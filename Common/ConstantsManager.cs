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

        #region 网站配置信息常量

        #region 网站基本配置
        /// <summary>
        /// 未登录用户/访客用户组编号常量
        /// </summary>
        public static string DEFAULT_GUEST_USERGROUP = ConfigurationManager.AppSettings["DEFAULT_GUEST_USERGROUP"];
        /// <summary>
        /// 网站名称
        /// </summary>
        public static string WEBSITE_NAME = ConfigurationManager.AppSettings["WEBSITE_NAME"];
        /// <summary>
        /// 视频服务器地址
        /// </summary>
        public static string SERVER_ADDRESS_VIDOE = ConfigurationManager.AppSettings["SERVER_ADDRESS_VIDOE"];
        /// <summary>
        /// WEB服务器地址
        /// </summary>
        public static string SERVER_ADDRESS_WEBSITE = ConfigurationManager.AppSettings["SERVER_ADDRESS_WEBSITE"];
        /// <summary>
        /// 管理默认首页
        /// </summary>
        public static string DEFAULT_ADMINISTRATOR_INDEX = ConfigurationManager.AppSettings["DEFAULT_ADMINISTRATOR_INDEX"];
        #endregion

        #region 上传文件配置
        /// <summary>
        /// 默认生成模版文件格式
        /// </summary>
        public const string DEFAULT_TEMPLATE_FORMAT = @"html";
        /// <summary>
        /// 上传图片文件格式
        /// </summary>
        public static string UPLOAD_IMAGE_FORMAT = ConfigurationManager.AppSettings["UPLOAD_IMAGE_FORMAT"];
        /// <summary>
        /// 上传图片文件大小(MB)
        /// </summary>
        public static Int32 UPLOAD_IMAGE_SIZE = int.Parse(ConfigurationManager.AppSettings["UPLOAD_IMAGE_SIZE"]);
        /// <summary>
        /// 上传多媒体文件格式
        /// </summary>
        public static string UPLOAD_MEDIA_FORMAT = ConfigurationManager.AppSettings["UPLOAD_MEDIA_FORMAT"];
        /// <summary>
        /// 上传多媒体文件大小(MB)
        /// </summary>
        public static Int32 UPLOAD_MEDIA_SIZE = int.Parse(ConfigurationManager.AppSettings["UPLOAD_MEDIA_SIZE"]);
        /// <summary>
        /// 上传文档文件格式
        /// </summary>
        public static string UPLOAD_DOC_FORMAT = ConfigurationManager.AppSettings["UPLOAD_DOC_FORMAT"];
        /// <summary>
        /// 上传文档文件大小(MB)
        /// </summary>
        public static Int32 UPLOAD_DOC_SIZE = int.Parse(ConfigurationManager.AppSettings["UPLOAD_DOC_SIZE"]);
        /// <summary>
        /// 上传其他文件格式
        /// </summary>
        public static string UPLOAD_ALL_FORMAT = ConfigurationManager.AppSettings["UPLOAD_ALL_FORMAT"];
        /// <summary>
        /// 上传其他文件大小(MB)
        /// </summary>
        public static Int32 UPLOAD_ALL_SIZE = int.Parse(ConfigurationManager.AppSettings["UPLOAD_ALL_SIZE"]);
        #endregion

        #region 网站目录配置
        /// <summary>
        /// 系统的虚拟目录,后面不能带/
        /// </summary>
        public static string WEBSITE_VIRTUAL_ROOT_DIR = ConfigurationManager.AppSettings["WEBSITE_VIRTUAL_ROOT_DIR"];
        /// <summary>
        /// 管理目录,后面不能带/,不带虚拟目录
        /// </summary>
        public const string WEBSITE_ADMIN_DIR = @"Administrator";
        /// <summary>
        /// 页面模版目录,后面不能带/,不带虚拟目录
        /// </summary>
        public const string WEBSITE_TEMPLATE_DIR = @"App_Themes/Template";
        /// <summary>
        /// 用户目录
        /// </summary>
        public const string WEBSITE_MEMBER_DIR = @"Member";
        /// <summary>
        /// 生成文件目录
        /// </summary>
        public const string GENERATE_FILE_DIR = @"Content";
        /// <summary>
        /// 上传视频文件
        /// </summary>
        public const string UPLOAD_VIDEO_DIR = @"Media/Video";
        /// <summary>
        /// 上传音频文件
        /// </summary>
        public const string UPLOAD_AUDIO_DIR = @"Media/Audio";
        /// <summary>
        /// 上传文档文件
        /// </summary>
        public const string UPLOAD_DOC_DIR = @"Media/Doc";
        /// <summary>
        /// 上传图像文件
        /// </summary>
        public const string UPLOAD_IMAGE_DIR = @"Media/Image";
        /// <summary>
        /// 上传其他文件
        /// </summary>
        public const string UPLOAD_OTHER_DIR = @"Media/OtherFile";
        /// <summary>
        /// 数据库备份目录
        /// </summary>
        public const string DATABASE_BACKUP_DIR = @""; 
        #endregion

        #region 注册默认配置
        /// <summary>
        /// 注册默认用户组
        /// </summary>
        public static string DEFAULT_REGISTER_USERGROUPID = ConfigurationManager.AppSettings["DEFAULT_REGISTER_USERGROUPID"];
        #endregion

        #region 验证码配置参数
        /// <summary>
        /// 验证码字符大小
        /// </summary>
        public const int IDENTIFY_CODE_FONTSIZE = 9;
        /// <summary>
        /// 验证码产生位数
        /// </summary>
        public const int IDENTIFY_CODE_LENGTH = 4;
        /// <summary>
        /// 验证码产生类型
        /// </summary>
        public const int IDENTIFY_CODE_TYPE = 1;
        /// <summary>
        /// 验证码产生图像所带噪声比例
        /// </summary>
        public const float IDENTIFY_CODE_NOISE_RATE = 0.00001f; 
        #endregion

        #endregion

        #region 系统公共常量
        /// <summary>
        /// 用来获取返回查询结果或者作为批量数据的输入的DataSet的名称
        /// </summary>
        public const string QUERY_DATASET_NAME = "dsRecordInfo";
        /// <summary>
        /// 总记录数
        /// </summary>
        public const string RECORD_COUNT = "RecordCount";
        /// <summary>
        /// 用来获取MessageID
        /// </summary>
        public const string MESSAGE_ID = "strMessageID";
        #endregion

        #region SESSION COOKIE名常量
        /// <summary>
        /// 验证码Session名
        /// </summary>
        public const string SESSION_IDENTIFY_CODE = "IdentifyCode";
        /// <summary>
        /// 当前页面Session名
        /// </summary>
        public const string SESSION_CURRENT_PAGE = "CurrentPage";
        /// <summary>
        /// 要跳转页面Session名
        /// </summary>
        public const string SESSION_REDIRECT_PAGE = "RedirectPage";
        /// <summary>
        /// 需要验证权限Session名
        /// </summary>
        public const string SESSION_CURRENT_PURVIEW = "CurrentPurview";
        /// <summary>
        /// 错误信息Session名/Application名
        /// </summary>
        public const string SESSION_ERR_MESSAGE_INFO = "ErrorMessageInfo";
        /// <summary>
        /// 消息类型Session名："SuccessClose"/"SuccessNext"/"FaildPre"/"FaildClose"/"FaildNext"
        /// </summary>
        public const string SESSION_MESSAGE_TYPE = "MessageType";
        /// <summary>
        /// 用户编号Session名
        /// </summary>
        public const string SESSION_USER_ID = "UserID";
        /// <summary>
        /// 用户登录名Session名
        /// </summary>
        public const string SESSION_USER_LOGIN_NAME = "UserLoginName";
        /// <summary>
        /// 用户昵称Session名
        /// </summary>
        public const string SESSION_USER_NICK_NAME = "UserNickName";
        /// <summary>
        /// 用户组编号Session名
        /// </summary>
        public const string SESSION_USER_GROUP_ID = "UserGroupID";
        /// <summary>
        /// 所属单位编号Session名
        /// </summary>
        public const string SESSION_SSDW_ID = "SubjectID";

        /// <summary>
        /// 用户编号Cookie名
        /// </summary>
        public const string COOKIE_USER_ID = "cookie_UserID";
        /// <summary>
        /// 用户登录名Cookie名
        /// </summary>
        public const string COOKIE_USER_LOGIN_NAME = "cookie_UserLoginName";
        /// <summary>
        /// 用户昵称Cookie名
        /// </summary>
        public const string COOKIE_USER_NICK_NAME = "cookie_UserNickName";
        /// <summary>
        /// 用户组编号Cookie名
        /// </summary>
        public const string COOKIE_USER_GROUP_ID = "cookie_UserGroupID";
        /// <summary>
        /// 所属单位编号Cookie名
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