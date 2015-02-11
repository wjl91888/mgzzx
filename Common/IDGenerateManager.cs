using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace RICH.Common
{
    /// <summary>
    /// Summary description for IDGenerateManager
    /// </summary>
    public class IDGenerateManager
    {
        public static string UploadFileNameGenerate()
        {
            return DateTime.Now.ToString("yyyyMMddhhmmssfff");
        }

        public static string UploadDirectoryNameGenerate()
        {
            return DateTime.Now.ToString("yyyy/MM/dd/");
        }
    }
}