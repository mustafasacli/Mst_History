using System;
using System.Collections.Generic;
using System.Collections;

namespace DbCreater.Database.DbObjects
{
    public class DbSchemaCollection : ICollection<DbSchema>
    {
        List<DbSchema> schemas = new List<DbSchema>();
        private bool _isreadOnly = false;

        public void Add(DbSchema schem)
        {
            if (IsReadOnly == false)
            {
                if (schemas.IndexOf(schem) == -1)
                {
                    schemas.Add(schem);
                }
            }
        }

        public void Clear()
        {
            schemas.Clear();
        }

        public bool Contains(DbSchema schem)
        {
            return schemas.IndexOf(schem) != -1;
        }

        public void CopyTo(DbSchema[] array, int arrayIndex)
        {
            schemas.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return schemas.Count; }
        }

        public bool IsReadOnly
        {
            get { return _isreadOnly; }
        }

        public bool Remove(DbSchema schem)
        {
            return schemas.Remove(schem);
        }

        public IEnumerator<DbSchema> GetEnumerator()
        {
            return schemas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return schemas.GetEnumerator();
        }
    }
}
