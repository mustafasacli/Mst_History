using Mst.Data.DbConnection;

namespace Mst.Data.Management
{
    /// <summary>
    /// MySQL Database Manager for MySQL Operations.
    /// </summary>
    public class MySQLManager : DbManager
    {
        /// <summary>
        /// MySQL Database Manager Constructor with Empty Connection String.
        /// </summary>
        public MySQLManager() : base(ConnectionTypes.MySQL) { }

        /// <summary>
        /// MySQL Database Manager Constructor.
        /// </summary>
        /// <param name="connectionString">MySQL Connection String</param>
        public MySQLManager(string connectionString) :
            base(ConnectionTypes.MySQL, connectionString) { }
    }
}
