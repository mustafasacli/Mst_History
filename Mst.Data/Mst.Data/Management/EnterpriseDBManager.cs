namespace Mst.Data.Management
{
    using Mst.Data.DBConnection;

    /// <summary>
    /// EnterpriseDB Database Manager for PostgreSQL Operations.
    /// </summary>
    public sealed class EnterpriseDBManager : DbManager
    {
        /// <summary>
        /// EnterpriseDB Database Manager Constructor with Empty Connection String.
        /// </summary>
        public EnterpriseDBManager()
            : base(ConnectionTypes.PostgreSQL)
        { }

        /// <summary>
        /// EnterpriseDB Database Manager Constructor.
        /// </summary>
        /// <param name="connectionString">EnterpriseDB Connection String</param>
        public EnterpriseDBManager(string connectionString)
            : base(ConnectionTypes.PostgreSQL, connectionString)
        { }

    }
}
