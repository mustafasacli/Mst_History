using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MstTableClassGenerator
{
    public class ClassTable
    {

        public string TableName { get; set; }

        public string IdColumn { get; set; }

        public List<ClassColumn> TableColumns { get; set; }
    }
}
