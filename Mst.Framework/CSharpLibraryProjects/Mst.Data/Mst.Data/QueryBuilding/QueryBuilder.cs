namespace Mst.Data.QueryBuilding
{
    using Mst.Data.DBConnection;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    public class QueryBuilder : IQueryBuilder
    {
        private Hashtable _parameters = new Hashtable();
        private string _queryString = string.Empty;
        private IBaseBO _baseBO;
        QueryTypes _queryType;

        private ConnectionTypes _ConnType;

        public QueryBuilder()
            : this(ConnectionTypes.SqlServer, QueryTypes.Select, null)
        { }

        public QueryBuilder(QueryTypes queryType)
            : this(ConnectionTypes.SqlServer, queryType, null)
        { }

        public QueryBuilder(ConnectionTypes ConnType, QueryTypes queryType,
            IBaseBO queryObject)
        {
            _baseBO = queryObject;
            _queryType = queryType;
            _ConnType = ConnType;
            _queryString = GetQueryString();
            _parameters = GetParameters();
        }


        public Hashtable QueryParameters
        {
            get { return _parameters; }
        }

        public string QueryString
        {
            get { return _queryString; }
        }

        private Hashtable GetParameters()
        {
            Hashtable hash = new Hashtable();
            string paramPrefix = GetParameterPrefix();
            List<string> colList = _baseBO.GetColumnChangeList();
            string idCol = _baseBO.GetIdColumn();
            switch (_queryType)
            {
                /*-- Select And SelectWithFilter Parts --*/
                case QueryTypes.Select:
                case QueryTypes.SelectWithFilter:
                case QueryTypes.SelectChangingColumns:
                    return null;

                /*-- SelectWithFilter Part --*/
                case QueryTypes.InsertAndGetId:
                case QueryTypes.Insert:
                    if (colList.IndexOf(idCol) > -1)
                        colList.Remove(idCol);
                    foreach (string col in colList)
                    {
                        PropertyInfo propInfo4 = _baseBO.GetType().GetProperty(col);
                        hash.Add(string.Format("{0}{1}", paramPrefix, col),
                            propInfo4.GetValue(_baseBO, null));

                    }
                    return hash;

                /*-- Update Part --*/
                case QueryTypes.Update:

                    if (colList.IndexOf(idCol) == -1)
                        colList.Add(idCol);

                    foreach (string col in colList)
                    {
                        PropertyInfo propInfo1 = _baseBO.GetType().GetProperty(col);
                        hash.Add(string.Format("{0}{1}", paramPrefix, col),
                            propInfo1.GetValue(_baseBO, null));
                    }

                    return hash;

                /*-- Delete And SelectWhere Parts --*/
                case QueryTypes.Delete:
                case QueryTypes.SelectWhere:
                    PropertyInfo propInfo3 = _baseBO.GetType().GetProperty(idCol);
                    hash.Add(string.Format("{0}{1}", paramPrefix, idCol),
                        propInfo3.GetValue(_baseBO, null));
                    return hash;

                default:
                    throw new InvalidOperationException("Invalid Query Type");
            }
        }

        private string GetQueryString()
        {
            string _queryFormat = QueryFormat(_queryType);
            switch (_queryType)
            {
                case QueryTypes.Select:
                    return String.Format(_queryFormat
                        , getCompleteTableName());

                case QueryTypes.Insert:
                    return string.Format(_queryFormat,
                        getCompleteTableName(),
                        GetColumnList(false),
                        GetParameterColumnList());

                case QueryTypes.Update:
                    return string.Format(_queryFormat,
                        getCompleteTableName(),
                        getUpdateParameter(),
                        getIdentityParameter());

                case QueryTypes.Delete:
                    return string.Format(_queryFormat,
                        getCompleteTableName(),
                        getIdentityParameter());

                case QueryTypes.InsertAndGetId:
                    return new StringBuilder(
                        string.Format(_queryFormat,
                         getCompleteTableName(),
                         GetColumnList(false),
                         GetParameterColumnList())).
                         AppendLine(GetIdentityInsert()).ToString();

                case QueryTypes.SelectWhere:
                    return String.Format(
                        _queryFormat,
                        getCompleteTableName(),
                        getIdentityParameter());

                case QueryTypes.SelectWithFilter:
                    return string.Format(_queryFormat, getCompleteTableName());

                case QueryTypes.SelectChangingColumns:
                    return string.Format(_queryFormat, GetColumnList(true), getCompleteTableName());

                default:
                    throw new InvalidOperationException("Invalid Query Type.");
            }
        }

        private string QueryFormat(QueryTypes queryType)
        {
            switch (queryType)
            {
                case QueryTypes.Select:
                    return "Select * From {0};";

                case QueryTypes.InsertAndGetId:
                case QueryTypes.Insert:
                    return "Insert Into {0}({1}) Values({2});";

                case QueryTypes.Update:
                    return "Update {0} Set {1} Where {2};";

                case QueryTypes.Delete:
                    return "Delete From {0} Where {1};";

                case QueryTypes.SelectWhere:
                    return "Select * From {0} Where {1};";

                case QueryTypes.SelectWithFilter:
                    return "Select * From {0} Where 1=1 ";

                case QueryTypes.SelectChangingColumns:
                    return "Select {0} From {1};";

                default:
                    break;
            }
            return string.Empty;
        }

        public void AddFilter(string filter)
        {
            if (filter.ToLower().Contains("drop") ||
                filter.ToLower().Contains("delete") ||
                filter.ToLower().Contains("update"))
            {
                throw new InvalidOperationException("Filter can not contain drop, delete or update query.");
            }
            else
            {
                if (_queryType == QueryTypes.SelectWithFilter)
                {
                    _queryString = string.Concat(QueryString, filter);
                }
                else
                {
                    throw new InvalidOperationException("QueryType must be QueryTypes.SelectwithFilter.");
                }
            }
        }

        private string getCompleteTableName()
        {
            if (!string.IsNullOrWhiteSpace(_baseBO.GetTable()))
            {
                string prefix = GetPrefix();
                string suffix = GetSuffix();

                StringBuilder strBuilder = new StringBuilder();

                strBuilder.AppendFormat("{0}{1}{2}", prefix, _baseBO.GetTable(), suffix);

                return strBuilder.ToString();
            }
            else
                throw new InvalidOperationException("Table Name can not be null or empty.");
        }

        private string GetColumnList(bool isAllChangeList)
        {
            string prefix = GetPrefix();
            string suffix = GetSuffix();
            StringBuilder strBuilder = new StringBuilder();
            foreach (string col in _baseBO.GetColumnChangeList())
            {
                if (isAllChangeList)
                {
                    strBuilder.AppendFormat("{0}{1}{2},", prefix, col, suffix);
                }
                else
                {
                    if (!col.Equals(_baseBO.GetIdColumn()))
                        strBuilder.AppendFormat("{0}{1}{2},", prefix, col, suffix);
                }
            }
            string str = strBuilder.ToString();

            return str.Substring(0, str.Length - 1);
        }


        private string GetParameterColumnList()
        {
            string prefix = GetParameterPrefix();
            StringBuilder strBuilder = new StringBuilder();
            foreach (string col in _baseBO.GetColumnChangeList())
            {
                if (!col.Equals(_baseBO.GetIdColumn()))
                    strBuilder.AppendFormat("{0}{1},", prefix, col);
            }

            string str = strBuilder.ToString();
            return str.Substring(0, str.Length - 1);
        }

        private string getUpdateParameter()
        {
            string paramPrefix = GetParameterPrefix();
            string prefix = GetPrefix();
            string suffix = GetSuffix();
            StringBuilder strBuilder = new StringBuilder();
            List<string> Cols = _baseBO.GetColumnChangeList();

            if (Cols.IndexOf(_baseBO.GetIdColumn()) > -1)
                Cols.Remove(_baseBO.GetIdColumn());

            foreach (string col in _baseBO.GetColumnChangeList())
            {
                strBuilder.AppendFormat("{0}{1}{2}={3}{4}, ",
                    prefix, col, suffix, paramPrefix, col);

            }
            string str = strBuilder.ToString();
            return str.Substring(0, str.Length - 2);
        }

        private string getIdentityParameter()
        {
            return string.Format("{0}{1}{2}={3}{4}", GetPrefix(), _baseBO.GetIdColumn(), GetSuffix(),
                GetParameterPrefix(), _baseBO.GetIdColumn());
        }

        private string GetParameterPrefix()
        {
            switch (_ConnType)
            {
                case ConnectionTypes.OleDb:
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                case ConnectionTypes.VistaDB:
                    return "@";

                case ConnectionTypes.Oracle:
                case ConnectionTypes.MySQL:
                case ConnectionTypes.MariaDB:
                    return ":";
                /*
            case ConnectionTypes.EnterpriseDB:                    
            case ConnectionTypes.DB2:
            case ConnectionTypes.SQLite:
            case ConnectionTypes.FireBird:
                 */
                default:
                    return string.Empty;
            }
        }

        private string GetPrefix()
        {
            string _prefix = "";
            switch (_ConnType)
            {
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                case ConnectionTypes.OleDb:
                    _prefix = "[";
                    break;
                case ConnectionTypes.Oracle:
                case ConnectionTypes.MySQL:
                    _prefix = "'";
                    break;

                default:
                    break;
            }
            return _prefix;
        }


        private string GetSuffix()
        {
            string _suffix = "";
            switch (_ConnType)
            {
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                case ConnectionTypes.OleDb:
                    _suffix = "]";
                    break;
                case ConnectionTypes.Oracle:
                case ConnectionTypes.MySQL:
                    _suffix = "'";
                    break;

                default:
                    break;
            }
            return _suffix;
        }

        private string GetIdentityInsert()
        {
            switch (_ConnType)
            {
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.OleDb:
                case ConnectionTypes.SqlServer:
                    return String.Format("SELECT IDENT_CURRENT('{0}');", _baseBO.GetTable());

                case ConnectionTypes.Oracle:
                    return string.Format("Returning {0}{1}{2} As IdCol", GetPrefix(), _baseBO.GetIdColumn(), GetSuffix());

                case ConnectionTypes.SQLite:
                    return "last_insert_rowid();";

                default:
                    throw new NotSupportedException("Unsupported Connection Type For Identity Insert Method.");
            }
        }



        public override string ToString()
        {
            return _queryString;
        }



    }
}
