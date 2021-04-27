namespace Scada.DBUtility
{
    using System;
    using System.Data;

    public class ScadaDBHelper
    {
        private ScadaConnectionBase ConnectionBasic;

        public ScadaDBHelper(ScadaConnectionBase connectionBase)
        {
            this.ConnectionBasic = connectionBase;
        }

        public int ExecuteSql(string sql)
        {
            switch (this.ConnectionBasic.DataBaseType)
            {
                case DataBaseType.SQLServer:
                {
                    DbHelperSQL rsql1 = new DbHelperSQL {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return rsql1.ExecuteSql(sql);
                }
                case DataBaseType.Oracle:
                {
                    DbHelperOra ora1 = new DbHelperOra {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ora1.ExecuteSql(sql);
                }
                case DataBaseType.MySQL:
                {
                    DbHelperMySQL ysql1 = new DbHelperMySQL {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ysql1.ExecuteSql(sql);
                }
                case DataBaseType.SyBase:
                {
                    DbHelperSyBase base1 = new DbHelperSyBase {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return base1.ExecuteSql(sql);
                }
                case DataBaseType.SQLite:
                {
                    DbHelperSQLiteEx ex1 = new DbHelperSQLiteEx {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ex1.ExecuteSql(sql);
                }
            }
            return 0;
        }

        public object GetSingle(string sql)
        {
            switch (this.ConnectionBasic.DataBaseType)
            {
                case DataBaseType.SQLServer:
                {
                    DbHelperSQL rsql1 = new DbHelperSQL {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return rsql1.GetSingle(sql);
                }
                case DataBaseType.Oracle:
                {
                    DbHelperOra ora1 = new DbHelperOra {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ora1.GetSingle(sql);
                }
                case DataBaseType.MySQL:
                {
                    DbHelperMySQL ysql1 = new DbHelperMySQL {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ysql1.GetSingle(sql);
                }
                case DataBaseType.SyBase:
                {
                    DbHelperSyBase base1 = new DbHelperSyBase {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return base1.GetSingle(sql);
                }
                case DataBaseType.SQLite:
                {
                    DbHelperSQLiteEx ex1 = new DbHelperSQLiteEx {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ex1.GetSingle(sql);
                }
            }
            return 0;
        }

        public DataSet Query(string sql)
        {
            switch (this.ConnectionBasic.DataBaseType)
            {
                case DataBaseType.SQLServer:
                {
                    DbHelperSQL rsql1 = new DbHelperSQL {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return rsql1.Query(sql);
                }
                case DataBaseType.Oracle:
                {
                    DbHelperOra ora1 = new DbHelperOra {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ora1.Query(sql);
                }
                case DataBaseType.MySQL:
                {
                    DbHelperMySQL ysql1 = new DbHelperMySQL {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ysql1.Query(sql);
                }
                case DataBaseType.SyBase:
                {
                    DbHelperSyBase base1 = new DbHelperSyBase {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return base1.Query(sql);
                }
                case DataBaseType.SQLite:
                {
                    DbHelperSQLiteEx ex1 = new DbHelperSQLiteEx {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ex1.Query(sql);
                }
            }
            return new DataSet();
        }

        public DataSet QueryPage(string sql, int pageindex, int pagesize)
        {
            if (pageindex <= 0)
            {
                pageindex = 1;
            }
            pageindex--;
            switch (this.ConnectionBasic.DataBaseType)
            {
                case DataBaseType.SQLServer:
                {
                    DbHelperSQL rsql1 = new DbHelperSQL {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return rsql1.QueryPage(sql, pageindex, pagesize);
                }
                case DataBaseType.Oracle:
                {
                    DbHelperOra ora1 = new DbHelperOra {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ora1.QueryPage(sql, pageindex, pagesize);
                }
                case DataBaseType.MySQL:
                {
                    DbHelperMySQL ysql1 = new DbHelperMySQL {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ysql1.QueryPage(sql, pageindex, pagesize);
                }
                case DataBaseType.SyBase:
                {
                    DbHelperSyBase base1 = new DbHelperSyBase {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return base1.QueryPage(sql, pageindex, pagesize);
                }
                case DataBaseType.SQLite:
                {
                    DbHelperSQLiteEx ex1 = new DbHelperSQLiteEx {
                        connectionString = DESEncrypt.Decrypt(this.ConnectionBasic.ConnectionString)
                    };
                    return ex1.QueryPage(sql, pageindex, pagesize);
                }
            }
            return new DataSet();
        }
    }
}

