using DbCreater.Database.DbObjectTypes;

namespace DbCreater.Database.DbObjects
{
    public struct DbPrimaryKeyConstraint : IDbConstraint
    {
        public string Name { get; set; }

        public ConstraintTypes ConstraintType
        {
            get
            { return ConstraintTypes.PrimaryKey; }

            set
            { return; }
        }
    }
}
