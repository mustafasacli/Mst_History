using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mst.Data.QueryBuilding
{
    public interface ITable
    {
        string getTableName();

       

        List<string> GetColumnChangeList();
    }
}
