namespace Mst.Data.Management
{
    using Mst.Data.DBConnection;

    /// <summary>
    /// SQLite Database Manager for SQLite Operations.
    /// </summary>
    public sealed class SQLiteManager : DbManager
    {
        /// <summary>
        /// SQLite Database Manager Constructor with Empty Connection String.
        /// </summary>
        public SQLiteManager() : base(ConnectionTypes.SQLite) { }

        /// <summary>
        /// SQLite Database Manager Constructor.
        /// </summary>
        /// <param name="connectionString">SQLite Connection String</param>
        public SQLiteManager(string connectionString) :
            base(ConnectionTypes.SQLite, connectionString) { }
    }
}
