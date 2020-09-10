using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mst.Data.QueryBuilding
{
    [TableAttribute(TableName = "AbstractTable")]
    public abstract class AbstractTable : ITable
    {
        private List<string> columnList = new List<string>();

        public virtual string getTableName()
        {
            return "";
        }

        public List<string> GetColumnChangeList()
        {
            return columnList;
        }

        public void AddChangeList(string column)
        {
            if (!columnList.Contains(column))
                columnList.Add(column);
        }
    }
}
