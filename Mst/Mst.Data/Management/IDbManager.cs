using Mst.Data.DbConnection;
using System;
using System.Collections;
using System.Data;

namespace Mst.Data.Management
{
    /// <summary>
    /// Interface for defining manager operations.
    /// </summary>
    interface IDbManager
    {
        
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
