using Temporal.Net.Common.Enums;
using Temporal.Net.InfluxDb;
using Temporal.Net.InfluxDb.Models;
using Temporal.Net.InfluxDb.Models.Responses;
using ScadaWeb.Common;
using ScadaWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Temporal.WebDbAPI
{
    public class InfluxDBHistoryResult
    {
        public IEnumerable<Serie> Seres = null;
        public int PageSize = 5000;
        public int PageCount = 0;
        public int PageIndex = 1;
        public int RecordCount = 0;
        /// <summary>
        /// 查询成功与否的条件
        /// </summary>
        public bool ReturnResult = false;
        /// <summary>
        /// 返回的相关说明
        /// </summary>
        public string Msg = "";
    }
    public class InfluxDBQueryPara
    {
        /// <summary>
        /// 通讯状态
        /// </summary>
        public int DeviceStatus { set; get; }
        public string IOServerID
        {
            set;
            get;
        }
        public string IOCommunicateID
        {
            set;
            get;
        }
        public string IODeviceID
        {
            set;
            get;
        }
        public string TableName
        {
            get { return    IOServerID + "_" + IODeviceID; }
        }
        public string SDate
        {
            set;
            get;
        }
        public string EDate
        {
            set;
            get;
        }
        public int UpdateCycle
        {
            set;
            get;
        }
        public string Fields = "";
    }
    public delegate void ExceptionHandle(Exception ex);
    public class WebInfluxDbManager
    {
        public WebInfluxDbManager(string _uri, string _dbname, string _user, string _password, string _version)
        {
            _dbName = _dbname;
            Uri = _uri;
            User = _user;
            Password = _password;
            Version = _version;

            ShouldConnectInfluxDb();
        }
        public WebInfluxDbManager()
        {
            _dbName = Configs.GetValue("InfluxDataBase");
            Uri = Configs.GetValue("InfluxHttpAddress");
            User = Configs.GetValue("InfluxUser");
            Password = Configs.GetValue("InfluxPassword");
            Version = Configs.GetValue("InfluxDBVersion");
            ShouldConnectInfluxDb();
        }
        public event ExceptionHandle InfluxException;
        private string _AlarmMeasurement = "DeviceParaAlarm";//报警数据表
        private string _AlarmConfigMeasurement = "DeviceParaAlarmConfig";//用户修改报警数据表
        private string _CommandsMeasurement = "DeviceParaCommands";//用户修改报警数据表
   
        private IInfluxDbClient _influx;
        private string _dbName = String.Empty;
        private readonly string _fakeDbPrefix = "SCADADB";
        private readonly string _fakeMeasurementPrefix = "SCADA";
        public string RealDataTablePrefix
        {
            get { return _fakeMeasurementPrefix; }
        }
        string Uri = "http://" + Configs.GetValue("InfluxHttpAddress");

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
        public bool ShouldConnectInfluxDb()
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

                //如果不存在此数据库，则进行创建，否则不创建
                if (!ExistDatabases(_dbName))
                {
                    return false;

                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10002" + ex.Message));
            }

            return false;

        }

        //清除数据库
        private void PurgeDatabases()
        {
            try
            {
                var databasesResponse = _influx.Database.GetDatabasesAsync();
                var dbs = databasesResponse.Result;

                foreach (var db in dbs)
                {
                    if (db.Name.StartsWith(_fakeDbPrefix))
                        _influx.Database.DropDatabaseAsync(db.Name);
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
        private bool FinalizeDropDatabase()
        {
            var deleteResponse = _influx.Database.DropDatabaseAsync(_dbName).Result;

            return deleteResponse.Success;
        }

        //删除数据库
        private void ShouldDropInfluxDb(string dbName)
        {
            try
            {


                // Act
                var deleteResponse = _influx.Database.DropDatabaseAsync(dbName);
                // Assert

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
        private void ShouldCreateInfluxDb(string dbName)
        {

            try
            {
                // Act
                var createResponse = _influx.Database.CreateDatabaseAsync(dbName);
                // Assert

            }
            catch (Exception ex)
            {

                DisplayException(new Exception("ERR10006" + ex.Message));

            }

        }

        //Web端只负责查询处理，不负责influxDB实时数据的写入
        ////////////////////////////////////////以下是读取相关的方法
        public static string GetInfluxdbValue(object obj)
        {
            if (obj == null)
                return "";
            if (obj.GetType() == typeof(string))
            {
                return obj == null ? "" : obj.ToString();
            }
            else if (obj.GetType() == typeof(DateTime))
            {
                DateTime dt = DateTime.Now;
                if (DateTime.TryParse(obj == null ? "" : obj.ToString(), out dt))
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


        /// <summary>
        /// 读取一个设备的系列数据,并将读取的数据保存的Device
        /// </summary>
        /// <param name="server">采集站</param>
        /// <param name="communication">通道</param>
        /// <param name="device">设备</param>
        /// <returns></returns>
        public Task<IEnumerable<Serie>> DbQuery_Real(string serverid, string communicationid, string deviceid, int device_updatecycle)
        {
            try
            {
                string tablename = serverid + "_" + deviceid;
                string query = "select * from " + _fakeMeasurementPrefix + "_" + tablename + " where   time>='" + DateTime.Now.AddSeconds(-device_updatecycle).ToString("yyyy-MM-dd HH:mm:ss") + "'  ORDER BY time desc ";


                var readerResponse = _influx.Client.QueryAsync(query, _dbName);
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
        public InfluxDBHistoryResult  DbQuery_History(string serverid, string communicationid, string deviceid, DateTime SDate, DateTime EDate, int PageSize, int PageIndex, string orderAction)
        {
            string tablename = serverid + "_" + deviceid;
            //条件限制最大页是10000条，超过此数量，强制归为最大数量
            if (PageSize > 10000)
                PageSize = 10000;
            try
            {
                InfluxDBHistoryResult datas = new InfluxDBHistoryResult();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;
                try
                {
                    string queryCount = "SELECT COUNT(field_device_date) FROM " + _fakeMeasurementPrefix + "_" + tablename + " where   time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                    var readerCountResponse = _influx.Client.QueryAsync(queryCount, _dbName).Result;
                    string query = "select * from " + _fakeMeasurementPrefix + "_" + tablename + " where   time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "'    ORDER BY time " + orderAction + "   LIMIT " + PageSize + " OFFSET " + (PageIndex - 1) * PageSize + "    ";
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

                    var readerResponse = _influx.Client.QueryAsync(query, _dbName).Result;
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
        /// 读取某个设备的历史统计数据
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="SDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex">从1开始</param>
        /// <returns></returns>
        public InfluxDBHistoryResult  DbQuery_HistoryStatics(string serverid, string communicationid, string deviceid, DateTime SDate, DateTime EDate, int PageSize, int PageIndex, string orderAction, string timespan, string returnfields)
        {
            string tablename = serverid + "_" + deviceid;
            //条件限制最大页是10000条，超过此数量，强制归为最大数量
            if (PageSize > 10000)
                PageSize = 10000;
            try
            {
                InfluxDBHistoryResult datas = new InfluxDBHistoryResult();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;
                try
                {
                    string queryCount = "SELECT COUNT(*) FROM " + _fakeMeasurementPrefix + "_" + tablename + " where   time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "'  group by time(" + timespan + ")";
                    var readerCountResponse = _influx.Client.QueryAsync(queryCount, _dbName).Result;
                    string query = "select " + returnfields + " from " + _fakeMeasurementPrefix + "_" + tablename + " where   time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "'    group by time(" + timespan + ")   ORDER BY time " + orderAction + "   LIMIT " + PageSize + " OFFSET " + (PageIndex - 1) * PageSize + "    ";
                    if (readerCountResponse != null && readerCountResponse.Count() > 0)
                    {
                        Serie s = readerCountResponse.Last();
                        if (s != null && s.Values.Count >= 1)
                        {

                            datas.RecordCount = s.Values.Count;



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

                    var readerResponse = _influx.Client.QueryAsync(query, _dbName).Result;
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
        /// 读取某个设备的实时报警数据,实时数据默认是当天的报警
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="SDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex">从1开始</param>
        /// <returns></returns>
        public InfluxDBHistoryResult DbQuery_Alarms(string timespan = "1d", string AlarmType = "", string AlarmLevel = "", int PageSize = 2000, int PageIndex = 1)
        {

            ///查询的数量最大为10000条，influxdb系统限制最大查询数量
            if (PageSize > 10000)
                PageSize = 10000;
            try
            {
                string sql = "SELECT * FROM " + _fakeMeasurementPrefix + "_" + _AlarmMeasurement;

                string where = "  WHERE time > now() - " + timespan;
                if (AlarmType != null && AlarmType != "" && AlarmType != "0")
                {
                    where += " and tag_level='" + AlarmType + "'";
                }
                if (AlarmLevel != null && AlarmLevel != "" && AlarmLevel != "0")
                {
                    where += " and tag_type='" + AlarmLevel + "'";
                }
                sql += where;
                sql += "   ORDER BY time DESC   LIMIT " + PageSize + " OFFSET " + (PageIndex - 1) * PageSize;
                InfluxDBHistoryResult datas = new InfluxDBHistoryResult();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;

                try
                {
                    string queryCount = "SELECT COUNT(field_io_alarm_date) FROM " + _fakeMeasurementPrefix + "_" + _AlarmMeasurement + "    " + where;
                    var readerCountResponse = _influx.Client.QueryAsync(queryCount, _dbName);
                    string query = sql;
                    if (readerCountResponse != null && readerCountResponse.Result.Count() > 0)
                    {
                        Serie s = readerCountResponse.Result.Last();
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

                    var readerResponse = _influx.Client.QueryAsync(query, _dbName);
                    datas.Seres = readerResponse.Result;
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
        public InfluxDBHistoryResult DbQuery_Alarms(List<string> DeviceIDs, string timespan = "1d", string AlarmType = "", string AlarmLevel = "", int PageSize = 2000, int PageIndex = 1)
        {
            if (AlarmType == "0")
                AlarmType = "";
            if (AlarmLevel == "0")
                AlarmLevel = "";

            ///查询的数量最大为10000条，influxdb系统限制最大查询数量
            if (PageSize > 10000)
                PageSize = 10000;
            try
            {
                string sql = "SELECT * FROM " + _fakeMeasurementPrefix + "_" + _AlarmMeasurement;

                string where = "  WHERE time > now() - " + timespan;
                if (!string.IsNullOrWhiteSpace(AlarmType))
                {
                    where += " and tag_level='" + AlarmType + "'";
                }
                if (!string.IsNullOrWhiteSpace(AlarmLevel))
                {
                    where += " and tag_type='" + AlarmLevel + "'";
                }

                if (DeviceIDs != null && DeviceIDs.Count > 0)
                {
                    string str = "";
                    for (int i = 0; i < DeviceIDs.Count; i++)
                    {
                        str += " tag_did='" + DeviceIDs[i] + "' or";

                    }
                    if (str != "")
                    {
                        str = str.Remove(str.Length - 2, 2);
                        where += " and (" + str + ")";
                    }



                }
                sql += where;
                sql += "   ORDER BY time DESC   LIMIT " + PageSize + " OFFSET " + (PageIndex - 1) * PageSize;
                InfluxDBHistoryResult datas = new InfluxDBHistoryResult();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;

                try
                {
                    string queryCount = "SELECT COUNT(field_io_alarm_date) FROM " + _fakeMeasurementPrefix + "_" + _AlarmMeasurement + "    " + where;
                    var readerCountResponse = _influx.Client.QueryAsync(queryCount, _dbName);
                    string query = sql;
                    if (readerCountResponse != null && readerCountResponse.Result.Count() > 0)
                    {
                        Serie s = readerCountResponse.Result.Last();
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

                    var readerResponse = _influx.Client.QueryAsync(query, _dbName);
                    datas.Seres = readerResponse.Result;
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
        public InfluxDBHistoryResult DbQuery_Alarms(string serverid, string communicationid, string deviceid, DateTime SDate, DateTime EDate, string AlarmType, string AlarmLevel, int PageSize, int PageIndex)
        {
            if (AlarmType == "0")
                AlarmType = "";
            if (AlarmLevel == "0")
                AlarmLevel = "";
            if (PageSize > 10000)
                PageSize = 10000;
            try
            {
                InfluxDBHistoryResult datas = new InfluxDBHistoryResult();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;
                string where = "time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and  tag_sid='" + serverid + "' and tag_cid='" + communicationid + "' and tag_did='" + deviceid + "'";
                if (!string.IsNullOrWhiteSpace(AlarmType))
                {
                    where += " and tag_level='" + AlarmType + "'";
                }
                if (!string.IsNullOrWhiteSpace(AlarmLevel))
                {
                    where += " and tag_type='" + AlarmLevel + "'";
                }
                try
                {
                    string queryCount = "SELECT COUNT(field_io_alarm_date) FROM " + _fakeMeasurementPrefix + "_" + _AlarmMeasurement + " where   " + where;
                    var readerCountResponse = _influx.Client.QueryAsync(queryCount, _dbName).Result;
                    string query = "select * from " + _fakeMeasurementPrefix + "_" + _AlarmMeasurement + " where  " + where + "     ORDER BY time DESC   LIMIT " + PageSize + " OFFSET " + (PageIndex - 1) * PageSize + "    ";
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

                    var readerResponse = _influx.Client.QueryAsync(query, _dbName);
                    datas.Seres = readerResponse.Result;
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
        public async Task<InfluxDBHistoryResult> DbQuery_Commands(string serverid, string communicationid, string deviceid, DateTime SDate, DateTime EDate, int PageSize, int PageIndex)
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
                InfluxDBHistoryResult datas = new InfluxDBHistoryResult();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;
                string where = "time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and  tag_sid='" + serverid + "' and tag_cid='" + communicationid + "' and tag_did='" + deviceid + "'";

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
        /// 读取某个设备报警配置记录
        /// </summary>
        /// <param name="server"></param>
        /// <param name="communication"></param>
        /// <param name="device"></param>
        /// <param name="SDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex">从1开始</param>
        /// <returns></returns>
        public async Task<InfluxDBHistoryResult> DbQuery_AlarmConfigs(string serverid, string communicationid, string deviceid, DateTime SDate, DateTime EDate, int PageSize, int PageIndex)
        {

            if (PageSize > 10000)
                PageSize = 10000;
            try
            {
                InfluxDBHistoryResult datas = new InfluxDBHistoryResult();
                datas.PageSize = PageSize;
                datas.PageIndex = PageIndex;
                string where = "time>='" + SDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and time<='" + EDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and  tag_sid='" + serverid + "' and tag_cid='" + communicationid + "' and tag_did='" + deviceid + "'";

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
        /// 读取多个设备数据并返回
        /// </summary>
        /// <param name="devices"></param>
        /// <returns></returns>
        public IEnumerable<IEnumerable<Serie>> MultiQueryReal(List<InfluxDBQueryPara> devices)
        {

            try
            {
                List<string> querys = new List<string>();
                for (int i = 0; i < devices.Count; i++)
                {
                    string query = "select * from " + _fakeMeasurementPrefix + "_" + devices[i].TableName + " where   time>='" + DateTime.Now.AddSeconds(0 - devices[i].UpdateCycle).ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY time DESC ";
                    querys.Add(query);
                    IEnumerable<Serie> queryData = _influx.Client.QueryAsync(querys, _dbName).Result;
                }

                var writeResponse = _influx.Client.MultiQueryAsync(querys, _dbName, null).Result;
                return writeResponse;
            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10012" + ex.Message));
                return null;

            }
        }

        public bool DbUpdate_AlarmPoints(ScadaAlarmModel alarmModel)
        {
            try
            {


                var points = CreateAlarmPoint(alarmModel.IO_SERVER_ID, alarmModel.IO_COMMUNICATE_ID, alarmModel);
                return _influx.Client.WriteAsync(points, _dbName, null, "ms").Result.Success;

            }
            catch (Exception ex)
            {
                DisplayException(new Exception("ERR10010" + ex.Message));

            }
            return false;

        }
        private Point CreateAlarmPoint(string serverid, string communicationid, ScadaAlarmModel alarm)
        {

            Point point = new Point();
            point.Fields = CreateParaAlarmFields(alarm);
            point.Tags = CreateParaAlarmTags(serverid, communicationid, alarm);
            point.Timestamp = Convert.ToDateTime(alarm.time);
            point.Name = _fakeMeasurementPrefix + "_" + _AlarmMeasurement;

            return point;
        }

        /// <summary>
        /// 创建实时数据表中的Tags
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private Dictionary<string, object> CreateParaAlarmTags(string serverid, string communicationid, ScadaAlarmModel alarm)
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
        private Dictionary<string, object> CreateParaAlarmFields(ScadaAlarmModel alarm)
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
        #region 下置命令类
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
        private Point CreateCommandPoint(string serverid, string communicationid, IO_COMMANDS command, DateTime? time)
        {

            Point point = new Point();
            point.Fields = this.CreateCommandFields(command);
            point.Tags = this.CreateCommandTags(serverid, communicationid, command);
            point.Timestamp = time;
            point.Name = _fakeMeasurementPrefix + "_" + _CommandsMeasurement;

            return point;
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
            dict.Add("field_command_value", (string)command.COMMAND_VALUE.ToString());
            dict.Add("field_label", (string)command.IO_LABEL.ToString());
            dict.Add("field_send_user", (string)command.COMMAND_SEND_USER.ToString());
            dict.Add("field_send_username", (string)command.COMMAND_SEND_USERNAME.ToString());
     
            return dict;
        }
        #endregion
    }
}
