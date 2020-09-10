namespace Mst.Data.QueryBuilding
{
    public interface IBaseOperations
    {
        int Insert();

        int InsertAndGetId();

        int Delete();

        int Update();

    }
}
