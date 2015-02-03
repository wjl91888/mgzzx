<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TreeViewControl.ascx.cs"
    Inherits="TreeViewControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadTreeView ID="TreeView" runat="server"  horizontalalignment="Left" style="text-align:left !important;">
</telerik:RadTreeView>
<div class="clearboth"></div>
<script language="javascript" type="text/javascript">
    function SetComboTreeViewText_<%= TreeView.ClientID %>()
    {
        if (RefreshGrid !== undefined && typeof RefreshGrid == 'function') {
            RefreshGrid();
        }
    }
</script>
