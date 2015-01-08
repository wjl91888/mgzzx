using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using RICH.Common;
/// <summary>
/// Summary description for IPAddessLibrary
/// </summary>
namespace RICH.Common.IM
{
    public class IPAddessLibrary
    {
        public IPAddessLibrary()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string GetLocationFromIP(string strIPAddress)
        {
            try
            {
                float floatIPAddress;
                floatIPAddress = ConvertIPAddress(strIPAddress);
                Database db = DatabaseFactory.CreateDatabase("strConnManager");
                string strProcName = "SP_GetLocationFromIP";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@IPAddress", DbType.Single);
                db.AddOutParameter(cmdProc, "@Location", DbType.String, 100);
                db.SetParameterValue(cmdProc, "@IPAddress", floatIPAddress);
                db.ExecuteNonQuery(cmdProc);
                return (string)db.GetParameterValue(cmdProc, "@Location");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static float ConvertIPAddress(string strIPAddress)
        {
            try
            {
                string[] strConvertIP;
                float floatConvertIP;
                strConvertIP = strIPAddress.Trim().Split('.');
                floatConvertIP = float.Parse(strConvertIP[0]) * 256 * 256 * 256
                    + float.Parse(strConvertIP[1]) * 256 * 256
                    + float.Parse(strConvertIP[2]) * 256
                    + float.Parse(strConvertIP[3]);
                return floatConvertIP;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GetRemoteTrueIP()
        {
            try
            {
                if (DataValidateManager.ValidateIsNull(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]) == true)
                {
                    return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetClientInfo()
        {
            try
            {
                string strReturn = string.Empty;
                string strClientInfo;
                strClientInfo = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
                if (strClientInfo.IndexOf("NetCaptor") >= 0)
                {
                    strReturn = "NetCaptor";
                }
                else if (strClientInfo.IndexOf("MSIE 6") >= 0)
                {
                    strReturn = "MSIE 6.x";
                }
                else if (strClientInfo.IndexOf("MSIE 5") >= 0)
                {
                    strReturn = "MSIE 5.x";
                }
                else if (strClientInfo.IndexOf("Netscape") >= 0)
                {
                    strReturn = "Netscape";
                }
                else if (strClientInfo.IndexOf("Opera") >= 0)
                {
                    strReturn = "Opera";
                }
                return strReturn;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
