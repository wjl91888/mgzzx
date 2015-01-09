using System.Web.Security;

namespace RICH.Common
{

    /// <summary>
    /// Summary description for SecurityManager
    /// </summary>
    public class SecurityManager
    {
        public static string MD5(string strCodeString, int intCodeLength)
        {
            switch (intCodeLength)
            {
                case 16:
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(strCodeString, "MD5").ToLower().Substring(8, 16);
                case 32:
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(strCodeString, "MD5").ToLower();
                default:
                    return "00000000000000000000000000000000";
            }
        }
    }
}