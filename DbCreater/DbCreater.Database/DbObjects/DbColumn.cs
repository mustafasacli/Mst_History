using DbCreater.Database.DbObjectTypes;

namespace DbCreater.Database.DbObjects
{
    public struct DbColumn : IDbObject
    {
        private int _length;
        private DbTable _table;
        private string _name;
        private bool _isNotNull;
        private DataTypes _dataType;

        public DbColumn(string name, DbTable table) :
            this(name, table, 11, false, DataTypes.Integer)
        {
        }

        public DbColumn(string name, DbTable table, bool is_notNull, DataTypes datatype) :
            this(name, table, 11, is_notNull, datatype)
        {
        }

        public DbColumn(string name, DbTable table, DataTypes datatype) :
            this(name, table, 11, false, datatype)
        {
        }

        public DbColumn(string name, DbTable table, int length, bool is_notNull, DataTypes datatype)
        {
            _name = name;
            _table = table;
            _length = length;
            _isNotNull = is_notNull;
            _dataType = datatype;
        }

        public bool IsNull
        {
            get { return _isNotNull; }
            set { _isNotNull = value; }
        }

        public DataTypes DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        public string Name
        {
            get
            { return _name; }
            set
            { _name = value; }
        }

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }


        public DbTable Table { get { return _table; } }


        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj.GetType(), typeof(DbColumn)) == true)
            {
                DbColumn col = (DbColumn)obj;
                return col._name.Equals(_name) && col.Table.Equals(_table);
            }
            else
                return false;
        }
    }
}
