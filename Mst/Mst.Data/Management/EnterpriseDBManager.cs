using Mst.Data.DbConnection;

namespace Mst.Data.Management
{
    /// <summary>
    /// EnterpriseDB Database Manager for PostgreSQL Operations.
    /// </summary>
    public class EnterpriseDBManager : DbManager
    {
        /// <summary>
        /// EnterpriseDB Database Manager Constructor with Empty Connection String.
        /// </summary>
        public EnterpriseDBManager()
            : base(ConnectionTypes.EnterpriseDB)
        { }

        /// <summary>
        /// EnterpriseDB Database Manager Constructor.
        /// </summary>
        /// <param name="connectionString">EnterpriseDB Connection String</param>
        public EnterpriseDBManager(string connectionString)
            : base(ConnectionTypes.EnterpriseDB, connectionString)
        { }

    }
}
