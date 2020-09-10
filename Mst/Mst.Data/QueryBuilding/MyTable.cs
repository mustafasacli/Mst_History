
using System.Collections.Generic;
namespace Mst.Data.QueryBuilding
{
    [TableAttribute(TableName = "MyTable")]
    public class MyTable : AbstractTable
    {
        private int _OBJID;
        [ColumnAttribute(Name = "OBJID", PrimaryKey = true)]
        public int OBJID
        {
            set { _OBJID = value; }
            get { return _OBJID; }
        }




        public override string getTableName()
        {
            return this.GetType().Name;
        }

        public int getTableHashCode()
        {
            return 1045;
        }


        public List<string> GetColumnChangeList()
        {
            throw new System.NotImplementedException();
        }
    }
}
