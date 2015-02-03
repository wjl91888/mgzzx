<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ComboTreeViewControl.ascx.cs"
    Inherits="ComboTreeViewControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadComboBox ID="ComboTreeView" runat="server" Height="240px" ShowToggleImage="True" horizontalalignment="Left">
    <ItemTemplate>
        <telerik:RadTreeView ID="ColumnTreeView" runat="server">
        </telerik:RadTreeView>
    </ItemTemplate>
    <Items>
        <telerik:RadComboBoxItem Text="" />
    </Items>
</telerik:RadComboBox>
<div class="clearboth"></div>
<script language="javascript" type="text/javascript">
     Sys.Application.add_load(function () {
        SetComboTreeViewText_<%= TreeView.ClientID %>();
    });
    function SetComboTreeViewText_<%= TreeView.ClientID %>()
    {
        var tree = $find("<%= TreeView.ClientID %>");
        var nodes = tree.get_checkedNodes();
        var strArr = new Array();
        for (var i = 0; i < nodes.length; i++) {
            if (nodes[i].get_nodes().length > 0) continue;
            strArr.push(nodes[i].get_text());
        }
        var comboTreeView = $find("<%= ComboTreeView.ClientID %>");
        comboTreeView.set_text(strArr.join(","));
    }
</script>
