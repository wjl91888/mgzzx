using System;
using System.Web.Hosting;
using System.Web.UI.WebControls;
using System.IO;

namespace RICH.Common
{
    /// <summary>
    /// Summary description for UploadFileLibrary
    /// </summary>
    public class FileUploadLibrary
    {
        public enum UploadFileType
        {
            NO_RESTRICT = 0,
            IMAGE_FILE_TYPE = 1,
            MEDIA_FILE_TYPE = 2,
            DOC_FILE_TYPE = 3,
            ALL_FILE_TYPE = 4
        }

        public bool SuccessFlag { get; private set; }
        public string MessageInfo { get; private set; }
        public string UploadPath { get; private set; }

        public FileUploadLibrary()
        {
            SuccessFlag = false;
        }

        public void UploadFile(FileUpload uploadFile, int intFileType)
        {
            string strVirtualPath = string.Empty;
            string strPhysicalPath = string.Empty;
            string strFileName = string.Empty;
            string strFileExtName = string.Empty;
            string strFileFullName = string.Empty;
            int intFileSize = 0;
            string strFileFormat = string.Empty;

            if (uploadFile.HasFile && DataValidateManager.ValidateFileNameFormat(uploadFile.FileName))
            {
                try
                {
                    switch (intFileType)
                    {
                            //图像文件
                        case (int)UploadFileType.IMAGE_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_IMAGE_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_IMAGE_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_IMAGE_SIZE;
                            break;
                            //多媒体文件
                        case (int)UploadFileType.MEDIA_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_VIDEO_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_MEDIA_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_MEDIA_SIZE;
                            break;
                            //文档文件
                        case (int)UploadFileType.DOC_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_DOC_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_DOC_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_DOC_SIZE;
                            break;
                            //其他文件
                        case (int)UploadFileType.ALL_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_OTHER_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_ALL_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_ALL_SIZE;
                            break;
                            //无类型限制
                        case (int)UploadFileType.NO_RESTRICT:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_OTHER_DIR + "/";
                            intFileSize = ConstantsManager.UPLOAD_ALL_SIZE;
                            break;
                    }
                    //strFileName = uploadFile.FileName.Split('.')[0];
                    strVirtualPath = strVirtualPath + IDGenerateManager.UploadDirectoryNameGenerate();
                    strFileName = IDGenerateManager.UploadFileNameGenerate();
                    strFileExtName = Path.GetExtension(uploadFile.FileName).ToLower().Replace(".", "");
                    if (strFileFormat.IndexOf(strFileExtName) >= 0 || intFileType == (int)UploadFileType.NO_RESTRICT)
                    {
                        if (uploadFile.FileBytes.Length <= intFileSize * 1024 * 1024)
                        {
                            strPhysicalPath = HostingEnvironment.MapPath(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + strVirtualPath);
                            if (Directory.Exists(strPhysicalPath) == false)
                            {
                                Directory.CreateDirectory(strPhysicalPath);
                            }
                            strFileFullName = strPhysicalPath + strFileName + "." + strFileExtName;
                            uploadFile.SaveAs(strFileFullName);
                            UploadPath = ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + strVirtualPath + strFileName + "." + strFileExtName;
                            SuccessFlag = true;
                        }
                        else
                        {
                            SuccessFlag = false;
                            MessageInfo = "上传文件大小应在" + intFileSize.ToString() + "MB之内";
                        }
                    }
                    else
                    {
                        SuccessFlag = false;
                        MessageInfo = "上传文件格式应为" + strFileFormat;
                    }
                }
                catch (Exception)
                {
                    SuccessFlag = false;
                    MessageInfo = "上传文件出错";
                }
            }
            else
            {
                // Notify the user that a file was not uploaded.
                SuccessFlag = false;
                MessageInfo = "没有可上传文件。";
            }
        }

        public void UploadFile(FileUpload uploadFile, int intFileType, bool boolOrgFileName)
        {
            string strVirtualPath = string.Empty;
            string strPhysicalPath = string.Empty;
            string strFileName = string.Empty;
            string strFileExtName = string.Empty;
            string strFileFullName = string.Empty;
            int intFileSize = 0;
            string strFileFormat = string.Empty;

            if (uploadFile.HasFile == true && DataValidateManager.ValidateFileNameFormat(uploadFile.FileName) == true)
            {
                try
                {
                    switch (intFileType)
                    {
                            //图像文件
                        case (int)UploadFileType.IMAGE_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_IMAGE_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_IMAGE_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_IMAGE_SIZE;
                            break;
                            //多媒体文件
                        case (int)UploadFileType.MEDIA_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_VIDEO_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_MEDIA_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_MEDIA_SIZE;
                            break;
                            //文档文件
                        case (int)UploadFileType.DOC_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_DOC_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_DOC_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_DOC_SIZE;
                            break;
                            //其他文件
                        case (int)UploadFileType.ALL_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_OTHER_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_ALL_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_ALL_SIZE;
                            break;
                    }
                    //strFileName = uploadFile.FileName.Split('.')[0];
                    strVirtualPath = strVirtualPath + IDGenerateManager.UploadDirectoryNameGenerate();
                    strFileName = IDGenerateManager.UploadFileNameGenerate().Substring(0, 8) + uploadFile.FileName.Split('.')[0].ToLowerInvariant();
                    strFileExtName = uploadFile.FileName.Split('.')[1].ToLowerInvariant();
                    if (strFileFormat.IndexOf(strFileExtName) >= 0)
                    {
                        if (uploadFile.FileBytes.Length <= intFileSize * 1024 * 1024)
                        {
                            strPhysicalPath = HostingEnvironment.MapPath(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + strVirtualPath);
                            if (Directory.Exists(strPhysicalPath) == false)
                            {
                                DirectoryInfo dirInfo = Directory.CreateDirectory(strPhysicalPath);
                            }
                            strFileFullName = strPhysicalPath + strFileName + "." + strFileExtName;
                            uploadFile.SaveAs(strFileFullName);
                            UploadPath = ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + strVirtualPath + strFileName + "." + strFileExtName;
                            SuccessFlag = true;
                        }
                        else
                        {
                            SuccessFlag = false;
                            MessageInfo = "上传文件大小应在" + intFileSize.ToString() + "MB之内";
                        }
                    }
                    else
                    {
                        SuccessFlag = false;
                        MessageInfo = "上传文件格式应为" + strFileFormat;
                    }
                }
                catch (Exception)
                {
                    SuccessFlag = false;
                    MessageInfo = "上传文件出错";
                }
            }
            else
            {
                // Notify the user that a file was not uploaded.
                SuccessFlag = false;
                MessageInfo = "没有可上传文件。";
            }
        }
    } 
}
