using Mst.DBObjects.Column;
using Mst.DBObjects.Schema;
using Mst.DBObjects.Types;
using System;
using System.Collections.Generic;

namespace Mst.DBObjects.Table
{


    public class DbTableCollection : ICollection<DbTable>
    {
        List<DbTable> tableList = null;

        public DbTableCollection()
        {
            tableList = new List<DbTable>();
        }


        public void Add(DbTable item)
        {
            if (!Contains(item))
            {
                if (!IsReadOnly)
                {
                    tableList.Add(item);
                }
                else
                    throw new InvalidCastException("DbTableCollection is Read-Only.");
            }
            else
                throw new InvalidOperationException("DbTable Already exist.");
        }

        public void Clear()
        {
            if (tableList != null)
            {
                if (!IsReadOnly)
                {
                    tableList.Clear();
                }
                else
                    throw new InvalidOperationException("DbTableCollection is Read-only.");
            }
            else
                throw new InvalidOperationException("DbTableCollection is not initialized.");
        }

        public bool Contains(DbTable item)
        {
            bool willBeReturned = false;

            foreach (var table in tableList)
            {
                willBeReturned = item.TableName.ToLower().Equals(
                    table.TableName.ToLower());
                if (willBeReturned)
                    break;
            }
            return willBeReturned;
        }

        public void CopyTo(DbTable[] array, int arrayIndex)
        {
            if (tableList != null)
            {
                if (tableList.Count > 0 &&
                    arrayIndex > -1 && arrayIndex < tableList.Count)
                {
                    DbTable[] tmpArray = new DbTable[tableList.Count - arrayIndex];
                    for (int i = arrayIndex; i < tableList.Count; i++)
                    {
                        tmpArray[i - arrayIndex] = tableList[i];
                    }
                    array = tmpArray;
                }
                else
                    throw new InvalidOperationException("DbTableCollection is empty or arrayIndex is out of range.");
            }
            else
                throw new InvalidOperationException("DbTableCollection is not initialized.");
        }

        public int Count
        {
            get
            {
                return tableList != null ? tableList.Count : -1;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(DbTable item)
        {
            bool willBeRemoved = false;
            if (Contains(item))
            {
                willBeRemoved = tableList.Remove(item);
            }
            return willBeRemoved;
        }

        public IEnumerator<DbTable> GetEnumerator()
        {
            if (tableList != null)
                return tableList.GetEnumerator();
            else
                throw new InvalidOperationException("DbTableCollection is not initialized.");
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            if (tableList != null)
                return tableList.GetEnumerator();
            else
                throw new InvalidOperationException("DbTableCollection is not initialized.");
        }
    }
}
