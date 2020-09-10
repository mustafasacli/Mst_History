using System.Collections;
using System.Collections.Generic;

namespace DbCreater.Database.DbObjects
{
    public class DbColumnCollection : ICollection<DbColumn>
    {
        private List<DbColumn> columns = new List<DbColumn>();
        private bool _isreadOnly = false;

        public void Add(DbColumn column)
        {
            if (IsReadOnly == false)
            {
                if (columns.IndexOf(column) == -1)
                {
                    columns.Add(column);
                }
            }
        }

        public void Clear()
        {
            columns.Clear();
        }

        public bool Contains(DbColumn column)
        {
            return columns.IndexOf(column) != -1;
        }

        public void CopyTo(DbColumn[] array, int arrayIndex)
        {
            columns.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return columns.Count; }
        }

        public bool IsReadOnly
        {
            get { return _isreadOnly; }
        }

        public bool Remove(DbColumn column)
        {
            return columns.Remove(column);
        }

        public IEnumerator<DbColumn> GetEnumerator()
        {
            return columns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return columns.GetEnumerator();
        }
    }
}
