/****************************************************** 
FileName:DictionaryApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.Dictionary
{
    //=========================================================================
    //  ClassName : DictionaryApplicationData
    /// <summary>
    /// Dictionary������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class DictionaryApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// ����DM
        /// </summary>
        /// <value>DM</value>
        public String DM { get; set; }
    
        /// <summary>
        /// ����LX
        /// </summary>
        /// <value>LX</value>
        public String LX { get; set; }
    
        /// <summary>
        /// ����MC
        /// </summary>
        /// <value>MC</value>
        public String MC { get; set; }
    
        /// <summary>
        /// �ϼ�����SJDM
        /// </summary>
        /// <value>SJDM</value>
        public String SJDM { get; set; }
    
        /// <summary>
        /// ˵��SM
        /// </summary>
        /// <value>SM</value>
        public String SM { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// ����DMBatch
        /// </summary>
        /// <value>DM</value>
        public String DMBatch { get; set; }

        /// <summary>
        /// ����LXBatch
        /// </summary>
        /// <value>LX</value>
        public String LXBatch { get; set; }

        /// <summary>
        /// ����MCBatch
        /// </summary>
        /// <value>MC</value>
        public String MCBatch { get; set; }

        /// <summary>
        /// �ϼ�����SJDMBatch
        /// </summary>
        /// <value>SJDM</value>
        public String SJDMBatch { get; set; }

        /// <summary>
        /// ˵��SMBatch
        /// </summary>
        /// <value>SM</value>
        public String SMBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// ������������DMValue
        /// </summary>
        /// <value>DMValue</value>
        public String DMValue { get; set; }
    
        /// <summary>
        /// ������������LXValue
        /// </summary>
        /// <value>LXValue</value>
        public String LXValue { get; set; }
    
        /// <summary>
        /// ������������MCValue
        /// </summary>
        /// <value>MCValue</value>
        public String MCValue { get; set; }
    
        /// <summary>
        /// �ϼ�������������SJDMValue
        /// </summary>
        /// <value>SJDMValue</value>
        public String SJDMValue { get; set; }
    
        /// <summary>
        /// ˵����������SMValue
        /// </summary>
        /// <value>SMValue</value>
        public String SMValue { get; set; }
        
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
                              ,"DM"
                              ,"LX"
                              ,"MC"
                              ,"SJDM"
                              ,"SM"
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
                              "DM"
                              ,"LX"
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
                              ,"SJDM"
                              ,"SM"
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

        public static IEnumerable<DictionaryApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<DictionaryApplicationData> collection = new List<DictionaryApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                DictionaryApplicationData applicationData = new DictionaryApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    DM = dr.ReadString("DM"),
    LX = dr.ReadString("LX"),
    MC = dr.ReadString("MC"),
    SJDM = dr.ReadString("SJDM"),
    SM = dr.ReadString("SM"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static DictionaryApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new DictionaryApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    DM = reader.ReadString("DM"),
    LX = reader.ReadString("LX"),
    MC = reader.ReadString("MC"),
    SJDM = reader.ReadString("SJDM"),
    SM = reader.ReadString("SM"),
    
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

  
