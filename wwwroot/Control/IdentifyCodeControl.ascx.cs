using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RICH.Common;

public partial class Control_IdentifyCodeControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        imgIdentifyCode.ImageUrl = ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/Page/IdentifyCode.aspx";
    }
    protected void btnChangeIdentifyCode_Click(object sender, EventArgs e)
    {
        imgIdentifyCode.ImageUrl = ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/Page/IdentifyCode.aspx";
    }
}
