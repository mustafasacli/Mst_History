using Mst.Data.DbConnection;

namespace Mst.Data.Management
{
    /// <summary>
    /// SQLite Database Manager for SQLite Operations.
    /// </summary>
    public class SQLiteManager : DbManager
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
