using System.Collections;

namespace RICH.Common.Base.ApplicationData
{
    //===========================================================================
    //  ClassName : DataTypeManager
    /// <summary>
    /// ApplicationDataBaseʹ�õ��������͹�����
    /// </summary>
    //===========================================================================
    public class DataTypeManager
    {
        #region �������ͽṹ
        /// <summary>
        /// �������ͽṹ
        /// </summary>
        private static Hashtable typeTable = new Hashtable();
        #endregion

        #region ���캯��
        //=========================================================================
        //  FunctionName : DataTypeManager
        /// <summary>
        /// DataTypeManager���캯��
        /// </summary>
        //=========================================================================
        private DataTypeManager()
        {
        }
        #endregion

        #region ��������
        //=========================================================================
        //  FunctionName : GetTypeInfo
        /// <summary>
        /// �������������Ϣ
        /// </summary>
        /// <remarks>
        /// �������������Ϣ
        /// </remarks>
        /// <param name="className">������������</param>
        /// <returns>����������Ϣ</returns>
        //=========================================================================
        public static IDictionary GetTypeInfo(string className)
        {
            return (IDictionary)typeTable[className];
        }

        //=========================================================================
        //  FunctionName : SetTypeInfo
        /// <summary>
        /// ��������������Ϣ
        /// </summary>
        /// <remarks>
        /// ��������������Ϣ
        /// </remarks>
        /// <param name="className">������������</param>
        /// <param name="propertyTable">����������Ϣ</param>
        //=========================================================================
        public static void SetTypeInfo(string className, IDictionary propertyTable)
        {
            typeTable[className] = propertyTable;
        }
        #endregion
    }
}
