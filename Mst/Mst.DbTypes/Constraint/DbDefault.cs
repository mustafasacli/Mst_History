
namespace Mst.DbObjects.Constraint
{
    public class DbDefault
    {

        private string _table = string.Empty;
        public string Table
        {
            get { return _table; }
            set { _table = value; }
        }

        private string _column = string.Empty;
        public string Column
        {
            get { return _column; }
            set { _column = value; }
        }

        private object _defaultValue;
        public object DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }
    }
}
