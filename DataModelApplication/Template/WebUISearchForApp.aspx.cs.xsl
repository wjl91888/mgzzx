<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUISearchForApp.aspx.cs.xsl'"/>
<xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>WebUISearchForApp.aspx.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Web.UI;
using RICH.Common;
using RICH.Common.Utilities;
using RICH.Common.Base.WebUI;
using RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>;
using Telerik.Web.UI;

namespace App
{
    public partial class <xsl:value-of select="/NewDataSet/TableName"/>WebUISearch : RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>WebUI
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Initalize();
                InitFilterData();
            }
            CurrentAjaxManager.AjaxRequest += AjaxManager_AjaxRequest;
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            DetailPage = true;
            // 数据查询
            appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
            QueryRecord();
            rptList.DataSource = appData.ResultSet;
            rptList.DataBind();
            ViewState["RecordCount"] = appData.RecordCount;
            ViewState["CurrentPage"] = appData.CurrentPage;
            ViewState["PageSize"] = appData.PageSize;
            ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
            InitPageInfo();
        }
<![CDATA[
        protected void InitFilterData()
        {
            var dataSourceCollection = new List<Pair<string, List<Triples<string, string, string>>>>();]]>
    <xsl:for-each select="/NewDataSet/RecordInfo">
        <xsl:if test="IsAppFilter = 'true'"><xsl:if test="IsAdvanceSearch = 'true'"><xsl:if test="IsDataBind = 'true'">
<![CDATA[            dataSourceCollection.Add(new Pair<string, List<Triples<string, string, string>>>("]]><xsl:value-of select="AppFilterRemarkName"/><![CDATA[", GetList_]]><xsl:value-of select="FieldName"/><![CDATA[_AdvanceSearch()));]]>
                    </xsl:if></xsl:if></xsl:if></xsl:for-each>
<![CDATA[            NavList.DataSource = dataSourceCollection;
        }
]]>
        protected void AjaxManager_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            switch (e.Argument)
            {
                case "Refresh":
                    Initalize();
                    break;
                default:
                    break;
            }
        }

        protected override Boolean GetQueryInputParameter()
        {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // 验证输入参数
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsAppFilter = 'true'">
    <xsl:if test="IsAdvanceSearch = 'true'">
    <xsl:choose>
      <xsl:when test="IsBatchSearch = 'true'">
            validateData = Validate<xsl:value-of select="FieldName"/>Batch(Request["<xsl:value-of select="FieldName"/>"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/>Batch = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
      </xsl:when>
      <xsl:when test="IsMoreItemSearch = 'true'">
            validateData = Validate<xsl:value-of select="FieldName"/>Batch(Request["<xsl:value-of select="FieldName"/>"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/>Batch = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
      </xsl:when>
      <xsl:when test="IsRangeSearch = 'true'">
            validateData = Validate<xsl:value-of select="FieldName"/>Begin(Request["<xsl:value-of select="FieldName"/>Begin"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/>Begin = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
            validateData = Validate<xsl:value-of select="FieldName"/>End(Request["<xsl:value-of select="FieldName"/>End"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/>End = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
            <xsl:if test="IsApproximateSearch = 'true'">
            if(!DataValidateManager.ValidateIsNull(Request["<xsl:value-of select="FieldName"/>"]))
            {
                appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>);
            }
            </xsl:if>
            <xsl:if test="IsApproximateSearch = 'false'">
            validateData = Validate<xsl:value-of select="FieldName"/>(Request["<xsl:value-of select="FieldName"/>"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
            </xsl:if>
      </xsl:when>
      <xsl:when test="DBType = 'Image'">
      </xsl:when>
      <xsl:when test="ControlType = 'RICH多选框'">
            validateData = Validate<xsl:value-of select="FieldName"/>(Request["<xsl:value-of select="FieldName"/>"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
      </xsl:when>
      <xsl:otherwise>
            validateData = Validate<xsl:value-of select="FieldName"/>(Request["<xsl:value-of select="FieldName"/>"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
      </xsl:otherwise>
    </xsl:choose>
        <xsl:if test="IsSubItemSearch = 'true'">
            validateData = Validate<xsl:value-of select="FieldName"/>(Request["<xsl:value-of select="FieldName"/>"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                        appData.<xsl:value-of select="FieldName"/> = null;
                        appData.<xsl:value-of select="FieldName"/>Batch = GetSubItem_<xsl:value-of select="FieldName"/>(validateData.Value.ToString()) + "," + validateData.Value.ToString();
                }
            }
        </xsl:if>
    </xsl:if>
    </xsl:if>
</xsl:for-each>
            if (!string.IsNullOrWhiteSpace(Request["SearchKeywords"]))
            {
                appData.<xsl:value-of select="/NewDataSet/TitleField"/> = Convert.ToString(Request["SearchKeywords"]);
            }

            if (!DataValidateManager.ValidateIsNull(ViewState["QueryType"]))
            {
                if (!DataValidateManager.ValidateStringFormat(ViewState["QueryType"].ToString()))
                {
                    appData.QueryType = "AND";
                }
                else
                {
                    appData.QueryType = ViewState["QueryType"].ToString();
                }
            }
            else
            {
                appData.SortField = "AND";
            }
            if (!DataValidateManager.ValidateIsNull(ViewState["Sort"]))
            {
                if (!DataValidateManager.ValidateBooleanFormat(ViewState["Sort"].ToString()))
                {
                    appData.Sort = DEFAULT_SORT;
                }
                else
                {
                    appData.Sort = Convert.ToBoolean(ViewState["Sort"].ToString());
                }
            }
            else
            {
                appData.Sort = DEFAULT_SORT;
            }
            if (!DataValidateManager.ValidateIsNull(ViewState["SortField"]))
            {
                if (!DataValidateManager.ValidateStringFormat(ViewState["SortField"].ToString()))
                {
                    appData.SortField = DEFAULT_SORT_FIELD;
                }
                else
                {
                    appData.SortField = ViewState["SortField"].ToString();
                }
            }
            else
            {
                appData.SortField = DEFAULT_SORT_FIELD;
            }
            if (!DataValidateManager.ValidateIsNull(ViewState["PageSize"]))
            {
                if (!DataValidateManager.ValidateNumberFormat(ViewState["PageSize"].ToString()))
                {
                    appData.PageSize = DEFAULT_PAGE_SIZE;
                }
                else
                {
                    appData.PageSize = Convert.ToInt32(ViewState["PageSize"].ToString());
                }
            }
            else
            {
                appData.PageSize = DEFAULT_PAGE_SIZE;
            }
            if (!DataValidateManager.ValidateIsNull(ViewState["CurrentPage"]))
            {
                if (!DataValidateManager.ValidateNumberFormat(ViewState["CurrentPage"].ToString()))
                {
                    appData.CurrentPage = DEFAULT_CURRENT_PAGE;
                }
                else
                {
                    appData.CurrentPage = Convert.ToInt32(ViewState["CurrentPage"].ToString());
                }
            }
            else
            {
                appData.CurrentPage = DEFAULT_CURRENT_PAGE;
            }
<xsl:for-each select="/NewDataSet/CustomPermissionFieldConfig">
    <xsl:if test="CustomPermissionType = 'SearchPage'">
        <xsl:if test="Condition = 'true'">
            if(CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
            {
                appData.<xsl:value-of select="FieldName"/> = <xsl:value-of select="ConditionValue"/>;
            }
        </xsl:if></xsl:if>
</xsl:for-each>
            return boolReturn;
        }
    }
}
</xsl:template>
</xsl:stylesheet>