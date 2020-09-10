using Mst.Data.DbConnection;

namespace Mst.Data.Management
{
    /// <summary>
    /// MsSQL Manager for Sql Operations.
    /// </summary>
    public class MsSQLManager : DbManager
    {
        /// <summary>
        /// MsSQL Database Manager Constructor with Empty Connection String.
        /// </summary>
        public MsSQLManager()
            : base()
        { }

        /// <summary>
        /// MsSQL Database Manager Constructor.
        /// </summary>
        /// <param name="connectionstring">MsSQL Connection String</param>
        public MsSQLManager(string connectionstring)
            : base(ConnectionTypes.SqlServer, connectionstring)
        { }
    }
}
