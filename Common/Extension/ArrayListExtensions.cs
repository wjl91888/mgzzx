using System;
using System.Collections;
using System.Text;

namespace RICH.Common
{
    public static class ArrayListExtensions
    {
        public static string[] ToStringArray(this ArrayList src)
        {
            var returnValue = new string[src.Count];
            for (int i = 0; i < src.Count; i++)
            {
                returnValue[i] = src[i].ToString();
            }
            return returnValue;
        }
    }
}
