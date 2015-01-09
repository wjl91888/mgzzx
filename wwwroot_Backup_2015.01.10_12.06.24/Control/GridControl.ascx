<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GridControl.ascx.cs" Inherits="GridControl" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadAjaxManagerProxy ID="ramGridControl" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnAddOneRow">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridDataBind" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="GridDataBind">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridDataBind" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div class="list" style="overflow:auto; width:100%; float:left;">
    <asp:GridView ID="GridDataBind" runat="server" CssClass="table" CellPadding="5" Width="100%" BorderWidth="0px" AutoGenerateColumns="false" OnDataBound="GridDataBind_DataBound" OnRowCommand="GridDataBind_RowCommand" EmptyDataText="请添加记录"></asp:GridView>
    <div id="operation" runat="server" class="operation" style="float:right !important; text-align:right; border-top:0px; width:100%;">
        <asp:Button runat="server" ID="btnAddOneRow" Text="添加记录" CssClass="button" OnClick="btnAddOneRow_Click" />
    </div>
</div>
