/****************************************************** 
FileName:T_BG_0602ApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_BG_0602
{
    //=========================================================================
    //  ClassName : T_BG_0602ApplicationData
    /// <summary>
    /// T_BG_0602������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BG_0602ApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// ��Ŀ��LMH
        /// </summary>
        /// <value>LMH</value>
        public String LMH { get; set; }
    
        /// <summary>
        /// ����LanguageID
        /// </summary>
        /// <value>LanguageID</value>
        public String LanguageID { get; set; }
    
        /// <summary>
        /// ��Ŀ��LMM
        /// </summary>
        /// <value>LMM</value>
        public String LMM { get; set; }
    
        /// <summary>
        /// �ϼ���ĿSJLMH
        /// </summary>
        /// <value>SJLMH</value>
        public String SJLMH { get; set; }
    
        /// <summary>
        /// ��ĿͼƬLMTP
        /// </summary>
        /// <value>LMTP</value>
        public String LMTP { get; set; }
    
        /// <summary>
        /// ��Ŀ��ʾ����LMNR
        /// </summary>
        /// <value>LMNR</value>
        public String LMNR { get; set; }
    
        /// <summary>
        /// ��Ŀ�б���ʽLMLBYS
        /// </summary>
        /// <value>LMLBYS</value>
        public String LMLBYS { get; set; }
    
        /// <summary>
        /// �б�������ĿSFLBLM
        /// </summary>
        /// <value>SFLBLM</value>
        public String SFLBLM { get; set; }
    
        /// <summary>
        /// �ⲿ��ĿSFWBURL
        /// </summary>
        /// <value>SFWBURL</value>
        public String SFWBURL { get; set; }
    
        /// <summary>
        /// �ⲿ��Ŀ����WBURL
        /// </summary>
        /// <value>WBURL</value>
        public String WBURL { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// ��Ŀ��LMHBatch
        /// </summary>
        /// <value>LMH</value>
        public String LMHBatch { get; set; }

        /// <summary>
        /// ����LanguageIDBatch
        /// </summary>
        /// <value>LanguageID</value>
        public String LanguageIDBatch { get; set; }

        /// <summary>
        /// ��Ŀ��LMMBatch
        /// </summary>
        /// <value>LMM</value>
        public String LMMBatch { get; set; }

        /// <summary>
        /// �ϼ���ĿSJLMHBatch
        /// </summary>
        /// <value>SJLMH</value>
        public String SJLMHBatch { get; set; }

        /// <summary>
        /// ��ĿͼƬLMTPBatch
        /// </summary>
        /// <value>LMTP</value>
        public String LMTPBatch { get; set; }

        /// <summary>
        /// ��Ŀ��ʾ����LMNRBatch
        /// </summary>
        /// <value>LMNR</value>
        public String LMNRBatch { get; set; }

        /// <summary>
        /// ��Ŀ�б���ʽLMLBYSBatch
        /// </summary>
        /// <value>LMLBYS</value>
        public String LMLBYSBatch { get; set; }

        /// <summary>
        /// �б�������ĿSFLBLMBatch
        /// </summary>
        /// <value>SFLBLM</value>
        public String SFLBLMBatch { get; set; }

        /// <summary>
        /// �ⲿ��ĿSFWBURLBatch
        /// </summary>
        /// <value>SFWBURL</value>
        public String SFWBURLBatch { get; set; }

        /// <summary>
        /// �ⲿ��Ŀ����WBURLBatch
        /// </summary>
        /// <value>WBURL</value>
        public String WBURLBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// ��Ŀ����������LMHValue
        /// </summary>
        /// <value>LMHValue</value>
        public String LMHValue { get; set; }
    
        /// <summary>
        /// ������������LanguageIDValue
        /// </summary>
        /// <value>LanguageIDValue</value>
        public String LanguageIDValue { get; set; }
    
        /// <summary>
        /// ��Ŀ����������LMMValue
        /// </summary>
        /// <value>LMMValue</value>
        public String LMMValue { get; set; }
    
        /// <summary>
        /// �ϼ���Ŀ��������SJLMHValue
        /// </summary>
        /// <value>SJLMHValue</value>
        public String SJLMHValue { get; set; }
    
        /// <summary>
        /// ��ĿͼƬ��������LMTPValue
        /// </summary>
        /// <value>LMTPValue</value>
        public String LMTPValue { get; set; }
    
        /// <summary>
        /// ��Ŀ��ʾ������������LMNRValue
        /// </summary>
        /// <value>LMNRValue</value>
        public String LMNRValue { get; set; }
    
        /// <summary>
        /// ��Ŀ�б���ʽ��������LMLBYSValue
        /// </summary>
        /// <value>LMLBYSValue</value>
        public String LMLBYSValue { get; set; }
    
        /// <summary>
        /// �б�������Ŀ��������SFLBLMValue
        /// </summary>
        /// <value>SFLBLMValue</value>
        public String SFLBLMValue { get; set; }
    
        /// <summary>
        /// �ⲿ��Ŀ��������SFWBURLValue
        /// </summary>
        /// <value>SFWBURLValue</value>
        public String SFWBURLValue { get; set; }
    
        /// <summary>
        /// �ⲿ��Ŀ������������WBURLValue
        /// </summary>
        /// <value>WBURLValue</value>
        public String WBURLValue { get; set; }
        
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
                              ,"LMH"
                              ,"LanguageID"
                              ,"LMM"
                              ,"SJLMH"
                              ,"LMTP"
                              ,"LMNR"
                              ,"LMLBYS"
                              ,"SFLBLM"
                              ,"SFWBURL"
                              ,"WBURL"
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
                              "LMH"
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
                              ,"LanguageID"
                              ,"SJLMH"
                              ,"LMTP"
                              ,"WBURL"
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

        public static IEnumerable<T_BG_0602ApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_BG_0602ApplicationData> collection = new List<T_BG_0602ApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_BG_0602ApplicationData applicationData = new T_BG_0602ApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    LMH = dr.ReadString("LMH"),
    LanguageID = dr.ReadString("LanguageID"),
    LMM = dr.ReadString("LMM"),
    SJLMH = dr.ReadString("SJLMH"),
    LMTP = dr.ReadString("LMTP"),
    LMNR = dr.ReadString("LMNR"),
    LMLBYS = dr.ReadString("LMLBYS"),
    SFLBLM = dr.ReadString("SFLBLM"),
    SFWBURL = dr.ReadString("SFWBURL"),
    WBURL = dr.ReadString("WBURL"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_BG_0602ApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_BG_0602ApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    LMH = reader.ReadString("LMH"),
    LanguageID = reader.ReadString("LanguageID"),
    LMM = reader.ReadString("LMM"),
    SJLMH = reader.ReadString("SJLMH"),
    LMTP = reader.ReadString("LMTP"),
    LMNR = reader.ReadString("LMNR"),
    LMLBYS = reader.ReadString("LMLBYS"),
    SFLBLM = reader.ReadString("SFLBLM"),
    SFWBURL = reader.ReadString("SFWBURL"),
    WBURL = reader.ReadString("WBURL"),
    
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

  
