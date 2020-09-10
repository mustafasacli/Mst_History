using DbCreater.Database.DbObjectTypes;

namespace DbCreater.Database.DbObjects
{
    public struct DbUniqueConstraint : IDbConstraint
    {
        public string Name { get; set; }

        public ConstraintTypes ConstraintType
        {
            get
            { return ConstraintTypes.Unique; }

            set
            { return; }
        }
    }
}
