namespace Scada.DBUtility
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SQLite;

    public abstract class DbHelperSQLite
    {
        public static bool IsSocket = false;
        public static string connectionString = "";

        public static void Compress()
        {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                PrepareCommand(cmd, conn, null, "VACUUM");
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException exception1)
            {
                throw new Exception(exception1.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static SQLiteDataReader ExecuteReader(string strSQL)
        {
            SQLiteDataReader reader;
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand command = new SQLiteCommand(strSQL, connection);
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (SQLiteException exception1)
            {
                throw new Exception(exception1.Message);
            }
            return reader;
        }

        public static SQLiteDataReader ExecuteReader(string SQLString, params SQLiteParameter[] cmdParms)
        {
            SQLiteDataReader reader2;
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                PrepareCommand(cmd, conn, null, SQLString, cmdParms);
                SQLiteDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                reader2 = reader;
            }
            catch (SQLiteException exception1)
            {
                throw new Exception(exception1.Message);
            }
            return reader2;
        }

        public static int ExecuteSql(string SQLString)
        {
            int num;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                 
                }
                catch (SQLiteException exception1)
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
                    connection.Close();
                }
            }
            return num;
        }

        public static int ExecuteSql(string SQLString, string content)
        {
            int num;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(SQLString, connection);
                SQLiteParameter parameter = new SQLiteParameter("@content", DbType.String) {
                    Value = content
                };
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SQLiteException exception1)
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

        public static int ExecuteSql(string SQLString, params SQLiteParameter[] cmdParms)
        {
            int num;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    try
                    {
                        PrepareCommand(command, connection, null, SQLString, cmdParms);
                        
                        num = command.ExecuteNonQuery();
                    }
                    catch (SQLiteException exception1)
                    {
                        throw new Exception(exception1.Message);
                    }
                    finally
                    {
                        command.Parameters.Clear();
                        command.Dispose();
                        connection.Close();
                    }
                }
            }
            return num;
        }

        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            int num;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(strSQL, connection);
                SQLiteParameter parameter = new SQLiteParameter("@fs", DbType.Binary) {
                    Value = fs
                };
                command.Parameters.Add(parameter);
                try
                {
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (SQLiteException exception1)
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

        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand {
                    Connection = connection
                };
                SQLiteTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    for (int i = 0; i < SQLStringList.Count; i++)
                    {
                        string str = SQLStringList[i].ToString();
                        if (str.Trim().Length > 1)
                        {
                            command.CommandText = str;
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                catch (SQLiteException exception1)
                {
                    transaction.Rollback();
                    throw new Exception(exception1.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    try
                    {
                        foreach (DictionaryEntry entry in SQLStringList)
                        {
                            string cmdText = entry.Key.ToString();
                            SQLiteParameter[] cmdParms = (SQLiteParameter[]) entry.Value;
                            PrepareCommand(cmd, connection, transaction, cmdText, cmdParms);
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
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public static bool Exists(string strSql)
        {
            int num;
            object single = GetSingle(strSql);
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

        public static bool Exists(string strSql, params SQLiteParameter[] cmdParms)
        {
            int num;
            object single = GetSingle(strSql, cmdParms);
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

        public static int GetMaxID(string FieldName, string TableName)
        {
            object single = GetSingle("select max(" + FieldName + ")+1 from " + TableName);
            if (single == null)
            {
                return 1;
            }
            return int.Parse(single.ToString());
        }

        public static object GetSingle(string SQLString)
        {
            object obj3;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(SQLString, connection);
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
                catch (SQLiteException exception1)
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

        public static object GetSingle(string SQLString, params SQLiteParameter[] cmdParms)
        {
            object obj3;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    try
                    {
                        PrepareCommand(command, connection, null, SQLString, cmdParms);
                        object objA = command.ExecuteScalar();
                        command.Parameters.Clear();
                        if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                        {
                            return null;
                        }
                        obj3 = objA;
                    }
                    catch (SQLiteException exception1)
                    {
                        throw new Exception(exception1.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return obj3;
        }

        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText)
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
        }

        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText, SQLiteParameter[] cmdParms)
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
                foreach (SQLiteParameter parameter in cmdParms)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        public static DataSet Query(string SQLString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new SQLiteDataAdapter(SQLString, connection).Fill(dataSet, "ds");
                }
                catch (SQLiteException exception1)
                {
                    throw new Exception(exception1.Message);
                }
                finally
                {
                    connection.Close();
                }
                return dataSet;
            }
        }

        public static DataSet Query(string SQLString, params SQLiteParameter[] cmdParms)
        {
            DataSet set2;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataSet dataSet = new DataSet();
                    try
                    {
                        adapter.Fill(dataSet, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SQLiteException exception1)
                    {
                        throw new Exception(exception1.Message);
                    }
                    connection.Close();
                    set2 = dataSet;
                }
            }
            return set2;
        }

        public DataSet QueryPage(string SQLString, int pageindex, int pagesize)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new SQLiteDataAdapter(SQLString, connection).Fill(dataSet, pagesize * pageindex, pagesize, "ds");
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

