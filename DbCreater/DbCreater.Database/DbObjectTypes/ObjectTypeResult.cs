using System;

namespace DbCreater.Database.DbObjectTypes
{
    public class ObjectTypeResult
    {

        public static string DataTypeString(DataTypes dataType)
        {
            string retVal = Enum.GetName(typeof(DataTypes), dataType);

            switch (dataType)
            {
                case DataTypes.NVarChar_MAX:
                case DataTypes.VarBinary_MAX:
                case DataTypes.VarChar_MAX:
                    retVal = retVal.Substring(0, retVal.Length - 4);
                    retVal = string.Concat(retVal, "(MAX)");
                    break;

                default:
                    break;
            }
            return retVal;
        }



        public static string ConstraintFormat(ConstraintTypes constraintType)
        {
            string retVal = string.Empty;

            switch (constraintType)
            {
                case ConstraintTypes.PrimaryKey:
                    retVal = "Constraint {0} Primary Key({1})";
                    break;
                case ConstraintTypes.ForeignKey:
                    break;
                case ConstraintTypes.Default:
                    retVal = "Default {0}";
                    break;
                case ConstraintTypes.Check:
                    retVal = "Check {0}";
                    break;
                case ConstraintTypes.Unique:
                    retVal = "Unique";
                    break;
                default:
                    break;
            }

            return retVal;
        }
    }
}
