/****************************************************** 
FileName:T_PM_PurviewInfoApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_PM_PurviewInfo
{
    //=========================================================================
    //  ClassName : T_PM_PurviewInfoApplicationData
    /// <summary>
    /// T_PM_PurviewInfo的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_PM_PurviewInfoApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// PurviewID
        /// </summary>
        /// <value>PurviewID</value>
        public String PurviewID { get; set; }
    
        /// <summary>
        /// PurviewName
        /// </summary>
        /// <value>PurviewName</value>
        public String PurviewName { get; set; }
    
        /// <summary>
        /// PurviewTypeID
        /// </summary>
        /// <value>PurviewTypeID</value>
        public String PurviewTypeID { get; set; }
    
        /// <summary>
        /// PurviewContent
        /// </summary>
        /// <value>PurviewContent</value>
        public String PurviewContent { get; set; }
    
        /// <summary>
        /// PurviewRemark
        /// </summary>
        /// <value>PurviewRemark</value>
        public String PurviewRemark { get; set; }
    
        /// <summary>
        /// IsPageMenu
        /// </summary>
        /// <value>IsPageMenu</value>
        public Boolean? IsPageMenu { get; set; }
    
        /// <summary>
        /// PageFileName
        /// </summary>
        /// <value>PageFileName</value>
        public String PageFileName { get; set; }
    
        /// <summary>
        /// PageFileParameter
        /// </summary>
        /// <value>PageFileParameter</value>
        public String PageFileParameter { get; set; }
    
        /// <summary>
        /// PageFilePath
        /// </summary>
        /// <value>PageFilePath</value>
        public String PageFilePath { get; set; }
    
        /// <summary>
        /// UpdateDate
        /// </summary>
        /// <value>UpdateDate</value>
        public DateTime? UpdateDate { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// PurviewIDBatch
        /// </summary>
        /// <value>PurviewID</value>
        public String PurviewIDBatch { get; set; }

        /// <summary>
        /// PurviewNameBatch
        /// </summary>
        /// <value>PurviewName</value>
        public String PurviewNameBatch { get; set; }

        /// <summary>
        /// PurviewTypeIDBatch
        /// </summary>
        /// <value>PurviewTypeID</value>
        public String PurviewTypeIDBatch { get; set; }

        /// <summary>
        /// PurviewContentBatch
        /// </summary>
        /// <value>PurviewContent</value>
        public String PurviewContentBatch { get; set; }

        /// <summary>
        /// PurviewRemarkBatch
        /// </summary>
        /// <value>PurviewRemark</value>
        public String PurviewRemarkBatch { get; set; }

        /// <summary>
        /// IsPageMenuBatch
        /// </summary>
        /// <value>IsPageMenu</value>
        public String IsPageMenuBatch { get; set; }

        /// <summary>
        /// PageFileNameBatch
        /// </summary>
        /// <value>PageFileName</value>
        public String PageFileNameBatch { get; set; }

        /// <summary>
        /// PageFileParameterBatch
        /// </summary>
        /// <value>PageFileParameter</value>
        public String PageFileParameterBatch { get; set; }

        /// <summary>
        /// PageFilePathBatch
        /// </summary>
        /// <value>PageFilePath</value>
        public String PageFilePathBatch { get; set; }

        /// <summary>
        /// UpdateDateBatch
        /// </summary>
        /// <value>UpdateDate</value>
        public String UpdateDateBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 批量更新PurviewIDValue
        /// </summary>
        /// <value>PurviewIDValue</value>
        public String PurviewIDValue { get; set; }
    
        /// <summary>
        /// 批量更新PurviewNameValue
        /// </summary>
        /// <value>PurviewNameValue</value>
        public String PurviewNameValue { get; set; }
    
        /// <summary>
        /// 批量更新PurviewTypeIDValue
        /// </summary>
        /// <value>PurviewTypeIDValue</value>
        public String PurviewTypeIDValue { get; set; }
    
        /// <summary>
        /// 批量更新PurviewContentValue
        /// </summary>
        /// <value>PurviewContentValue</value>
        public String PurviewContentValue { get; set; }
    
        /// <summary>
        /// 批量更新PurviewRemarkValue
        /// </summary>
        /// <value>PurviewRemarkValue</value>
        public String PurviewRemarkValue { get; set; }
    
        /// <summary>
        /// 批量更新IsPageMenuValue
        /// </summary>
        /// <value>IsPageMenuValue</value>
        public Boolean? IsPageMenuValue { get; set; }
    
        /// <summary>
        /// 批量更新PageFileNameValue
        /// </summary>
        /// <value>PageFileNameValue</value>
        public String PageFileNameValue { get; set; }
    
        /// <summary>
        /// 批量更新PageFileParameterValue
        /// </summary>
        /// <value>PageFileParameterValue</value>
        public String PageFileParameterValue { get; set; }
    
        /// <summary>
        /// 批量更新PageFilePathValue
        /// </summary>
        /// <value>PageFilePathValue</value>
        public String PageFilePathValue { get; set; }
    
        /// <summary>
        /// 批量更新UpdateDateValue
        /// </summary>
        /// <value>UpdateDateValue</value>
        public DateTime? UpdateDateValue { get; set; }
        
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
                              ,"PurviewID"
                              ,"PurviewName"
                              ,"PurviewTypeID"
                              ,"PurviewContent"
                              ,"PurviewRemark"
                              ,"IsPageMenu"
                              ,"PageFileName"
                              ,"PageFileParameter"
                              ,"PageFilePath"
                              ,"UpdateDate"
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
                              ,SqlDbType.Bit
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
                              "PurviewID"
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
                              ,"PurviewContent"
                              ,"PurviewRemark"
                              ,"IsPageMenu"
                              ,"PageFileName"
                              ,"PageFileParameter"
                              ,"PageFilePath"
                              ,"UpdateDate"
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

        public static IEnumerable<T_PM_PurviewInfoApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_PM_PurviewInfoApplicationData> collection = new List<T_PM_PurviewInfoApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_PM_PurviewInfoApplicationData applicationData = new T_PM_PurviewInfoApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    PurviewID = dr.ReadString("PurviewID"),
    PurviewName = dr.ReadString("PurviewName"),
    PurviewTypeID = dr.ReadString("PurviewTypeID"),
    PurviewContent = dr.ReadString("PurviewContent"),
    PurviewRemark = dr.ReadString("PurviewRemark"),
    IsPageMenu = dr.ReadBooleanNullable("IsPageMenu"),
    PageFileName = dr.ReadString("PageFileName"),
    PageFileParameter = dr.ReadString("PageFileParameter"),
    PageFilePath = dr.ReadString("PageFilePath"),
    UpdateDate = dr.ReadDateTimeNullable("UpdateDate"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_PM_PurviewInfoApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_PM_PurviewInfoApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    PurviewID = reader.ReadString("PurviewID"),
    PurviewName = reader.ReadString("PurviewName"),
    PurviewTypeID = reader.ReadString("PurviewTypeID"),
    PurviewContent = reader.ReadString("PurviewContent"),
    PurviewRemark = reader.ReadString("PurviewRemark"),
    IsPageMenu = reader.ReadBooleanNullable(fromImportDataSet ? "IsPageMenu" : "IsPageMenu"),
    PageFileName = reader.ReadString("PageFileName"),
    PageFileParameter = reader.ReadString("PageFileParameter"),
    PageFilePath = reader.ReadString("PageFilePath"),
    UpdateDate = reader.ReadDateTimeNullable(fromImportDataSet ? "UpdateDate" : "UpdateDate"),
    
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

  
