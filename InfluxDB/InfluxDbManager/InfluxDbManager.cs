using System;
using System.Collections.Generic;
using System.Linq;


using FluentAssertions;

using System.Configuration;
using System.Threading.Tasks;

using Scada.DBUtility;

using Scada.Model;
using Temporal.Net.Common.Enums;
using Temporal.Net.InfluxDb;
using Temporal.Net.InfluxDb.Models;
using AutoFixture;
using Temporal.Net.InfluxDb.Models.Responses;
using System.Net.Http;
using System.Globalization;
 

namespace Temporal.DbAPI
{
    public delegate void ExceptionHandle(Exception ex);
    public class InfluxDbManager
    {

        public InfluxDbManager(string _uri, string _dbname, string _user, string _password, string _version)
        {
            _dbName = _dbname;
            Uri = _uri;
            User = _user;
            Password = _password;
            Version = _version;
        }
        public event ExceptionHandle InfluxException;
        private string _AlarmMeasurement = "DeviceParaAlarm";//报警数据表
        private string _AlarmConfigMeasurement = "DeviceParaAlarmConfig";//用户修改报警数据表
        private string _CommandsMeasurement = "DeviceParaCommands";//用户修改报警数据表
        private string _InfluxDBBackupMeasurement = "InfluxDBBackupLog";//备份信息表
        private int _AlarmConfigUpdateCryle = 10;//获取用户5秒前的报警设置信息
        private IInfluxDbClient _influx;
        private string _dbName = String.Empty;
        private readonly string _fakeDbPrefix = "SCADADB";
        private readonly string _fakeMeasurementPrefix = "SCADA";
        string Uri = "http://" + LocalIp.GetLocalIp() + ":8086";

        string User = "root";
        string Password = "root";
        public string Version = "v_1_3";
        private void DisplayException(Exception ex)
        {
            if (InfluxException != null)
            {
                InfluxException(ex);
            }
        }
        /// <summary>
        /// 配置数据库连接
        /// </summary>
        /// <returns></returns>
        public void  ShouldConnectInfluxDb()
        {


            try
            {


                //TODO: 使这个可写入的，以便它可以用不同的数据从测试服务器执行
                InfluxDbVersion influxVersion;
                if (!Enum.TryParse(Version, out influxVersion))
                    influxVersion = InfluxDbVersion.v_1_3;

                _influx = new InfluxDbClient(
                   Uri,
                   User,
                  Password,
                    influxVersion, QueryLocation.FormData);

                _influx.Should().NotBeNull();

                //如果不存在此数据库，则进行创建，否则不创建
                if (!ExistDatabases(_dbName))
                {
                    var createResponse = _influx.Database.CreateDatabaseAsync(_dbName).Result;
                    createResponse.Success.Should().BeTrue();

                }
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10002" + ex.Message));
            }



        }
        //清除数据库
        private async void PurgeDatabases()
        {
            try
            {
                var databasesResponse = _influx.Database.GetDatabasesAsync();
                var dbs = databasesResponse.Result;

                foreach (var db in dbs)
                {
                    if (db.Name.StartsWith(_fakeDbPrefix))
                        await _influx.Database.DropDatabaseAsync(db.Name);
                }
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10003" + ex.Message));
            }
        }
        private bool ExistDatabases(string dbName)
        {
            try
            {
                var databasesResponse = _influx.Database.GetDatabasesAsync();
                var dbs = databasesResponse.Result;

                foreach (var db in dbs)
                {
                    if (db.Name.Trim() == dbName)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                DisplayException(new Exception("ERR10004" + ex.Message));
                return false;
            }

        }
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        private bool BackupDatabases(string dbName)
        {
            try
            {
                var databasesResponse = _influx.Database.GetDatabasesAsync();
                var dbs = databasesResponse.Result;

                foreach (var db in dbs)
                {
                    if (db.Name.Trim() == dbName)
                    {
                      
                        return true;
                    }
                   
                }
                return false;
            }
            catch (Exception ex)
            {

                DisplayException(new Exception("ERR10004" + ex.Message));
                return false;
            }

        }
        /// <summary>
        /// 完成数据库的卸载(删除时序数据库)
        /// </summary>
        /// <returns></returns>
        protected void  FinalizeDropDatabase()
        {
            var deleteResponse = _influx.Database.DropDatabaseAsync(_dbName).Result;

            deleteResponse.Success.Should().BeTrue();
        }


        //删除数据库
        private async Task ShouldDropInfluxDb(string dbName)
        {
            try
            {


                // Act

                var deleteResponse = await _influx.Database.DropDatabaseAsync(dbName);

                // Assert

                deleteResponse.Success.Should().BeTrue();
            }
            catch (Exception ex)
            {

                DisplayException(new Exception("ERR10005" + ex.Message));

            }
        }
        /// <summary>
        /// 创建新的数据库
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        private async Task ShouldCreateInfluxDb(string dbName)
        {

            try
            {
                // Act
                var createResponse = await _influx.Database.CreateDatabaseAsync(dbName);


                // Assert
                createResponse.Success.Should().BeTrue();
            }
            catch (Exception ex)
            {

                DisplayException(new Exception("ERR10006" + ex.Message));

            }

        }
        /// <summary>
        /// 创建一个事实数据表
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>

        //写入设备数据表数据，如果没有相关设备的数据表，则对应建立相关结构
        private Point CreateDevicePoint(string serverid, string communicationid, IO_DEVICE device, DateTime? time)
        {
            try
            {

                Point point = new Point();
                point.Fields = CreateDeviceParaFields(device);
                point.Tags = CreateDeviceParaTags(serverid, communicationid, device);
                point.Timestamp = device.GetedValueDate;
                point.Name = _fakeMeasurementPrefix + "_" + device.TableName;

                return point;
            }
            catch
            {
                return null;
            }
        }
        private Point CreateDevicePoint(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, DateTime time)
        {


            return CreateDevicePoint(server.SERVER_ID, communication.IO_COMM_ID.ToString(), device, time);
        }
        //写入设备数据表数据，如果没有相关设备的数据表，则对应建立相关结构
        private Point[] CreateDevicePoint(List<IO_DEVICE> devices, DateTime time)
        {
            List<Point> Points = new List<Point>();
            for (int i = 0; i < devices.Count; i++)
            {
                Point np = CreateDevicePoint(devices[i].IO_SERVER_ID, devices[i].IO_COMM_ID, devices[i], time);
                if(np!=null)
                Points.Add(np);
            }
            return Points.ToArray();
        }
        private Point CreateAlarmPoint(string serverid, string communicationid, IO_PARAALARM alarm, DateTime time)
        {

            Point point = new Point();
            point.Fields = CreateParaAlarmFields(alarm);
            point.Tags = CreateParaAlarmTags(serverid, communicationid, alarm);
            point.Timestamp = time;
            point.Name = _fakeMeasurementPrefix + "_" + _AlarmMeasurement;

            return point;
        }
        private Point[] CreateAlarmPoints(List<IO_PARAALARM> alarms, DateTime time)
        {
            List<Point> Points = new List<Point>();
            for (int i = 0; i < alarms.Count; i++)
            {
                Point np = CreateAlarmPoint(alarms[i].IO_SERVER_ID, alarms[i].IO_COMM_ID, alarms[i], time);
                if(np!=null)
                Points.Add(np);
            }
            return Points.ToArray();
        }
        private Point CreateAlarmConfigPoint(string serverid, string communicationid, IO_ALARM_CONFIG alarm, DateTime? time)
        {

            Point point = new Point();
            point.Fields = this.CreateParaAlarmConfigFields(alarm);
            point.Tags = this.CreateParaAlarmConfigTags(serverid, communicationid, alarm);
            point.Timestamp = time;
            point.Name = _fakeMeasurementPrefix + "_" + _AlarmConfigMeasurement;

            return point;
        }
        private Point[] CreateAlarmConfigPoints(List<IO_PARAALARM> alarms, DateTime time)
        {
            List<Point> Points = new List<Point>();
            for (int i = 0; i < alarms.Count; i++)
            {
                Point np = CreateAlarmPoint(alarms[i].IO_SERVER_ID, alarms[i].IO_COMM_ID, alarms[i], time);
                if (np != null)
                    Points.Add(np);
            }
            return Points.ToArray();
        }
        private Point CreateCommandPoint(string serverid, string communicationid, IO_COMMANDS command, DateTime? time)
        {

            Point point = new Point();
            point.Fields = this.CreateCommandFields(command);
            point.Tags = this.CreateCommandTags(serverid, communicationid, command);
            point.Timestamp = time;
            point.Name = _fakeMeasurementPrefix + "_" + _CommandsMeasurement;

            return point;
        }
        private Point[] CreateCommandPoints(List<IO_COMMANDS> commands, DateTime time)
        {
            List<Point> Points = new List<Point>();
            for (int i = 0; i < commands.Count; i++)
            {
                Point np = CreateCommandPoint(commands[i].IO_SERVER_ID, commands[i].IO_COMM_ID, commands[i], time);
                if (np != null)
                    Points.Add(np);
            }
            return Points.ToArray();
        }
        //////////////////
        private Point CreateBackupPoint(InfluxDBBackupLog backup, DateTime? time)
        {

            Point point = new Point();
            point.Fields = this.CreateBackupFields(backup);
            point.Tags = this.CreateBackupTags(backup);
            point.Timestamp = time;
            point.Name = _fakeMeasurementPrefix + "_" + this._InfluxDBBackupMeasurement;

            return point;
        }
        private Point[] CreateBackupPoints(List<IO_COMMANDS> commands, DateTime time)
        {
            List<Point> Points = new List<Point>();
            for (int i = 0; i < commands.Count; i++)
            {
                Point np = CreateCommandPoint(commands[i].IO_SERVER_ID, commands[i].IO_COMM_ID, commands[i], time);
                if (np != null)
                    Points.Add(np);
            }
            return Points.ToArray();
        }
        /// <summary>
        /// 返回已经存在的数据库列表
        /// </summary>
        /// <returns></returns>
        private async Task DbShowDatabases_OnDatabaseExists_ShouldReturnDatabaseList(string dbName)
        {

            try
            {
                // Act
                var databases = await _influx.Database.GetDatabasesAsync();

                // Assert
                databases
                    .Should()
                    .NotBeNullOrEmpty();

                databases
                    .Where(db => db.Name.Equals(dbName))
                    .Single()
                    .Should()
                    .NotBeNull();
            }
            catch (Exception ex)
            {

                DisplayException(new Exception("ERR10007" + ex.Message));


            }
        }
        /// <summary>
        /// 写入数据
        /// </summary>
        /// <returns></returns>
        public async Task DbWrite_RealPoints(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, DateTime? time)
        {
            try
            {

                if (server == null)
                {
                    DisplayException(new Exception("ERR10009_1 Server IS NULL"));
                }
                if (communication == null)
                {
                    DisplayException(new Exception("ERR10009_2 Communication IS NULL"));
                }
                if (device == null)
                {
                    DisplayException(new Exception("ERR10009_2 Device IS NULL"));
                }
                var points = CreateDevicePoint(server.SERVER_ID, communication.IO_COMM_ID, device, time);
                if (points != null)
                {
                    var writeResponse = await _influx.Client.WriteAsync(points, _dbName, null, "ms");
                    if (writeResponse != null)
                        writeResponse.Success.Should().BeTrue();
                }

            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10009" + ex.Message));


            }

        }
        /// <summary>
 
        public async Task DbWrite_RealPoints(List<IO_DEVICE> devices, DateTime time)
        {
            try
            {


                var points = CreateDevicePoint(devices, time);
                var writeResponse = await _influx.Client.WriteAsync(points, _dbName, null, "ms");

            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10010" + ex.Message));

            }

        }


        ///////////////////////报警写入
        /// <summary>
        /// 写入数据
        /// </summary>
        /// <returns></returns>
        public async Task DbWrite_AlarmPoints(string serverid, string communicationid, IO_PARAALARM alarm, DateTime time)
        {
            try
            {

                 
                if (alarm == null)
                {
                    DisplayException(new Exception("ERR10009_2 Device IS NULL"));
                }
                var points = this.CreateAlarmPoint(serverid, communicationid, alarm, time);
                if (points != null)
                {
                    var writeResponse = await _influx.Client.WriteAsync(points, _dbName, null, "ms");
                    if (writeResponse != null)
                        writeResponse.Success.Should().BeTrue();
                }

            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10009" + ex.Message));


            }

        }
        /// <summary>

        public async Task DbWrite_AlarmPoints(List<IO_PARAALARM> alarms, DateTime time)
        {
            try
            {


                var points = CreateAlarmPoints( alarms, time);
                var writeResponse = await _influx.Client.WriteAsync(points, _dbName, null, "ms");

            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10010" + ex.Message));

            }

        }

        ////////////////////////结束报警写入


        ///////////////////////报警配置日志写入
        /// <summary>
        /// 写入数据
        /// </summary>
        /// <returns></returns>
        public async Task DbWrite_AlarmConfigPoints(string serverid, string communicationid, IO_ALARM_CONFIG alarm, DateTime? time)
        {
            try
            {


                if (alarm == null)
                {
                    DisplayException(new Exception("ERR40009_2 Device IS NULL"));
                }
                var points = this.CreateAlarmConfigPoint(serverid, communicationid, alarm, time);
                if (points != null)
                {
                    var writeResponse = await _influx.Client.WriteAsync(points, _dbName, null, "ms");
                    if (writeResponse != null)
                        writeResponse.Success.Should().BeTrue();
                }

            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR40009" + ex.Message));


            }

        }
        /// <summary>

        public async Task DbWrite_AlarmConfigPoints(List<IO_PARAALARM> alarms, DateTime time)
        {
            try
            {


                var points = CreateAlarmConfigPoints(alarms, time);
                var writeResponse = await _influx.Client.WriteAsync(points, _dbName, null, "ms");

            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10010" + ex.Message));

            }

        }

        ////////////////////////结束报警写入

        //写入命令下置操作
        public async Task DbWrite_CommandPoint(string serverid, string communicationid, IO_COMMANDS command, DateTime? time)
        {
            try
            {


                if (command == null)
                {
                    DisplayException(new Exception("ERR50109_2 Device IS NULL"));
                }
                var points = this.CreateCommandPoint(serverid, communicationid, command, time);
                if (points != null)
                {
                    var writeResponse = await _influx.Client.WriteAsync(points, _dbName, null, "ms");
                    if (writeResponse != null)
                        writeResponse.Success.Should().BeTrue();
                }

            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR50109" + ex.Message));


            }

        }
        public async Task DbWrite_CommandPoints(List<IO_COMMANDS> commands, DateTime time)
        {
            try
            {


                var points = this.CreateCommandPoints(commands, time);
                var writeResponse = await _influx.Client.WriteAsync(points, _dbName, null, "ms");

            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10010" + ex.Message));

            }

        }
        /// <summary>
        /// 写入数据库备份日志
        /// </summary>
        /// <param name="backup"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task DbWrite_BackupPoints(InfluxDBBackupLog backup, DateTime time)
        {
            try
            {


                var points = this.CreateBackupPoint(backup, time);
                var writeResponse = await _influx.Client.WriteAsync(points, _dbName, null, "ms");

            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR13010" + ex.Message));

            }

        }
        ////////////////////////////////////////以下是读取相关的方法
        public static  string GetInfluxdbValue(object obj)
        {
            if (obj == null)
                return "";
            if(obj.GetType()==typeof(string))
            {
                return obj == null ? "" : obj.ToString();
            }
            else if (obj.GetType() == typeof(DateTime))
            {
                DateTime dt = DateTime.Now;
                if(DateTime.TryParse(obj == null ? "" : obj.ToString(), out dt))
                {
                    return dt.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return obj == null ? "-9999" : obj.ToString();
            }

        }
        //读取数据库备份日志,分页读取
        public async Task<InfluxDBHistoryData> DbQuery_Backup(int PageSize,int PageIndex)
        {
            //条件限制最大页是10000条，超过此数量，强制归为最大数量
            if (PageSize > 10000)
                PageSize = 10000;
            InfluxDBHistoryData datas = new InfluxDBHistoryData();
            try
            {
          
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;
                try
                {
                    string queryCount = "SELECT COUNT(field_device_date) FROM " + _fakeMeasurementPrefix + "_" + this._InfluxDBBackupMeasurement + "  ";
                    var readerCountResponse = await _influx.Client.QueryAsync(queryCount, _dbName);
                    string query = "select * from " + _fakeMeasurementPrefix + "_" + _InfluxDBBackupMeasurement + "    ORDER BY time DESC   LIMIT " + PageSize + " OFFSET " + (PageIndex - 1) * PageSize + "    ";
                    if (readerCountResponse != null && readerCountResponse.Count() > 0)
                    {
                        Serie s = readerCountResponse.Last();
                        if (s != null && s.Values.Count == 1)
                        {
                            if (s.Values[0][1] != null)
                            {
                                datas.RecordCount = int.Parse(s.Values[0][1].ToString());
                            }

                        }
                    }
                    datas.PageCount = datas.RecordCount / datas.PageSize;
                    if (datas.RecordCount % datas.PageSize != 0)
                    {
                        datas.PageCount++;
                    }
                    if (datas.PageCount == 0)
                    {
                        datas.PageIndex = 0;

                    }

                    var readerResponse = await _influx.Client.QueryAsync(query, _dbName);
                    datas.Seres = readerResponse;
                    datas.ReturnResult = true;
                    if (+datas.RecordCount > 0)
                        datas.Msg = "共计有" + datas.RecordCount + "条数据,当前" + datas.PageIndex + "/" + datas.PageCount + ",每页显示" + datas.PageSize;
                    else
                        datas.Msg = "没有符合查询条件的数据";
                }
                catch 
                {
                    datas.ReturnResult = false;
                    datas.Msg = "查询异常";
                }
                return datas;
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10015" + ex.Message));
                return null;

            }
        }

        //结束命令下置操作

        /// <summary>
        /// 读取一个设备的系列数据,并将读取的数据保存的Device
        /// </summary>
        /// <param name="server">采集站</param>
        /// <param name="communication">通道</param>
        /// <param name="device">设备</param>
        /// <returns></returns>
        public async Task<IEnumerable<Serie>> DbQuery_Real(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device)
        {
            try
            {

                string query = "select * from " + _fakeMeasurementPrefix + "_" + device.TableName + " where   time> '" + DateTime.Now.AddSeconds(-device.IO_DEVICE_UPDATECYCLE).ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY time DESC ";


                var readerResponse = await _influx.Client.QueryAsync(query, _dbName);
                return readerResponse;
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10011" + ex.Message));
                return null;

            }



        }
        
  
        /// <summary>
        /// 读取某个设备的历史数据
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="SDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex">从1开始</param>
        /// <returns></returns>
        public async Task<InfluxDBHistoryData> DbQuery_History(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device,DateTime SDate, DateTime EDate,int PageSize,int PageIndex)
        {
            //条件限制最大页是10000条，超过此数量，强制归为最大数量
            if (PageSize > 10000)
                PageSize = 10000;
            try
            {
                InfluxDBHistoryData datas = new InfluxDBHistoryData();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;
                try
                {
                    string queryCount = "SELECT COUNT(field_device_date) FROM " + _fakeMeasurementPrefix + "_" + device.TableName + " where   time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY time DESC  ";
                    var readerCountResponse = await _influx.Client.QueryAsync(queryCount, _dbName);
                    string query = "select * from " + _fakeMeasurementPrefix + "_" + device.TableName + " where   time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "'    ORDER BY time DESC   LIMIT " + PageSize + " OFFSET "+ (PageIndex-1)* PageSize + "    ";
                    if (readerCountResponse != null && readerCountResponse.Count() > 0)
                    {
                        Serie s = readerCountResponse.Last();
                        if (s != null && s.Values.Count == 1)
                        {
                            if (s.Values[0][1] != null)
                            {
                                datas.RecordCount = int.Parse(s.Values[0][1].ToString());
                            }

                        }
                    }
                    datas.PageCount = datas.RecordCount / datas.PageSize;
                    if (datas.RecordCount % datas.PageSize != 0)
                    {
                        datas.PageCount++;
                    }
                    if(datas.PageCount==0)
                    {
                        datas.PageIndex = 0;

                    }

                    var readerResponse = await _influx.Client.QueryAsync(query, _dbName);
                    datas.Seres = readerResponse;
                    datas.ReturnResult = true;
                    if (+datas.RecordCount > 0)
                        datas.Msg = "共计有" + datas.RecordCount + "条数据,当前" + datas.PageIndex + "/" + datas.PageCount + ",每页显示" + datas.PageSize;
                    else
                        datas.Msg = "没有符合查询条件的数据";
                }
                catch
                {
                    datas.ReturnResult = false;
                    datas.Msg = "查询异常";
                }
                return datas;
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10015" + ex.Message));
                return null;

            }



        }
        /// <summary>
        /// 读取某个设备的统计数据
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="SDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex">从1开始</param>
        /// <returns></returns>
        public async Task<InfluxDBHistoryData> DbQuery_HistoryStatics(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, DateTime SDate, DateTime EDate, int PageSize, int PageIndex,string selected,string timespan)
        {
            //条件限制最大页是10000条，超过此数量，强制归为最大数量
            if (PageSize > 10000)
                PageSize = 10000;
            try
            {
                InfluxDBHistoryData datas = new InfluxDBHistoryData();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;
                try
                {
                    string queryCount = "SELECT COUNT(*) FROM " + _fakeMeasurementPrefix + "_" + device.TableName + " where    time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "'  group by time("+ timespan + ")";
                    var readerCountResponse = await _influx.Client.QueryAsync(queryCount, _dbName);
                    string query = "select "+ selected + " from " + _fakeMeasurementPrefix + "_" + device.TableName + " where    time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "'      group by time(" + timespan + ")   ORDER BY time DESC  LIMIT " + PageSize + " OFFSET " + (PageIndex - 1) * PageSize + "    ";
 
                    if (readerCountResponse != null && readerCountResponse.Count() > 0)
                    {
                        Serie s = readerCountResponse.Last();
                        if (s != null)
                        {
                           
                                datas.RecordCount = int.Parse(s.Values.Count.ToString());
                          

                        }
                    }
                    datas.PageCount = datas.RecordCount / datas.PageSize;
                    if (datas.RecordCount % datas.PageSize != 0)
                    {
                        datas.PageCount++;
                    }
                    if (datas.PageCount == 0)
                    {
                        datas.PageIndex = 0;

                    }

                    var readerResponse = await _influx.Client.QueryAsync(query, _dbName);
                    datas.Seres = readerResponse;
                    datas.ReturnResult = true;
                    if (+datas.RecordCount > 0)
                        datas.Msg = "共计有" + datas.RecordCount + "条数据,当前" + datas.PageIndex + "/" + datas.PageCount + ",每页显示" + datas.PageSize;
                    else
                        datas.Msg = "没有符合查询条件的数据";
                }
                catch 
                {
                    datas.ReturnResult = false;
                    datas.Msg = "查询异常";
                }
                return datas;
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10015" + ex.Message));
                return null;

            }



        }

        /// <summary>
        /// 读取某个设备的历史报警数据
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="SDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex">从1开始</param>
        /// <returns></returns>
        public async Task<InfluxDBHistoryData> DbQuery_Alarms(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, DateTime SDate, DateTime EDate, string AlarmType,string  AlarmLevel, int PageSize, int PageIndex)
        {
            //dict.Add("tag_did", alarm.IO_DEVICE_ID.ToString());
            //dict.Add("tag_cid", communicationid.ToString());
            //dict.Add("tag_sid", serverid.ToString());
            //dict.Add("tag_ioid", alarm.IO_ID.ToString());
            //dict.Add("tag_type", (string)alarm.IO_ALARM_TYPE);
            //dict.Add("tag_level", (string)alarm.IO_ALARM_VALUE);
            //条件限制最大页是10000条，超过此数量，强制归为最大数量
            if (PageSize > 10000)
                PageSize = 10000;
            try
            {
                InfluxDBHistoryData datas = new InfluxDBHistoryData();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;
                string where = "time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and  tag_sid='"+ server.SERVER_ID + "' and tag_cid='"+ communication.IO_COMM_ID + "' and tag_did='"+ device .IO_DEVICE_ID+ "'";
                if(AlarmType!="")
                {
                    where = " and  tag_type='"+ AlarmType + "'";
                }
                if (AlarmLevel != "")
                {
                    where = " and  tag_level='" + AlarmLevel + "'";
                }
                try
                {
                    string queryCount = "SELECT COUNT(field_io_alarm_date) FROM " + _fakeMeasurementPrefix + "_" + _AlarmMeasurement + " where   "+ where+ " ORDER BY time DESC  ";
                    var readerCountResponse = await _influx.Client.QueryAsync(queryCount, _dbName);
                    string query = "select * from " + _fakeMeasurementPrefix + "_" + _AlarmMeasurement + " where  "+ where + "     ORDER BY time DESC   LIMIT " + PageSize + " OFFSET " + (PageIndex - 1) * PageSize + "    ";
                    if (readerCountResponse != null && readerCountResponse.Count() > 0)
                    {
                        Serie s = readerCountResponse.Last();
                        if (s != null && s.Values.Count == 1)
                        {
                            if (s.Values[0][1] != null)
                            {
                                datas.RecordCount = int.Parse(s.Values[0][1].ToString());
                            }

                        }
                    }
                    datas.PageCount = datas.RecordCount / datas.PageSize;
                    if (datas.RecordCount % datas.PageSize != 0)
                    {
                        datas.PageCount++;
                    }
                    if (datas.PageCount == 0)
                    {
                        datas.PageIndex = 0;

                    }

                    var readerResponse = await _influx.Client.QueryAsync(query, _dbName);
                    datas.Seres = readerResponse;
                    datas.ReturnResult = true;
                    if (+datas.RecordCount > 0)
                        datas.Msg = "共计有" + datas.RecordCount + "条数据,当前" + datas.PageIndex + "/" + datas.PageCount + ",每页显示" + datas.PageSize;
                    else
                        datas.Msg = "没有符合查询条件的数据";
                }
                catch  
                {
                    datas.ReturnResult = false;
                    datas.Msg = "查询异常";
                }
                return datas;
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10015" + ex.Message));
                return null;

            }



        }


        /// <summary>
        /// 读取某个设备的下置命令历史记录
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="SDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex">从1开始</param>
        /// <returns></returns>
        public async Task<InfluxDBHistoryData> DbQuery_Commands(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, DateTime SDate, DateTime EDate, int PageSize, int PageIndex)
        {
            //dict.Add("tag_did", alarm.IO_DEVICE_ID.ToString());
            //dict.Add("tag_cid", communicationid.ToString());
            //dict.Add("tag_sid", serverid.ToString());
            //dict.Add("tag_ioid", alarm.IO_ID.ToString());
            //dict.Add("tag_type", (string)alarm.IO_ALARM_TYPE);
            //dict.Add("tag_level", (string)alarm.IO_ALARM_VALUE);
            //条件限制最大页是10000条，超过此数量，强制归为最大数量
            if (PageSize > 10000)
                PageSize = 10000;
            try
            {
                InfluxDBHistoryData datas = new InfluxDBHistoryData();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;
                string where = "time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and  tag_sid='" + server.SERVER_ID + "' and tag_cid='" + communication.IO_COMM_ID + "' and tag_did='" + device.IO_DEVICE_ID + "'";
               
                try
                {
                    string queryCount = "SELECT COUNT(field_command_date) FROM " + _fakeMeasurementPrefix + "_" + _CommandsMeasurement + " where   " + where;
                    var readerCountResponse = await _influx.Client.QueryAsync(queryCount, _dbName);
                    string query = "select * from " + _fakeMeasurementPrefix + "_" + _CommandsMeasurement + " where  " + where + "     ORDER BY time DESC   LIMIT " + PageSize + " OFFSET " + (PageIndex - 1) * PageSize + "    ";
                    if (readerCountResponse != null && readerCountResponse.Count() > 0)
                    {
                        Serie s = readerCountResponse.Last();
                        if (s != null && s.Values.Count == 1)
                        {
                            if (s.Values[0][1] != null)
                            {
                                datas.RecordCount = int.Parse(s.Values[0][1].ToString());
                            }

                        }
                    }
                    datas.PageCount = datas.RecordCount / datas.PageSize;
                    if (datas.RecordCount % datas.PageSize != 0)
                    {
                        datas.PageCount++;
                    }
                    if (datas.PageCount == 0)
                    {
                        datas.PageIndex = 0;

                    }

                    var readerResponse = await _influx.Client.QueryAsync(query, _dbName);
                    datas.Seres = readerResponse;
                    datas.ReturnResult = true;
                    if (+datas.RecordCount > 0)
                        datas.Msg = "共计有" + datas.RecordCount + "条数据,当前" + datas.PageIndex + "/" + datas.PageCount + ",每页显示" + datas.PageSize;
                    else
                        datas.Msg = "没有符合查询条件的数据";
                }
                catch  
                {
                    datas.ReturnResult = false;
                    datas.Msg = "查询异常";
                }
                return datas;
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10015" + ex.Message));
                return null;

            }



        }
        /// <summary>
        /// 读取某个设备的下置命令历史记录
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="SDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex">从1开始</param>
        /// <returns></returns>
        public async Task<InfluxDBHistoryData> DbQuery_AlarmConfigs(IO_SERVER server, IO_COMMUNICATION communication, IO_DEVICE device, DateTime SDate, DateTime EDate, int PageSize, int PageIndex)
        {
          
            if (PageSize > 10000)
                PageSize = 10000;
            try
            {
                InfluxDBHistoryData datas = new InfluxDBHistoryData();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;
                string where = "time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and  tag_sid='" + server.SERVER_ID + "' and tag_cid='" + communication.IO_COMM_ID + "' and tag_did='" + device.IO_DEVICE_ID + "'";

                try
                {
                    string queryCount = "SELECT COUNT(field_command_date) FROM " + _fakeMeasurementPrefix + "_" + _AlarmConfigMeasurement + " where   " + where;
                    var readerCountResponse = await _influx.Client.QueryAsync(queryCount, _dbName);
                    string query = "select * from " + _fakeMeasurementPrefix + "_" + _AlarmConfigMeasurement + " where  " + where + "     ORDER BY time DESC   LIMIT " + PageSize + " OFFSET " + (PageIndex - 1) * PageSize + "    ";
                    if (readerCountResponse != null && readerCountResponse.Count() > 0)
                    {
                        Serie s = readerCountResponse.Last();
                        if (s != null && s.Values.Count == 1)
                        {
                            if (s.Values[0][1] != null)
                            {
                                datas.RecordCount = int.Parse(s.Values[0][1].ToString());
                            }

                        }
                    }
                    datas.PageCount = datas.RecordCount / datas.PageSize;
                    if (datas.RecordCount % datas.PageSize != 0)
                    {
                        datas.PageCount++;
                    }
                    if (datas.PageCount == 0)
                    {
                        datas.PageIndex = 0;

                    }

                    var readerResponse = await _influx.Client.QueryAsync(query, _dbName);
                    datas.Seres = readerResponse;
                    datas.ReturnResult = true;
                    if (+datas.RecordCount > 0)
                        datas.Msg = "共计有" + datas.RecordCount + "条数据,当前" + datas.PageIndex + "/" + datas.PageCount + ",每页显示" + datas.PageSize;
                    else
                        datas.Msg = "没有符合查询条件的数据";
                }
                catch  
                {
                    datas.ReturnResult = false;
                    datas.Msg = "查询异常";
                }
                return datas;
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10015" + ex.Message));
                return null;

            }



        }
        /// <summary>
        /// 读取用户重新设置的报警配置信息
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Serie>> DbQuery_AlarmConfig()
        {
            try
            {

                string query = "select * from " + _fakeMeasurementPrefix + "_" + this._AlarmConfigMeasurement + " where   time> '" + DateTime.Now.AddSeconds(-this._AlarmConfigUpdateCryle).ToString("yyyy-MM-dd HH:mm:ss") + "'";


                var writeResponse = await _influx.Client.QueryAsync(query, _dbName);
                return writeResponse;
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10011" + ex.Message));
                return null;

            }



        }

        /// <summary>
        /// 读取多个设备数据并返回
        /// </summary>
        /// <param name="devices"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IEnumerable<Serie>>> MultiQueryAsync(List<IO_DEVICE> devices)
        {
            try
            {
                List<string> querys = new List<string>();
                for (int i = 0; i < devices.Count; i++)
                {
                    string query = "select * from " + _fakeMeasurementPrefix + "_" + devices[i].TableName + " where   time>='" + DateTime.Now.AddSeconds(0 - devices[i].IO_DEVICE_UPDATECYCLE).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    querys.Add(query);

                }

                var writeResponse = await _influx.Client.MultiQueryAsync(querys, _dbName, null);
                return writeResponse;
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10012" + ex.Message));
                return null;

            }
        }
        /// <summary>
        /// 创建实时数据表中的Tags
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private Dictionary<string, object> CreateDeviceParaTags(string serverid, string communicationid, IO_DEVICE device)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                dict.Add("tag_did", device.IO_DEVICE_ID.ToString());
                dict.Add("tag_cid", communicationid.ToString());
                dict.Add("tag_sid", serverid.ToString());
          
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10013" + ex.Message));
            }

            return dict;
        }
        /// <summary>
        /// 创建实时数据表中的Fields
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private Dictionary<string, object> CreateDeviceParaFields(IO_DEVICE device)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
            
                //新增加一个时间点的
                dict.Add("field_device_date", device.GetedValueDate == null ? "" : device.GetedValueDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));//创建数据采集时间,总时间，这个时间是所有数据统一获取的时间

                for (int i = 0; i < device.IOParas.Count; i++)
                {
                    IO_PARA npara = device.IOParas[i];
                    if (npara.IORealData == null)
                    {
                        npara.IORealData = new Scada.IOStructure.IOData();
                        npara.IORealData.Date = device.GetedValueDate;
                    }
                    npara.IORealData.ServerID = device.IO_SERVER_ID;
                    npara.IORealData.CommunicationID = device.IO_COMM_ID;
                    npara.IORealData.ID = device.IO_DEVICE_ID;
                 
                    if (npara.IORealData.ParaValue == null || npara.IORealData.ParaValue == "")
                    {
                        npara.IORealData.ParaValue = "-9999";
                        npara.IORealData.QualityStamp = Scada.IOStructure.QualityStamp.BAD;
                    }
                    if (dict.ContainsKey("field_" + npara.IO_NAME.ToLower().Trim() + "_datetime"))
                    {
                        dict.Remove("field_" + npara.IO_NAME.ToLower().Trim() + "_datetime");
                    }
                    dict.Add("field_" + npara.IO_NAME.ToLower().Trim() + "_datetime", npara.IORealData == null ? "" : npara.IORealData.Date.Value.ToString("yyyy-MM-dd HH:mm:ss"));//创建数据采集时间


                    if (dict.ContainsKey("field_" + npara.IO_NAME.ToLower().Trim() + "_qualitystamp"))
                    {
                        dict.Remove("field_" + npara.IO_NAME.ToLower().Trim() + "_qualitystamp");

                    }

                    dict.Add("field_" + npara.IO_NAME.ToLower().Trim() + "_qualitystamp", npara.IORealData.QualityStamp.ToString());//创建质量戳
                    if (dict.ContainsKey("field_" + npara.IO_NAME.ToLower().Trim() + "_value"))
                    {
                        dict.Remove("field_" + npara.IO_NAME.ToLower().Trim() + "_value");
                    }
                    try
                    {
                        if (npara.IORealData == null)
                        {
                            npara.IORealData = new Scada.IOStructure.IOData();
                            npara.IORealData.ParaName = npara.IO_NAME;
                            npara.IORealData.ParaValue = "-9999";
                            npara.IORealData.QualityStamp = Scada.IOStructure.QualityStamp.BAD;
                            npara.IORealData.Date = device.GetedValueDate;
                        }

                        double dbvalue = -9999;
                        if (!double.TryParse(npara.IORealData.ParaValue, out dbvalue))//表示字符串
                        {
                           if(npara.IO_POINTTYPE=="字符串"|| npara.IO_POINTTYPE == "常量值")
                            {
                                npara.IORealData.QualityStamp = Scada.IOStructure.QualityStamp.GOOD;
                                dict.Add("field_" + npara.IO_NAME.ToLower().Trim() + "_value", npara.IORealData.ParaValue.ToString());
                            }
                           
                        }
                        else
                        {
                            dict.Add("field_" + npara.IO_NAME.ToLower().Trim() + "_value", Convert.ToSingle(dbvalue));

                        }

 

                    }
                    catch (Exception ex)
                    {
                        dict.Add("field_" + npara.IO_NAME.ToLower().Trim() + "_value", null);
                        DisplayException(new Exception("ERR10001  错误" + npara.IORealData.ParaValue + " " + ex.Message));
                    }
                }
                return dict;

            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10201  错误 " + ex.Message));
            }

            return null;

        }

        /// <summary>
        /// 创建实时数据表中的Tags
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private Dictionary<string, object> CreateParaAlarmTags(string serverid, string communicationid, IO_PARAALARM alarm)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                dict.Add("tag_did", alarm.IO_DEVICE_ID.ToString());
                dict.Add("tag_cid", communicationid.ToString());
                dict.Add("tag_sid", serverid.ToString());
                dict.Add("tag_ioid", alarm.IO_ID.ToString());
                dict.Add("tag_type", (string)alarm.IO_ALARM_TYPE);
                dict.Add("tag_level", (string)alarm.IO_ALARM_LEVEL);
                dict.Add("tag_device_name", (string)alarm.DEVICE_NAME);
             
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10013" + ex.Message));
            }

            return dict;
        }
        /// <summary>
        /// 创建实时数据表中的Fields
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private Dictionary<string, object> CreateParaAlarmFields(IO_PARAALARM alarm)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            dict.Add("field_io_alarm_date", (string)alarm.IO_ALARM_DATE);
            dict.Add("field_io_alarm_disposalidea", (string)alarm.IO_ALARM_DISPOSALIDEA);
            dict.Add("field_io_alarm_disposaluser", (string)alarm.IO_ALARM_DISPOSALUSER);
            dict.Add("field_io_alarm_level", (string)alarm.IO_ALARM_LEVEL);
            dict.Add("field_io_alarm_type", (string)alarm.IO_ALARM_TYPE);
            dict.Add("field_io_alarm_value", (string)alarm.IO_ALARM_VALUE);
            dict.Add("field_io_label", (string)alarm.IO_LABEL);
            dict.Add("field_io_name", (string)alarm.IO_NAME);
            
            return dict;
        }
        ///
        /// <summary>
        /// 创建实时数据表中的Tags
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private Dictionary<string, object> CreateParaAlarmConfigTags(string serverid, string communicationid, IO_ALARM_CONFIG alarm)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                dict.Add("tag_did", alarm.IO_DEVICE_ID.ToString());
                dict.Add("tag_cid", communicationid.ToString());
                dict.Add("tag_sid", serverid.ToString());
                dict.Add("tag_ioid", alarm.IO_ID.ToString());
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR40013" + ex.Message));
            }

            return dict;
        }
        /// <summary>
        /// 创建实时数据表中的Fields
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private Dictionary<string, object> CreateParaAlarmConfigFields(IO_ALARM_CONFIG alarm)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("field_update_date", alarm.UPDATE_DATE.ToString());
            dict.Add("field_update_result", alarm.UPDATE_RESULT.ToString());
            dict.Add("field_update_uid", alarm.UPDATE_UID.ToString());
            dict.Add("field_io_label", alarm.IO_LABEL.ToString());
            dict.Add("field_io_name", alarm.IO_NAME.ToString());
          
            dict.Add("field_io_condition", (string)alarm.IO_CONDITION);
            dict.Add("field_io_enable_maxmax",  alarm.IO_ENABLE_MAXMAX.ToString());
            dict.Add("field_io_maxmax_type", alarm.IO_MAXMAX_TYPE.ToString());
            dict.Add("field_io_maxmax_value", alarm.IO_MAXMAX_VALUE.ToString());
            dict.Add("field_io_enable_max", alarm.IO_ENABLE_MAX.ToString());
            dict.Add("field_io_max_type", alarm.IO_MAX_TYPE.ToString());
            dict.Add("field_io_max_value", alarm.IO_MAX_VALUE.ToString());
            dict.Add("field_io_enable_min", alarm.IO_ENABLE_MIN.ToString());
            dict.Add("field_io_min_type", alarm.IO_MIN_TYPE.ToString());
            dict.Add("field_io_min_value", alarm.IO_MIN_VALUE.ToString());
            dict.Add("field_io_enable_minmin", alarm.IO_ENABLE_MINMIN.ToString());
            dict.Add("field_io_minmin_type", alarm.IO_MINMIN_TYPE.ToString());
            dict.Add("field_io_minmin_value", alarm.IO_MINMIN_VALUE.ToString());

       
            return dict;
        }


        ///
        /// <summary>
        /// 创建实时数据表中的Tags
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private Dictionary<string, object> CreateCommandTags(string serverid, string communicationid, IO_COMMANDS command)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                dict.Add("tag_did", command.IO_DEVICE_ID.ToString());
                dict.Add("tag_cid", communicationid.ToString());
                dict.Add("tag_sid", serverid.ToString());
                dict.Add("tag_ioid", command.IO_ID.ToString());
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR51013" + ex.Message));
            }

            return dict;
        }
        /// <summary>
        /// 创建实时数据表中的Fields
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private Dictionary<string, object> CreateCommandFields(IO_COMMANDS command)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            dict.Add("field_command_date", (string)command.COMMAND_DATE);
            dict.Add("field_command_id", command.COMMAND_ID.ToString());
            dict.Add("field_command_result", (string)command.COMMAND_RESULT);
            dict.Add("field_command_user", (string)command.COMMAND_USER);
            dict.Add("field_command_value", command.COMMAND_VALUE.ToString());
            dict.Add("field_label", command.IO_LABEL.ToString());
            dict.Add("field_name", command.IO_LABEL.ToString());
            return dict;
        }


        ////////////////数据库备份
        ///
        /// <summary>
        /// 创建实时数据表中的Tags
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private Dictionary<string, object>CreateBackupTags(InfluxDBBackupLog backup)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                dict.Add("tag_backup_id", backup.BackUpID.ToString());
     
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR51013" + ex.Message));
            }

            return dict;
        }
        /// <summary>
        /// 创建实时数据表中的Fields
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private Dictionary<string, object> CreateBackupFields(InfluxDBBackupLog backup)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            dict.Add("field_backup_date", (string)backup.BackUpDate);
            dict.Add("field_backup_file", (string)backup.BackUpFile);
            dict.Add("field_backup_result", (string)backup.BackUpResult);
            dict.Add("field_backup_path", (string)backup.BackUpPath);
 
            return dict;
        }

    }
}
