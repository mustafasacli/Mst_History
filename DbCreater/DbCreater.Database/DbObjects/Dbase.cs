using DbCreater.Database.DbObjectTypes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DbCreater.Database.DbObjects
{
    public struct Dbase : IDbObject
    {
        private string _name;
        private ConnectionTypes _ConnectionType;
        private DbSchemaCollection _schemas;

        public Dbase(string database_name, ConnectionTypes connection_type)
        {
            _name = database_name;
            _ConnectionType = connection_type;
            _schemas = new DbSchemaCollection();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ConnectionTypes ConnectionType
        {
            get { return _ConnectionType; }
            set { _ConnectionType = value; }
        }

        public DbSchemaCollection Schemas
        {
            get { return _schemas; }
            set { _schemas = value; }
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj.GetType(), typeof(Dbase)) == true)
            {
                Dbase db_base = (Dbase)obj;
                return db_base.Name.Equals(this.Name) && db_base.ConnectionType.Equals(this.ConnectionType);
            }
            else
                return false;
        }

        public DbSchema GteSchemaByName(string schemaName)
        {
            try
            {
                IEnumerator<DbSchema> _enumerator = _schemas.GetEnumerator();
                DbSchema schem = new DbSchema();
                while (_enumerator.MoveNext())
                {
                    if (_enumerator.Current.Name.Equals(schemaName) == true)
                    {
                        schem = _enumerator.Current;
                        break;
                    }

                }
                return schem;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
