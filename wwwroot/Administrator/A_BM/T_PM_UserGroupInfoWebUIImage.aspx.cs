/****************************************************** 
FileName:T_PM_UserGroupInfoWebUIImage.aspx.cs
******************************************************/
using System;
using RICH.Common;
using RICH.Common.BM.T_PM_UserGroupInfo;

public partial class T_PM_UserGroupInfoWebUIImage : RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoWebUI
{
     protected override void Page_Init(object sender, EventArgs e)
    {
        base.Page_Init(sender, e);
    }

   //=====================================================================
    //  FunctionName : Page_Load
    /// <summary>
    /// Page_Load
    /// </summary>
    //=====================================================================
    protected override void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            Initalize();
        }
        base.Page_Load(sender, e);
    }

    //=====================================================================
    //  FunctionName : Initalize
    /// <summary>
    /// ÷ÿ‘ÿ≥ı ºªØ∫Ø ˝
    /// </summary>
    //=====================================================================
    protected override void Initalize()
    {
        try
        {
            appData = new T_PM_UserGroupInfoApplicationData();
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            appData.ObjectID = (string)Request.QueryString["ObjectID"];
            QueryRecord();
            if (appData.ResultSet.Tables[0].Rows.Count > 0)
            {
                if (appData.ResultSet.Tables[0].Rows[0][Request.QueryString["ImageField"]] != DBNull.Value)
                {
                    Response.ContentType = "application/octet-stream";
                    Response.BinaryWrite((Byte[])appData.ResultSet.Tables[0].Rows[0][Request.QueryString["ImageField"]]);
                    Response.End();
                }
                else
                {
                    Response.ClearContent();
                    Response.ContentType = "image/Png";
                    Response.BinaryWrite(RICH.Common.GenerateImage.GetStringImage("‘›ŒﬁÕº∆¨", 130, 160, 18, 10, 0).ToArray());
                    Response.End();
                }
            }
            else
            {
                Response.ClearContent();
                Response.ContentType = "image/Png";
                Response.BinaryWrite(RICH.Common.GenerateImage.GetStringImage("‘›ŒﬁÕº∆¨", 130, 160, 18, 10, 0).ToArray());
                Response.End();
            }
        }
        catch (Exception)
        {
            Response.ContentType = "image/Png";
            Response.BinaryWrite(RICH.Common.GenerateImage.GetStringImage("‘›ŒﬁÕº∆¨", 130, 160, 18, 10, 0).ToArray());
            Response.End();
        }
    }
}

