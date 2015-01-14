using System.Data;
using System.Reflection;

namespace RICH.Common.Base.ApplicationData
{
    //===========================================================================
    //  ClassName : ColumnInfo
    /// <summary>
    /// ApplicationDataBase������ʵ����е�������
    /// </summary>
    //===========================================================================
    public class ColumnInfo
    {
        #region ������Ϣ
        /// <summary>
        /// ������Ϣ
        /// </summary>
        private PropertyInfo columnProperty = null;

        /// <summary>
        /// �趨ȡ��������Ϣ
        /// </summary>
        /// <value>����</value>
        public PropertyInfo ColumnProperty
        {
            get { return columnProperty; }
            set { columnProperty = value; }
        }
        #endregion

        #region ���ݿ���������

        /// <summary>
        /// �趨ȡ�����ݿ���������
        /// </summary>
        /// <value>���ݿ���������</value>
        public SqlDbType ColumnType { get; set; }

        #endregion

        #region �Ƿ�������

        /// <summary>
        /// �趨ȡ���Ƿ���������ʾ
        /// </summary>
        /// <value>
        /// ����������� true
        /// ������������� false
        /// </value>
        public bool IsPrimaryKey { get; set; }

        #endregion

        #region �Ƿ����ΪNull

        /// <summary>
        /// ����ȡ���Ƿ����ΪNull��ʾ
        /// </summary>
        /// <value>
        /// ����ΪNull true
        /// ������ΪNull false
        /// </value>
        public bool IsNullable { get; set; }

        #endregion

        #region ���캯��
        //=========================================================================
        //  FunctionName : ColumnInfo
        /// <summary>
        /// ColumnInfo���캯��
        /// </summary>
        //=========================================================================
        public ColumnInfo()
        {
            IsPrimaryKey = false;
            IsNullable = false;
        }

        #endregion
    }

}
