namespace Scada.DBUtility
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class DbHelperSQL
    {
        public string connectionString = "";

        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command1 = BuildQueryCommand(connection, storedProcName, parameters);
            command1.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command1;
        }

        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection) {
                CommandType = CommandType.StoredProcedure
            };
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    if (((parameter.Direction == ParameterDirection.InputOutput) || (parameter.Direction == ParameterDirection.Input)) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }

        public bool ColumnExists(string tableName, string columnName)
        {
            string[] textArray1 = new string[] { "select count(1) from syscolumns where [id]=object_id('", tableName, "') and [name]='", columnName, "'" };
            string sQLString = string.Concat(textArray1);
            object single = this.GetSingle(sQLString);
            if (single == null)
            {
                return false;
            }
            return (Convert.ToInt32(single) > 0);
        }

        public SqlDataReader ExecuteReader(string strSQL)
        {
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection(this.connectionString);
            SqlCommand command = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException exception1)
            {
                throw exception1;
            }
            return reader;
        }

        public SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlDataReader reader;
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, conn, null, SQLString, cmdParms);
                cmd.Parameters.Clear();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException exception1)
            {
                throw exception1;
            }
            return reader;
        }

        public int ExecuteSql(string SQLString)
        {
            int num;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SqlException exception1)
                {
                    connection.Close();
                    throw exception1;
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
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                SqlParameter parameter = new SqlParameter("@content", SqlDbType.NText) {
                    Value = content
                };
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SqlException exception1)
                {
                    throw exception1;
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return num;
        }

        public int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            int num;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    cmd.Parameters.Clear();
                    num = cmd.ExecuteNonQuery();
                }
                catch (SqlException exception1)
                {
                    throw exception1;
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

        public int ExecuteSqlByTime(string SQLString, int Times)
        {
            int num;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    command.CommandTimeout = Times;
                    num = command.ExecuteNonQuery();
                }
                catch (SqlException exception1)
                {
                    connection.Close();
                    throw exception1;
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

        public object ExecuteSqlGet(string SQLString, string content)
        {
            object obj3;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                SqlParameter parameter = new SqlParameter("@content", SqlDbType.NText) {
                    Value = content
                };
                command.Parameters.Add(parameter);
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
                catch (SqlException exception1)
                {
                    throw exception1;
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return obj3;
        }

        public int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            int num;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand(strSQL, connection);
                SqlParameter parameter = new SqlParameter("@fs", SqlDbType.Image) {
                    Value = fs
                };
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SqlException exception1)
                {
                    throw exception1;
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
            return num;
        }

        public int ExecuteSqlTran(List<CommandInfo> cmdList)
        {
            int num3;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int num = 0;
                        foreach (CommandInfo info in cmdList)
                        {
                            string commandText = info.CommandText;
                            SqlParameter[] parameters = (SqlParameter[]) info.Parameters;
                            PrepareCommand(cmd, connection, transaction, commandText, parameters);
                            if ((info.EffentNextType == EffentNextType.WhenHaveContine) || (info.EffentNextType == EffentNextType.WhenNoHaveContine))
                            {
                                if (info.CommandText.ToLower().IndexOf("count(") == -1)
                                {
                                    transaction.Rollback();
                                    return 0;
                                }
                                object obj2 = cmd.ExecuteScalar();
                                bool flag = false;
                                if ((obj2 == null) && (obj2 == DBNull.Value))
                                {
                                    flag = false;
                                }
                                flag = Convert.ToInt32(obj2) > 0;
                                if ((info.EffentNextType == EffentNextType.WhenHaveContine) && !flag)
                                {
                                    transaction.Rollback();
                                    return 0;
                                }
                                if ((info.EffentNextType == EffentNextType.WhenNoHaveContine) & flag)
                                {
                                    transaction.Rollback();
                                    return 0;
                                }
                            }
                            else
                            {
                                int num2 = cmd.ExecuteNonQuery();
                                num += num2;
                                if ((info.EffentNextType == EffentNextType.ExcuteEffectRows) && (num2 == 0))
                                {
                                    transaction.Rollback();
                                    return 0;
                                }
                                cmd.Parameters.Clear();
                            }
                        }
                        transaction.Commit();
                        num3 = num;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return num3;
        }

        public int ExecuteSqlTran(List<string> SQLStringList)
        {
            int num3;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand {
                    Connection = connection
                };
                SqlTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    int num = 0;
                    for (int i = 0; i < SQLStringList.Count; i++)
                    {
                        string str = SQLStringList[i];
                        if (str.Trim().Length > 1)
                        {
                            command.CommandText = str;
                            num += command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    num3 = num;
                }
                catch
                {
                    transaction.Rollback();
                    num3 = 0;
                }
            }
            return num3;
        }

        public void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry entry in SQLStringList)
                        {
                            string cmdText = entry.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[]) entry.Value;
                            PrepareCommand(cmd, connection, transaction, cmdText, cmdParms);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void ExecuteSqlTranWithIndentity(List<CommandInfo> SQLStringList)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int num = 0;
                        foreach (CommandInfo local1 in SQLStringList)
                        {
                            string commandText = local1.CommandText;
                            SqlParameter[] parameters = (SqlParameter[]) local1.Parameters;
                            foreach (SqlParameter parameter in parameters)
                            {
                                if (parameter.Direction == ParameterDirection.InputOutput)
                                {
                                    parameter.Value = num;
                                }
                            }
                            PrepareCommand(cmd, connection, transaction, commandText, parameters);
                            cmd.ExecuteNonQuery();
                            foreach (SqlParameter parameter2 in parameters)
                            {
                                if (parameter2.Direction == ParameterDirection.Output)
                                {
                                    num = Convert.ToInt32(parameter2.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int num = 0;
                        foreach (DictionaryEntry entry in SQLStringList)
                        {
                            string cmdText = entry.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[]) entry.Value;
                            foreach (SqlParameter parameter in cmdParms)
                            {
                                if (parameter.Direction == ParameterDirection.InputOutput)
                                {
                                    parameter.Value = num;
                                }
                            }
                            PrepareCommand(cmd, connection, transaction, cmdText, cmdParms);
                            cmd.ExecuteNonQuery();
                            foreach (SqlParameter parameter2 in cmdParms)
                            {
                                if (parameter2.Direction == ParameterDirection.Output)
                                {
                                    num = Convert.ToInt32(parameter2.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        transaction.Commit();
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

        public bool Exists(string strSql, params SqlParameter[] cmdParms)
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
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
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
                catch (SqlException exception1)
                {
                    connection.Close();
                    throw exception1;
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

        public object GetSingle(string SQLString, int Times)
        {
            object obj3;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    command.CommandTimeout = Times;
                    object objA = command.ExecuteScalar();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    obj3 = objA;
                }
                catch (SqlException exception1)
                {
                    connection.Close();
                    throw exception1;
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

        public object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            object obj3;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    object objA = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    obj3 = objA;
                }
                catch (SqlException exception1)
                {
                    throw exception1;
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

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
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
                foreach (SqlParameter parameter in cmdParms)
                {
                    if (((parameter.Direction == ParameterDirection.InputOutput) || (parameter.Direction == ParameterDirection.Input)) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        public DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new SqlDataAdapter(SQLString, connection).Fill(dataSet, "ds");
                }
                catch (SqlException exception1)
                {
                    throw new Exception(exception1.Message);
                }
                return dataSet;
            }
        }

        public DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new SqlDataAdapter(SQLString, connection) { SelectCommand = { CommandTimeout = Times } }.Fill(dataSet, "ds");
                }
                catch (SqlException exception1)
                {
                    throw new Exception(exception1.Message);
                }
                return dataSet;
            }
        }

        public DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            DataSet set2;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet dataSet = new DataSet();
                    try
                    {
                        adapter.Fill(dataSet, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException exception1)
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
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new SqlDataAdapter(SQLString, connection).Fill(dataSet, pagesize * pageindex, pagesize, "ds");
                }
                catch (SqlException exception1)
                {
                    throw new Exception(exception1.Message);
                }
                return dataSet;
            }
        }

        public SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(this.connectionString);
            connection.Open();
            SqlCommand command1 = BuildQueryCommand(connection, storedProcName, parameters);
            command1.CommandType = CommandType.StoredProcedure;
            return command1.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                new SqlDataAdapter { SelectCommand = BuildQueryCommand(connection, storedProcName, parameters) }.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        public int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                return (int) command.Parameters["ReturnValue"].Value;
            }
        }

        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter adapter1 = new SqlDataAdapter {
                    SelectCommand = BuildQueryCommand(connection, storedProcName, parameters)
                };
                adapter1.SelectCommand.CommandTimeout = Times;
                adapter1.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        public bool TabExists(string TableName)
        {
            int num;
            string sQLString = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            object single = this.GetSingle(sQLString);
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
    }
}

