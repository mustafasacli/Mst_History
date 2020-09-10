using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mst.Data.QueryBuilding
{
    [Serializable, AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ColumnAttribute : System.Attribute
    {
        private string _Name = string.Empty;
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        private int _Lentgh;
        public int Lentgh
        {
            set { _Lentgh = value > 0 ? value : 0; }
            get { return _Lentgh; }
        }

        private bool _PrimaryKey = false;
        public bool PrimaryKey
        {
            get { return _PrimaryKey; }
            set { _PrimaryKey = value; }
        }

        private bool _Nullable = true;
        public bool Nullable
        {
            set { _Nullable = value && !_PrimaryKey && !IsUnique; }
            get { return _Nullable; }
        }

        private bool _IsUnique = false;
        public bool IsUnique
        {
            set { _IsUnique = value && !IsIdentity; }
            get { return _IsUnique; }
        }

        private bool _IsIdentity = false;
        public bool IsIdentity
        {
            set { _IsIdentity = value; }
            get { return _IsIdentity; }
        }


    }
}
