using System;
using RICH.Common;

public partial class Administrator_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsMobileDevice() && !string.IsNullOrWhiteSpace(Request.QueryString["lcode"]))
        {
            Response.Redirect("/App/index.aspx?lcode={0}".FormatInvariantCulture(Request.QueryString["lcode"]));
        }
    }
}
