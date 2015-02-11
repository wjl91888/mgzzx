using System;
using RICH.Common;

public partial class Page_UplaodFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            txtImageURL.Style.Add("display", "none");
        }
    }

    protected void btnImageFileUpload_Click(object sender, EventArgs e)
    {
        FileUploadLibrary uploadFileLibrary = new FileUploadLibrary();
        uploadFileLibrary.UploadFile(uploadImageFile, (int)FileUploadLibrary.UploadFileType.NO_RESTRICT);
        if (uploadFileLibrary.SuccessFlag)
        {
            txtImageURL.Text = uploadFileLibrary.UploadPath;
            lblStatus.Text = "文件上传成功。";
        }
        else
        {
            txtImageURL.Text = uploadFileLibrary.MessageInfo;
            lblStatus.Text = uploadFileLibrary.MessageInfo;
        }
    }
}
