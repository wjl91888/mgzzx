using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace RICH.Common
{
    public static class StringFormatExtensions
    {
        /// <summary>
        /// Encrypt mask for string to hex
        /// </summary>
        private const byte Mask = 0xac;
        /// <summary>
        /// helper array for char value to ascii number string
        /// </summary>
        private static readonly char[] CharAsciiMap = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        /// <summary>
        /// helper array for ascii string to char value
        /// </summary>
        ///----------------------------------------------------------//48-57 '0'-'9' --------------//58-64 -------------//65-70 'A'-'Z'
        private static readonly byte[] AsciiStringMap = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 0, 0, 0, 0, 0, 0, 10, 11, 12, 13, 14, 15, };

        /// <summary>
        /// Convert string to a series of hex number string with a little encryption
        /// </summary>
        /// <param name="src">the source string</param>
        /// <returns>Encrypted string in hex format</returns>
        public static string ToHexString(this string src)
        {
            if (String.IsNullOrEmpty(src))
            {
                return String.Empty;
            }
            var data = new byte[src.Length * 2];

            for (var i = 0; i < src.Length; i++)
            {
                var t = (byte)(src[i] ^ Mask);
                data[i * 2] = (byte)CharAsciiMap[t >> 4];
                data[i * 2 + 1] = (byte)CharAsciiMap[t % 0x10];
            }
            return Encoding.ASCII.GetString(data);
        }

        /// <summary>
        /// Decrypt for hex formated string encrypted by ToHexString 
        /// </summary>
        /// <param name="src">encrypted string</param>
        /// <returns>decrypted string</returns>
        public static string DecodeHexString(this string src)
        {
            if (String.IsNullOrEmpty(src))
            {
                return String.Empty;
            }
            var data = new byte[src.Length >> 1];
            for (var i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(((AsciiStringMap[src[i << 1] - '0'] << 4) | (AsciiStringMap[src[(i << 1) + 1] - '0'])) ^ Mask);
            }
            return Encoding.ASCII.GetString(data);
        }


        /// <summary>
        /// Determine if specific <paramref name="input"/> is a valid SSN
        /// </summary>
        /// <param name="input">A input expected to be in SSN format</param>
        /// <returns>
        ///     <c>True</c> if <paramref name="input"/> is in SSN format. <c>False</c> otherwise
        /// </returns>
        public static bool IsValidSsn(this string input)
        {
            // SSN should format like xxx-xx-xxxx or xxxxxxxxx
            string pattern = @"^\d{3}-?\d{2}-?\d{4}$";
            return !String.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, pattern, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Determine if specific <paramref name="input"/> is a valid email
        /// </summary>
        /// <param name="input">A input expected to be in email format</param>
        /// <returns>
        ///     <c>True</c> if <paramref name="input"/> is in email format. <c>False</c> otherwise
        /// </returns>
        public static bool IsValidEmail(this string input)
        {
            return !String.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, ConstantsManager.EmailPattern, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Generate a xml format Id list from id collection
        /// </summary>
        /// <param name="ids">id collection</param>
        /// <returns>xml id list in format "<IdList><Item Id="1"/><Item Id="2"/></IdList>"</returns>
        public static string ToIntIdListXml(this IEnumerable<int> ids)
        {
            var element = ids.ToIntIdListXElement();
            return element != null ? element.ToString() : null;
        }

        /// <summary>
        /// Generate a xml format Id list from id collection
        /// </summary>
        /// <param name="ids">id collection</param>
        /// <returns>xml id list in format "<IdList><Item Id="1"/><Item Id="2"/></IdList>"</returns>
        public static string ToBigIntIdListXml(this IEnumerable<long> ids)
        {
            var element = ids.ToBigIntIdListXElement();
            return element != null ? element.ToString() : null;
        }

        /// <summary>
        /// Generate a xml format Id list from id collection
        /// </summary>
        /// <param name="ids">id collection</param>
        /// <returns>xml id list in format "<IdList><Item Id="1"/><Item Id="2"/></IdList>"</returns>
        public static XElement ToIntIdListXElement(this IEnumerable<int> ids)
        {
            return ids == null ? null : ToStringIdListXElement(from id in ids select id.ToString());
        }

        /// <summary>
        /// Generate a xml format Id list from id collection
        /// </summary>
        /// <param name="ids">id collection</param>
        /// <returns>xml id list in format "<IdList><Item Id="1"/><Item Id="2"/></IdList>"</returns>
        public static XElement ToStringIdListXElement(this IEnumerable<string> ids)
        {
            return ids == null ? null : new XElement(ConstantsManager.IdListElementName, from id in ids select new XElement(ConstantsManager.IdListItemName, new XAttribute(ConstantsManager.IdListAttributeName, id)));
        }

        /// <summary>
        /// Generate a xml format Id list from id collection
        /// </summary>
        /// <param name="ids">id collection</param>
        /// <returns>xml id list in format "<IdList><Item Id="1"/><Item Id="2"/></IdList>"</returns>
        public static XElement ToBigIntIdListXElement(this IEnumerable<long> ids)
        {
            return ids == null ? null : ToStringIdListXElement(from id in ids select id.ToString());
        }

        /// <summary>
        /// Parse and int Id collection from the string which created by the method above
        /// </summary>
        public static IEnumerable<int> ExtractIntIdList(this string src)
        {
            if (src == null)
            {
                return null;
            }
            if (src.IsNullOrEmpty())
            {
                return Enumerable.Empty<int>();
            }
            var element = XElement.Parse(src);
            return element.ExtractIntIdList();
        }

        /// <summary>
        /// Parse and int Id collection from the XElement which created by the method above
        /// </summary>
        public static IEnumerable<int> ExtractIntIdList(this XElement src)
        {
            if (src == null)
            {
                return null;
            }
            src.VerifyElementName(ConstantsManager.IdListElementName);
            return from item in src.Elements(ConstantsManager.IdListItemName) select item.GetAttributeInt(ConstantsManager.IdListAttributeName);
        }

        /// <summary>
        /// Parse and long Id collection from the XElement which created by the method above
        /// </summary>
        public static IEnumerable<long> ExtractBigIntIdList(this XElement src)
        {
            if (src == null)
            {
                return null;
            }
            src.VerifyElementName(ConstantsManager.IdListElementName);
            return from item in src.Elements(ConstantsManager.IdListItemName) select item.GetAttributeInt64(ConstantsManager.IdListAttributeName);
        }

        /// <summary>
        /// Parse a comma delimited int id string to int id collection
        /// </summary>
        /// <param name="src">the formated comma delimited string</param>
        /// <param name="skipInvalid">Skip the entry if it is not valid</param>
        /// <returns>parsed id collection</returns>
        public static IEnumerable<int> ExtractIntIdCollection(this string src, bool skipInvalid = false)
        {
            return string.IsNullOrEmpty(src) ? null : src.Split(ConstantsManager.CommaDelimCharArray, StringSplitOptions.RemoveEmptyEntries)
                .Select(idValue =>
                    {
                        int value = default(int);
                        if (!Int32.TryParse(idValue, out value) && !skipInvalid)
                        {
                            throw new ArgumentException("Invalid cast for {0} to be an integer".FormatInvariantCulture(idValue));
                        }
                        return value;
                    });
        }

        /// <summary>
        /// Construct rule Id name dictionary from saved id name string by "GetCommaDelimitedIdNamePairString"
        /// </summary>
        /// <param name="value">the stored ids string value without encryption</param>
        /// <param name="encrypted">Tell the method whether there was encryption in the string field</param>
        /// <returns>the dictionary</returns>
        public static IDictionary<int, string> ExtractIdNameDictionary(this string value, bool encrypted = true)
        {
            if (value.IsNullOrEmpty())
            {
                return null;
            }
            if (IsEmptyIdNameCollection(value))
            {
                return new Dictionary<int, string>();
            }
            return (from items in value.Split(ConstantsManager.CommaDelimCharArray, StringSplitOptions.RemoveEmptyEntries)
                    let fields = items.Split(ConstantsManager.SemiDelimCharArray, StringSplitOptions.RemoveEmptyEntries)
                    select new { Id = Convert.ToInt32(fields[0]), Name = encrypted ? fields[1].DecodeHexString() : fields[1] }).ToDictionary(i => i.Id, i => i.Name);
        }

        /// <summary>
        /// Construct rule Id name dictionary from saved id name string by "GetCommaDelimitedIdNamePairString"
        /// </summary>
        /// <param name="value">the stored ids string value without encryption</param>
        /// <param name="encrypted">Tell the method whether there was encryption in the string field</param>
        /// <returns>the dictionary</returns>
        public static IDictionary<long, string> ExtractBigIntIdNameDictionary(this string value, bool encrypted = true)
        {
            if (value.IsNullOrEmpty())
            {
                return null;
            }
            if (IsEmptyIdNameCollection(value))
            {
                return new Dictionary<long, string>();
            }
            return (from items in value.Split(ConstantsManager.CommaDelimCharArray, StringSplitOptions.RemoveEmptyEntries)
                    let fields = items.Split(ConstantsManager.SemiDelimCharArray, StringSplitOptions.RemoveEmptyEntries)
                    select new { Id = Convert.ToInt64(fields[0]), Name = encrypted ? fields[1].DecodeHexString() : fields[1] }).ToDictionary(i => i.Id, i => i.Name);
        }

        /// <summary>
        /// return the string value indicating the empty collection for ToCommaDelimIdNameString
        /// </summary>
        /// <returns>the empty collection indicator</returns>
        public static string GetEmptyIdNameDictString()
        {
            return ConstantsManager.SemiDelim;
        }

        /// <summary>
        /// To see if the string is indicating empty id name collection 
        /// </summary>
        /// <param name="value">the formated ids string</param>
        /// <returns>bool</returns>
        public static bool IsEmptyIdNameCollection(this string value)
        {
            return value != null && value.Equals(ConstantsManager.SemiDelim, StringComparison.Ordinal);
        }

        /// <summary>
        /// To see if a string is null or empty string
        /// </summary>
        /// <param name="src">the string</param>
        /// <returns>bool</returns>
        public static bool IsNullOrEmpty(this string src)
        {
            return String.IsNullOrEmpty(src);
        }

        /// <summary>
        /// wrapper of string.format
        /// </summary>
        /// <param name="src">the string</param>
        /// <param name="values">format params</param>
        /// <returns>bool</returns>
        public static string FormatInvariantCulture(this string src, params object[] values)
        {
            if (src.IsNullOrEmpty())
            {
                throw new ArgumentNullException("src");
            }
            return String.Format(CultureInfo.InvariantCulture, src, values);
        }

        /// <summary>
        /// To see if a string is null or white space
        /// </summary>
        /// <param name="src">the string</param>
        /// <returns>bool</returns>
        public static bool IsNullOrWhiteSpace(this string src)
        {
            return String.IsNullOrWhiteSpace(src);
        }

        /// <summary>
        /// Wrapper of string.Trim
        /// </summary>
        /// <param name="src">The string</param>
        /// <returns>if string is not null or whitespace, return trimmed version; otherwise return null.</returns>
        public static string TrimIfNotNullOrWhiteSpace(this string src)
        {
            return !src.IsNullOrWhiteSpace() ? src.Trim() : null;
        }

        /// <summary>
        /// Wrapper of string.length
        /// </summary>
        /// <param name="src">the string</param>
        /// <returns>if src is not null or whitespace only, then return the actual lengh; otherwise return 0</returns>
        public static int Length(this string src)
        {
            return !src.IsNullOrWhiteSpace() ? src.Trim().Length : 0;
        }

        /// <summary>
        /// Validate string.length
        /// </summary>
        /// <param name="src">the string</param>
        /// <param name="minlenth">min lenth</param>
        /// <param name="maxlenth">max lenth</param>
        /// <param name="isDecimal">if or not need to decide src is or not a decimal</param>
        /// <returns>if src is not null and string length is in range  , then return true; otherwise return false</returns>
        public static bool IsLengthRange(this string src, int maxLength, int minLength = 0, bool isDecimal = false)
        {
            if (!src.IsNullOrWhiteSpace())
            {
                int length = src.Length;
                decimal value;
                return length >= minLength && length <= maxLength && (!isDecimal || decimal.TryParse(src, out value));
            }
            return false;
        }

        /// <summary>
        /// Check if a string is null or white space after html decode
        /// </summary>
        /// <param name="src">the string</param>
        /// <returns>bool</returns>
        public static bool IsHtmlNullOrWiteSpace(this string src)
        {
            return src.HtmlDecode().IsNullOrWhiteSpace();
        }

        /// <summary>
        /// Wrapper for HttpUtility.HtmlDecode
        /// </summary>
        /// <param name="src">the string</param>
        /// <returns>Decoded string</returns>
        public static string HtmlDecode(this string src)
        {
            return src.IsNullOrWhiteSpace() ? String.Empty : HttpUtility.HtmlDecode(src);
        }

        /// <summary>
        /// HttpUtility.HtmlDecode then trim
        /// </summary>
        /// <param name="src">the string</param>
        /// <returns>Decoded string</returns>
        public static string HtmlDecodeWithTrim(this string src)
        {
            return src.IsNullOrWhiteSpace() ? String.Empty : HttpUtility.HtmlDecode(src).Trim();
        }

        /// <summary>
        /// HttpUtility.UrlDecode
        /// </summary>
        /// <param name="src">the string</param>
        /// <returns>Url decoded string</returns>
        public static string UrlDecodeWithTrim(this string src)
        {
            return src.IsNullOrWhiteSpace() ? String.Empty : HttpUtility.UrlDecode(src).Trim();
        }

        /// <summary>
        /// Returns String.Empty if the input is null.
        /// </summary>
        /// <param name="str">The input string.</param>
        public static string EmptyIfNull(this string str)
        {
            return str ?? String.Empty;
        }

        public static string PrepareConvertToNumeric(this string value)
        {
            return value.Replace(@"""", "").TrimIfNotNullOrWhiteSpace();
        }

    }
}
