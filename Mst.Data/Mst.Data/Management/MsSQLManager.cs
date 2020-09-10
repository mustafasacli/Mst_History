namespace Mst.Data.Management
{
    using Mst.Data.DBConnection;

    /// <summary>
    /// MsSQL Manager for Sql Operations.
    /// </summary>
    public sealed class MsSQLManager : DbManager
    {
        /// <summary>
        /// MsSQL Database Manager Constructor with Empty Connection String.
        /// </summary>
        public MsSQLManager()
            : base(ConnectionTypes.SqlServer)
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
