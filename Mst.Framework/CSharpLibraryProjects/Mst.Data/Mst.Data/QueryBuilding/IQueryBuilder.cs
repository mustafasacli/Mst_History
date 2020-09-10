namespace Mst.Data.QueryBuilding
{
    using Mst.Data.DBConnection;
    using System;
    using System.Collections;

    public interface IQueryBuilder
    {

        Hashtable QueryParameters { get; }

        String QueryString { get; }

    }
}
