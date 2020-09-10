
namespace Mst.DBObjects.Constraint
{
    public class DbPrimaryKey
    {
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

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

        private string _database = string.Empty;
        public string Database
        {
            get { return _database; }
            set { _database = value; }
        }

    }
}
