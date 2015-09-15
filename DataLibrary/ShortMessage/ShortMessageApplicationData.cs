/****************************************************** 
FileName:ShortMessageApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.ShortMessage
{
    //=========================================================================
    //  ClassName : ShortMessageApplicationData
    /// <summary>
    /// ShortMessage������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class ShortMessageApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// ����DXXBT
        /// </summary>
        /// <value>DXXBT</value>
        public String DXXBT { get; set; }
    
        /// <summary>
        /// ����DXXLX
        /// </summary>
        /// <value>DXXLX</value>
        public String DXXLX { get; set; }
    
        /// <summary>
        /// ����DXXNR
        /// </summary>
        /// <value>DXXNR</value>
        public String DXXNR { get; set; }
    
        /// <summary>
        /// ����DXXFJ
        /// </summary>
        /// <value>DXXFJ</value>
        public String DXXFJ { get; set; }
    
        /// <summary>
        /// ����ʱ��FSSJ
        /// </summary>
        /// <value>FSSJ</value>
        public DateTime? FSSJ { get; set; }
    
        /// <summary>
        /// ����ʱ�俪ʼFSSJBegin
        /// </summary>
        /// <value>FSSJBegin</value>
        public DateTime? FSSJBegin { get; set; }

        /// <summary>
        /// ����ʱ�����FSSJEnd
        /// </summary>
        /// <value>FSSJEnd</value>
        public DateTime? FSSJEnd { get; set; }
    
        /// <summary>
        /// ������FSR
        /// </summary>
        /// <value>FSR</value>
        public String FSR { get; set; }
    
        /// <summary>
        /// ���Ͳ���FSBM
        /// </summary>
        /// <value>FSBM</value>
        public String FSBM { get; set; }
    
        /// <summary>
        /// ����IPFSIP
        /// </summary>
        /// <value>FSIP</value>
        public String FSIP { get; set; }
    
        /// <summary>
        /// ������JSR
        /// </summary>
        /// <value>JSR</value>
        public String JSR { get; set; }
    
        /// <summary>
        /// �鿴״̬SFCK
        /// </summary>
        /// <value>SFCK</value>
        public Boolean? SFCK { get; set; }
    
        /// <summary>
        /// �鿴ʱ��CKSJ
        /// </summary>
        /// <value>CKSJ</value>
        public DateTime? CKSJ { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// ����DXXBTBatch
        /// </summary>
        /// <value>DXXBT</value>
        public String DXXBTBatch { get; set; }

        /// <summary>
        /// ����DXXLXBatch
        /// </summary>
        /// <value>DXXLX</value>
        public String DXXLXBatch { get; set; }

        /// <summary>
        /// ����DXXNRBatch
        /// </summary>
        /// <value>DXXNR</value>
        public String DXXNRBatch { get; set; }

        /// <summary>
        /// ����DXXFJBatch
        /// </summary>
        /// <value>DXXFJ</value>
        public String DXXFJBatch { get; set; }

        /// <summary>
        /// ����ʱ��FSSJBatch
        /// </summary>
        /// <value>FSSJ</value>
        public String FSSJBatch { get; set; }

        /// <summary>
        /// ������FSRBatch
        /// </summary>
        /// <value>FSR</value>
        public String FSRBatch { get; set; }

        /// <summary>
        /// ���Ͳ���FSBMBatch
        /// </summary>
        /// <value>FSBM</value>
        public String FSBMBatch { get; set; }

        /// <summary>
        /// ����IPFSIPBatch
        /// </summary>
        /// <value>FSIP</value>
        public String FSIPBatch { get; set; }

        /// <summary>
        /// ������JSRBatch
        /// </summary>
        /// <value>JSR</value>
        public String JSRBatch { get; set; }

        /// <summary>
        /// �鿴״̬SFCKBatch
        /// </summary>
        /// <value>SFCK</value>
        public String SFCKBatch { get; set; }

        /// <summary>
        /// �鿴ʱ��CKSJBatch
        /// </summary>
        /// <value>CKSJ</value>
        public String CKSJBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// ������������DXXBTValue
        /// </summary>
        /// <value>DXXBTValue</value>
        public String DXXBTValue { get; set; }
    
        /// <summary>
        /// ������������DXXLXValue
        /// </summary>
        /// <value>DXXLXValue</value>
        public String DXXLXValue { get; set; }
    
        /// <summary>
        /// ������������DXXNRValue
        /// </summary>
        /// <value>DXXNRValue</value>
        public String DXXNRValue { get; set; }
    
        /// <summary>
        /// ������������DXXFJValue
        /// </summary>
        /// <value>DXXFJValue</value>
        public String DXXFJValue { get; set; }
    
        /// <summary>
        /// ����ʱ����������FSSJValue
        /// </summary>
        /// <value>FSSJValue</value>
        public DateTime? FSSJValue { get; set; }
    
        /// <summary>
        /// ��������������FSRValue
        /// </summary>
        /// <value>FSRValue</value>
        public String FSRValue { get; set; }
    
        /// <summary>
        /// ���Ͳ�����������FSBMValue
        /// </summary>
        /// <value>FSBMValue</value>
        public String FSBMValue { get; set; }
    
        /// <summary>
        /// ����IP��������FSIPValue
        /// </summary>
        /// <value>FSIPValue</value>
        public String FSIPValue { get; set; }
    
        /// <summary>
        /// ��������������JSRValue
        /// </summary>
        /// <value>JSRValue</value>
        public String JSRValue { get; set; }
    
        /// <summary>
        /// �鿴״̬��������SFCKValue
        /// </summary>
        /// <value>SFCKValue</value>
        public Boolean? SFCKValue { get; set; }
    
        /// <summary>
        /// �鿴ʱ����������CKSJValue
        /// </summary>
        /// <value>CKSJValue</value>
        public DateTime? CKSJValue { get; set; }
        
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
                              ,"DXXBT"
                              ,"DXXLX"
                              ,"DXXNR"
                              ,"DXXFJ"
                              ,"FSSJ"
                              ,"FSR"
                              ,"FSBM"
                              ,"FSIP"
                              ,"JSR"
                              ,"SFCK"
                              ,"CKSJ"
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
                              ,SqlDbType.DateTime
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.Bit
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
                              "DXXLX"
                              ,"DXXNR"
                              ,"DXXFJ"
                              ,"FSSJ"
                              ,"FSR"
                              ,"FSBM"
                              ,"FSIP"
                              ,"SFCK"
                              ,"CKSJ"
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

        public static IEnumerable<ShortMessageApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<ShortMessageApplicationData> collection = new List<ShortMessageApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                ShortMessageApplicationData applicationData = new ShortMessageApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    DXXBT = dr.ReadString("DXXBT"),
    DXXLX = dr.ReadString("DXXLX"),
    DXXNR = dr.ReadString("DXXNR"),
    DXXFJ = dr.ReadString("DXXFJ"),
    FSSJ = dr.ReadDateTimeNullable("FSSJ"),
    FSR = dr.ReadString("FSR"),
    FSBM = dr.ReadString("FSBM"),
    FSIP = dr.ReadString("FSIP"),
    JSR = dr.ReadString("JSR"),
    SFCK = dr.ReadBooleanNullable("SFCK"),
    CKSJ = dr.ReadDateTimeNullable("CKSJ"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static ShortMessageApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new ShortMessageApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    DXXBT = reader.ReadString("DXXBT"),
    DXXLX = reader.ReadString("DXXLX"),
    DXXNR = reader.ReadString("DXXNR"),
    DXXFJ = reader.ReadString("DXXFJ"),
    FSSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "FSSJ" : "FSSJ"),
    FSR = reader.ReadString("FSR"),
    FSBM = reader.ReadString("FSBM"),
    FSIP = reader.ReadString("FSIP"),
    JSR = reader.ReadString("JSR"),
    SFCK = reader.ReadBooleanNullable(fromImportDataSet ? "SFCK" : "SFCK"),
    CKSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "CKSJ" : "CKSJ"),
    
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

  
