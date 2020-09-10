using System.Collections.Generic;
using System.Collections;
using System;

namespace DbCreater.Database.DbObjects
{
    public struct DbSchema : IDbObject
    {
        private string _name;
        private DbTableCollection _tables;
        private Dbase _database;

        public DbSchema(string schemaName, Dbase database)
        {
            _name = schemaName;
            _database = database;
            _tables = new DbTableCollection();
        }

        public Dbase Database
        {
            get { return _database; }
            set { _database = value; }
        }

        public DbTableCollection Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj.GetType(), typeof(DbSchema)) == true)
            {
                DbSchema schem = (DbSchema)obj;
                return schem.Name.Equals(this.Name) && schem.Database.Equals(this.Database);
            }
            else
                return false;
        }

        public DbTable GetTableByName(string tableName)
        {
            try
            {
                DbTable table = new DbTable();
                IEnumerator<DbTable> tabless = _tables.GetEnumerator();

                while (tabless.MoveNext())
                {
                    if (tabless.Current.Name.Equals(tableName) == true)
                    {
                        table = tabless.Current;
                        break;
                    }
                }

                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
