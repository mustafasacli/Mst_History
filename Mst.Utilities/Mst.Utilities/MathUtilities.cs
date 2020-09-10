namespace Mst.Utilities
{
    using System;

    public class MathUtilities
    {

        #region [ Convert To Int32 Without Exception ]

        public static int Convert2Int32WithoutExc(string willBeConverted)
        {
            try
            {
                return Convert.ToInt32(willBeConverted);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion


        #region [ Convert To Int32 Without Exception ]
        public static int Convert2Int32WithoutExc(object willBeConverted)
        {
            try
            {
                return Convert.ToInt32(willBeConverted);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion


        #region [ Convert To Int32 With Exception ]
        public static int Convert2Int32WithExc(string willBeConverted)
        {
            try
            {
                return Convert.ToInt32(willBeConverted);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        } // end GetIntFromString
        #endregion


        #region [ Convert To Int32 With Exception ]

        public static int Convert2Int32WithExc(object willBeConverted)
        {
            try
            {
                return Convert.ToInt32(willBeConverted);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Convert To Double Without Exception ]

        public static double Convert2DoubleWithoutExc(object wilBeConverted)
        {
            try
            {
                return Convert.ToDouble(wilBeConverted);
            }
            catch (Exception)
            {
                return 0.0d;
            }
        }

        #endregion


        #region [ Convert To Double Without Exception ]

        public static double Convert2DoubleWithoutExc(string wilBeConverted)
        {
            try
            {
                return Convert.ToDouble(wilBeConverted);
            }
            catch (Exception)
            {
                return 0.0d;
            }
        }

        #endregion


        #region [ Convert To Double With Exception ]

        public static double Convert2DoubleWithExc(object wilBeConverted)
        {
            try
            {
                return Convert.ToDouble(wilBeConverted);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Convert To Double With Exception ]

        public static double Convert2DoubleWithExc(string wilBeConverted)
        {
            try
            {
                return Convert.ToDouble(wilBeConverted);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Convert the Numbers To Digits ]

        public static string GetIntegerBits(int sayi)
        {
            if (sayi < 0)
            {
                throw new InvalidOperationException("Number must be greater than zero.");
            }
            else
            {
                switch (sayi)
                {
                    case 0:
                        return "0";
                    case 1:
                        return "1";
                    default:
                        return String.Concat(GetIntegerBits(sayi / 2),
                        (sayi - (sayi / 2) * 2).ToString());
                }
            }
        }
        #endregion



    }
}
