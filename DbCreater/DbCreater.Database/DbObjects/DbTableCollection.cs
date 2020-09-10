using System.Collections.Generic;
using System.Collections;

namespace DbCreater.Database.DbObjects
{
    public class DbTableCollection : ICollection<DbTable>
    {
        private List<DbTable> tables = new List<DbTable>();
        private bool _isreadOnly = false;

        public void Add(DbTable table)
        {
            if (IsReadOnly == false)
            {
                if (tables.IndexOf(table) == -1)
                {
                    tables.Add(table);
                }
            }
        }

        public void Clear()
        {
            tables.Clear();
        }

        public bool Contains(DbTable table)
        {
            return tables.IndexOf(table) != -1;
        }

        public void CopyTo(DbTable[] array, int arrayIndex)
        {
            tables.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return tables.Count; }
        }

        public bool IsReadOnly
        {
            get { return _isreadOnly; }
        }

        public bool Remove(DbTable table)
        {
            return tables.Remove(table);
        }

        public IEnumerator<DbTable> GetEnumerator()
        {
            return tables.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return tables.GetEnumerator();
        }
    }
}
