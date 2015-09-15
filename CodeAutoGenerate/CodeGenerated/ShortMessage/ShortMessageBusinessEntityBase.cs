/****************************************************** 
FileName:ShortMessageBusinessEntityBase.cs
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

namespace  RICH.Common.BM.ShortMessage
{
    //=========================================================================
    //  ClassName : ShortMessageBusinessEntityBase
    /// <summary>
    /// ShortMessage的逻辑实体类
    /// </summary>
    //=========================================================================
    public class ShortMessageBusinessEntityBase : BusinessEntityBase
    {
        #region 数据实体
        /// <summary>
        /// AppData
        /// </summary>
        private ShortMessageApplicationData m_AppData;

        /// <summary>
        /// 取得设定AppData
        /// </summary>
        /// <value>AppData</value>
        public ShortMessageApplicationData AppData
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
            string strProcName = "SP_InsertShortMessage";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@DXXBT", DbType.String);
            db.AddInParameter(cmdProc, "@DXXLX", DbType.String);
            db.AddInParameter(cmdProc, "@DXXNR", DbType.String);
            db.AddInParameter(cmdProc, "@DXXFJ", DbType.String);
            db.AddInParameter(cmdProc, "@FSSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FSR", DbType.String);
            db.AddInParameter(cmdProc, "@FSBM", DbType.String);
            db.AddInParameter(cmdProc, "@FSIP", DbType.String);
            db.AddInParameter(cmdProc, "@JSR", DbType.String);
            db.AddInParameter(cmdProc, "@SFCK", DbType.Boolean);
            db.AddInParameter(cmdProc, "@CKSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@DXXBT", AppData.DXXBT);
            db.SetParameterValue(cmdProc, "@DXXLX", AppData.DXXLX);
            db.SetParameterValue(cmdProc, "@DXXNR", AppData.DXXNR);
            db.SetParameterValue(cmdProc, "@DXXFJ", AppData.DXXFJ);
            db.SetParameterValue(cmdProc, "@FSSJ", AppData.FSSJ);
            db.SetParameterValue(cmdProc, "@FSR", AppData.FSR);
            db.SetParameterValue(cmdProc, "@FSBM", AppData.FSBM);
            db.SetParameterValue(cmdProc, "@FSIP", AppData.FSIP);
            db.SetParameterValue(cmdProc, "@JSR", AppData.JSR);
            db.SetParameterValue(cmdProc, "@SFCK", AppData.SFCK);
            db.SetParameterValue(cmdProc, "@CKSJ", AppData.CKSJ);
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
            string strProcName = "SP_UpdateShortMessageByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@DXXBT", DbType.String);
            db.AddInParameter(cmdProc, "@DXXBTBatch", DbType.String);
            db.AddInParameter(cmdProc, "@DXXBTValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@DXXLX", DbType.String);
            db.AddInParameter(cmdProc, "@DXXLXBatch", DbType.String);
            db.AddInParameter(cmdProc, "@DXXLXValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@DXXNR", DbType.String);
            db.AddInParameter(cmdProc, "@DXXNRBatch", DbType.String);
            db.AddInParameter(cmdProc, "@DXXNRValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@DXXFJ", DbType.String);
            db.AddInParameter(cmdProc, "@DXXFJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@DXXFJValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@FSSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FSSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FSSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FSSJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FSSJValue", DbType.DateTime);
                
            db.AddInParameter(cmdProc, "@FSR", DbType.String);
            db.AddInParameter(cmdProc, "@FSRBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FSRValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@FSBM", DbType.String);
            db.AddInParameter(cmdProc, "@FSBMBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FSBMValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@FSIP", DbType.String);
            db.AddInParameter(cmdProc, "@FSIPBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FSIPValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@JSR", DbType.String);
            db.AddInParameter(cmdProc, "@JSRBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JSRValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@SFCK", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SFCKBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SFCKValue", DbType.Boolean);
                
            db.AddInParameter(cmdProc, "@CKSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@CKSJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@CKSJValue", DbType.DateTime);
                
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@QueryKeywords", AppData.QueryKeywords);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@DXXBT", AppData.DXXBT);
            db.SetParameterValue(cmdProc, "@DXXBTBatch", AppData.DXXBTBatch);
            db.SetParameterValue(cmdProc, "@DXXBTValue", AppData.DXXBTValue);
                
            db.SetParameterValue(cmdProc, "@DXXLX", AppData.DXXLX);
            db.SetParameterValue(cmdProc, "@DXXLXBatch", AppData.DXXLXBatch);
            db.SetParameterValue(cmdProc, "@DXXLXValue", AppData.DXXLXValue);
                
            db.SetParameterValue(cmdProc, "@DXXNR", AppData.DXXNR);
            db.SetParameterValue(cmdProc, "@DXXNRBatch", AppData.DXXNRBatch);
            db.SetParameterValue(cmdProc, "@DXXNRValue", AppData.DXXNRValue);
                
            db.SetParameterValue(cmdProc, "@DXXFJ", AppData.DXXFJ);
            db.SetParameterValue(cmdProc, "@DXXFJBatch", AppData.DXXFJBatch);
            db.SetParameterValue(cmdProc, "@DXXFJValue", AppData.DXXFJValue);
                
            db.SetParameterValue(cmdProc, "@FSSJ", AppData.FSSJ);
            db.SetParameterValue(cmdProc, "@FSSJBegin", AppData.FSSJBegin);
            db.SetParameterValue(cmdProc, "@FSSJEnd", AppData.FSSJEnd);
            db.SetParameterValue(cmdProc, "@FSSJBatch", AppData.FSSJBatch);
            db.SetParameterValue(cmdProc, "@FSSJValue", AppData.FSSJValue);
                
            db.SetParameterValue(cmdProc, "@FSR", AppData.FSR);
            db.SetParameterValue(cmdProc, "@FSRBatch", AppData.FSRBatch);
            db.SetParameterValue(cmdProc, "@FSRValue", AppData.FSRValue);
                
            db.SetParameterValue(cmdProc, "@FSBM", AppData.FSBM);
            db.SetParameterValue(cmdProc, "@FSBMBatch", AppData.FSBMBatch);
            db.SetParameterValue(cmdProc, "@FSBMValue", AppData.FSBMValue);
                
            db.SetParameterValue(cmdProc, "@FSIP", AppData.FSIP);
            db.SetParameterValue(cmdProc, "@FSIPBatch", AppData.FSIPBatch);
            db.SetParameterValue(cmdProc, "@FSIPValue", AppData.FSIPValue);
                
            db.SetParameterValue(cmdProc, "@JSR", AppData.JSR);
            db.SetParameterValue(cmdProc, "@JSRBatch", AppData.JSRBatch);
            db.SetParameterValue(cmdProc, "@JSRValue", AppData.JSRValue);
                
            db.SetParameterValue(cmdProc, "@SFCK", AppData.SFCK);
            db.SetParameterValue(cmdProc, "@SFCKBatch", AppData.SFCKBatch);
            db.SetParameterValue(cmdProc, "@SFCKValue", AppData.SFCKValue);
                
            db.SetParameterValue(cmdProc, "@CKSJ", AppData.CKSJ);
            db.SetParameterValue(cmdProc, "@CKSJBatch", AppData.CKSJBatch);
            db.SetParameterValue(cmdProc, "@CKSJValue", AppData.CKSJValue);
                
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
            string strProcName = "SP_UpdateShortMessageByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@DXXBT", DbType.String);
            db.AddInParameter(cmdProc, "@DXXLX", DbType.String);
            db.AddInParameter(cmdProc, "@DXXNR", DbType.String);
            db.AddInParameter(cmdProc, "@DXXFJ", DbType.String);
            db.AddInParameter(cmdProc, "@FSSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FSR", DbType.String);
            db.AddInParameter(cmdProc, "@FSBM", DbType.String);
            db.AddInParameter(cmdProc, "@FSIP", DbType.String);
            db.AddInParameter(cmdProc, "@JSR", DbType.String);
            db.AddInParameter(cmdProc, "@SFCK", DbType.Boolean);
            db.AddInParameter(cmdProc, "@CKSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@DXXBT", AppData.DXXBT);
            db.SetParameterValue(cmdProc, "@DXXLX", AppData.DXXLX);
            db.SetParameterValue(cmdProc, "@DXXNR", AppData.DXXNR);
            db.SetParameterValue(cmdProc, "@DXXFJ", AppData.DXXFJ);
            db.SetParameterValue(cmdProc, "@FSSJ", AppData.FSSJ);
            db.SetParameterValue(cmdProc, "@FSR", AppData.FSR);
            db.SetParameterValue(cmdProc, "@FSBM", AppData.FSBM);
            db.SetParameterValue(cmdProc, "@FSIP", AppData.FSIP);
            db.SetParameterValue(cmdProc, "@JSR", AppData.JSR);
            db.SetParameterValue(cmdProc, "@SFCK", AppData.SFCK);
            db.SetParameterValue(cmdProc, "@CKSJ", AppData.CKSJ);
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
            string strProcName = "SP_UpdateShortMessageByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@DXXBT", DbType.String);
            db.AddInParameter(cmdProc, "@DXXLX", DbType.String);
            db.AddInParameter(cmdProc, "@DXXNR", DbType.String);
            db.AddInParameter(cmdProc, "@DXXFJ", DbType.String);
            db.AddInParameter(cmdProc, "@FSSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FSR", DbType.String);
            db.AddInParameter(cmdProc, "@FSBM", DbType.String);
            db.AddInParameter(cmdProc, "@FSIP", DbType.String);
            db.AddInParameter(cmdProc, "@JSR", DbType.String);
            db.AddInParameter(cmdProc, "@SFCK", DbType.Boolean);
            db.AddInParameter(cmdProc, "@CKSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@DXXBT", AppData.DXXBT);
            db.SetParameterValue(cmdProc, "@DXXLX", AppData.DXXLX);
            db.SetParameterValue(cmdProc, "@DXXNR", AppData.DXXNR);
            db.SetParameterValue(cmdProc, "@DXXFJ", AppData.DXXFJ);
            db.SetParameterValue(cmdProc, "@FSSJ", AppData.FSSJ);
            db.SetParameterValue(cmdProc, "@FSR", AppData.FSR);
            db.SetParameterValue(cmdProc, "@FSBM", AppData.FSBM);
            db.SetParameterValue(cmdProc, "@FSIP", AppData.FSIP);
            db.SetParameterValue(cmdProc, "@JSR", AppData.JSR);
            db.SetParameterValue(cmdProc, "@SFCK", AppData.SFCK);
            db.SetParameterValue(cmdProc, "@CKSJ", AppData.CKSJ);
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
            string strProcName = "SP_UpdateShortMessageByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@DXXBT", DbType.String);
            db.AddInParameter(cmdProc, "@DXXLX", DbType.String);
            db.AddInParameter(cmdProc, "@DXXNR", DbType.String);
            db.AddInParameter(cmdProc, "@DXXFJ", DbType.String);
            db.AddInParameter(cmdProc, "@FSSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FSR", DbType.String);
            db.AddInParameter(cmdProc, "@FSBM", DbType.String);
            db.AddInParameter(cmdProc, "@FSIP", DbType.String);
            db.AddInParameter(cmdProc, "@JSR", DbType.String);
            db.AddInParameter(cmdProc, "@SFCK", DbType.Boolean);
            db.AddInParameter(cmdProc, "@CKSJ", DbType.DateTime);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@DXXBT", AppData.DXXBT);
            db.SetParameterValue(cmdProc, "@DXXLX", AppData.DXXLX);
            db.SetParameterValue(cmdProc, "@DXXNR", AppData.DXXNR);
            db.SetParameterValue(cmdProc, "@DXXFJ", AppData.DXXFJ);
            db.SetParameterValue(cmdProc, "@FSSJ", AppData.FSSJ);
            db.SetParameterValue(cmdProc, "@FSR", AppData.FSR);
            db.SetParameterValue(cmdProc, "@FSBM", AppData.FSBM);
            db.SetParameterValue(cmdProc, "@FSIP", AppData.FSIP);
            db.SetParameterValue(cmdProc, "@JSR", AppData.JSR);
            db.SetParameterValue(cmdProc, "@SFCK", AppData.SFCK);
            db.SetParameterValue(cmdProc, "@CKSJ", AppData.CKSJ);
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
            string strProcName = "SP_SelectShortMessageByKey";
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
            string strProcName = "SP_SelectShortMessageByObjectID";
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
        public static ShortMessageApplicationData GetDataByObjectID(string strObjectID)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectShortMessageByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // 执行存储过程
            return ShortMessageApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// 以Key为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static ShortMessageApplicationData GetDataByKey(ShortMessageApplicationData appData)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectShortMessageByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@ObjectID", appData.ObjectID);
            // 执行存储过程
            return ShortMessageApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectShortMessageByAnyCondition";
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
                
            db.AddInParameter(cmdProc, "@DXXBT", DbType.String);
            db.AddInParameter(cmdProc, "@DXXBTBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@DXXLX", DbType.String);
            db.AddInParameter(cmdProc, "@DXXLXBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@DXXNR", DbType.String);
            db.AddInParameter(cmdProc, "@DXXNRBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@DXXFJ", DbType.String);
            db.AddInParameter(cmdProc, "@DXXFJBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FSSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FSSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FSSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@FSSJBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FSR", DbType.String);
            db.AddInParameter(cmdProc, "@FSRBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FSBM", DbType.String);
            db.AddInParameter(cmdProc, "@FSBMBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FSIP", DbType.String);
            db.AddInParameter(cmdProc, "@FSIPBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JSR", DbType.String);
            db.AddInParameter(cmdProc, "@JSRBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SFCK", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SFCKBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@CKSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@CKSJBatch", DbType.String);
                
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
                
            db.SetParameterValue(cmdProc, "@DXXBT", AppData.DXXBT);
            db.SetParameterValue(cmdProc, "@DXXBTBatch", AppData.DXXBTBatch);
                
            db.SetParameterValue(cmdProc, "@DXXLX", AppData.DXXLX);
            db.SetParameterValue(cmdProc, "@DXXLXBatch", AppData.DXXLXBatch);
                
            db.SetParameterValue(cmdProc, "@DXXNR", AppData.DXXNR);
            db.SetParameterValue(cmdProc, "@DXXNRBatch", AppData.DXXNRBatch);
                
            db.SetParameterValue(cmdProc, "@DXXFJ", AppData.DXXFJ);
            db.SetParameterValue(cmdProc, "@DXXFJBatch", AppData.DXXFJBatch);
                
            db.SetParameterValue(cmdProc, "@FSSJ", AppData.FSSJ);
            db.SetParameterValue(cmdProc, "@FSSJBegin", AppData.FSSJBegin);
            db.SetParameterValue(cmdProc, "@FSSJEnd", AppData.FSSJEnd);
            db.SetParameterValue(cmdProc, "@FSSJBatch", AppData.FSSJBatch);
                
            db.SetParameterValue(cmdProc, "@FSR", AppData.FSR);
            db.SetParameterValue(cmdProc, "@FSRBatch", AppData.FSRBatch);
                
            db.SetParameterValue(cmdProc, "@FSBM", AppData.FSBM);
            db.SetParameterValue(cmdProc, "@FSBMBatch", AppData.FSBMBatch);
                
            db.SetParameterValue(cmdProc, "@FSIP", AppData.FSIP);
            db.SetParameterValue(cmdProc, "@FSIPBatch", AppData.FSIPBatch);
                
            db.SetParameterValue(cmdProc, "@JSR", AppData.JSR);
            db.SetParameterValue(cmdProc, "@JSRBatch", AppData.JSRBatch);
                
            db.SetParameterValue(cmdProc, "@SFCK", AppData.SFCK);
            db.SetParameterValue(cmdProc, "@SFCKBatch", AppData.SFCKBatch);
                
            db.SetParameterValue(cmdProc, "@CKSJ", AppData.CKSJ);
            db.SetParameterValue(cmdProc, "@CKSJBatch", AppData.CKSJBatch);
                
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
            string strProcName = "SP_DeleteShortMessageByKey";
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
            string strProcName = "SP_DeleteShortMessageByObjectID";
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
            string strProcName = "SP_DeleteShortMessageByObjectIDBatch";
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
            string strProcName = "SP_IsExistShortMessageByKey";
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
            string strProcName = "SP_IsExistShortMessageByObjectID";
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
                    string strProcName = "SP_SelectShortMessageByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // 设定存储过程输入参数
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@DXXBT", DbType.String);
                    db.AddInParameter(cmdProc, "@DXXLX", DbType.String);
                    db.AddInParameter(cmdProc, "@DXXNR", DbType.String);
                    db.AddInParameter(cmdProc, "@DXXFJ", DbType.String);
                    db.AddInParameter(cmdProc, "@FSSJ", DbType.DateTime);
                    db.AddInParameter(cmdProc, "@FSR", DbType.String);
                    db.AddInParameter(cmdProc, "@FSBM", DbType.String);
                    db.AddInParameter(cmdProc, "@FSIP", DbType.String);
                    db.AddInParameter(cmdProc, "@JSR", DbType.String);
                    db.AddInParameter(cmdProc, "@SFCK", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@CKSJ", DbType.DateTime);
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
            string strProcName = "SP_GetMaxShortMessageBy";
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
            string strProcName = "SP_CountShortMessageByAnyCondition";
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
        

        public static DataSet GetTreeData_ShortMessage_JSR(string iDFieldName, string nameFieldName, string parentFieldValue = null, string conditionFieldName = null, string conditionFieldValue = null, bool onlyShowUsed = false)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetTreeData_ShortMessage_JSR";
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
  
