/****************************************************** 
FileName:FilterReportBusinessEntityBase.cs
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

namespace  RICH.Common.BM.FilterReport
{
    //=========================================================================
    //  ClassName : FilterReportBusinessEntityBase
    /// <summary>
    /// FilterReport的逻辑实体类
    /// </summary>
    //=========================================================================
    public class FilterReportBusinessEntityBase : BusinessEntityBase
    {
        #region 数据实体
        /// <summary>
        /// AppData
        /// </summary>
        private FilterReportApplicationData m_AppData;

        /// <summary>
        /// 取得设定AppData
        /// </summary>
        /// <value>AppData</value>
        public FilterReportApplicationData AppData
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
            string strProcName = "SP_InsertFilterReport";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BGMC", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@BGLX", DbType.String);
            db.AddInParameter(cmdProc, "@GXBG", DbType.String);
            db.AddInParameter(cmdProc, "@XTBG", DbType.String);
            db.AddInParameter(cmdProc, "@BGCXTJ", DbType.String);
            db.AddInParameter(cmdProc, "@BGCJSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BGMC", AppData.BGMC);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@BGLX", AppData.BGLX);
            db.SetParameterValue(cmdProc, "@GXBG", AppData.GXBG);
            db.SetParameterValue(cmdProc, "@XTBG", AppData.XTBG);
            db.SetParameterValue(cmdProc, "@BGCXTJ", AppData.BGCXTJ);
            db.SetParameterValue(cmdProc, "@BGCJSJ", AppData.BGCJSJ);
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
            string strProcName = "SP_UpdateFilterReportByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@BGMC", DbType.String);
            db.AddInParameter(cmdProc, "@BGMCBatch", DbType.String);
            db.AddInParameter(cmdProc, "@BGMCValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@UserIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UserIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@BGLX", DbType.String);
            db.AddInParameter(cmdProc, "@BGLXBatch", DbType.String);
            db.AddInParameter(cmdProc, "@BGLXValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@GXBG", DbType.String);
            db.AddInParameter(cmdProc, "@GXBGBatch", DbType.String);
            db.AddInParameter(cmdProc, "@GXBGValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@XTBG", DbType.String);
            db.AddInParameter(cmdProc, "@XTBGBatch", DbType.String);
            db.AddInParameter(cmdProc, "@XTBGValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@BGCXTJ", DbType.String);
            db.AddInParameter(cmdProc, "@BGCXTJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@BGCXTJValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@BGCJSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BGCJSJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@BGCJSJValue", DbType.DateTime);
                
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@QueryKeywords", AppData.QueryKeywords);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@BGMC", AppData.BGMC);
            db.SetParameterValue(cmdProc, "@BGMCBatch", AppData.BGMCBatch);
            db.SetParameterValue(cmdProc, "@BGMCValue", AppData.BGMCValue);
                
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@UserIDBatch", AppData.UserIDBatch);
            db.SetParameterValue(cmdProc, "@UserIDValue", AppData.UserIDValue);
                
            db.SetParameterValue(cmdProc, "@BGLX", AppData.BGLX);
            db.SetParameterValue(cmdProc, "@BGLXBatch", AppData.BGLXBatch);
            db.SetParameterValue(cmdProc, "@BGLXValue", AppData.BGLXValue);
                
            db.SetParameterValue(cmdProc, "@GXBG", AppData.GXBG);
            db.SetParameterValue(cmdProc, "@GXBGBatch", AppData.GXBGBatch);
            db.SetParameterValue(cmdProc, "@GXBGValue", AppData.GXBGValue);
                
            db.SetParameterValue(cmdProc, "@XTBG", AppData.XTBG);
            db.SetParameterValue(cmdProc, "@XTBGBatch", AppData.XTBGBatch);
            db.SetParameterValue(cmdProc, "@XTBGValue", AppData.XTBGValue);
                
            db.SetParameterValue(cmdProc, "@BGCXTJ", AppData.BGCXTJ);
            db.SetParameterValue(cmdProc, "@BGCXTJBatch", AppData.BGCXTJBatch);
            db.SetParameterValue(cmdProc, "@BGCXTJValue", AppData.BGCXTJValue);
                
            db.SetParameterValue(cmdProc, "@BGCJSJ", AppData.BGCJSJ);
            db.SetParameterValue(cmdProc, "@BGCJSJBatch", AppData.BGCJSJBatch);
            db.SetParameterValue(cmdProc, "@BGCJSJValue", AppData.BGCJSJValue);
                
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
            string strProcName = "SP_UpdateFilterReportByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BGMC", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@BGLX", DbType.String);
            db.AddInParameter(cmdProc, "@GXBG", DbType.String);
            db.AddInParameter(cmdProc, "@XTBG", DbType.String);
            db.AddInParameter(cmdProc, "@BGCXTJ", DbType.String);
            db.AddInParameter(cmdProc, "@BGCJSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BGMC", AppData.BGMC);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@BGLX", AppData.BGLX);
            db.SetParameterValue(cmdProc, "@GXBG", AppData.GXBG);
            db.SetParameterValue(cmdProc, "@XTBG", AppData.XTBG);
            db.SetParameterValue(cmdProc, "@BGCXTJ", AppData.BGCXTJ);
            db.SetParameterValue(cmdProc, "@BGCJSJ", AppData.BGCJSJ);
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
            string strProcName = "SP_UpdateFilterReportByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BGMC", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@BGLX", DbType.String);
            db.AddInParameter(cmdProc, "@GXBG", DbType.String);
            db.AddInParameter(cmdProc, "@XTBG", DbType.String);
            db.AddInParameter(cmdProc, "@BGCXTJ", DbType.String);
            db.AddInParameter(cmdProc, "@BGCJSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BGMC", AppData.BGMC);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@BGLX", AppData.BGLX);
            db.SetParameterValue(cmdProc, "@GXBG", AppData.GXBG);
            db.SetParameterValue(cmdProc, "@XTBG", AppData.XTBG);
            db.SetParameterValue(cmdProc, "@BGCXTJ", AppData.BGCXTJ);
            db.SetParameterValue(cmdProc, "@BGCJSJ", AppData.BGCJSJ);
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
            string strProcName = "SP_UpdateFilterReportByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BGMC", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@BGLX", DbType.String);
            db.AddInParameter(cmdProc, "@GXBG", DbType.String);
            db.AddInParameter(cmdProc, "@XTBG", DbType.String);
            db.AddInParameter(cmdProc, "@BGCXTJ", DbType.String);
            db.AddInParameter(cmdProc, "@BGCJSJ", DbType.DateTime);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BGMC", AppData.BGMC);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@BGLX", AppData.BGLX);
            db.SetParameterValue(cmdProc, "@GXBG", AppData.GXBG);
            db.SetParameterValue(cmdProc, "@XTBG", AppData.XTBG);
            db.SetParameterValue(cmdProc, "@BGCXTJ", AppData.BGCXTJ);
            db.SetParameterValue(cmdProc, "@BGCJSJ", AppData.BGCJSJ);
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
            string strProcName = "SP_SelectFilterReportByKey";
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
        //  FunctionName : SelectByObjectID
        /// <summary>
        /// 以ObjectID为条件查询记录
        /// </summary>
        //=====================================================================
        public override void SelectByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectFilterReportByObjectID";
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
        public static FilterReportApplicationData GetDataByObjectID(string strObjectID)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectFilterReportByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // 执行存储过程
            return FilterReportApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// 以Key为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static FilterReportApplicationData GetDataByKey(FilterReportApplicationData appData)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectFilterReportByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@ObjectID", appData.ObjectID);
            // 执行存储过程
            return FilterReportApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectFilterReportByAnyCondition";
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
                
            db.AddInParameter(cmdProc, "@BGMC", DbType.String);
            db.AddInParameter(cmdProc, "@BGMCBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@UserIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@BGLX", DbType.String);
            db.AddInParameter(cmdProc, "@BGLXBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@GXBG", DbType.String);
            db.AddInParameter(cmdProc, "@GXBGBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@XTBG", DbType.String);
            db.AddInParameter(cmdProc, "@XTBGBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@BGCXTJ", DbType.String);
            db.AddInParameter(cmdProc, "@BGCXTJBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@BGCJSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@BGCJSJBatch", DbType.String);
                
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
                
            db.SetParameterValue(cmdProc, "@BGMC", AppData.BGMC);
            db.SetParameterValue(cmdProc, "@BGMCBatch", AppData.BGMCBatch);
                
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@UserIDBatch", AppData.UserIDBatch);
                
            db.SetParameterValue(cmdProc, "@BGLX", AppData.BGLX);
            db.SetParameterValue(cmdProc, "@BGLXBatch", AppData.BGLXBatch);
                
            db.SetParameterValue(cmdProc, "@GXBG", AppData.GXBG);
            db.SetParameterValue(cmdProc, "@GXBGBatch", AppData.GXBGBatch);
                
            db.SetParameterValue(cmdProc, "@XTBG", AppData.XTBG);
            db.SetParameterValue(cmdProc, "@XTBGBatch", AppData.XTBGBatch);
                
            db.SetParameterValue(cmdProc, "@BGCXTJ", AppData.BGCXTJ);
            db.SetParameterValue(cmdProc, "@BGCXTJBatch", AppData.BGCXTJBatch);
                
            db.SetParameterValue(cmdProc, "@BGCJSJ", AppData.BGCJSJ);
            db.SetParameterValue(cmdProc, "@BGCJSJBatch", AppData.BGCJSJBatch);
                
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
            string strProcName = "SP_DeleteFilterReportByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
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
            string strProcName = "SP_DeleteFilterReportByObjectID";
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
            string strProcName = "SP_DeleteFilterReportByObjectIDBatch";
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
            string strProcName = "SP_IsExistFilterReportByKey";
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
        //  FunctionName : IsExistByObjectID
        /// <summary>
        /// 以ObjectID为条件判断记录是否存在
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistFilterReportByObjectID";
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
                    string strProcName = "SP_SelectFilterReportByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // 设定存储过程输入参数
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@BGMC", DbType.String);
                    db.AddInParameter(cmdProc, "@UserID", DbType.String);
                    db.AddInParameter(cmdProc, "@BGLX", DbType.String);
                    db.AddInParameter(cmdProc, "@GXBG", DbType.String);
                    db.AddInParameter(cmdProc, "@XTBG", DbType.String);
                    db.AddInParameter(cmdProc, "@BGCXTJ", DbType.String);
                    db.AddInParameter(cmdProc, "@BGCJSJ", DbType.DateTime);
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
            string strProcName = "SP_GetMaxFilterReportBy";
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
            string strProcName = "SP_CountFilterReportByAnyCondition";
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
  
