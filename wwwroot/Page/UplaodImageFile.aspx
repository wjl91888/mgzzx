<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UplaodImageFile.aspx.cs"
    Inherits="Page_UplaodImageFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><meta content="IE=7" http-equiv="X-UA-Compatible" />
    <title>图片文件上传</title>
    <style type="text/css">
    body{font-size:12px; background-color: #ffffff;}
    .button{width:60px;text-align:center;font-size:12px;margin-right:20px;padding-top:2px;}    
    </style>

    <script language="javascript" type="text/javascript">
    function ZoomImage()
    {
        maxWidth = 200;
        Pic=document.body.getElementsByTagName("img");
        for(i=0;i<Pic.length;i++)
        {
            if(Pic[i].width>maxWidth)
            {
                Pic[i].height=Pic[i].height*maxWidth/Pic[i].width;
                Pic[i].width=maxWidth;
            }
        }
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%">
                <tr>
                    <td width="100%">
                        请选择要上传的图片文件：
                        <asp:HyperLink ID="linkImageURL" runat="server" Text="下载当前图片" Target="_blank"></asp:HyperLink>
                        <asp:TextBox ID="txtImageURL" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:FileUpload ID="uploadImageFile" runat="server" />
                        <asp:Button ID="btnImageFileUpload" runat="server" Text="上传图片" OnClick="btnImageFileUpload_Click"
                            CssClass="button" /><br />
                    </td>
                </tr>
                <tr height="150">
                    <td align="center">
                        <asp:Image ID="imagePreview" runat="server" ImageUrl="~/App_Themes/Themes/Image/nopic_supply.gif"
                            AlternateText="预览图片文件" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <input type="button" value="确定" onclick="SelectUplaodImageFile()" class="button" />
                        <input type="button" value="取消" onclick="closeParentUplaodImageFileLayer()" class="button" />
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
                document.getElementById("imagePreview").src = ofileurlField.value;
            }
            
            function SelectUplaodImageFile()
            {
                ofileurlField.value = document.getElementById("txtImageURL").value;
                closeParentUplaodImageFileLayer();
            }
            
            function closeParentUplaodImageFileLayer()
            {
                var UplaodImageFileframeid = "UplaodImageFileLayer";
                var UplaodImageFilebackgroundframeid = "UplaodImageFileBackgroundLayer";
                objUplaodImageFile = parent.document.getElementById(UplaodImageFileframeid);
                objUplaodImageFileBackground = parent.document.getElementById(UplaodImageFilebackgroundframeid);
	            objUplaodImageFile.style.display="none";
	            objUplaodImageFileBackground.style.display="none";
            }
            </script>

        </div>
    </form>
</body>
</html>
