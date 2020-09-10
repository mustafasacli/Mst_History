namespace Mst.Data.QueryBuilding
{
    using Mst.Data.Management;
    using System.Collections.Generic;
    using System.Data;

    public interface IBaseBO
    {
        string GetTable();

        string GetIdColumn();

        int Insert();

        int InsertAndGetId();

        int Delete();

        int Update();

        List<string> GetColumnChangeList();

        void AddChangeList(string column);
    }
}
