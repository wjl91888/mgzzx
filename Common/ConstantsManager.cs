using System;
using System.Configuration;
using System.Web;

namespace RICH.Common
{
    /// <summary>
    /// Summary description for Constants
    /// </summary>
    public class ConstantsManager
    {
        public static string ConnectString = ConfigurationManager.AppSettings["strConnManager"];

        #region ��վ������Ϣ����

        #region ��վ��������
        /// <summary>
        /// δ��¼�û�/�ÿ��û����ų���
        /// </summary>
        public static string DEFAULT_GUEST_USERGROUP = ConfigurationManager.AppSettings["DEFAULT_GUEST_USERGROUP"];
        /// <summary>
        /// ��վ����
        /// </summary>
        public static string WEBSITE_NAME = ConfigurationManager.AppSettings["WEBSITE_NAME"];
        /// <summary>
        /// ��Ƶ��������ַ
        /// </summary>
        public static string SERVER_ADDRESS_VIDOE = ConfigurationManager.AppSettings["SERVER_ADDRESS_VIDOE"];
        /// <summary>
        /// WEB��������ַ
        /// </summary>
        public static string SERVER_ADDRESS_WEBSITE = ConfigurationManager.AppSettings["SERVER_ADDRESS_WEBSITE"];
        /// <summary>
        /// ����Ĭ����ҳ
        /// </summary>
        public static string DEFAULT_ADMINISTRATOR_INDEX = ConfigurationManager.AppSettings["DEFAULT_ADMINISTRATOR_INDEX"];
        #endregion

        #region �ϴ��ļ�����
        /// <summary>
        /// Ĭ������ģ���ļ���ʽ
        /// </summary>
        public const string DEFAULT_TEMPLATE_FORMAT = @"html";
        /// <summary>
        /// �ϴ�ͼƬ�ļ���ʽ
        /// </summary>
        public static string UPLOAD_IMAGE_FORMAT = ConfigurationManager.AppSettings["UPLOAD_IMAGE_FORMAT"];
        /// <summary>
        /// �ϴ�ͼƬ�ļ���С(MB)
        /// </summary>
        public static Int32 UPLOAD_IMAGE_SIZE = int.Parse(ConfigurationManager.AppSettings["UPLOAD_IMAGE_SIZE"]);
        /// <summary>
        /// �ϴ���ý���ļ���ʽ
        /// </summary>
        public static string UPLOAD_MEDIA_FORMAT = ConfigurationManager.AppSettings["UPLOAD_MEDIA_FORMAT"];
        /// <summary>
        /// �ϴ���ý���ļ���С(MB)
        /// </summary>
        public static Int32 UPLOAD_MEDIA_SIZE = int.Parse(ConfigurationManager.AppSettings["UPLOAD_MEDIA_SIZE"]);
        /// <summary>
        /// �ϴ��ĵ��ļ���ʽ
        /// </summary>
        public static string UPLOAD_DOC_FORMAT = ConfigurationManager.AppSettings["UPLOAD_DOC_FORMAT"];
        /// <summary>
        /// �ϴ��ĵ��ļ���С(MB)
        /// </summary>
        public static Int32 UPLOAD_DOC_SIZE = int.Parse(ConfigurationManager.AppSettings["UPLOAD_DOC_SIZE"]);
        /// <summary>
        /// �ϴ������ļ���ʽ
        /// </summary>
        public static string UPLOAD_ALL_FORMAT = ConfigurationManager.AppSettings["UPLOAD_ALL_FORMAT"];
        /// <summary>
        /// �ϴ������ļ���С(MB)
        /// </summary>
        public static Int32 UPLOAD_ALL_SIZE = int.Parse(ConfigurationManager.AppSettings["UPLOAD_ALL_SIZE"]);
        #endregion

        #region ��վĿ¼����
        /// <summary>
        /// ϵͳ������Ŀ¼,���治�ܴ�/
        /// </summary>
        public static string WEBSITE_VIRTUAL_ROOT_DIR = ConfigurationManager.AppSettings["WEBSITE_VIRTUAL_ROOT_DIR"];
        /// <summary>
        /// ����Ŀ¼,���治�ܴ�/,��������Ŀ¼
        /// </summary>
        public const string WEBSITE_ADMIN_DIR = @"Administrator";
        /// <summary>
        /// ҳ��ģ��Ŀ¼,���治�ܴ�/,��������Ŀ¼
        /// </summary>
        public const string WEBSITE_TEMPLATE_DIR = @"App_Themes/Template";
        /// <summary>
        /// �û�Ŀ¼
        /// </summary>
        public const string WEBSITE_MEMBER_DIR = @"Member";
        /// <summary>
        /// �����ļ�Ŀ¼
        /// </summary>
        public const string GENERATE_FILE_DIR = @"Content";
        /// <summary>
        /// �ϴ���Ƶ�ļ�
        /// </summary>
        public const string UPLOAD_VIDEO_DIR = @"Media/Video";
        /// <summary>
        /// �ϴ���Ƶ�ļ�
        /// </summary>
        public const string UPLOAD_AUDIO_DIR = @"Media/Audio";
        /// <summary>
        /// �ϴ��ĵ��ļ�
        /// </summary>
        public const string UPLOAD_DOC_DIR = @"Media/Doc";
        /// <summary>
        /// �ϴ�ͼ���ļ�
        /// </summary>
        public const string UPLOAD_IMAGE_DIR = @"Media/Image";
        /// <summary>
        /// �ϴ������ļ�
        /// </summary>
        public const string UPLOAD_OTHER_DIR = @"Media/OtherFile";
        /// <summary>
        /// ���ݿⱸ��Ŀ¼
        /// </summary>
        public const string DATABASE_BACKUP_DIR = @""; 
        #endregion

        #region ע��Ĭ������
        /// <summary>
        /// ע��Ĭ���û���
        /// </summary>
        public static string DEFAULT_REGISTER_USERGROUPID = ConfigurationManager.AppSettings["DEFAULT_REGISTER_USERGROUPID"];
        #endregion

        #region ��֤�����ò���
        /// <summary>
        /// ��֤���ַ���С
        /// </summary>
        public const int IDENTIFY_CODE_FONTSIZE = 9;
        /// <summary>
        /// ��֤�����λ��
        /// </summary>
        public const int IDENTIFY_CODE_LENGTH = 4;
        /// <summary>
        /// ��֤���������
        /// </summary>
        public const int IDENTIFY_CODE_TYPE = 1;
        /// <summary>
        /// ��֤�����ͼ��������������
        /// </summary>
        public const float IDENTIFY_CODE_NOISE_RATE = 0.00001f; 
        #endregion

        #endregion

        #region ϵͳ��������
        /// <summary>
        /// ������ȡ���ز�ѯ���������Ϊ�������ݵ������DataSet������
        /// </summary>
        public const string QUERY_DATASET_NAME = "dsRecordInfo";
        /// <summary>
        /// �ܼ�¼��
        /// </summary>
        public const string RECORD_COUNT = "RecordCount";
        /// <summary>
        /// ������ȡMessageID
        /// </summary>
        public const string MESSAGE_ID = "strMessageID";
        #endregion

        #region SESSION COOKIE������
        /// <summary>
        /// ��֤��Session��
        /// </summary>
        public const string SESSION_IDENTIFY_CODE = "IdentifyCode";
        /// <summary>
        /// ��ǰҳ��Session��
        /// </summary>
        public const string SESSION_CURRENT_PAGE = "CurrentPage";
        /// <summary>
        /// Ҫ��תҳ��Session��
        /// </summary>
        public const string SESSION_REDIRECT_PAGE = "RedirectPage";
        /// <summary>
        /// ��Ҫ��֤Ȩ��Session��
        /// </summary>
        public const string SESSION_CURRENT_PURVIEW = "CurrentPurview";
        /// <summary>
        /// ������ϢSession��/Application��
        /// </summary>
        public const string SESSION_ERR_MESSAGE_INFO = "ErrorMessageInfo";
        /// <summary>
        /// ��Ϣ����Session����"SuccessClose"/"SuccessNext"/"FaildPre"/"FaildClose"/"FaildNext"
        /// </summary>
        public const string SESSION_MESSAGE_TYPE = "MessageType";
        /// <summary>
        /// �û����Session��
        /// </summary>
        public const string SESSION_USER_ID = "UserID";
        /// <summary>
        /// �û���¼��Session��
        /// </summary>
        public const string SESSION_USER_LOGIN_NAME = "UserLoginName";
        /// <summary>
        /// �û��ǳ�Session��
        /// </summary>
        public const string SESSION_USER_NICK_NAME = "UserNickName";
        /// <summary>
        /// �û�����Session��
        /// </summary>
        public const string SESSION_USER_GROUP_ID = "UserGroupID";
        /// <summary>
        /// ������λ���Session��
        /// </summary>
        public const string SESSION_SSDW_ID = "SubjectID";

        /// <summary>
        /// �û����Cookie��
        /// </summary>
        public const string COOKIE_USER_ID = "cookie_UserID";
        /// <summary>
        /// �û���¼��Cookie��
        /// </summary>
        public const string COOKIE_USER_LOGIN_NAME = "cookie_UserLoginName";
        /// <summary>
        /// �û��ǳ�Cookie��
        /// </summary>
        public const string COOKIE_USER_NICK_NAME = "cookie_UserNickName";
        /// <summary>
        /// �û�����Cookie��
        /// </summary>
        public const string COOKIE_USER_GROUP_ID = "cookie_UserGroupID";
        /// <summary>
        /// ������λ���Cookie��
        /// </summary>
        public const string COOKIE_SSDW_ID = "cookie_SubjectID";
        public const string COOKIE_SAVE_LOGIN_STATUS = "sls";
        public const string COOKIE_PASSWORD = "pwd";
        #endregion

        public const string FieldSplitString = "||";
        public const string ItemSplitString = "$$$";

        public static readonly char[] ColonDelimCharArray = { ':' };
        public static readonly char[] CommaDelimCharArray = { ',' };
        public static readonly char[] SemiDelimCharArray = { ';' };
        public static readonly char ColonDelimChar = ':';
        public static readonly char CommaDelimChar = ',';
        public static readonly char SemiDelimChar = ';';
        public static readonly string ColonDelim = ":";
        public static readonly string CommaDelim = ",";
        public static readonly string SemiDelim = ";";

        public const string
            VariableAccountSurFix = "[Variable]",
            IdListElementName = "IdList",
            IdListItemName = "Item",
            IdListAttributeName = "Id",
            // adapted the pattern from MSDN: http://msdn.microsoft.com/en-us/library/01escwtf%28v=VS.71%29.aspx
            EmailPattern =
                @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const string
            ValidateUserEmailContentName = "ValidateUser",
            ChangePasswordEmailContentName = "ChangePassword",

            VCodeParamName = "$VCode$",
            UserNameParamName = "$UserName$",
            DomainParamName = "$Domain$"
            ;

        public static string EmailContentXmlPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["EmailContentXmlPath"]);
        public static string UserSignedupEmailFrom = ConfigurationManager.AppSettings["UserSignedupEmailFrom"];
        public static string UserSignedupEmailPassword = ConfigurationManager.AppSettings["UserSignedupEmailPassword"];

    }
}