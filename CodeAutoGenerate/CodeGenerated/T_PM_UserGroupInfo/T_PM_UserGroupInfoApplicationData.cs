/****************************************************** 
FileName:T_PM_UserGroupInfoApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_PM_UserGroupInfo
{
    //=========================================================================
    //  ClassName : T_PM_UserGroupInfoApplicationData
    /// <summary>
    /// T_PM_UserGroupInfo的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_PM_UserGroupInfoApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 用户组编号UserGroupID
        /// </summary>
        /// <value>UserGroupID</value>
        public String UserGroupID { get; set; }
    
        /// <summary>
        /// 用户组名称UserGroupName
        /// </summary>
        /// <value>UserGroupName</value>
        public String UserGroupName { get; set; }
    
        /// <summary>
        /// 内容UserGroupContent
        /// </summary>
        /// <value>UserGroupContent</value>
        public String UserGroupContent { get; set; }
    
        /// <summary>
        /// 备注UserGroupRemark
        /// </summary>
        /// <value>UserGroupRemark</value>
        public String UserGroupRemark { get; set; }
    
        /// <summary>
        /// 系统默认页DefaultPage
        /// </summary>
        /// <value>DefaultPage</value>
        public String DefaultPage { get; set; }
    
        /// <summary>
        /// 更新时间UpdateDate
        /// </summary>
        /// <value>UpdateDate</value>
        public DateTime? UpdateDate { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 用户组编号UserGroupIDBatch
        /// </summary>
        /// <value>UserGroupID</value>
        public String UserGroupIDBatch { get; set; }

        /// <summary>
        /// 用户组名称UserGroupNameBatch
        /// </summary>
        /// <value>UserGroupName</value>
        public String UserGroupNameBatch { get; set; }

        /// <summary>
        /// 内容UserGroupContentBatch
        /// </summary>
        /// <value>UserGroupContent</value>
        public String UserGroupContentBatch { get; set; }

        /// <summary>
        /// 备注UserGroupRemarkBatch
        /// </summary>
        /// <value>UserGroupRemark</value>
        public String UserGroupRemarkBatch { get; set; }

        /// <summary>
        /// 系统默认页DefaultPageBatch
        /// </summary>
        /// <value>DefaultPage</value>
        public String DefaultPageBatch { get; set; }

        /// <summary>
        /// 更新时间UpdateDateBatch
        /// </summary>
        /// <value>UpdateDate</value>
        public String UpdateDateBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 用户组编号批量更新UserGroupIDValue
        /// </summary>
        /// <value>UserGroupIDValue</value>
        public String UserGroupIDValue { get; set; }
    
        /// <summary>
        /// 用户组名称批量更新UserGroupNameValue
        /// </summary>
        /// <value>UserGroupNameValue</value>
        public String UserGroupNameValue { get; set; }
    
        /// <summary>
        /// 内容批量更新UserGroupContentValue
        /// </summary>
        /// <value>UserGroupContentValue</value>
        public String UserGroupContentValue { get; set; }
    
        /// <summary>
        /// 备注批量更新UserGroupRemarkValue
        /// </summary>
        /// <value>UserGroupRemarkValue</value>
        public String UserGroupRemarkValue { get; set; }
    
        /// <summary>
        /// 系统默认页批量更新DefaultPageValue
        /// </summary>
        /// <value>DefaultPageValue</value>
        public String DefaultPageValue { get; set; }
    
        /// <summary>
        /// 更新时间批量更新UpdateDateValue
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
                              ,"UserGroupID"
                              ,"UserGroupName"
                              ,"UserGroupContent"
                              ,"UserGroupRemark"
                              ,"DefaultPage"
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
                              "UserGroupID"
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
                              ,"UserGroupContent"
                              ,"UserGroupRemark"
                              ,"DefaultPage"
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

        public static IEnumerable<T_PM_UserGroupInfoApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_PM_UserGroupInfoApplicationData> collection = new List<T_PM_UserGroupInfoApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_PM_UserGroupInfoApplicationData applicationData = new T_PM_UserGroupInfoApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    UserGroupID = dr.ReadString("UserGroupID"),
    UserGroupName = dr.ReadString("UserGroupName"),
    UserGroupContent = dr.ReadString("UserGroupContent"),
    UserGroupRemark = dr.ReadString("UserGroupRemark"),
    DefaultPage = dr.ReadString("DefaultPage"),
    UpdateDate = dr.ReadDateTimeNullable("UpdateDate"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_PM_UserGroupInfoApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_PM_UserGroupInfoApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    UserGroupID = reader.ReadString("UserGroupID"),
    UserGroupName = reader.ReadString("UserGroupName"),
    UserGroupContent = reader.ReadString("UserGroupContent"),
    UserGroupRemark = reader.ReadString("UserGroupRemark"),
    DefaultPage = reader.ReadString("DefaultPage"),
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

  
