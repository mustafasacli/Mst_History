using Mst.Data.DbConnection;

namespace Mst.Data.Management
{
    /// <summary>
    /// Oracle Database Manager for Oracle Operations.
    /// </summary>
    public class OracleManager : DbManager
    {
        /// <summary>
        ///  Oracle Database Manager Constructor with Empty Connection String.
        /// </summary>
        public OracleManager() : base(ConnectionTypes.Oracle) { }

        /// <summary>
        /// Oracle Database Manager Constructor.
        /// </summary>
        /// <param name="connectionString">Oracle Connection String</param>
        public OracleManager(string connectionString) :
            base(ConnectionTypes.Oracle, connectionString) { }

    }
}
