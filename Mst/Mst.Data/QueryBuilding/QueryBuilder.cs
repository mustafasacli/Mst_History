using Mst.Data.DbConnection;
using System;
using System.Collections;
using System.Reflection;

namespace Mst.Data.QueryBuilding
{
    public class QueryBuilder : IQueryBuilder
    {

        public QueryBuilder()
            : this(ConnectionTypes.SqlServer, QueryTypes.Select, null)
        { }

        public QueryBuilder(QueryTypes queryType)
            : this(ConnectionTypes.SqlServer, queryType, null)
        { }

        public QueryBuilder(ConnectionTypes ConnType, QueryTypes queryType, Object queryObject)
        {
            _queryObject = queryObject;
            _queryType = queryType;
            _queryString = GetQueryString();
            _parameters = GetParameters();
        }

        private object _queryObject = null;
        public object QueryObject
        {
            get
            {
                return _queryObject;
            }
            set
            {
                _queryObject = value;
            }
        }

        private QueryTypes _queryType;
        public QueryTypes QueryType
        {
            get
            {
                return _queryType;
            }
            set
            {
                _queryType = value;
            }
        }

        private Hashtable GetParameters()
        {
            if (object.ReferenceEquals(_queryObject.GetType(), typeof(AbstractTable)))
            {
                AbstractTable table = (_queryObject as AbstractTable);
                TypeAttributes attrs = table.GetType().Attributes;

                PropertyInfo[] props = table.GetType().GetProperties();
                foreach (var item in props)
                {

                }
                return null;
            }
            else
                throw new InvalidOperationException("Table Object must be inherited from AbstractTable object.");
        }

        private string GetQueryString()
        {
            if (object.ReferenceEquals(_queryObject.GetType(), typeof(ITable)))
            {
                ITable table = (_queryObject as ITable);
                PropertyInfo[] props = table.GetType().GetProperties();
                foreach (var item in props)
                {

                }
                return string.Empty;
            }
            else
                throw new InvalidOperationException("Table Object must be inherited from ITable object.");
        }

        private string QueryFormat(QueryTypes queryType)
        {
            switch (queryType)
            {
                case QueryTypes.Select:
                    return "Select {0} From {1} Where {2};";
                case QueryTypes.Insert:
                    return "Insert Into {0}({1}) Values({2})";
                case QueryTypes.Update:
                    return "Update {0} Set {1} Where {2}";
                case QueryTypes.Delete:
                    return "Delete From {0} Where {1}";
                case QueryTypes.Create:
                    return "Create Table {0}{1}{2}({3});";
                case QueryTypes.Drop:
                    return "Drop Table {0};";
                default:
                    throw new InvalidOperationException("Onknown Query Type");
            }
        }

        private string GetPrefix(ConnectionTypes ConnType)
        {
            string _prefix = "";
            switch (ConnType)
            {
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                    _prefix = "[";
                    break;
                case ConnectionTypes.Oracle:
                case ConnectionTypes.MySQL:
                    _prefix = "'";
                    break;

                /*
                 * 
                   case ConnectionTypes.DB2:
                    break;case ConnectionTypes.EnterpriseDB:
                    break;
                case ConnectionTypes.OleDb:
                    break;
                case ConnectionTypes.SQLite:
                    break;
                case ConnectionTypes.FireBird:
                    break;
                 */
                default:
                    break;
            }
            return _prefix;
        }


        private string Getsuffix(ConnectionTypes ConnType)
        {
            string _suffix = "";
            switch (ConnType)
            {
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                    _suffix = "]";
                    break;
                case ConnectionTypes.Oracle:
                case ConnectionTypes.MySQL:
                    _suffix = "'";
                    break;

                /*
                 * 
                   case ConnectionTypes.DB2:
                    break;case ConnectionTypes.EnterpriseDB:
                    break;
                case ConnectionTypes.OleDb:
                    break;
                case ConnectionTypes.SQLite:
                    break;
                case ConnectionTypes.FireBird:
                    break;
                 */
                default:
                    break;
            }
            return _suffix;
        }




        private Hashtable _parameters = new Hashtable();
        public Hashtable QueryParameters
        {
            get
            {
                return _parameters;
            }
        }

        private string _queryString = string.Empty;
        public string QueryString
        {
            get
            {
                return GetQueryString();
            }
        }


        public override string ToString()
        {
            return QueryString;
        }

    }
}
