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
        private Hashtable _parameters = null;
        private string _queryString = string.Empty;
        private IBaseBO _baseBO;
        QueryTypes _queryType;
        Boolean isNotEmptyChangeList = true;

        private ConnectionTypes _ConnType;

        /// <summary>
        /// Create a QueryBuilder with given object and SqlServer ConnetionTypes and Select QueryTypes.
        /// </summary>
        /// <param name="queryObject">An object inherits IBaseBO interface.</param>
        public QueryBuilder(IBaseBO queryObject)
            : this(ConnectionTypes.SqlServer, QueryTypes.Select, queryObject)
        { }

        /// <summary>
        /// Create a QueryBuilder with given object and  querytype and SqlServer ConnetionTypes.
        /// </summary>
        /// <param name="queryType">Query Types of Query Builder.</param>
        /// <param name="queryObject">An object inherits IBaseBO interface.</param>
        public QueryBuilder(QueryTypes queryType, IBaseBO queryObject)
            : this(ConnectionTypes.SqlServer, queryType, queryObject)
        { }

        /// <summary>
        /// Create a QueryBuilder with given object and  querytype and connetiontypes.
        /// </summary>
        /// <param name="ConnType">Connetion Types of Query Builder.</param>
        /// <param name="queryType">Query Types of Query Builder.</param>
        /// <param name="queryObject">An object inherits IBaseBO interface.</param>
        public QueryBuilder(ConnectionTypes ConnType, QueryTypes queryType,
            IBaseBO queryObject)
        {
            _baseBO = queryObject;
            _queryType = queryType;
            _ConnType = ConnType;
            isNotEmptyChangeList = _baseBO.GetColumnChangeList().Count > 0;

            _queryString = GetQueryString();
            _parameters = GetParameters();

        }

        /// <summary>
        /// Returns Query Parameters of QueryBuilder.
        /// </summary>
        public Hashtable QueryParameters
        {
            get { return _parameters; }
        }

        /// <summary>
        /// Returns Query String of QueryBuilder.
        /// </summary>
        public string QueryString
        {
            get { return _queryString; }
        }


        #region [ Get Parameters ]

        /// <summary>
        /// Returns Query Parameters of QueryBuilder.
        /// </summary>
        /// <returns>Returns Query Parameters of QueryBuilder.</returns>
        private Hashtable GetParameters()
        {
            Hashtable hash = new Hashtable();
            string paramPrefix = GetParameterPrefix();
            List<string> colList = _baseBO.GetColumnChangeList();
            string idCol = _baseBO.GetIdColumn();
            PropertyInfo propInfo;
            switch (_queryType)
            {
                /*-- Select And SelectWithFilter Parts --*/
                case QueryTypes.Select:
                    return null;

                /*-- Insert and InsertAndGetId Part --*/
                case QueryTypes.InsertAndGetId:
                case QueryTypes.Insert:
                    if (colList.Contains(idCol))
                        colList.Remove(idCol);
                    foreach (string col in colList)
                    {
                        propInfo = _baseBO.GetType().GetProperty(col);
                        hash.Add(string.Format("{0}{1}", paramPrefix, col),
                            propInfo.GetValue(_baseBO, null));

                    }
                    return hash;

                /*-- Update Part --*/
                case QueryTypes.Update:

                    if (colList.IndexOf(idCol) == -1)
                        colList.Add(idCol);

                    foreach (string col in colList)
                    {
                        propInfo = _baseBO.GetType().GetProperty(col);
                        hash.Add(string.Format("{0}{1}", paramPrefix, col),
                            propInfo.GetValue(_baseBO, null));
                    }

                    return hash;

                /*-- Delete And SelectWhereId Parts --*/
                case QueryTypes.SelectWhereId:
                case QueryTypes.Delete:
                    propInfo = _baseBO.GetType().GetProperty(idCol);
                    hash.Add(string.Format("{0}{1}", paramPrefix, idCol),
                        propInfo.GetValue(_baseBO, null));
                    return hash;


                case QueryTypes.SelectWhereChangeColumns:
                    foreach (string col in colList)
                    {
                        propInfo = _baseBO.GetType().GetProperty(col);
                        hash.Add(string.Format("{0}{1}", paramPrefix, col), propInfo.GetValue(_baseBO, null));
                    }
                    return hash;

                case QueryTypes.SelectChangeColumns:
                    foreach (string col in colList)
                    {
                        propInfo = _baseBO.GetType().GetProperty(col);
                        hash.Add(string.Format("{0}{1}", paramPrefix, col), propInfo.GetValue(_baseBO, null));
                    }
                    return hash;
                default:
                    throw new InvalidOperationException("Invalid Query Type");
            }
        }

        #endregion


        #region [ Get Query String ]

        /// <summary>
        /// Returns Query String.
        /// </summary>
        /// <returns></returns>
        private string GetQueryString()
        {
            string _queryFormat = QueryFormat(_queryType);
            switch (_queryType)
            {
                case QueryTypes.Select:
                    return string.Format(_queryFormat, getCompleteTableName());

                case QueryTypes.Insert:
                    return string.Format(_queryFormat,
                        getCompleteTableName(),
                        GetFirstPart(),
                        getSecondPart());

                case QueryTypes.Update:
                    return string.Format(_queryFormat,
                        getCompleteTableName(),
                        GetFirstPart(),
                        getSecondPart());


                case QueryTypes.Delete:
                    return string.Format(_queryFormat,
                        getCompleteTableName(),
                        getSecondPart());

                case QueryTypes.InsertAndGetId:
                    return new StringBuilder(
                        string.Format(_queryFormat,
                         getCompleteTableName(),
                         GetFirstPart(), getSecondPart()
                         )).
                         AppendLine(GetIdentityInsert()).ToString();

                case QueryTypes.SelectWhereId:
                    return string.Format(
                        _queryFormat,
                        getCompleteTableName(),
                        getSecondPart()
                        );

                case QueryTypes.SelectWhereChangeColumns:
                    return string.Format(_queryFormat, getCompleteTableName(), getSecondPart());

                case QueryTypes.SelectChangeColumns:
                    return string.Format(_queryFormat, getCompleteTableName(), getSecondPart());

                default:
                    throw new InvalidOperationException("Invalid Query Type.");
            }
        }

        #endregion


        #region [ Query Format of QueryType ]

        /// <summary>
        /// Returns Format of Query according to QueryType.
        /// </summary>
        /// <param name="queryType"></param>
        /// <returns></returns>
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

                case QueryTypes.SelectWhereChangeColumns:
                case QueryTypes.SelectWhereId:
                    return "Select * From {0} Where {1};";

                default:
                    break;
            }
            return string.Empty;
        }
        #endregion


        #region [ Get Completely Table Name ]

        /// <summary>
        /// Returns Table Name with prefix and suffix.
        /// </summary>
        /// <returns> Returns Table Name with prefix and suffix. </returns>
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

        #endregion


        #region [ Get First Part ]

        /// <summary>
        /// Returns Second Part of Query format;
        /// for Select  Or Delete --> ""
        /// for Insert --> Table({0})
        /// for Update Set Column=@Column
        /// </summary>
        /// <returns></returns>
        private string GetFirstPart()
        {
            string _firstPart = "";
            string paramPrefix = GetParameterPrefix();
            string prefix = GetPrefix();
            string suffix = GetSuffix();
            StringBuilder strBuilder;
            List<string> Cols;

            switch (_queryType)
            {
                case QueryTypes.SelectWhereId:
                case QueryTypes.SelectWhereChangeColumns:
                case QueryTypes.SelectChangeColumns:
                case QueryTypes.Select:
                case QueryTypes.Delete:
                    break;

                case QueryTypes.InsertAndGetId:
                case QueryTypes.Insert:
                    {
                        Cols = _baseBO.GetColumnChangeList();
                        Cols.Remove(_baseBO.GetIdColumn());

                        if (Cols.Count == 0)
                            return "";

                        strBuilder = new StringBuilder();
                        foreach (string col in Cols)
                        {
                            strBuilder.AppendFormat("{0}{1}{2},", prefix, col, suffix);
                        }
                        _firstPart = strBuilder.ToString();

                        return _firstPart.Substring(0, _firstPart.Length - 1);
                    }

                case QueryTypes.Update:
                    {
                        strBuilder = new StringBuilder();
                        Cols = _baseBO.GetColumnChangeList();
                        Cols.Remove(_baseBO.GetIdColumn());

                        if (Cols.Count == 0)
                            return "";

                        foreach (string col in _baseBO.GetColumnChangeList())
                        {
                            strBuilder.AppendFormat("{0}{1}{2}={3}{1}, ",
                                prefix, col, suffix, paramPrefix);

                        }
                        _firstPart = strBuilder.ToString();
                        return _firstPart.Substring(0, _firstPart.Length - 2);
                    }

                default:
                    break;
            }

            return _firstPart;
        }

        #endregion


        #region [ Second Part ]

        /// <summary>
        /// Returns Second Part of Query format;
        /// for Select --> ""
        /// for Insert --> Values({0})
        /// for Update Or Delete Where IdColumn=@IdColumn
        /// </summary>
        /// <returns></returns>
        private string getSecondPart()
        {
            string _secondPart = "";
            string paramPrefix = GetParameterPrefix();
            string prefix = GetPrefix();
            string suffix = GetSuffix();
            StringBuilder strBuilder;
            List<string> Cols;

            switch (_queryType)
            {
                case QueryTypes.Select:
                    break;

                case QueryTypes.InsertAndGetId:
                case QueryTypes.Insert:
                    {
                        Cols = _baseBO.GetColumnChangeList();
                        Cols.Remove(_baseBO.GetIdColumn());
                        if (Cols.Count == 0)
                            return "";

                        strBuilder = new StringBuilder();
                        foreach (string col in Cols)
                        {
                            strBuilder.AppendFormat("{0}{1},", paramPrefix, col);
                        }

                        _secondPart = strBuilder.ToString();
                        return _secondPart.Substring(0, _secondPart.Length - 1);
                    }

                case QueryTypes.SelectWhereId:
                case QueryTypes.Delete:
                case QueryTypes.Update:
                    _secondPart = string.Format("{0}{1}{2}={3}{1}", prefix,
                        _baseBO.GetIdColumn(), suffix, paramPrefix);
                    break;

                case QueryTypes.SelectWhereChangeColumns:
                    {
                        strBuilder = new StringBuilder();
                        Cols = _baseBO.GetColumnChangeList();

                        if (Cols.Count == 0)
                            return "";

                        foreach (string col in _baseBO.GetColumnChangeList())
                        {
                            strBuilder.AppendFormat("{0}{1}{2}={3}{1} And ",
                                prefix, col, suffix, paramPrefix);

                        }
                        _secondPart = strBuilder.ToString();
                        return _secondPart.Substring(0, _secondPart.Length - 5);
                    }

                default:
                    break;
            }
            return _secondPart;
        }

        #endregion


        #region [ Get Parameter Prefix ]

        /// <summary>
        /// Returns Prefix for parameters according to Connection Type.
        /// </summary>
        /// <returns> Returns Prefix for parameters according to Connection Type.</returns>
        private string GetParameterPrefix()
        {
            switch (_ConnType)
            {
                case ConnectionTypes.OleDb:
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                case ConnectionTypes.VistaDB:
                case ConnectionTypes.SqlServerCe:
                case ConnectionTypes.MySQL:
                case ConnectionTypes.MariaDB:
                case ConnectionTypes.SQLite:
                    return "@";

                case ConnectionTypes.Oracle:
                    return ":";
                /*
            case ConnectionTypes.EnterpriseDB:                    
            case ConnectionTypes.DB2:
            case ConnectionTypes.FireBird:
                 */
                default:
                    return string.Empty;
            }
        }
        #endregion


        #region [ Get Prefix ]

        /// <summary>
        /// Returns Prefix for columns and tables according to Connection Type.
        /// </summary>
        /// <returns> Returns Prefix for columns and tables according to Connection Type.</returns>
        private string GetPrefix()
        {
            string _prefix = "";
            switch (_ConnType)
            {
                case ConnectionTypes.OleDb:
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                case ConnectionTypes.VistaDB:
                case ConnectionTypes.SqlServerCe:
                    _prefix = "[";
                    break;
                case ConnectionTypes.Oracle:
                case ConnectionTypes.MySQL:
                case ConnectionTypes.MariaDB:
                    _prefix = "'";
                    break;

                default:
                    break;
            }
            return _prefix;
        }

        #endregion


        #region [ Get Suffix ]

        /// <summary>
        /// Returns Suffix for columns and tables according to Connection Type.
        /// </summary>
        /// <returns>Returns Suffix for columns and tables according to Connection Type.</returns>
        private string GetSuffix()
        {
            string _suffix = "";
            switch (_ConnType)
            {
                case ConnectionTypes.OleDb:
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                case ConnectionTypes.VistaDB:
                case ConnectionTypes.SqlServerCe:
                    _suffix = "]";
                    break;
                case ConnectionTypes.Oracle:
                case ConnectionTypes.MySQL:
                case ConnectionTypes.MariaDB:
                    _suffix = "'";
                    break;

                default:
                    break;
            }
            return _suffix;
        }

        #endregion


        #region [ Get Identity Insert ]

        /// <summary>
        /// Returns GetIdentity query part of InsertAndGetId.
        /// </summary>
        /// <returns> Returns GetIdentity query part of InsertAndGetId. </returns>
        private string GetIdentityInsert()
        {
            switch (_ConnType)
            {
                case ConnectionTypes.OleDb:
                case ConnectionTypes.SqlExpress:
                case ConnectionTypes.SqlServer:
                case ConnectionTypes.VistaDB:
                case ConnectionTypes.SqlServerCe:
                    return String.Format("SELECT IDENT_CURRENT('{0}');", _baseBO.GetTable());

                case ConnectionTypes.Oracle:
                    return string.Format("Returning {0}{1}{2} As IdCol", GetPrefix(), _baseBO.GetIdColumn(), GetSuffix());

                case ConnectionTypes.SQLite:
                    return "last_insert_rowid();";

                case ConnectionTypes.MySQL:
                case ConnectionTypes.MariaDB:
                    return "Select last_insert_id();";

                default:
                    throw new NotSupportedException("Unsupported Connection Type For Identity Insert Method.");
            }
        }

        #endregion


        /// <summary>
        /// Returns Query String of QueryBuilder.
        /// </summary>
        /// <returns>Returns Query String of QueryBuilder.</returns>
        public override string ToString()
        {
            return _queryString;
        }

    }
}
