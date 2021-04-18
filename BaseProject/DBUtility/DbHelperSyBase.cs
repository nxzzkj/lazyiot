namespace Scada.DBUtility
{
    using Sybase.Data.AseClient;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OracleClient;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class DbHelperSyBase
    {
        public string connectionString = "";

        private AseCommand BuildIntCommand(AseConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            AseCommand command1 = this.BuildQueryCommand(connection, storedProcName, parameters);
            command1.Parameters.Add(new AseParameter("ReturnValue", AseDbType.Integer, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command1;
        }

        private AseCommand BuildQueryCommand(AseConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            AseCommand command = new AseCommand(storedProcName, connection) {
                CommandType = CommandType.StoredProcedure
            };
            foreach (AseParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        public AseDataReader ExecuteReader(string strSQL)
        {
            AseDataReader reader;
            AseConnection connection = new AseConnection(this.connectionString);
            AseCommand command = new AseCommand(strSQL, connection);
            try
            {
                connection.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (OracleException exception1)
            {
                throw new Exception(exception1.Message);
            }
            return reader;
        }

        public AseDataReader ExecuteReader(string SQLString, params AseParameter[] cmdParms)
        {
            AseDataReader reader;
            AseConnection conn = new AseConnection(this.connectionString);
            AseCommand cmd = new AseCommand();
            try
            {
                this.PrepareCommand(cmd, conn, null, SQLString, cmdParms);
                cmd.Parameters.Clear();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (OracleException exception1)
            {
                throw new Exception(exception1.Message);
            }
            return reader;
        }

        public int ExecuteSql(string SQLString)
        {
            int num;
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                AseCommand command = new AseCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    connection.Close();
                    throw new Exception(exception1.Message);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }
            return num;
        }

        public int ExecuteSql(string SQLString, string content)
        {
            int num;
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                AseCommand command = new AseCommand(SQLString, connection);
                AseParameter p = new AseParameter("@content", OracleType.NVarChar) {
                    Value = content
                };
                command.Parameters.Add(p);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    throw new Exception(exception1.Message);
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return num;
        }

        public int ExecuteSql(string SQLString, params AseParameter[] cmdParms)
        {
            int num;
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                AseCommand cmd = new AseCommand();
                try
                {
                    this.PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    cmd.Parameters.Clear();
                    num = cmd.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    throw new Exception(exception1.Message);
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return num;
        }

        public int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            int num;
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                AseCommand command = new AseCommand(strSQL, connection);
                AseParameter p = new AseParameter("@fs", AseDbType.Image) {
                    Value = fs
                };
                command.Parameters.Add(p);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (Exception exception1)
                {
                    throw new Exception(exception1.Message);
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return num;
        }

        public void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                connection.Open();
                using (AseTransaction transaction = connection.BeginTransaction())
                {
                    AseCommand cmd = new AseCommand();
                    try
                    {
                        foreach (DictionaryEntry entry in SQLStringList)
                        {
                            string cmdText = entry.Key.ToString();
                            AseParameter[] cmdParms = (AseParameter[]) entry.Value;
                            this.PrepareCommand(cmd, connection, transaction, cmdText, cmdParms);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            transaction.Commit();
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool Exists(string strSql)
        {
            int num;
            object single = this.GetSingle(strSql);
            if (object.Equals(single, null) || object.Equals(single, DBNull.Value))
            {
                num = 0;
            }
            else
            {
                num = int.Parse(single.ToString());
            }
            if (num == 0)
            {
                return false;
            }
            return true;
        }

        public bool Exists(string strSql, params AseParameter[] cmdParms)
        {
            int num;
            object single = this.GetSingle(strSql, cmdParms);
            if (object.Equals(single, null) || object.Equals(single, DBNull.Value))
            {
                num = 0;
            }
            else
            {
                num = int.Parse(single.ToString());
            }
            if (num == 0)
            {
                return false;
            }
            return true;
        }

        public int GetMaxID(string FieldName, string TableName)
        {
            string sQLString = "select max(" + FieldName + ")+1 from " + TableName;
            object single = this.GetSingle(sQLString);
            if (single == null)
            {
                return 1;
            }
            return int.Parse(single.ToString());
        }

        public object GetSingle(string SQLString)
        {
            object obj3;
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                AseCommand command = new AseCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    object objA = command.ExecuteScalar();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    obj3 = objA;
                }
                catch (Exception exception1)
                {
                    connection.Close();
                    throw new Exception(exception1.Message);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }
            return obj3;
        }

        public object GetSingle(string SQLString, params AseParameter[] cmdParms)
        {
            object obj3;
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                AseCommand cmd = new AseCommand();
                try
                {
                    this.PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    object objA = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    obj3 = objA;
                }
                catch (Exception exception1)
                {
                    throw new Exception(exception1.Message);
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return obj3;
        }

        private void PrepareCommand(AseCommand cmd, AseConnection conn, AseTransaction trans, string cmdText, AseParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (AseParameter parameter in cmdParms)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        public DataSet Query(string SQLString)
        {
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new AseDataAdapter(SQLString, connection).Fill(dataSet, "ds");
                }
                catch (Exception exception1)
                {
                    throw new Exception(exception1.Message);
                }
                return dataSet;
            }
        }

        public DataSet Query(string SQLString, params AseParameter[] cmdParms)
        {
            DataSet set2;
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                AseCommand cmd = new AseCommand();
                this.PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (AseDataAdapter adapter = new AseDataAdapter(cmd))
                {
                    DataSet dataSet = new DataSet();
                    try
                    {
                        adapter.Fill(dataSet, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (Exception exception1)
                    {
                        throw new Exception(exception1.Message);
                    }
                    set2 = dataSet;
                }
            }
            return set2;
        }

        public DataSet QueryPage(string SQLString, int pageindex, int pagesize)
        {
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new AseDataAdapter(SQLString, connection).Fill(dataSet, pagesize * pageindex, pagesize, "ds");
                }
                catch (SqlException exception1)
                {
                    throw new Exception(exception1.Message);
                }
                return dataSet;
            }
        }

        public AseDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            AseConnection connection = new AseConnection(this.connectionString);
            connection.Open();
            AseCommand command1 = this.BuildQueryCommand(connection, storedProcName, parameters);
            command1.CommandType = CommandType.StoredProcedure;
            return command1.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                new AseDataAdapter { SelectCommand = this.BuildQueryCommand(connection, storedProcName, parameters) }.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        public int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (AseConnection connection = new AseConnection(this.connectionString))
            {
                connection.Open();
                AseCommand command = this.BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                return (int) command.Parameters["ReturnValue"].Value;
            }
        }
    }
}

