namespace MstTableClassGenerator
{
    public class ClassColumn
    {
        public ClassColumn(string sColumnName, string sColumnType)
        {
            _ColumnName = sColumnName;
            _ColumnTypeName = ConvertFromDbDataType(sColumnType);
        }

        private string _ColumnName = "";
        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }

        private string _ColumnTypeName = "";
        public string ColumnTypeName
        {
            get { return _ColumnTypeName; }
            set { _ColumnTypeName = value; }
        }

        private string ConvertFromDbDataType(string column_data_type)
        {
            switch (column_data_type)
            {
                case "number":
                case "int":
                case "INT":
                case "int4":
                case "INT4":
                    return "int";

                case "tinyint":
                case "TINYINT":
                    return "byte";

                case "smallint":
                case "SMALLINT":
                    return "Int16";

                case "DateTimeOffset":
                case "Date":
                case "datetime":
                case "DATETIME":
                case "time":
                case "TIME":
                    return "DateTime";

                case "bigint":
                case "BIGINT":
                    return "long";

                case "decimal":
                case "DECIMAL":
                case "SmallMoney":
                case "Money":
                    return "decimal";

                case "real":
                case "REAL":
                    return "float";

                case "Float":
                    return "double";

                case "BIT":
                case "bit":
                    return "bool";

                case "nvarchar":
                case "nvarchar2":
                case "varchar":
                case "varchar2":
                case "NVARCHAR":
                case "NVARCHAR2":
                case "VARCHAR":
                case "VARCHAR2":
                case "text":
                case "NText":
                    return "string";

                case "Char":
                case "NChar":
                    return "char";

                case "Binary":
                case "Image":
                    return "byte[] ";

                default:
                    return "string";
            }
        }
    }
}
