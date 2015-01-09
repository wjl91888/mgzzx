<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UplaodFile.aspx.cs" Inherits="Page_UplaodFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><meta content="IE=7" http-equiv="X-UA-Compatible" />
    <title>文件上传</title>
    <style type="text/css">
    body{font-size:12px; background-color: #ffffff;}
    .button{width:60px;text-align:center;font-size:12px;margin-right:20px;padding-top:2px;}    
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%">
                <tr>
                    <td width="100%">
                        请选择要上传的文件：
                        <asp:HyperLink ID="linkImageURL" runat="server" Text="下载当前文件" Target="_blank"></asp:HyperLink>
                        <asp:TextBox ID="txtImageURL" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:FileUpload ID="uploadImageFile" runat="server" />
                        <asp:Button ID="btnImageFileUpload" runat="server" Text="上传文件" OnClick="btnImageFileUpload_Click"
                            CssClass="button" /><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblStatus"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center">
                        <input type="button" value="确定" onclick="SelectUploadFile()" class="button" />
                        <input type="button" value="取消" onclick="closeParentUploadFileLayer()" class="button" />
                    </td>
                </tr>
            </table>

            <script language="Javascript" type="text/javascript">
            var ofileurlField = null;
            var sfileurlName = "<%=Request.QueryString["Param"]%>" ;
            ofileurlField = parent.document.getElementsByName(sfileurlName)[0];
            if (document.getElementById("txtImageURL").value == null || document.getElementById("txtImageURL").value == "")
            {
                document.getElementById("txtImageURL").value = ofileurlField.value;
                document.getElementById("linkImageURL").href = ofileurlField.value;
            }
            
            function SelectUploadFile()
            {
                ofileurlField.value = document.getElementById("txtImageURL").value;
                closeParentUploadFileLayer();
            }
            
            function closeParentUploadFileLayer()
            {
                var uploadfileframeid = "uploadFileLayer";
                var uploadfilebackgroundframeid = "uploadFileBackgroundLayer";
                objUploadFile = parent.document.getElementById(uploadfileframeid);
                objUploadFileBackground = parent.document.getElementById(uploadfilebackgroundframeid);
	            objUploadFile.style.display="none";
	            objUploadFileBackground.style.display="none";
            }
            </script>

        </div>
    </form>
</body>
</html>
