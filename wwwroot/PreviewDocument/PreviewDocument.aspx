<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreviewDocument.aspx.cs"
    Inherits="PreviewDocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="../App_Themes/Themes/JavaScript/jQuery/jquery-1.4.2.js"></script>
    <script type="text/javascript" src="../App_Themes/Themes/JavaScript/FlexPaper/flexpaper_flash.js"></script>
</head>
<body style="margin: 0 auto;">
    <form id="form1" runat="server">
    <asp:Label ID="MessageLabel" runat="server"></asp:Label>
    <asp:HiddenField ID="SwfFileNameHiddenField" runat="server" />
    <div id="FlexPaperViewerContainer" runat="server">
        <div id="viewerPlaceHolder" style="width: 1024px; height: 100%; display: block; margin:0 auto;">
        </div>
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
