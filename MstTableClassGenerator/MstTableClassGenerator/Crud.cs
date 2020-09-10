using Mst.Data.DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MstTableClassGenerator
{
    public class Crud
    {
        public static string GetTablesQuery(ConnectionTypes ConnType)
        {
            switch (ConnType)
            {
                case ConnectionTypes.DB2:
                    break;

                case ConnectionTypes.PostgreSQL:
                    return "select table_name from information_schema.tables where table_schema='public'";

                case ConnectionTypes.FireBird:
                    break;

                case ConnectionTypes.MySQL:
                    return "show tables;";

                case ConnectionTypes.Oracle:
                    break;

                case ConnectionTypes.SQLite:
                    break;

                case ConnectionTypes.OleDb:
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                    return "select name from sys.objects where type='u' order by name;";
                default:
                    break;
            }
            return string.Empty;
        }

        public static string GetColumnsOfTablesQuery(ConnectionTypes ConnType)
        {
            switch (ConnType)
            {
                case ConnectionTypes.DB2:
                    break;

                case ConnectionTypes.PostgreSQL:
                    return "select column_name,udt_name,table_name from information_schema.columns where table_schema='public' and table_name='{0}';";

                case ConnectionTypes.FireBird:
                    break;

                case ConnectionTypes.MySQL:
                    return "show columns From {0};";

                case ConnectionTypes.Oracle:
                    break;

                case ConnectionTypes.SQLite:
                    break;

                case ConnectionTypes.OleDb:
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                    return @"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'";
                default:
                    break;
            }
            return string.Empty;
        }

        public static string GetIdColumnOfTable(ConnectionTypes ConnType)
        {
            switch (ConnType)
            {
                case ConnectionTypes.DB2:
                    break;

                case ConnectionTypes.PostgreSQL:
                    break;

                case ConnectionTypes.FireBird:
                    break;

                case ConnectionTypes.MySQL:
                    return "show columns From {0} where columns.Key='PRI';";

                case ConnectionTypes.Oracle:
                    break;

                case ConnectionTypes.SQLite:
                    break;

                case ConnectionTypes.OleDb:
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                    return @"select COLUMN_NAME
from INFORMATION_SCHEMA.COLUMNS
where COLUMNPROPERTY(object_id(TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1 And
TABLE_NAME='{0}'";

                default:
                    break;
            }
            return string.Empty;
        }
    }
}
