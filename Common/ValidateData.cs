namespace RICH.Common
{
    //****************************************************** 
    ///<summary>
    ///Module ID：ValidateData
    ///Depiction：验证返回数据类
    ///</summary>
    //******************************************************
    public class ValidateData
    {
        /// <summary>
        /// 验证数值Value
        /// </summary>
        /// <value>Value</value>
        public object Value { get; set; }

        /// <summary>
        /// 验证类型ValidateType
        /// </summary>
        /// <value>ValidateType</value>
        public string ValidateType { get; set; }

        /// <summary>
        /// 验证输入参数Parameters
        /// </summary>
        /// <value>Parameters</value>
        public string[] Parameters { get; set; }

        /// <summary>
        /// 验证输入参数MatchPattern
        /// </summary>
        /// <value>MatchPattern</value>
        public string MatchPattern { get; set; }

        /// <summary>
        /// 验证数值是否可以为空Nullable
        /// </summary>
        /// <value>Nullable</value>
        public bool Nullable { get; set; }

        /// <summary>
        /// 验证数值是否是否在数据库中唯一Exist
        /// </summary>
        /// <value>Exist</value>
        public bool Exist { get; set; }

        /// <summary>
        /// 验证数据结果Result
        /// </summary>
        /// <value>Result</value>
        public bool Result { get; set; }

        /// <summary>
        /// 验证数据是否为空IsNull
        /// </summary>
        /// <value>IsNull</value>
        public bool IsNull { get; set; }

        /// <summary>
        /// 验证数据是否存在IsExist
        /// </summary>
        /// <value>IsExist</value>
        public bool IsExist { get; set; }

        /// <summary>
        /// 验证数据返回消息Message
        /// </summary>
        /// <value>Message</value>
        public string Message { get; set; }
    }
}