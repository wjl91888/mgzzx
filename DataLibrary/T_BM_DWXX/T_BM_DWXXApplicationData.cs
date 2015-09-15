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
    /// T_BM_DWXX的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_DWXXApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 单位编号DWBH
        /// </summary>
        /// <value>DWBH</value>
        public String DWBH { get; set; }
    
        /// <summary>
        /// 单位名称DWMC
        /// </summary>
        /// <value>DWMC</value>
        public String DWMC { get; set; }
    
        /// <summary>
        /// 上级单位SJDWBH
        /// </summary>
        /// <value>SJDWBH</value>
        public String SJDWBH { get; set; }
    
        /// <summary>
        /// 地址DZ
        /// </summary>
        /// <value>DZ</value>
        public String DZ { get; set; }
    
        /// <summary>
        /// 邮编YB
        /// </summary>
        /// <value>YB</value>
        public String YB { get; set; }
    
        /// <summary>
        /// 联系部门LXBM
        /// </summary>
        /// <value>LXBM</value>
        public String LXBM { get; set; }
    
        /// <summary>
        /// 联系电话LXDH
        /// </summary>
        /// <value>LXDH</value>
        public String LXDH { get; set; }
    
        /// <summary>
        /// EmailEmail
        /// </summary>
        /// <value>Email</value>
        public String Email { get; set; }
    
        /// <summary>
        /// 联系人LXR
        /// </summary>
        /// <value>LXR</value>
        public String LXR { get; set; }
    
        /// <summary>
        /// 手机SJ
        /// </summary>
        /// <value>SJ</value>
        public String SJ { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 单位编号DWBHBatch
        /// </summary>
        /// <value>DWBH</value>
        public String DWBHBatch { get; set; }

        /// <summary>
        /// 单位名称DWMCBatch
        /// </summary>
        /// <value>DWMC</value>
        public String DWMCBatch { get; set; }

        /// <summary>
        /// 上级单位SJDWBHBatch
        /// </summary>
        /// <value>SJDWBH</value>
        public String SJDWBHBatch { get; set; }

        /// <summary>
        /// 地址DZBatch
        /// </summary>
        /// <value>DZ</value>
        public String DZBatch { get; set; }

        /// <summary>
        /// 邮编YBBatch
        /// </summary>
        /// <value>YB</value>
        public String YBBatch { get; set; }

        /// <summary>
        /// 联系部门LXBMBatch
        /// </summary>
        /// <value>LXBM</value>
        public String LXBMBatch { get; set; }

        /// <summary>
        /// 联系电话LXDHBatch
        /// </summary>
        /// <value>LXDH</value>
        public String LXDHBatch { get; set; }

        /// <summary>
        /// EmailEmailBatch
        /// </summary>
        /// <value>Email</value>
        public String EmailBatch { get; set; }

        /// <summary>
        /// 联系人LXRBatch
        /// </summary>
        /// <value>LXR</value>
        public String LXRBatch { get; set; }

        /// <summary>
        /// 手机SJBatch
        /// </summary>
        /// <value>SJ</value>
        public String SJBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 单位编号批量更新DWBHValue
        /// </summary>
        /// <value>DWBHValue</value>
        public String DWBHValue { get; set; }
    
        /// <summary>
        /// 单位名称批量更新DWMCValue
        /// </summary>
        /// <value>DWMCValue</value>
        public String DWMCValue { get; set; }
    
        /// <summary>
        /// 上级单位批量更新SJDWBHValue
        /// </summary>
        /// <value>SJDWBHValue</value>
        public String SJDWBHValue { get; set; }
    
        /// <summary>
        /// 地址批量更新DZValue
        /// </summary>
        /// <value>DZValue</value>
        public String DZValue { get; set; }
    
        /// <summary>
        /// 邮编批量更新YBValue
        /// </summary>
        /// <value>YBValue</value>
        public String YBValue { get; set; }
    
        /// <summary>
        /// 联系部门批量更新LXBMValue
        /// </summary>
        /// <value>LXBMValue</value>
        public String LXBMValue { get; set; }
    
        /// <summary>
        /// 联系电话批量更新LXDHValue
        /// </summary>
        /// <value>LXDHValue</value>
        public String LXDHValue { get; set; }
    
        /// <summary>
        /// Email批量更新EmailValue
        /// </summary>
        /// <value>EmailValue</value>
        public String EmailValue { get; set; }
    
        /// <summary>
        /// 联系人批量更新LXRValue
        /// </summary>
        /// <value>LXRValue</value>
        public String LXRValue { get; set; }
    
        /// <summary>
        /// 手机批量更新SJValue
        /// </summary>
        /// <value>SJValue</value>
        public String SJValue { get; set; }
        
        #endregion
        #region 一对一相关表

        #endregion
        #region 功能属性
        /// <summary>
        /// ResultSet
        /// </summary>
        private DataSet m_ResultSet = new DataSet();

        /// <summary>
        /// 查询返回结果集ResultSet
        /// </summary>
        /// <value>ResultSet</value>
        public DataSet ResultSet
        {
            get { return m_ResultSet; }
            set { m_ResultSet = value; }
        }

        /// <summary>
        /// 查询方式QueryType
        /// </summary>
        /// <value>QueryType</value>
        public String QueryType { get; set; }

        /// <summary>
        /// 查询字段QueryField
        /// </summary>
        /// <value>QueryField</value>
        public String QueryField { get; set; }

        /// <summary>
        /// 查询关键字QueryKeywords
        /// </summary>
        /// <value>QueryKeywords</value>
        public String QueryKeywords { get; set; }

        /// <summary>
        /// 查询排序方式Sort
        /// </summary>
        /// <value>Sort</value>
        public Boolean Sort { get; set; }

        /// <summary>
        /// 查询排序关键字SortField
        /// </summary>
        /// <value>SortField</value>
        public String SortField { get; set; }

        /// <summary>
        /// 统计记录数字段CountField
        /// </summary>
        /// <value>CountField</value>
        public String CountField { get; set; }

        /// <summary>
        /// 查询每页记录数PageSize
        /// </summary>
        /// <value>PageSize</value>
        public Int32 PageSize { get; set; }

        /// <summary>
        /// 查询当前页码CurrentPage
        /// </summary>
        /// <value>CurrentPage</value>
        public Int32 CurrentPage { get; set; }

        /// <summary>
        /// 查询记录数RecordCount
        /// </summary>
        /// <value>RecordCount</value>
        public Int32 RecordCount { get; set; }

        /// <summary>
        /// 有效记录数ValidRecordCount
        /// </summary>
        /// <value>ValidRecordCount</value>
        public Int32 ValidRecordCount { get; set; }

        /// <summary>
        /// 有效记录平均值AvgValue
        /// </summary>
        /// <value>AvgValue</value>
        public Double AvgValue { get; set; }

        /// <summary>
        /// 有效记录求和SumValue
        /// </summary>
        /// <value>SumValue</value>
        public Double SumValue { get; set; }
		
        /// <summary>
        /// 最大值MaxValue
        /// </summary>
        /// <value>MaxValue</value>
        public object MaxValue { get; set; }

        /// <summary>
        /// 最小值MinValue
        /// </summary>
        /// <value>MinValue</value>
        public Int32 MinValue { get; set; }

        /// <summary>
        /// 结果代码ResultCode
        /// </summary>
        /// <value>ResultCode</value>
        public ResultState ResultCode { get; set; }

        /// <summary>
        /// 消息代码MessageCode
        /// </summary>
        /// <value>MessageCode</value>
        public string[] MessageCode { get; set; }
        
        /// <summary>
        /// 数据库操作方式代码OPCode
        /// </summary>
        /// <value>OPCode</value>
        public OPType OPCode { get; set; }
        #endregion

        #region 数据实体的列操作
        /// <summary>
        /// 列名列表
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
        /// 取得列名列表
        /// </summary>
        /// <returns>列名列表</returns>
        //=====================================================================
        public override string[] GetColumnName()
        {
            return columnList;
        }

        /// <summary>
        /// 列数据类型列表
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
        /// 取得列数据类型列表
        /// </summary>
        /// <returns>列数据类型列表</returns>
        //=====================================================================
        public override SqlDbType[] GetColumnType()
        {
            return columnTypeList;
        }

        /// <summary>
        /// 主键列表
        /// </summary>
        private static string[] primaryKeyList 
                = new string[] {
                              "DWBH"
                                };

        //=====================================================================
        //  FunctionName : GetPrimaryKey
        /// <summary>
        /// 取得主键列表
        /// </summary>
        /// <returns>主键列表</returns>
        //=====================================================================
        public override string[] GetPrimaryKey()
        {
            return primaryKeyList;
        }

        /// <summary>
        /// 允许为Null的列名称列表
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
        /// 取得允许为Null的列名称列表
        /// </summary>
        /// <returns>允许为Null的列名称列表</returns>
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

  
