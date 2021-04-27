namespace Scada.DBUtility
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class DbHelperMySQL
    {
        public string connectionString = "";

        public MySqlDataReader ExecuteReader(string strSQL)
        {
            MySqlDataReader reader;
            MySqlConnection connection = new MySqlConnection(this.connectionString);
            MySqlCommand command = new MySqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (MySqlException exception1)
            {
                throw exception1;
            }
            return reader;
        }

        public MySqlDataReader ExecuteReader(string SQLString, params MySqlParameter[] cmdParms)
        {
            MySqlDataReader reader;
            MySqlConnection conn = new MySqlConnection(this.connectionString);
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                PrepareCommand(cmd, conn, null, SQLString, cmdParms);
                cmd.Parameters.Clear();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (MySqlException exception1)
            {
                throw exception1;
            }
            return reader;
        }

        public int ExecuteSql(string SQLString)
        {
            int num;
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                MySqlCommand command = new MySqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (MySqlException exception1)
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                MySqlCommand command = new MySqlCommand(SQLString, connection);
                MySqlParameter parameter = new MySqlParameter("@content", SqlDbType.NText) {
                    Value = content
                };
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (MySqlException exception1)
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

        public int ExecuteSql(string SQLString, params MySqlParameter[] cmdParms)
        {
            int num;
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    cmd.Parameters.Clear();
                    num = cmd.ExecuteNonQuery();
                }
                catch (MySqlException exception1)
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                MySqlCommand command = new MySqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    command.CommandTimeout = Times;
                    num = command.ExecuteNonQuery();
                }
                catch (MySqlException exception1)
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                MySqlCommand command = new MySqlCommand(SQLString, connection);
                MySqlParameter parameter = new MySqlParameter("@content", SqlDbType.NText) {
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
                catch (MySqlException exception1)
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                MySqlCommand command = new MySqlCommand(strSQL, connection);
                MySqlParameter parameter = new MySqlParameter("@fs", SqlDbType.Image) {
                    Value = fs
                };
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (MySqlException exception1)
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    try
                    {
                        int num = 0;
                        foreach (CommandInfo info in cmdList)
                        {
                            string commandText = info.CommandText;
                            MySqlParameter[] parameters = (MySqlParameter[]) info.Parameters;
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand {
                    Connection = connection
                };
                MySqlTransaction transaction = connection.BeginTransaction();
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    try
                    {
                        foreach (DictionaryEntry entry in SQLStringList)
                        {
                            string cmdText = entry.Key.ToString();
                            MySqlParameter[] cmdParms = (MySqlParameter[]) entry.Value;
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    try
                    {
                        int num = 0;
                        foreach (CommandInfo local1 in SQLStringList)
                        {
                            string commandText = local1.CommandText;
                            MySqlParameter[] parameters = (MySqlParameter[]) local1.Parameters;
                            foreach (MySqlParameter parameter in parameters)
                            {
                                if (parameter.Direction == ParameterDirection.InputOutput)
                                {
                                    parameter.Value = num;
                                }
                            }
                            PrepareCommand(cmd, connection, transaction, commandText, parameters);
                            cmd.ExecuteNonQuery();
                            foreach (MySqlParameter parameter2 in parameters)
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    try
                    {
                        int num = 0;
                        foreach (DictionaryEntry entry in SQLStringList)
                        {
                            string cmdText = entry.Key.ToString();
                            MySqlParameter[] cmdParms = (MySqlParameter[]) entry.Value;
                            foreach (MySqlParameter parameter in cmdParms)
                            {
                                if (parameter.Direction == ParameterDirection.InputOutput)
                                {
                                    parameter.Value = num;
                                }
                            }
                            PrepareCommand(cmd, connection, transaction, cmdText, cmdParms);
                            cmd.ExecuteNonQuery();
                            foreach (MySqlParameter parameter2 in cmdParms)
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

        public bool Exists(string strSql, params MySqlParameter[] cmdParms)
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                MySqlCommand command = new MySqlCommand(SQLString, connection);
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
                catch (MySqlException exception1)
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                MySqlCommand command = new MySqlCommand(SQLString, connection);
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
                catch (MySqlException exception1)
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

        public object GetSingle(string SQLString, params MySqlParameter[] cmdParms)
        {
            object obj3;
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                MySqlCommand cmd = new MySqlCommand();
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
                catch (MySqlException exception1)
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

        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] cmdParms)
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
                foreach (MySqlParameter parameter in cmdParms)
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new MySqlDataAdapter(SQLString, connection).Fill(dataSet, "ds");
                }
                catch (MySqlException exception1)
                {
                    throw new Exception(exception1.Message);
                }
                return dataSet;
            }
        }

        public DataSet Query(string SQLString, int Times)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new MySqlDataAdapter(SQLString, connection) { SelectCommand = { CommandTimeout = Times } }.Fill(dataSet, "ds");
                }
                catch (MySqlException exception1)
                {
                    throw new Exception(exception1.Message);
                }
                return dataSet;
            }
        }

        public DataSet Query(string SQLString, params MySqlParameter[] cmdParms)
        {
            DataSet set2;
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataSet dataSet = new DataSet();
                    try
                    {
                        adapter.Fill(dataSet, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (MySqlException exception1)
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
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new MySqlDataAdapter(SQLString, connection).Fill(dataSet, pagesize * pageindex, pagesize, "ds");
                }
                catch (SqlException exception1)
                {
                    throw new Exception(exception1.Message);
                }
                return dataSet;
            }
        }
    }
}

