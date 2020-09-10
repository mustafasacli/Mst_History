using Mst.DBObjects.Column;
using Mst.DBObjects.Schema;
using Mst.DBObjects.Types;

namespace Mst.DBObjects.Table
{
    public class DbTable
    {
        private string _TableName;
        /// <summary>
        /// Name Of Table.
        /// </summary>
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        private DbSchema _Schema;
        /// <summary>
        /// Schema Of Table.
        /// </summary>
        public DbSchema Schema
        {
            get { return _Schema; }
            set { _Schema = value; }
        }


        private DbTableTypes tabletype;
        /// <summary>
        /// Type Of Table.
        /// </summary>
        public DbTableTypes TableType
        {
            get
            { return tabletype; }
            set
            { tabletype = value; }
        }

        /// <summary>
        /// The Column Count Of Table.
        /// </summary>
        public int ColumnCount
        {
            get
            { return _ColumnCollection.Count; }
        }


        private DbColumnCollection _ColumnCollection = new DbColumnCollection();
        /// <summary>
        /// The Column Collection Of Table.
        /// </summary>
        public DbColumnCollection ColumnCollection
        {
            get
            { return _ColumnCollection; }
        }
    }
}
