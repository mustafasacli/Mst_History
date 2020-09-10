using Mst.DBObjects.Database;
using Mst.DBObjects.Table;

namespace Mst.DBObjects.Schema
{
    public class DbSchema
    {
        private string _Name = "";
        /// <summary>
        /// Name of schema.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private DbDatabase _Database;
        /// <summary>
        /// database Of Schema.
        /// </summary>
        public DbDatabase Database
        {
            get { return _Database; }
            set { _Database = value; }
        }


        private DbTableCollection _TableCollection = new DbTableCollection();
        /// <summary>
        /// Table Collection Of Schema.
        /// </summary>
        public DbTableCollection TableCollection
        {
            get
            { return _TableCollection; }
        }

        /// <summary>
        /// Count Of Tables.
        /// </summary>
        public int TableCount
        {
            get
            { return _TableCollection.Count; }
        }
    }
}
