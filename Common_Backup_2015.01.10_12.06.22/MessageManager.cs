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
        #region ��ʾ��Ϣ����
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

        #region ������ʾ��Ϣ����
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

        #region ��־��Ϣ����
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

        #region ϵͳ��Ϣ����
        public const string SYS_MSGID_0001 = "";
        #endregion

        private static Hashtable htMessageInfo;

        private static void GenerateMessageInfo()
        {
            if (htMessageInfo == null)
            {
                htMessageInfo = new Hashtable
                                    {
                                        //�����ʾ��Ϣ
                                        {HINT_MSGID_0001, @"��¼�ɹ���"},
                                        {HINT_MSGID_0002, @"{0}������Ϊ�ա�"},
                                        {HINT_MSGID_0003, @"{0}����Ϊ���֡�"},
                                        {HINT_MSGID_0004, @"{0}����Ϊ���ȴ���{1}С��{2}���ַ�����"},
                                        {HINT_MSGID_0005, @"{0}����Ϊ���ڣ���ʽΪYYYY/MM/DD��YYYY-MM-DD��"},
                                        {HINT_MSGID_0006, @"{0}����Ϊ�������ͣ�""true""����""false""��"},
                                        {HINT_MSGID_0007, @"{0}������{1}��{2}ʱ�䷶Χ�ڡ�"},
                                        {HINT_MSGID_0008, @"{0}������{1}��{2}���ַ�Χ�ڡ�"},
                                        {HINT_MSGID_0009, @"{0}�����ǳ���Ϊ{1}�Ķ����ַ�����"},
                                        {HINT_MSGID_0010, @"{0}��������4-20��Ӣ����ĸ���������(��֧�����ġ����������ֿ�ͷ)��"},
                                        {HINT_MSGID_0011, @"������6-20�������ַ���ɣ���������׼ǡ��Ѳµ�Ӣ��������ϡ�"},
                                        {HINT_MSGID_0012, @"{0}��ʽ������""XXXXXXXX-XXXX-XXXX-XXXXXXXXXXXX""��"},
                                        {HINT_MSGID_0013, @"{0}��ʽ������""����-�绰����""����""���ŵ绰����""��"},
                                        {HINT_MSGID_0014, @"��ϲ������ֵ�ɹ���"},
                                        {HINT_MSGID_0015, @"{0}{1}�����ɹ���"},
                                        {HINT_MSGID_0016, @"����δ��¼�����Ƚ��е�¼��"},
                                        {HINT_MSGID_0017, @"{0}���㣡"},
                                        {HINT_MSGID_0018, @"�ϴ�{0}����С��{1}KB������������ϴ���"},
                                        {HINT_MSGID_0019, @""},
                                        {HINT_MSGID_0020, @""},
                                        {HINT_MSGID_0021, @""},
                                        //��Ӵ�����ʾ��Ϣ
                                        {ERR_MSGID_0001, @"���û������ڡ�"},
                                        {ERR_MSGID_0002, @"�������"},
                                        {ERR_MSGID_0003, @"��û�з��ʴ�ҳ����ܵ�Ȩ�ޡ�"},
                                        {ERR_MSGID_0004, @"Ȩ�޵��ڡ�"},
                                        {ERR_MSGID_0005, @"������ĳ�ֵ�������ڡ�"},
                                        {ERR_MSGID_0006, @"��ֵ�����޵��ڡ�"},
                                        {ERR_MSGID_0007, @"�˳�ֵ���Ѿ���ʹ�á�"},
                                        {ERR_MSGID_0008, @"��ֵ���������"},
                                        {ERR_MSGID_0009, @"�����д��ڷǷ��ַ���"},
                                        {ERR_MSGID_0010, @"�����ﺬ�зǷ��ַ���"},
                                        {ERR_MSGID_0011, @"�����ѯ��������"},
                                        {ERR_MSGID_0012, @"��Ҫ�޸ĵ�{0}�����ڡ�"},
                                        {ERR_MSGID_0013, @"�Ѵ���{0}��{1}��"},
                                        {ERR_MSGID_0014, @"{0}��ʽ����ȷ"},
                                        {ERR_MSGID_0015, @"{0}�������࣡"},
                                        {ERR_MSGID_0016, @"���û��Ѵ��ڡ�"},
                                        {ERR_MSGID_0017, @"{0}�Ѵ��ڡ�"},
                                        {ERR_MSGID_0018, @"��֤���������"},
                                        {ERR_MSGID_0019, @"�����������벻һ�£�"},
                                        {ERR_MSGID_0020, @"ԭ��¼�������"},
                                        {ERR_MSGID_0021, @"��{0}�����ڡ�"},
                                        {ERR_MSGID_0022, @"�����������"},
                                        {ERR_MSGID_0023, @"{0}�����ʽ����"},
                                        {ERR_MSGID_0024, @"�������ʵĶ��󲻴��ڡ�"},
                                        {ERR_MSGID_0025, @"�������ѻ��ֲ�����֧���˴ν��ף����ֵ��"},
                                        {ERR_MSGID_0026, @"���ύ����Ϣ���зǷ��ַ������������ύ��"},
                                        {ERR_MSGID_0027, @"���û�״̬Ϊδ��ˣ�����ϵ����Ա��"},
                                        {ERR_MSGID_0028, @"�������䣬����������֤���ٵ�¼��"},
                                        {ERR_MSGID_0029, @""},
                                        {ERR_MSGID_0030, @""},
                                        {ERR_MSGID_0031, @""},
                                        //�����־��Ϣ
                                        {LOG_MSGID_0001, @"�û�{0}��¼�ɹ���"},
                                        {LOG_MSGID_0002, @"�û�{0}��¼ʧ�ܡ�"},
                                        {LOG_MSGID_0003, @"�û�{0}������{1}{2}��{3}������"},
                                        {LOG_MSGID_0004, @"�û�{0}��{1}������ԽȨ������"},
                                        {LOG_MSGID_0005, @"�û�{0}������{1}������"},
                                        {LOG_MSGID_0006, @"�û�{0}������{1}{2}��{3}������"},
                                        {LOG_MSGID_0007, @"�û�{0}��¼�ɹ���"},
                                        {LOG_MSGID_0008, @"�û�{0}��¼ʧ�ܡ�"},
                                        {LOG_MSGID_0009, @"�û�{0}�ύ�Ƿ��ؼ��֣�������ͼ����ϵͳ��"},
                                        {LOG_MSGID_0010, @"�û�{0}�����˳�ϵͳ��"},
                                        {LOG_MSGID_0011, @"�û�{0}��ʱ�˳�ϵͳ��"},
                                        {LOG_MSGID_0012, @"�û�{0}�����{1}{2}��"},
                                        {LOG_MSGID_0013, @"�û�{0}�ϴ����ļ�{1}��"},
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