using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RICH.Common;

public partial class Administrator_ImportWord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InfoFromDoc.Attributes.Add("onclick", "uploadfile(this);");

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write(FileLibrary.GetWordPreview(InfoFromDoc.Text, true, true));
    }
}