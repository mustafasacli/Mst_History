namespace Mst.Data.DBConnection
{

    using FirebirdSql.Data.FirebirdClient;
    using MySql.Data.MySqlClient;
    using Npgsql;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using VistaDB.Provider;

    public class ConnectionObject
    {

        #region [Get Connection with Connection Type]
        /// <summary>
        /// Returns a IDbConnection object instance.
        /// </summary>
        /// <param name="conType">Connection Type</param>
        /// <returns>Returns a IDbConnection object instance.</returns>
        public static IDbConnection GetConnection(ConnectionTypes conType)
        {
            try
            {
                switch (conType)
                {
                    case ConnectionTypes.SqlExpress:
                    case ConnectionTypes.SqlServer:
                        return new SqlConnection();

                    case ConnectionTypes.PostgreSQL:
                        return new NpgsqlConnection();
                    //throw new NotSupportedException("PostgreSQL Driver is not supported.");

                    case ConnectionTypes.DB2:
                        throw new NotSupportedException("DB2 Driver is not supported.");

                    case ConnectionTypes.OleDb:
                        return new OleDbConnection();

                    case ConnectionTypes.FireBird:
                        return new FbConnection();
                    //throw new NotSupportedException("FireBirdSQL Driver is not supported.");

                    case ConnectionTypes.Oracle:
                        return new OracleConnection();
                    //throw new NotSupportedException("Oracle Driver is not supported.");

                    case ConnectionTypes.SQLite:
                        return new SQLiteConnection();
                    //throw new NotSupportedException("SQLite Driver is not supported.");

                    case ConnectionTypes.MariaDB:
                    case ConnectionTypes.MySQL:
                        return new MySqlConnection();
                    //throw new NotSupportedException("MySQL Driver is not supported.");

                    case ConnectionTypes.VistaDB:
                        return new VistaDBConnection();
                    //throw new NotSupportedException("VistaDB Driver is not supported.");

                    default:
                        throw new NotSupportedException("UnSupported Driver Type");
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion


        #region [Get Data Adapter with Connection Type]
        /// <summary>
        /// Returns a IDataAdapter object instance.
        /// </summary>
        /// <param name="conType">Connection Type</param>
        /// <returns>Returns a IDataAdapter object instance.</returns>
        public static IDataAdapter GetDataAdapter(ConnectionTypes conType, IDbCommand dbcmd)
        {
            try
            {
                switch (conType)
                {

                    case ConnectionTypes.SqlExpress:
                    case ConnectionTypes.SqlServer:
                        return new SqlDataAdapter((SqlCommand)dbcmd);

                    case ConnectionTypes.PostgreSQL:
                        return new NpgsqlDataAdapter((NpgsqlCommand)dbcmd);
                    //throw new NotSupportedException("Npgsql Driver is not supported.");

                    case ConnectionTypes.DB2:
                        throw new NotSupportedException("DB2 Driver is not supported.");

                    case ConnectionTypes.Oracle:
                        return new OracleDataAdapter((OracleCommand)dbcmd);
                    //   throw new NotSupportedException("Oracle Driver is not supported."); 

                    case ConnectionTypes.MariaDB:
                    case ConnectionTypes.MySQL:
                        return new MySqlDataAdapter((MySqlCommand)dbcmd);
                    //throw new NotSupportedException("MySQL Driver is not supported.");

                    case ConnectionTypes.OleDb:
                        return new OleDbDataAdapter((OleDbCommand)dbcmd);

                    case ConnectionTypes.SQLite:
                        return new SQLiteDataAdapter((SQLiteCommand)dbcmd);
                    //throw new NotSupportedException("SQLite Driver is not supported.");

                    case ConnectionTypes.FireBird:
                        return new FbDataAdapter((FbCommand)dbcmd);
                    //throw new NotSupportedException("FireBirdSQL Driver is not supported.");

                    case ConnectionTypes.VistaDB:
                        return new VistaDBDataAdapter((VistaDBCommand)dbcmd);
                    //throw new NotSupportedException("VistaDB Driver is not supported.");

                    default:
                        throw new NotSupportedException("UnSupported Driver Type");
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion
        
    }
}
