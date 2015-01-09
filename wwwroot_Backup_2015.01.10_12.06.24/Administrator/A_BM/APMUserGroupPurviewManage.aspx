<%@ Page Language="C#" AutoEventWireup="true" CodeFile="APMUserGroupPurviewManage.aspx.cs"
    Inherits="APMUserGroupPurviewManage" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><meta content="IE=7" http-equiv="X-UA-Compatible" />
    <title>�û���Ȩ���޸�</title>
    <link href="../../App_Themes/Themes/Css/mainstyle.css" type="text/css"
        rel="stylesheet" />
    <style>
    .table{
	border: 1px solid #004A6F;
	margin-top: 5px;
	margin-bottom: 5px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
        <div class="list">
            <table class="table" cellspacing="1" cellpadding="4" width="98%" align="center" border="0">
                <tr class="fieldname">
                    <td class="fieldname" colspan="4">
                        �û��������Ϣ
                    </td>
                </tr>
                <tr>
                    <td class="fieldinput CaptionClass">
                        <div align="right">
                            �û�������
                        </div>
                    </td>
                    <td class="fieldinput ContentClass">
                        <span id="span_ClassName">
                            <asp:Label ID="lblUserGroupName" runat="server" Text="Label" Width="150px"></asp:Label>
                        </span>
                    </td>
                    <td class="fieldinput CaptionClass">
                        <div align="right">
                            �û�����
                        </div>
                    </td>
                    <td class="fieldinput ContentClass">
                        <span id="span1">
                            <asp:Label ID="lblUserGroupID" runat="server" Text="Label" Width="150px"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="fieldinput CaptionClass">
                        <div align="right">
                            �û�����
                        </div>
                    </td>
                    <td class="fieldinput ContentClass" colspan="3">
                        <span id="span2">
                            <asp:Label ID="lblUserGroupContent" runat="server" Text="Label"></asp:Label>
                        </span>
                    </td>
                </tr>
            </table>
            <table class="table" cellspacing="1" cellpadding="4" width="98%" align="center" border="0">
                <tr class="fieldname">
                    <td class="fieldname" colspan="4">
                        �û���Ȩ���޸�
                        <asp:RadioButtonList ID="rblPurviewPRI" AutoPostBack="true" runat="server" BackColor="White" OnSelectedIndexChanged="rblPurviewPRI_SelectedIndexChanged" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Repeater ID="PurviewRepeater" runat="server">
                            <ItemTemplate>
                                <RICH:CheckBoxListEx ID="PurviewCheckBoxList" runat="server" ></RICH:CheckBoxListEx>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Table ID="tbPurviewInfo" runat="server" CssClass="table fieldinput" CellSpacing="1"
                            CellPadding="4" Width="98%" align="center" border="0">
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td class="fieldinput" colspan="4">
                        <div style="text-align: center">
                            <asp:Button ID="btnSetPurview" runat="server" Text="�����û���Ȩ��" OnClick="btnSetPurview_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
