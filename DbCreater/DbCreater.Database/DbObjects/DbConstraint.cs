using DbCreater.Database.DbObjectTypes;

namespace DbCreater.Database.DbObjects
{
    public struct DbConstraint : IDbConstraint
    {
        public string Name { get; set; }

        public ConstraintTypes ConstraintType { get; set; }

        public string ConstraintString { get; set; }
    }
}
