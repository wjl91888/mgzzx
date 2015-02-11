using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.LM;
using Telerik.Web.UI;

public partial class UploadFilesControl : System.Web.UI.UserControl
{
    private RadAsyncUpload RadUploadFilesControl { get; set; }

    public string Width { get; set; }
    public Color BackColor { get; set; }
    public bool ReadOnly { get; set; }
    private List<string> Files { get; set; }
    public string Text
    {
        set
        {
            FileName.Value = value;
            Files = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            FilesList.DataSource = Files;
            FilesList.DataBind();
        }
        get
        {
            if (FileName.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length > 0)
            {
                return FileName.Value;
            }
            return null;
        }
    }

    public string Message { get; set; }

    public Telerik.Web.UI.AsyncUpload.MultipleFileSelection MultipleFileSelection
    {
        get
        {
            return RadUploadFilesControl.MultipleFileSelection;
        }
        set
        {
            RadUploadFilesControl.MultipleFileSelection = value;
        }
    }

    public int InitialFileInputsCount
    {
        get
        {
            return RadUploadFilesControl.InitialFileInputsCount;
        }
        set
        {
            RadUploadFilesControl.InitialFileInputsCount = value;
        }
    }

    public int MaxFileInputsCount
    {
        get
        {
            return RadUploadFilesControl.MaxFileInputsCount;
        }
        set
        {
            RadUploadFilesControl.MaxFileInputsCount = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public bool Upload()
    {
        bool error = true;
        if (RadAsyncUploadControl.UploadedFiles.Count > 0)
        {
            string strVirtualPath;
            int maxSize;
            strVirtualPath = ConstantsManager.UPLOAD_OTHER_DIR;
            maxSize = ConstantsManager.UPLOAD_ALL_SIZE * 1024 * 1024;
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
                    //var existExtName = RadAsyncUploadControl.AllowedFileExtensions.Any(ext => extName.Equals(ext, StringComparison.OrdinalIgnoreCase));
                    //if (!existExtName)
                    //{
                    //    Message = "<p>文件{0}格式错误</p>".FormatInvariantCulture(file.FileName);
                    //    error = false;
                    //}
                    if (file.ContentLength >= maxSize)
                    {
                        Message = "<p>文件{0}大小限制在{1}MB之内</p>".FormatInvariantCulture(file.FileName, maxSize / (1024 * 1024));
                        error = false;
                    }
                }
            }
            if (error)
            {
                Files = FileName.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (UploadedFile uploadedFile in RadAsyncUploadControl.UploadedFiles)
                {
                    var file = uploadedFile;
                    if (file != null)
                    {
                        var extName = file.GetExtension().ToLower();
                        var uploadFileName = "{0}_{1}{2}".FormatInvariantCulture(file.GetNameWithoutExtension(), DateTime.Now.ToString("yyMMddhhmmss"), extName);
                        var fullFileName = Path.Combine(uploadPath, uploadFileName);
                        file.SaveAs(fullFileName, true);
                        var filename = "{0}{1}".FormatInvariantCulture(strVirtualPath, uploadFileName);
                        Files.Add(filename);
                    }
                }
                Text = string.Join(",", Files);
                //记录日志开始
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0013, new string[] { (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], Text });
                LogLibrary.LogWrite("A01", strLogContent, null, null, null);
                //记录日志结束
            }
        }
        return error;
    }


    protected void FilesList_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("REMOVE"))
        {
            var removevalue = e.CommandArgument.ToString();
            Text = Text.Replace(removevalue, string.Empty);
        }
    }

    protected string GetFileName(string url)
    {
        return url.Substring(url.LastIndexOf('/') + 1);
    }
}
