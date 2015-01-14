using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace RICH.Common
{/// <summary>
    /// Summary description for Message
    /// </summary>
    public class MessageManager
    {
        #region 提示消息定义
        public const string HINT_MSGID_0001 = "HINT_MSGID_0001";
        public const string HINT_MSGID_0002 = "HINT_MSGID_0002";
        public const string HINT_MSGID_0003 = "HINT_MSGID_0003";
        public const string HINT_MSGID_0004 = "HINT_MSGID_0004";
        public const string HINT_MSGID_0005 = "HINT_MSGID_0005";
        public const string HINT_MSGID_0006 = "HINT_MSGID_0006";
        public const string HINT_MSGID_0007 = "HINT_MSGID_0007";
        public const string HINT_MSGID_0008 = "HINT_MSGID_0008";
        public const string HINT_MSGID_0009 = "HINT_MSGID_0009";
        public const string HINT_MSGID_0010 = "HINT_MSGID_0010";
        public const string HINT_MSGID_0011 = "HINT_MSGID_0011";
        public const string HINT_MSGID_0012 = "HINT_MSGID_0012";
        public const string HINT_MSGID_0013 = "HINT_MSGID_0013";
        public const string HINT_MSGID_0014 = "HINT_MSGID_0014";
        public const string HINT_MSGID_0015 = "HINT_MSGID_0015";
        public const string HINT_MSGID_0016 = "HINT_MSGID_0016";
        public const string HINT_MSGID_0017 = "HINT_MSGID_0017";
        public const string HINT_MSGID_0018 = "HINT_MSGID_0018";
        public const string HINT_MSGID_0019 = "HINT_MSGID_0019";
        public const string HINT_MSGID_0020 = "HINT_MSGID_0020";
        public const string HINT_MSGID_0021 = "HINT_MSGID_0021";
        public const string HINT_MSGID_0022 = "HINT_MSGID_0022";
        public const string HINT_MSGID_0023 = "HINT_MSGID_0023";
        public const string HINT_MSGID_0024 = "HINT_MSGID_0024";
        public const string HINT_MSGID_0025 = "HINT_MSGID_0025";
        public const string HINT_MSGID_0026 = "HINT_MSGID_0026";
        #endregion

        #region 错误提示消息定义
        public const string ERR_MSGID_0001 = "ERR_MSGID_0001";
        public const string ERR_MSGID_0002 = "ERR_MSGID_0002";
        public const string ERR_MSGID_0003 = "ERR_MSGID_0003";
        public const string ERR_MSGID_0004 = "ERR_MSGID_0004";
        public const string ERR_MSGID_0005 = "ERR_MSGID_0005";
        public const string ERR_MSGID_0006 = "ERR_MSGID_0006";
        public const string ERR_MSGID_0007 = "ERR_MSGID_0007";
        public const string ERR_MSGID_0008 = "ERR_MSGID_0008";
        public const string ERR_MSGID_0009 = "ERR_MSGID_0009";
        public const string ERR_MSGID_0010 = "ERR_MSGID_0010";
        public const string ERR_MSGID_0011 = "ERR_MSGID_0011";
        public const string ERR_MSGID_0012 = "ERR_MSGID_0012";
        public const string ERR_MSGID_0013 = "ERR_MSGID_0013";
        public const string ERR_MSGID_0014 = "ERR_MSGID_0014";
        public const string ERR_MSGID_0015 = "ERR_MSGID_0015";
        public const string ERR_MSGID_0016 = "ERR_MSGID_0016";
        public const string ERR_MSGID_0017 = "ERR_MSGID_0017";
        public const string ERR_MSGID_0018 = "ERR_MSGID_0018";
        public const string ERR_MSGID_0019 = "ERR_MSGID_0019";
        public const string ERR_MSGID_0020 = "ERR_MSGID_0020";
        public const string ERR_MSGID_0021 = "ERR_MSGID_0021";
        public const string ERR_MSGID_0022 = "ERR_MSGID_0022";
        public const string ERR_MSGID_0023 = "ERR_MSGID_0023";
        public const string ERR_MSGID_0024 = "ERR_MSGID_0024";
        public const string ERR_MSGID_0025 = "ERR_MSGID_0025";
        public const string ERR_MSGID_0026 = "ERR_MSGID_0026";
        public const string ERR_MSGID_0027 = "ERR_MSGID_0027";
        public const string ERR_MSGID_0028 = "ERR_MSGID_0028";
        public const string ERR_MSGID_0029 = "ERR_MSGID_0029";
        public const string ERR_MSGID_0030 = "ERR_MSGID_0030";
        public const string ERR_MSGID_0031 = "ERR_MSGID_0031";
        #endregion

        #region 日志消息定义
        public const string LOG_MSGID_0001 = "LOG_MSGID_0001";
        public const string LOG_MSGID_0002 = "LOG_MSGID_0002";
        public const string LOG_MSGID_0003 = "LOG_MSGID_0003";
        public const string LOG_MSGID_0004 = "LOG_MSGID_0004";
        public const string LOG_MSGID_0005 = "LOG_MSGID_0005";
        public const string LOG_MSGID_0006 = "LOG_MSGID_0006";
        public const string LOG_MSGID_0007 = "LOG_MSGID_0007";
        public const string LOG_MSGID_0008 = "LOG_MSGID_0008";
        public const string LOG_MSGID_0009 = "LOG_MSGID_0009";
        public const string LOG_MSGID_0010 = "LOG_MSGID_0010";
        public const string LOG_MSGID_0011 = "LOG_MSGID_0011";
        public const string LOG_MSGID_0012 = "LOG_MSGID_0012";
        public const string LOG_MSGID_0013 = "LOG_MSGID_0013";
        public const string LOG_MSGID_0014 = "LOG_MSGID_0014";
        public const string LOG_MSGID_0015 = "LOG_MSGID_0015";
        public const string LOG_MSGID_0016 = "LOG_MSGID_0016";
        #endregion

        #region 系统消息定义
        public const string SYS_MSGID_0001 = "";
        #endregion

        private static Hashtable htMessageInfo;

        private static void GenerateMessageInfo()
        {
            if (htMessageInfo == null)
            {
                htMessageInfo = new Hashtable
                                    {
                                        //添加提示消息
                                        {HINT_MSGID_0001, @"登录成功。"},
                                        {HINT_MSGID_0002, @"{0}不可以为空。"},
                                        {HINT_MSGID_0003, @"{0}必须为数字。"},
                                        {HINT_MSGID_0004, @"{0}必须为长度大于{1}小于{2}的字符串。"},
                                        {HINT_MSGID_0005, @"{0}必须为日期，格式为YYYY/MM/DD或YYYY-MM-DD。"},
                                        {HINT_MSGID_0006, @"{0}必须为布尔类型，""true""或者""false""。"},
                                        {HINT_MSGID_0007, @"{0}必须在{1}至{2}时间范围内。"},
                                        {HINT_MSGID_0008, @"{0}必须在{1}至{2}数字范围内。"},
                                        {HINT_MSGID_0009, @"{0}必须是长度为{1}的定长字符串。"},
                                        {HINT_MSGID_0010, @"{0}必须是由4-20个英文字母或数字组成(不支持中文、不能以数字开头)。"},
                                        {HINT_MSGID_0011, @"密码由6-20个任意字符组成，建议采用易记、难猜的英文数字组合。"},
                                        {HINT_MSGID_0012, @"{0}格式必须是""XXXXXXXX-XXXX-XXXX-XXXXXXXXXXXX""。"},
                                        {HINT_MSGID_0013, @"{0}格式必须是""区号-电话号码""或者""区号电话号码""。"},
                                        {HINT_MSGID_0014, @"恭喜您，充值成功！"},
                                        {HINT_MSGID_0015, @"{0}{1}操作成功。"},
                                        {HINT_MSGID_0016, @"您还未登录，请先进行登录。"},
                                        {HINT_MSGID_0017, @"{0}不足！"},
                                        {HINT_MSGID_0018, @"上传{0}必须小于{1}KB，请调整后在上传。"},
                                        {HINT_MSGID_0019, @""},
                                        {HINT_MSGID_0020, @""},
                                        {HINT_MSGID_0021, @""},
                                        //添加错误提示消息
                                        {ERR_MSGID_0001, @"此用户不存在。"},
                                        {ERR_MSGID_0002, @"密码错误。"},
                                        {ERR_MSGID_0003, @"你没有访问此页面或功能的权限。"},
                                        {ERR_MSGID_0004, @"权限到期。"},
                                        {ERR_MSGID_0005, @"你输入的充值卡不存在。"},
                                        {ERR_MSGID_0006, @"充值卡期限到期。"},
                                        {ERR_MSGID_0007, @"此充值卡已经被使用。"},
                                        {ERR_MSGID_0008, @"充值卡密码错误。"},
                                        {ERR_MSGID_0009, @"名称中存在非法字符。"},
                                        {ERR_MSGID_0010, @"内容里含有非法字符。"},
                                        {ERR_MSGID_0011, @"输入查询条件错误。"},
                                        {ERR_MSGID_0012, @"所要修改的{0}不存在。"},
                                        {ERR_MSGID_0013, @"已存在{0}的{1}。"},
                                        {ERR_MSGID_0014, @"{0}格式不正确"},
                                        {ERR_MSGID_0015, @"{0}字数过多！"},
                                        {ERR_MSGID_0016, @"此用户已存在。"},
                                        {ERR_MSGID_0017, @"{0}已存在。"},
                                        {ERR_MSGID_0018, @"验证码输入错误。"},
                                        {ERR_MSGID_0019, @"密码两次输入不一致！"},
                                        {ERR_MSGID_0020, @"原登录密码错误。"},
                                        {ERR_MSGID_0021, @"此{0}不存在。"},
                                        {ERR_MSGID_0022, @"输入参数错误。"},
                                        {ERR_MSGID_0023, @"{0}输入格式错误。"},
                                        {ERR_MSGID_0024, @"您所访问的对象不存在。"},
                                        {ERR_MSGID_0025, @"您的消费积分不足以支付此次交易，请充值。"},
                                        {ERR_MSGID_0026, @"您提交的信息含有非法字符，请您检查后提交。"},
                                        {ERR_MSGID_0027, @"此用户状态为未审核，请联系管理员。"},
                                        {ERR_MSGID_0028, @"请检查邮箱，进行邮箱验证后再登录。"},
                                        {ERR_MSGID_0029, @""},
                                        {ERR_MSGID_0030, @""},
                                        {ERR_MSGID_0031, @""},
                                        //添加日志消息
                                        {LOG_MSGID_0001, @"用户{0}登录成功。"},
                                        {LOG_MSGID_0002, @"用户{0}登录失败。"},
                                        {LOG_MSGID_0003, @"用户{0}进行了{1}{2}的{3}操作。"},
                                        {LOG_MSGID_0004, @"用户{0}对{1}进行了越权操作。"},
                                        {LOG_MSGID_0005, @"用户{0}进行了{1}操作。"},
                                        {LOG_MSGID_0006, @"用户{0}进行了{1}{2}的{3}操作。"},
                                        {LOG_MSGID_0007, @"用户{0}登录成功。"},
                                        {LOG_MSGID_0008, @"用户{0}登录失败。"},
                                        {LOG_MSGID_0009, @"用户{0}提交非法关键字，可能企图攻击系统。"},
                                        {LOG_MSGID_0010, @"用户{0}正常退出系统。"},
                                        {LOG_MSGID_0011, @"用户{0}超时退出系统。"},
                                        {LOG_MSGID_0012, @"用户{0}浏览了{1}{2}。"},
                                        {LOG_MSGID_0013, @"用户{0}上传了文件{1}。"},
                                        {LOG_MSGID_0014, @""},
                                        {LOG_MSGID_0015, @""},
                                        {LOG_MSGID_0016, @""}
                                    };
            }
        }

        public static string GetMessageInfo(string strMsgID)
        {
            GenerateMessageInfo();
            return "<div>" + (string)htMessageInfo[strMsgID] + "</div>";
        }

        public static string GetMessageInfo(string strMsgID, string strMessageInfo)
        {
            GenerateMessageInfo();
            return strMessageInfo +  "<div>" + (string)htMessageInfo[strMsgID] + "</div>";
        }

        public static string GetMessageInfo(string strMsgID, string[] strArrPrarmeter)
        {
            GenerateMessageInfo();
            string strMessageInfo = "";
            if (strArrPrarmeter.Length == 0)
            {
                strMessageInfo = "<div>" + (string)htMessageInfo[strMsgID] + "</div>";
            }
            else if (strArrPrarmeter.Length > 0)
            {
                strMessageInfo = "<div>" + String.Format((string)htMessageInfo[strMsgID], strArrPrarmeter) + "</div>";
            }
            return strMessageInfo;
        }

        public static string GetMessageInfo(string strMsgID, string[] strArrPrarmeter, string strMessageInfo)
        {
            GenerateMessageInfo();
            if (strArrPrarmeter.Length == 0)
            {
                strMessageInfo = "<div>" + (string)htMessageInfo[strMsgID] + "</div>";
            }
            else if (strArrPrarmeter.Length > 0)
            {
                strMessageInfo = strMessageInfo + "<div>" + String.Format((string)htMessageInfo[strMsgID], strArrPrarmeter) + "</div>";
            }
            return strMessageInfo;
        }
    }
}