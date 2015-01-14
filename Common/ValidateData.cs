namespace RICH.Common
{
    //****************************************************** 
    ///<summary>
    ///Module ID��ValidateData
    ///Depiction����֤����������
    ///</summary>
    //******************************************************
    public class ValidateData
    {
        #region ��֤��ֵValue

        /// <summary>
        /// ��֤��ֵValue
        /// </summary>
        /// <value>Value</value>
        public object Value { get; set; }

        #endregion

        #region ��֤����ValidateType

        /// <summary>
        /// ��֤����ValidateType
        /// </summary>
        /// <value>ValidateType</value>
        public string ValidateType { get; set; }

        #endregion

        #region ��֤�������Parameters

        /// <summary>
        /// ��֤�������Parameters
        /// </summary>
        /// <value>Parameters</value>
        public string[] Parameters { get; set; }

        #endregion

        #region ģʽƥ���ַ���MatchPattern

        /// <summary>
        /// ��֤�������MatchPattern
        /// </summary>
        /// <value>MatchPattern</value>
        public string MatchPattern { get; set; }

        #endregion

        #region ��֤��ֵ�Ƿ����Ϊ��Nullable

        /// <summary>
        /// ��֤��ֵ�Ƿ����Ϊ��Nullable
        /// </summary>
        /// <value>Nullable</value>
        public bool Nullable { get; set; }

        #endregion

        #region ��֤��ֵ�Ƿ��Ƿ������ݿ���ΨһExist

        /// <summary>
        /// ��֤��ֵ�Ƿ��Ƿ������ݿ���ΨһExist
        /// </summary>
        /// <value>Exist</value>
        public bool Exist { get; set; }

        #endregion

        #region ��֤���ݽ��Result

        /// <summary>
        /// ��֤���ݽ��Result
        /// </summary>
        /// <value>Result</value>
        public bool Result { get; set; }

        #endregion

        #region ��֤�����Ƿ�Ϊ��IsNull

        /// <summary>
        /// ��֤�����Ƿ�Ϊ��IsNull
        /// </summary>
        /// <value>IsNull</value>
        public bool IsNull { get; set; }

        #endregion

        #region ��֤�����Ƿ����IsExist

        /// <summary>
        /// ��֤�����Ƿ����IsExist
        /// </summary>
        /// <value>IsExist</value>
        public bool IsExist { get; set; }

        #endregion

        #region ��֤���ݷ�����ϢMessage

        /// <summary>
        /// ��֤���ݷ�����ϢMessage
        /// </summary>
        /// <value>Message</value>
        public string Message { get; set; }

        #endregion
    }
}