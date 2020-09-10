using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mst.Data.DBConnection;
using Mst.Data.Management;
using System.Data;
using System.Collections;

namespace MstTableClassGenerator
{
    public class TableClassGenerator
    {

        public static string ConnStr = string.Empty;
        public static int Index = -1;
        public List<ClassTable> GetTableList()
        {
            try
            {
                DbManager dbman = GetDbManager(Index);
                dbman.ConnectionString = ConnStr;
                string sqlQuery = Crud.GetTablesQuery(dbman.ConnectionType);

                DataTable dT = dbman.GetResultSetOfQuery(sqlQuery).Tables[0];
                List<ClassTable> classtable = new List<ClassTable>();

                foreach (DataRow row in dT.Rows)
                {
                    classtable.Add(new ClassTable()
                    {
                        TableName = row[0].ToString()
                    });
                }

                return classtable;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<ClassColumn> GetColumnsOfTable(string tableName)
        {
            try
            {
                DbManager dbman = GetDbManager(Index);
                dbman.ConnectionString = ConnStr;
                string sqlQuery = Crud.GetColumnsOfTablesQuery(dbman.ConnectionType);

                DataTable dT = dbman.GetResultSetOfQuery(string.Format(sqlQuery, tableName)).Tables[0];
                List<ClassColumn> columns = new List<ClassColumn>();

                foreach (DataRow row in dT.Rows)
                {
                    columns.Add(
                        new ClassColumn(
                            row[0].ToString(),  // for Column Name
                            row[1].ToString()   // for Column Datatype
                    ));
                }

                return columns;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public string GetIdColumnOfTable(string tableName)
        {
            try
            {
                DbManager dbMan = GetDbManager(Index);
                dbMan.ConnectionString = ConnStr;
                string query = string.Format(Crud.GetIdColumnOfTable(dbMan.ConnectionType), tableName);
                DataTable dtIdCols = dbMan.GetResultSetOfQuery(query).Tables[0];
                string IdColumn = "";
                foreach (DataRow row in dtIdCols.Rows)
                {
                    IdColumn = row[0].ToString(); // IdColumn
                    break;
                }
                return IdColumn;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


        public static DbManager GetDbManager(int index)
        {
            switch (index)
            {
                case 0:
                case 1:
                    return new MsSQLManager();

                case 2:
                    return new EnterpriseDBManager();

                case 3:
                    return new DB2Manager();

                case 4:
                    return new OracleManager();

                case 5:
                    return new MySQLManager();

                case 6:
                    return new OleDbManager();

                case 7:
                    return new SQLiteManager();

                case 8:
                    return new FireBirdManager();

                default:
                    return null;
            }
        }
    }
}
