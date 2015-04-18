<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIImage.aspx.cs.xsl'"/>
<xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>WebUIImage.aspx.cs
******************************************************/
using System;
using RICH.Common;
using RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>;

public partial class <xsl:value-of select="/NewDataSet/TableName"/>WebUIImage : RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>WebUI
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
    /// 重载初始化函数
    /// </summary>
    //=====================================================================
    protected override void Initalize()
    {
        try
        {
            appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
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
                    Response.BinaryWrite(RICH.Common.GenerateImage.GetStringImage("暂无图片", 130, 160, 18, 10, 0).ToArray());
                    Response.End();
                }
            }
            else
            {
                Response.ClearContent();
                Response.ContentType = "image/Png";
                Response.BinaryWrite(RICH.Common.GenerateImage.GetStringImage("暂无图片", 130, 160, 18, 10, 0).ToArray());
                Response.End();
            }
        }
        catch (Exception)
        {
            Response.ContentType = "image/Png";
            Response.BinaryWrite(RICH.Common.GenerateImage.GetStringImage("暂无图片", 130, 160, 18, 10, 0).ToArray());
            Response.End();
        }
    }
}
</xsl:template>
</xsl:stylesheet>
