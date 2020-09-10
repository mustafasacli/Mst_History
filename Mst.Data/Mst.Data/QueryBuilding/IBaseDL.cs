namespace Mst.Data.QueryBuilding
{
    using Mst.Data.Management;
    using System.Data;

    public interface IBaseDL : IBaseOperations
    {

        IDbManager Manager { get; }

    }
}
