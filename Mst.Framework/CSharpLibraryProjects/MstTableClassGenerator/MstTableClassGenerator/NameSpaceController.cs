using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MstTableClassGenerator
{
    public class NameSpaceController
    {

        public static bool ControlNameSpace(string _nameSpace)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_nameSpace))
                {
                    char[] chStr = _nameSpace.ToCharArray();
                    int ii = (int)chStr[0];

                    if (ii > 47 && ii < 58)
                        return false;

                    bool retBool = true;
                    foreach (var ch in chStr)
                    {
                        int i = (int)ch;
                        retBool &=
                            ((i > 47 && i < 58) ||
                             (i > 64 && i < 91) ||
                             (i > 96 && i < 123) ||
                             (i == 95) || (i==46));
                    }
                    return retBool;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
