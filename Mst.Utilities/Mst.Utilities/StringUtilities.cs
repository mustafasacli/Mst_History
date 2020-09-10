namespace Mst.Utilities
{
    using System;
    using System.Text;

    public class StringUtilities
    {
        public static bool isValidString(string str)
        {
            if (null != str)
                return str.Trim().Length > 0;
            else
                return false;
        }

        public static string ReverseString(string WillBeReversed)
        {
            if (null != WillBeReversed)
            {
                return ReversesString(WillBeReversed, WillBeReversed.Length);
            }
            else
                throw new InvalidOperationException("string will be converted can not be null.");
        }
        private static string ReversesString(string text, int len)
        {
            //if the provided string is a single character then return it
            if (len == 1)
            {
                return text;
            }
            else
            {
                //otherwise use recursion to reverse the string
                return ReversesString(text.Substring(len - (text.Length - 1),
                    text.Length - 1), len - 1) + text[0].ToString();
            }
        }

        public static String MultiConcat(params string[] strings)
        {
            StringBuilder strBuilder = new StringBuilder();
            if (null != strings)
            {
                foreach (var item in strings)
                {
                    if (null != item)
                    {
                        strBuilder.Append(item);
                    }
                    else
                        throw new InvalidOperationException("string will be concated can not be null.");
                }
            }
            return strBuilder.ToString();
        }

        public static String Reversestring2(string willBeReversed)
        {
            try
            {
                if (willBeReversed.Length == 1)
                { return willBeReversed; }
                else
                {
                    return (new StringBuilder()).
                        Append(willBeReversed[willBeReversed.Length - 1]).
                        Append(Reversestring2(willBeReversed.Substring(1, willBeReversed.Length - 2))).
                        Append(willBeReversed[0]).ToString();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public static String ReverseString2(string willBeReversed)
        {
            try
            {
                if (willBeReversed.Length > -1)
                {
                    switch (willBeReversed.Length)
                    {
                        case 0:
                            return string.Empty;
                        case 1:
                            return willBeReversed;
                        case 2:
                            return String.Concat(
                                willBeReversed[1], willBeReversed[0]);
                        default:
                            return (new StringBuilder()).
                            Append(willBeReversed[willBeReversed.Length - 1]).
                            Append(ReverseString2(willBeReversed.Substring(1, willBeReversed.Length - 2))).
                            Append(willBeReversed[0]).ToString();
                    }
                }
                else
                    throw new InvalidOperationException("String object can not be null!.");

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


        #region [String will be examined consist of only number]
        public static bool isNumber(String willBeExamined)
        {
            try
            {
                bool willBeReturned = true;
                foreach (char ch in willBeExamined.ToCharArray())
                {
                    willBeReturned &= Char.IsNumber(ch);
                    if (!willBeReturned)
                    {
                        break;
                    }
                }
                return willBeReturned;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        } // end isNumber
        #endregion

        #region [ String From Int Array ]

        public static string StringFromIntArray(int[] array)
        {
            try
            {
                StringBuilder strBuilder = new StringBuilder();
                foreach (int i in array)
                {
                    string str = i.ToString();
                    strBuilder.Append(str);
                }
                //Console.WriteLine("Int Array Uzunluk: {0}", array.Length);
                //Console.WriteLine("Int Array String Uzunluk: {0}", strBuilder.ToString().Length);
                return ReverseString(strBuilder.ToString());
            }
            catch (Exception exc)
            {
                throw exc;
            }
        } // end StringFromIntArray

        #endregion

        #region [ Multiply Two Integer As Two String ]
        public static string MultiplyStrings(string str1, string str2)
        {
            try
            {
                if (isNumber(str1) && isNumber(str2))
                {
                    string tmp1 = ReverseString(str1);
                    string tmp2 = ReverseString(str2);
                    int len1 = tmp1.Length;
                    int len2 = tmp2.Length;
                    int returnLength = len1 + len2;
                    int[] IntArray = new int[returnLength];
                    for (int i = 0; i < len2; i++)
                    {
                        for (int j = 0; j < len1; j++)
                        {
                            int sayi1 = MathUtilities.Convert2Int32WithoutExc(tmp1[j].ToString());
                            int sayi2 = MathUtilities.Convert2Int32WithoutExc(tmp2[i].ToString());

                            int say = sayi1 * sayi2;
                            IntArray[i + j] += say;

                            IterateArray(ref IntArray, i + j);
                        }
                    }

                    return StringFromIntArray(IntArray);
                }
                else
                    throw new InvalidOperationException("Parameters only consist of numbers.");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion

        private static void IterateArray(ref int[] array, int startIndex)
        {
            try
            {
                for (int i = startIndex; i < array.Length; i++)
                {
                    if (array[i] > 9)
                    {
                        array[i + 1] += (array[i] / 10);
                        array[i] %= 10;
                    }
                    else
                        break;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


    }
}
