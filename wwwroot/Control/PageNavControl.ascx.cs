using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.LM;
using RICH.Common.PM;
using RICH.Common.Utilities;
using Telerik.Web.UI;

public partial class PageNavControl : System.Web.UI.UserControl
{
    public string CurrentUrl
    {
        get
        {
            var url = "{0}://{1}{2}".FormatInvariantCulture(Request.Url.Scheme, Request.Url.Authority, Request.Url.AbsolutePath);
            return "{0}?lcode={1}".FormatInvariantCulture(url, Request["lcode"]);
        }
    }

    public List<Pair<string, List<Triples<string, string, string>>>> DataSource
    {
        set
        {
            NavList.DataSource = value;
            NavList.DataBind();
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