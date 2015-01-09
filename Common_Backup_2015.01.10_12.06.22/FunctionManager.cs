using System;

namespace RICH.Common
{
    /// <summary>
    /// Summary description for FunctionManager
    /// </summary>
    public static class FunctionManager
    {
        public static int RoundInt(double dblSource)
        {
            if (dblSource != (int)dblSource)
            {
                return (int)dblSource + 1;
            }
            return (int)dblSource;
        }

        public static string LeftFixLengthString(string strSource, int intFixLength)
        {
            byte[] byteSource = System.Text.Encoding.Unicode.GetBytes(strSource);
            int intLength = byteSource.Length;
            System.Text.StringBuilder sbReturn = new System.Text.StringBuilder(string.Empty);
            if (intLength >= intFixLength * 2)
            {
                int intTemp = intFixLength * 2;
                foreach (char charTemp in strSource.ToCharArray())
                {
                    intTemp = System.Text.Encoding.UTF8.GetBytes(charTemp.ToString()).Length == 1
                                  ? intTemp - 1
                                  : intTemp - 2;
                    sbReturn.Append(charTemp);
                    if (intTemp <= 0)
                    {
                        sbReturn.Append("...");
                        break;
                    }
                }
                return sbReturn.ToString();
            }
            return strSource;
        }

        public static string RemoveTags(string strSource)
        {
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "<br>", "\r\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "<br/>", "\r\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "<br />", "\r\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "<[^>]*>", "");
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "&nbsp;", " ", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "&lt;", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "&gt;", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return strSource;
        }

        public static string RemoveTagsToWordTemplate(string strSource)
        {
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "<br>", "\r\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "<br/>", "\r\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "<br />", "\r\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "<[^>]*>", "");
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "\r\n", @"</w:t></w:r></w:p><w:p wsp:rsidR=""00BE08F7"" wsp:rsidRDefault=""009F65CE"" wsp:rsidP=""00BE08F7""><w:pPr><w:rPr><w:rFonts w:ascii=""·ÂËÎ"" w:fareast=""·ÂËÎ"" w:h-ansi=""·ÂËÎ""/><wx:font wx:val=""·ÂËÎ""/><w:sz w:val=""22""/><w:sz-cs w:val=""22""/></w:rPr></w:pPr><w:r wsp:rsidRPr=""00AF0475""><w:rPr><w:rFonts w:ascii=""·ÂËÎ"" w:fareast=""·ÂËÎ"" w:h-ansi=""·ÂËÎ"" w:hint=""fareast""/><wx:font wx:val=""·ÂËÎ""/><w:sz w:val=""22""/><w:sz-cs w:val=""22""/></w:rPr><w:t>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "&nbsp;", " ", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "&lt;", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            strSource = System.Text.RegularExpressions.Regex.Replace(strSource, "&gt;", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return strSource;
        }

        public static string GetAgeByBirthday(string birthday, string currentDate)
        {
            DateTime dateBirthday;
            DateTime dateCuurrent;
            if (DataValidateManager.ValidateDateFormat(birthday))
            {
                dateBirthday =  DateTime.Parse(birthday);
                if (DataValidateManager.ValidateDateFormat(currentDate))
                {
                    dateCuurrent = DateTime.Parse(currentDate);
                }
                else
                {
                    dateCuurrent = DateTime.Now;
                }
                return RoundInt((dateCuurrent - dateBirthday).Days/365).ToString();
            }
            return "0";
        }
    }
}