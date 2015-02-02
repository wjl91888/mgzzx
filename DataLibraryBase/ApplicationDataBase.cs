using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RICH.Common.Base.ApplicationData
{
    //===========================================================================
    //  ClassName : ApplicationDataBase
    /// <summary>
    /// 数据实体基类
    /// </summary>
    //===========================================================================
    [Serializable]
    public abstract class ApplicationDataBase
    {
        /// <summary>
        /// 定义结果状态专用的结果代码
        /// </summary>
        public enum ResultState
        {
            /// <summary>
            /// 操作失败
            /// </summary>
            Failure,
            /// <summary>
            /// 参数错误
            /// </summary>
            ArgumentError,
            /// <summary>
            /// 系统错误
            /// </summary>
            SystemError,
            /// <summary>
            /// 查询错误
            /// </summary>
            InquiryError,
            /// <summary>
            /// 操作成功
            /// </summary>
            Succeed
        }

        /// <summary>
        /// 定义数据库操作代码
        /// </summary>
        public enum OPType
        {
            /// <summary>
            /// 无条件操作
            /// </summary>
            ALL,
            /// <summary>
            /// 主键操作
            /// </summary>
            PK,
            /// <summary>
            /// ID操作
            /// </summary>
            ID,
            /// <summary>
            /// 一批数据操作
            /// </summary>
            BATCH
        }
        
        #region 抽象方法
        //=========================================================================
        //  FunctionName : GetPrimaryKey
        /// <summary>
        /// 取得对应数据实体的主健
        /// </summary>
        /// <returns>返回对应表结构的主健列表字符串数组</returns>
        //=========================================================================
        public abstract string[] GetPrimaryKey();

        //=========================================================================
        //  FunctionName : GetColumnName
        /// <summary>
        /// 取得对应数据实体的所有列名
        /// </summary>
        /// <remarks>
        /// 取得对应数据实体的所有列名
        /// </remarks>
        /// <returns>列名称字符串数组</returns>
        //=========================================================================
        public abstract string[] GetColumnName();

        //=========================================================================
        //  FunctionName : GetColumnType
        /// <summary>
        /// 取得对应数据实体的所有列的数据库数据类型
        /// </summary>
        /// <remarks>
        /// 取得对应数据实体的所有列的数据库数据类型
        /// </remarks>
        /// <returns>列数据库类型字符串数组</returns>
        //=========================================================================
        public abstract SqlDbType[] GetColumnType();

        //=========================================================================
        //  FunctionName : GetNullableColumn
        /// <summary>
        /// 取得对应数据实体允许为空的列名称
        /// </summary>
        /// <returns>允许为空的列名称字符串数组</returns>
        //=========================================================================
        public abstract string[] GetNullableColumn();
        #endregion

        #region 公共方法
        //=========================================================================
        //  FunctionName : GetData
        /// <summary>
        /// 取得数据实体指定列的值
        /// </summary>
        /// <param name="columnName">列名称</param>
        /// <returns>列所对应的值</returns>
        //=========================================================================
        public object GetData(string columnName)
        {
            string className = this.GetType().ToString();
            IDictionary typeTable = DataTypeManager.GetTypeInfo(className);
            if (typeTable == null)
            {
                Initialize();
            }
            IDictionary propertyTable = DataTypeManager.GetTypeInfo(className);
            ColumnInfo infoColumn = (ColumnInfo)propertyTable[columnName];
            if (infoColumn == null)
            {
                string msg = "列名称:" + columnName;
                throw new Exception();
                //throw new BaseDataException(MESSAGE_ID_NOT_FOUND, new string[] {msg}, null ,null ,null);
            }
            return infoColumn.ColumnProperty.GetValue(this, null);
        }

        //=========================================================================
        //  FunctionName : SetData
        /// <summary>
        /// 设定数据实体指定列的值
        /// </summary>
        /// <param name="columnName">列名称</param>
        /// <param name="columnValue">列值</param>
        //=========================================================================
        public void SetData(string columnName, object columnValue)
        {
            string className = this.GetType().ToString();
            IDictionary typeTable = DataTypeManager.GetTypeInfo(className);
            if (typeTable == null)
            {
                Initialize();
            }
            IDictionary propertyTable = DataTypeManager.GetTypeInfo(className);
            ColumnInfo infoColumn = (ColumnInfo)propertyTable[columnName];
            if (infoColumn == null)
            {
                string msg = "列名称:" + columnName;
                throw new Exception();
                //throw new BaseDataException(MESSAGE_ID_NOT_FOUND, new string[] {msg}, null ,null ,null);
            }
            infoColumn.ColumnProperty.SetValue(this, columnValue, null);
        }

        //=========================================================================
        //  FunctionName : GetColumnInfo
        /// <summary>
        /// 取得数据实体指定列的列信息
        /// </summary>
        /// <param name="columnName">列名称</param>
        /// <returns>ColumnInfo类型数组</returns>
        /// <exception cref="BaseDataException"></exception>
        //=========================================================================
        public ColumnInfo GetColumnInfo(string columnName)
        {
            string className = this.GetType().ToString();
            IDictionary typeTable = DataTypeManager.GetTypeInfo(className);
            if (typeTable == null)
            {
                Initialize();
            }
            IDictionary propertyTable = (IDictionary)DataTypeManager.GetTypeInfo(className);
            ColumnInfo infoColumn = (ColumnInfo)propertyTable[columnName];
            if (infoColumn == null)
            {
                string msg = "列名称:" + columnName;
                throw new Exception();
                //throw new BaseDataException(MESSAGE_ID_NOT_FOUND, new string[] {msg}, null ,null ,null);
            }
            return infoColumn;
        }

        //=========================================================================
        //  FunctionName : ToString
        /// <summary>
        /// 重载ToString方法输出所有列名称和对应的值
        /// </summary>
        /// <returns>字符串</returns>
        //=========================================================================
        public override string ToString()
        {
            string className = this.GetType().ToString();
            try
            {
                IDictionary typeTable = DataTypeManager.GetTypeInfo(className);
                if (typeTable == null)
                {
                    Initialize();
                }
                string[] columnNameList = this.GetColumnName();
                StringBuilder builder = new StringBuilder();
                foreach (string columnName in columnNameList)
                {
                    if (builder.Length != 0)
                    {
                        builder.Append(", ");
                    }
                    builder.Append(columnName).Append("=").Append(this.GetData(columnName));
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                return string.Format("{0}.ToString() 错误信息({1})", className, ex.Message);
            }
        }
        #endregion

        #region 保护方法
        //=========================================================================
        //  FunctionName : TypeConvert
        /// <summary>
        /// 将源值转换成指定的数据类型并保存到目标存储单元
        /// </summary>
        /// <param name="sourceValue">源值</param>
        /// <param name="convertType">要转换成的数据类型</param>
        /// <param name="dataValue">目标存储单元</param>
        //=========================================================================
        protected void TypeConvert(object sourceValue, Type convertType, ref object dataValue)
        {
            switch (convertType.Name)
            {
                case "Int64":
                    dataValue = Convert.ToInt64(sourceValue);
                    break;
                case "Boolean":
                    dataValue = Convert.ToBoolean(sourceValue);
                    break;
                case "String":
                    dataValue = Convert.ToString(sourceValue);
                    break;
                case "DateTime":
                    dataValue = Convert.ToDateTime(sourceValue);
                    break;
                case "Decimal":
                    dataValue = Convert.ToDecimal(sourceValue);
                    break;
                case "Double":
                    dataValue = Convert.ToDouble(sourceValue);
                    break;
                case "Int32":
                    dataValue = Convert.ToInt32(sourceValue);
                    break;
                case "Single":
                    dataValue = Convert.ToSingle(sourceValue);
                    break;
                case "Int16":
                    dataValue = Convert.ToInt16(sourceValue);
                    break;
                case "Byte":
                    dataValue = Convert.ToByte(sourceValue);
                    break;
                default:
                    dataValue = sourceValue;
                    break;
            }
        }
        #endregion

        #region 私有方法
        //=========================================================================
        //  FunctionName : Initialize
        /// <summary>
        /// 初始化数据实体
        /// </summary>
        /// <remarks>
        /// 初始化数据实体实例
        /// </remarks>
        //=========================================================================
        private void Initialize()
        {
            lock(this.GetType())
            {
                string className = this.GetType().ToString();
                IDictionary typeTable = DataTypeManager.GetTypeInfo(className);
                if (typeTable == null)
                {
                    Hashtable propertyTable = new Hashtable();

                    ColumnInfo infoColumn;
                    string[] columnList = this.GetColumnName();
                    SqlDbType[] columnTypeList = this.GetColumnType();
                    string[] keyList = this.GetPrimaryKey();
                    string[] nullList = this.GetNullableColumn();
                    PropertyInfo[] properties = this.GetType().GetProperties();
 
                    for(int i = 0 ; i < columnList.Length ; i++)
                    {
                        infoColumn = new ColumnInfo();
                        infoColumn.ColumnType = columnTypeList[i];
                        propertyTable[columnList[i]] = infoColumn;
                        propertyTable[columnList[i].ToLower()] = infoColumn;
                    }

                    foreach (PropertyInfo infoProperty in properties)
                    {
                        infoColumn = (ColumnInfo)propertyTable[infoProperty.Name];
                        if (infoColumn == null)
                        {
                            continue;
                        }

                        infoColumn.ColumnProperty = infoProperty;
                        if (keyList.Any(keyCol => keyCol == infoProperty.Name))
                        {
                            infoColumn.IsPrimaryKey = true;
                        }
                        if (nullList.Any(nullCol => nullCol == infoProperty.Name))
                        {
                            infoColumn.IsNullable = true;
                        }
                    }

                    DataTypeManager.SetTypeInfo(className, propertyTable);
                }
            }
        }
        #endregion

        public bool ValidateColumnName(string strColumn)
        {
            bool boolReturn = false;
            string[] columnList = this.GetColumnName();
            foreach (string strTemp in columnList)
            {
                if (strColumn == strTemp)
                {
                    boolReturn = true;
                    break;
                }
            }
            return boolReturn;
        }

        public static IList<T> GetDataFromDataFile<T>(string strFileName, bool boolVirtual = false, bool afterDelete = true, int recordStartLine = 2)
        {
            IList<T> appDatas = new List<T>();
            var dt = RICH.Common.FileLibrary.ConvertDataFileToDataTable(strFileName, boolVirtual, afterDelete, recordStartLine);
            var arg = new object[] { dt };
            appDatas = (IList<T>)typeof(T).InvokeMember("GetCollectionFromImportDataTable", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, arg);
            return appDatas;
        }

    }
}
