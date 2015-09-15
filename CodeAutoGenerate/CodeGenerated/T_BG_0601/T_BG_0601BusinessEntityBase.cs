/****************************************************** 
FileName:T_BG_0601BusinessEntityBase.cs
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

namespace  RICH.Common.BM.T_BG_0601
{
    //=========================================================================
    //  ClassName : T_BG_0601BusinessEntityBase
    /// <summary>
    /// T_BG_0601的逻辑实体类
    /// </summary>
    //=========================================================================
    public class T_BG_0601BusinessEntityBase : BusinessEntityBase
    {
        #region 数据实体
        /// <summary>
        /// AppData
        /// </summary>
        private T_BG_0601ApplicationData m_AppData;

        /// <summary>
        /// 取得设定AppData
        /// </summary>
        /// <value>AppData</value>
        public T_BG_0601ApplicationData AppData
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
            string strProcName = "SP_InsertT_BG_0601";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@FBH", DbType.String);
            db.AddInParameter(cmdProc, "@BT", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@FBLM", DbType.String);
            db.AddInParameter(cmdProc, "@FBBM", DbType.String);
            db.AddInParameter(cmdProc, "@FBZT", DbType.String);
            db.AddInParameter(cmdProc, "@XXLX", DbType.String);
            db.AddInParameter(cmdProc, "@XXTPDZ", DbType.String);
            db.AddInParameter(cmdProc, "@XXNR", DbType.String);
            db.AddInParameter(cmdProc, "@FJXZDZ", DbType.String);
            db.AddInParameter(cmdProc, "@PZRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@XXZT", DbType.String);
            db.AddInParameter(cmdProc, "@IsTop", DbType.String);
            db.AddInParameter(cmdProc, "@TopSort", DbType.Int32);
            db.AddInParameter(cmdProc, "@IsBest", DbType.String);
            db.AddInParameter(cmdProc, "@YXSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@FBSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBIP", DbType.String);
            db.AddInParameter(cmdProc, "@LLCS", DbType.Int32);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@FBH", AppData.FBH);
            db.SetParameterValue(cmdProc, "@BT", AppData.BT);
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@FBLM", AppData.FBLM);
            db.SetParameterValue(cmdProc, "@FBBM", AppData.FBBM);
            db.SetParameterValue(cmdProc, "@FBZT", AppData.FBZT);
            db.SetParameterValue(cmdProc, "@XXLX", AppData.XXLX);
            db.SetParameterValue(cmdProc, "@XXTPDZ", AppData.XXTPDZ);
            db.SetParameterValue(cmdProc, "@XXNR", AppData.XXNR);
            db.SetParameterValue(cmdProc, "@FJXZDZ", AppData.FJXZDZ);
            db.SetParameterValue(cmdProc, "@PZRJGH", AppData.PZRJGH);
            db.SetParameterValue(cmdProc, "@XXZT", AppData.XXZT);
            db.SetParameterValue(cmdProc, "@IsTop", AppData.IsTop);
            db.SetParameterValue(cmdProc, "@TopSort", AppData.TopSort);
            db.SetParameterValue(cmdProc, "@IsBest", AppData.IsBest);
            db.SetParameterValue(cmdProc, "@YXSJRQ", AppData.YXSJRQ);
            db.SetParameterValue(cmdProc, "@FBRJGH", AppData.FBRJGH);
            db.SetParameterValue(cmdProc, "@FBSJRQ", AppData.FBSJRQ);
            db.SetParameterValue(cmdProc, "@FBIP", AppData.FBIP);
            db.SetParameterValue(cmdProc, "@LLCS", AppData.LLCS);
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
            string strProcName = "SP_UpdateT_BG_0601ByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@FBH", DbType.String);
            db.AddInParameter(cmdProc, "@FBHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FBHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@BT", DbType.String);
            db.AddInParameter(cmdProc, "@BTBatch", DbType.String);
            db.AddInParameter(cmdProc, "@BTValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@FBLM", DbType.String);
            db.AddInParameter(cmdProc, "@FBLMBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FBLMValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@FBBM", DbType.String);
            db.AddInParameter(cmdProc, "@FBBMBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FBBMValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@FBZT", DbType.String);
            db.AddInParameter(cmdProc, "@FBZTBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FBZTValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@XXLX", DbType.String);
            db.AddInParameter(cmdProc, "@XXLXBatch", DbType.String);
            db.AddInParameter(cmdProc, "@XXLXValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@XXTPDZ", DbType.String);
            db.AddInParameter(cmdProc, "@XXTPDZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@XXTPDZValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@XXNR", DbType.String);
            db.AddInParameter(cmdProc, "@XXNRBatch", DbType.String);
            db.AddInParameter(cmdProc, "@XXNRValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@FJXZDZ", DbType.String);
            db.AddInParameter(cmdProc, "@FJXZDZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FJXZDZValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@PZRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@PZRJGHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PZRJGHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@XXZT", DbType.String);
            db.AddInParameter(cmdProc, "@XXZTBatch", DbType.String);
            db.AddInParameter(cmdProc, "@XXZTValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@IsTop", DbType.String);
            db.AddInParameter(cmdProc, "@IsTopBatch", DbType.String);
            db.AddInParameter(cmdProc, "@IsTopValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@TopSort", DbType.Int32);
            db.AddInParameter(cmdProc, "@TopSortBatch", DbType.String);
            db.AddInParameter(cmdProc, "@TopSortValue", DbType.Int32);
                
            db.AddInParameter(cmdProc, "@IsBest", DbType.String);
            db.AddInParameter(cmdProc, "@IsBestBatch", DbType.String);
            db.AddInParameter(cmdProc, "@IsBestValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@YXSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YXSJRQBatch", DbType.String);
            db.AddInParameter(cmdProc, "@YXSJRQValue", DbType.DateTime);
                
            db.AddInParameter(cmdProc, "@FBRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@FBRJGHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FBRJGHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@FBSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBSJRQBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBSJRQEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBSJRQBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FBSJRQValue", DbType.DateTime);
                
            db.AddInParameter(cmdProc, "@FBIP", DbType.String);
            db.AddInParameter(cmdProc, "@FBIPBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FBIPValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LLCS", DbType.Int32);
            db.AddInParameter(cmdProc, "@LLCSBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LLCSValue", DbType.Int32);
                
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@QueryKeywords", AppData.QueryKeywords);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@FBH", AppData.FBH);
            db.SetParameterValue(cmdProc, "@FBHBatch", AppData.FBHBatch);
            db.SetParameterValue(cmdProc, "@FBHValue", AppData.FBHValue);
                
            db.SetParameterValue(cmdProc, "@BT", AppData.BT);
            db.SetParameterValue(cmdProc, "@BTBatch", AppData.BTBatch);
            db.SetParameterValue(cmdProc, "@BTValue", AppData.BTValue);
                
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@LanguageIDBatch", AppData.LanguageIDBatch);
            db.SetParameterValue(cmdProc, "@LanguageIDValue", AppData.LanguageIDValue);
                
            db.SetParameterValue(cmdProc, "@FBLM", AppData.FBLM);
            db.SetParameterValue(cmdProc, "@FBLMBatch", AppData.FBLMBatch);
            db.SetParameterValue(cmdProc, "@FBLMValue", AppData.FBLMValue);
                
            db.SetParameterValue(cmdProc, "@FBBM", AppData.FBBM);
            db.SetParameterValue(cmdProc, "@FBBMBatch", AppData.FBBMBatch);
            db.SetParameterValue(cmdProc, "@FBBMValue", AppData.FBBMValue);
                
            db.SetParameterValue(cmdProc, "@FBZT", AppData.FBZT);
            db.SetParameterValue(cmdProc, "@FBZTBatch", AppData.FBZTBatch);
            db.SetParameterValue(cmdProc, "@FBZTValue", AppData.FBZTValue);
                
            db.SetParameterValue(cmdProc, "@XXLX", AppData.XXLX);
            db.SetParameterValue(cmdProc, "@XXLXBatch", AppData.XXLXBatch);
            db.SetParameterValue(cmdProc, "@XXLXValue", AppData.XXLXValue);
                
            db.SetParameterValue(cmdProc, "@XXTPDZ", AppData.XXTPDZ);
            db.SetParameterValue(cmdProc, "@XXTPDZBatch", AppData.XXTPDZBatch);
            db.SetParameterValue(cmdProc, "@XXTPDZValue", AppData.XXTPDZValue);
                
            db.SetParameterValue(cmdProc, "@XXNR", AppData.XXNR);
            db.SetParameterValue(cmdProc, "@XXNRBatch", AppData.XXNRBatch);
            db.SetParameterValue(cmdProc, "@XXNRValue", AppData.XXNRValue);
                
            db.SetParameterValue(cmdProc, "@FJXZDZ", AppData.FJXZDZ);
            db.SetParameterValue(cmdProc, "@FJXZDZBatch", AppData.FJXZDZBatch);
            db.SetParameterValue(cmdProc, "@FJXZDZValue", AppData.FJXZDZValue);
                
            db.SetParameterValue(cmdProc, "@PZRJGH", AppData.PZRJGH);
            db.SetParameterValue(cmdProc, "@PZRJGHBatch", AppData.PZRJGHBatch);
            db.SetParameterValue(cmdProc, "@PZRJGHValue", AppData.PZRJGHValue);
                
            db.SetParameterValue(cmdProc, "@XXZT", AppData.XXZT);
            db.SetParameterValue(cmdProc, "@XXZTBatch", AppData.XXZTBatch);
            db.SetParameterValue(cmdProc, "@XXZTValue", AppData.XXZTValue);
                
            db.SetParameterValue(cmdProc, "@IsTop", AppData.IsTop);
            db.SetParameterValue(cmdProc, "@IsTopBatch", AppData.IsTopBatch);
            db.SetParameterValue(cmdProc, "@IsTopValue", AppData.IsTopValue);
                
            db.SetParameterValue(cmdProc, "@TopSort", AppData.TopSort);
            db.SetParameterValue(cmdProc, "@TopSortBatch", AppData.TopSortBatch);
            db.SetParameterValue(cmdProc, "@TopSortValue", AppData.TopSortValue);
                
            db.SetParameterValue(cmdProc, "@IsBest", AppData.IsBest);
            db.SetParameterValue(cmdProc, "@IsBestBatch", AppData.IsBestBatch);
            db.SetParameterValue(cmdProc, "@IsBestValue", AppData.IsBestValue);
                
            db.SetParameterValue(cmdProc, "@YXSJRQ", AppData.YXSJRQ);
            db.SetParameterValue(cmdProc, "@YXSJRQBatch", AppData.YXSJRQBatch);
            db.SetParameterValue(cmdProc, "@YXSJRQValue", AppData.YXSJRQValue);
                
            db.SetParameterValue(cmdProc, "@FBRJGH", AppData.FBRJGH);
            db.SetParameterValue(cmdProc, "@FBRJGHBatch", AppData.FBRJGHBatch);
            db.SetParameterValue(cmdProc, "@FBRJGHValue", AppData.FBRJGHValue);
                
            db.SetParameterValue(cmdProc, "@FBSJRQ", AppData.FBSJRQ);
            db.SetParameterValue(cmdProc, "@FBSJRQBegin", AppData.FBSJRQBegin);
            db.SetParameterValue(cmdProc, "@FBSJRQEnd", AppData.FBSJRQEnd);
            db.SetParameterValue(cmdProc, "@FBSJRQBatch", AppData.FBSJRQBatch);
            db.SetParameterValue(cmdProc, "@FBSJRQValue", AppData.FBSJRQValue);
                
            db.SetParameterValue(cmdProc, "@FBIP", AppData.FBIP);
            db.SetParameterValue(cmdProc, "@FBIPBatch", AppData.FBIPBatch);
            db.SetParameterValue(cmdProc, "@FBIPValue", AppData.FBIPValue);
                
            db.SetParameterValue(cmdProc, "@LLCS", AppData.LLCS);
            db.SetParameterValue(cmdProc, "@LLCSBatch", AppData.LLCSBatch);
            db.SetParameterValue(cmdProc, "@LLCSValue", AppData.LLCSValue);
                
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
            string strProcName = "SP_UpdateT_BG_0601ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@FBH", DbType.String);
            db.AddInParameter(cmdProc, "@BT", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@FBLM", DbType.String);
            db.AddInParameter(cmdProc, "@FBBM", DbType.String);
            db.AddInParameter(cmdProc, "@FBZT", DbType.String);
            db.AddInParameter(cmdProc, "@XXLX", DbType.String);
            db.AddInParameter(cmdProc, "@XXTPDZ", DbType.String);
            db.AddInParameter(cmdProc, "@XXNR", DbType.String);
            db.AddInParameter(cmdProc, "@FJXZDZ", DbType.String);
            db.AddInParameter(cmdProc, "@PZRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@XXZT", DbType.String);
            db.AddInParameter(cmdProc, "@IsTop", DbType.String);
            db.AddInParameter(cmdProc, "@TopSort", DbType.Int32);
            db.AddInParameter(cmdProc, "@IsBest", DbType.String);
            db.AddInParameter(cmdProc, "@YXSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@FBSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBIP", DbType.String);
            db.AddInParameter(cmdProc, "@LLCS", DbType.Int32);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@FBH", AppData.FBH);
            db.SetParameterValue(cmdProc, "@BT", AppData.BT);
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@FBLM", AppData.FBLM);
            db.SetParameterValue(cmdProc, "@FBBM", AppData.FBBM);
            db.SetParameterValue(cmdProc, "@FBZT", AppData.FBZT);
            db.SetParameterValue(cmdProc, "@XXLX", AppData.XXLX);
            db.SetParameterValue(cmdProc, "@XXTPDZ", AppData.XXTPDZ);
            db.SetParameterValue(cmdProc, "@XXNR", AppData.XXNR);
            db.SetParameterValue(cmdProc, "@FJXZDZ", AppData.FJXZDZ);
            db.SetParameterValue(cmdProc, "@PZRJGH", AppData.PZRJGH);
            db.SetParameterValue(cmdProc, "@XXZT", AppData.XXZT);
            db.SetParameterValue(cmdProc, "@IsTop", AppData.IsTop);
            db.SetParameterValue(cmdProc, "@TopSort", AppData.TopSort);
            db.SetParameterValue(cmdProc, "@IsBest", AppData.IsBest);
            db.SetParameterValue(cmdProc, "@YXSJRQ", AppData.YXSJRQ);
            db.SetParameterValue(cmdProc, "@FBRJGH", AppData.FBRJGH);
            db.SetParameterValue(cmdProc, "@FBSJRQ", AppData.FBSJRQ);
            db.SetParameterValue(cmdProc, "@FBIP", AppData.FBIP);
            db.SetParameterValue(cmdProc, "@LLCS", AppData.LLCS);
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
            string strProcName = "SP_UpdateT_BG_0601ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@FBH", DbType.String);
            db.AddInParameter(cmdProc, "@BT", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@FBLM", DbType.String);
            db.AddInParameter(cmdProc, "@FBBM", DbType.String);
            db.AddInParameter(cmdProc, "@FBZT", DbType.String);
            db.AddInParameter(cmdProc, "@XXLX", DbType.String);
            db.AddInParameter(cmdProc, "@XXTPDZ", DbType.String);
            db.AddInParameter(cmdProc, "@XXNR", DbType.String);
            db.AddInParameter(cmdProc, "@FJXZDZ", DbType.String);
            db.AddInParameter(cmdProc, "@PZRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@XXZT", DbType.String);
            db.AddInParameter(cmdProc, "@IsTop", DbType.String);
            db.AddInParameter(cmdProc, "@TopSort", DbType.Int32);
            db.AddInParameter(cmdProc, "@IsBest", DbType.String);
            db.AddInParameter(cmdProc, "@YXSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@FBSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBIP", DbType.String);
            db.AddInParameter(cmdProc, "@LLCS", DbType.Int32);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@FBH", AppData.FBH);
            db.SetParameterValue(cmdProc, "@BT", AppData.BT);
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@FBLM", AppData.FBLM);
            db.SetParameterValue(cmdProc, "@FBBM", AppData.FBBM);
            db.SetParameterValue(cmdProc, "@FBZT", AppData.FBZT);
            db.SetParameterValue(cmdProc, "@XXLX", AppData.XXLX);
            db.SetParameterValue(cmdProc, "@XXTPDZ", AppData.XXTPDZ);
            db.SetParameterValue(cmdProc, "@XXNR", AppData.XXNR);
            db.SetParameterValue(cmdProc, "@FJXZDZ", AppData.FJXZDZ);
            db.SetParameterValue(cmdProc, "@PZRJGH", AppData.PZRJGH);
            db.SetParameterValue(cmdProc, "@XXZT", AppData.XXZT);
            db.SetParameterValue(cmdProc, "@IsTop", AppData.IsTop);
            db.SetParameterValue(cmdProc, "@TopSort", AppData.TopSort);
            db.SetParameterValue(cmdProc, "@IsBest", AppData.IsBest);
            db.SetParameterValue(cmdProc, "@YXSJRQ", AppData.YXSJRQ);
            db.SetParameterValue(cmdProc, "@FBRJGH", AppData.FBRJGH);
            db.SetParameterValue(cmdProc, "@FBSJRQ", AppData.FBSJRQ);
            db.SetParameterValue(cmdProc, "@FBIP", AppData.FBIP);
            db.SetParameterValue(cmdProc, "@LLCS", AppData.LLCS);
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
            string strProcName = "SP_UpdateT_BG_0601ByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@FBH", DbType.String);
            db.AddInParameter(cmdProc, "@BT", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@FBLM", DbType.String);
            db.AddInParameter(cmdProc, "@FBBM", DbType.String);
            db.AddInParameter(cmdProc, "@FBZT", DbType.String);
            db.AddInParameter(cmdProc, "@XXLX", DbType.String);
            db.AddInParameter(cmdProc, "@XXTPDZ", DbType.String);
            db.AddInParameter(cmdProc, "@XXNR", DbType.String);
            db.AddInParameter(cmdProc, "@FJXZDZ", DbType.String);
            db.AddInParameter(cmdProc, "@PZRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@XXZT", DbType.String);
            db.AddInParameter(cmdProc, "@IsTop", DbType.String);
            db.AddInParameter(cmdProc, "@TopSort", DbType.Int32);
            db.AddInParameter(cmdProc, "@IsBest", DbType.String);
            db.AddInParameter(cmdProc, "@YXSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@FBSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBIP", DbType.String);
            db.AddInParameter(cmdProc, "@LLCS", DbType.Int32);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@FBH", AppData.FBH);
            db.SetParameterValue(cmdProc, "@BT", AppData.BT);
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@FBLM", AppData.FBLM);
            db.SetParameterValue(cmdProc, "@FBBM", AppData.FBBM);
            db.SetParameterValue(cmdProc, "@FBZT", AppData.FBZT);
            db.SetParameterValue(cmdProc, "@XXLX", AppData.XXLX);
            db.SetParameterValue(cmdProc, "@XXTPDZ", AppData.XXTPDZ);
            db.SetParameterValue(cmdProc, "@XXNR", AppData.XXNR);
            db.SetParameterValue(cmdProc, "@FJXZDZ", AppData.FJXZDZ);
            db.SetParameterValue(cmdProc, "@PZRJGH", AppData.PZRJGH);
            db.SetParameterValue(cmdProc, "@XXZT", AppData.XXZT);
            db.SetParameterValue(cmdProc, "@IsTop", AppData.IsTop);
            db.SetParameterValue(cmdProc, "@TopSort", AppData.TopSort);
            db.SetParameterValue(cmdProc, "@IsBest", AppData.IsBest);
            db.SetParameterValue(cmdProc, "@YXSJRQ", AppData.YXSJRQ);
            db.SetParameterValue(cmdProc, "@FBRJGH", AppData.FBRJGH);
            db.SetParameterValue(cmdProc, "@FBSJRQ", AppData.FBSJRQ);
            db.SetParameterValue(cmdProc, "@FBIP", AppData.FBIP);
            db.SetParameterValue(cmdProc, "@LLCS", AppData.LLCS);
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
            string strProcName = "SP_SelectT_BG_0601ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@FBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@FBH", AppData.FBH);
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
            string strProcName = "SP_SelectT_BG_0601ByObjectID";
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
        public static T_BG_0601ApplicationData GetDataByObjectID(string strObjectID)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BG_0601ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // 执行存储过程
            return T_BG_0601ApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// 以Key为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static T_BG_0601ApplicationData GetDataByKey(T_BG_0601ApplicationData appData)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BG_0601ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@FBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@FBH", appData.FBH);
            // 执行存储过程
            return T_BG_0601ApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectT_BG_0601ByAnyCondition";
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
                
            db.AddInParameter(cmdProc, "@FBH", DbType.String);
            db.AddInParameter(cmdProc, "@FBHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@BT", DbType.String);
            db.AddInParameter(cmdProc, "@BTBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FBLM", DbType.String);
            db.AddInParameter(cmdProc, "@FBLMBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FBBM", DbType.String);
            db.AddInParameter(cmdProc, "@FBBMBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FBZT", DbType.String);
            db.AddInParameter(cmdProc, "@FBZTBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@XXLX", DbType.String);
            db.AddInParameter(cmdProc, "@XXLXBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@XXTPDZ", DbType.String);
            db.AddInParameter(cmdProc, "@XXTPDZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@XXNR", DbType.String);
            db.AddInParameter(cmdProc, "@XXNRBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FJXZDZ", DbType.String);
            db.AddInParameter(cmdProc, "@FJXZDZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@PZRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@PZRJGHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@XXZT", DbType.String);
            db.AddInParameter(cmdProc, "@XXZTBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@IsTop", DbType.String);
            db.AddInParameter(cmdProc, "@IsTopBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@TopSort", DbType.Int32);
            db.AddInParameter(cmdProc, "@TopSortBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@IsBest", DbType.String);
            db.AddInParameter(cmdProc, "@IsBestBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@YXSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@YXSJRQBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FBRJGH", DbType.String);
            db.AddInParameter(cmdProc, "@FBRJGHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FBSJRQ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBSJRQBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBSJRQEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FBSJRQBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FBIP", DbType.String);
            db.AddInParameter(cmdProc, "@FBIPBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LLCS", DbType.Int32);
            db.AddInParameter(cmdProc, "@LLCSBatch", DbType.String);
                
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
                
            db.SetParameterValue(cmdProc, "@FBH", AppData.FBH);
            db.SetParameterValue(cmdProc, "@FBHBatch", AppData.FBHBatch);
                
            db.SetParameterValue(cmdProc, "@BT", AppData.BT);
            db.SetParameterValue(cmdProc, "@BTBatch", AppData.BTBatch);
                
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@LanguageIDBatch", AppData.LanguageIDBatch);
                
            db.SetParameterValue(cmdProc, "@FBLM", AppData.FBLM);
            db.SetParameterValue(cmdProc, "@FBLMBatch", AppData.FBLMBatch);
                
            db.SetParameterValue(cmdProc, "@FBBM", AppData.FBBM);
            db.SetParameterValue(cmdProc, "@FBBMBatch", AppData.FBBMBatch);
                
            db.SetParameterValue(cmdProc, "@FBZT", AppData.FBZT);
            db.SetParameterValue(cmdProc, "@FBZTBatch", AppData.FBZTBatch);
                
            db.SetParameterValue(cmdProc, "@XXLX", AppData.XXLX);
            db.SetParameterValue(cmdProc, "@XXLXBatch", AppData.XXLXBatch);
                
            db.SetParameterValue(cmdProc, "@XXTPDZ", AppData.XXTPDZ);
            db.SetParameterValue(cmdProc, "@XXTPDZBatch", AppData.XXTPDZBatch);
                
            db.SetParameterValue(cmdProc, "@XXNR", AppData.XXNR);
            db.SetParameterValue(cmdProc, "@XXNRBatch", AppData.XXNRBatch);
                
            db.SetParameterValue(cmdProc, "@FJXZDZ", AppData.FJXZDZ);
            db.SetParameterValue(cmdProc, "@FJXZDZBatch", AppData.FJXZDZBatch);
                
            db.SetParameterValue(cmdProc, "@PZRJGH", AppData.PZRJGH);
            db.SetParameterValue(cmdProc, "@PZRJGHBatch", AppData.PZRJGHBatch);
                
            db.SetParameterValue(cmdProc, "@XXZT", AppData.XXZT);
            db.SetParameterValue(cmdProc, "@XXZTBatch", AppData.XXZTBatch);
                
            db.SetParameterValue(cmdProc, "@IsTop", AppData.IsTop);
            db.SetParameterValue(cmdProc, "@IsTopBatch", AppData.IsTopBatch);
                
            db.SetParameterValue(cmdProc, "@TopSort", AppData.TopSort);
            db.SetParameterValue(cmdProc, "@TopSortBatch", AppData.TopSortBatch);
                
            db.SetParameterValue(cmdProc, "@IsBest", AppData.IsBest);
            db.SetParameterValue(cmdProc, "@IsBestBatch", AppData.IsBestBatch);
                
            db.SetParameterValue(cmdProc, "@YXSJRQ", AppData.YXSJRQ);
            db.SetParameterValue(cmdProc, "@YXSJRQBatch", AppData.YXSJRQBatch);
                
            db.SetParameterValue(cmdProc, "@FBRJGH", AppData.FBRJGH);
            db.SetParameterValue(cmdProc, "@FBRJGHBatch", AppData.FBRJGHBatch);
                
            db.SetParameterValue(cmdProc, "@FBSJRQ", AppData.FBSJRQ);
            db.SetParameterValue(cmdProc, "@FBSJRQBegin", AppData.FBSJRQBegin);
            db.SetParameterValue(cmdProc, "@FBSJRQEnd", AppData.FBSJRQEnd);
            db.SetParameterValue(cmdProc, "@FBSJRQBatch", AppData.FBSJRQBatch);
                
            db.SetParameterValue(cmdProc, "@FBIP", AppData.FBIP);
            db.SetParameterValue(cmdProc, "@FBIPBatch", AppData.FBIPBatch);
                
            db.SetParameterValue(cmdProc, "@LLCS", AppData.LLCS);
            db.SetParameterValue(cmdProc, "@LLCSBatch", AppData.LLCSBatch);
                
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
            string strProcName = "SP_DeleteT_BG_0601ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@FBH", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@FBH", AppData.FBH);
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
            string strProcName = "SP_DeleteT_BG_0601ByObjectID";
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
            string strProcName = "SP_DeleteT_BG_0601ByObjectIDBatch";
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
            string strProcName = "SP_IsExistT_BG_0601ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@FBH", DbType.String);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@FBH", AppData.FBH);
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
            string strProcName = "SP_IsExistT_BG_0601ByObjectID";
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
                    string strProcName = "SP_SelectT_BG_0601ByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // 设定存储过程输入参数
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@FBH", DbType.String);
                    db.AddInParameter(cmdProc, "@BT", DbType.String);
                    db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
                    db.AddInParameter(cmdProc, "@FBLM", DbType.String);
                    db.AddInParameter(cmdProc, "@FBBM", DbType.String);
                    db.AddInParameter(cmdProc, "@FBZT", DbType.String);
                    db.AddInParameter(cmdProc, "@XXLX", DbType.String);
                    db.AddInParameter(cmdProc, "@XXTPDZ", DbType.String);
                    db.AddInParameter(cmdProc, "@XXNR", DbType.String);
                    db.AddInParameter(cmdProc, "@FJXZDZ", DbType.String);
                    db.AddInParameter(cmdProc, "@PZRJGH", DbType.String);
                    db.AddInParameter(cmdProc, "@XXZT", DbType.String);
                    db.AddInParameter(cmdProc, "@IsTop", DbType.String);
                    db.AddInParameter(cmdProc, "@TopSort", DbType.Int32);
                    db.AddInParameter(cmdProc, "@IsBest", DbType.String);
                    db.AddInParameter(cmdProc, "@YXSJRQ", DbType.DateTime);
                    db.AddInParameter(cmdProc, "@FBRJGH", DbType.String);
                    db.AddInParameter(cmdProc, "@FBSJRQ", DbType.DateTime);
                    db.AddInParameter(cmdProc, "@FBIP", DbType.String);
                    db.AddInParameter(cmdProc, "@LLCS", DbType.Int32);
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
            string strProcName = "SP_GetMaxT_BG_0601ByFBH";
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
            string strProcName = "SP_CountT_BG_0601ByAnyCondition";
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
        

        public static DataSet GetTreeData_T_BG_0601_FBLM(string iDFieldName, string nameFieldName, string parentFieldValue = null, string conditionFieldName = null, string conditionFieldValue = null, bool onlyShowUsed = false)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetTreeData_T_BG_0601_FBLM";
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
	
        public static DataSet GetTreeData_T_BG_0601_FBBM(string iDFieldName, string nameFieldName, string parentFieldValue = null, string conditionFieldName = null, string conditionFieldValue = null, bool onlyShowUsed = false)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetTreeData_T_BG_0601_FBBM";
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
  
