<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreviewDocument.aspx.cs"
    Inherits="PreviewDocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="../App_Themes/Themes/JavaScript/jQuery/jquery-1.10.1.min.js"></script>
    <script type="text/javascript" src="../App_Themes/Themes/JavaScript/FlexPaper/flexpaper_flash.js"></script>
    <style>
        .previewfileslist
        {
            max-width:1024px;
            margin: 0 auto;
        }
        .flexpaperviewer
        {
            max-width:1024px;
            margin: 0 auto;
        }
        .previewfileslist ul
        {
            margin: 0px;
            list-style-type: none;
            width: 100%;
            height: 25px;
            padding: 0px;
            padding-top: 10px;
        }
        .previewfileslist ul li
        {
            margin: 0px;
            padding: 0px;
        }
        .previewfileslist ul.alter
        {
            background-color: #e5e5e5;
        }
        .previewfileslist ul li.filename
        {
            list-style-type: none;
            float: left;
            width: 800px;
            overflow: hidden;
            font-size: 14px;
        }
        .previewfileslist ul li.button
        {
            margin: 0px;
            list-style-type: none;
            float: left;
            width: 60px;
            text-align: center;
        }
    </style>
</head>
<body style="margin: 0 auto;">
    <form id="form1" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramGridControl" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="FilesList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="FlexPaperViewerContainer" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <asp:Label ID="MessageLabel" runat="server"></asp:Label>
    <asp:HiddenField ID="SwfFileNameHiddenField" runat="server" />
    <div id="FilesListContainer" runat="server" class="previewfileslist">
        <asp:HiddenField ID="FileName" runat="server" />
        <asp:Repeater ID="FilesList" runat="server" OnItemCommand="FilesList_ItemCommand">
            <ItemTemplate>
                <ul>
                    <li class="filename">
                        <asp:LinkButton ID="Preview" runat="server" CommandName="PREVIEW" ToolTip="<%# GetFileName((string)Container.DataItem)%>" CommandArgument="<%# Container.DataItem%>">
                        <%# GetFileName((string)Container.DataItem)%>
                        </asp:LinkButton>
                    </li>
                    <li class="button"><a href="<%# Container.DataItem%>" target="_blank">下载</a> </li>
                </ul>
            </ItemTemplate>
        </asp:Repeater>
        <div style="text-align:right;"><asp:Button ID="PackageDownload" runat="server" OnClick="PackageDownload_Click" Width="120" Height="30" Text="文件打包下载"/></div>
    </div>
    <div id="FlexPaperViewerContainer" runat="server" class="flexpaperviewer">
        <div id="viewerPlaceHolder" style="max-width: 1024px; height:600px; display: block; margin: 0 auto; padding-top:20px;">
        </div>
        <div style="clear:both"></div>
        <script type="text/javascript">
            var fp = new FlexPaperViewer(
                         'FlexPaper/FlexPaperViewer',
                         'viewerPlaceHolder', { config: {
                             SwfFile: escape($("#SwfFileNameHiddenField").val()),
                             Scale: 0.6,
                             ZoomTransition: 'easeOut',
                             ZoomTime: 0.5,
                             ZoomInterval: 0.2,
                             FitPageOnLoad: true,
                             FitWidthOnLoad: true,
                             PrintEnabled: true,
                             FullScreenAsMaxWindow: false,
                             ProgressiveLoading: false,
                             MinZoomSize: 0.2,
                             MaxZoomSize: 5,
                             SearchMatchAll: false,
                             InitViewMode: 'Portrait',

                             ViewModeToolsVisible: true,
                             ZoomToolsVisible: true,
                             NavToolsVisible: true,
                             CursorToolsVisible: true,
                             SearchToolsVisible: true,

                             localeChain: 'en_US'
                         }
                         });
        </script>
    </div>
    </form>
</body>
</html>
