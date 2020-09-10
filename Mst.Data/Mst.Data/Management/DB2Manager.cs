namespace Mst.Data.Management
{
    using Mst.Data.DBConnection;

    /// <summary>
    /// DB2 Manager for DB2 Operations.
    /// </summary>
    public sealed class DB2Manager : DbManager
    {
        /// <summary>
        /// DB2  Database Manager Constructor with Empty Connection String.
        /// </summary>
        public DB2Manager()
            : base(ConnectionTypes.DB2)
        { }


        /// <summary>
        /// DB2 Database Manager Constructor.
        /// </summary>
        /// <param name="ConnectionString">DB2 Connection String</param>
        public DB2Manager(string ConnectionString)
            : base(ConnectionTypes.DB2, ConnectionString) { }
    }
}
