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
    /// FilterReport的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class FilterReportApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 报表名称BGMC
        /// </summary>
        /// <value>BGMC</value>
        public String BGMC { get; set; }
    
        /// <summary>
        /// 用户编号UserID
        /// </summary>
        /// <value>UserID</value>
        public String UserID { get; set; }
    
        /// <summary>
        /// 报告类型BGLX
        /// </summary>
        /// <value>BGLX</value>
        public String BGLX { get; set; }
    
        /// <summary>
        /// 共享报告GXBG
        /// </summary>
        /// <value>GXBG</value>
        public String GXBG { get; set; }
    
        /// <summary>
        /// 系统报告XTBG
        /// </summary>
        /// <value>XTBG</value>
        public String XTBG { get; set; }
    
        /// <summary>
        /// 报告条件BGCXTJ
        /// </summary>
        /// <value>BGCXTJ</value>
        public String BGCXTJ { get; set; }
    
        /// <summary>
        /// 创建时间BGCJSJ
        /// </summary>
        /// <value>BGCJSJ</value>
        public DateTime? BGCJSJ { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 报表名称BGMCBatch
        /// </summary>
        /// <value>BGMC</value>
        public String BGMCBatch { get; set; }

        /// <summary>
        /// 用户编号UserIDBatch
        /// </summary>
        /// <value>UserID</value>
        public String UserIDBatch { get; set; }

        /// <summary>
        /// 报告类型BGLXBatch
        /// </summary>
        /// <value>BGLX</value>
        public String BGLXBatch { get; set; }

        /// <summary>
        /// 共享报告GXBGBatch
        /// </summary>
        /// <value>GXBG</value>
        public String GXBGBatch { get; set; }

        /// <summary>
        /// 系统报告XTBGBatch
        /// </summary>
        /// <value>XTBG</value>
        public String XTBGBatch { get; set; }

        /// <summary>
        /// 报告条件BGCXTJBatch
        /// </summary>
        /// <value>BGCXTJ</value>
        public String BGCXTJBatch { get; set; }

        /// <summary>
        /// 创建时间BGCJSJBatch
        /// </summary>
        /// <value>BGCJSJ</value>
        public String BGCJSJBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 报表名称批量更新BGMCValue
        /// </summary>
        /// <value>BGMCValue</value>
        public String BGMCValue { get; set; }
    
        /// <summary>
        /// 用户编号批量更新UserIDValue
        /// </summary>
        /// <value>UserIDValue</value>
        public String UserIDValue { get; set; }
    
        /// <summary>
        /// 报告类型批量更新BGLXValue
        /// </summary>
        /// <value>BGLXValue</value>
        public String BGLXValue { get; set; }
    
        /// <summary>
        /// 共享报告批量更新GXBGValue
        /// </summary>
        /// <value>GXBGValue</value>
        public String GXBGValue { get; set; }
    
        /// <summary>
        /// 系统报告批量更新XTBGValue
        /// </summary>
        /// <value>XTBGValue</value>
        public String XTBGValue { get; set; }
    
        /// <summary>
        /// 报告条件批量更新BGCXTJValue
        /// </summary>
        /// <value>BGCXTJValue</value>
        public String BGCXTJValue { get; set; }
    
        /// <summary>
        /// 创建时间批量更新BGCJSJValue
        /// </summary>
        /// <value>BGCJSJValue</value>
        public DateTime? BGCJSJValue { get; set; }
        
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
                              ,SqlDbType.DateTime
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
                              "ObjectID"
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

  
