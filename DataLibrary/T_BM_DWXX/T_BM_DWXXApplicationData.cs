/****************************************************** 
FileName:T_BM_DWXXApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_BM_DWXX
{
    //=========================================================================
    //  ClassName : T_BM_DWXXApplicationData
    /// <summary>
    /// T_BM_DWXX������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_DWXXApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// ��λ���DWBH
        /// </summary>
        /// <value>DWBH</value>
        public String DWBH { get; set; }
    
        /// <summary>
        /// ��λ����DWMC
        /// </summary>
        /// <value>DWMC</value>
        public String DWMC { get; set; }
    
        /// <summary>
        /// �ϼ���λSJDWBH
        /// </summary>
        /// <value>SJDWBH</value>
        public String SJDWBH { get; set; }
    
        /// <summary>
        /// ��ַDZ
        /// </summary>
        /// <value>DZ</value>
        public String DZ { get; set; }
    
        /// <summary>
        /// �ʱ�YB
        /// </summary>
        /// <value>YB</value>
        public String YB { get; set; }
    
        /// <summary>
        /// ��ϵ����LXBM
        /// </summary>
        /// <value>LXBM</value>
        public String LXBM { get; set; }
    
        /// <summary>
        /// ��ϵ�绰LXDH
        /// </summary>
        /// <value>LXDH</value>
        public String LXDH { get; set; }
    
        /// <summary>
        /// EmailEmail
        /// </summary>
        /// <value>Email</value>
        public String Email { get; set; }
    
        /// <summary>
        /// ��ϵ��LXR
        /// </summary>
        /// <value>LXR</value>
        public String LXR { get; set; }
    
        /// <summary>
        /// �ֻ�SJ
        /// </summary>
        /// <value>SJ</value>
        public String SJ { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// ��λ���DWBHBatch
        /// </summary>
        /// <value>DWBH</value>
        public String DWBHBatch { get; set; }

        /// <summary>
        /// ��λ����DWMCBatch
        /// </summary>
        /// <value>DWMC</value>
        public String DWMCBatch { get; set; }

        /// <summary>
        /// �ϼ���λSJDWBHBatch
        /// </summary>
        /// <value>SJDWBH</value>
        public String SJDWBHBatch { get; set; }

        /// <summary>
        /// ��ַDZBatch
        /// </summary>
        /// <value>DZ</value>
        public String DZBatch { get; set; }

        /// <summary>
        /// �ʱ�YBBatch
        /// </summary>
        /// <value>YB</value>
        public String YBBatch { get; set; }

        /// <summary>
        /// ��ϵ����LXBMBatch
        /// </summary>
        /// <value>LXBM</value>
        public String LXBMBatch { get; set; }

        /// <summary>
        /// ��ϵ�绰LXDHBatch
        /// </summary>
        /// <value>LXDH</value>
        public String LXDHBatch { get; set; }

        /// <summary>
        /// EmailEmailBatch
        /// </summary>
        /// <value>Email</value>
        public String EmailBatch { get; set; }

        /// <summary>
        /// ��ϵ��LXRBatch
        /// </summary>
        /// <value>LXR</value>
        public String LXRBatch { get; set; }

        /// <summary>
        /// �ֻ�SJBatch
        /// </summary>
        /// <value>SJ</value>
        public String SJBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// ��λ�����������DWBHValue
        /// </summary>
        /// <value>DWBHValue</value>
        public String DWBHValue { get; set; }
    
        /// <summary>
        /// ��λ������������DWMCValue
        /// </summary>
        /// <value>DWMCValue</value>
        public String DWMCValue { get; set; }
    
        /// <summary>
        /// �ϼ���λ��������SJDWBHValue
        /// </summary>
        /// <value>SJDWBHValue</value>
        public String SJDWBHValue { get; set; }
    
        /// <summary>
        /// ��ַ��������DZValue
        /// </summary>
        /// <value>DZValue</value>
        public String DZValue { get; set; }
    
        /// <summary>
        /// �ʱ���������YBValue
        /// </summary>
        /// <value>YBValue</value>
        public String YBValue { get; set; }
    
        /// <summary>
        /// ��ϵ������������LXBMValue
        /// </summary>
        /// <value>LXBMValue</value>
        public String LXBMValue { get; set; }
    
        /// <summary>
        /// ��ϵ�绰��������LXDHValue
        /// </summary>
        /// <value>LXDHValue</value>
        public String LXDHValue { get; set; }
    
        /// <summary>
        /// Email��������EmailValue
        /// </summary>
        /// <value>EmailValue</value>
        public String EmailValue { get; set; }
    
        /// <summary>
        /// ��ϵ����������LXRValue
        /// </summary>
        /// <value>LXRValue</value>
        public String LXRValue { get; set; }
    
        /// <summary>
        /// �ֻ���������SJValue
        /// </summary>
        /// <value>SJValue</value>
        public String SJValue { get; set; }
        
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
                              ,"DWBH"
                              ,"DWMC"
                              ,"SJDWBH"
                              ,"DZ"
                              ,"YB"
                              ,"LXBM"
                              ,"LXDH"
                              ,"Email"
                              ,"LXR"
                              ,"SJ"
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
                              "DWBH"
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
                              ,"SJDWBH"
                              ,"DZ"
                              ,"YB"
                              ,"LXBM"
                              ,"LXDH"
                              ,"Email"
                              ,"LXR"
                              ,"SJ"
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

        public static IEnumerable<T_BM_DWXXApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_BM_DWXXApplicationData> collection = new List<T_BM_DWXXApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_BM_DWXXApplicationData applicationData = new T_BM_DWXXApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    DWBH = dr.ReadString("DWBH"),
    DWMC = dr.ReadString("DWMC"),
    SJDWBH = dr.ReadString("SJDWBH"),
    DZ = dr.ReadString("DZ"),
    YB = dr.ReadString("YB"),
    LXBM = dr.ReadString("LXBM"),
    LXDH = dr.ReadString("LXDH"),
    Email = dr.ReadString("Email"),
    LXR = dr.ReadString("LXR"),
    SJ = dr.ReadString("SJ"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_BM_DWXXApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_BM_DWXXApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    DWBH = reader.ReadString("DWBH"),
    DWMC = reader.ReadString("DWMC"),
    SJDWBH = reader.ReadString("SJDWBH"),
    DZ = reader.ReadString("DZ"),
    YB = reader.ReadString("YB"),
    LXBM = reader.ReadString("LXBM"),
    LXDH = reader.ReadString("LXDH"),
    Email = reader.ReadString("Email"),
    LXR = reader.ReadString("LXR"),
    SJ = reader.ReadString("SJ"),
    
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

  
