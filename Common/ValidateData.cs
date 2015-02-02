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
        /// <summary>
        /// ��֤��ֵValue
        /// </summary>
        /// <value>Value</value>
        public object Value { get; set; }

        /// <summary>
        /// ��֤����ValidateType
        /// </summary>
        /// <value>ValidateType</value>
        public string ValidateType { get; set; }

        /// <summary>
        /// ��֤�������Parameters
        /// </summary>
        /// <value>Parameters</value>
        public string[] Parameters { get; set; }

        /// <summary>
        /// ��֤�������MatchPattern
        /// </summary>
        /// <value>MatchPattern</value>
        public string MatchPattern { get; set; }

        /// <summary>
        /// ��֤��ֵ�Ƿ����Ϊ��Nullable
        /// </summary>
        /// <value>Nullable</value>
        public bool Nullable { get; set; }

        /// <summary>
        /// ��֤��ֵ�Ƿ��Ƿ������ݿ���ΨһExist
        /// </summary>
        /// <value>Exist</value>
        public bool Exist { get; set; }

        /// <summary>
        /// ��֤���ݽ��Result
        /// </summary>
        /// <value>Result</value>
        public bool Result { get; set; }

        /// <summary>
        /// ��֤�����Ƿ�Ϊ��IsNull
        /// </summary>
        /// <value>IsNull</value>
        public bool IsNull { get; set; }

        /// <summary>
        /// ��֤�����Ƿ����IsExist
        /// </summary>
        /// <value>IsExist</value>
        public bool IsExist { get; set; }

        /// <summary>
        /// ��֤���ݷ�����ϢMessage
        /// </summary>
        /// <value>Message</value>
        public string Message { get; set; }
    }
}