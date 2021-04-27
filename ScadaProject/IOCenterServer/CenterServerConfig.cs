using Scada.AsyncNetTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Scada.DBUtility;

namespace ScadaCenterServer
{
    public enum ConfigItemType
    {
        字符串,
        多项列表,
        布尔值,
        时间单位,
        存储单位,
        路径,
        数值,
        对象
    }
    public class ConfigItem
    {
        public ConfigItemType ItemType = ConfigItemType.字符串;
        public string Key = "";
        public string Value = "";
        public string DefaultValue = "";

        public bool ReadOnly = false;
        public string Description = "";
        public List<string> SelectItems = new List<string>();
    }
    public class InfluxItem
    {
        public string Name = "";
        public string Description = "";
        public bool Enable = false;
        public List<ConfigItem> Items = new List<ConfigItem>();

    }
    public class influxdConfig
    {
        public List<InfluxItem> ConfigItems = new List<InfluxItem>();
        public InfluxItem HeadItem = new InfluxItem();
        public InfluxItem MetaItem = new InfluxItem();
        public InfluxItem DataItem = new InfluxItem();
        public InfluxItem CoordinatorItem = new InfluxItem();
        public InfluxItem RetentionItem = new InfluxItem();
        public InfluxItem Shard_PrecreationItem = new InfluxItem();
        public InfluxItem AdminItem = new InfluxItem();
        public InfluxItem MonitorItem = new InfluxItem();
        public InfluxItem HttpItem = new InfluxItem();
        public InfluxItem LoggingItem = new InfluxItem();
        public InfluxItem SubscriberItem = new InfluxItem();
     
        public InfluxItem Continuous_queriesItem = new InfluxItem();
     
        ConfigItem Http_Bind_Address = null;
        public string HttpAddress
        {
            get
            {
                if (Http_Bind_Address != null&& Http_Bind_Address.Value!="")
                {
                    return "http://" + Http_Bind_Address.Value;
                }
                return "http://"+ LocalIp.GetLocalIp() + ":8086";
            }
        }
        public influxdConfig()
        {

            ConfigItem Reporting_Disabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "reporting-disabled", Value = "false", DefaultValue = "false", Description = "该选项用于上报influxdb的使用信息给InfluxData公司，默认值为false" };
            ConfigItem Bind_Address = new ConfigItem() { ItemType = ConfigItemType.字符串, Key = "bind-address", Value = ""+ LocalIp.GetLocalIp() + ":8088", DefaultValue = ""+ LocalIp.GetLocalIp() + ":8088", Description = "备份恢复时使用，默认值为8088" };
            HeadItem.Items.Add(Reporting_Disabled);
            HeadItem.Items.Add(Bind_Address);
            HeadItem.Name = "HEAD";
            HeadItem.Description = @"如果未指定配置选项。注释行是配置字段和使用的默认值。取消对行的注释并更改值将更改进程重新启动时在运行时使用的值。";
            //[meta] 控制存储有关InfluxDB群集的元数据的Raft共识组的参数。
            ConfigItem Meta_Dir = new ConfigItem() { ItemType = ConfigItemType.路径,Key = "dir", Value = Application.StartupPath+"/influxdb/meta", DefaultValue = Application.StartupPath + "/influxdb/meta", Description = "Meta数据存放目录，默认值：/var/lib/influxdb/meta" };
            ConfigItem Meta_Retention_Autocreate = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "retention-autocreate", DefaultValue = "true", Value = "true", Description = "用于控制默认存储策略，数据库创建时，会自动生成autogen的存储策略，默认值：true" };
            ConfigItem Meta_Logging_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "logging-enabled", Value = "true", DefaultValue = "true", Description = "是否开启meta日志，默认值：true" };
            MetaItem.Name = "meta";
            MetaItem.Description = "控制存储有关InfluxDB群集的元数据的Raft共识组的参数";
            MetaItem.Items.Add(Meta_Dir);
            MetaItem.Items.Add(Meta_Retention_Autocreate);
            MetaItem.Items.Add(Meta_Logging_Enabled);

            //[data] 控制InfluxDB的实际分片数据的生存位置以及它从WAL中刷新的方式。 “dir”可能需要更改为适合您系统的位置，但WAL设置是高级配置。 默认值应适用于大多数系统。
            //最终数据（TSM文件）存储目录，默认值：/var/lib/influxdb/data
            ConfigItem Data_Dir = new ConfigItem() { ItemType = ConfigItemType.路径, Key = "dir", Value = Application.StartupPath + "/influxdb/data", DefaultValue = Application.StartupPath + "/influxdb/data", Description = "最终数据（TSM文件）存储目录，默认值：/var/lib/influxdb/data" };
            ConfigItem Data_Wal_Dir = new ConfigItem() { ItemType = ConfigItemType.路径, Key = "wal-dir", Value = Application.StartupPath + "/influxdb/wal", DefaultValue = Application.StartupPath + "/influxdb/wal", Description = "预写日志存储目录，默认值：/var/lib/influxdb/wal" };
            ConfigItem Data_Wal_Fsync_Delay = new ConfigItem() { ItemType = ConfigItemType.时间单位, Key = "wal-fsync-delay", Value = "0s", DefaultValue = "0s", Description = "在同步写入之前等待的总时间，默认0s" };
            ConfigItem Data_Query_Log_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "query-log-enabled", Value = "true", DefaultValue = "true", Description = "是否开启tsm引擎查询日志，默认值： true" };
            ConfigItem Data_Cache_Max_Memory_size = new ConfigItem() { ItemType = ConfigItemType.存储单位, Key = "cache-max-memory-size", Value = "1g", DefaultValue = "1g", Description = "用于限定shard最大值，大于该值时会拒绝写入，默认值，默认值：1G" };
            ConfigItem Data_Cache_Snapshot_Memory_size = new ConfigItem() { ItemType = ConfigItemType.存储单位, Key = "cache-snapshot-memory-size", Value = "25m", DefaultValue = "25m", Description = "用于设置快照大小，大于该值时数据会刷新到tsm文件，默认值：25m" };
            ConfigItem Data_Cache_Snapshot_Write_Cold_Duration = new ConfigItem() { ItemType = ConfigItemType.存储单位, Key = "cache-snapshot-write-cold-duration", Value = "10m", DefaultValue = "10m", Description = "tsm1引擎 snapshot写盘延迟，默认值：10m" };
            ConfigItem Data_Compact_Full_Write_Cold_Duration = new ConfigItem() { ItemType = ConfigItemType.时间单位, Key = "compact-full-write-cold-duration", Value = "4h", DefaultValue = "4h", Description = "tsm文件在压缩前可以存储的最大时间，默认值：4h" };
            ConfigItem Data_Max_Concurrent_Compactions = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "max-concurrent-compactions", Value = "0", DefaultValue = "0", Description = "压缩并发的最大数量，默认设置为0，默认值：0" };
            ConfigItem Data_Max_Series_Per_Database = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "max-series-per-database", Value = "1000000", DefaultValue = "1000000", Description = "限制数据库的级数，该值为0时取消限制，默认值：1000000" };
            ConfigItem Data_Max_Values_Per_Tag = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "max-values-per-tag", Value = "100000", DefaultValue = "100000", Description = "一个tag最大的value数，0取消限制，默认值：100000" };
            ConfigItem Data_Trace_Logging_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "trace-logging-enabled", Value = "false", DefaultValue = "false", Description = "是否开启trace日志，默认值： false" };
            ConfigItem Data_Max_Index_Log_File_Size = new ConfigItem() { ItemType = ConfigItemType.存储单位, Key = "max-index-log-file-size", Value = "1m", DefaultValue = "1m", Description = "限制索引日志文件大小，默认值： 1m" };
            ConfigItem Data_Tsm_Use_Madv_Willneed = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "tsm-use-madv-willneed", Value = "false", DefaultValue = "false", Description = "如果为true，mmap的建议值MADV_WILLNEED会被提供给内核，默认值： false" };
            DataItem.Description = "控制InfluxDB的实际分片数据的生存位置以及它从WAL中刷新的方式。 “dir”可能需要更改为适合您系统的位置，但WAL设置是高级配置。 默认值应适用于大多数系统";
            DataItem.Name = "data";
            DataItem.Items.Add(Data_Dir);
            DataItem.Items.Add(Data_Wal_Dir);
            DataItem.Items.Add(Data_Wal_Fsync_Delay);
            DataItem.Items.Add(Data_Query_Log_Enabled);
            DataItem.Items.Add(Data_Cache_Max_Memory_size);
            DataItem.Items.Add(Data_Cache_Snapshot_Memory_size);
            DataItem.Items.Add(Data_Cache_Snapshot_Write_Cold_Duration);
            DataItem.Items.Add(Data_Compact_Full_Write_Cold_Duration);
            DataItem.Items.Add(Data_Max_Concurrent_Compactions);
            DataItem.Items.Add(Data_Max_Series_Per_Database);
            DataItem.Items.Add(Data_Max_Values_Per_Tag);
            DataItem.Items.Add(Data_Trace_Logging_Enabled);
            DataItem.Items.Add(Data_Max_Index_Log_File_Size);
            DataItem.Items.Add(Data_Tsm_Use_Madv_Willneed);
            //[coordinator]  控制群集服务配置
            ConfigItem Coordinator_Write_Timeout = new ConfigItem() { ItemType = ConfigItemType.时间单位, Key = "write-timeout", Value = "10s", DefaultValue = "10s", Description = "写操作超时时间，默认值： 10s" };
            ConfigItem Coordinator_Query_Timeout = new ConfigItem() { ItemType = ConfigItemType.时间单位, Key = "query-timeout", Value = "0s", DefaultValue = "0s", Description = "查询操作超时时间，0无限制，默认值：0s" };
            ConfigItem Coordinator_Log_Queries_After = new ConfigItem() { ItemType = ConfigItemType.时间单位, Key = "log-queries-after", Value = "0s", DefaultValue = "0s", Description = "慢查询超时时间，0无限制，默认值：0s" };
            ConfigItem Coordinator_Max_Select_Point = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "max-select-point", Value = "0", DefaultValue = "0", Description = "SELECT语句可以处理的最大点数（points），0无限制，默认值：0" };
            ConfigItem Coordinator_Max_Select_Series = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "max-select-series", Value = "0", DefaultValue = "0", Description = "SELECT语句可以处理的最大级数（series），0无限制，默认值：0" };
            ConfigItem Coordinator_Max_Select_Buckets = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "max-select-buckets", Value = "0", DefaultValue = "0", Description = "SELECT语句可以处理的最大'GROUP BY time()'的时间周期，0无限制，默认值：0" };
            CoordinatorItem.Description = "控制群集服务配置";
            CoordinatorItem.Name = "coordinator";
            CoordinatorItem.Items.Add(Coordinator_Write_Timeout);
            CoordinatorItem.Items.Add(Coordinator_Query_Timeout);
            CoordinatorItem.Items.Add(Coordinator_Log_Queries_After);
            CoordinatorItem.Items.Add(Coordinator_Max_Select_Point);
            CoordinatorItem.Items.Add(Coordinator_Max_Select_Series);
            CoordinatorItem.Items.Add(Coordinator_Max_Select_Buckets);
            //[retention]  旧数据的保留策略
            ConfigItem Retention_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "enabled", Value = "true", DefaultValue = "true", Description = " 是否启用该模块，默认值 ： true" };
            ConfigItem Retention_Check_Interval = new ConfigItem() { ItemType = ConfigItemType.时间单位, Key = "check-interval", Value = "30m", DefaultValue = "30m", Description = " 检查时间间隔，默认值 ：30m" };
            RetentionItem.Description = "旧数据的保留策略";
            RetentionItem.Name = "retention";
            RetentionItem.Items.Add(Retention_Enabled);
            RetentionItem.Items.Add(Retention_Check_Interval);
            //[shard-precreation]  分区预创建。
            ConfigItem Shard_Retention_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "enabled", Value = "true", DefaultValue = "true", Description = " 是否启用该模块，默认值 ： true" };
            ConfigItem Shard_Check_Interval = new ConfigItem() { ItemType = ConfigItemType.时间单位, Key = "check-interval", Value = "10m", DefaultValue = "10m", Description = " 检查时间间隔，默认值 ：10m" };
            ConfigItem Shard_Advance_Period = new ConfigItem() { ItemType = ConfigItemType.时间单位, Key = "advance-period", Value = "30m", DefaultValue = "30m", Description = " 预创建分区的最大提前时间，默认值 ：30m" };
            Shard_PrecreationItem.Description = "分区预创建";
            Shard_PrecreationItem.Name = "shard-precreation";
            Shard_PrecreationItem.Items.Add(Shard_Retention_Enabled);
            Shard_PrecreationItem.Items.Add(Shard_Check_Interval);
            Shard_PrecreationItem.Items.Add(Shard_Advance_Period);
            //[admin]：influxdb提供的简单web管理页面。
            ConfigItem Admin_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "enabled", Value = "false", DefaultValue = "false", Description = "是否启用该模块，默认值 ：true" };
            ConfigItem Admin_Bind_Address = new ConfigItem() { ItemType = ConfigItemType.字符串, Key = "bind-address", Value = LocalIp.GetLocalIp()+":8083", DefaultValue = LocalIp.GetLocalIp()+":8083", Description = "绑定地址，默认值 ：8083" };
            ConfigItem Admin_Https_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "https-enabled", Value = "false", DefaultValue = "false", Description = "是否开启https ，默认值 ：false" };
            ConfigItem Admin_Https_Certificate = new ConfigItem() { ItemType = ConfigItemType.路径, Key = "https-certificate", Value = Application.StartupPath + "/etc/ssl/influxdb.pem", DefaultValue = Application.StartupPath + "/etc/ssl/influxdb.pem", Description = "https证书路径，默认值：/ etc / ssl / influxdb.pem" };
            AdminItem.Description = "influxdb提供的简单web管理页面";
            AdminItem.Name = "admin";
            AdminItem.Items.Add(Admin_Enabled);
            AdminItem.Items.Add(Admin_Bind_Address);
            AdminItem.Items.Add(Admin_Https_Enabled);
            AdminItem.Items.Add(Admin_Https_Certificate);
            //[monitor] 这一部分控制InfluxDB自有的监控系统。 默认情况下，InfluxDB把这些数据写入_internal 数据库，如果这个库不存在则自动创建。 _internal 库默认的retention策略是7天，如果你想使用一个自己的retention策略，需要自己创建。
            ConfigItem Monitor_Store_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "store-enabled", Value = "true", DefaultValue = "true", Description = "是否启用该模块，默认值 ：true" };
            ConfigItem Monitor_Store_Database = new ConfigItem() { ItemType = ConfigItemType.字符串, Key = "store-database", Value = "_internal", DefaultValue = "_internal", Description = "默认数据库：_internal" };
            ConfigItem Monitor_Store_Interval = new ConfigItem() { ItemType = ConfigItemType.时间单位, Key = "store-interval", Value = "10s", DefaultValue = "10s", Description = "统计间隔，默认值：“10s”" };
            MonitorItem.Description = "这一部分控制InfluxDB自有的监控系统。 默认情况下，InfluxDB把这些数据写入_internal 数据库，如果这个库不存在则自动创建。 _internal 库默认的retention策略是7天，如果你想使用一个自己的retention策略，需要自己创建";
            MonitorItem.Name = "monitor";
            MonitorItem.Items.Add(Monitor_Store_Enabled);
            MonitorItem.Items.Add(Monitor_Store_Database);
            MonitorItem.Items.Add(Monitor_Store_Interval);
            //[http]：influxdb的http接口配置。

            ConfigItem Http_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "enabled", Value = "true", DefaultValue = "true", Description = "是否启用该模块，默认值 ：true" };
            ConfigItem Http_Flux_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "flux-enabled", Value = "false", DefaultValue = "false", Description = "是否启用流查询端点，默认值 ：false" };
             Http_Bind_Address = new ConfigItem() { ItemType = ConfigItemType.字符串, Key = "bind-address", Value = LocalIp.GetLocalIp()+":8086", DefaultValue = LocalIp.GetLocalIp()+":8086", Description = "绑定地址，默认值:8086" };
            ConfigItem Http_Auth_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "auth-enabled", Value = "false", DefaultValue = "false", Description = "是否开启认证，默认值：false" };
            ConfigItem Http_Realm = new ConfigItem() { Key = "realm", Value = "InfluxDB", DefaultValue = "InfluxDB", Description = "发出基本身份验证质询时发送回的默认域，默认值：InfluxDB" };
            ConfigItem Http_Log_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "log-enabled", Value = "true", DefaultValue = "true", Description = "是否开启http请求日志，默认值：true" };
            ConfigItem Http_Suppress_Write_Log = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "suppress-write-log", DefaultValue = "false", Value = "false", Description = "在启用日志时是否应禁止HTTP写入请求日志，默认值：false" };
            ConfigItem Http_Access_Log_Path = new ConfigItem() { Key = "access-log-path", Value = "", DefaultValue = "", Description = "启用HTTP请求日志记录时，此选项指定应写入日志条目的路径。如果未指定，则默认为写入stderr，它将HTTP日志与内部InfluxDB日志记录混合。如果涌入无法访问指定路径，它将记录错误并回退到将请求日志写入stderr。" };
            ConfigItem Http_Writer_Tracing = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "write-tracing", Value = "false", DefaultValue = "false", Description = "是否开启写操作日志，如果置成true，每一次写操作都会打日志，默认值：false" };
            ConfigItem Http_Pprof_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "pprof-enabled", Value = "true", DefaultValue = "true", Description = "是否开启pprof，此端点用于故障排除和监视，默认值：true" };
            ConfigItem Http_Debug_Pprof_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "debug-pprof-enabled", Value = "false", DefaultValue = "false", Description = "在启动时立即启用绑定到localhost：6060的pprof端点。这只需要调试启动问题。默认值：false" };
            ConfigItem Http_Https_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "https-enabled", Value = "false", DefaultValue = "false", Description = "是否开启https，默认值：false" };
            ConfigItem Http_Https_Certificate = new ConfigItem() { ItemType = ConfigItemType.路径, Key = "https-certificate", Value = Application.StartupPath + "/etc/ssl/influxdb.pem", DefaultValue = Application.StartupPath + "/etc/ssl/influxdb.pem", Description = "设置https证书路径，默认值：/ etc / ssl / influxdb.pem" };
            ConfigItem Http_Max_Row_Limit = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "max-row-limit", Value = "10000", DefaultValue = "10000", Description = "配置查询返回最大行数，默认值：10000" };
            ConfigItem Http_Max_Connection_Limit = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "max-connection-limit", Value = "0", DefaultValue = "0", Description = "配置最大连接数，超出此限制的新连接将被删除，0无限制，默认值：0" };
            ConfigItem Http_Unix_Socket_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "unix-socket-enabled", Value = "false", DefaultValue = "false", Description = "通过unix域套接字启用http服务，默认值：false" };
            ConfigItem Http_Bind_Socket = new ConfigItem() { ItemType = ConfigItemType.路径, Key = "bind-socket", Value = Application.StartupPath + "/var/run/influxdb.sock", DefaultValue = Application.StartupPath + "/var/run/influxdb.sock", Description = "unix-socket路径，默认值： / var / run / influxdb.sock" };
            ConfigItem Http_Max_Body_Size = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "max-body-size", Value = "25000000", DefaultValue = "25000000", Description = "客户端请求正文的最大大小（以字节为单位）， 将此值设置为0将禁用该限制。默认值：25000000。" };
            ConfigItem Http_Concurrent_Write_Limit = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "max-concurrent-write-limit", Value = "0", DefaultValue = "0", Description = "并发处理的最大写入次数，将此设置为0将禁用该限制。默认值：0。" };
            ConfigItem Http_Enqueued_Write_Limit = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "max-enqueued-write-limit", Value = "0", DefaultValue = "0", Description = "写入等待队列中写入的最长持续时间。将此设置为0或将max-concurrent-write-limit设置为0将禁用该限制。默认值：0" };
            HttpItem.Description = "influxdb的http接口配置";
            HttpItem.Name = "http";
            HttpItem.Items.Add(Http_Enabled);
            HttpItem.Items.Add(Http_Flux_Enabled);
            HttpItem.Items.Add(Http_Bind_Address);
            HttpItem.Items.Add(Http_Auth_Enabled);
            HttpItem.Items.Add(Http_Realm);
            HttpItem.Items.Add(Http_Log_Enabled);
            HttpItem.Items.Add(Http_Suppress_Write_Log);
            HttpItem.Items.Add(Http_Access_Log_Path);
            HttpItem.Items.Add(Http_Writer_Tracing);
            HttpItem.Items.Add(Http_Pprof_Enabled);
            HttpItem.Items.Add(Http_Debug_Pprof_Enabled);
            HttpItem.Items.Add(Http_Https_Enabled);
            HttpItem.Items.Add(Http_Https_Certificate);
            HttpItem.Items.Add(Http_Max_Row_Limit);
            HttpItem.Items.Add(Http_Max_Connection_Limit);
            HttpItem.Items.Add(Http_Unix_Socket_Enabled);
            HttpItem.Items.Add(Http_Bind_Socket);
            HttpItem.Items.Add(Http_Max_Body_Size);
            HttpItem.Items.Add(Http_Concurrent_Write_Limit);
            HttpItem.Items.Add(Http_Enqueued_Write_Limit);


            //[logging]：控制记录器如何将日志发送到输出。
            ConfigItem Logging_Format = new ConfigItem() { ItemType = ConfigItemType.多项列表, SelectItems = new List<string>() { "auto", "logfmt", "json" }, Key = "format", Value = "auto", DefaultValue = "auto", Description = "确定用于日志的日志编码器。 可用选项包括auto，logfmt和json 。如果输出终端是TTY，则auto将使用更加用户友好的输出格式，但格式不易于机器读取。 当输出是非TTY时，auto将使用logfmt。默认值：“auto”" };
            ConfigItem Logging_Level = new ConfigItem() { ItemType = ConfigItemType.字符串, Key = "level", Value = "info", DefaultValue = "info", Description = "确定将发出的日志级别。 可用的级别包括错误，警告，信息和调试。 将发出等于或高于指定级别的日志。默认值：“info”" };
            ConfigItem Logging_Suppress_Logo = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "suppress-logo", Value = "true", DefaultValue = "true", Description = "禁止在程序启动时打印的徽标输出。 如果STDOUT不是TTY，则始终禁止使用徽标。默认值：false" };
            LoggingItem.Description = "控制记录器如何将日志发送到输出";
            LoggingItem.Name = "logging";
            LoggingItem.Items.Add(Logging_Format);
            LoggingItem.Items.Add(Logging_Level);
            LoggingItem.Items.Add(Logging_Suppress_Logo);
            // [subscriber]：控制Kapacitor接受数据的配置。
            ConfigItem Subscriber_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "enabled", Value = "true", DefaultValue = "true", Description = "是否启用该模块，默认值 ：true" };
            ConfigItem Subscriber_Http_Timeout = new ConfigItem() { ItemType = ConfigItemType.时间单位, Key = "http-timeout", Value = "30s", DefaultValue = "30s", Description = "http超时时间，默认值：“30s”" };
            ConfigItem Subscriber_Insecure_Skip_Verify = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "insecure-skip-verify", Value = "false", DefaultValue = "false", Description = "是否允许不安全的证书，当测试自己签发的证书时比较有用。默认值： false" };
            ConfigItem Subscriber_Ca_Certs = new ConfigItem() { Key = "ca-certs", Value = "", DefaultValue = "", Description = "是否允许不安全的证书，当测试自己签发的证书时比较有用。默认值： false" };
            ConfigItem Subscriber_Write_Concurrency = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "write-concurrency", Value = "40", DefaultValue = "40", Description = "设置并发数目，默认值：40" };
            ConfigItem Subscriber_Write_Buffer_Size = new ConfigItem() { ItemType = ConfigItemType.数值, Key = "write-buffer-size", Value = "1000", DefaultValue = "1000", Description = "设置buffer大小，默认值：1000" };
            SubscriberItem.Description = "控制Kapacitor接受数据的配置";
            SubscriberItem.Name = "subscriber";
            SubscriberItem.Items.Add(Subscriber_Enabled);
            SubscriberItem.Items.Add(Subscriber_Http_Timeout);
            SubscriberItem.Items.Add(Subscriber_Insecure_Skip_Verify);
            SubscriberItem.Items.Add(Subscriber_Ca_Certs);
            SubscriberItem.Items.Add(Subscriber_Write_Concurrency);
            SubscriberItem.Items.Add(Subscriber_Write_Buffer_Size);

          
            
 

            //[continuous_queries]：CQs配置。


            ConfigItem Cqs_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "enabled", Value = "true", DefaultValue = "true", Description = "是否开启CQs，默认值：true" };
            ConfigItem Cqs_Log_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "log-enabled", Value = "true", DefaultValue = "true", Description = "是否开启日志，默认值：true" };
            ConfigItem Cqs_Uery_Stats_Enabled = new ConfigItem() { ItemType = ConfigItemType.布尔值, Key = "uery-stats-enabled", Value = "false", DefaultValue = "false", Description = "控制是否将查询记录到自我监视数据存储。默认值：false" };
            ConfigItem Cqs_Run_Interval = new ConfigItem() { ItemType = ConfigItemType.时间单位, Key = "run-interval", Value = "1s", DefaultValue = "1s", Description = "检查连续查询是否需要运行的时间间隔，默认值：“1s”" };
            Continuous_queriesItem.Description = "CQs配置";
            Continuous_queriesItem.Name = "continuous_queries";
            Continuous_queriesItem.Items.Add(Cqs_Enabled);
            Continuous_queriesItem.Items.Add(Cqs_Log_Enabled);
            Continuous_queriesItem.Items.Add(Cqs_Uery_Stats_Enabled);
            Continuous_queriesItem.Items.Add(Cqs_Run_Interval);

            
            ConfigItems.Clear();
            ConfigItems.Add(HeadItem);
            ConfigItems.Add(MetaItem);
            ConfigItems.Add(DataItem);
            ConfigItems.Add(CoordinatorItem);
            ConfigItems.Add(RetentionItem);
            ConfigItems.Add(Shard_PrecreationItem);
            ConfigItems.Add(MonitorItem);
            ConfigItems.Add(HttpItem);
            ConfigItems.Add(LoggingItem);
            ConfigItems.Add(SubscriberItem);
          
            ConfigItems.Add(Continuous_queriesItem);
    

        }


    }


    public class InfluxDBGlobal
    {
        public string DataBaseName = "zzscadabase";
        public string User = "root";
        public string Password = "root";
        public string InfluxDBVersion = "v013x";
    }
    public class Backups
    {
        public string BackupFullPath = "D:\\SCADA_BAK";//备份文件路径
        public string BackupCycle = "每天";//备份周期
        public string BackupTime = "23:59:59";//具体每天备份的日期
        public bool Enable = false;
        public DateTime LastBackupDate = DateTime.Now;
    }
    /// <summary>
    /// 服务器端配置
    /// </summary>
    public class CenterServerConfig
    {
        private string xmlname = "";
        public CenterServerConfig(string xml)
        {
            influxdConfig = new influxdConfig();
            Backups = new Backups();
            xmlname = xml;
            //读取xml文件
            ReadConfig(xml);
        }
        public CenterServerConfig()
        {
            influxdConfig = new influxdConfig();
            Backups = new Backups();
            xmlname = Application.StartupPath + "/CenterServerConfig.xml";
            //读取xml文件
            ReadConfig(Application.StartupPath + "/CenterServerConfig.xml");
        }


        public string LocalPort = "8888";
        public string User = "admin";
        public string Password = "123456";
  
        public string WebUrl = "http://127.0.0.1";
        public influxdConfig influxdConfig = new influxdConfig();
        public Backups Backups = new Backups();
        public InfluxDBGlobal InfluxDBGlobal = new InfluxDBGlobal();
        public void ReadConfig(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNodeList list = doc.SelectNodes("/IOServer");
            foreach (XmlNode item in list)
            {

                LocalPort = item["LocalPort"].InnerText.Trim();
                User = item["User"].InnerText.Trim();
                Password = item["Password"].InnerText.Trim();
            
                WebUrl = item["WebUrl"].InnerText.Trim();

                int DelayTime = 20;
                if (int.TryParse(item["DelayTime"].InnerText.Trim(), out DelayTime))
                {
                    TcpPackConfig.DelayTime = DelayTime;
                }
                int recbuffsize = 5120;
                if (int.TryParse(item["ReceiveBufferSize"].InnerText.Trim(), out recbuffsize))
                {
                    TcpPackConfig.ReceiveBufferSize = recbuffsize;
                }

                int sendbuffsize = 5120;
                if (int.TryParse(item["SendBufferSize"].InnerText.Trim(), out sendbuffsize))
                {
                    TcpPackConfig.SendBufferSize = sendbuffsize;
                }
                int sendtimeout = 100000;
                if (int.TryParse(item["SendTimeout"].InnerText.Trim(), out sendtimeout))
                {
                    TcpPackConfig.SendTimeout = sendtimeout;
                }
                int rectimeout = 100000;
                if (int.TryParse(item["ReceiveTimeout"].InnerText.Trim(), out rectimeout))
                {
                    TcpPackConfig.ReceiveTimeout = rectimeout;
                }


                InfluxDBGlobal.DataBaseName = item["InfluxDBGlobal"]["DataBaseName"].InnerText.Trim();
                InfluxDBGlobal.User = item["InfluxDBGlobal"]["User"].InnerText.Trim();
                InfluxDBGlobal.Password = item["InfluxDBGlobal"]["Password"].InnerText.Trim();
                InfluxDBGlobal.InfluxDBVersion = item["InfluxDBGlobal"]["InfluxDBVersion"].InnerText.Trim();
                
            
                //读取实时数据库配置信息
                for (int i = 0; i < influxdConfig.ConfigItems.Count; i++)
                {
                    if (item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()] != null)
                    {
                        if (item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()].Attributes["Description"] != null)
                            influxdConfig.ConfigItems[i].Description = item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()].Attributes["Description"].Value;
                        if (item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()].Attributes["Enable"] != null && item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name].Attributes["Enable"].Value == "true")
                            influxdConfig.ConfigItems[i].Enable = true;
                        else
                            influxdConfig.ConfigItems[i].Enable = false;
                        for (int j = 0; j < influxdConfig.ConfigItems[i].Items.Count; j++)
                        {
                            if (item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()][influxdConfig.ConfigItems[i].Items[j].Key.Trim()] != null)
                            {
                                influxdConfig.ConfigItems[i].Items[j].Value = item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()][influxdConfig.ConfigItems[i].Items[j].Key.Trim()].InnerText.Trim();
                                if (item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()][influxdConfig.ConfigItems[i].Items[j].Key.Trim()].Attributes["ReadOnly"] != null && item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()][influxdConfig.ConfigItems[i].Items[j].Key.Trim()].Attributes["ReadOnly"].Value.Trim() == "true")
                                    influxdConfig.ConfigItems[i].Items[j].ReadOnly = true;
                                else
                                {
                                    influxdConfig.ConfigItems[i].Items[j].ReadOnly = false;

                                }

                                if (item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()][influxdConfig.ConfigItems[i].Items[j].Key.Trim()].Attributes["Description"] != null)
                                {
                                    influxdConfig.ConfigItems[i].Items[j].Description = item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()][influxdConfig.ConfigItems[i].Items[j].Key.Trim()].Attributes["Description"].Value;

                                }
                                if (item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()][influxdConfig.ConfigItems[i].Items[j].Key.Trim()].Attributes["ItemType"] != null)
                                {
                                    influxdConfig.ConfigItems[i].Items[j].ItemType = (ConfigItemType)System.Enum.Parse(typeof(ConfigItemType), item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()][influxdConfig.ConfigItems[i].Items[j].Key.Trim()].Attributes["ItemType"].Value);

                                }

                                if (item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()][influxdConfig.ConfigItems[i].Items[j].Key.Trim()].Attributes["SelectItems"] != null)
                                {
                                    influxdConfig.ConfigItems[i].Items[j].SelectItems = item["InfluxDBConfig"][influxdConfig.ConfigItems[i].Name.Trim()][influxdConfig.ConfigItems[i].Items[j].Key.Trim()].Attributes["SelectItems"].Value.Trim().Split(',').ToList();

                                }

                            }
                        }
                    }

                }
                //结束实时数据库配置信息
                Backups.BackupCycle = item["Backups"]["BackupCycle"].InnerText.Trim();
                Backups.BackupFullPath = item["Backups"]["BackupFullPath"].InnerText.Trim();
                Backups.BackupTime = item["Backups"]["BackupTime"].InnerText.Trim();
                Backups.LastBackupDate = item["Backups"]["LastBackupDate"].InnerText.Trim()!=""?Convert.ToDateTime(item["Backups"]["LastBackupDate"].InnerText.Trim()):DateTime.Now;
                Backups.Enable = false;
                if (Backups.BackupFullPath == "")
                    Backups.BackupFullPath = "D:\\SCADA_BAK";
                bool.TryParse( item["Backups"]["Enable"].InnerText.Trim(), out Backups.Enable);
                for (int i = 0; i < influxdConfig.ConfigItems.Count; i++)
                {
                    
                    for (int j = 0; j < influxdConfig.ConfigItems[i].Items.Count; j++)
                    {
                        if(influxdConfig.ConfigItems[i].Items[j].Value.Trim()=="")
                        {
                            influxdConfig.ConfigItems[i].Items[j].Value = influxdConfig.ConfigItems[i].Items[j].DefaultValue.Trim();
                        }
                    }
                }

            }
            doc = null;
        }
        /// <summary>
        /// 恢复为默认值
        /// </summary>
        public void RecoveryConfig()
        {
            for (int i = 0; i < influxdConfig.ConfigItems.Count; i++)
            {

                for (int j = 0; j < influxdConfig.ConfigItems[i].Items.Count; j++)
                {
                    
                        influxdConfig.ConfigItems[i].Items[j].Value = influxdConfig.ConfigItems[i].Items[j].DefaultValue.Trim();
                }
            }
        }
        /// <summary>
        /// 保存配置文件信息
        /// </summary>
        public void WriteConfig()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlname);
            XmlNodeList list = doc.SelectNodes("/IOServer");
            foreach (XmlNode item in list)
            {
     
                item["WebUrl"].InnerText = WebUrl;
                item["LocalPort"].InnerText = LocalPort;
                item["User"].InnerText = User;
                item["Password"].InnerText = Password;
                item["HeartBeat"].InnerText = TcpPackConfig.HeartBeat;
                item["HeadPack"].InnerText = TcpPackConfig.HeadPack;
                item["TailPack"].InnerText = TcpPackConfig.TailPack;
                item["DelayTime"].InnerText = TcpPackConfig.DelayTime.ToString();
                item["ReceiveBufferSize"].InnerText = TcpPackConfig.ReceiveBufferSize.ToString();
                item["SendBufferSize"].InnerText = TcpPackConfig.SendBufferSize.ToString();
                item["SendTimeout"].InnerText = TcpPackConfig.SendTimeout.ToString();
                item["ReceiveTimeout"].InnerText = TcpPackConfig.ReceiveTimeout.ToString();
                item["InfluxDBGlobal"]["DataBaseName"].InnerText = InfluxDBGlobal.DataBaseName;
                item["InfluxDBGlobal"]["User"].InnerText = InfluxDBGlobal.User;
                item["InfluxDBGlobal"]["Password"].InnerText = InfluxDBGlobal.Password;
                item["InfluxDBConfig"].RemoveAll();

                //读取实时数据库配置信息
                for (int i = 0; i < influxdConfig.ConfigItems.Count; i++)
                {
                    XmlNode firstxn = doc.CreateElement(influxdConfig.ConfigItems[i].Name.Trim());
                    XmlAttribute atrrdesc = doc.CreateAttribute("Description");
                    atrrdesc.Value = influxdConfig.ConfigItems[i].Description;
                    firstxn.Attributes.Append(atrrdesc);
                    XmlAttribute atrrenable = doc.CreateAttribute("Enable");
                    if (influxdConfig.ConfigItems[i].Enable)
                        atrrenable.Value = "true";
                    else
                        atrrenable.Value = "false";
                    firstxn.Attributes.Append(atrrenable);

                    for (int j = 0; j < influxdConfig.ConfigItems[i].Items.Count; j++)
                    {
                        XmlNode secondxn = doc.CreateElement(influxdConfig.ConfigItems[i].Items[j].Key.Trim());
                        XmlAttribute secatrrdesc = doc.CreateAttribute("Description");
                        secatrrdesc.Value = influxdConfig.ConfigItems[i].Items[j].Description;
                        XmlAttribute secatrrdefault = doc.CreateAttribute("DefaultValue");
                        secatrrdefault.Value = influxdConfig.ConfigItems[i].Items[j].DefaultValue;
                        XmlAttribute secatrritemtype = doc.CreateAttribute("ItemType");
                        secatrritemtype.Value = influxdConfig.ConfigItems[i].Items[j].ItemType.ToString();
                        XmlAttribute secatrrreadonly = doc.CreateAttribute("ReadOnly");
                        if (influxdConfig.ConfigItems[i].Items[j].ReadOnly == true)
                            secatrrreadonly.Value = "true";
                        else
                            secatrrreadonly.Value = "false";
                        XmlAttribute secatrrselectitems = doc.CreateAttribute("SelectItems");
                        secatrrselectitems.Value = String.Join(",", influxdConfig.ConfigItems[i].Items[j].SelectItems);

                        secondxn.Attributes.Append(secatrrdesc);
                        secondxn.Attributes.Append(secatrrdefault);
                        secondxn.Attributes.Append(secatrritemtype);
                        secondxn.Attributes.Append(secatrrreadonly);
                        secondxn.Attributes.Append(secatrrselectitems);
                        secondxn.InnerText = influxdConfig.ConfigItems[i].Items[j].Value;
                        firstxn.AppendChild(secondxn);
                    }
                    item["InfluxDBConfig"].AppendChild(firstxn);

                }

                item["Backups"]["BackupCycle"].InnerText = Backups.BackupCycle.Trim();
                item["Backups"]["BackupFullPath"].InnerText = Backups.BackupFullPath.Trim();
                item["Backups"]["BackupTime"].InnerText = Backups.BackupTime.Trim();
                item["Backups"]["LastBackupDate"].InnerText = Backups.LastBackupDate.ToString("yyyy-MM-dd HH:mm:ss");

                if (Backups.Enable)
                item["Backups"]["Enable"].InnerText = "true";
                else
                    item["Backups"]["Enable"].InnerText = "false";


            }

            doc.Save(xmlname);
            doc = null;
            ///重新保存并写入配置文件
            File.Copy(Application.StartupPath + "//influxdb//influxdb.conf", Application.StartupPath + "//influxdb//influxdb" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".conf");
            StreamWriter sw = new StreamWriter(Application.StartupPath + "//influxdb//influxdb.conf", false, Encoding.Default);
            for (int i = 0; i < influxdConfig.ConfigItems.Count; i++)
            {
                sw.WriteLine("### " + influxdConfig.ConfigItems[i].Description + "");
                sw.WriteLine("["+influxdConfig.ConfigItems[i].Name+"]");
                for (int j = 0; j < influxdConfig.ConfigItems[i].Items.Count; j++)
                {
                    string value = influxdConfig.ConfigItems[i].Items[j].Value.Trim() == "" ? influxdConfig.ConfigItems[i].Items[j].DefaultValue.Trim() : influxdConfig.ConfigItems[i].Items[j].Value.Trim();
                    sw.WriteLine(" # " + influxdConfig.ConfigItems[i].Items[j].Description + "");
                    if(influxdConfig.ConfigItems[i].Items[j].ItemType== ConfigItemType.数值|| influxdConfig.ConfigItems[i].Items[j].ItemType == ConfigItemType.对象 || influxdConfig.ConfigItems[i].Items[j].ItemType == ConfigItemType.布尔值)
                    {
                        sw.WriteLine(" "+influxdConfig.ConfigItems[i].Items[j].Key.Trim() + " = " + value + "");
                    }
                    else if (influxdConfig.ConfigItems[i].Items[j].ItemType == ConfigItemType.存储单位|| influxdConfig.ConfigItems[i].Items[j].ItemType == ConfigItemType.字符串|| influxdConfig.ConfigItems[i].Items[j].ItemType == ConfigItemType.时间单位 || influxdConfig.ConfigItems[i].Items[j].ItemType == ConfigItemType.多项列表 || influxdConfig.ConfigItems[i].Items[j].ItemType == ConfigItemType.路径)
                    {
                        sw.WriteLine(" " + influxdConfig.ConfigItems[i].Items[j].Key.Trim() + " = \"" + value + "\"");
                    }
                }
            }
            sw.Close();

        }
    }
}
