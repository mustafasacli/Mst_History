using DbCreater.Database.DbObjectTypes;

namespace DbCreater.Database.DbObjects
{
    public struct DbForeignKeyContraint : IDbConstraint
    {
        public string Name { get; set; }

        public ConstraintTypes ConstraintType
        {
            get
            { return ConstraintTypes.ForeignKey; }

            set
            { return; }
        }
    }
}
