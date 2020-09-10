using Mst.DBObjects.Types;
using System;

namespace Mst.DBObjects.Column
{
    public class DbColumn
    {
        private string _ColumnName;
        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }

        private int _Length;
        public int Length
        {
            get { return _Length; }
            set
            {
                _Length = value > 0 ? value : 0;
            }
        }

        private Type _type;
        public Type TypeOfColumn
        {
            get { return _type; }
            set { _type = value; }
        }

        private DbDataTypes datatype;
        public DbDataTypes DataType
        {
            get
            { return datatype; }
            set
            { datatype = value; }
        }

        private bool _isUnique;
        public bool isUnique
        {
            get
            { return _isUnique; }
            set
            {
                _isUnique = _isIdentity ? false : value;
            }
        }

        private bool _isIdentity;
        public bool isIdentity
        {
            get { return _isIdentity; }
            set
            {
                _isIdentity = value;
                _isUnique = isIdentity ? false : _isUnique;
            }
        }

        private bool _isPrimaryKey;

        public bool IsPrimaryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }
    }
}
