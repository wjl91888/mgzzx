using System;
using System.Text.RegularExpressions;
namespace RICH.Common
{
    /// <summary>
    /// Summary description for DataValidateManager
    /// </summary>
    public class DataValidateManager
    {
        const String PATTERN_NUMBER_001 = @"^[0-9]+([.]?[0-9]*)$";
        const String PATTERN_NUMBER_002 = @"^[0-9]+$";
        const String PATTERN_NUMBER_003 = @"^(0|[1-9][0-9]*)$";
        const String PATTERN_NUMBER_004 = @"^[0-9]+(.[0-9]{2}?$";
        const String PATTERN_NUMBER_005 = @"^[0-9]+(.[0-9]{1,3}?$";
        const String PATTERN_NUMBER_006 = @"^\+?[1-9][0-9]*$";
        const String PATTERN_NUMBER_007 = @"^\-?[1-9][0-9]*$";
        const String PATTERN_CHAR_001 = @"^.{3}$";
        const String PATTERN_CHAR_002 = @"^[A-Z]+$";
        const String PATTERN_CHAR_003 = @"^[a-z]+$";
        const String PATTERN_CHAR_004 = @"^[A-Za-z0-9]+$";
        const String PATTERN_CHAR_005 = @"^\w+$";
        const String PATTERN_CHAR_006 = @"[^%&',;=?$\x22]+";
        const String PATTERN_NUMBER_LENGTH = @"^\d{{{0}}}$";
        const String PATTERN_NUMBER_MINLENGTH = @"^\d[{0},]$";
        const String PATTERN_NUMBER_RANGE = @"^\d{{{0},{1}}}$";
        const String PATTERN_STRING_LENGTH = @"^.{{{0}}}$";
        const String PATTERN_STRING_RANGE = @"^.{{{0},{1}}}$";
        const String PATTERN_CHINESE_WORDS_NULL = @"[\u4e00-\u9fff]*$";
        const String PATTERN_CHINESE_WORDS_NOTNULL = @"[\u4e00-\u9fff]+$";
        const String PATTERN_ENGLISH_WORDS_NULL = @"^[A-Za-z]*$";
        const String PATTERN_ENGLISH_WORDS_NOTNULL = @"^[A-Za-z]+$";
        const String PATTERN_EMAIL = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        const String PATTERN_URL = @"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";
        const String PATTERN_USERNAME = @"^([0-9]|[a-zA-Z])\w{4,20}$";
        const String PATTERN_PASSWORD = @"^.{6,20}$";
        const String PATTERN_TELEPHONE = @"^(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$";
        const String PATTERN_IDCARD = @"^\d{15}|\d{18}$";
        const String PATTERN_MONTH = @"^(0?[1-9]|1[0-2])$";
        const String PATTERN_DAY = @"^((0?[1-9])|((1|2)[0-9])|30|31)$";
        const String PATTERN_IPADDRESS = @"^((0|1?[0-9]?[0-9])|(2[0-5][0-5])).((0|1?[0-9]?[0-9])|(2[0-5][0-5])).((0|1?[0-9]?[0-9])|(2[0-5][0-5])).((0|1?[0-9]?[0-9])|(2[0-5][0-5]))$";
        const String PATTERN_UNIQUE_IDENTIFIER = @"^\w{8}-\w{4}-\w{4}-\w{4}-\w{12}";
        const String PATTERN_FILENAME = @"^\w{1,255}.\w{1,5}";

        #region 空验证
        public static Boolean ValidateIsNull(Object objectData)
        {
            Boolean boolReturn = false;
            if (objectData == null)
            {
                boolReturn = true;
            }
            else if (objectData == DBNull.Value)
            {
                boolReturn = true;
            }
            else
            {
                if (objectData.ToString() == "" || objectData.ToString() == string.Empty)
                {
                    boolReturn = true;
                }
                if (objectData.GetType().ToString().Equals("System.Data.SqlTypes.SqlBinary") && objectData.ToString().Equals("null", StringComparison.OrdinalIgnoreCase))
                {
                    boolReturn = true;
                }
            }
            return boolReturn;
        }

        public static Boolean ValidateIsNull(Object objectData, object objParamOne, object objParamTwo)
        {
            Boolean boolReturn = false;
            if (objectData == null)
            {
                boolReturn = true;
            }
            else if (objectData == DBNull.Value)
            {
                boolReturn = true;
            }
            else
            {
                if (objectData.ToString() == "" || objectData.ToString() == string.Empty)
                {
                    boolReturn = true;
                }
            }
            return boolReturn;
        }

        public static Boolean ValidateIsDBNull(Object objectData)
        {
            return objectData == DBNull.Value;
        }

        public static Boolean ValidateIsDBNull(Object objectData, object objParamOne, object objParamTwo)
        {
            return objectData != DBNull.Value;
        }
        #endregion

        #region 字符串验证
        public static Boolean ValidateStringFormat(Object objectData)
        {
            Boolean boolReturn = false;
            if (!ValidateIsNull(objectData))
            {
                String strData = objectData.ToString();
                boolReturn = strData != string.Empty;
            }
            return boolReturn;
        }

        public static Boolean ValidateStringFormat(Object objectData, object objParamOne, object objParamTwo)
        {
            Boolean boolReturn = false;
            if (!ValidateIsNull(objectData))
            {
                String strData = objectData.ToString();
                boolReturn = strData != string.Empty;
            }
            return boolReturn;
        }

        public static Boolean ValidateStringLength(Object objectData, Int64 intLength)
        {
            return ValidatePatternMatch(objectData, String.Format(PATTERN_STRING_LENGTH, intLength.ToString()));
        }

        public static Boolean ValidateStringLength(Object objectData, Int64 intLength, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, String.Format(PATTERN_STRING_LENGTH, intLength.ToString()));
        }

        public static Boolean ValidateStringLengthRange(Object objectData, Int64 intMinValue, Int64 intMaxValue)
        {
            return ValidatePatternMatch(objectData, String.Format(PATTERN_STRING_RANGE, intMinValue.ToString(), intMaxValue.ToString()));
        }

        public static Boolean ValidateIsEnglishWords(Object objectData)
        {
            return ValidatePatternMatch(objectData, PATTERN_ENGLISH_WORDS_NULL);
        }

        public static Boolean ValidateIsEnglishWords(Object objectData, object objParamOne, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, PATTERN_ENGLISH_WORDS_NULL);
        }

        public static Boolean ValidateIsChineseWords(Object objectData)
        {
            return ValidatePatternMatch(objectData, PATTERN_CHINESE_WORDS_NULL);
        }

        public static Boolean ValidateIsChineseWords(Object objectData, object objParamOne, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, PATTERN_CHINESE_WORDS_NULL);
        }
        #endregion

        #region 数字验证
        public static Boolean ValidateNumberFormat(Object objectData)
        {
            return ValidatePatternMatch(objectData, PATTERN_NUMBER_001);
        }
        public static Boolean ValidateNumberFormat(Object objectData, object objParamOne, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, PATTERN_NUMBER_001);
        }

        public static Boolean ValidateNumberLength(Object objectData, Int32 intValue)
        {
            return ValidatePatternMatch(objectData, String.Format(PATTERN_NUMBER_LENGTH, intValue.ToString()));
        }
        public static Boolean ValidateNumberLength(Object objectData, Int32 intValue, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, String.Format(PATTERN_NUMBER_LENGTH, intValue.ToString()));
        }

        public static Boolean ValidateNumberLengthRange(Object objectData, Int64 intMaxValue, Int64 intMinValue)
        {
            return ValidatePatternMatch(objectData, String.Format(PATTERN_NUMBER_RANGE, intMinValue.ToString(), intMaxValue.ToString()));
        }

        public static Boolean ValidateNumberRange(Object objectData, Double dblMaxValue, Double dblMinValue)
        {
            Boolean boolReturn = false;
            Double dblData;
            if (ValidatePatternMatch(objectData, PATTERN_NUMBER_001))
            {
                dblData = Double.Parse(objectData.ToString());
                if (dblData >= dblMinValue && dblData <= dblMaxValue)
                {
                    boolReturn = true;
                }
            }
            return boolReturn;
        }
        #endregion

        #region 日期验证
        public static Boolean ValidateDateFormat(Object objectData)
        {
            Boolean boolReturn = false;
            if (!ValidateIsNull(objectData))
            {
                DateTime dateData;
                boolReturn = DateTime.TryParse(objectData.ToString(), out dateData);
            }
            return boolReturn;
        }

        public static Boolean ValidateDateFormat(Object objectData, object objParamOne = null, object objParamTwo = null)
        {
            Boolean boolReturn = false;
            if (!ValidateIsNull(objectData))
            {
                DateTime dateData;
                boolReturn = DateTime.TryParse(objectData.ToString(), out dateData);
            }
            return boolReturn;
        }

        public static Boolean ValidateDateRange(Object objectData, DateTime dateStart, DateTime dateEnd)
        {
            Boolean boolReturn = false;
            if (!ValidateIsNull(objectData))
            {
                DateTime dateData;
                if (DateTime.TryParse((string)objectData, out dateData))
                {
                    if (dateData >= dateStart && dateData <= dateEnd)
                    {
                        boolReturn = true;
                    }
                } 
            }
            return boolReturn;
        }
        #endregion

        public static Boolean ValidateBooleanFormat(Object objectData)
        {
            Boolean boolReturn = false;
            if (!ValidateIsNull(objectData))
            {
                Boolean boolData;
                boolReturn = Boolean.TryParse(objectData.ToString(), out boolData);
            }
            return boolReturn;
        }

        public static Boolean ValidateBooleanFormat(Object objectData, object objParamOne = null, object objParamTwo = null)
        {
            Boolean boolReturn = false;
            if (!ValidateIsNull(objectData))
            {
                Boolean boolData;
                boolReturn = Boolean.TryParse(objectData.ToString(), out boolData);
            }
            return boolReturn;
        }

        #region IP地址验证
        public static Boolean ValidateIPAddressFormat(Object objectData)
        {
            return ValidatePatternMatch(objectData, PATTERN_IPADDRESS);
        }

        public static Boolean ValidateIPAddressFormat(Object objectData, object objParamOne = null, object objParamTwo = null)
        {
            return ValidatePatternMatch(objectData, PATTERN_IPADDRESS);
        }

        public static Boolean ValidateIPAddressRange(Object objectData, object objParamOne, object objParamTwo)
        {
            Boolean boolReturn = false;
            if (!ValidateIsNull(objectData))
            {
                boolReturn = true;
            }
            return boolReturn;
        }
        #endregion

        #region Email地址验证
        public static Boolean ValidateEmailFormat(Object objectData)
        {
            return ValidatePatternMatch(objectData, PATTERN_EMAIL);
        }
        public static Boolean ValidateEmailFormat(Object objectData, object objParamOne, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, PATTERN_EMAIL);
        }
        #endregion
        
        #region 链接地址验证
        public static Boolean ValidateURLFormat(Object objectData)
        {
            return ValidatePatternMatch(objectData, PATTERN_URL);
        }
        public static Boolean ValidateURLFormat(Object objectData, object objParamOne, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, PATTERN_URL);
        }
        #endregion

        #region 域名验证
        public static Boolean ValidateDomainFormat(Object objectData)
        {
            return false;
        }
        public static Boolean ValidateDomainFormat(Object objectData, object objParamOne, object objParamTwo)
        {
            return false;
        }
        #endregion

        #region 模式匹配
        public static Boolean ValidatePatternMatch(Object objectData, String strPattern)
        {
            Boolean boolReturn = false;
            if (!ValidateIsNull(objectData))
            {
                String strData = objectData.ToString();
                Regex regexPattern = new Regex(strPattern);
                Match matchPattern = regexPattern.Match(strData);
                if (matchPattern.Success)
                {
                    boolReturn = true;
                }
            }
            return boolReturn;
        } 
        #endregion

        #region 密码验证
        public static Boolean ValidatePasswordFormat(Object objectData)
        {
            return ValidatePatternMatch(objectData, PATTERN_PASSWORD);
        }
        public static Boolean ValidatePasswordFormat(Object objectData, object objParamOne, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, PATTERN_PASSWORD);
        }
        #endregion

        #region 用户名验证
        public static Boolean ValidateUserNameFormat(Object objectData)
        {
            return ValidatePatternMatch(objectData, PATTERN_USERNAME);
        }

        public static Boolean ValidateUserNameFormat(Object objectData, object objParamOne, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, PATTERN_USERNAME);
        }
        #endregion
        
        #region ObjectID验证
        public static Boolean ValidateUniqueIdentifierFormat(Object objectData)
        {
            return ValidatePatternMatch(objectData, PATTERN_UNIQUE_IDENTIFIER);
        }

        public static Boolean ValidateUniqueIdentifierFormat(Object objectData, object objParamOne, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, PATTERN_UNIQUE_IDENTIFIER);
        }
        #endregion

        #region 电话号码验证
        public static Boolean ValidateTelFormat(Object objectData)
        {
            return ValidatePatternMatch(objectData, PATTERN_TELEPHONE);
        }

        public static Boolean ValidateTelFormat(Object objectData, object objParamOne, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, PATTERN_TELEPHONE);
        }
        #endregion

        #region 文件名格式验证验证
        public static Boolean ValidateFileNameFormat(Object objectData)
        {
            return ValidatePatternMatch(objectData, PATTERN_FILENAME);
        }

        public static Boolean ValidateFileNameFormat(Object objectData, object objParamOne, object objParamTwo)
        {
            return ValidatePatternMatch(objectData, PATTERN_FILENAME);
        }
        #endregion

        #region 图像验证
        public static Boolean ValidateImageSize(Object objectData, object objParamOne, object objParamTwo)
        {
            return ((Byte[])objectData).Length <= Convert.ToInt32(objParamOne) * 1024;
        }
        #endregion

    }
}