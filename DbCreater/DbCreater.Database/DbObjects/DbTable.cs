using System;
using System.Collections;
using System.Collections.Generic;

namespace DbCreater.Database.DbObjects
{
    public struct DbTable : IDbObject
    {
        private DbSchema _schema;
        private string _name;
        private DbColumnCollection _columns;

        public DbTable(string tableName, DbSchema schema)
        {
            _name = tableName;
            _schema = schema;
            _columns = new DbColumnCollection();
        }

        public DbColumnCollection Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        public DbSchema Schema
        {
            get { return _schema; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj.GetType(), typeof(DbTable)) == true)
            {
                DbTable table = (DbTable)obj;
                return table.Name.Equals(this.Name) && table.Schema.Equals(this.Schema);
            }
            else
                return false;
        }

        public DbColumn GetColumnByName(string columnName)
        {
            try
            {
                DbColumn dbCol = new DbColumn();
                IEnumerator<DbColumn> cols = _columns.GetEnumerator();
                while (cols.MoveNext())
                {
                    if (cols.Current.Name.Equals(columnName) == true)
                    {
                        dbCol = cols.Current;
                        break;
                    }
                }
                return dbCol;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
