<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportWord.aspx.cs" Inherits="Administrator_ImportWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/Themes/Css/mainstyle.css" rev="stylesheet" rel="stylesheet" type="text/css" media="screen" charset="gb2312" />
    <script type="text/javascript" src="../App_Themes/Themes/JavaScript/UploadFile/UploadFile.js" language="javascript" charset="gb2312"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="InfoFromDoc" runat="server" CssClass="input"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Preview" onclick="Button2_Click" />
    </div>
    </form>
</body>
</html>
