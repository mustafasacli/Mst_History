using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mst.DbObjects.Column
{
    public class DbColumnCollection : ICollection<DbColumn>
    {
        private List<DbColumn> columnList = null;

        public DbColumnCollection()
        {
            columnList = new List<DbColumn>();
        }

        public void Add(DbColumn item)
        {
            if (!Contains(item))
            {
                if (!IsReadOnly)
                {
                    columnList.Add(item);
                }
                else
                    throw new InvalidCastException("DbColumnCollection is Read-Only.");
            }
            else
                throw new InvalidOperationException("DbColumnCollection is not initialized.");
        }

        public void Clear()
        {
            if (columnList != null)
            {
                columnList.Clear();
            }
            else
                throw new InvalidOperationException("DbColumnCollection is not initialized.");
        }

        public bool Contains(DbColumn item)
        {
            if (columnList != null)
            {
                if (columnList.Count > 0)
                {
                    bool willBeReturned = false;
                    string itemName = item.ColumnName.ToLower();
                    foreach (var column in columnList)
                    {
                        willBeReturned = itemName.Equals(
                            column.ColumnName.ToLower());
                        if (willBeReturned)
                            break;
                    }
                    return willBeReturned;
                }
                else
                    throw new InvalidOperationException("DbColumnCollection is empty.");
            }
            else
                throw new InvalidOperationException("DbColumnCollection is not initialized.");
        }

        public void CopyTo(DbColumn[] array, int arrayIndex)
        {
            if (columnList != null)
            {
                if (columnList.Count > 0 &&
                    arrayIndex > -1 && arrayIndex < columnList.Count)
                {
                    DbColumn[] tmpArray = new DbColumn[columnList.Count - arrayIndex];
                    for (int i = arrayIndex; i < columnList.Count; i++)
                    {
                        tmpArray[i - arrayIndex] = columnList.ElementAt<DbColumn>(i);
                    }
                    array = tmpArray;
                }
                else
                    throw new InvalidOperationException("DbColumnCollection is empty or arrayIndex is out of range.");
            }
            else
                throw new InvalidOperationException("DbColumnCollection is not initialized.");
        }

        public int Count
        {
            get { return columnList != null ? columnList.Count : -1; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(DbColumn item)
        {
            bool willBeReturned = false;
            if (Contains(item))
            {
                willBeReturned = columnList.Remove(item);
            }
            return willBeReturned;
        }

        public IEnumerator<DbColumn> GetEnumerator()
        {
            if (columnList != null)
                return columnList.GetEnumerator();
            else
                throw new InvalidOperationException("DbColumnCollection is not initialized.");
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
