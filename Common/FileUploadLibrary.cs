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
                            //ͼ���ļ�
                        case (int)UploadFileType.IMAGE_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_IMAGE_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_IMAGE_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_IMAGE_SIZE;
                            break;
                            //��ý���ļ�
                        case (int)UploadFileType.MEDIA_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_VIDEO_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_MEDIA_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_MEDIA_SIZE;
                            break;
                            //�ĵ��ļ�
                        case (int)UploadFileType.DOC_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_DOC_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_DOC_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_DOC_SIZE;
                            break;
                            //�����ļ�
                        case (int)UploadFileType.ALL_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_OTHER_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_ALL_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_ALL_SIZE;
                            break;
                            //����������
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
                            MessageInfo = "�ϴ��ļ���СӦ��" + intFileSize.ToString() + "MB֮��";
                        }
                    }
                    else
                    {
                        SuccessFlag = false;
                        MessageInfo = "�ϴ��ļ���ʽӦΪ" + strFileFormat;
                    }
                }
                catch (Exception)
                {
                    SuccessFlag = false;
                    MessageInfo = "�ϴ��ļ�����";
                }
            }
            else
            {
                // Notify the user that a file was not uploaded.
                SuccessFlag = false;
                MessageInfo = "û�п��ϴ��ļ���";
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
                            //ͼ���ļ�
                        case (int)UploadFileType.IMAGE_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_IMAGE_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_IMAGE_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_IMAGE_SIZE;
                            break;
                            //��ý���ļ�
                        case (int)UploadFileType.MEDIA_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_VIDEO_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_MEDIA_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_MEDIA_SIZE;
                            break;
                            //�ĵ��ļ�
                        case (int)UploadFileType.DOC_FILE_TYPE:
                            strVirtualPath = "/" + ConstantsManager.UPLOAD_DOC_DIR + "/";
                            strFileFormat = ConstantsManager.UPLOAD_DOC_FORMAT;
                            intFileSize = ConstantsManager.UPLOAD_DOC_SIZE;
                            break;
                            //�����ļ�
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
                            MessageInfo = "�ϴ��ļ���СӦ��" + intFileSize.ToString() + "MB֮��";
                        }
                    }
                    else
                    {
                        SuccessFlag = false;
                        MessageInfo = "�ϴ��ļ���ʽӦΪ" + strFileFormat;
                    }
                }
                catch (Exception)
                {
                    SuccessFlag = false;
                    MessageInfo = "�ϴ��ļ�����";
                }
            }
            else
            {
                // Notify the user that a file was not uploaded.
                SuccessFlag = false;
                MessageInfo = "û�п��ϴ��ļ���";
            }
        }
    } 
}
