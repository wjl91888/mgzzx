/****************************************************** 
FileName:FilterReportApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.FilterReport
{
    //=========================================================================
    //  ClassName : FilterReportApplicationData
    /// <summary>
    /// FilterReport������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class FilterReportApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// ��������BGMC
        /// </summary>
        /// <value>BGMC</value>
        public String BGMC { get; set; }
    
        /// <summary>
        /// �û����UserID
        /// </summary>
        /// <value>UserID</value>
        public String UserID { get; set; }
    
        /// <summary>
        /// ��������BGLX
        /// </summary>
        /// <value>BGLX</value>
        public String BGLX { get; set; }
    
        /// <summary>
        /// ������GXBG
        /// </summary>
        /// <value>GXBG</value>
        public String GXBG { get; set; }
    
        /// <summary>
        /// ϵͳ����XTBG
        /// </summary>
        /// <value>XTBG</value>
        public String XTBG { get; set; }
    
        /// <summary>
        /// ��������BGCXTJ
        /// </summary>
        /// <value>BGCXTJ</value>
        public String BGCXTJ { get; set; }
    
        /// <summary>
        /// ����ʱ��BGCJSJ
        /// </summary>
        /// <value>BGCJSJ</value>
        public DateTime? BGCJSJ { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// ��������BGMCBatch
        /// </summary>
        /// <value>BGMC</value>
        public String BGMCBatch { get; set; }

        /// <summary>
        /// �û����UserIDBatch
        /// </summary>
        /// <value>UserID</value>
        public String UserIDBatch { get; set; }

        /// <summary>
        /// ��������BGLXBatch
        /// </summary>
        /// <value>BGLX</value>
        public String BGLXBatch { get; set; }

        /// <summary>
        /// ������GXBGBatch
        /// </summary>
        /// <value>GXBG</value>
        public String GXBGBatch { get; set; }

        /// <summary>
        /// ϵͳ����XTBGBatch
        /// </summary>
        /// <value>XTBG</value>
        public String XTBGBatch { get; set; }

        /// <summary>
        /// ��������BGCXTJBatch
        /// </summary>
        /// <value>BGCXTJ</value>
        public String BGCXTJBatch { get; set; }

        /// <summary>
        /// ����ʱ��BGCJSJBatch
        /// </summary>
        /// <value>BGCJSJ</value>
        public String BGCJSJBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// ����������������BGMCValue
        /// </summary>
        /// <value>BGMCValue</value>
        public String BGMCValue { get; set; }
    
        /// <summary>
        /// �û������������UserIDValue
        /// </summary>
        /// <value>UserIDValue</value>
        public String UserIDValue { get; set; }
    
        /// <summary>
        /// ����������������BGLXValue
        /// </summary>
        /// <value>BGLXValue</value>
        public String BGLXValue { get; set; }
    
        /// <summary>
        /// ��������������GXBGValue
        /// </summary>
        /// <value>GXBGValue</value>
        public String GXBGValue { get; set; }
    
        /// <summary>
        /// ϵͳ������������XTBGValue
        /// </summary>
        /// <value>XTBGValue</value>
        public String XTBGValue { get; set; }
    
        /// <summary>
        /// ����������������BGCXTJValue
        /// </summary>
        /// <value>BGCXTJValue</value>
        public String BGCXTJValue { get; set; }
    
        /// <summary>
        /// ����ʱ����������BGCJSJValue
        /// </summary>
        /// <value>BGCJSJValue</value>
        public DateTime? BGCJSJValue { get; set; }
        
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
                              ,"BGMC"
                              ,"UserID"
                              ,"BGLX"
                              ,"GXBG"
                              ,"XTBG"
                              ,"BGCXTJ"
                              ,"BGCJSJ"
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
                              "ObjectID"
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

        public static IEnumerable<FilterReportApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<FilterReportApplicationData> collection = new List<FilterReportApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                FilterReportApplicationData applicationData = new FilterReportApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    BGMC = dr.ReadString("BGMC"),
    UserID = dr.ReadString("UserID"),
    BGLX = dr.ReadString("BGLX"),
    GXBG = dr.ReadString("GXBG"),
    XTBG = dr.ReadString("XTBG"),
    BGCXTJ = dr.ReadString("BGCXTJ"),
    BGCJSJ = dr.ReadDateTimeNullable("BGCJSJ"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static FilterReportApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new FilterReportApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    BGMC = reader.ReadString("BGMC"),
    UserID = reader.ReadString("UserID"),
    BGLX = reader.ReadString("BGLX"),
    GXBG = reader.ReadString("GXBG"),
    XTBG = reader.ReadString("XTBG"),
    BGCXTJ = reader.ReadString("BGCXTJ"),
    BGCJSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "BGCJSJ" : "BGCJSJ"),
    
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

  
