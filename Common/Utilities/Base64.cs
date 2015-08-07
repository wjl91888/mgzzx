using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RICH.Common.Utilities
{
    public static class Base64
    {
        public static string UTF8Decode(string base64String)
        {
            return !base64String.IsNullOrWhiteSpace() ? Encoding.UTF8.GetString(Convert.FromBase64String(base64String)) : string.Empty;
        }

        public static string UTF8Encode(string encodetring)
        {
            return !encodetring.IsNullOrWhiteSpace() ? Convert.ToBase64String(Encoding.UTF8.GetBytes(encodetring)) : string.Empty;
        }

        public static string UnicodeDecode(string base64String)
        {
            return !base64String.IsNullOrWhiteSpace() ? Encoding.Unicode.GetString(Convert.FromBase64String(base64String)) : string.Empty;
        }

        public static string UnicodeEncode(string encodetring)
        {
            return !encodetring.IsNullOrWhiteSpace() ? Convert.ToBase64String(Encoding.Unicode.GetBytes(encodetring)) : string.Empty;
        }
    }
}
