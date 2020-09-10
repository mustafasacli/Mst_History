namespace Mst.Data.Management
{
    using System;
    using System.Data;
    using System.Collections;
    using Mst.Data.DBConnection;
    using Mst.Data.QueryBuilding;
    using System.Reflection;

    /// <summary>
    /// General Database Manager for Database Operations.
    /// </summary>
    public class DbManager : IDbManager
    {
        /// <summary>
        /// DbManager Constructor with Empty Connection String and SqlServer ConnectionType.
        /// </summary>
        public DbManager()
            : this(ConnectionTypes.SqlServer, string.Empty)
        { }

        /// <summary>
        ///  DbManager Constructor with  SqlServer ConnectionType.
        /// </summary>
        /// <param name="connectionString"> Database Connection string.</param>
        public DbManager(string connectionString)
            : this(ConnectionTypes.SqlServer,
            connectionString)
        { }

        /// <summary>
        /// DbManager Constructor  with Empty Connection string.
        /// </summary>
        /// <param name="ConnType">Connection Type</param>
        public DbManager(ConnectionTypes ConnType)
            : this(ConnType, string.Empty)
        { }

        /// <summary>
        /// DbManager Constructor
        /// </summary>
        /// <param name="ConnType">Connection Type</param>
        /// <param name="ConnectionString">Connection String</param>
        public DbManager(ConnectionTypes ConnType, String ConnectionString)
        {
            _ConnStr = ConnectionString;
            _ConType = ConnType;
        }

        private string _ConnStr;
        /// <summary>
        /// Get And Set Connection String of Manager.
        /// </summary>       
        public String ConnectionString
        {
            set
            {
                _ConnStr = value;
            }
            get
            {
                return _ConnStr;
            }
        }

        private ConnectionTypes _ConType;
        /// <summary>
        /// Gets Connection Type Of Manager.
        /// </summary>
        public ConnectionTypes ConnectionType
        {
            get
            { return _ConType; }
        }


        /// <summary>
        /// Returns A DataSet with given Procedure Name without any parameter
        /// </summary>
        /// <param name="Procedure">Procedure Name</param>
        /// <returns>Returns A DataSet with given Procedure Name without any parameter</returns>
        public DataSet GetResultSetOfProcedure(string Procedure)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.GetResultSet(CommandType.StoredProcedure, Procedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


        /// <summary>
        /// Returns A DataSet with given Procedure Name and parameters
        /// </summary>
        /// <param name="Procedure">Procedure Name</param>
        /// <param name="parameters">Hashtable contains parameters and values</param>
        /// <returns>Returns A DataSet with given Procedure Name and parameters</returns>
        public DataSet GetResultSetOfProcedure(string Procedure, Hashtable parameters)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.GetResultSet(CommandType.StoredProcedure, Procedure, parameters);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Returns A DataSet with given Query without any parameter
        /// </summary>
        /// <param name="Query">Sql Query</param>
        /// <returns>Returns A DataSet with given Query without any parameter</returns>
        public DataSet GetResultSetOfQuery(string Query)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.GetResultSet(CommandType.Text, Query);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


        /// <summary>
        /// Returns A DataSet with given Query and parameters
        /// </summary>
        /// <param name="Query">Sql Query</param>
        /// <param name="parameters">Hashtable contains parameters and values</param>
        /// <returns>Returns A DataSet with given Query and parameters</returns>
        public DataSet GetResultSetOfQuery(string Query, Hashtable parameters)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.GetResultSet(CommandType.Text, Query, parameters);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Executes Procedure without any parameter
        /// </summary>
        /// <param name="Procedure">Procedure Name</param>
        /// <returns>Returns Execution Result</returns>
        public int ExecuteProcedure(string Procedure)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteQuery(CommandType.StoredProcedure, Procedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


        /// <summary>
        /// Executes Procedure with given parameters
        /// </summary>
        /// <param name="Procedure">Procedure Name</param>
        /// <param name="parameters">Hashtable contains parameters and values</param>
        /// <returns>Returns Execution Result</returns>
        public int ExecuteProcedure(string Procedure, Hashtable parameters)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteQuery(CommandType.StoredProcedure, Procedure, parameters);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }



        /// <summary>
        /// Executes SQL Query with given parameters
        /// </summary>
        /// <param name="Query">Sql Query</param>
        /// <param name="parameters">Hashtable contains parameters and values</param>
        /// <returns>Returns Execution Result</returns>
        public int ExecuteQuery(string Query, Hashtable parameters)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteQuery(CommandType.Text, Query, parameters);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


        /// <summary>
        /// Executes SQL Query without any parameter
        /// </summary>
        /// <param name="Query">Sql Query</param>
        /// <returns>Returns Execution Result</returns>
        public int ExecuteQuery(string Query)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteQuery(CommandType.Text, Query);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


        /// <summary>
        /// ExecuteScalar  Method for Procedure with given parameters
        /// </summary>
        /// <param name="Procedure">Procedure Name</param>
        /// <param name="parameters">Hashtable contains parameters and values</param>
        /// <returns>Returns object Result of ExecuteScalar Query</returns>
        public object ExecuteScalarProcedure(string Procedure, System.Collections.Hashtable parameters)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteScalar(CommandType.StoredProcedure, Procedure, parameters);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// ExecuteScalar  Method for Procedure without any parameter
        /// </summary>
        /// <param name="Procedure">Procedure Name</param>
        /// <returns>Returns object Result of ExecuteScalar Procedure</returns>
        public object ExecuteScalarProcedure(string Procedure)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteScalar(CommandType.StoredProcedure, Procedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


        /// <summary>
        /// ExecuteScalar  Method for Query with given parameters
        /// </summary>
        /// <param name="Query">Sql Query</param>
        /// <param name="parameters">Hashtable contains parameters and values</param>
        /// <returns>Returns object Result of ExecuteScalar Query and parameters </returns>
        public object ExecuteScalarQuery(string Query, Hashtable parameters)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteScalar(CommandType.Text, Query, parameters);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// ExecuteScalar  Method for Query without any parameter
        /// </summary>
        /// <param name="Query">Sql Query</param>
        /// <returns>ExecuteScalar  Method for Query without any parameter</returns>
        public object ExecuteScalarQuery(string Query)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteScalar(CommandType.Text, Query);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// ExecuteReader Method for Procedure with given parameters
        /// </summary>
        /// <param name="Procedure">Procedure Name</param>
        /// <param name="parameters">hashtable contains parameters and values</param>
        /// <returns> Returns an Object type of IDataReader</returns>
        public IDataReader ExecuteReaderProcedure(string Procedure, Hashtable parameters)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteReader(CommandType.StoredProcedure, Procedure, parameters);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// ExecuteReader Method for Procedure without any parameter
        /// </summary>
        /// <param name="Procedure">Procedure Name</param>
        /// <returns>Returns an IDataReader object </returns>
        public IDataReader ExecuteReaderProcedure(string Procedure)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteReader(CommandType.StoredProcedure, Procedure);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// ExecuteReader Method for Procedure with given parameters
        /// </summary>
        /// <param name="Query">Sql Query</param>
        /// <param name="parameters">Hashtable contains parameter and values.</param>
        /// <returns>Returns an IDataReader object</returns>
        public IDataReader ExecuteReaderQuery(string Query, Hashtable parameters)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteReader(CommandType.Text, Query, parameters);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// ExecuteReader Method for Query without any parameter.
        /// </summary>
        /// <param name="Query">Sql Query</param>
        /// <returns>Returns an IDataReader object</returns>
        public IDataReader ExecuteReaderQuery(string Query)
        {
            try
            {
                using (Connection dbConn = new Connection(_ConType, _ConnStr))
                {
                    return dbConn.ExecuteReader(CommandType.Text, Query);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Create A QueryBuilder object with ConnectionType Of Connection and given querytype and AbstractBaseBo object.
        /// </summary>
        /// <param name="queryType">QueryType Of QueryBuilder</param>
        /// <param name="tableObject">Table class object.</param>
        /// <returns>Returns A QueryBuilder object with ConnectionType Of Connection and given querytype and AbstractBaseBo object.</returns>
        public QueryBuilder CreateQueryBuilder(QueryTypes queryType, IBaseBO tableObject)
        {
            return new QueryBuilder(_ConType, queryType, tableObject);
        }

        public int Insert(IBaseBO baseBO)
        {
            try
            {
                QueryBuilder queryBuilder =
                     CreateQueryBuilder(QueryTypes.Insert, baseBO);

                return ExecuteQuery(queryBuilder.QueryString,
                    queryBuilder.QueryParameters);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int InsertAndGetId(IBaseBO baseBO)
        {
            try
            {
                QueryBuilder queryBuilder =
                     CreateQueryBuilder(QueryTypes.InsertAndGetId, baseBO);

                return Convert.ToInt32(ExecuteScalarQuery(queryBuilder.QueryString,
                    queryBuilder.QueryParameters));
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int Update(IBaseBO baseBO)
        {
            try
            {
                QueryBuilder queryBuilder =
                    CreateQueryBuilder(QueryTypes.Update, baseBO);

                return ExecuteQuery(queryBuilder.QueryString,
                    queryBuilder.QueryParameters);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int Delete(IBaseBO baseBO)
        {
            try
            {
                QueryBuilder queryBuilder =
                    CreateQueryBuilder(QueryTypes.Delete, baseBO);

                return ExecuteQuery(queryBuilder.QueryString,
                    queryBuilder.QueryParameters);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }       
    }
}
