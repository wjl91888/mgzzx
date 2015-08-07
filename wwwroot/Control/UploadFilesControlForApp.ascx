<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploadFilesControl.ascx.cs"
    Inherits="UploadFilesControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadAjaxManagerProxy ID="ramGridControl" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="FilesList">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="FilesList" />
                <telerik:AjaxUpdatedControl ControlID="FileName" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<asp:HiddenField ID="FileName" runat="server" />
<ul class="list-group">
    <asp:Repeater ID="FilesList" runat="server" OnItemCommand="FilesList_ItemCommand">
        <ItemTemplate>
            <li class="list-group-item"><a href="../../PreviewDocument/PreviewDocument.aspx?a=d&file=<%# HttpUtility.UrlEncode((string)Container.DataItem)%>"
                target="_blank" title="<%# GetFileName((string)Container.DataItem)%>" class="fancyboxmodellink">
                <%# GetFileName((string)Container.DataItem)%></a> </li>
            <li class="button list-group-item <%# ReadOnly ? "hidden" : string.Empty%>">
                <asp:LinkButton ID="Remove" runat="server" CommandName="REMOVE" CommandArgument="<%# Container.DataItem%>"
                    OnClientClick="return confirm('您确定要删除此条数据吗？');" Visible='<%# !ReadOnly%>'>删除</asp:LinkButton>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    <li class="list-group-item <%# ReadOnly ? "hidden" : string.Empty%>">
        <telerik:RadAsyncUpload ID="RadAsyncUploadControl" runat="server" MultipleFileSelection="Automatic"
            AutoAddFileInputs="true" Visible='<%# !ReadOnly%>'>
        </telerik:RadAsyncUpload>
    </li>
</ul>
