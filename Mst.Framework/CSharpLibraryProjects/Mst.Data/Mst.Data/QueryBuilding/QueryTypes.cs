namespace Mst.Data.QueryBuilding
{
    public enum QueryTypes : byte
    {
        Select = 1,
        Insert = 2,
        Update = 3,
        Delete = 4,
        InsertAndGetId = 5,
        SelectWhere = 6,
        SelectWithFilter = 7,
        SelectChangingColumns = 8
    };
}
