namespace Mst.Data.Management
{
    using Mst.Data.DBConnection;
    using Mst.Data.QueryBuilding;
    using System;
    using System.Collections;
    using System.Data;

    /// <summary>
    /// Interface for defining manager operations.
    /// </summary>
    public interface IDbManager
    {
        int Insert(IBaseBO baseBO);

        int InsertAndGetId(IBaseBO baseBO);

        int Update(IBaseBO baseBO);

        int Delete(IBaseBO baseBO);

        QueryBuilder CreateQueryBuilder(QueryTypes queryType, IBaseBO tableObject);

        ConnectionTypes ConnectionType { get; }

        DataSet GetResultSetOfProcedure(string Procedure);

        DataSet GetResultSetOfProcedure(string Procedure, Hashtable parameters);

        DataSet GetResultSetOfQuery(String Query);

        DataSet GetResultSetOfQuery(String Query, Hashtable parameters);

        Int32 ExecuteProcedure(string Procedure);

        Int32 ExecuteProcedure(string Procedure, Hashtable parameters);

        Int32 ExecuteQuery(string Query, Hashtable parameters);

        Int32 ExecuteQuery(string Query);

        Object ExecuteScalarProcedure(String Procedure, Hashtable parameters);

        Object ExecuteScalarProcedure(String Procedure);

        Object ExecuteScalarQuery(String Query, Hashtable parameters);

        Object ExecuteScalarQuery(String Query);

        IDataReader ExecuteReaderProcedure(String Procedure, Hashtable parameters);

        IDataReader ExecuteReaderProcedure(String Procedure);

        IDataReader ExecuteReaderQuery(String Query, Hashtable parameters);

        IDataReader ExecuteReaderQuery(String Query);

    }
}
