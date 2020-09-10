namespace Mst.Data.QueryBuilding
{
    using Mst.Data.Management;
    using System.Data;

    public interface IBaseDL
    {
        int Insert();

        int InsertAndGetId();

        int Update();

        int Delete();

        IDbManager Manager { get; }

    }
}
