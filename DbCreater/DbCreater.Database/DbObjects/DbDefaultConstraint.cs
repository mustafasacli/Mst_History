using DbCreater.Database.DbObjectTypes;

namespace DbCreater.Database.DbObjects
{
    public struct DbDefaultConstraint : IDbConstraint
    {
        public string Name { get; set; }

        public ConstraintTypes ConstraintType
        {
            get
            { return ConstraintTypes.Default; }

            set
            { return; }
        }
    }
}
