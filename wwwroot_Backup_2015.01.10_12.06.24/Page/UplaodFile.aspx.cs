using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.LM;
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
        if (uploadFileLibrary.SuccessFlag == true)
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
