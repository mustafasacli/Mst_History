namespace Mst.Data.DBConnection
{
    using System;
    using System.Collections;
    using System.Data;

    public class Connection : IConnection, IDisposable
    {
        #region [ Private Fields ]

        private IDbConnection dbConn;
        private IDbTransaction dbTrans;

        private string _ConnString = string.Empty;
        private ConnectionTypes _ConnType = ConnectionTypes.SqlServer;

        #endregion


        #region [ Connection Contructor With No Parameter]

        /// <summary>
        /// Creates Connection Object with SqlServer ConnectionType and empty Connection String.
        /// </summary>
        public Connection()
            : this(ConnectionTypes.SqlServer, string.Empty)
        {
        }

        #endregion


        #region [ Connnection Constructor With Connection String]

        /// <summary>
        /// Creates Connection Object with given Connection String and SqlServer ConnectionType.
        /// </summary>
        /// <param name="ConnectionString"></param>
        public Connection(String ConnectionString)
            : this(ConnectionTypes.SqlServer, ConnectionString)
        { }

        #endregion


        #region [ Connetion Constructor with Connection Type And Connection String ]

        /// <summary>
        /// Creates Connection Object with given ConnectionType And ConnectionString.
        /// </summary>
        /// <param name="ConnectionType">Connection Type</param>
        /// <param name="connectionString">Connection String</param>
        public Connection(ConnectionTypes ConnectionType, String connectionString)
        {
            dbConn = ConnectionObject.GetConnection(ConnectionType);
            dbConn.ConnectionString = connectionString;
            _ConnString = connectionString;
            _ConnType = ConnectionType;
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Resolver);

        }

        #endregion

        static System.Reflection.Assembly Resolver(object sender, ResolveEventArgs args)
        {
            Assembly a1 = Assembly.GetExecutingAssembly();
            Stream s = a1.GetManifestResourceStream(args.Name);
            byte[] block = new byte[s.Length];
            s.Read(block, 0, block.Length);
            Assembly a2 = Assembly.Load(block);
            return a2;
        }


        #region [ ConnectionType Property Of Connection ]

        /// <summary>
        ///  ConnectionType Of Connection.
        /// </summary>
        public ConnectionTypes ConnectionType
        {
            get
            {
                return _ConnType;
            }
            set
            {
                dbConn = ConnectionObject.GetConnection(value);
                dbConn.ConnectionString = _ConnString;
                _ConnType = value;
            }
        }

        #endregion


        #region [ ConnectionString Property Of Connection ]

        /// <summary>
        /// Connection String Of Connection.
        /// </summary>
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

        #endregion


        #region [ Get ResultSet With CommandType And QueryOrProcedure ]

        /// <summary>
        /// Get DataSet with given CommandType And Procedure Name Or Query.
        /// </summary>
        /// <param name="cmdType">CommandType cmdType Like Text, StoredProcedure, etc. </param>
        /// <param name="QueryOrProcedure">Procedure Name Or Query</param>
        /// <returns>Returns System.Data.DataSet object</returns>
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

        #endregion


        #region [ Get ResultSet With CommandType, QueryOrProcedure And Parameters ]
        /// <summary>
        /// Get DataSet with given CommandType, Procedure Name Or Query And Hashtable.
        /// </summary>
        /// <param name="cmdType">CommandType cmdType Like Text, StoredProcedure, etc. </param>
        /// <param name="QueryOrProcedure">Procedure Name Or Query</param>
        /// <param name="parameters">Hashtable object contains parameters names and values.</param>
        /// <returns>>Returns System.Data.DataSet object</returns>
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
                        ConnectionObject.GetDataAdapter(_ConnType, dbCmd);

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

        #endregion


        #region [ Execute Query With CommandType And QueryOrProcedure ]

        /// <summary>
        /// Execute Query with given CommandType And Procedure Name Or Query.
        /// </summary>
        /// <param name="cmdType">CommandType cmdType Like Text, StoredProcedure, etc.</param>
        /// <param name="QueryOrProcedure">Procedure Name Or Query</param>
        /// <returns>Returns value of ExecuteQuery method.</returns>
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

        #endregion


        #region [ Execute Query With CommandType, QueryOrProcedure And Parameters ]

        /// <summary>
        /// Execute Query with given CommandType, Procedure Name Or Query And Hashtable.
        /// </summary>
        /// <param name="cmdType">CommandType cmdType Like Text, StoredProcedure, etc. </param>
        /// <param name="QueryOrProcedure">Procedure Name Or Query</param>
        /// <param name="parameters">Hashtable object contains parameters names and values.</param>
        /// <returns>Returns value of ExecuteQuery method.</returns>
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

        #endregion


        #region [ Execute Scalar With CommandType And QueryOrProcedure ]

        /// <summary>
        /// Execute Scalar with given CommandType And Procedure Name Or Query.
        /// </summary>
        /// <param name="cmdType">CommandType cmdType Like Text, StoredProcedure, etc.</param>
        /// <param name="QueryOrProcedure">Procedure Name Or Query</param>
        /// <returns>Returns value of ExecuteScalar method.</returns>
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

        #endregion


        #region [ Execute Scalar With CommandType, QueryOrProcedure And Parameters ]

        /// <summary>
        /// Execute Scalar with given CommandType, Procedure Name Or Query And Hashtable.
        /// </summary>
        /// <param name="cmdType">CommandType cmdType Like Text, StoredProcedure, etc.</param>
        /// <param name="QueryOrProcedure">Procedure Name Or Query</param>
        /// <param name="parameters">Hashtable object contains parameters names and values.</param>
        /// <returns>Returns value of ExecuteScalar method.</returns>
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

        #endregion


        #region [ Execute Reader With CommandType And QueryOrProcedure ]

        /// <summary>
        /// Execute Reader with given CommandType And Procedure Name Or Query.
        /// </summary>
        /// <param name="cmdType">CommandType cmdType Like Text, StoredProcedure, etc.</param>
        /// <param name="QueryOrProcedure">Procedure Name Or Query</param>
        /// <returns>Returns System.Data.IDataReader object.</returns>
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

        #endregion


        #region [ Execute Reader With CommandType, QueryOrProcedure And Parameters ]

        /// <summary>
        /// Execute Reader with given CommandType, Procedure Name Or Query And Hashtable.
        /// </summary>
        /// <param name="cmdType">CommandType cmdType Like Text, StoredProcedure, etc.</param>
        /// <param name="QueryOrProcedure">Procedure Name Or Query</param>
        /// <param name="parameters">Hashtable object contains parameters names and values</param>
        /// <returns>Returns System.Data.IDataReader object.</returns>
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

        #endregion


        #region [ Dispose Method ]

        public void Dispose()
        {
            if (null != dbConn)
            {
                if (dbConn.State == ConnectionState.Open)
                    dbConn.Close();
            }

            dbConn.Dispose();
            GC.Collect();
        }

        #endregion

    }
}
