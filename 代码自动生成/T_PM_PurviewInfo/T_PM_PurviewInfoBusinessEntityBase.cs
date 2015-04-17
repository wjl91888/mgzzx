/****************************************************** 
FileName:T_PM_PurviewInfoBusinessEntityBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using RICH.Common;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.BusinessEntity;

namespace  RICH.Common.BM.T_PM_PurviewInfo
{
    //=========================================================================
    //  ClassName : T_PM_PurviewInfoBusinessEntityBase
    /// <summary>
    /// T_PM_PurviewInfo的逻辑实体类
    /// </summary>
    //=========================================================================
    public class T_PM_PurviewInfoBusinessEntityBase : BusinessEntityBase
    {
        #region 数据实体
        /// <summary>
        /// AppData
        /// </summary>
        private T_PM_PurviewInfoApplicationData m_AppData;

        /// <summary>
        /// 取得设定AppData
        /// </summary>
        /// <value>AppData</value>
        public T_PM_PurviewInfoApplicationData AppData
        {
            get { return m_AppData; }
            set { m_AppData = value; }
        }
        #endregion

        #region 对对应的数据实体进行数据库操作
        //=====================================================================
        //  FunctionName : Insert
        /// <summary>
        /// 插入记录
        /// </summary>
        //=====================================================================
        public override void Insert()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_InsertT_PM_PurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewName", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewContent", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewRemark", DbType.String);
            db.AddInParameter(cmdProc, "@IsPageMenu", DbType.Boolean);
            db.AddInParameter(cmdProc, "@PageFileName", DbType.String);
            db.AddInParameter(cmdProc, "@PageFileParameter", DbType.String);
            db.AddInParameter(cmdProc, "@PageFilePath", DbType.String);
            db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
            db.SetParameterValue(cmdProc, "@PurviewName", AppData.PurviewName);
            db.SetParameterValue(cmdProc, "@PurviewTypeID", AppData.PurviewTypeID);
            db.SetParameterValue(cmdProc, "@PurviewContent", AppData.PurviewContent);
            db.SetParameterValue(cmdProc, "@PurviewRemark", AppData.PurviewRemark);
            db.SetParameterValue(cmdProc, "@IsPageMenu", AppData.IsPageMenu);
            db.SetParameterValue(cmdProc, "@PageFileName", AppData.PageFileName);
            db.SetParameterValue(cmdProc, "@PageFileParameter", AppData.PageFileParameter);
            db.SetParameterValue(cmdProc, "@PageFilePath", AppData.PageFilePath);
            db.SetParameterValue(cmdProc, "@UpdateDate", AppData.UpdateDate);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }
        
        //=====================================================================
        //  FunctionName : UpdateByAnyCondition
        /// <summary>
        /// 以任意条件更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByAnyCondition()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_PM_PurviewInfoByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@PurviewName", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewNameBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewNameValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewTypeIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewTypeIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@PurviewContent", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewContentBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewContentValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@PurviewRemark", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewRemarkBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewRemarkValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@IsPageMenu", DbType.Boolean);
            db.AddInParameter(cmdProc, "@IsPageMenuBatch", DbType.String);
            db.AddInParameter(cmdProc, "@IsPageMenuValue", DbType.Boolean);
                
            db.AddInParameter(cmdProc, "@PageFileName", DbType.String);
            db.AddInParameter(cmdProc, "@PageFileNameBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PageFileNameValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@PageFileParameter", DbType.String);
            db.AddInParameter(cmdProc, "@PageFileParameterBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PageFileParameterValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@PageFilePath", DbType.String);
            db.AddInParameter(cmdProc, "@PageFilePathBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PageFilePathValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
            db.AddInParameter(cmdProc, "@UpdateDateBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UpdateDateValue", DbType.DateTime);
                
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
            db.SetParameterValue(cmdProc, "@PurviewIDBatch", AppData.PurviewIDBatch);
            db.SetParameterValue(cmdProc, "@PurviewIDValue", AppData.PurviewIDValue);
                
            db.SetParameterValue(cmdProc, "@PurviewName", AppData.PurviewName);
            db.SetParameterValue(cmdProc, "@PurviewNameBatch", AppData.PurviewNameBatch);
            db.SetParameterValue(cmdProc, "@PurviewNameValue", AppData.PurviewNameValue);
                
            db.SetParameterValue(cmdProc, "@PurviewTypeID", AppData.PurviewTypeID);
            db.SetParameterValue(cmdProc, "@PurviewTypeIDBatch", AppData.PurviewTypeIDBatch);
            db.SetParameterValue(cmdProc, "@PurviewTypeIDValue", AppData.PurviewTypeIDValue);
                
            db.SetParameterValue(cmdProc, "@PurviewContent", AppData.PurviewContent);
            db.SetParameterValue(cmdProc, "@PurviewContentBatch", AppData.PurviewContentBatch);
            db.SetParameterValue(cmdProc, "@PurviewContentValue", AppData.PurviewContentValue);
                
            db.SetParameterValue(cmdProc, "@PurviewRemark", AppData.PurviewRemark);
            db.SetParameterValue(cmdProc, "@PurviewRemarkBatch", AppData.PurviewRemarkBatch);
            db.SetParameterValue(cmdProc, "@PurviewRemarkValue", AppData.PurviewRemarkValue);
                
            db.SetParameterValue(cmdProc, "@IsPageMenu", AppData.IsPageMenu);
            db.SetParameterValue(cmdProc, "@IsPageMenuBatch", AppData.IsPageMenuBatch);
            db.SetParameterValue(cmdProc, "@IsPageMenuValue", AppData.IsPageMenuValue);
                
            db.SetParameterValue(cmdProc, "@PageFileName", AppData.PageFileName);
            db.SetParameterValue(cmdProc, "@PageFileNameBatch", AppData.PageFileNameBatch);
            db.SetParameterValue(cmdProc, "@PageFileNameValue", AppData.PageFileNameValue);
                
            db.SetParameterValue(cmdProc, "@PageFileParameter", AppData.PageFileParameter);
            db.SetParameterValue(cmdProc, "@PageFileParameterBatch", AppData.PageFileParameterBatch);
            db.SetParameterValue(cmdProc, "@PageFileParameterValue", AppData.PageFileParameterValue);
                
            db.SetParameterValue(cmdProc, "@PageFilePath", AppData.PageFilePath);
            db.SetParameterValue(cmdProc, "@PageFilePathBatch", AppData.PageFilePathBatch);
            db.SetParameterValue(cmdProc, "@PageFilePathValue", AppData.PageFilePathValue);
                
            db.SetParameterValue(cmdProc, "@UpdateDate", AppData.UpdateDate);
            db.SetParameterValue(cmdProc, "@UpdateDateBatch", AppData.UpdateDateBatch);
            db.SetParameterValue(cmdProc, "@UpdateDateValue", AppData.UpdateDateValue);
                
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到更新的记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        }

        //=====================================================================
        //  FunctionName : UpdateByKey
        /// <summary>
        /// 以主键为条件更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_PM_PurviewInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewName", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewContent", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewRemark", DbType.String);
            db.AddInParameter(cmdProc, "@IsPageMenu", DbType.Boolean);
            db.AddInParameter(cmdProc, "@PageFileName", DbType.String);
            db.AddInParameter(cmdProc, "@PageFileParameter", DbType.String);
            db.AddInParameter(cmdProc, "@PageFilePath", DbType.String);
            db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
            db.SetParameterValue(cmdProc, "@PurviewName", AppData.PurviewName);
            db.SetParameterValue(cmdProc, "@PurviewTypeID", AppData.PurviewTypeID);
            db.SetParameterValue(cmdProc, "@PurviewContent", AppData.PurviewContent);
            db.SetParameterValue(cmdProc, "@PurviewRemark", AppData.PurviewRemark);
            db.SetParameterValue(cmdProc, "@IsPageMenu", AppData.IsPageMenu);
            db.SetParameterValue(cmdProc, "@PageFileName", AppData.PageFileName);
            db.SetParameterValue(cmdProc, "@PageFileParameter", AppData.PageFileParameter);
            db.SetParameterValue(cmdProc, "@PageFilePath", AppData.PageFilePath);
            db.SetParameterValue(cmdProc, "@UpdateDate", AppData.UpdateDate);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : UpdateByObjectID
        /// <summary>
        /// 以ObjectID为条件更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_PM_PurviewInfoByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewName", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewContent", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewRemark", DbType.String);
            db.AddInParameter(cmdProc, "@IsPageMenu", DbType.Boolean);
            db.AddInParameter(cmdProc, "@PageFileName", DbType.String);
            db.AddInParameter(cmdProc, "@PageFileParameter", DbType.String);
            db.AddInParameter(cmdProc, "@PageFilePath", DbType.String);
            db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
            db.SetParameterValue(cmdProc, "@PurviewName", AppData.PurviewName);
            db.SetParameterValue(cmdProc, "@PurviewTypeID", AppData.PurviewTypeID);
            db.SetParameterValue(cmdProc, "@PurviewContent", AppData.PurviewContent);
            db.SetParameterValue(cmdProc, "@PurviewRemark", AppData.PurviewRemark);
            db.SetParameterValue(cmdProc, "@IsPageMenu", AppData.IsPageMenu);
            db.SetParameterValue(cmdProc, "@PageFileName", AppData.PageFileName);
            db.SetParameterValue(cmdProc, "@PageFileParameter", AppData.PageFileParameter);
            db.SetParameterValue(cmdProc, "@PageFilePath", AppData.PageFilePath);
            db.SetParameterValue(cmdProc, "@UpdateDate", AppData.UpdateDate);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : UpdateByObjectIDBatch
        /// <summary>
        /// 以ObjectID为条件批量更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByObjectIDBatch()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_PM_PurviewInfoByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewName", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewContent", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewRemark", DbType.String);
            db.AddInParameter(cmdProc, "@IsPageMenu", DbType.Boolean);
            db.AddInParameter(cmdProc, "@PageFileName", DbType.String);
            db.AddInParameter(cmdProc, "@PageFileParameter", DbType.String);
            db.AddInParameter(cmdProc, "@PageFilePath", DbType.String);
            db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
            db.SetParameterValue(cmdProc, "@PurviewName", AppData.PurviewName);
            db.SetParameterValue(cmdProc, "@PurviewTypeID", AppData.PurviewTypeID);
            db.SetParameterValue(cmdProc, "@PurviewContent", AppData.PurviewContent);
            db.SetParameterValue(cmdProc, "@PurviewRemark", AppData.PurviewRemark);
            db.SetParameterValue(cmdProc, "@IsPageMenu", AppData.IsPageMenu);
            db.SetParameterValue(cmdProc, "@PageFileName", AppData.PageFileName);
            db.SetParameterValue(cmdProc, "@PageFileParameter", AppData.PageFileParameter);
            db.SetParameterValue(cmdProc, "@PageFilePath", AppData.PageFilePath);
            db.SetParameterValue(cmdProc, "@UpdateDate", AppData.UpdateDate);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : SelectByKey
        /// <summary>
        /// 以主键为条件查询记录
        /// </summary>
        //=====================================================================
        public override void SelectByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_PM_PurviewInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = AppData.ResultSet.Tables[0].Rows.Count;
        }

        //=====================================================================
        //  FunctionName : SelectByObjectID
        /// <summary>
        /// 以ObjectID为条件查询记录
        /// </summary>
        //=====================================================================
        public override void SelectByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_PM_PurviewInfoByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = AppData.ResultSet.Tables[0].Rows.Count;
        }
        
        //=====================================================================
        //  FunctionName : GetDataByObjectID
        /// <summary>
        /// 以ObjectID为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static T_PM_PurviewInfoApplicationData GetDataByObjectID(string strObjectID)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_PM_PurviewInfoByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // 执行存储过程
            return T_PM_PurviewInfoApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// 以Key为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static T_PM_PurviewInfoApplicationData GetDataByKey(T_PM_PurviewInfoApplicationData appData)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_PM_PurviewInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@PurviewID", appData.PurviewID);
            // 执行存储过程
            return T_PM_PurviewInfoApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
		
        //=====================================================================
        //  FunctionName : SelectByAnyCondition
        /// <summary>
        /// 以任意条件查询记录
        /// </summary>
        //=====================================================================
        public override void SelectByAnyCondition()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_PM_PurviewInfoByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryField", DbType.String);
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
            db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
            // 主表
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@PurviewName", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewNameBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewTypeIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@PurviewContent", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewContentBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@PurviewRemark", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewRemarkBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@IsPageMenu", DbType.Boolean);
            db.AddInParameter(cmdProc, "@IsPageMenuBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@PageFileName", DbType.String);
            db.AddInParameter(cmdProc, "@PageFileNameBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@PageFileParameter", DbType.String);
            db.AddInParameter(cmdProc, "@PageFileParameterBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@PageFilePath", DbType.String);
            db.AddInParameter(cmdProc, "@PageFilePathBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
            db.AddInParameter(cmdProc, "@UpdateDateBatch", DbType.String);
                
            // 一对一相关表
            
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
        
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryField", AppData.QueryField);
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@Sort", AppData.Sort);
            db.SetParameterValue(cmdProc, "@SortField", AppData.SortField);
            db.SetParameterValue(cmdProc, "@PageSize", AppData.PageSize);
            db.SetParameterValue(cmdProc, "@CurrentPage", AppData.CurrentPage);
            // 主表
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
                
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
            db.SetParameterValue(cmdProc, "@PurviewIDBatch", AppData.PurviewIDBatch);
                
            db.SetParameterValue(cmdProc, "@PurviewName", AppData.PurviewName);
            db.SetParameterValue(cmdProc, "@PurviewNameBatch", AppData.PurviewNameBatch);
                
            db.SetParameterValue(cmdProc, "@PurviewTypeID", AppData.PurviewTypeID);
            db.SetParameterValue(cmdProc, "@PurviewTypeIDBatch", AppData.PurviewTypeIDBatch);
                
            db.SetParameterValue(cmdProc, "@PurviewContent", AppData.PurviewContent);
            db.SetParameterValue(cmdProc, "@PurviewContentBatch", AppData.PurviewContentBatch);
                
            db.SetParameterValue(cmdProc, "@PurviewRemark", AppData.PurviewRemark);
            db.SetParameterValue(cmdProc, "@PurviewRemarkBatch", AppData.PurviewRemarkBatch);
                
            db.SetParameterValue(cmdProc, "@IsPageMenu", AppData.IsPageMenu);
            db.SetParameterValue(cmdProc, "@IsPageMenuBatch", AppData.IsPageMenuBatch);
                
            db.SetParameterValue(cmdProc, "@PageFileName", AppData.PageFileName);
            db.SetParameterValue(cmdProc, "@PageFileNameBatch", AppData.PageFileNameBatch);
                
            db.SetParameterValue(cmdProc, "@PageFileParameter", AppData.PageFileParameter);
            db.SetParameterValue(cmdProc, "@PageFileParameterBatch", AppData.PageFileParameterBatch);
                
            db.SetParameterValue(cmdProc, "@PageFilePath", AppData.PageFilePath);
            db.SetParameterValue(cmdProc, "@PageFilePathBatch", AppData.PageFilePathBatch);
                
            db.SetParameterValue(cmdProc, "@UpdateDate", AppData.UpdateDate);
            db.SetParameterValue(cmdProc, "@UpdateDateBatch", AppData.UpdateDateBatch);
                
            // 一对一相关表
            
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        
        }

        //=====================================================================
        //  FunctionName : DeleteByKey
        /// <summary>
        /// 以主键为条件删除记录
        /// </summary>
        //=====================================================================
        public override void DeleteByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_PM_PurviewInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : DeleteByObjectID
        /// <summary>
        /// 以ObjectID为条件删除记录
        /// </summary>
        //=====================================================================
        public override void DeleteByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_PM_PurviewInfoByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : DeleteByObjectIDBatch
        /// <summary>
        /// 以ObjectID为条件批量删除记录
        /// </summary>
        //=====================================================================
        public override void DeleteByObjectIDBatch()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_PM_PurviewInfoByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : IsExistByKey
        /// <summary>
        /// 以主键为条件判断记录是否存在
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistT_PM_PurviewInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
            if (AppData.RecordCount > 0)
            {
              return true;
            }
            else if(AppData.RecordCount == 0)
            {
              return false;
            }
            else
            {
              return false; 
            }
        }

        //=====================================================================
        //  FunctionName : IsExistByObjectID
        /// <summary>
        /// 以ObjectID为条件判断记录是否存在
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistT_PM_PurviewInfoByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
            if (AppData.RecordCount > 0)
            {
              return true;
            }
            else if(AppData.RecordCount == 0)
            {
              return false;
            }
            else
            {
              return false; 
            }
        }

        //=====================================================================
        //  FunctionName : GetValueByFixCondition
        /// <summary>
        /// 以指定条件查询指定字段
        /// </summary>
        //=====================================================================
        public override object GetValueByFixCondition(string strConditionField, object strConditionValue, string strValueField, string strFixConditionField = null, object strFixConditionValue = null)
        {
            object objReturn = new object();
            StringBuilder sbReturn = new StringBuilder();
            if ((strConditionValue == DBNull.Value || strConditionValue == null) == false)
            {
                string[] strArrayConditionValue = strConditionValue.ToString().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
                bool boolFirstItem = true;
                foreach (string strValue in strArrayConditionValue)
                {
                    DataSet dsTemp = new DataSet();
                    // 创建数据库连接 
                    Database db = DatabaseFactory.CreateDatabase("strConnManager");
                    string strProcName = "SP_SelectT_PM_PurviewInfoByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // 设定存储过程输入参数
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
                    db.AddInParameter(cmdProc, "@PurviewName", DbType.String);
                    db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
                    db.AddInParameter(cmdProc, "@PurviewContent", DbType.String);
                    db.AddInParameter(cmdProc, "@PurviewRemark", DbType.String);
                    db.AddInParameter(cmdProc, "@IsPageMenu", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@PageFileName", DbType.String);
                    db.AddInParameter(cmdProc, "@PageFileParameter", DbType.String);
                    db.AddInParameter(cmdProc, "@PageFilePath", DbType.String);
                    db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
                    // 设定存储过程输出参数
                    db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
                
                    // 对存储过程参数赋值
                    db.SetParameterValue(cmdProc, "@" + strConditionField, strValue);
                    if (!strFixConditionField.IsNullOrWhiteSpace())
                    {
                        if (strFixConditionField != "null")
                        {
                            db.SetParameterValue(cmdProc, "@" + strFixConditionField, strFixConditionValue);
                        }
                    }
                    // 执行存储过程
                    dsTemp = (DataSet)db.ExecuteDataSet(cmdProc);
                    if ((Int32)db.GetParameterValue(cmdProc, "@RecordCount") > 0)
                    {
                        if (boolFirstItem == false)
                        {
                            sbReturn.Append(",");
                            sbReturn.Append(dsTemp.Tables[0].Rows[0][strValueField]);
                        }
                        else if (boolFirstItem == true)
                        {
                            sbReturn.Append(dsTemp.Tables[0].Rows[0][strValueField]);
                            boolFirstItem = false;
                        }
                    }
                }
                objReturn = (object)sbReturn.ToString();
            }
            else
            {
                objReturn = (object)string.Empty;
            }
            return objReturn;
        }

        //=====================================================================
        //  FunctionName : GetMaxValue
        /// <summary>
        /// 得到指定字段的最大值
        /// </summary>
        //=====================================================================
        public override object GetMaxValue(string strPrefix)
        {
            return null;
        }
        public object GetMaxValue(string strPrefix, int intNumber)
        {
            object objReturn = new object();
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetMaxT_PM_PurviewInfoBy";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@Prefix", DbType.String);
            db.AddInParameter(cmdProc, "@Number", DbType.Int32, 4);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@MaxValue", DbType.String, 100);
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@Prefix", strPrefix);
            db.SetParameterValue(cmdProc, "@Number", intNumber);
            // 执行存储过程
            db.ExecuteDataSet(cmdProc);
            if ((int)db.GetParameterValue(cmdProc, "@RecordCount") > 0)
            {
                objReturn = db.GetParameterValue(cmdProc, "@MaxValue");
            }
            else
            {
                objReturn = (object)string.Empty;
            }
            return objReturn;
        }

        //=====================================================================
        //  FunctionName : CountByAnyCondition
        /// <summary>
        /// 以任意条件统计指定字段
        /// </summary>
        //=====================================================================
        public override void CountByAnyCondition()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_CountT_PM_PurviewInfoByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@CountField", DbType.String);
            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            // 主表 
            
            // 一对一相关表
            
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@CountField", AppData.CountField);
            db.SetParameterValue(cmdProc, "@Sort", AppData.Sort);
            db.SetParameterValue(cmdProc, "@SortField", AppData.SortField);
            // 主表
            
            // 一对一相关表
            
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        }
        

        #endregion
    }
}
  
