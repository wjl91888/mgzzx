/****************************************************** 
FileName:T_BM_DWXXBusinessEntityBase.cs
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

namespace  RICH.Common.BM.T_BM_DWXX
{
    //=========================================================================
    //  ClassName : T_BM_DWXXBusinessEntityBase
    /// <summary>
    /// T_BM_DWXX的逻辑实体类
    /// </summary>
    //=========================================================================
    public class T_BM_DWXXBusinessEntityBase : BusinessEntityBase
    {
        #region 数据实体
        /// <summary>
        /// AppData
        /// </summary>
        private T_BM_DWXXApplicationData m_AppData;

        /// <summary>
        /// 取得设定AppData
        /// </summary>
        /// <value>AppData</value>
        public T_BM_DWXXApplicationData AppData
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
            string strProcName = "SP_InsertT_BM_DWXX";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            db.AddInParameter(cmdProc, "@DWMC", DbType.String);
            db.AddInParameter(cmdProc, "@SJDWBH", DbType.String);
            db.AddInParameter(cmdProc, "@DZ", DbType.String);
            db.AddInParameter(cmdProc, "@YB", DbType.String);
            db.AddInParameter(cmdProc, "@LXBM", DbType.String);
            db.AddInParameter(cmdProc, "@LXDH", DbType.String);
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@LXR", DbType.String);
            db.AddInParameter(cmdProc, "@SJ", DbType.String);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
            db.SetParameterValue(cmdProc, "@DWMC", AppData.DWMC);
            db.SetParameterValue(cmdProc, "@SJDWBH", AppData.SJDWBH);
            db.SetParameterValue(cmdProc, "@DZ", AppData.DZ);
            db.SetParameterValue(cmdProc, "@YB", AppData.YB);
            db.SetParameterValue(cmdProc, "@LXBM", AppData.LXBM);
            db.SetParameterValue(cmdProc, "@LXDH", AppData.LXDH);
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@LXR", AppData.LXR);
            db.SetParameterValue(cmdProc, "@SJ", AppData.SJ);
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
            string strProcName = "SP_UpdateT_BM_DWXXByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            db.AddInParameter(cmdProc, "@DWBHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@DWBHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@DWMC", DbType.String);
            db.AddInParameter(cmdProc, "@DWMCBatch", DbType.String);
            db.AddInParameter(cmdProc, "@DWMCValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@SJDWBH", DbType.String);
            db.AddInParameter(cmdProc, "@SJDWBHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SJDWBHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@DZ", DbType.String);
            db.AddInParameter(cmdProc, "@DZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@DZValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@YB", DbType.String);
            db.AddInParameter(cmdProc, "@YBBatch", DbType.String);
            db.AddInParameter(cmdProc, "@YBValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LXBM", DbType.String);
            db.AddInParameter(cmdProc, "@LXBMBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LXBMValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LXDH", DbType.String);
            db.AddInParameter(cmdProc, "@LXDHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LXDHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@EmailBatch", DbType.String);
            db.AddInParameter(cmdProc, "@EmailValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LXR", DbType.String);
            db.AddInParameter(cmdProc, "@LXRBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LXRValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@SJ", DbType.String);
            db.AddInParameter(cmdProc, "@SJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SJValue", DbType.String);
                
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@QueryKeywords", AppData.QueryKeywords);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
            db.SetParameterValue(cmdProc, "@DWBHBatch", AppData.DWBHBatch);
            db.SetParameterValue(cmdProc, "@DWBHValue", AppData.DWBHValue);
                
            db.SetParameterValue(cmdProc, "@DWMC", AppData.DWMC);
            db.SetParameterValue(cmdProc, "@DWMCBatch", AppData.DWMCBatch);
            db.SetParameterValue(cmdProc, "@DWMCValue", AppData.DWMCValue);
                
            db.SetParameterValue(cmdProc, "@SJDWBH", AppData.SJDWBH);
            db.SetParameterValue(cmdProc, "@SJDWBHBatch", AppData.SJDWBHBatch);
            db.SetParameterValue(cmdProc, "@SJDWBHValue", AppData.SJDWBHValue);
                
            db.SetParameterValue(cmdProc, "@DZ", AppData.DZ);
            db.SetParameterValue(cmdProc, "@DZBatch", AppData.DZBatch);
            db.SetParameterValue(cmdProc, "@DZValue", AppData.DZValue);
                
            db.SetParameterValue(cmdProc, "@YB", AppData.YB);
            db.SetParameterValue(cmdProc, "@YBBatch", AppData.YBBatch);
            db.SetParameterValue(cmdProc, "@YBValue", AppData.YBValue);
                
            db.SetParameterValue(cmdProc, "@LXBM", AppData.LXBM);
            db.SetParameterValue(cmdProc, "@LXBMBatch", AppData.LXBMBatch);
            db.SetParameterValue(cmdProc, "@LXBMValue", AppData.LXBMValue);
                
            db.SetParameterValue(cmdProc, "@LXDH", AppData.LXDH);
            db.SetParameterValue(cmdProc, "@LXDHBatch", AppData.LXDHBatch);
            db.SetParameterValue(cmdProc, "@LXDHValue", AppData.LXDHValue);
                
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@EmailBatch", AppData.EmailBatch);
            db.SetParameterValue(cmdProc, "@EmailValue", AppData.EmailValue);
                
            db.SetParameterValue(cmdProc, "@LXR", AppData.LXR);
            db.SetParameterValue(cmdProc, "@LXRBatch", AppData.LXRBatch);
            db.SetParameterValue(cmdProc, "@LXRValue", AppData.LXRValue);
                
            db.SetParameterValue(cmdProc, "@SJ", AppData.SJ);
            db.SetParameterValue(cmdProc, "@SJBatch", AppData.SJBatch);
            db.SetParameterValue(cmdProc, "@SJValue", AppData.SJValue);
                
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
            string strProcName = "SP_UpdateT_BM_DWXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            db.AddInParameter(cmdProc, "@DWMC", DbType.String);
            db.AddInParameter(cmdProc, "@SJDWBH", DbType.String);
            db.AddInParameter(cmdProc, "@DZ", DbType.String);
            db.AddInParameter(cmdProc, "@YB", DbType.String);
            db.AddInParameter(cmdProc, "@LXBM", DbType.String);
            db.AddInParameter(cmdProc, "@LXDH", DbType.String);
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@LXR", DbType.String);
            db.AddInParameter(cmdProc, "@SJ", DbType.String);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
            db.SetParameterValue(cmdProc, "@DWMC", AppData.DWMC);
            db.SetParameterValue(cmdProc, "@SJDWBH", AppData.SJDWBH);
            db.SetParameterValue(cmdProc, "@DZ", AppData.DZ);
            db.SetParameterValue(cmdProc, "@YB", AppData.YB);
            db.SetParameterValue(cmdProc, "@LXBM", AppData.LXBM);
            db.SetParameterValue(cmdProc, "@LXDH", AppData.LXDH);
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@LXR", AppData.LXR);
            db.SetParameterValue(cmdProc, "@SJ", AppData.SJ);
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
            string strProcName = "SP_UpdateT_BM_DWXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            db.AddInParameter(cmdProc, "@DWMC", DbType.String);
            db.AddInParameter(cmdProc, "@SJDWBH", DbType.String);
            db.AddInParameter(cmdProc, "@DZ", DbType.String);
            db.AddInParameter(cmdProc, "@YB", DbType.String);
            db.AddInParameter(cmdProc, "@LXBM", DbType.String);
            db.AddInParameter(cmdProc, "@LXDH", DbType.String);
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@LXR", DbType.String);
            db.AddInParameter(cmdProc, "@SJ", DbType.String);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
            db.SetParameterValue(cmdProc, "@DWMC", AppData.DWMC);
            db.SetParameterValue(cmdProc, "@SJDWBH", AppData.SJDWBH);
            db.SetParameterValue(cmdProc, "@DZ", AppData.DZ);
            db.SetParameterValue(cmdProc, "@YB", AppData.YB);
            db.SetParameterValue(cmdProc, "@LXBM", AppData.LXBM);
            db.SetParameterValue(cmdProc, "@LXDH", AppData.LXDH);
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@LXR", AppData.LXR);
            db.SetParameterValue(cmdProc, "@SJ", AppData.SJ);
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
            string strProcName = "SP_UpdateT_BM_DWXXByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            db.AddInParameter(cmdProc, "@DWMC", DbType.String);
            db.AddInParameter(cmdProc, "@SJDWBH", DbType.String);
            db.AddInParameter(cmdProc, "@DZ", DbType.String);
            db.AddInParameter(cmdProc, "@YB", DbType.String);
            db.AddInParameter(cmdProc, "@LXBM", DbType.String);
            db.AddInParameter(cmdProc, "@LXDH", DbType.String);
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@LXR", DbType.String);
            db.AddInParameter(cmdProc, "@SJ", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
            db.SetParameterValue(cmdProc, "@DWMC", AppData.DWMC);
            db.SetParameterValue(cmdProc, "@SJDWBH", AppData.SJDWBH);
            db.SetParameterValue(cmdProc, "@DZ", AppData.DZ);
            db.SetParameterValue(cmdProc, "@YB", AppData.YB);
            db.SetParameterValue(cmdProc, "@LXBM", AppData.LXBM);
            db.SetParameterValue(cmdProc, "@LXDH", AppData.LXDH);
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@LXR", AppData.LXR);
            db.SetParameterValue(cmdProc, "@SJ", AppData.SJ);
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
            string strProcName = "SP_SelectT_BM_DWXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
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
            string strProcName = "SP_SelectT_BM_DWXXByObjectID";
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
        public static T_BM_DWXXApplicationData GetDataByObjectID(string strObjectID)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_DWXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // 执行存储过程
            return T_BM_DWXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// 以Key为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static T_BM_DWXXApplicationData GetDataByKey(T_BM_DWXXApplicationData appData)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_DWXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@DWBH", appData.DWBH);
            // 执行存储过程
            return T_BM_DWXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectT_BM_DWXXByAnyCondition";
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
                
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            db.AddInParameter(cmdProc, "@DWBHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@DWMC", DbType.String);
            db.AddInParameter(cmdProc, "@DWMCBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SJDWBH", DbType.String);
            db.AddInParameter(cmdProc, "@SJDWBHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@DZ", DbType.String);
            db.AddInParameter(cmdProc, "@DZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@YB", DbType.String);
            db.AddInParameter(cmdProc, "@YBBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LXBM", DbType.String);
            db.AddInParameter(cmdProc, "@LXBMBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LXDH", DbType.String);
            db.AddInParameter(cmdProc, "@LXDHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@EmailBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LXR", DbType.String);
            db.AddInParameter(cmdProc, "@LXRBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SJ", DbType.String);
            db.AddInParameter(cmdProc, "@SJBatch", DbType.String);
                
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
                
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
            db.SetParameterValue(cmdProc, "@DWBHBatch", AppData.DWBHBatch);
                
            db.SetParameterValue(cmdProc, "@DWMC", AppData.DWMC);
            db.SetParameterValue(cmdProc, "@DWMCBatch", AppData.DWMCBatch);
                
            db.SetParameterValue(cmdProc, "@SJDWBH", AppData.SJDWBH);
            db.SetParameterValue(cmdProc, "@SJDWBHBatch", AppData.SJDWBHBatch);
                
            db.SetParameterValue(cmdProc, "@DZ", AppData.DZ);
            db.SetParameterValue(cmdProc, "@DZBatch", AppData.DZBatch);
                
            db.SetParameterValue(cmdProc, "@YB", AppData.YB);
            db.SetParameterValue(cmdProc, "@YBBatch", AppData.YBBatch);
                
            db.SetParameterValue(cmdProc, "@LXBM", AppData.LXBM);
            db.SetParameterValue(cmdProc, "@LXBMBatch", AppData.LXBMBatch);
                
            db.SetParameterValue(cmdProc, "@LXDH", AppData.LXDH);
            db.SetParameterValue(cmdProc, "@LXDHBatch", AppData.LXDHBatch);
                
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@EmailBatch", AppData.EmailBatch);
                
            db.SetParameterValue(cmdProc, "@LXR", AppData.LXR);
            db.SetParameterValue(cmdProc, "@LXRBatch", AppData.LXRBatch);
                
            db.SetParameterValue(cmdProc, "@SJ", AppData.SJ);
            db.SetParameterValue(cmdProc, "@SJBatch", AppData.SJBatch);
                
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
            string strProcName = "SP_DeleteT_BM_DWXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
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
            string strProcName = "SP_DeleteT_BM_DWXXByObjectID";
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
            string strProcName = "SP_DeleteT_BM_DWXXByObjectIDBatch";
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
            string strProcName = "SP_IsExistT_BM_DWXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
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
            string strProcName = "SP_IsExistT_BM_DWXXByObjectID";
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
                    string strProcName = "SP_SelectT_BM_DWXXByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // 设定存储过程输入参数
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@DWBH", DbType.String);
                    db.AddInParameter(cmdProc, "@DWMC", DbType.String);
                    db.AddInParameter(cmdProc, "@SJDWBH", DbType.String);
                    db.AddInParameter(cmdProc, "@DZ", DbType.String);
                    db.AddInParameter(cmdProc, "@YB", DbType.String);
                    db.AddInParameter(cmdProc, "@LXBM", DbType.String);
                    db.AddInParameter(cmdProc, "@LXDH", DbType.String);
                    db.AddInParameter(cmdProc, "@Email", DbType.String);
                    db.AddInParameter(cmdProc, "@LXR", DbType.String);
                    db.AddInParameter(cmdProc, "@SJ", DbType.String);
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
            string strProcName = "SP_GetMaxT_BM_DWXXByDWBH";
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
            string strProcName = "SP_CountT_BM_DWXXByAnyCondition";
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
        

        public static DataSet GetTreeData_T_BM_DWXX_SJDWBH(string iDFieldName, string nameFieldName, string parentFieldValue = null, string conditionFieldName = null, string conditionFieldValue = null, bool onlyShowUsed = false)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetTreeData_T_BM_DWXX_SJDWBH";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@IDFieldName", DbType.String);
            db.SetParameterValue(cmdProc, "@IDFieldName", iDFieldName);
            db.AddInParameter(cmdProc, "@NameFieldName", DbType.String);
            db.SetParameterValue(cmdProc, "@NameFieldName", nameFieldName);
            db.AddInParameter(cmdProc, "@ParentIDFieldValue", DbType.String);
            db.SetParameterValue(cmdProc, "@ParentIDFieldValue", parentFieldValue);
            db.AddInParameter(cmdProc, "@ConditionFieldName", DbType.String);
            db.SetParameterValue(cmdProc, "@ConditionFieldName", conditionFieldName);
            db.AddInParameter(cmdProc, "@ConditionFieldValue", DbType.String);
            db.SetParameterValue(cmdProc, "@ConditionFieldValue", conditionFieldValue);
            db.AddInParameter(cmdProc, "@OnlyShowUsed", DbType.Boolean);
            db.SetParameterValue(cmdProc, "@OnlyShowUsed", onlyShowUsed);
            // 执行存储过程
            DataSet ds = db.ExecuteDataSet(cmdProc);
            return ds;
        }
	
        #endregion
    }
}
  
