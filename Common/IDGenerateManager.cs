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
        #region 路径生成规则字符串常量
        /// <summary>
        /// 路径规则"系统分类编号/YYYY-MM-DD/"
        /// </summary>
        private const string PATH_RULE_0001 = "{3}/{0}-{1}-{2}/";
        /// <summary>
        /// 路径规则"系统分类编号/YYYY/MM/DD/"
        /// </summary>
        private const string PATH_RULE_0002 = "{3}/{0}/{1}/{2}/";
        /// <summary>
        /// 路径规则"系统分类编号/YYYY/MM-DD/"
        /// </summary>
        private const string PATH_RULE_0003 = "{3}/{0}/{1}-{2}/";
        /// <summary>
        /// 路径规则"系统分类编号/YYYY-MM/DD/"
        /// </summary>
        private const string PATH_RULE_0004 = "{3}/{0}-{1}/{2}/";
        /// <summary>
        /// 路径规则"系统分类编号/"
        /// </summary>
        private const string PATH_RULE_0005 = "{0}/";
        /// <summary>
        /// 路径规则"系统分类编号/YYYY/MM/"
        /// </summary>
        private const string PATH_RULE_0006 = "{2}/{0}/{1}/";
        /// <summary>
        /// 路径规则"系统分类编号/YYYY/MMDD/"
        /// </summary>
        private const string PATH_RULE_0007 = "{3}/{0}/{1}{2}/";
        /// <summary>
        /// 路径规则"系统分类编号/YYYYMMDD/"
        /// </summary>
        private const string PATH_RULE_0008 = "{3}/{0}{1}{2}/";
        #endregion

        #region 文件名/编号生成规则字符串常量
        /// <summary>
        /// 文件名/编号规则"YYYYMMDDHHMMSS???"
        /// </summary>
        private const string DIRECTORYNAME_RULE_0001 = "{0}/{1}/{2}/";
        /// <summary>
        /// 文件名/编号规则"YYYYMMDDHHMMSS???"
        /// </summary>
        private const string FILENAME_RULE_0001 = "{0}{1}{2}{3}{4}{5}{6}";
        /// <summary>
        /// 文件名/编号规则"文件名前缀YYYYMMDDHHMMSS???"
        /// </summary>
        private const string FILENAME_RULE_0002 = "{7}{0}{1}{2}{3}{4}{5}{6}";
        #endregion

        #region 文件扩展名常量字符串
        /// <summary>
        /// 文件扩展名html
        /// </summary>
        private const string EXTNAME_HTML = "html";
        /// <summary>
        /// 文件扩展名htm
        /// </summary>
        private const string EXTNAME_HTM = "htm";
        /// <summary>
        /// 文件扩展名shtml
        /// </summary>
        private const string EXTNAME_SHTML = "shtml";
        /// <summary>
        /// 文件扩展名shtm
        /// </summary>
        private const string EXTNAME_SHTM = "shtm";
        /// <summary>
        /// 文件扩展名XML
        /// </summary>
        private const string EXTNAME_XML = "xml";
        /// <summary>
        /// 文件扩展名ASPX
        /// </summary>
        private const string EXTNAME_ASPX = "aspx"; 
        #endregion

        #region 编号相关常量字符串
        /// <summary>
        /// 编号规则"编号前缀YYYYMMDDHHMMSS???"
        /// </summary>
        public const string ID_RULE_0001 = "{7}{0}{1}{2}{3}{4}{5}{6}";
        /// <summary>
        /// LessonID前缀Lesson Item缩写"LI"
        /// </summary>
        public const string LESSON_ID_PRDFIX = "LI";
        /// <summary>
        /// QuestionID前缀Question Item缩写"QI"
        /// </summary>
        public const string QUESTION_ID_PRDFIX = "QI";
        /// <summary>
        /// AnswerID前缀Answer Item缩写"AI"
        /// </summary>
        public const string ANSWER_ID_PRDFIX = "AI";
        /// <summary>
        /// LessonScheduleID前缀LessonSchedule Item缩写"LSI"
        /// </summary>
        public const string LESSONSCHEDULE_ID_PRDFIX = "LSI";
        /// <summary>
        /// UserClassID前缀User Class缩写"UC"
        /// </summary>
        public const string USERCLASS_ID_PRDFIX = "UC";
        /// <summary>
        /// SpecialID前缀Special Item缩写"SI"
        /// </summary>
        public const string SPECIAL_ID_PRDFIX = "SI";
        /// <summary>
        /// UserID前缀User Item缩写"UI"
        /// </summary>
        public const string USER_ID_PRDFIX = "UI";
        /// <summary>
        /// TemplateID前缀Template Item缩写"TI"
        /// </summary>
        public const string TEMPLATE_ID_PRDFIX = "TI";
        /// <summary>
        /// PlacardID前缀Placard Item缩写"PI"
        /// </summary>
        public const string PLACARD_ID_PRDFIX = "PI";
        /// <summary>
        /// LinkID前缀Link Item缩写"LINK"
        /// </summary>
        public const string LINK_ID_PRDFIX = "LINK";
        /// <summary>
        /// WebsiteID前缀Website Item缩写"WI"
        /// </summary>
        public const string WEBSITE_ID_PRDFIX = "WI";
        /// <summary>
        /// LogTypeID前缀Log Type缩写"LT"
        /// </summary>
        public const string LOG_TYPE_ID_PRDFIX = "LT";

        #endregion

        #region UserIDGenerate
        //***************************************************** 
        //  Function Name:  UserIDGenerate
        /// <summary>
        /// 生成表T_PM_UserInfo的主键UserID
        /// </summary>
        /// <param name=""></param>
        /// <returns>
        /// 生成的主键UserID字符串
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

        #region 系统文件路径的生成FilePathNameGenerate
        //***************************************************** 
        //  Function Name:  FilePathNameGenerate
        /// <summary>
        /// 按照一定的生成规则生成文件存放的文件路径
        /// </summary>
        /// <param name="dateReference"></param>
        /// <param name="strPrdfix"></param>
        /// <param name="intType"></param>
        /// <returns>
        /// 生成的文件所存放的路径字符串
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

        #region 文件名的生成FileNameGenerate
        //***************************************************** 
        //  Function Name:  FileNameGenerate
        /// <summary>
        /// 按照一定的生成规则生成文件的文件名
        /// </summary>
        /// <param name=""></param>
        /// <param name="dateReference"></param>
        /// <param name="strPrdfix"></param>
        /// <param name="intExtType"></param>
        /// <returns>
        /// 生成的文件名字符串
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