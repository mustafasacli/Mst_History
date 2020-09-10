using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mst.Data.QueryBuilding
{
    public enum QueryTypes : byte
    {
        Select = 1,
        Insert = 2,
        Update = 3,
        Delete = 4,
        Create = 5,
        Drop = 6
    };
}
