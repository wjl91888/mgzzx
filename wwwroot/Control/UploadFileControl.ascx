<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploadFileControl.ascx.cs" Inherits="UploadFileControl" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadAjaxManagerProxy ID="ramUploadFileControl" runat="server">
    <AjaxSettings>

    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div class="UploadFileControl">
    <div>
        <telerik:RadAsyncUpload CssClass="RadAsyncUploadControl" ID="RadAsyncUploadControl" runat="server"
            OnFileUploaded="RadAsyncUploadControl_OnFileUploaded"></telerik:RadAsyncUpload>
        <asp:Literal ID="Description" runat="server"></asp:Literal>
        <div class="colorred <%=ramUploadFileControl.ClientID %>logofileerrormessage width400"></div>
    </div>
    <div class="margintop10">
        <telerik:RadBinaryImage ID="ImageRadBinaryImage" runat="server" />
    </div>
</div>
<telerik:RadCodeBlock ID="UploadFileControlRadCodeBlock" runat="server">
    <script type="text/javascript">
        function <%=RadAsyncUploadControl.ClientID %>FileUploaded(sender, args) {
            $find('<%=ramUploadFileControl.ClientID %>').ajaxRequest();
            $(".<%=RadAsyncUploadControl.ClientID %>logofileerrormessage").hide();
        }
        function <%=RadAsyncUploadControl.ClientID %>ValidationFailed(sender, args) {
            var upload = $find("<%= RadAsyncUploadControl.ClientID %>");
            upload.deleteAllFileInputs();
            $(".<%=RadAsyncUploadControl.ClientID %>logofileerrormessage").html("<p>123123</p>");
            $(".<%=RadAsyncUploadControl.ClientID %>logofileerrormessage").show();
        }
        $(".<%=RadAsyncUploadControl.ClientID %>logofileerrormessage").hide();
    </script>
</telerik:RadCodeBlock>

