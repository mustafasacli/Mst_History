namespace Mst.Data.DBConnection
{

    using System;
    using System.Collections;
    using System.Data;

    interface IConnection
    {
        ConnectionTypes ConnectionType { get; set; }
        String ConnectionString { get; set; }

        DataSet GetResultSet(CommandType cmdType, String QueryOrProcedure);

        DataSet GetResultSet(CommandType cmdType, String QueryOrProcedure, Hashtable parameters);

        Int32 ExecuteQuery(CommandType cmdType, String QueryOrProcedure);

        Int32 ExecuteQuery(CommandType cmdType, String QueryOrProcedure, Hashtable parameters);

        Object ExecuteScalar(CommandType cmdType, String QueryOrProcedure);

        Object ExecuteScalar(CommandType cmdType, String QueryOrProcedure, Hashtable parameters);

        IDataReader ExecuteReader(CommandType cmdType, String QueryOrProcedure);

        IDataReader ExecuteReader(CommandType cmdType, String QueryOrProcedure, Hashtable parameters);

    }
}
