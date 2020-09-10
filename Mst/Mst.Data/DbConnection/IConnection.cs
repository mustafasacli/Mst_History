using System;
using System.Collections;
using System.Data;

namespace Mst.Data.DbConnection
{
    interface IConnection
    {
        ConnectionTypes ConnectionType { get; set; }
        String ConnectionString { get; set; }

        DataSet GetResultSet(CommandType cmdType, String QueryOrProcedure);

        DataSet GetResultSet(CommandType cmdType, String QueryOrProcedure, Hashtable hashatble);

        Int32 ExecuteQuery(CommandType cmdType, String QueryOrProcedure);

        Int32 ExecuteQuery(CommandType cmdType, String QueryOrProcedure, Hashtable hashtable);

        Object ExecuteScalar(CommandType cmdType, String QueryOrProcedure);

        Object ExecuteScalar(CommandType cmdType, String QueryOrProcedure, Hashtable hashtable);

        IDataReader ExecuteReader(CommandType cmdType, String QueryOrProcedure);

        IDataReader ExecuteReader(CommandType cmdType, String QueryOrProcedure, Hashtable hashtable);

    }
}
