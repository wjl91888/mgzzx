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
<div class="clearboth"></div>
<div class="uploadfilescontrol">
    <div class="uploadfileslist">
        <asp:HiddenField ID="FileName" runat="server" />
        <asp:Repeater ID="FilesList" runat="server" OnItemCommand="FilesList_ItemCommand">
            <ItemTemplate>
                <ul>
                    <li class="filename">
                        <a href="../../PreviewDocument/PreviewDocument.aspx?a=d&file=<%# HttpUtility.UrlEncode((string)Container.DataItem)%>" target="_blank" title="<%# GetFileName((string)Container.DataItem)%>">
                        <%# GetFileName((string)Container.DataItem)%></a>
                    </li>
                    <li class="button"><a href="../../PreviewDocument/PreviewDocument.aspx?file=<%# HttpUtility.UrlEncode((string)Container.DataItem)%>" target="_blank">预览</a> </li>
                    <li class="button">
                        <asp:LinkButton ID="Remove" runat="server" CommandName="REMOVE" CommandArgument="<%# Container.DataItem%>"
                            OnClientClick="return confirm('您确定要删除此条数据吗？');" Visible='<%# !ReadOnly%>'>删除</asp:LinkButton>
                    </li>
                </ul>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <ul class="alter">
                    <li class="filename">
                        <a href="../../PreviewDocument/PreviewDocument.aspx?a=d&file=<%# HttpUtility.UrlEncode((string)Container.DataItem)%>" target="_blank" title="<%# GetFileName((string)Container.DataItem)%>">
                        <%# GetFileName((string)Container.DataItem)%></a>
                    </li>
                    <li class="button"><a href="/PreviewDocument/PreviewDocument.aspx?file=<%# HttpUtility.UrlEncode((string)Container.DataItem)%>" target="_blank">预览</a> </li>
                    <li class="button">
                        <asp:LinkButton ID="Remove" runat="server" CommandName="REMOVE" CommandArgument="<%# Container.DataItem%>"
                            OnClientClick="return confirm('您确定要删除此条数据吗？');" Visible='<%# !ReadOnly%>'>删除</asp:LinkButton>
                    </li>
                </ul>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </div>
    <div class="clearboth"></div>
    <div class="uploadcontrol">
        <telerik:RadAsyncUpload ID="RadAsyncUploadControl" runat="server" MultipleFileSelection="Automatic"
            AutoAddFileInputs="true" Visible='<%# !ReadOnly%>'>
        </telerik:RadAsyncUpload>
    </div>
</div>
<div class="clearboth"></div>
