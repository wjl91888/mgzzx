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
    /// T_BG_0601的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BG_0601ApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 发布号FBH
        /// </summary>
        /// <value>FBH</value>
        public String FBH { get; set; }
    
        /// <summary>
        /// 标题BT
        /// </summary>
        /// <value>BT</value>
        public String BT { get; set; }
    
        /// <summary>
        /// 语言LanguageID
        /// </summary>
        /// <value>LanguageID</value>
        public String LanguageID { get; set; }
    
        /// <summary>
        /// 发布栏目FBLM
        /// </summary>
        /// <value>FBLM</value>
        public String FBLM { get; set; }
    
        /// <summary>
        /// 发布部门FBBM
        /// </summary>
        /// <value>FBBM</value>
        public String FBBM { get; set; }
    
        /// <summary>
        /// 发布专题FBZT
        /// </summary>
        /// <value>FBZT</value>
        public String FBZT { get; set; }
    
        /// <summary>
        /// 信息类型XXLX
        /// </summary>
        /// <value>XXLX</value>
        public String XXLX { get; set; }
    
        /// <summary>
        /// 信息图片XXTPDZ
        /// </summary>
        /// <value>XXTPDZ</value>
        public String XXTPDZ { get; set; }
    
        /// <summary>
        /// 信息内容XXNR
        /// </summary>
        /// <value>XXNR</value>
        public String XXNR { get; set; }
    
        /// <summary>
        /// 附件FJXZDZ
        /// </summary>
        /// <value>FJXZDZ</value>
        public String FJXZDZ { get; set; }
    
        /// <summary>
        /// 批准人PZRJGH
        /// </summary>
        /// <value>PZRJGH</value>
        public String PZRJGH { get; set; }
    
        /// <summary>
        /// 信息状态XXZT
        /// </summary>
        /// <value>XXZT</value>
        public String XXZT { get; set; }
    
        /// <summary>
        /// 是否置顶IsTop
        /// </summary>
        /// <value>IsTop</value>
        public String IsTop { get; set; }
    
        /// <summary>
        /// 置顶序号TopSort
        /// </summary>
        /// <value>TopSort</value>
        public Int32? TopSort { get; set; }
    
        /// <summary>
        /// 推荐IsBest
        /// </summary>
        /// <value>IsBest</value>
        public String IsBest { get; set; }
    
        /// <summary>
        /// 有效时间YXSJRQ
        /// </summary>
        /// <value>YXSJRQ</value>
        public DateTime? YXSJRQ { get; set; }
    
        /// <summary>
        /// 发布人FBRJGH
        /// </summary>
        /// <value>FBRJGH</value>
        public String FBRJGH { get; set; }
    
        /// <summary>
        /// 发布时间FBSJRQ
        /// </summary>
        /// <value>FBSJRQ</value>
        public DateTime? FBSJRQ { get; set; }
    
        /// <summary>
        /// 发布时间开始FBSJRQBegin
        /// </summary>
        /// <value>FBSJRQBegin</value>
        public DateTime? FBSJRQBegin { get; set; }

        /// <summary>
        /// 发布时间结束FBSJRQEnd
        /// </summary>
        /// <value>FBSJRQEnd</value>
        public DateTime? FBSJRQEnd { get; set; }
    
        /// <summary>
        /// 发布IPFBIP
        /// </summary>
        /// <value>FBIP</value>
        public String FBIP { get; set; }
    
        /// <summary>
        /// 浏览次数LLCS
        /// </summary>
        /// <value>LLCS</value>
        public Int32? LLCS { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 发布号FBHBatch
        /// </summary>
        /// <value>FBH</value>
        public String FBHBatch { get; set; }

        /// <summary>
        /// 标题BTBatch
        /// </summary>
        /// <value>BT</value>
        public String BTBatch { get; set; }

        /// <summary>
        /// 语言LanguageIDBatch
        /// </summary>
        /// <value>LanguageID</value>
        public String LanguageIDBatch { get; set; }

        /// <summary>
        /// 发布栏目FBLMBatch
        /// </summary>
        /// <value>FBLM</value>
        public String FBLMBatch { get; set; }

        /// <summary>
        /// 发布部门FBBMBatch
        /// </summary>
        /// <value>FBBM</value>
        public String FBBMBatch { get; set; }

        /// <summary>
        /// 发布专题FBZTBatch
        /// </summary>
        /// <value>FBZT</value>
        public String FBZTBatch { get; set; }

        /// <summary>
        /// 信息类型XXLXBatch
        /// </summary>
        /// <value>XXLX</value>
        public String XXLXBatch { get; set; }

        /// <summary>
        /// 信息图片XXTPDZBatch
        /// </summary>
        /// <value>XXTPDZ</value>
        public String XXTPDZBatch { get; set; }

        /// <summary>
        /// 信息内容XXNRBatch
        /// </summary>
        /// <value>XXNR</value>
        public String XXNRBatch { get; set; }

        /// <summary>
        /// 附件FJXZDZBatch
        /// </summary>
        /// <value>FJXZDZ</value>
        public String FJXZDZBatch { get; set; }

        /// <summary>
        /// 批准人PZRJGHBatch
        /// </summary>
        /// <value>PZRJGH</value>
        public String PZRJGHBatch { get; set; }

        /// <summary>
        /// 信息状态XXZTBatch
        /// </summary>
        /// <value>XXZT</value>
        public String XXZTBatch { get; set; }

        /// <summary>
        /// 是否置顶IsTopBatch
        /// </summary>
        /// <value>IsTop</value>
        public String IsTopBatch { get; set; }

        /// <summary>
        /// 置顶序号TopSortBatch
        /// </summary>
        /// <value>TopSort</value>
        public String TopSortBatch { get; set; }

        /// <summary>
        /// 推荐IsBestBatch
        /// </summary>
        /// <value>IsBest</value>
        public String IsBestBatch { get; set; }

        /// <summary>
        /// 有效时间YXSJRQBatch
        /// </summary>
        /// <value>YXSJRQ</value>
        public String YXSJRQBatch { get; set; }

        /// <summary>
        /// 发布人FBRJGHBatch
        /// </summary>
        /// <value>FBRJGH</value>
        public String FBRJGHBatch { get; set; }

        /// <summary>
        /// 发布时间FBSJRQBatch
        /// </summary>
        /// <value>FBSJRQ</value>
        public String FBSJRQBatch { get; set; }

        /// <summary>
        /// 发布IPFBIPBatch
        /// </summary>
        /// <value>FBIP</value>
        public String FBIPBatch { get; set; }

        /// <summary>
        /// 浏览次数LLCSBatch
        /// </summary>
        /// <value>LLCS</value>
        public String LLCSBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 发布号批量更新FBHValue
        /// </summary>
        /// <value>FBHValue</value>
        public String FBHValue { get; set; }
    
        /// <summary>
        /// 标题批量更新BTValue
        /// </summary>
        /// <value>BTValue</value>
        public String BTValue { get; set; }
    
        /// <summary>
        /// 语言批量更新LanguageIDValue
        /// </summary>
        /// <value>LanguageIDValue</value>
        public String LanguageIDValue { get; set; }
    
        /// <summary>
        /// 发布栏目批量更新FBLMValue
        /// </summary>
        /// <value>FBLMValue</value>
        public String FBLMValue { get; set; }
    
        /// <summary>
        /// 发布部门批量更新FBBMValue
        /// </summary>
        /// <value>FBBMValue</value>
        public String FBBMValue { get; set; }
    
        /// <summary>
        /// 发布专题批量更新FBZTValue
        /// </summary>
        /// <value>FBZTValue</value>
        public String FBZTValue { get; set; }
    
        /// <summary>
        /// 信息类型批量更新XXLXValue
        /// </summary>
        /// <value>XXLXValue</value>
        public String XXLXValue { get; set; }
    
        /// <summary>
        /// 信息图片批量更新XXTPDZValue
        /// </summary>
        /// <value>XXTPDZValue</value>
        public String XXTPDZValue { get; set; }
    
        /// <summary>
        /// 信息内容批量更新XXNRValue
        /// </summary>
        /// <value>XXNRValue</value>
        public String XXNRValue { get; set; }
    
        /// <summary>
        /// 附件批量更新FJXZDZValue
        /// </summary>
        /// <value>FJXZDZValue</value>
        public String FJXZDZValue { get; set; }
    
        /// <summary>
        /// 批准人批量更新PZRJGHValue
        /// </summary>
        /// <value>PZRJGHValue</value>
        public String PZRJGHValue { get; set; }
    
        /// <summary>
        /// 信息状态批量更新XXZTValue
        /// </summary>
        /// <value>XXZTValue</value>
        public String XXZTValue { get; set; }
    
        /// <summary>
        /// 是否置顶批量更新IsTopValue
        /// </summary>
        /// <value>IsTopValue</value>
        public String IsTopValue { get; set; }
    
        /// <summary>
        /// 置顶序号批量更新TopSortValue
        /// </summary>
        /// <value>TopSortValue</value>
        public Int32? TopSortValue { get; set; }
    
        /// <summary>
        /// 推荐批量更新IsBestValue
        /// </summary>
        /// <value>IsBestValue</value>
        public String IsBestValue { get; set; }
    
        /// <summary>
        /// 有效时间批量更新YXSJRQValue
        /// </summary>
        /// <value>YXSJRQValue</value>
        public DateTime? YXSJRQValue { get; set; }
    
        /// <summary>
        /// 发布人批量更新FBRJGHValue
        /// </summary>
        /// <value>FBRJGHValue</value>
        public String FBRJGHValue { get; set; }
    
        /// <summary>
        /// 发布时间批量更新FBSJRQValue
        /// </summary>
        /// <value>FBSJRQValue</value>
        public DateTime? FBSJRQValue { get; set; }
    
        /// <summary>
        /// 发布IP批量更新FBIPValue
        /// </summary>
        /// <value>FBIPValue</value>
        public String FBIPValue { get; set; }
    
        /// <summary>
        /// 浏览次数批量更新LLCSValue
        /// </summary>
        /// <value>LLCSValue</value>
        public Int32? LLCSValue { get; set; }
        
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
                              "FBH"
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
        /// 取得允许为Null的列名称列表
        /// </summary>
        /// <returns>允许为Null的列名称列表</returns>
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

  
