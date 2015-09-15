<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIDetail.aspx.cs.xsl'"/>
<xsl:template match="/">
using System;
using System.Data;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>;
using Telerik.Web.UI;

namespace App
{
    public partial class <xsl:value-of select="/NewDataSet/TableName"/>WebUIDetail : RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>WebUI
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Initalize();
            }
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            // 读取记录详细资料
            appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
            appData.ObjectID = ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            Header.DataBind();
            rptDetail.DataSource = appData.ResultSet;
            rptDetail.DataBind();

            if (!IsPostBack)
            {
                foreach (DataRow drTemp in appData.ResultSet.Tables[0].Rows)
                {
                    //记录日志开始
                    string strLogTypeID = "A10";
                    strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                    strMessageParam[1] = "<xsl:value-of select="/NewDataSet/TableRemark"/>";
                    strMessageParam[2] = drTemp["<xsl:value-of select="/NewDataSet/TitleField"/>"].ToString();
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0012, strMessageParam);
                    RICH.Common.LM.LogLibrary.LogWrite(strLogTypeID, strLogContent, null, drTemp["ObjectID"].ToString(), null);
                    //记录日志结束
                }
            }
        }

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                foreach (RepeaterItem item in rptDetail.Items)
                {
        <xsl:for-each select="/NewDataSet/CustomPermissionFieldConfig">
            <xsl:if test="CustomPermissionType = 'SearchPage'">
                <xsl:if test="Hidden = 'true'">
                    if(CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
                    {
                        var <xsl:value-of select="FieldName"/>Control = item.FindControl("<xsl:value-of select="FieldName"/>Container");
                        if (<xsl:value-of select="FieldName"/>Control != null) 
                        {
                            <xsl:value-of select="FieldName"/>Control.Visible = false;
                        }
                    }</xsl:if></xsl:if></xsl:for-each>
                }
            }
            else
            {
                rptDetail.Visible = false;
            }
        }
    }
}
</xsl:template>
</xsl:stylesheet>
