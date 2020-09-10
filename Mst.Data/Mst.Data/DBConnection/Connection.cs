namespace Mst.Data.DBConnection
{
    using FirebirdSql.Data.FirebirdClient;
    using MySql.Data.MySqlClient;
    using Npgsql;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data.SqlServerCe;
    using System.IO;
    using System.Reflection;
    using VistaDB.Provider;

    public class Connection : IConnection
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
        { }

        #endregion


        #region [ Connnection Constructor With Connection String]

        /// <summary>
        /// Creates Connection Object with given Connection String and SqlServer ConnectionType.
        /// </summary>
        /// <param name="ConnectionString"></param>
        public Connection(String ConnectionString)
            : this(ConnectionTypes.SqlExpress, ConnectionString)
        { }

        #endregion


        #region [ Connection Constructor with Connection Type And Connection String ]

        /// <summary>
        /// Creates Connection Object with given ConnectionType And ConnectionString.
        /// </summary>
        /// <param name="ConnectionType">Connection Type</param>
        /// <param name="connectionString">Connection String</param>
        public Connection(ConnectionTypes ConnectionType, String connectionString)
        {
            _ConnString = connectionString;
            _ConnType = ConnectionType;
            dbConn = CreateConnection();
            dbConn.ConnectionString = connectionString;
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
                _ConnType = value;
                dbConn = CreateConnection();
                dbConn.ConnectionString = _ConnString;

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
                CreateTransaction(); //dbConn.BeginTransaction();

                DataSet dataSet = new DataSet();

                using (IDbCommand dbCmd = CreateCommand())
                {
                    dbCmd.Transaction = dbTrans;
                    dbCmd.CommandType = cmdType;
                    dbCmd.CommandText = QueryOrProcedure;
                    if (null != parameters)
                    {
                        IEnumerator keys = parameters.Keys.GetEnumerator();
                        while (keys.MoveNext())
                        {
                            IDataParameter dbParam = CreateParameter(dbCmd);

                            string key = keys.Current.ToString();
                            if (String.IsNullOrWhiteSpace(key))
                                throw new Exception("Parameter name could not be empty or null.");

                            dbParam.ParameterName = keys.Current.ToString();
                            dbParam.Value = parameters[keys.Current];
                            dbCmd.Parameters.Add(dbParam);
                        }
                    }

                    IDbDataAdapter dbAdapter = CreateAdapter(dbCmd);

                    dbAdapter.Fill(dataSet);
                    dbCmd.Parameters.Clear();
                }
                CommitTransaction();
                CloseConnection();

                return dataSet;
            }
            catch (Exception exc)
            {
                RollbackTransaction();
                CloseConnection();
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
                OpenConnection();
                CreateTransaction();

                Int32 returnInt;

                using (IDbCommand dbCmd = CreateCommand())
                {
                    dbCmd.Transaction = dbTrans;
                    dbCmd.CommandType = cmdType;
                    dbCmd.CommandText = QueryOrProcedure;
                    if (null != parameters)
                    {
                        IEnumerator keys = parameters.Keys.GetEnumerator();
                        while (keys.MoveNext())
                        {
                            IDataParameter dbParam = CreateParameter(dbCmd);

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
                }
                CommitTransaction();
                CloseConnection();

                return returnInt;
            }
            catch (Exception exc)
            {
                RollbackTransaction();
                CloseConnection();
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
                OpenConnection();
                CreateTransaction();

                object returnObj;

                using (IDbCommand dbCmd = CreateCommand())
                {
                    dbCmd.Transaction = dbTrans;
                    dbCmd.CommandType = cmdType;
                    dbCmd.CommandText = QueryOrProcedure;
                    if (null != parameters)
                    {
                        IEnumerator keys = parameters.Keys.GetEnumerator();
                        while (keys.MoveNext())
                        {
                            IDataParameter dbParam = CreateParameter(dbCmd);

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
                }
                CommitTransaction();
                CloseConnection();

                return returnObj;
            }
            catch (Exception exc)
            {
                RollbackTransaction();
                CloseConnection();
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
                CreateTransaction();

                IDataReader retDataReader;

                using (IDbCommand dbCmd = CreateCommand())
                {
                    dbCmd.Transaction = dbTrans;
                    dbCmd.CommandType = cmdType;
                    dbCmd.CommandText = QueryOrProcedure;

                    if (null != parameters)
                    {
                        IEnumerator keys = parameters.Keys.GetEnumerator();
                        while (keys.MoveNext())
                        {
                            IDataParameter dbParam = CreateParameter(dbCmd);

                            string key = keys.Current.ToString();
                            if (String.IsNullOrWhiteSpace(key))
                                throw new Exception("Parameter name could not be empty or null.");

                            dbParam.ParameterName = keys.Current.ToString();
                            dbParam.Value = parameters[keys.Current];
                            dbCmd.Parameters.Add(dbParam);
                        }
                    }

                    retDataReader = dbCmd.ExecuteReader();

                    dbCmd.Parameters.Clear();
                }
                CommitTransaction();
                CloseConnection();

                return retDataReader;
            }
            catch (Exception exc)
            {
                RollbackTransaction();
                CloseConnection();
                throw exc;
            }
        }

        #endregion


        #region [ Dispose Method ]

        /// <summary>
        /// Disposes Connection object.
        /// </summary>
        public void Dispose()
        {
            if (null != dbConn)
            {
                if (dbConn.State != ConnectionState.Closed)
                    dbConn.Close();
            }

            dbConn.Dispose();
            GC.Collect(0, GCCollectionMode.Optimized);
        }

        #endregion


        #region [ Create Connection with Connection Type]
        /// <summary>
        /// Returns a IDbConnection object instance.
        /// </summary>
        /// <param name="conType">Connection Type</param>
        /// <returns>Returns a IDbConnection object instance.</returns>
        public IDbConnection CreateConnection()
        {
            try
            {
                switch (_ConnType)
                {
                    case ConnectionTypes.SqlExpress:
                    case ConnectionTypes.SqlServer:
                        return new SqlConnection();

                    case ConnectionTypes.PostgreSQL:
                        return new NpgsqlConnection();
                    //throw new NotSupportedException("PostgreSQL Driver is not supported.");

                    case ConnectionTypes.DB2:
                        throw new NotSupportedException("DB2 Driver is not supported.");

                    case ConnectionTypes.OleDb:
                        return new OleDbConnection();

                    case ConnectionTypes.FireBird:
                        return new FbConnection();
                    //throw new NotSupportedException("FireBirdSQL Driver is not supported.");

                    case ConnectionTypes.Oracle:
                        //return new OracleConnection();
                        throw new NotSupportedException("Oracle Driver is not supported.");

                    case ConnectionTypes.SQLite:
                        // return new SQLiteConnection();
                        throw new NotSupportedException("SQLite Driver is not supported.");

                    case ConnectionTypes.MariaDB:
                    case ConnectionTypes.MySQL:
                        return new MySqlConnection();
                    //throw new NotSupportedException("MySQL Driver is not supported.");

                    case ConnectionTypes.VistaDB:
                        return new VistaDBConnection();
                    //throw new NotSupportedException("VistaDB Driver is not supported.");

                    case ConnectionTypes.SqlServerCe:
                        return new SqlCeConnection();
                    //throw new NotSupportedException("SqlServerCe Driver is not supported.");

                    //Buraya External XML File kısmı eklenecek.
                    case ConnectionTypes.External:
                        throw new NotSupportedException("External Driver is not supported.");

                    default:
                        throw new NotSupportedException("UnSupported Driver Type");
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion


        #region [ Create Transaction for IDbConnection ]

        public void CreateTransaction()
        {
            try
            {
                if (dbConn.State != ConnectionState.Open)
                {
                    dbConn.Open();
                }

                dbTrans = dbConn.BeginTransaction();
            }
            catch (Exception exc)
            { throw exc; }
        }

        #endregion


        #region [ Creates IDbCommand  with IDbConnection ]

        public IDbCommand CreateCommand()
        {
            try
            {
                return dbConn.CreateCommand();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Create IDbParameter with IDbCommand ]

        public IDbDataParameter CreateParameter(IDbCommand dbCmd)
        {
            try
            {
                return dbCmd.CreateParameter();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Create Data Adapter with Connection Type]
        /// <summary>
        /// Returns a IDataAdapter object instance.
        /// </summary>
        /// <param name="conType">Connection Type</param>
        /// <returns>Returns a IDataAdapter object instance.</returns>
        public IDbDataAdapter CreateAdapter(IDbCommand dbCmd)
        {
            try
            {
                switch (_ConnType)
                {
                    case ConnectionTypes.SqlExpress:
                    case ConnectionTypes.SqlServer:
                        return new SqlDataAdapter((SqlCommand)dbCmd);

                    case ConnectionTypes.PostgreSQL:
                        return new NpgsqlDataAdapter((NpgsqlCommand)dbCmd);
                    //throw new NotSupportedException("Npgsql Driver is not supported.");

                    case ConnectionTypes.DB2:
                        throw new NotSupportedException("DB2 Driver is not supported.");

                    case ConnectionTypes.Oracle:
                        //    return new OracleDataAdapter((OracleCommand)dbCmd);
                        throw new NotSupportedException("Oracle Driver is not supported.");

                    case ConnectionTypes.MariaDB:
                    case ConnectionTypes.MySQL:
                        return new MySqlDataAdapter((MySqlCommand)dbCmd);
                    //throw new NotSupportedException("MySQL Driver is not supported.");

                    case ConnectionTypes.OleDb:
                        return new OleDbDataAdapter((OleDbCommand)dbCmd);

                    case ConnectionTypes.SQLite:
                        // return new SQLiteDataAdapter((SQLiteCommand)dbCmd);
                        throw new NotSupportedException("SQLite Driver is not supported.");

                    case ConnectionTypes.FireBird:
                        return new FbDataAdapter((FbCommand)dbCmd);
                    //throw new NotSupportedException("FireBirdSQL Driver is not supported.");

                    case ConnectionTypes.VistaDB:
                        return new VistaDBDataAdapter((VistaDBCommand)dbCmd);
                    //throw new NotSupportedException("VistaDB Driver is not supported.");

                    case ConnectionTypes.SqlServerCe:
                        return new SqlCeDataAdapter((SqlCeCommand)dbCmd);
                    //throw new NotSupportedException("SqlServerCe Driver is not supported.");

                    default:
                        throw new NotSupportedException("UnSupported Driver Type");
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion


        #region [ Commit And Dispose Transaction ]

        public void CommitTransaction()
        {
            try
            {
                if (dbTrans != null)
                {
                    dbTrans.Commit();
                    dbTrans.Dispose();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Rollback And Dispose Transaction ]

        public void RollbackTransaction()
        {
            try
            {
                if (dbTrans != null)
                {
                    dbTrans.Rollback();
                    dbTrans.Dispose();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Open Connection ]

        public void OpenConnection()
        {
            try
            {
                if (dbConn.State != ConnectionState.Open)
                {
                    dbConn.Open();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Close Connection ]

        public void CloseConnection()
        {
            try
            {
                if (dbConn.State != ConnectionState.Closed)
                {
                    dbConn.Close();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Get Connection State ]

        public ConnectionState GetConnectionState()
        {
            return dbConn.State;
        }

        #endregion

    }
}
