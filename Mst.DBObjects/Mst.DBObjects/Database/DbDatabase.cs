using Mst.DBObjects.Schema;

namespace Mst.DBObjects.Database
{
    public class DbDatabase
    {
        public DbDatabase(string DatabaseName)
        {
            _DatabaseName = DatabaseName;
        }

        private DbSchemaCollection schemaCollection = new DbSchemaCollection();
        public DbDatabase(string DatabaseName,
            DbSchemaCollection schemacollection)
        {
            _DatabaseName = DatabaseName;
            schemaCollection = schemacollection;
        }

        private string _DatabaseName;
        public string DatabaseName
        {
            get { return _DatabaseName; }
        }

        public DbSchemaCollection SchemaCollection
        {
            get
            { return schemaCollection; }
        }

        public int SchemaCount
        {
            get
            { return schemaCollection.Count; }
        }

    }
}
