/****************************************************** 
FileName:T_PM_UserGroupInfoApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_PM_UserGroupInfo
{
    //=========================================================================
    //  ClassName : T_PM_UserGroupInfoApplicationData
    /// <summary>
    /// T_PM_UserGroupInfo������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_PM_UserGroupInfoApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// �û�����UserGroupID
        /// </summary>
        /// <value>UserGroupID</value>
        public String UserGroupID { get; set; }
    
        /// <summary>
        /// �û�������UserGroupName
        /// </summary>
        /// <value>UserGroupName</value>
        public String UserGroupName { get; set; }
    
        /// <summary>
        /// ����UserGroupContent
        /// </summary>
        /// <value>UserGroupContent</value>
        public String UserGroupContent { get; set; }
    
        /// <summary>
        /// ��עUserGroupRemark
        /// </summary>
        /// <value>UserGroupRemark</value>
        public String UserGroupRemark { get; set; }
    
        /// <summary>
        /// ϵͳĬ��ҳDefaultPage
        /// </summary>
        /// <value>DefaultPage</value>
        public String DefaultPage { get; set; }
    
        /// <summary>
        /// ����ʱ��UpdateDate
        /// </summary>
        /// <value>UpdateDate</value>
        public DateTime? UpdateDate { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// �û�����UserGroupIDBatch
        /// </summary>
        /// <value>UserGroupID</value>
        public String UserGroupIDBatch { get; set; }

        /// <summary>
        /// �û�������UserGroupNameBatch
        /// </summary>
        /// <value>UserGroupName</value>
        public String UserGroupNameBatch { get; set; }

        /// <summary>
        /// ����UserGroupContentBatch
        /// </summary>
        /// <value>UserGroupContent</value>
        public String UserGroupContentBatch { get; set; }

        /// <summary>
        /// ��עUserGroupRemarkBatch
        /// </summary>
        /// <value>UserGroupRemark</value>
        public String UserGroupRemarkBatch { get; set; }

        /// <summary>
        /// ϵͳĬ��ҳDefaultPageBatch
        /// </summary>
        /// <value>DefaultPage</value>
        public String DefaultPageBatch { get; set; }

        /// <summary>
        /// ����ʱ��UpdateDateBatch
        /// </summary>
        /// <value>UpdateDate</value>
        public String UpdateDateBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// �û�������������UserGroupIDValue
        /// </summary>
        /// <value>UserGroupIDValue</value>
        public String UserGroupIDValue { get; set; }
    
        /// <summary>
        /// �û���������������UserGroupNameValue
        /// </summary>
        /// <value>UserGroupNameValue</value>
        public String UserGroupNameValue { get; set; }
    
        /// <summary>
        /// ������������UserGroupContentValue
        /// </summary>
        /// <value>UserGroupContentValue</value>
        public String UserGroupContentValue { get; set; }
    
        /// <summary>
        /// ��ע��������UserGroupRemarkValue
        /// </summary>
        /// <value>UserGroupRemarkValue</value>
        public String UserGroupRemarkValue { get; set; }
    
        /// <summary>
        /// ϵͳĬ��ҳ��������DefaultPageValue
        /// </summary>
        /// <value>DefaultPageValue</value>
        public String DefaultPageValue { get; set; }
    
        /// <summary>
        /// ����ʱ����������UpdateDateValue
        /// </summary>
        /// <value>UpdateDateValue</value>
        public DateTime? UpdateDateValue { get; set; }
        
        #endregion
        #region һ��һ��ر�

        #endregion
        #region ��������
        /// <summary>
        /// ResultSet
        /// </summary>
        private DataSet m_ResultSet = new DataSet();

        /// <summary>
        /// ��ѯ���ؽ����ResultSet
        /// </summary>
        /// <value>ResultSet</value>
        public DataSet ResultSet
        {
            get { return m_ResultSet; }
            set { m_ResultSet = value; }
        }

        /// <summary>
        /// ��ѯ��ʽQueryType
        /// </summary>
        /// <value>QueryType</value>
        public String QueryType { get; set; }

        /// <summary>
        /// ��ѯ�ֶ�QueryField
        /// </summary>
        /// <value>QueryField</value>
        public String QueryField { get; set; }

        /// <summary>
        /// ��ѯ�ؼ���QueryKeywords
        /// </summary>
        /// <value>QueryKeywords</value>
        public String QueryKeywords { get; set; }

        /// <summary>
        /// ��ѯ����ʽSort
        /// </summary>
        /// <value>Sort</value>
        public Boolean Sort { get; set; }

        /// <summary>
        /// ��ѯ����ؼ���SortField
        /// </summary>
        /// <value>SortField</value>
        public String SortField { get; set; }

        /// <summary>
        /// ͳ�Ƽ�¼���ֶ�CountField
        /// </summary>
        /// <value>CountField</value>
        public String CountField { get; set; }

        /// <summary>
        /// ��ѯÿҳ��¼��PageSize
        /// </summary>
        /// <value>PageSize</value>
        public Int32 PageSize { get; set; }

        /// <summary>
        /// ��ѯ��ǰҳ��CurrentPage
        /// </summary>
        /// <value>CurrentPage</value>
        public Int32 CurrentPage { get; set; }

        /// <summary>
        /// ��ѯ��¼��RecordCount
        /// </summary>
        /// <value>RecordCount</value>
        public Int32 RecordCount { get; set; }

        /// <summary>
        /// ��Ч��¼��ValidRecordCount
        /// </summary>
        /// <value>ValidRecordCount</value>
        public Int32 ValidRecordCount { get; set; }

        /// <summary>
        /// ��Ч��¼ƽ��ֵAvgValue
        /// </summary>
        /// <value>AvgValue</value>
        public Double AvgValue { get; set; }

        /// <summary>
        /// ��Ч��¼���SumValue
        /// </summary>
        /// <value>SumValue</value>
        public Double SumValue { get; set; }
		
        /// <summary>
        /// ���ֵMaxValue
        /// </summary>
        /// <value>MaxValue</value>
        public object MaxValue { get; set; }

        /// <summary>
        /// ��СֵMinValue
        /// </summary>
        /// <value>MinValue</value>
        public Int32 MinValue { get; set; }

        /// <summary>
        /// �������ResultCode
        /// </summary>
        /// <value>ResultCode</value>
        public ResultState ResultCode { get; set; }

        /// <summary>
        /// ��Ϣ����MessageCode
        /// </summary>
        /// <value>MessageCode</value>
        public string[] MessageCode { get; set; }
        
        /// <summary>
        /// ���ݿ������ʽ����OPCode
        /// </summary>
        /// <value>OPCode</value>
        public OPType OPCode { get; set; }
        #endregion

        #region ����ʵ����в���
        /// <summary>
        /// �����б�
        /// </summary>
        private static string[] columnList 
                = new string[] {
                              "ObjectID"
                              ,"UserGroupID"
                              ,"UserGroupName"
                              ,"UserGroupContent"
                              ,"UserGroupRemark"
                              ,"DefaultPage"
                              ,"UpdateDate"
                                };

        //=====================================================================
        //  FunctionName : GetColumnName
        /// <summary>
        /// ȡ�������б�
        /// </summary>
        /// <returns>�����б�</returns>
        //=====================================================================
        public override string[] GetColumnName()
        {
            return columnList;
        }

        /// <summary>
        /// �����������б�
        /// </summary>
        private static SqlDbType[] columnTypeList 
                = new SqlDbType[] {
                              SqlDbType.UniqueIdentifier
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.DateTime
                                  };

        //=====================================================================
        //  FunctionName : GetColumnType
        /// <summary>
        /// ȡ�������������б�
        /// </summary>
        /// <returns>�����������б�</returns>
        //=====================================================================
        public override SqlDbType[] GetColumnType()
        {
            return columnTypeList;
        }

        /// <summary>
        /// �����б�
        /// </summary>
        private static string[] primaryKeyList 
                = new string[] {
                              "UserGroupID"
                                };

        //=====================================================================
        //  FunctionName : GetPrimaryKey
        /// <summary>
        /// ȡ�������б�
        /// </summary>
        /// <returns>�����б�</returns>
        //=====================================================================
        public override string[] GetPrimaryKey()
        {
            return primaryKeyList;
        }

        /// <summary>
        /// ����ΪNull���������б�
        /// </summary>
        private static string[] nullableList
                = new string[] {
                              "ObjectID"
                              ,"UserGroupContent"
                              ,"UserGroupRemark"
                              ,"DefaultPage"
                              ,"UpdateDate"
                                };


        //=====================================================================
        //  FunctionName : GetNullableColumn
        /// <summary>
        /// ȡ������ΪNull���������б�
        /// </summary>
        /// <returns>����ΪNull���������б�</returns>
        //=====================================================================
        public override string[] GetNullableColumn()
        {
            return nullableList;
        }

        public static IEnumerable<T_PM_UserGroupInfoApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_PM_UserGroupInfoApplicationData> collection = new List<T_PM_UserGroupInfoApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_PM_UserGroupInfoApplicationData applicationData = new T_PM_UserGroupInfoApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    UserGroupID = dr.ReadString("UserGroupID"),
    UserGroupName = dr.ReadString("UserGroupName"),
    UserGroupContent = dr.ReadString("UserGroupContent"),
    UserGroupRemark = dr.ReadString("UserGroupRemark"),
    DefaultPage = dr.ReadString("DefaultPage"),
    UpdateDate = dr.ReadDateTimeNullable("UpdateDate"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_PM_UserGroupInfoApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_PM_UserGroupInfoApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    UserGroupID = reader.ReadString("UserGroupID"),
    UserGroupName = reader.ReadString("UserGroupName"),
    UserGroupContent = reader.ReadString("UserGroupContent"),
    UserGroupRemark = reader.ReadString("UserGroupRemark"),
    DefaultPage = reader.ReadString("DefaultPage"),
    UpdateDate = reader.ReadDateTimeNullable(fromImportDataSet ? "UpdateDate" : "UpdateDate"),
    
                };
            }
            return null;
        }

        #endregion
        
        private DataTable GetImportColumn(DataTable dt)
        {

            return dt;
        }

    }
}

  
