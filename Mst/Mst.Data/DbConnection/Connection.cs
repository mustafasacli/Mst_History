using System;
using System.Collections;
using System.Data;

namespace Mst.Data.DbConnection
{
    public class Connection : IConnection, IDisposable
    {
        private IDbConnection dbConn;
        IDbTransaction dbTrans;
        private string _ConnString = string.Empty;

        private ConnectionTypes _ConnType = ConnectionTypes.SqlServer;

        public Connection()
            : this(ConnectionTypes.SqlServer, string.Empty)
        { }

        public Connection(String connectionString)
            : this(ConnectionTypes.SqlServer, connectionString)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Connectiontype"></param>
        /// <param name="ConnectionString"></param>
        public Connection(ConnectionTypes Connectiontype, String ConnectionString)
        {
            dbConn = DataObject.GetConnection(Connectiontype);
            dbConn.ConnectionString = ConnectionString;
            _ConnString = ConnectionString;
            _ConnType = Connectiontype;
        }

        public ConnectionTypes ConnectionType
        {
            get
            {
                return _ConnType;
            }
            set
            {
                dbConn = DataObject.GetConnection(value);
                dbConn.ConnectionString = _ConnString;
                _ConnType = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return _ConnString;
            }
            set
            {
                _ConnString = value;
                dbConn.ConnectionString = _ConnString;
            }
        }


        public DataSet GetResultSet(CommandType cmdType, string QueryOrProcedure)
        {
            try
            {
                return GetResultSet(cmdType, QueryOrProcedure, null);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public DataSet GetResultSet(CommandType cmdType, string QueryOrProcedure, Hashtable parameters)
        {
            try
            {
                dbConn.Open();
                dbTrans = dbConn.BeginTransaction();

                DataSet dataSet = new DataSet();

                using (IDbCommand dbCmd = dbConn.CreateCommand())
                {
                    dbCmd.Transaction = dbTrans;
                    dbCmd.CommandType = cmdType;
                    dbCmd.CommandText = QueryOrProcedure;
                    if (null != parameters)
                    {
                        IEnumerator keys = parameters.Keys.GetEnumerator();
                        while (keys.MoveNext())
                        {
                            IDataParameter dbParam = dbCmd.CreateParameter();

                            string key = keys.Current.ToString();
                            if (String.IsNullOrWhiteSpace(key))
                                throw new Exception("Parameter name could not be empty or null.");

                            dbParam.ParameterName = keys.Current.ToString();
                            dbParam.Value = parameters[keys.Current];
                            dbCmd.Parameters.Add(dbParam);
                        }
                    }


                    IDataAdapter dbAdapter =
                        DataObject.GetDataAdapter(_ConnType, dbCmd);

                    dbAdapter.Fill(dataSet);

                    dbCmd.Parameters.Clear();
                    dbTrans.Commit();
                }
                dbTrans.Dispose();
                dbConn.Close();

                return dataSet;
            }
            catch (Exception exc)
            {
                if (null != dbTrans)
                {
                    dbTrans.Rollback();
                    dbTrans.Dispose();
                }
                if (null != dbConn)
                {
                    dbConn.Close();
                }
                throw exc;
            }
        }

        public int ExecuteQuery(CommandType cmdType, string QueryOrProcedure)
        {
            try
            {
                return ExecuteQuery(cmdType, QueryOrProcedure, null);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int ExecuteQuery(CommandType cmdType, string QueryOrProcedure, Hashtable parameters)
        {
            try
            {
                dbConn.Open();
                dbTrans = dbConn.BeginTransaction();

                Int32 returnInt;

                using (IDbCommand dbCmd = dbConn.CreateCommand())
                {
                    dbCmd.Transaction = dbTrans;
                    dbCmd.CommandType = cmdType;
                    dbCmd.CommandText = QueryOrProcedure;
                    if (null != parameters)
                    {
                        IEnumerator keys = parameters.Keys.GetEnumerator();
                        while (keys.MoveNext())
                        {
                            IDataParameter dbParam = dbCmd.CreateParameter();

                            string key = keys.Current.ToString();
                            if (String.IsNullOrWhiteSpace(key))
                                throw new Exception("Parameter name could not be empty or null.");

                            dbParam.ParameterName = keys.Current.ToString();
                            dbParam.Value = parameters[keys.Current];
                            dbCmd.Parameters.Add(dbParam);
                        }
                    }

                    returnInt = dbCmd.ExecuteNonQuery();

                    dbCmd.Parameters.Clear();
                    dbTrans.Commit();
                }
                dbTrans.Dispose();
                dbConn.Close();

                return returnInt;
            }
            catch (Exception exc)
            {
                if (null != dbTrans)
                {
                    dbTrans.Rollback();
                    dbTrans.Dispose();
                }
                if (null != dbConn)
                {
                    dbConn.Close();
                }
                throw exc;
            }
        }

        public object ExecuteScalar(CommandType cmdType, string QueryOrProcedure)
        {
            try
            {
                return ExecuteScalar(cmdType, QueryOrProcedure, null);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public object ExecuteScalar(CommandType cmdType, string QueryOrProcedure, Hashtable parameters)
        {
            try
            {
                dbConn.Open();
                dbTrans = dbConn.BeginTransaction();

                object returnObj;

                using (IDbCommand dbCmd = dbConn.CreateCommand())
                {
                    dbCmd.Transaction = dbTrans;
                    dbCmd.CommandType = cmdType;
                    dbCmd.CommandText = QueryOrProcedure;
                    if (null != parameters)
                    {
                        IEnumerator keys = parameters.Keys.GetEnumerator();
                        while (keys.MoveNext())
                        {
                            IDataParameter dbParam = dbCmd.CreateParameter();

                            string key = keys.Current.ToString();
                            if (String.IsNullOrWhiteSpace(key))
                                throw new Exception("Parameter name could not be empty or null.");

                            dbParam.ParameterName = keys.Current.ToString();
                            dbParam.Value = parameters[keys.Current];
                            dbCmd.Parameters.Add(dbParam);
                        }
                    }

                    returnObj = dbCmd.ExecuteScalar();

                    dbCmd.Parameters.Clear();
                    dbTrans.Commit();
                }
                dbTrans.Dispose();
                dbConn.Close();

                return returnObj;
            }
            catch (Exception exc)
            {
                if (null != dbTrans)
                {
                    dbTrans.Rollback();
                    dbTrans.Dispose();
                }
                if (null != dbConn)
                {
                    dbConn.Close();
                }
                throw exc;
            }
        }

        public IDataReader ExecuteReader(CommandType cmdType, string QueryOrProcedure)
        {
            try
            {
                return ExecuteReader(cmdType, QueryOrProcedure, null);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public IDataReader ExecuteReader(CommandType cmdType, string QueryOrProcedure, Hashtable parameters)
        {
            try
            {
                dbConn.Open();
                dbTrans = dbConn.BeginTransaction();

                IDataReader retDataReader;

                using (IDbCommand dbCmd = dbConn.CreateCommand())
                {
                    dbCmd.Transaction = dbTrans;
                    dbCmd.CommandType = cmdType;
                    dbCmd.CommandText = QueryOrProcedure;
                    if (null != parameters)
                    {
                        IEnumerator keys = parameters.Keys.GetEnumerator();
                        while (keys.MoveNext())
                        {
                            IDataParameter dbParam = dbCmd.CreateParameter();

                            string key = keys.Current.ToString();
                            if (String.IsNullOrWhiteSpace(key))
                                throw new Exception("Parameter name could not be empty or null.");

                            dbParam.ParameterName = keys.Current.ToString();
                            dbParam.Value = parameters[keys.Current].ToString();
                            dbCmd.Parameters.Add(dbParam);
                        }
                    }

                    retDataReader = dbCmd.ExecuteReader();

                    dbCmd.Parameters.Clear();
                    dbTrans.Commit();
                }
                dbTrans.Dispose();
                dbConn.Close();

                return retDataReader;
            }
            catch (Exception exc)
            {
                if (null != dbTrans)
                {
                    dbTrans.Rollback();
                    dbTrans.Dispose();
                }
                if (null != dbConn)
                {
                    dbConn.Close();
                }
                throw exc;
            }
        }

        public void Dispose()
        {
            if (null != dbConn)
            {
                if (dbConn.State == ConnectionState.Open)
                    dbConn.Close();
            }
            else
            { }
            dbConn.Dispose();
            GC.Collect();
        }
    }
}
