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
    /// T_BG_0602的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BG_0602ApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 栏目号LMH
        /// </summary>
        /// <value>LMH</value>
        public String LMH { get; set; }
    
        /// <summary>
        /// 语言LanguageID
        /// </summary>
        /// <value>LanguageID</value>
        public String LanguageID { get; set; }
    
        /// <summary>
        /// 栏目名LMM
        /// </summary>
        /// <value>LMM</value>
        public String LMM { get; set; }
    
        /// <summary>
        /// 上级栏目SJLMH
        /// </summary>
        /// <value>SJLMH</value>
        public String SJLMH { get; set; }
    
        /// <summary>
        /// 栏目图片LMTP
        /// </summary>
        /// <value>LMTP</value>
        public String LMTP { get; set; }
    
        /// <summary>
        /// 栏目显示内容LMNR
        /// </summary>
        /// <value>LMNR</value>
        public String LMNR { get; set; }
    
        /// <summary>
        /// 栏目列表样式LMLBYS
        /// </summary>
        /// <value>LMLBYS</value>
        public String LMLBYS { get; set; }
    
        /// <summary>
        /// 列表内容栏目SFLBLM
        /// </summary>
        /// <value>SFLBLM</value>
        public String SFLBLM { get; set; }
    
        /// <summary>
        /// 外部栏目SFWBURL
        /// </summary>
        /// <value>SFWBURL</value>
        public String SFWBURL { get; set; }
    
        /// <summary>
        /// 外部栏目连接WBURL
        /// </summary>
        /// <value>WBURL</value>
        public String WBURL { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 栏目号LMHBatch
        /// </summary>
        /// <value>LMH</value>
        public String LMHBatch { get; set; }

        /// <summary>
        /// 语言LanguageIDBatch
        /// </summary>
        /// <value>LanguageID</value>
        public String LanguageIDBatch { get; set; }

        /// <summary>
        /// 栏目名LMMBatch
        /// </summary>
        /// <value>LMM</value>
        public String LMMBatch { get; set; }

        /// <summary>
        /// 上级栏目SJLMHBatch
        /// </summary>
        /// <value>SJLMH</value>
        public String SJLMHBatch { get; set; }

        /// <summary>
        /// 栏目图片LMTPBatch
        /// </summary>
        /// <value>LMTP</value>
        public String LMTPBatch { get; set; }

        /// <summary>
        /// 栏目显示内容LMNRBatch
        /// </summary>
        /// <value>LMNR</value>
        public String LMNRBatch { get; set; }

        /// <summary>
        /// 栏目列表样式LMLBYSBatch
        /// </summary>
        /// <value>LMLBYS</value>
        public String LMLBYSBatch { get; set; }

        /// <summary>
        /// 列表内容栏目SFLBLMBatch
        /// </summary>
        /// <value>SFLBLM</value>
        public String SFLBLMBatch { get; set; }

        /// <summary>
        /// 外部栏目SFWBURLBatch
        /// </summary>
        /// <value>SFWBURL</value>
        public String SFWBURLBatch { get; set; }

        /// <summary>
        /// 外部栏目连接WBURLBatch
        /// </summary>
        /// <value>WBURL</value>
        public String WBURLBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 栏目号批量更新LMHValue
        /// </summary>
        /// <value>LMHValue</value>
        public String LMHValue { get; set; }
    
        /// <summary>
        /// 语言批量更新LanguageIDValue
        /// </summary>
        /// <value>LanguageIDValue</value>
        public String LanguageIDValue { get; set; }
    
        /// <summary>
        /// 栏目名批量更新LMMValue
        /// </summary>
        /// <value>LMMValue</value>
        public String LMMValue { get; set; }
    
        /// <summary>
        /// 上级栏目批量更新SJLMHValue
        /// </summary>
        /// <value>SJLMHValue</value>
        public String SJLMHValue { get; set; }
    
        /// <summary>
        /// 栏目图片批量更新LMTPValue
        /// </summary>
        /// <value>LMTPValue</value>
        public String LMTPValue { get; set; }
    
        /// <summary>
        /// 栏目显示内容批量更新LMNRValue
        /// </summary>
        /// <value>LMNRValue</value>
        public String LMNRValue { get; set; }
    
        /// <summary>
        /// 栏目列表样式批量更新LMLBYSValue
        /// </summary>
        /// <value>LMLBYSValue</value>
        public String LMLBYSValue { get; set; }
    
        /// <summary>
        /// 列表内容栏目批量更新SFLBLMValue
        /// </summary>
        /// <value>SFLBLMValue</value>
        public String SFLBLMValue { get; set; }
    
        /// <summary>
        /// 外部栏目批量更新SFWBURLValue
        /// </summary>
        /// <value>SFWBURLValue</value>
        public String SFWBURLValue { get; set; }
    
        /// <summary>
        /// 外部栏目连接批量更新WBURLValue
        /// </summary>
        /// <value>WBURLValue</value>
        public String WBURLValue { get; set; }
        
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
                              "LMH"
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
                              ,"LanguageID"
                              ,"SJLMH"
                              ,"LMTP"
                              ,"WBURL"
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

  
