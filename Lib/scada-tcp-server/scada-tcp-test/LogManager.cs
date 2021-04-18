using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;
using scada_tcp_server;

namespace scada_tcp_test
{
    public class LogManager:ScadaLogManager
    {
        private static ILog LOG = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public override void Debug(object msg)
        {
            LOG.Debug(msg);
        }

        public override void DebugFormat(string msg, params object[] args)
        {
            LOG.DebugFormat(msg,args);
        }

        public override void Debug(object msg, Exception exception)
        {
            LOG.Debug(msg,exception);
        }

        public override void Info(object msg)
        {
            LOG.Info(msg);
        }

        public override void InfoFormat(string msg, params object[] args)
        {
            LOG.InfoFormat(msg,args);
        }

        public override void Info(object msg, Exception exception)
        {
            LOG.Info(msg,exception);
        }

        public override void Warn(object msg)
        {
            LOG.Warn(msg);
        }

        public override void Warn(object msg, Exception exception)
        {
            LOG.Warn(msg,exception);
        }

        public override void WarnFormat(string msg, params object[] args)
        {
            LOG.WarnFormat(msg,args);
        }

        public override void Error(object msg)
        {
            LOG.Error(msg);
        }

        public override void Error(object msg, Exception exception)
        {
            LOG.Error(msg,exception);
        }

        public override void ErrorFormat(string msg, params object[] args)
        {
            LOG.ErrorFormat(msg,args);
        }
    }
}
