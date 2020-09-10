namespace DbCreater.Database.DbObjectTypes
{
    public enum ConnectionTypes : byte
    {
        SqlServer = 1,
        PostgreSQL = 2,
        Oracle = 3,
        MySQL = 4
    };

    public enum ConstraintTypes : byte
    {
        PrimaryKey = 1,
        ForeignKey = 2,
        Default = 4,
        Check = 8,
        Unique = 16
    };

    public enum DataTypes : long
    {
        BigInt = 1,
        Binary,
        Bit,
        Char,
        Date,
        DateTime,
        DateTime2,
        DateTimeOffset,
        Decimal,
        Float,
        Image,
        Integer,
        Money,
        NChar,
        NText,
        Numeric,
        NVarChar,
        NVarChar_MAX,
        Real,
        SmallDateTime,
        SmallInt,
        SmallMoney,
        Sql_Variant,
        Text,
        Time,
        TimeStamp,
        TinyInt,
        UniqueIdentifier,
        VarBinary,
        VarBinary_MAX,
        VarChar,
        VarChar_MAX,
        XML
    };
}
