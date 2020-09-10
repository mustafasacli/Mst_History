namespace Mst.Data.QueryBuilding
{
    using Mst.Data.Management;
    using System.Collections.Generic;
    using System.Data;

    public interface IBaseBO : IBaseOperations
    {
        string GetTable();

        string GetIdColumn();

        List<string> GetColumnChangeList();

        void AddChangeList(string column);
    }
}
