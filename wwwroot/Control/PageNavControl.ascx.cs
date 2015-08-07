using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.LM;
using RICH.Common.PM;
using Telerik.Web.UI;

public partial class PageNavControl : System.Web.UI.UserControl
{
    public string CurrentUrl
    {
        get
        {
            var url = Request.Url.AbsoluteUri;
            return url.IndexOf("?") < 0 ? "{0}?1=1".FormatInvariantCulture(url) : url;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        InitalPage();
    }

    
    private void InitalPage()
    {
    }

    protected void Page_Init(object sender, EventArgs e)
    {
    }
}