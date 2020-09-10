using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mst.Data.QueryBuilding
{
    [Serializable, AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class TableAttribute : Attribute
    {
        private string _TableName = "";
        /// <summary>
        /// Name Of Table Object
        /// </summary>
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        private string _SchemaName = "";
        /// <summary>
        /// Schema Name of Table Object
        /// </summary>
        public string SchemaName
        {
            get { return _SchemaName; }
            set { _SchemaName = value; }
        }

        private string _DatabaseName = "";
        /// <summary>
        /// Database name of Table Object
        /// </summary>
        public string DatabaseName
        {
            get { return _DatabaseName; }
            set { _DatabaseName = value; }
        }
    }
}
