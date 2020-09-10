using System;
using System.Collections;

namespace Mst.Data.QueryBuilding
{
    public interface IQueryBuilder
    {

        Object QueryObject { get; set; }

        QueryTypes QueryType { get; set; }

        Hashtable QueryParameters { get; }

        String QueryString { get; }

    }
}
