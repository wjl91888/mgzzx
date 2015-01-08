using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using RICH.Common;
using RICH.Common.LM;
using Telerik.Web.UI;

public partial class UploadFileControl : System.Web.UI.UserControl
{
    public string Width { get; set; }

    public string Text { get; set; }

    public string Message { get; set; }

    private FileUploadLibrary.UploadFileType uploadFileType = FileUploadLibrary.UploadFileType.ALL_FILE_TYPE;
    public FileUploadLibrary.UploadFileType UploadFileType
    {
        get
        {
            return uploadFileType;
        }
        set
        {
            uploadFileType = value;
        }
    }


    private bool multipleFileSelection = false;
    public bool MultipleFileSelection
    {
        get
        {
            return multipleFileSelection;
        }
        set
        {
            multipleFileSelection = value;
        }
    }

    private int initialFileInputsCount = 1;
    public int InitialFileInputsCount
    {
        get
        {
            return initialFileInputsCount;
        }
        set
        {
            initialFileInputsCount = value;
        }
    }

    private int maxFileInputsCount = 1;
    public int MaxFileInputsCount
    {
        get
        {
            return maxFileInputsCount;
        }
        set
        {
            maxFileInputsCount = value;
        }
    }

    private int uploadImageMaxHeight = 100;
    public int UploadImageMaxHeight
    {
        get
        {
            return uploadImageMaxHeight;
        }
        set
        {
            uploadImageMaxHeight = value;
        }
    }

    protected void Page_Init(object sender,EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //RadAsyncUploadControl.OnClientValidationFailed = "{0}ValidationFailed".FormatInvariantCulture(RadAsyncUploadControl.ClientID);
        //RadAsyncUploadControl.OnClientValidationFailed = "{0}FileUploaded".FormatInvariantCulture(RadAsyncUploadControl.ClientID);
        RadAsyncUploadControl.InitialFileInputsCount = InitialFileInputsCount;
        RadAsyncUploadControl.MaxFileInputsCount = MaxFileInputsCount;
        RadAsyncUploadControl.MultipleFileSelection = MultipleFileSelection ? Telerik.Web.UI.AsyncUpload.MultipleFileSelection.Automatic : Telerik.Web.UI.AsyncUpload.MultipleFileSelection.Disabled;
        RadAsyncUploadControl.InitialFileInputsCount = InitialFileInputsCount;
        switch (UploadFileType)
        {
            case FileUploadLibrary.UploadFileType.IMAGE_FILE_TYPE:
                RadAsyncUploadControl.AllowedFileExtensions = ConstantsManager.UPLOAD_IMAGE_FORMAT.Split(new char[]{','});
                break;
            case FileUploadLibrary.UploadFileType.MEDIA_FILE_TYPE:
                RadAsyncUploadControl.AllowedFileExtensions = ConstantsManager.UPLOAD_MEDIA_FORMAT.Split(new char[] { ',' });
                break;
            case FileUploadLibrary.UploadFileType.DOC_FILE_TYPE:
                RadAsyncUploadControl.AllowedFileExtensions = ConstantsManager.UPLOAD_DOC_FORMAT.Split(new char[] { ',' });
                break;
            case FileUploadLibrary.UploadFileType.ALL_FILE_TYPE:
                RadAsyncUploadControl.AllowedFileExtensions = ConstantsManager.UPLOAD_ALL_FORMAT.Split(new char[]{','});
                break;
            default:
                RadAsyncUploadControl.AllowedFileExtensions = ConstantsManager.UPLOAD_ALL_FORMAT.Split(new char[] { ',' });
                break;
        }
        if (!IsPostBack)
        {
            if (File.Exists(Text))
            {
                using (var stream = new FileStream(Text, FileMode.Open, FileAccess.Read))
                {
                    FillImageData(stream);
                }
                ImageRadBinaryImage.Visible = true;
            }
            else
            {
                ImageRadBinaryImage.Visible = false;
            }
        }
    }

    protected void RadAsyncUploadControl_OnFileUploaded(object sender, FileUploadedEventArgs e)
    {
        using (Stream stream = e.File.InputStream)
        {
            byte[] imageData = new byte[stream.Length];
            stream.Read(imageData, 0, (int)stream.Length);
            FillImageData(stream);
            ImageRadBinaryImage.Visible = true;
        }
    }

    public bool Upload()
    {
        bool error = true;
        if (RadAsyncUploadControl.UploadedFiles.Count > 0)
        {
            string strVirtualPath;
            int maxSize;
            switch (UploadFileType)
            {
                case FileUploadLibrary.UploadFileType.IMAGE_FILE_TYPE:
                    strVirtualPath = ConstantsManager.UPLOAD_IMAGE_DIR;
                    maxSize = ConstantsManager.UPLOAD_IMAGE_SIZE  * 1024 * 1024;
                    break;
                case FileUploadLibrary.UploadFileType.MEDIA_FILE_TYPE:
                    strVirtualPath = ConstantsManager.UPLOAD_VIDEO_DIR;
                    maxSize = ConstantsManager.UPLOAD_MEDIA_SIZE * 1024 * 1024;
                    break;
                case FileUploadLibrary.UploadFileType.DOC_FILE_TYPE:
                    strVirtualPath = ConstantsManager.UPLOAD_DOC_DIR;
                    maxSize = ConstantsManager.UPLOAD_DOC_SIZE * 1024 * 1024;
                    break;
                case FileUploadLibrary.UploadFileType.ALL_FILE_TYPE:
                default:
                    strVirtualPath = ConstantsManager.UPLOAD_OTHER_DIR;
                    maxSize = ConstantsManager.UPLOAD_ALL_SIZE * 1024 * 1024;
                    break;
            }
            strVirtualPath = "{0}/{1}/{2}".FormatInvariantCulture(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR, strVirtualPath, IDGenerateManager.UploadDirectoryNameGenerate());
            var uploadPath = Server.MapPath(strVirtualPath);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            foreach (UploadedFile uploadedFile in RadAsyncUploadControl.UploadedFiles)
            {
                var file = uploadedFile;
                if (file != null)
                {
                    var extName = file.GetExtension().ToLower();
                    var existExtName = RadAsyncUploadControl.AllowedFileExtensions.Any(ext => extName.Equals(ext, StringComparison.OrdinalIgnoreCase));
                    if (!existExtName)
                    {
                        Message = "文件{0}格式错误".FormatInvariantCulture(file.FileName);
                        error = false;
                    }
                    if (file.ContentLength >= maxSize)
                    {
                        Message = "文件{0}大小限制在{1}MB之内".FormatInvariantCulture(file.FileName, maxSize / (1024 * 1024));
                        error = false;
                    }
                    else
                    {
                        var uploadFileName = "{0}.{1}".FormatInvariantCulture(IDGenerateManager.UploadFileNameGenerate(), extName);
                        var fullFileName = Path.Combine(uploadPath, uploadFileName);
                        file.SaveAs(fullFileName, true);
                        Text = "{0}{1}".FormatInvariantCulture(strVirtualPath, uploadFileName);
                        //记录日志开始
                        string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };
                        string strLogTypeID = "A01";
                        strMessageParam[0] = Session[ConstantsManager.SESSION_USER_LOGIN_NAME].ToString();
                        strMessageParam[1] = Text;
                        string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0013, strMessageParam);
                        LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
                        //记录日志结束
                    }
                }
            }
        }
        return error;
    }

    private void FillImageData(Stream imageStream)
    {
        Image image = null;
        try
        {
            image = Image.FromStream(imageStream);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                if (image.Height > UploadImageMaxHeight)
                {
                    image = ResizeByHeight(image, UploadImageMaxHeight);
                }
                image.SaveJpegWithQualitySetting(memoryStream, 95);
                ImageRadBinaryImage.DataValue = memoryStream.GetBuffer();
            }
        }
        finally
        {
            if (image != null)
            {
                image.Dispose();
            }
        }
    }

    public static Image ResizeByHeight(Image img, int newHeight)
    {
        if (img == null)
        {
            return null;
        }
        var percentW = ((float)img.Width / (float)img.Height);
        var bmp = new Bitmap((int)(newHeight * percentW), newHeight);
        using (var g = Graphics.FromImage(bmp))
        {
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
            return bmp;
        }
    }
}
