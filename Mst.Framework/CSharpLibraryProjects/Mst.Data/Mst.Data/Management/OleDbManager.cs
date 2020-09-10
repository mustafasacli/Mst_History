namespace Mst.Data.Management
{
    using Mst.Data.DBConnection;

    /// <summary>
    /// OleDb Manager for OleDb Operations.
    /// </summary>
    public sealed class OleDbManager : DbManager
    {
        /// <summary>
        /// OleDb Manager constructor with Empty Connection String.
        /// </summary>
        public OleDbManager() : base(ConnectionTypes.OleDb) { }

        /// <summary>
        /// OleDb Manager Constructor.
        /// </summary>
        /// <param name="connectionString">OleDb Connection String.</param>
        public OleDbManager(string connectionString) :
            base(ConnectionTypes.OleDb, connectionString) { }
    }
}
