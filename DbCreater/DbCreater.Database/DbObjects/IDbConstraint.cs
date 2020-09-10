using DbCreater.Database.DbObjectTypes;

namespace DbCreater.Database.DbObjects
{
    public interface IDbConstraint : IDbObject
    {
        ConstraintTypes ConstraintType { get; }
    }
}
