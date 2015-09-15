/****************************************************** 
FileName:T_BG_0601ApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_BG_0601
{
    //=========================================================================
    //  ClassName : T_BG_0601ApplicationData
    /// <summary>
    /// T_BG_0601������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BG_0601ApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// ������FBH
        /// </summary>
        /// <value>FBH</value>
        public String FBH { get; set; }
    
        /// <summary>
        /// ����BT
        /// </summary>
        /// <value>BT</value>
        public String BT { get; set; }
    
        /// <summary>
        /// ����LanguageID
        /// </summary>
        /// <value>LanguageID</value>
        public String LanguageID { get; set; }
    
        /// <summary>
        /// ������ĿFBLM
        /// </summary>
        /// <value>FBLM</value>
        public String FBLM { get; set; }
    
        /// <summary>
        /// ��������FBBM
        /// </summary>
        /// <value>FBBM</value>
        public String FBBM { get; set; }
    
        /// <summary>
        /// ����ר��FBZT
        /// </summary>
        /// <value>FBZT</value>
        public String FBZT { get; set; }
    
        /// <summary>
        /// ��Ϣ����XXLX
        /// </summary>
        /// <value>XXLX</value>
        public String XXLX { get; set; }
    
        /// <summary>
        /// ��ϢͼƬXXTPDZ
        /// </summary>
        /// <value>XXTPDZ</value>
        public String XXTPDZ { get; set; }
    
        /// <summary>
        /// ��Ϣ����XXNR
        /// </summary>
        /// <value>XXNR</value>
        public String XXNR { get; set; }
    
        /// <summary>
        /// ����FJXZDZ
        /// </summary>
        /// <value>FJXZDZ</value>
        public String FJXZDZ { get; set; }
    
        /// <summary>
        /// ��׼��PZRJGH
        /// </summary>
        /// <value>PZRJGH</value>
        public String PZRJGH { get; set; }
    
        /// <summary>
        /// ��Ϣ״̬XXZT
        /// </summary>
        /// <value>XXZT</value>
        public String XXZT { get; set; }
    
        /// <summary>
        /// �Ƿ��ö�IsTop
        /// </summary>
        /// <value>IsTop</value>
        public String IsTop { get; set; }
    
        /// <summary>
        /// �ö����TopSort
        /// </summary>
        /// <value>TopSort</value>
        public Int32? TopSort { get; set; }
    
        /// <summary>
        /// �Ƽ�IsBest
        /// </summary>
        /// <value>IsBest</value>
        public String IsBest { get; set; }
    
        /// <summary>
        /// ��Чʱ��YXSJRQ
        /// </summary>
        /// <value>YXSJRQ</value>
        public DateTime? YXSJRQ { get; set; }
    
        /// <summary>
        /// ������FBRJGH
        /// </summary>
        /// <value>FBRJGH</value>
        public String FBRJGH { get; set; }
    
        /// <summary>
        /// ����ʱ��FBSJRQ
        /// </summary>
        /// <value>FBSJRQ</value>
        public DateTime? FBSJRQ { get; set; }
    
        /// <summary>
        /// ����ʱ�俪ʼFBSJRQBegin
        /// </summary>
        /// <value>FBSJRQBegin</value>
        public DateTime? FBSJRQBegin { get; set; }

        /// <summary>
        /// ����ʱ�����FBSJRQEnd
        /// </summary>
        /// <value>FBSJRQEnd</value>
        public DateTime? FBSJRQEnd { get; set; }
    
        /// <summary>
        /// ����IPFBIP
        /// </summary>
        /// <value>FBIP</value>
        public String FBIP { get; set; }
    
        /// <summary>
        /// �������LLCS
        /// </summary>
        /// <value>LLCS</value>
        public Int32? LLCS { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// ������FBHBatch
        /// </summary>
        /// <value>FBH</value>
        public String FBHBatch { get; set; }

        /// <summary>
        /// ����BTBatch
        /// </summary>
        /// <value>BT</value>
        public String BTBatch { get; set; }

        /// <summary>
        /// ����LanguageIDBatch
        /// </summary>
        /// <value>LanguageID</value>
        public String LanguageIDBatch { get; set; }

        /// <summary>
        /// ������ĿFBLMBatch
        /// </summary>
        /// <value>FBLM</value>
        public String FBLMBatch { get; set; }

        /// <summary>
        /// ��������FBBMBatch
        /// </summary>
        /// <value>FBBM</value>
        public String FBBMBatch { get; set; }

        /// <summary>
        /// ����ר��FBZTBatch
        /// </summary>
        /// <value>FBZT</value>
        public String FBZTBatch { get; set; }

        /// <summary>
        /// ��Ϣ����XXLXBatch
        /// </summary>
        /// <value>XXLX</value>
        public String XXLXBatch { get; set; }

        /// <summary>
        /// ��ϢͼƬXXTPDZBatch
        /// </summary>
        /// <value>XXTPDZ</value>
        public String XXTPDZBatch { get; set; }

        /// <summary>
        /// ��Ϣ����XXNRBatch
        /// </summary>
        /// <value>XXNR</value>
        public String XXNRBatch { get; set; }

        /// <summary>
        /// ����FJXZDZBatch
        /// </summary>
        /// <value>FJXZDZ</value>
        public String FJXZDZBatch { get; set; }

        /// <summary>
        /// ��׼��PZRJGHBatch
        /// </summary>
        /// <value>PZRJGH</value>
        public String PZRJGHBatch { get; set; }

        /// <summary>
        /// ��Ϣ״̬XXZTBatch
        /// </summary>
        /// <value>XXZT</value>
        public String XXZTBatch { get; set; }

        /// <summary>
        /// �Ƿ��ö�IsTopBatch
        /// </summary>
        /// <value>IsTop</value>
        public String IsTopBatch { get; set; }

        /// <summary>
        /// �ö����TopSortBatch
        /// </summary>
        /// <value>TopSort</value>
        public String TopSortBatch { get; set; }

        /// <summary>
        /// �Ƽ�IsBestBatch
        /// </summary>
        /// <value>IsBest</value>
        public String IsBestBatch { get; set; }

        /// <summary>
        /// ��Чʱ��YXSJRQBatch
        /// </summary>
        /// <value>YXSJRQ</value>
        public String YXSJRQBatch { get; set; }

        /// <summary>
        /// ������FBRJGHBatch
        /// </summary>
        /// <value>FBRJGH</value>
        public String FBRJGHBatch { get; set; }

        /// <summary>
        /// ����ʱ��FBSJRQBatch
        /// </summary>
        /// <value>FBSJRQ</value>
        public String FBSJRQBatch { get; set; }

        /// <summary>
        /// ����IPFBIPBatch
        /// </summary>
        /// <value>FBIP</value>
        public String FBIPBatch { get; set; }

        /// <summary>
        /// �������LLCSBatch
        /// </summary>
        /// <value>LLCS</value>
        public String LLCSBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// ��������������FBHValue
        /// </summary>
        /// <value>FBHValue</value>
        public String FBHValue { get; set; }
    
        /// <summary>
        /// ������������BTValue
        /// </summary>
        /// <value>BTValue</value>
        public String BTValue { get; set; }
    
        /// <summary>
        /// ������������LanguageIDValue
        /// </summary>
        /// <value>LanguageIDValue</value>
        public String LanguageIDValue { get; set; }
    
        /// <summary>
        /// ������Ŀ��������FBLMValue
        /// </summary>
        /// <value>FBLMValue</value>
        public String FBLMValue { get; set; }
    
        /// <summary>
        /// ����������������FBBMValue
        /// </summary>
        /// <value>FBBMValue</value>
        public String FBBMValue { get; set; }
    
        /// <summary>
        /// ����ר����������FBZTValue
        /// </summary>
        /// <value>FBZTValue</value>
        public String FBZTValue { get; set; }
    
        /// <summary>
        /// ��Ϣ������������XXLXValue
        /// </summary>
        /// <value>XXLXValue</value>
        public String XXLXValue { get; set; }
    
        /// <summary>
        /// ��ϢͼƬ��������XXTPDZValue
        /// </summary>
        /// <value>XXTPDZValue</value>
        public String XXTPDZValue { get; set; }
    
        /// <summary>
        /// ��Ϣ������������XXNRValue
        /// </summary>
        /// <value>XXNRValue</value>
        public String XXNRValue { get; set; }
    
        /// <summary>
        /// ������������FJXZDZValue
        /// </summary>
        /// <value>FJXZDZValue</value>
        public String FJXZDZValue { get; set; }
    
        /// <summary>
        /// ��׼����������PZRJGHValue
        /// </summary>
        /// <value>PZRJGHValue</value>
        public String PZRJGHValue { get; set; }
    
        /// <summary>
        /// ��Ϣ״̬��������XXZTValue
        /// </summary>
        /// <value>XXZTValue</value>
        public String XXZTValue { get; set; }
    
        /// <summary>
        /// �Ƿ��ö���������IsTopValue
        /// </summary>
        /// <value>IsTopValue</value>
        public String IsTopValue { get; set; }
    
        /// <summary>
        /// �ö������������TopSortValue
        /// </summary>
        /// <value>TopSortValue</value>
        public Int32? TopSortValue { get; set; }
    
        /// <summary>
        /// �Ƽ���������IsBestValue
        /// </summary>
        /// <value>IsBestValue</value>
        public String IsBestValue { get; set; }
    
        /// <summary>
        /// ��Чʱ����������YXSJRQValue
        /// </summary>
        /// <value>YXSJRQValue</value>
        public DateTime? YXSJRQValue { get; set; }
    
        /// <summary>
        /// ��������������FBRJGHValue
        /// </summary>
        /// <value>FBRJGHValue</value>
        public String FBRJGHValue { get; set; }
    
        /// <summary>
        /// ����ʱ����������FBSJRQValue
        /// </summary>
        /// <value>FBSJRQValue</value>
        public DateTime? FBSJRQValue { get; set; }
    
        /// <summary>
        /// ����IP��������FBIPValue
        /// </summary>
        /// <value>FBIPValue</value>
        public String FBIPValue { get; set; }
    
        /// <summary>
        /// ���������������LLCSValue
        /// </summary>
        /// <value>LLCSValue</value>
        public Int32? LLCSValue { get; set; }
        
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
                              ,"FBH"
                              ,"BT"
                              ,"LanguageID"
                              ,"FBLM"
                              ,"FBBM"
                              ,"FBZT"
                              ,"XXLX"
                              ,"XXTPDZ"
                              ,"XXNR"
                              ,"FJXZDZ"
                              ,"PZRJGH"
                              ,"XXZT"
                              ,"IsTop"
                              ,"TopSort"
                              ,"IsBest"
                              ,"YXSJRQ"
                              ,"FBRJGH"
                              ,"FBSJRQ"
                              ,"FBIP"
                              ,"LLCS"
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
                              ,SqlDbType.NText
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.Int
                              ,SqlDbType.NVarChar
                              ,SqlDbType.DateTime
                              ,SqlDbType.NVarChar
                              ,SqlDbType.DateTime
                              ,SqlDbType.NVarChar
                              ,SqlDbType.Int
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
                              "FBH"
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
                              ,"FBBM"
                              ,"FBZT"
                              ,"XXTPDZ"
                              ,"FJXZDZ"
                              ,"PZRJGH"
                              ,"XXZT"
                              ,"IsTop"
                              ,"TopSort"
                              ,"IsBest"
                              ,"YXSJRQ"
                              ,"FBRJGH"
                              ,"FBSJRQ"
                              ,"FBIP"
                              ,"LLCS"
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

        public static IEnumerable<T_BG_0601ApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_BG_0601ApplicationData> collection = new List<T_BG_0601ApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_BG_0601ApplicationData applicationData = new T_BG_0601ApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    FBH = dr.ReadString("FBH"),
    BT = dr.ReadString("BT"),
    LanguageID = dr.ReadString("LanguageID"),
    FBLM = dr.ReadString("FBLM"),
    FBBM = dr.ReadString("FBBM"),
    FBZT = dr.ReadString("FBZT"),
    XXLX = dr.ReadString("XXLX"),
    XXTPDZ = dr.ReadString("XXTPDZ"),
    XXNR = dr.ReadString("XXNR"),
    FJXZDZ = dr.ReadString("FJXZDZ"),
    PZRJGH = dr.ReadString("PZRJGH"),
    XXZT = dr.ReadString("XXZT"),
    IsTop = dr.ReadString("IsTop"),
    TopSort = dr.ReadInt32Nullable("TopSort"),
    IsBest = dr.ReadString("IsBest"),
    YXSJRQ = dr.ReadDateTimeNullable("YXSJRQ"),
    FBRJGH = dr.ReadString("FBRJGH"),
    FBSJRQ = dr.ReadDateTimeNullable("FBSJRQ"),
    FBIP = dr.ReadString("FBIP"),
    LLCS = dr.ReadInt32Nullable("LLCS"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_BG_0601ApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_BG_0601ApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    FBH = reader.ReadString("FBH"),
    BT = reader.ReadString("BT"),
    LanguageID = reader.ReadString("LanguageID"),
    FBLM = reader.ReadString("FBLM"),
    FBBM = reader.ReadString("FBBM"),
    FBZT = reader.ReadString("FBZT"),
    XXLX = reader.ReadString("XXLX"),
    XXTPDZ = reader.ReadString("XXTPDZ"),
    XXNR = reader.ReadString("XXNR"),
    FJXZDZ = reader.ReadString("FJXZDZ"),
    PZRJGH = reader.ReadString("PZRJGH"),
    XXZT = reader.ReadString("XXZT"),
    IsTop = reader.ReadString("IsTop"),
    TopSort = reader.ReadInt32Nullable(fromImportDataSet ? "TopSort" : "TopSort"),
    IsBest = reader.ReadString("IsBest"),
    YXSJRQ = reader.ReadDateTimeNullable(fromImportDataSet ? "YXSJRQ" : "YXSJRQ"),
    FBRJGH = reader.ReadString("FBRJGH"),
    FBSJRQ = reader.ReadDateTimeNullable(fromImportDataSet ? "FBSJRQ" : "FBSJRQ"),
    FBIP = reader.ReadString("FBIP"),
    LLCS = reader.ReadInt32Nullable(fromImportDataSet ? "LLCS" : "LLCS"),
    
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

  
