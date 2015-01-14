using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace RICH.Common
{
    /// <summary>
    /// Summary description for IDGenerateManager
    /// </summary>
    public class IDGenerateManager
    {
        #region ·�����ɹ����ַ�������
        /// <summary>
        /// ·������"ϵͳ������/YYYY-MM-DD/"
        /// </summary>
        private const string PATH_RULE_0001 = "{3}/{0}-{1}-{2}/";
        /// <summary>
        /// ·������"ϵͳ������/YYYY/MM/DD/"
        /// </summary>
        private const string PATH_RULE_0002 = "{3}/{0}/{1}/{2}/";
        /// <summary>
        /// ·������"ϵͳ������/YYYY/MM-DD/"
        /// </summary>
        private const string PATH_RULE_0003 = "{3}/{0}/{1}-{2}/";
        /// <summary>
        /// ·������"ϵͳ������/YYYY-MM/DD/"
        /// </summary>
        private const string PATH_RULE_0004 = "{3}/{0}-{1}/{2}/";
        /// <summary>
        /// ·������"ϵͳ������/"
        /// </summary>
        private const string PATH_RULE_0005 = "{0}/";
        /// <summary>
        /// ·������"ϵͳ������/YYYY/MM/"
        /// </summary>
        private const string PATH_RULE_0006 = "{2}/{0}/{1}/";
        /// <summary>
        /// ·������"ϵͳ������/YYYY/MMDD/"
        /// </summary>
        private const string PATH_RULE_0007 = "{3}/{0}/{1}{2}/";
        /// <summary>
        /// ·������"ϵͳ������/YYYYMMDD/"
        /// </summary>
        private const string PATH_RULE_0008 = "{3}/{0}{1}{2}/";
        #endregion

        #region �ļ���/������ɹ����ַ�������
        /// <summary>
        /// �ļ���/��Ź���"YYYYMMDDHHMMSS???"
        /// </summary>
        private const string DIRECTORYNAME_RULE_0001 = "{0}/{1}/{2}/";
        /// <summary>
        /// �ļ���/��Ź���"YYYYMMDDHHMMSS???"
        /// </summary>
        private const string FILENAME_RULE_0001 = "{0}{1}{2}{3}{4}{5}{6}";
        /// <summary>
        /// �ļ���/��Ź���"�ļ���ǰ׺YYYYMMDDHHMMSS???"
        /// </summary>
        private const string FILENAME_RULE_0002 = "{7}{0}{1}{2}{3}{4}{5}{6}";
        #endregion

        #region �ļ���չ�������ַ���
        /// <summary>
        /// �ļ���չ��html
        /// </summary>
        private const string EXTNAME_HTML = "html";
        /// <summary>
        /// �ļ���չ��htm
        /// </summary>
        private const string EXTNAME_HTM = "htm";
        /// <summary>
        /// �ļ���չ��shtml
        /// </summary>
        private const string EXTNAME_SHTML = "shtml";
        /// <summary>
        /// �ļ���չ��shtm
        /// </summary>
        private const string EXTNAME_SHTM = "shtm";
        /// <summary>
        /// �ļ���չ��XML
        /// </summary>
        private const string EXTNAME_XML = "xml";
        /// <summary>
        /// �ļ���չ��ASPX
        /// </summary>
        private const string EXTNAME_ASPX = "aspx"; 
        #endregion

        #region �����س����ַ���
        /// <summary>
        /// ��Ź���"���ǰ׺YYYYMMDDHHMMSS???"
        /// </summary>
        public const string ID_RULE_0001 = "{7}{0}{1}{2}{3}{4}{5}{6}";
        /// <summary>
        /// LessonIDǰ׺Lesson Item��д"LI"
        /// </summary>
        public const string LESSON_ID_PRDFIX = "LI";
        /// <summary>
        /// QuestionIDǰ׺Question Item��д"QI"
        /// </summary>
        public const string QUESTION_ID_PRDFIX = "QI";
        /// <summary>
        /// AnswerIDǰ׺Answer Item��д"AI"
        /// </summary>
        public const string ANSWER_ID_PRDFIX = "AI";
        /// <summary>
        /// LessonScheduleIDǰ׺LessonSchedule Item��д"LSI"
        /// </summary>
        public const string LESSONSCHEDULE_ID_PRDFIX = "LSI";
        /// <summary>
        /// UserClassIDǰ׺User Class��д"UC"
        /// </summary>
        public const string USERCLASS_ID_PRDFIX = "UC";
        /// <summary>
        /// SpecialIDǰ׺Special Item��д"SI"
        /// </summary>
        public const string SPECIAL_ID_PRDFIX = "SI";
        /// <summary>
        /// UserIDǰ׺User Item��д"UI"
        /// </summary>
        public const string USER_ID_PRDFIX = "UI";
        /// <summary>
        /// TemplateIDǰ׺Template Item��д"TI"
        /// </summary>
        public const string TEMPLATE_ID_PRDFIX = "TI";
        /// <summary>
        /// PlacardIDǰ׺Placard Item��д"PI"
        /// </summary>
        public const string PLACARD_ID_PRDFIX = "PI";
        /// <summary>
        /// LinkIDǰ׺Link Item��д"LINK"
        /// </summary>
        public const string LINK_ID_PRDFIX = "LINK";
        /// <summary>
        /// WebsiteIDǰ׺Website Item��д"WI"
        /// </summary>
        public const string WEBSITE_ID_PRDFIX = "WI";
        /// <summary>
        /// LogTypeIDǰ׺Log Type��д"LT"
        /// </summary>
        public const string LOG_TYPE_ID_PRDFIX = "LT";

        #endregion

        #region UserIDGenerate
        //***************************************************** 
        //  Function Name:  UserIDGenerate
        /// <summary>
        /// ���ɱ�T_PM_UserInfo������UserID
        /// </summary>
        /// <param name=""></param>
        /// <returns>
        /// ���ɵ�����UserID�ַ���
        /// </returns>
        //******************************************************
        public static string UserIDGenerate(DateTime dateReference)
        {
            const string strPrdfix = USER_ID_PRDFIX;
            String[] strParam = new String[10];
            strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
            strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
            strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
            strParam[3] = FillZeroToString(dateReference.Hour.ToString(), 2);
            strParam[4] = FillZeroToString(dateReference.Minute.ToString(), 2);
            strParam[5] = FillZeroToString(dateReference.Second.ToString(), 2);
            strParam[6] = FillZeroToString(dateReference.Millisecond.ToString(), 3);
            strParam[7] = strPrdfix;
            string strReturn = String.Format(ID_RULE_0001, strParam);
            return strReturn;
        }
        #endregion

        #region ϵͳ�ļ�·��������FilePathNameGenerate
        //***************************************************** 
        //  Function Name:  FilePathNameGenerate
        /// <summary>
        /// ����һ�������ɹ��������ļ���ŵ��ļ�·��
        /// </summary>
        /// <param name="dateReference"></param>
        /// <param name="strPrdfix"></param>
        /// <param name="intType"></param>
        /// <returns>
        /// ���ɵ��ļ�����ŵ�·���ַ���
        /// </returns>
        //******************************************************
        public static string FilePathNameGenerate(DateTime dateReference, string strPrdfix, int intType)
        {
            string strReturn;
            String[] strParam = new String[10];
            switch (intType)
            {
                case 1:
                    strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
                    strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
                    strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
                    strParam[3] = strPrdfix;
                    strReturn = String.Format(PATH_RULE_0001, strParam);
                    break;
                case 2:
                    strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
                    strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
                    strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
                    strParam[3] = strPrdfix;
                    strReturn = String.Format(PATH_RULE_0002, strParam);
                    break;
                case 3:
                    strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
                    strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
                    strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
                    strParam[3] = strPrdfix;
                    strReturn = String.Format(PATH_RULE_0003, strParam);
                    break;
                case 4:
                    strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
                    strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
                    strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
                    strParam[3] = strPrdfix;
                    strReturn = String.Format(PATH_RULE_0004, strParam);
                    break;
                case 5:
                    strParam[0] = strPrdfix;
                    strReturn = String.Format(PATH_RULE_0005, strParam);
                    break;
                case 6:
                    strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
                    strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
                    strParam[2] = strPrdfix;
                    strReturn = String.Format(PATH_RULE_0006, strParam);
                    break;
                case 7:
                    strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
                    strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
                    strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
                    strParam[3] = strPrdfix;
                    strReturn = String.Format(PATH_RULE_0007, strParam);
                    break;
                case 8:
                    strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
                    strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
                    strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
                    strParam[3] = strPrdfix;
                    strReturn = String.Format(PATH_RULE_0008, strParam);
                    break;
                default:
                    strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
                    strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
                    strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
                    strParam[3] = strPrdfix;
                    strReturn = String.Format(PATH_RULE_0002, strParam);
                    break;
            }
            return strReturn;
        }
        #endregion

        #region �ļ���������FileNameGenerate
        //***************************************************** 
        //  Function Name:  FileNameGenerate
        /// <summary>
        /// ����һ�������ɹ��������ļ����ļ���
        /// </summary>
        /// <param name=""></param>
        /// <param name="dateReference"></param>
        /// <param name="strPrdfix"></param>
        /// <param name="intExtType"></param>
        /// <returns>
        /// ���ɵ��ļ����ַ���
        /// </returns>
        //******************************************************
        public static string FileNameGenerate(DateTime dateReference, string strPrdfix, int intExtType)
        {
            String[] strParam = new String[10];
            strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
            strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
            strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
            strParam[3] = FillZeroToString(dateReference.Hour.ToString(), 2);
            strParam[4] = FillZeroToString(dateReference.Minute.ToString(), 2);
            strParam[5] = FillZeroToString(dateReference.Second.ToString(), 2);
            strParam[6] = FillZeroToString(dateReference.Millisecond.ToString(), 3);
            strParam[7] = strPrdfix;
            string strReturn = String.Format(FILENAME_RULE_0002, strParam);
            switch (intExtType)
            {
                case 1:
                    strReturn = strReturn + "." + EXTNAME_HTML;
                    break;
                case 2:
                    strReturn = strReturn + "." + EXTNAME_HTM;
                    break;
                case 3:
                    strReturn = strReturn + "." + EXTNAME_SHTML;
                    break;
                case 4:
                    strReturn = strReturn + "." + EXTNAME_SHTM;
                    break;
                case 5:
                    strReturn = strReturn + "." + EXTNAME_XML;
                    break;
                case 6:
                    strReturn = strReturn + "." + EXTNAME_HTML;
                    break;
                default:
                    strReturn = strReturn + "." + EXTNAME_ASPX;
                    break;
            }
            return strReturn;
        }
        public static string FileNameGenerate(DateTime dateReference, int intExtType)
        {
            String[] strParam = new String[10];
            strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
            strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
            strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
            strParam[3] = FillZeroToString(dateReference.Hour.ToString(), 2);
            strParam[4] = FillZeroToString(dateReference.Minute.ToString(), 2);
            strParam[5] = FillZeroToString(dateReference.Second.ToString(), 2);
            strParam[6] = FillZeroToString(dateReference.Millisecond.ToString(), 3);
            string strReturn = String.Format(FILENAME_RULE_0001, strParam);
            switch (intExtType)
            {
                case 1:
                    strReturn = strReturn + "." + EXTNAME_HTML;
                    break;
                case 2:
                    strReturn = strReturn + "." + EXTNAME_HTM;
                    break;
                case 3:
                    strReturn = strReturn + "." + EXTNAME_SHTML;
                    break;
                case 4:
                    strReturn = strReturn + "." + EXTNAME_SHTM;
                    break;
                case 5:
                    strReturn = strReturn + "." + EXTNAME_XML;
                    break;
                case 6:
                    strReturn = strReturn + "." + EXTNAME_HTML;
                    break;
                default:
                    strReturn = strReturn + "." + EXTNAME_ASPX;
                    break;
            }
            return strReturn;
        }

        public static string UploadFileNameGenerate()
        {
            DateTime dateReference = DateTime.Now;
            String[] strParam = new String[10];
            strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
            strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
            strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
            strParam[3] = FillZeroToString(dateReference.Hour.ToString(), 2);
            strParam[4] = FillZeroToString(dateReference.Minute.ToString(), 2);
            strParam[5] = FillZeroToString(dateReference.Second.ToString(), 2);
            strParam[6] = FillZeroToString(dateReference.Millisecond.ToString(), 3);
            string strReturn = String.Format(FILENAME_RULE_0001, strParam);
            return strReturn;
        }

        public static string UploadDirectoryNameGenerate()
        {
            DateTime dateReference = DateTime.Now;
            String[] strParam = new String[10];
            strParam[0] = FillZeroToString(dateReference.Year.ToString(), 4);
            strParam[1] = FillZeroToString(dateReference.Month.ToString(), 2);
            strParam[2] = FillZeroToString(dateReference.Day.ToString(), 2);
            string strReturn = String.Format(DIRECTORYNAME_RULE_0001, strParam);
            return strReturn;
        }
        #endregion

        public static string FillZeroToString(string strObject, int intNumber)
        {
            if (strObject.Length < intNumber)
            {
                int i;
                for (i = 0; i <= (intNumber - strObject.Length); i++)
                {
                    strObject = "0" + strObject;
                }
            }
            return strObject;
        }
    }
}