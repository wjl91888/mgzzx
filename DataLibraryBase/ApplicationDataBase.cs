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
    /// ����ʵ�����
    /// </summary>
    //===========================================================================
    [Serializable]
    public abstract class ApplicationDataBase
    {
        /// <summary>
        /// ������״̬ר�õĽ������
        /// </summary>
        public enum ResultState
        {
            /// <summary>
            /// ����ʧ��
            /// </summary>
            Failure,
            /// <summary>
            /// ��������
            /// </summary>
            ArgumentError,
            /// <summary>
            /// ϵͳ����
            /// </summary>
            SystemError,
            /// <summary>
            /// ��ѯ����
            /// </summary>
            InquiryError,
            /// <summary>
            /// �����ɹ�
            /// </summary>
            Succeed
        }

        /// <summary>
        /// �������ݿ��������
        /// </summary>
        public enum OPType
        {
            /// <summary>
            /// ����������
            /// </summary>
            ALL,
            /// <summary>
            /// ��������
            /// </summary>
            PK,
            /// <summary>
            /// ID����
            /// </summary>
            ID,
            /// <summary>
            /// һ�����ݲ���
            /// </summary>
            BATCH
        }
        
        #region ���󷽷�
        //=========================================================================
        //  FunctionName : GetPrimaryKey
        /// <summary>
        /// ȡ�ö�Ӧ����ʵ�������
        /// </summary>
        /// <returns>���ض�Ӧ��ṹ�������б��ַ�������</returns>
        //=========================================================================
        public abstract string[] GetPrimaryKey();

        //=========================================================================
        //  FunctionName : GetColumnName
        /// <summary>
        /// ȡ�ö�Ӧ����ʵ�����������
        /// </summary>
        /// <remarks>
        /// ȡ�ö�Ӧ����ʵ�����������
        /// </remarks>
        /// <returns>�������ַ�������</returns>
        //=========================================================================
        public abstract string[] GetColumnName();

        //=========================================================================
        //  FunctionName : GetColumnType
        /// <summary>
        /// ȡ�ö�Ӧ����ʵ��������е����ݿ���������
        /// </summary>
        /// <remarks>
        /// ȡ�ö�Ӧ����ʵ��������е����ݿ���������
        /// </remarks>
        /// <returns>�����ݿ������ַ�������</returns>
        //=========================================================================
        public abstract SqlDbType[] GetColumnType();

        //=========================================================================
        //  FunctionName : GetNullableColumn
        /// <summary>
        /// ȡ�ö�Ӧ����ʵ������Ϊ�յ�������
        /// </summary>
        /// <returns>����Ϊ�յ��������ַ�������</returns>
        //=========================================================================
        public abstract string[] GetNullableColumn();
        #endregion

        #region ��������
        //=========================================================================
        //  FunctionName : GetData
        /// <summary>
        /// ȡ������ʵ��ָ���е�ֵ
        /// </summary>
        /// <param name="columnName">������</param>
        /// <returns>������Ӧ��ֵ</returns>
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
                string msg = "������:" + columnName;
                throw new Exception();
                //throw new BaseDataException(MESSAGE_ID_NOT_FOUND, new string[] {msg}, null ,null ,null);
            }
            return infoColumn.ColumnProperty.GetValue(this, null);
        }

        //=========================================================================
        //  FunctionName : SetData
        /// <summary>
        /// �趨����ʵ��ָ���е�ֵ
        /// </summary>
        /// <param name="columnName">������</param>
        /// <param name="columnValue">��ֵ</param>
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
                string msg = "������:" + columnName;
                throw new Exception();
                //throw new BaseDataException(MESSAGE_ID_NOT_FOUND, new string[] {msg}, null ,null ,null);
            }
            infoColumn.ColumnProperty.SetValue(this, columnValue, null);
        }

        //=========================================================================
        //  FunctionName : GetColumnInfo
        /// <summary>
        /// ȡ������ʵ��ָ���е�����Ϣ
        /// </summary>
        /// <param name="columnName">������</param>
        /// <returns>ColumnInfo��������</returns>
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
                string msg = "������:" + columnName;
                throw new Exception();
                //throw new BaseDataException(MESSAGE_ID_NOT_FOUND, new string[] {msg}, null ,null ,null);
            }
            return infoColumn;
        }

        //=========================================================================
        //  FunctionName : ToString
        /// <summary>
        /// ����ToString����������������ƺͶ�Ӧ��ֵ
        /// </summary>
        /// <returns>�ַ���</returns>
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
                return string.Format("{0}.ToString() ������Ϣ({1})", className, ex.Message);
            }
        }
        #endregion

        #region ��������
        //=========================================================================
        //  FunctionName : TypeConvert
        /// <summary>
        /// ��Դֵת����ָ�����������Ͳ����浽Ŀ��洢��Ԫ
        /// </summary>
        /// <param name="sourceValue">Դֵ</param>
        /// <param name="convertType">Ҫת���ɵ���������</param>
        /// <param name="dataValue">Ŀ��洢��Ԫ</param>
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

        #region ˽�з���
        //=========================================================================
        //  FunctionName : Initialize
        /// <summary>
        /// ��ʼ������ʵ��
        /// </summary>
        /// <remarks>
        /// ��ʼ������ʵ��ʵ��
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
