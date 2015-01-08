<%@ Page Language="C#" AutoEventWireup="true" CodeFile="APMUserGroupList.aspx.cs" Inherits="Administrator_A_PM_APMUserGroupList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server"><meta content="IE=7" http-equiv="X-UA-Compatible" />
  <title>�û�����Ϣ����</title>
   <link href="../../App_Themes/Themes/Css/mainstyle.css" type="text/css"
        rel="stylesheet" />

    <script language="JavaScript" src="../../App_Themes/Themes/JavaScript/Common/Common.js"
        type="text/JavaScript"></script>
    <style>
    .table{
	border: 1px solid #004A6F;
	margin-top: 5px;
	margin-bottom: 5px;
}
    </style>
</head>
<body>
    <form id="submitForm" runat="server">
        <div class="list">
            <table class="table" cellspacing="1" cellpadding="3" width="98%" align="center" border="0">
                <tr class="fieldinput">
                    <td class="fieldname" colspan="3">
<strong>�û�����Ϣ����</strong>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvRecordList" runat="server" AutoGenerateColumns="False" CellSpacing="1"
                CellPadding="5" Width="98%" HorizontalAlign="Center" CssClass="table"
                OnDataBinding="gvRecordList_DataBinding" OnDataBound="gvRecordList_DataBound"
                OnRowDataBound="gvRecordList_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="�û�����">
                        <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                        <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "UserGroupID")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�û���">
                         <ItemStyle CssClass="fieldinput"  HorizontalAlign="Center" />
                        <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "UserGroupName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                        <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />
                        <ItemTemplate>
                             <%# "<a href=../../Administrator/A_BM/APMUserGroupPurviewEdit.aspx?UserGroupID=" + DataBinder.Eval(Container.DataItem, "UserGroupID") + " >�޸�Ȩ��</a>"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ObjectID" HeaderText="ObjectID" Visible="False" />
                </Columns>
            </asp:GridView>
             <table class="table" cellspacing="1" cellpadding="5" width="98%" align="center" border="0">
                <tr>
                    <td class="fieldinput" colspan="7" height="18">
                        <div align="right">
                            <asp:Button ID="btnFirstPage" runat="server" Text="��һҳ" OnClick="btnFirstPage_Click" />
                            <asp:Button ID="btnPrePage" runat="server" Text="��һҳ" OnClick="btnPrePage_Click" />
                            <asp:Button ID="btnNextPage" runat="server" Text="��һҳ" OnClick="btnNextPage_Click" />
                            <asp:Button ID="btnLastPage" runat="server" Text="���һҳ" OnClick="btnLastPage_Click" />
                            <asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:Label ID="lblPageInfo" runat="server" Text="ÿҳ{0}����¼����ǰ��<b><span class=tx>{1}</span>/{2}</b>����<b><span id=recordcount>{3}</span></b>����¼��"></asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
