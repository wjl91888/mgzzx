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

        private string VirtualPath = string.Empty;
        private string PhysicalPath = string.Empty;
        private int FileSize = 0;
        private string FileFormat = string.Empty;

        public FileUploadLibrary()
        {
            SuccessFlag = false;
        }

        private void InitialUploadFileInfo(int intFileType)
        {
            switch (intFileType)
            {
                //ͼ���ļ�
                case (int)UploadFileType.IMAGE_FILE_TYPE:
                    VirtualPath = "/" + ConstantsManager.UPLOAD_IMAGE_DIR + "/";
                    FileFormat = ConstantsManager.UPLOAD_IMAGE_FORMAT;
                    FileSize = ConstantsManager.UPLOAD_IMAGE_SIZE;
                    break;
                //��ý���ļ�
                case (int)UploadFileType.MEDIA_FILE_TYPE:
                    VirtualPath = "/" + ConstantsManager.UPLOAD_VIDEO_DIR + "/";
                    FileFormat = ConstantsManager.UPLOAD_MEDIA_FORMAT;
                    FileSize = ConstantsManager.UPLOAD_MEDIA_SIZE;
                    break;
                //�ĵ��ļ�
                case (int)UploadFileType.DOC_FILE_TYPE:
                    VirtualPath = "/" + ConstantsManager.UPLOAD_DOC_DIR + "/";
                    FileFormat = ConstantsManager.UPLOAD_DOC_FORMAT;
                    FileSize = ConstantsManager.UPLOAD_DOC_SIZE;
                    break;
                //�����ļ�
                case (int)UploadFileType.ALL_FILE_TYPE:
                    VirtualPath = "/" + ConstantsManager.UPLOAD_OTHER_DIR + "/";
                    FileFormat = ConstantsManager.UPLOAD_ALL_FORMAT;
                    FileSize = ConstantsManager.UPLOAD_ALL_SIZE;
                    break;
                //����������
                case (int)UploadFileType.NO_RESTRICT:
                    VirtualPath = "/" + ConstantsManager.UPLOAD_OTHER_DIR + "/";
                    FileSize = ConstantsManager.UPLOAD_ALL_SIZE;
                    break;
            }
        }

        public void UploadFile(FileUpload uploadFile, int intFileType, bool boolOrgFileName = false)
        {
            string strFileName = string.Empty;
            string strFileExtName = string.Empty;
            string strFileFullName = string.Empty;
            SuccessFlag = false;

            if (uploadFile.HasFile && !uploadFile.FileName.IsNullOrWhiteSpace())
            {
                try
                {
                    InitialUploadFileInfo(intFileType);
                    VirtualPath = VirtualPath + IDGenerateManager.UploadDirectoryNameGenerate();
                    strFileExtName = Path.GetExtension(uploadFile.FileName).ToLower().Replace(".", "");
                    strFileName = boolOrgFileName 
                        ? uploadFile.FileName
                        : "{0}.{1}".FormatInvariantCulture(IDGenerateManager.UploadFileNameGenerate(), strFileExtName);
                    if (FileFormat.IndexOf(strFileExtName) >= 0 || intFileType == (int)UploadFileType.NO_RESTRICT)
                    {
                        if (uploadFile.FileBytes.Length <= FileSize * 1024 * 1024)
                        {
                            PhysicalPath = HostingEnvironment.MapPath(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + VirtualPath);
                            if (PhysicalPath != null)
                            {
                                if (!Directory.Exists(PhysicalPath))
                                {
                                    Directory.CreateDirectory(PhysicalPath);
                                }
                                strFileFullName = "{0}{1}".FormatInvariantCulture(PhysicalPath, strFileName);
                                uploadFile.SaveAs(strFileFullName);
                                UploadPath = "{0}{1}{2}".FormatInvariantCulture(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR, VirtualPath, strFileName);
                                SuccessFlag = true;
                            }
                        }
                        else
                        {
                            MessageInfo = "�ϴ��ļ���СӦ��{0}MB֮��".FormatInvariantCulture(FileSize);
                        }
                    }
                    else
                    {
                        MessageInfo = "�ϴ��ļ���ʽӦΪ��{0}".FormatInvariantCulture(FileFormat);
                    }
                }
                catch (Exception ex)
                {
                    MessageInfo = "�ϴ��ļ�����{0}".FormatInvariantCulture(ex.Message);
                }
            }
            else
            {
                MessageInfo = "û�п��ϴ��ļ���";
            }
        }
    } 
}
