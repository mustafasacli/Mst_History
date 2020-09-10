using DbCreater.Database.DbObjectTypes;

namespace DbCreater.Database.DbObjects
{
    public struct DbCheckContraint : IDbConstraint
    {
        public string Name { get; set; }

        public ConstraintTypes ConstraintType
        {
            get
            { return ConstraintTypes.Check; }
        }
    }
}
