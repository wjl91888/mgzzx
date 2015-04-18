/****************************************************** 
FileName:T_PM_PurviewInfoApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_PM_PurviewInfo
{
    //=========================================================================
    //  ClassName : T_PM_PurviewInfoApplicationData
    /// <summary>
    /// T_PM_PurviewInfo������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_PM_PurviewInfoApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// PurviewID
        /// </summary>
        /// <value>PurviewID</value>
        public String PurviewID { get; set; }
    
        /// <summary>
        /// PurviewName
        /// </summary>
        /// <value>PurviewName</value>
        public String PurviewName { get; set; }
    
        /// <summary>
        /// PurviewTypeID
        /// </summary>
        /// <value>PurviewTypeID</value>
        public String PurviewTypeID { get; set; }
    
        /// <summary>
        /// PurviewContent
        /// </summary>
        /// <value>PurviewContent</value>
        public String PurviewContent { get; set; }
    
        /// <summary>
        /// PurviewRemark
        /// </summary>
        /// <value>PurviewRemark</value>
        public String PurviewRemark { get; set; }
    
        /// <summary>
        /// IsPageMenu
        /// </summary>
        /// <value>IsPageMenu</value>
        public Boolean? IsPageMenu { get; set; }
    
        /// <summary>
        /// PageFileName
        /// </summary>
        /// <value>PageFileName</value>
        public String PageFileName { get; set; }
    
        /// <summary>
        /// PageFileParameter
        /// </summary>
        /// <value>PageFileParameter</value>
        public String PageFileParameter { get; set; }
    
        /// <summary>
        /// PageFilePath
        /// </summary>
        /// <value>PageFilePath</value>
        public String PageFilePath { get; set; }
    
        /// <summary>
        /// UpdateDate
        /// </summary>
        /// <value>UpdateDate</value>
        public DateTime? UpdateDate { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// PurviewIDBatch
        /// </summary>
        /// <value>PurviewID</value>
        public String PurviewIDBatch { get; set; }

        /// <summary>
        /// PurviewNameBatch
        /// </summary>
        /// <value>PurviewName</value>
        public String PurviewNameBatch { get; set; }

        /// <summary>
        /// PurviewTypeIDBatch
        /// </summary>
        /// <value>PurviewTypeID</value>
        public String PurviewTypeIDBatch { get; set; }

        /// <summary>
        /// PurviewContentBatch
        /// </summary>
        /// <value>PurviewContent</value>
        public String PurviewContentBatch { get; set; }

        /// <summary>
        /// PurviewRemarkBatch
        /// </summary>
        /// <value>PurviewRemark</value>
        public String PurviewRemarkBatch { get; set; }

        /// <summary>
        /// IsPageMenuBatch
        /// </summary>
        /// <value>IsPageMenu</value>
        public String IsPageMenuBatch { get; set; }

        /// <summary>
        /// PageFileNameBatch
        /// </summary>
        /// <value>PageFileName</value>
        public String PageFileNameBatch { get; set; }

        /// <summary>
        /// PageFileParameterBatch
        /// </summary>
        /// <value>PageFileParameter</value>
        public String PageFileParameterBatch { get; set; }

        /// <summary>
        /// PageFilePathBatch
        /// </summary>
        /// <value>PageFilePath</value>
        public String PageFilePathBatch { get; set; }

        /// <summary>
        /// UpdateDateBatch
        /// </summary>
        /// <value>UpdateDate</value>
        public String UpdateDateBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// ��������PurviewIDValue
        /// </summary>
        /// <value>PurviewIDValue</value>
        public String PurviewIDValue { get; set; }
    
        /// <summary>
        /// ��������PurviewNameValue
        /// </summary>
        /// <value>PurviewNameValue</value>
        public String PurviewNameValue { get; set; }
    
        /// <summary>
        /// ��������PurviewTypeIDValue
        /// </summary>
        /// <value>PurviewTypeIDValue</value>
        public String PurviewTypeIDValue { get; set; }
    
        /// <summary>
        /// ��������PurviewContentValue
        /// </summary>
        /// <value>PurviewContentValue</value>
        public String PurviewContentValue { get; set; }
    
        /// <summary>
        /// ��������PurviewRemarkValue
        /// </summary>
        /// <value>PurviewRemarkValue</value>
        public String PurviewRemarkValue { get; set; }
    
        /// <summary>
        /// ��������IsPageMenuValue
        /// </summary>
        /// <value>IsPageMenuValue</value>
        public Boolean? IsPageMenuValue { get; set; }
    
        /// <summary>
        /// ��������PageFileNameValue
        /// </summary>
        /// <value>PageFileNameValue</value>
        public String PageFileNameValue { get; set; }
    
        /// <summary>
        /// ��������PageFileParameterValue
        /// </summary>
        /// <value>PageFileParameterValue</value>
        public String PageFileParameterValue { get; set; }
    
        /// <summary>
        /// ��������PageFilePathValue
        /// </summary>
        /// <value>PageFilePathValue</value>
        public String PageFilePathValue { get; set; }
    
        /// <summary>
        /// ��������UpdateDateValue
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
                              ,"PurviewID"
                              ,"PurviewName"
                              ,"PurviewTypeID"
                              ,"PurviewContent"
                              ,"PurviewRemark"
                              ,"IsPageMenu"
                              ,"PageFileName"
                              ,"PageFileParameter"
                              ,"PageFilePath"
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
                              ,SqlDbType.Bit
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
                              "PurviewID"
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
                              ,"PurviewContent"
                              ,"PurviewRemark"
                              ,"IsPageMenu"
                              ,"PageFileName"
                              ,"PageFileParameter"
                              ,"PageFilePath"
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

        public static IEnumerable<T_PM_PurviewInfoApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_PM_PurviewInfoApplicationData> collection = new List<T_PM_PurviewInfoApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_PM_PurviewInfoApplicationData applicationData = new T_PM_PurviewInfoApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    PurviewID = dr.ReadString("PurviewID"),
    PurviewName = dr.ReadString("PurviewName"),
    PurviewTypeID = dr.ReadString("PurviewTypeID"),
    PurviewContent = dr.ReadString("PurviewContent"),
    PurviewRemark = dr.ReadString("PurviewRemark"),
    IsPageMenu = dr.ReadBooleanNullable("IsPageMenu"),
    PageFileName = dr.ReadString("PageFileName"),
    PageFileParameter = dr.ReadString("PageFileParameter"),
    PageFilePath = dr.ReadString("PageFilePath"),
    UpdateDate = dr.ReadDateTimeNullable("UpdateDate"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_PM_PurviewInfoApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_PM_PurviewInfoApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    PurviewID = reader.ReadString("PurviewID"),
    PurviewName = reader.ReadString("PurviewName"),
    PurviewTypeID = reader.ReadString("PurviewTypeID"),
    PurviewContent = reader.ReadString("PurviewContent"),
    PurviewRemark = reader.ReadString("PurviewRemark"),
    IsPageMenu = reader.ReadBooleanNullable(fromImportDataSet ? "IsPageMenu" : "IsPageMenu"),
    PageFileName = reader.ReadString("PageFileName"),
    PageFileParameter = reader.ReadString("PageFileParameter"),
    PageFilePath = reader.ReadString("PageFilePath"),
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

  
