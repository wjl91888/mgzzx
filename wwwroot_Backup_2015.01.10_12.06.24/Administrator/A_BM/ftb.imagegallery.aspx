<%@ Page Language="C#" ValidateRequest="false" Trace="false" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<script runat="server">
    protected void Page_Load(Object Src, EventArgs E)
    {

        // *** remove this return statement to use the following code ***
        string currentFolder = ImageGallery1.CurrentImagesFolder;
        ImageGallery1.CurrentImagesFolder = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";
        if (Request["rif"] == ("~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/")
            && Request["cif"] == ("~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/")
            )
        {
            CreateDirectory(ImageGallery1.CurrentImagesFolder);
            ImageGallery1.RootImagesFolder = ImageGallery1.CurrentImagesFolder;
            ImageGallery1.AcceptedFileTypes = new string[] { "gif", "jpg", "bmp", "png", "jpeg" };
            return;
        }
        else
        {
            Response.Write("您没有权限操作此目录。");
            Response.End();
        }
        return;        

        
        // modify the directories allowed
        if (currentFolder == "~/Media/Image/FreeTextBox")
        {

            // these are the default directories FTB:ImageGallery will find
            string[] defaultDirectories = System.IO.Directory.GetDirectories(Server.MapPath(currentFolder), "*");

            // user defined custom directories
            string[] customDirectories = new string[] { "folder1", "folder2" };

            // the gallery will use these images in this instance
            ImageGallery1.CurrentDirectories = customDirectories;
        }


        // modify the images allowed
        if (currentFolder == "~/Media/Image/FreeTextBox")
        {

            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(Server.MapPath(currentFolder));

            // these are the default images FTB:ImageGallery will find
            System.IO.FileInfo[] defaultImages = directoryInfo.GetFiles("*");

            // user defined custom images (here, we're just allowing the first two)
            System.IO.FileInfo[] customImages = new System.IO.FileInfo[2] { defaultImages[0], defaultImages[1] };

            // the gallery will use these images in this instance
            ImageGallery1.CurrentImages = customImages;
        }
    }
    public static void CreateDirectory(string strVirtualPath)
    {
        string strPhysicalPath;
        strPhysicalPath = System.Web.Hosting.HostingEnvironment.MapPath(strVirtualPath);
        if (!System.IO.Directory.Exists(strPhysicalPath))
        {
            System.IO.Directory.CreateDirectory(strPhysicalPath);
        }
    }

</script>

<html>
<head>
    <title>Image Gallery</title>
</head>
<body>
    <form id="Form1" runat="server" enctype="multipart/form-data">
        <FTB:ImageGallery ID="ImageGallery1" JavaScriptLocation="ExternalFile" UtilityImagesLocation="ExternalFile"
            SupportFolder="~/aspnet_client/FreeTextBox/" AllowImageDelete="false" AllowImageUpload="true"
            AllowDirectoryCreate="false" AllowDirectoryDelete="false" runat="Server" />
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
function test()
{
    for(i=0;i<=document.getElementById('Form1').getElementsByTagName('td').length;i++)
    {
        switch(document.getElementById('Form1').getElementsByTagName('td').item(i).innerText)
        {
            case "Status":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "状态";
                break;
            case "Upload File":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "选择本地文件";
                break;
            case "Create Folder":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "创建目录";
                break;
            case "Preview":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "预览";
                break;
            case "Dimensions":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "图像大小信息";
                break;
            case "Original Size":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "原始大小";
                break;
            case "Custom Size":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "自定义大小";
                break;
            case "Percentage":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "百分率";
                break;
            case "Properties":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "属性";
                break;
            case "Align":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "位置";
                break;
            case "Border":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "边框";
                break;
            case "VSpace":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "状态";
                break;
            case "HSpace":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "状态";
                break;
            case "Alt":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "注释";
                break;
            case "Title":
                document.getElementById('Form1').getElementsByTagName('td').item(i).innerText = "标题";
                break;
        }
    }
}
//test();
</script>

