using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;
using RICH.Common.Utilities;
using RICH.Common;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FlexPaperViewerContainer.Visible = false;
            var fileUrl = Request.QueryString["file"];
            if (!fileUrl.IsHtmlNullOrWiteSpace())
            {
                var filefullname = Server.MapPath(fileUrl);
                if (File.Exists(filefullname))
                {
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
                        case "jpeg":
                        case "jpg":
                        case "png":
                        case "gif":
                            FlexPaperViewerContainer.Visible = true;
                            ConvertDocToSwf(filefullname);
                            break;
                        default:
                            FlexPaperViewerContainer.Visible = false;
                            MessageLabel.Text = "暂不支持{0}文件的预览，请直接下载。".FormatInvariantCulture(filetype);
                            return;
                    }
                }
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
                case "jpeg":
                case "jpg":
                    SwfFileName = PictureToSwf(jpeg2swfToolPath, filefullname, SWFFilePath);
                    break;
                case "png":
                    SwfFileName = PictureToSwf(png2swfToolPath, filefullname, SWFFilePath);
                    break;
                case "gif":
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
}