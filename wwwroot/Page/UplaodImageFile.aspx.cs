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
public partial class Page_UplaodImageFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            imagePreview.Attributes.Add("onload", "ZoomImage();");
            txtImageURL.Style.Add("display", "none");
        }
    }

    protected void btnImageFileUpload_Click(object sender, EventArgs e)
    {
        FileUploadLibrary uploadFileLibrary = new FileUploadLibrary();
        uploadFileLibrary.UploadFile(uploadImageFile, (int)FileUploadLibrary.UploadFileType.IMAGE_FILE_TYPE);
        if (uploadFileLibrary.SuccessFlag == true)
        {
            txtImageURL.Text = uploadFileLibrary.UploadPath;
            imagePreview.ImageUrl = txtImageURL.Text;
        }
        else
        {
            txtImageURL.Text = uploadFileLibrary.MessageInfo;
        }
    }
    protected void imagePreview_Load(object sender, EventArgs e)
    {
        if (imagePreview.Width.Value >= 200 && imagePreview.Height.Value >= 150)
        {
            double rate = imagePreview.Width.Value / imagePreview.Height.Value;
            if (imagePreview.Width.Value > imagePreview.Height.Value)
            {
                imagePreview.Width = 200;
                imagePreview.Height = Convert.ToUInt16(200 / rate);

            }
            else
            {
                imagePreview.Height = 150;
                imagePreview.Width = Convert.ToUInt16(150 * rate);
            }
        }
        else if (imagePreview.Width.Value >= 200 && imagePreview.Height.Value < 150)
        {
            imagePreview.Width = 200;
        }
        else if (imagePreview.Width.Value < 200 && imagePreview.Height.Value >= 150)
        {
            imagePreview.Height = 150;
        }

    }
}
