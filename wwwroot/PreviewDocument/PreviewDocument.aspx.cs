using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;
using RICH.Common.Utilities;
using RICH.Common;
using Ionic.Zip;

public partial class PreviewDocument : System.Web.UI.Page
{
    private const string PdfFilePathUrl = "../Media/PDF/";
    private string PdfFilePath = HttpContext.Current.Server.MapPath("../Media/PDF/");
    private const string SWFFilePathUrl = "../Media/SWF/";
    private string SWFFilePath = HttpContext.Current.Server.MapPath("../Media/SWF/");
    private string pdf2swfToolPath = HttpContext.Current.Server.MapPath("FlexPaper/pdf2swf.exe");
    private string png2swfToolPath = HttpContext.Current.Server.MapPath("FlexPaper/png2swf.exe");
    private string jpeg2swfToolPath = HttpContext.Current.Server.MapPath("FlexPaper/jpeg2swf.exe");
    private string gif2swfToolPath = HttpContext.Current.Server.MapPath("FlexPaper/gif2swf.exe");
    private string[] filelist
    {
        get
        {
            var fileUrls = HttpUtility.UrlDecode(Request.QueryString["file"]);
            if (!fileUrls.IsNullOrWhiteSpace())
            {
                return fileUrls.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FlexPaperViewerContainer.Visible = false;
            PackageDownload.Visible = false;
            if (filelist.IsNullOrEmpty())
            {
                return;
            }
            FilesList.DataSource = filelist;
            FilesList.DataBind();
            var fileUrl = filelist[0];
            if (Request.QueryString["a"] == "d")
            {
                if (filelist.Length > 1)
                {
                    DownloadPackage();
                }
                Response.Redirect(fileUrl);
            }
            if (filelist.Length > 1)
            {
                PackageDownload.Visible = true;
            }
            Prieview(fileUrl);
        }
    }

    private void Prieview(string fileUrl)
    {
        var filefullname = Server.MapPath(fileUrl);
        if (File.Exists(filefullname))
        {
            if (this.IsMobileDevice())
            {
                Response.Redirect(fileUrl);
            }
            string filetype = Path.GetExtension(filefullname).ToLower();
            switch (filetype)
            {
                case ".pdf":
                case ".pptx":
                case ".ppt":
                case ".xlsx":
                case ".xls":
                case ".docx":
                case ".doc":
                case ".jpeg":
                case ".jpg":
                case ".png":
                case ".gif":
                    FlexPaperViewerContainer.Visible = true;
                    try
                    {
                        ConvertDocToSwf(filefullname);
                    }
                    catch (Exception)
                    {
                        FlexPaperViewerContainer.Visible = false;
                        MessageLabel.Text = "不支持此文件预览，请直接下载。".FormatInvariantCulture(filetype);
                        Response.Redirect(fileUrl);
                    }
                    break;
                default:
                    FlexPaperViewerContainer.Visible = false;
                    MessageLabel.Text = "暂不支持{0}文件的预览，请直接下载。".FormatInvariantCulture(filetype);
                    Response.Redirect(fileUrl);
                    return;
            }
        }
    }

    protected void ConvertDocToSwf(string filefullname)
    {
        string SwfFileName = String.Empty;
        string filename = Path.GetFileName(filefullname);
        string filenamewithoutext = Path.GetFileNameWithoutExtension(filefullname);
        string filepath = Path.GetDirectoryName(filefullname) + @"\";
        string filetype = Path.GetExtension(filefullname).ToLower();
        var swffilename = "{0}{1}.swf".FormatInvariantCulture(SWFFilePath, filenamewithoutext);
        if (File.Exists(swffilename))
        {
            this.SwfFileNameHiddenField.Value = "{0}{1}.swf".FormatInvariantCulture(SWFFilePathUrl, filenamewithoutext);
        }
        else
        {
            switch (filetype)
            {
                case ".pdf":
                    SwfFileName = PdfToSwf(pdf2swfToolPath, filepath, filename, SWFFilePath);
                    break;
                case ".pptx":
                case ".ppt":
                case ".xlsx":
                case ".xls":
                case ".docx":
                case ".doc":
                    {
                        string PdfFileName = OfficeToPdf(filefullname, PdfFilePath);
                        if (PdfFileName == "")
                        {
                            this.MessageLabel.Text = "不支持的该Office文件类型到pdf的转化";
                            return;
                        }
                        SwfFileName = PdfToSwf(pdf2swfToolPath, PdfFilePath, PdfFileName, SWFFilePath);
                        string pdffilename = PdfFilePath + PdfFileName;
                        if (File.Exists(pdffilename))
                        {
                            File.Delete(PdfFilePath + PdfFileName);
                        }
                    }
                    break;
                case ".jpeg":
                case ".jpg":
                    SwfFileName = PictureToSwf(jpeg2swfToolPath, filefullname, SWFFilePath);
                    break;
                case ".png":
                    SwfFileName = PictureToSwf(png2swfToolPath, filefullname, SWFFilePath);
                    break;
                case ".gif":
                    SwfFileName = PictureToSwf(gif2swfToolPath, filefullname, SWFFilePath);
                    break;
                default:
                    this.MessageLabel.Text = "不支持的文件类型->" + filetype;
                    return;
            }
            if (SwfFileName.IsHtmlNullOrWiteSpace())
            {
                this.MessageLabel.Text = "不支持的该文件类型到swf的转化";
            }
            else
            {
                this.MessageLabel.Text = "";
                this.SwfFileNameHiddenField.Value = SWFFilePathUrl + SwfFileName;
            }
        }
    }

    private string OfficeToPdf(string fullPathName, string destPath)
    {
        string fileNameWithoutEx = Path.GetFileNameWithoutExtension(fullPathName);
        string extendName = Path.GetExtension(fullPathName).ToLower();
        string saveName = destPath + fileNameWithoutEx + ".pdf";
        string returnValue = fileNameWithoutEx + ".pdf";
        switch (extendName)
        {
            case ".doc":
            case ".docx":
                PreviewDocumetHelper.WordToPDF(fullPathName, saveName);
                break;
            case ".ppt":
            case ".pptx":
                PreviewDocumetHelper.PowerPointToPDF(fullPathName, saveName);
                break;
            case ".xls":
            case ".xlsx":
                PreviewDocumetHelper.ExcelToPDF(fullPathName, saveName);
                break;
            default:
                returnValue = "";
                break;
        }
        return returnValue;
    }

    private string PdfToSwf(string pdf2swfPath, string PdfPath, string PdfName, string destPath)
    {
        string fullPathName = PdfPath + PdfName;
        string fileNameWithoutEx = Path.GetFileNameWithoutExtension(fullPathName);
        string extendName = Path.GetExtension(fullPathName).ToLower();
        string saveName = destPath + fileNameWithoutEx + ".swf";
        string returnValue = fileNameWithoutEx + ".swf"; ;
        if (extendName != ".pdf")
        {
            returnValue = "";
        }
        else
        {
            PreviewDocumetHelper.PDFToSWF(pdf2swfPath, fullPathName, saveName);
        }
        return returnValue;
    }

    private string PictureToSwf(string toolpath, string fullPathName, string destPath)
    {
        string fileNameWithoutEx = Path.GetFileNameWithoutExtension(fullPathName);
        string extendName = Path.GetExtension(fullPathName).ToLower();
        string saveName = destPath + fileNameWithoutEx + ".swf";
        string returnValue = fileNameWithoutEx + ".swf";
        if (extendName == ".gif")
        {
            PreviewDocumetHelper.GifPicturesToSwf(toolpath, fullPathName, saveName);
        }
        else
        {
            PreviewDocumetHelper.PicturesToSwf(toolpath, fullPathName, saveName);
        }
        return returnValue;
    }

    protected string GetFileName(string url)
    {
        return url.Substring(url.LastIndexOf('/') + 1);
    }

    protected void FilesList_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("PREVIEW"))
        {
            var fileUrl = e.CommandArgument.ToString();
            Prieview(fileUrl);
        }
    }

    protected void PackageDownload_Click(object sender, EventArgs e)
    {
        DownloadPackage();
    }

    private void DownloadPackage()
    {
        if (filelist.IsNullOrEmpty())
        {
            return;
        }
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.BufferOutput = false;
        HttpContext.Current.Response.ContentType = "application/zip";
        HttpContext.Current.Response.AddHeader("content-disposition", @"attachment;filename=""{0}.zip""".FormatInvariantCulture(DateTime.Now.ToString("yyyyMMddhhmmssfff")));
        using (var zip = new ZipFile(System.Text.Encoding.Default))
        {
            foreach (var fileUrl in filelist)
            {
                var filefullname = Server.MapPath(fileUrl);
                if (File.Exists(filefullname))
                {
                    zip.AddFile(filefullname, "");
                }
            }
            zip.Save(HttpContext.Current.Response.OutputStream);
        }
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.SuppressContent = true;
        HttpContext.Current.Response.OutputStream.Close();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
}