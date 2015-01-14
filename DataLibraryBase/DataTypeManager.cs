using System.Collections;

namespace RICH.Common.Base.ApplicationData
{
    //===========================================================================
    //  ClassName : DataTypeManager
    /// <summary>
    /// ApplicationDataBase使用的数据类型管理类
    /// </summary>
    //===========================================================================
    public class DataTypeManager
    {
        #region 数据类型结构
        /// <summary>
        /// 数据类型结构
        /// </summary>
        private static Hashtable typeTable = new Hashtable();
        #endregion

        #region 构造函数
        //=========================================================================
        //  FunctionName : DataTypeManager
        /// <summary>
        /// DataTypeManager构造函数
        /// </summary>
        //=========================================================================
        private DataTypeManager()
        {
        }
        #endregion

        #region 公共方法
        //=========================================================================
        //  FunctionName : GetTypeInfo
        /// <summary>
        /// 获得数据类型信息
        /// </summary>
        /// <remarks>
        /// 获得数据类型信息
        /// </remarks>
        /// <param name="className">数据类型名称</param>
        /// <returns>数据类型信息</returns>
        //=========================================================================
        public static IDictionary GetTypeInfo(string className)
        {
            return (IDictionary)typeTable[className];
        }

        //=========================================================================
        //  FunctionName : SetTypeInfo
        /// <summary>
        /// 设置数据类型信息
        /// </summary>
        /// <remarks>
        /// 设置数据类型信息
        /// </remarks>
        /// <param name="className">数据类型名称</param>
        /// <param name="propertyTable">数据类型信息</param>
        //=========================================================================
        public static void SetTypeInfo(string className, IDictionary propertyTable)
        {
            typeTable[className] = propertyTable;
        }
        #endregion
    }
}
