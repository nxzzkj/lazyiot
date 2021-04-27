using Scada.IOStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scada.Model;

namespace Scada.MakeAlarm
{
    public class IODeviceParaMaker
    {
        //高限和超高限报警
        private void MakeUpAlarm(ref IO_PARAALARM alarm, decimal dvalue, string IO_CONDITION, List<IO_PARA> deviceParas, IOData dataValue, string AlarmLevel, string AlarmType, decimal AlarmTypeValue)
        {
            alarm.IO_ALARM_LEVEL = AlarmType;
            alarm.IO_ALARM_TYPE = AlarmLevel;

            if (dvalue > AlarmTypeValue)
            {


                //是否有前置条件，如果没有前置条件，则报警，否则不报警
                if (IO_CONDITION == "")
                {
                    alarm.IO_ALARM_DISPOSALIDEA = "";
                    alarm.IO_ALARM_DISPOSALUSER = "";
                    alarm.IO_ALARM_VALUE = dataValue.ParaValue;
                    return;


                }
                else
                {
                    alarm.IO_ALARM_DISPOSALIDEA = "";
                    alarm.IO_ALARM_DISPOSALUSER = "";
                    alarm.IO_ALARM_VALUE = dataValue.ParaValue;
                    string[] condition = IO_CONDITION.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (condition.Length <= 0)
                    {
                        return;
                    }
                    else
                    {
                        bool isInvalid = true;
                        #region 前置条件判断

                        for (int i = 0; i < condition.Length; i++)
                        {

                            string[] cond_values = condition[i].Split(new char[3] { '>', '=', '<' }, StringSplitOptions.RemoveEmptyEntries);
                            if (cond_values.Length == 2)
                            {
                                IO_PARA conditonPara = deviceParas.Find(x => x.IO_NAME == cond_values[0]);
                                if (conditonPara != null &&
                                    conditonPara.IORealData != null &&
                                    conditonPara.IORealData.QualityStamp == QualityStamp.GOOD &&
                                    conditonPara.IORealData.ParaValue != "-9999" &&
                                        conditonPara.IORealData.ParaValue != "")

                                {
                                    #region 条件判断


                                    if (condition[i].Contains(">"))
                                    {
                                        decimal pvalue = -9999;
                                        decimal cvalue = -9999;

                                        if (decimal.TryParse(conditonPara.IORealData.ParaValue, out pvalue) && decimal.TryParse(cond_values[1], out cvalue))
                                        {
                                            isInvalid = pvalue > cvalue ? true : false;
                                            if (isInvalid == false)//条件不满足报警要求，则停止判断
                                                break;
                                        }
                                    }
                                    else if (condition[i].Contains("="))
                                    {
                                        decimal pvalue = -9999;
                                        decimal cvalue = -9999;

                                        if (decimal.TryParse(conditonPara.IORealData.ParaValue, out pvalue) && decimal.TryParse(cond_values[1], out cvalue))
                                        {
                                            isInvalid = pvalue == cvalue ? true : false;
                                            if (isInvalid == false)//条件不满足报警要求，则停止判断
                                                break;
                                        }
                                    }
                                    else if (condition[i].Contains("<"))
                                    {
                                        decimal pvalue = -9999;
                                        decimal cvalue = -9999;

                                        if (decimal.TryParse(conditonPara.IORealData.ParaValue, out pvalue) && decimal.TryParse(cond_values[1], out cvalue))
                                        {
                                            isInvalid = pvalue < cvalue ? true : false;
                                            if (isInvalid == false)//条件不满足报警要求，则停止判断
                                                break;

                                        }
                                    }

                                    #endregion

                                }
                            }
                        }

                        #endregion
                        if (!isInvalid)
                        {
                            alarm = null;

                        }

                    }


                }
            }
            else
            {
                alarm = null;
            }
        }
        //低限和超低限报警
        private void MakeDownAlarm(ref IO_PARAALARM alarm, decimal dvalue, string IO_CONDITION, List<IO_PARA> deviceParas, IOData dataValue, string AlarmLevel, string AlarmType, decimal AlarmTypeValue)
        {
            alarm.IO_ALARM_LEVEL = AlarmType;
            alarm.IO_ALARM_TYPE = AlarmLevel;

            if (dvalue < AlarmTypeValue)
            {


                //是否有前置条件，如果没有前置条件，则报警，否则不报警
                if (IO_CONDITION == "")
                {
                    alarm.IO_ALARM_DISPOSALIDEA = "";
                    alarm.IO_ALARM_DISPOSALUSER = "";
                    alarm.IO_ALARM_VALUE = dataValue.ParaValue;
                    return;


                }
                else
                {
                    alarm.IO_ALARM_DISPOSALIDEA = "";
                    alarm.IO_ALARM_DISPOSALUSER = "";
                    alarm.IO_ALARM_VALUE = dataValue.ParaValue;
                    string[] condition = IO_CONDITION.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (condition.Length <= 0)
                    {
                        return;
                    }
                    else
                    {
                        bool isInvalid = true;
                        #region 前置条件判断

                        for (int i = 0; i < condition.Length; i++)
                        {

                            string[] cond_values = condition[i].Split(new char[3] { '>', '=', '<' }, StringSplitOptions.RemoveEmptyEntries);
                            if (cond_values.Length == 2)
                            {
                                IO_PARA conditonPara = deviceParas.Find(x => x.IO_NAME == cond_values[0]);
                                if (conditonPara != null &&
                                    conditonPara.IORealData != null &&
                                    conditonPara.IORealData.QualityStamp == QualityStamp.GOOD &&
                                    conditonPara.IORealData.ParaValue != "-9999" &&
                                        conditonPara.IORealData.ParaValue != "")

                                {
                                    #region 条件判断


                                    if (condition[i].Contains(">"))
                                    {
                                        decimal pvalue = -9999;
                                        decimal cvalue = -9999;

                                        if (decimal.TryParse(conditonPara.IORealData.ParaValue, out pvalue) && decimal.TryParse(cond_values[1], out cvalue))
                                        {
                                            isInvalid = pvalue > cvalue ? true : false;
                                            if (isInvalid == false)//条件不满足报警要求，则停止判断
                                                break;
                                        }
                                    }
                                    else if (condition[i].Contains("="))
                                    {
                                        decimal pvalue = -9999;
                                        decimal cvalue = -9999;

                                        if (decimal.TryParse(conditonPara.IORealData.ParaValue, out pvalue) && decimal.TryParse(cond_values[1], out cvalue))
                                        {
                                            isInvalid = pvalue == cvalue ? true : false;
                                            if (isInvalid == false)//条件不满足报警要求，则停止判断
                                                break;
                                        }
                                    }
                                    else if (condition[i].Contains("<"))
                                    {
                                        decimal pvalue = -9999;
                                        decimal cvalue = -9999;

                                        if (decimal.TryParse(conditonPara.IORealData.ParaValue, out pvalue) && decimal.TryParse(cond_values[1], out cvalue))
                                        {
                                            isInvalid = pvalue < cvalue ? true : false;
                                            if (isInvalid == false)//条件不满足报警要求，则停止判断
                                                break;

                                        }
                                    }

                                    #endregion

                                }
                            }
                        }

                        #endregion
                        if (!isInvalid)
                        {
                            alarm = null;

                        }

                    }


                }
            }
            else
            {
                alarm = null;
            }
        }

        /// <summary>
        /// 生成报警,这个传入值必须是量程转换后的（如果开启量程转换）
        /// </summary>
        /// <param name="para"></param>
        /// <param name="dataValue"></param>
        /// <returns></returns>
        public IO_PARAALARM MakeAlarm(List<IO_PARA> deviceParas, IO_PARA para, IOData dataValue,string devicename)
        {

            //
            IO_PARAALARM maxmaxAlarm = null;
            IO_PARAALARM maxAlarm = null;
            IO_PARAALARM minAlarm = null;
            IO_PARAALARM minminAlarm = null;
            if (para == null)
                return null;
            if (para.IO_POINTTYPE != "模拟量")
                return null;
            if (dataValue == null)
                return null;
            if (dataValue.QualityStamp != QualityStamp.GOOD)
            {
                return null;
            }
            if (dataValue.ParaValue == "-9999")
            {
                return null;
            }
            if (dataValue.ParaValue == "")
            {
                return null;
            }
            decimal dvalue = -9999;
            if (!decimal.TryParse(dataValue.ParaValue, out dvalue))
                return null;
            if (para.AlarmConfig == null)
                return null;

            if (para.IO_ENABLEALARM == 1)
            {

                //高级报警
                if (para.AlarmConfig.IO_ENABLE_MAX.Value == 1)
                {
                    maxAlarm = new IO_PARAALARM();

                    maxAlarm.DEVICE_NAME = devicename;
                    maxAlarm.IO_ALARM_ID = "";
                    maxAlarm.IO_ALARM_DATE = dataValue == null ? "" : dataValue.Date.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    maxAlarm.IO_ID = para.IO_ID;
                    maxAlarm.IO_LABEL = para.IO_LABEL;
                    maxAlarm.IO_NAME = para.IO_NAME;
                    maxAlarm.IO_SERVER_ID = para.IO_SERVER_ID;
                    maxAlarm.IO_DEVICE_ID = para.IO_DEVICE_ID;
                    maxAlarm.IO_COMM_ID = para.IO_COMM_ID;
                    maxAlarm.IO_ALARM_LEVEL = para.AlarmConfig.IO_MAX_TYPE;
                    maxAlarm.IO_ALARM_TYPE = "高限报警";
                    MakeUpAlarm(ref maxAlarm,
                           dvalue,
                           para.AlarmConfig.IO_CONDITION,
                           deviceParas, dataValue,
                           maxAlarm.IO_ALARM_LEVEL,
                           "高限报警",
                           para.AlarmConfig.IO_MAX_VALUE.Value);
                }
                //超高限报警
                if (para.AlarmConfig.IO_ENABLE_MAXMAX.Value == 1)
                {
                    maxmaxAlarm = new IO_PARAALARM();

                    maxmaxAlarm.DEVICE_NAME = devicename;
                    maxmaxAlarm.IO_ALARM_ID = "";
                    maxmaxAlarm.IO_ALARM_DATE = dataValue == null ? "" : dataValue.Date.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    maxmaxAlarm.IO_ID = para.IO_ID;
                    maxmaxAlarm.IO_LABEL = para.IO_LABEL;
                    maxmaxAlarm.IO_NAME = para.IO_NAME;
                    maxmaxAlarm.IO_SERVER_ID = para.IO_SERVER_ID;
                    maxmaxAlarm.IO_DEVICE_ID = para.IO_DEVICE_ID;
                    maxmaxAlarm.IO_COMM_ID = para.IO_COMM_ID;
                    maxmaxAlarm.IO_ALARM_LEVEL = para.AlarmConfig.IO_MAXMAX_TYPE;
                    maxmaxAlarm.IO_ALARM_TYPE = "超高限报警";
                    MakeUpAlarm(ref maxmaxAlarm,
                        dvalue,
                        para.AlarmConfig.IO_CONDITION,
                        deviceParas, dataValue,
                        maxmaxAlarm.IO_ALARM_LEVEL,
                        "超高限报警",
                        para.AlarmConfig.IO_MAXMAX_VALUE.Value);
                }
                //低限报警
                if (para.AlarmConfig.IO_ENABLE_MIN.Value == 1)
                {
                    minAlarm = new IO_PARAALARM();
                    minAlarm.DEVICE_NAME = devicename;
                    minAlarm.IO_ALARM_ID = "";
                    minAlarm.IO_ALARM_DATE = dataValue == null ? "" : dataValue.Date.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    minAlarm.IO_ID = para.IO_ID;
                    minAlarm.IO_LABEL = para.IO_LABEL;
                    minAlarm.IO_NAME = para.IO_NAME;
                    minAlarm.IO_SERVER_ID = para.IO_SERVER_ID;
                    minAlarm.IO_DEVICE_ID = para.IO_DEVICE_ID;
                    minAlarm.IO_COMM_ID = para.IO_COMM_ID;
                    minAlarm.IO_ALARM_LEVEL = para.AlarmConfig.IO_MIN_TYPE;
                    minAlarm.IO_ALARM_TYPE = "低限报警";
                    MakeDownAlarm(ref minAlarm,
                        dvalue,
                        para.AlarmConfig.IO_CONDITION,
                        deviceParas, dataValue,
                        minAlarm.IO_ALARM_LEVEL,
                        "低限报警",
                        para.AlarmConfig.IO_MIN_VALUE.Value);
                }
                //超低限报警
                if (para.AlarmConfig.IO_ENABLE_MINMIN.Value == 1)
                {
                    minminAlarm = new IO_PARAALARM();
                    minminAlarm.DEVICE_NAME = devicename;
                    minminAlarm.IO_ALARM_ID = "";
                    minminAlarm.IO_ALARM_DATE = dataValue == null ? "" : dataValue.Date.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    minminAlarm.IO_ID = para.IO_ID;
                    minminAlarm.IO_LABEL = para.IO_LABEL;
                    minminAlarm.IO_NAME = para.IO_NAME;
                    minminAlarm.IO_SERVER_ID = para.IO_SERVER_ID;
                    minminAlarm.IO_DEVICE_ID = para.IO_DEVICE_ID;
                    minminAlarm.IO_COMM_ID = para.IO_COMM_ID;
                    minminAlarm.IO_ALARM_LEVEL = para.AlarmConfig.IO_MINMIN_TYPE;
                    minminAlarm.IO_ALARM_TYPE = "超低限报警";
                    MakeDownAlarm(ref minminAlarm,
                        dvalue,
                        para.AlarmConfig.IO_CONDITION,
                        deviceParas, dataValue,
                        minminAlarm.IO_ALARM_LEVEL,
                       "超低限报警",
                        para.AlarmConfig.IO_MINMIN_VALUE.Value);
                }
            }
            if (maxmaxAlarm != null)
                return maxmaxAlarm;
            if (maxAlarm != null)
                return maxAlarm;
            if (minminAlarm != null)
                return minminAlarm;
            if (minAlarm != null)
                return minAlarm;
            return null;
        }
    }
}
