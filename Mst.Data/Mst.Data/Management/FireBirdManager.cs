namespace Mst.Data.Management
{
    using Mst.Data.DBConnection;

    /// <summary>
    /// FireBird Manager for Sql Operations.
    /// </summary>
    public sealed class FireBirdManager : DbManager
    {
        /// <summary>
        /// FireBird Database Manager Constructor with Empty Connection String.
        /// </summary>
        public FireBirdManager()
            : base(ConnectionTypes.FireBird)
        { }

        /// <summary>
        /// FireBird Database Manager Constructor.
        /// </summary>
        /// <param name="ConnectionString">FireBird  Connection String</param>
        public FireBirdManager(string ConnectionString)
            : base(ConnectionTypes.FireBird, ConnectionString)
        { }

    }
}
