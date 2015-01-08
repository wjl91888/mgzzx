/****************************************************** 
FileName:DictionaryApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.Dictionary
{
    //=========================================================================
    //  ClassName : DictionaryApplicationData
    /// <summary>
    /// Dictionary的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class DictionaryApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 代码DM
        /// </summary>
        /// <value>DM</value>
        public String DM { get; set; }
    
        /// <summary>
        /// 类型LX
        /// </summary>
        /// <value>LX</value>
        public String LX { get; set; }
    
        /// <summary>
        /// 名称MC
        /// </summary>
        /// <value>MC</value>
        public String MC { get; set; }
    
        /// <summary>
        /// 上级代码SJDM
        /// </summary>
        /// <value>SJDM</value>
        public String SJDM { get; set; }
    
        /// <summary>
        /// 说明SM
        /// </summary>
        /// <value>SM</value>
        public String SM { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 代码DMBatch
        /// </summary>
        /// <value>DM</value>
        public String DMBatch { get; set; }

        /// <summary>
        /// 类型LXBatch
        /// </summary>
        /// <value>LX</value>
        public String LXBatch { get; set; }

        /// <summary>
        /// 名称MCBatch
        /// </summary>
        /// <value>MC</value>
        public String MCBatch { get; set; }

        /// <summary>
        /// 上级代码SJDMBatch
        /// </summary>
        /// <value>SJDM</value>
        public String SJDMBatch { get; set; }

        /// <summary>
        /// 说明SMBatch
        /// </summary>
        /// <value>SM</value>
        public String SMBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 代码批量更新DMValue
        /// </summary>
        /// <value>DMValue</value>
        public String DMValue { get; set; }
    
        /// <summary>
        /// 类型批量更新LXValue
        /// </summary>
        /// <value>LXValue</value>
        public String LXValue { get; set; }
    
        /// <summary>
        /// 名称批量更新MCValue
        /// </summary>
        /// <value>MCValue</value>
        public String MCValue { get; set; }
    
        /// <summary>
        /// 上级代码批量更新SJDMValue
        /// </summary>
        /// <value>SJDMValue</value>
        public String SJDMValue { get; set; }
    
        /// <summary>
        /// 说明批量更新SMValue
        /// </summary>
        /// <value>SMValue</value>
        public String SMValue { get; set; }
        
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
                              ,"DM"
                              ,"LX"
                              ,"MC"
                              ,"SJDM"
                              ,"SM"
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
                              "DM"
                              ,"LX"
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
                              ,"SJDM"
                              ,"SM"
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

		internal static DictionaryApplicationData FillDataFromDataReader(IDataReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new DictionaryApplicationData
                {
ObjectID = (reader.ReadGuidNullable("ObjectID") == null ? null : reader.ReadGuidNullable("ObjectID").ToString()),
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
    }
}

  
