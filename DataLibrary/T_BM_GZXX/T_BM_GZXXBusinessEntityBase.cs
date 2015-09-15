/****************************************************** 
FileName:T_BM_GZXXBusinessEntityBase.cs
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

namespace  RICH.Common.BM.T_BM_GZXX
{
    //=========================================================================
    //  ClassName : T_BM_GZXXBusinessEntityBase
    /// <summary>
    /// T_BM_GZXX的逻辑实体类
    /// </summary>
    //=========================================================================
    public class T_BM_GZXXBusinessEntityBase : BusinessEntityBase
    {
        #region 数据实体
        /// <summary>
        /// AppData
        /// </summary>
        private T_BM_GZXXApplicationData m_AppData;

        /// <summary>
        /// 取得设定AppData
        /// </summary>
        /// <value>AppData</value>
        public T_BM_GZXXApplicationData AppData
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
            string strProcName = "SP_InsertT_BM_GZXX";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@XM", DbType.String);
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@FFGZNY", DbType.String);
            db.AddInParameter(cmdProc, "@JCGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JSDJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@ZWGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JBGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JKDQJT", DbType.Double);
            db.AddInParameter(cmdProc, "@JKTSGWJT", DbType.Double);
            db.AddInParameter(cmdProc, "@GLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@XJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@TGBF", DbType.Double);
            db.AddInParameter(cmdProc, "@DHF", DbType.Double);
            db.AddInParameter(cmdProc, "@DSZNF", DbType.Double);
            db.AddInParameter(cmdProc, "@FNWSHLF", DbType.Double);
            db.AddInParameter(cmdProc, "@HLF", DbType.Double);
            db.AddInParameter(cmdProc, "@JJ", DbType.Double);
            db.AddInParameter(cmdProc, "@JTF", DbType.Double);
            db.AddInParameter(cmdProc, "@JHLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JT", DbType.Double);
            db.AddInParameter(cmdProc, "@BF", DbType.Double);
            db.AddInParameter(cmdProc, "@QTBT", DbType.Double);
            db.AddInParameter(cmdProc, "@DFXJT", DbType.Double);
            db.AddInParameter(cmdProc, "@YFX", DbType.Double);
            db.AddInParameter(cmdProc, "@QTKK", DbType.Double);
            db.AddInParameter(cmdProc, "@SYBX", DbType.Double);
            db.AddInParameter(cmdProc, "@SDNQF", DbType.Double);
            db.AddInParameter(cmdProc, "@SDS", DbType.Double);
            db.AddInParameter(cmdProc, "@YLBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YLIBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YSSHF", DbType.Double);
            db.AddInParameter(cmdProc, "@ZFGJJ", DbType.Double);
            db.AddInParameter(cmdProc, "@KFX", DbType.Double);
            db.AddInParameter(cmdProc, "@SFGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@GZKKSM", DbType.String);
            db.AddInParameter(cmdProc, "@TJSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@XM", AppData.XM);
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@FFGZNY", AppData.FFGZNY);
            db.SetParameterValue(cmdProc, "@JCGZ", AppData.JCGZ);
            db.SetParameterValue(cmdProc, "@JSDJGZ", AppData.JSDJGZ);
            db.SetParameterValue(cmdProc, "@ZWGZ", AppData.ZWGZ);
            db.SetParameterValue(cmdProc, "@JBGZ", AppData.JBGZ);
            db.SetParameterValue(cmdProc, "@JKDQJT", AppData.JKDQJT);
            db.SetParameterValue(cmdProc, "@JKTSGWJT", AppData.JKTSGWJT);
            db.SetParameterValue(cmdProc, "@GLGZ", AppData.GLGZ);
            db.SetParameterValue(cmdProc, "@XJGZ", AppData.XJGZ);
            db.SetParameterValue(cmdProc, "@TGBF", AppData.TGBF);
            db.SetParameterValue(cmdProc, "@DHF", AppData.DHF);
            db.SetParameterValue(cmdProc, "@DSZNF", AppData.DSZNF);
            db.SetParameterValue(cmdProc, "@FNWSHLF", AppData.FNWSHLF);
            db.SetParameterValue(cmdProc, "@HLF", AppData.HLF);
            db.SetParameterValue(cmdProc, "@JJ", AppData.JJ);
            db.SetParameterValue(cmdProc, "@JTF", AppData.JTF);
            db.SetParameterValue(cmdProc, "@JHLGZ", AppData.JHLGZ);
            db.SetParameterValue(cmdProc, "@JT", AppData.JT);
            db.SetParameterValue(cmdProc, "@BF", AppData.BF);
            db.SetParameterValue(cmdProc, "@QTBT", AppData.QTBT);
            db.SetParameterValue(cmdProc, "@DFXJT", AppData.DFXJT);
            db.SetParameterValue(cmdProc, "@YFX", AppData.YFX);
            db.SetParameterValue(cmdProc, "@QTKK", AppData.QTKK);
            db.SetParameterValue(cmdProc, "@SYBX", AppData.SYBX);
            db.SetParameterValue(cmdProc, "@SDNQF", AppData.SDNQF);
            db.SetParameterValue(cmdProc, "@SDS", AppData.SDS);
            db.SetParameterValue(cmdProc, "@YLBX", AppData.YLBX);
            db.SetParameterValue(cmdProc, "@YLIBX", AppData.YLIBX);
            db.SetParameterValue(cmdProc, "@YSSHF", AppData.YSSHF);
            db.SetParameterValue(cmdProc, "@ZFGJJ", AppData.ZFGJJ);
            db.SetParameterValue(cmdProc, "@KFX", AppData.KFX);
            db.SetParameterValue(cmdProc, "@SFGZ", AppData.SFGZ);
            db.SetParameterValue(cmdProc, "@GZKKSM", AppData.GZKKSM);
            db.SetParameterValue(cmdProc, "@TJSJ", AppData.TJSJ);
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
            string strProcName = "SP_UpdateT_BM_GZXXByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@XM", DbType.String);
            db.AddInParameter(cmdProc, "@XMBatch", DbType.String);
            db.AddInParameter(cmdProc, "@XMValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@XBBatch", DbType.String);
            db.AddInParameter(cmdProc, "@XBValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@SFZHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SFZHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@FFGZNY", DbType.String);
            db.AddInParameter(cmdProc, "@FFGZNYBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FFGZNYValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@JCGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JCGZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JCGZValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@JSDJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JSDJGZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JSDJGZValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@ZWGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@ZWGZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ZWGZValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@JBGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JBGZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JBGZValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@JKDQJT", DbType.Double);
            db.AddInParameter(cmdProc, "@JKDQJTBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JKDQJTValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@JKTSGWJT", DbType.Double);
            db.AddInParameter(cmdProc, "@JKTSGWJTBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JKTSGWJTValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@GLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@GLGZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@GLGZValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@XJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@XJGZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@XJGZValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@TGBF", DbType.Double);
            db.AddInParameter(cmdProc, "@TGBFBatch", DbType.String);
            db.AddInParameter(cmdProc, "@TGBFValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@DHF", DbType.Double);
            db.AddInParameter(cmdProc, "@DHFBatch", DbType.String);
            db.AddInParameter(cmdProc, "@DHFValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@DSZNF", DbType.Double);
            db.AddInParameter(cmdProc, "@DSZNFBatch", DbType.String);
            db.AddInParameter(cmdProc, "@DSZNFValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@FNWSHLF", DbType.Double);
            db.AddInParameter(cmdProc, "@FNWSHLFBatch", DbType.String);
            db.AddInParameter(cmdProc, "@FNWSHLFValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@HLF", DbType.Double);
            db.AddInParameter(cmdProc, "@HLFBatch", DbType.String);
            db.AddInParameter(cmdProc, "@HLFValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@JJ", DbType.Double);
            db.AddInParameter(cmdProc, "@JJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JJValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@JTF", DbType.Double);
            db.AddInParameter(cmdProc, "@JTFBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JTFValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@JHLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JHLGZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JHLGZValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@JT", DbType.Double);
            db.AddInParameter(cmdProc, "@JTBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JTValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@BF", DbType.Double);
            db.AddInParameter(cmdProc, "@BFBatch", DbType.String);
            db.AddInParameter(cmdProc, "@BFValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@QTBT", DbType.Double);
            db.AddInParameter(cmdProc, "@QTBTBatch", DbType.String);
            db.AddInParameter(cmdProc, "@QTBTValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@DFXJT", DbType.Double);
            db.AddInParameter(cmdProc, "@DFXJTBatch", DbType.String);
            db.AddInParameter(cmdProc, "@DFXJTValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@YFX", DbType.Double);
            db.AddInParameter(cmdProc, "@YFXBegin", DbType.Double);
            db.AddInParameter(cmdProc, "@YFXEnd", DbType.Double);
            db.AddInParameter(cmdProc, "@YFXBatch", DbType.String);
            db.AddInParameter(cmdProc, "@YFXValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@QTKK", DbType.Double);
            db.AddInParameter(cmdProc, "@QTKKBatch", DbType.String);
            db.AddInParameter(cmdProc, "@QTKKValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@SYBX", DbType.Double);
            db.AddInParameter(cmdProc, "@SYBXBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SYBXValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@SDNQF", DbType.Double);
            db.AddInParameter(cmdProc, "@SDNQFBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SDNQFValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@SDS", DbType.Double);
            db.AddInParameter(cmdProc, "@SDSBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SDSValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@YLBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YLBXBatch", DbType.String);
            db.AddInParameter(cmdProc, "@YLBXValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@YLIBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YLIBXBatch", DbType.String);
            db.AddInParameter(cmdProc, "@YLIBXValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@YSSHF", DbType.Double);
            db.AddInParameter(cmdProc, "@YSSHFBatch", DbType.String);
            db.AddInParameter(cmdProc, "@YSSHFValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@ZFGJJ", DbType.Double);
            db.AddInParameter(cmdProc, "@ZFGJJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ZFGJJValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@KFX", DbType.Double);
            db.AddInParameter(cmdProc, "@KFXBatch", DbType.String);
            db.AddInParameter(cmdProc, "@KFXValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@SFGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@SFGZBegin", DbType.Double);
            db.AddInParameter(cmdProc, "@SFGZEnd", DbType.Double);
            db.AddInParameter(cmdProc, "@SFGZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SFGZValue", DbType.Double);
                
            db.AddInParameter(cmdProc, "@GZKKSM", DbType.String);
            db.AddInParameter(cmdProc, "@GZKKSMBatch", DbType.String);
            db.AddInParameter(cmdProc, "@GZKKSMValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@TJSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@TJSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@TJSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@TJSJBatch", DbType.String);
            db.AddInParameter(cmdProc, "@TJSJValue", DbType.DateTime);
                
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@QueryKeywords", AppData.QueryKeywords);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@XM", AppData.XM);
            db.SetParameterValue(cmdProc, "@XMBatch", AppData.XMBatch);
            db.SetParameterValue(cmdProc, "@XMValue", AppData.XMValue);
                
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@XBBatch", AppData.XBBatch);
            db.SetParameterValue(cmdProc, "@XBValue", AppData.XBValue);
                
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@SFZHBatch", AppData.SFZHBatch);
            db.SetParameterValue(cmdProc, "@SFZHValue", AppData.SFZHValue);
                
            db.SetParameterValue(cmdProc, "@FFGZNY", AppData.FFGZNY);
            db.SetParameterValue(cmdProc, "@FFGZNYBatch", AppData.FFGZNYBatch);
            db.SetParameterValue(cmdProc, "@FFGZNYValue", AppData.FFGZNYValue);
                
            db.SetParameterValue(cmdProc, "@JCGZ", AppData.JCGZ);
            db.SetParameterValue(cmdProc, "@JCGZBatch", AppData.JCGZBatch);
            db.SetParameterValue(cmdProc, "@JCGZValue", AppData.JCGZValue);
                
            db.SetParameterValue(cmdProc, "@JSDJGZ", AppData.JSDJGZ);
            db.SetParameterValue(cmdProc, "@JSDJGZBatch", AppData.JSDJGZBatch);
            db.SetParameterValue(cmdProc, "@JSDJGZValue", AppData.JSDJGZValue);
                
            db.SetParameterValue(cmdProc, "@ZWGZ", AppData.ZWGZ);
            db.SetParameterValue(cmdProc, "@ZWGZBatch", AppData.ZWGZBatch);
            db.SetParameterValue(cmdProc, "@ZWGZValue", AppData.ZWGZValue);
                
            db.SetParameterValue(cmdProc, "@JBGZ", AppData.JBGZ);
            db.SetParameterValue(cmdProc, "@JBGZBatch", AppData.JBGZBatch);
            db.SetParameterValue(cmdProc, "@JBGZValue", AppData.JBGZValue);
                
            db.SetParameterValue(cmdProc, "@JKDQJT", AppData.JKDQJT);
            db.SetParameterValue(cmdProc, "@JKDQJTBatch", AppData.JKDQJTBatch);
            db.SetParameterValue(cmdProc, "@JKDQJTValue", AppData.JKDQJTValue);
                
            db.SetParameterValue(cmdProc, "@JKTSGWJT", AppData.JKTSGWJT);
            db.SetParameterValue(cmdProc, "@JKTSGWJTBatch", AppData.JKTSGWJTBatch);
            db.SetParameterValue(cmdProc, "@JKTSGWJTValue", AppData.JKTSGWJTValue);
                
            db.SetParameterValue(cmdProc, "@GLGZ", AppData.GLGZ);
            db.SetParameterValue(cmdProc, "@GLGZBatch", AppData.GLGZBatch);
            db.SetParameterValue(cmdProc, "@GLGZValue", AppData.GLGZValue);
                
            db.SetParameterValue(cmdProc, "@XJGZ", AppData.XJGZ);
            db.SetParameterValue(cmdProc, "@XJGZBatch", AppData.XJGZBatch);
            db.SetParameterValue(cmdProc, "@XJGZValue", AppData.XJGZValue);
                
            db.SetParameterValue(cmdProc, "@TGBF", AppData.TGBF);
            db.SetParameterValue(cmdProc, "@TGBFBatch", AppData.TGBFBatch);
            db.SetParameterValue(cmdProc, "@TGBFValue", AppData.TGBFValue);
                
            db.SetParameterValue(cmdProc, "@DHF", AppData.DHF);
            db.SetParameterValue(cmdProc, "@DHFBatch", AppData.DHFBatch);
            db.SetParameterValue(cmdProc, "@DHFValue", AppData.DHFValue);
                
            db.SetParameterValue(cmdProc, "@DSZNF", AppData.DSZNF);
            db.SetParameterValue(cmdProc, "@DSZNFBatch", AppData.DSZNFBatch);
            db.SetParameterValue(cmdProc, "@DSZNFValue", AppData.DSZNFValue);
                
            db.SetParameterValue(cmdProc, "@FNWSHLF", AppData.FNWSHLF);
            db.SetParameterValue(cmdProc, "@FNWSHLFBatch", AppData.FNWSHLFBatch);
            db.SetParameterValue(cmdProc, "@FNWSHLFValue", AppData.FNWSHLFValue);
                
            db.SetParameterValue(cmdProc, "@HLF", AppData.HLF);
            db.SetParameterValue(cmdProc, "@HLFBatch", AppData.HLFBatch);
            db.SetParameterValue(cmdProc, "@HLFValue", AppData.HLFValue);
                
            db.SetParameterValue(cmdProc, "@JJ", AppData.JJ);
            db.SetParameterValue(cmdProc, "@JJBatch", AppData.JJBatch);
            db.SetParameterValue(cmdProc, "@JJValue", AppData.JJValue);
                
            db.SetParameterValue(cmdProc, "@JTF", AppData.JTF);
            db.SetParameterValue(cmdProc, "@JTFBatch", AppData.JTFBatch);
            db.SetParameterValue(cmdProc, "@JTFValue", AppData.JTFValue);
                
            db.SetParameterValue(cmdProc, "@JHLGZ", AppData.JHLGZ);
            db.SetParameterValue(cmdProc, "@JHLGZBatch", AppData.JHLGZBatch);
            db.SetParameterValue(cmdProc, "@JHLGZValue", AppData.JHLGZValue);
                
            db.SetParameterValue(cmdProc, "@JT", AppData.JT);
            db.SetParameterValue(cmdProc, "@JTBatch", AppData.JTBatch);
            db.SetParameterValue(cmdProc, "@JTValue", AppData.JTValue);
                
            db.SetParameterValue(cmdProc, "@BF", AppData.BF);
            db.SetParameterValue(cmdProc, "@BFBatch", AppData.BFBatch);
            db.SetParameterValue(cmdProc, "@BFValue", AppData.BFValue);
                
            db.SetParameterValue(cmdProc, "@QTBT", AppData.QTBT);
            db.SetParameterValue(cmdProc, "@QTBTBatch", AppData.QTBTBatch);
            db.SetParameterValue(cmdProc, "@QTBTValue", AppData.QTBTValue);
                
            db.SetParameterValue(cmdProc, "@DFXJT", AppData.DFXJT);
            db.SetParameterValue(cmdProc, "@DFXJTBatch", AppData.DFXJTBatch);
            db.SetParameterValue(cmdProc, "@DFXJTValue", AppData.DFXJTValue);
                
            db.SetParameterValue(cmdProc, "@YFX", AppData.YFX);
            db.SetParameterValue(cmdProc, "@YFXBegin", AppData.YFXBegin);
            db.SetParameterValue(cmdProc, "@YFXEnd", AppData.YFXEnd);
            db.SetParameterValue(cmdProc, "@YFXBatch", AppData.YFXBatch);
            db.SetParameterValue(cmdProc, "@YFXValue", AppData.YFXValue);
                
            db.SetParameterValue(cmdProc, "@QTKK", AppData.QTKK);
            db.SetParameterValue(cmdProc, "@QTKKBatch", AppData.QTKKBatch);
            db.SetParameterValue(cmdProc, "@QTKKValue", AppData.QTKKValue);
                
            db.SetParameterValue(cmdProc, "@SYBX", AppData.SYBX);
            db.SetParameterValue(cmdProc, "@SYBXBatch", AppData.SYBXBatch);
            db.SetParameterValue(cmdProc, "@SYBXValue", AppData.SYBXValue);
                
            db.SetParameterValue(cmdProc, "@SDNQF", AppData.SDNQF);
            db.SetParameterValue(cmdProc, "@SDNQFBatch", AppData.SDNQFBatch);
            db.SetParameterValue(cmdProc, "@SDNQFValue", AppData.SDNQFValue);
                
            db.SetParameterValue(cmdProc, "@SDS", AppData.SDS);
            db.SetParameterValue(cmdProc, "@SDSBatch", AppData.SDSBatch);
            db.SetParameterValue(cmdProc, "@SDSValue", AppData.SDSValue);
                
            db.SetParameterValue(cmdProc, "@YLBX", AppData.YLBX);
            db.SetParameterValue(cmdProc, "@YLBXBatch", AppData.YLBXBatch);
            db.SetParameterValue(cmdProc, "@YLBXValue", AppData.YLBXValue);
                
            db.SetParameterValue(cmdProc, "@YLIBX", AppData.YLIBX);
            db.SetParameterValue(cmdProc, "@YLIBXBatch", AppData.YLIBXBatch);
            db.SetParameterValue(cmdProc, "@YLIBXValue", AppData.YLIBXValue);
                
            db.SetParameterValue(cmdProc, "@YSSHF", AppData.YSSHF);
            db.SetParameterValue(cmdProc, "@YSSHFBatch", AppData.YSSHFBatch);
            db.SetParameterValue(cmdProc, "@YSSHFValue", AppData.YSSHFValue);
                
            db.SetParameterValue(cmdProc, "@ZFGJJ", AppData.ZFGJJ);
            db.SetParameterValue(cmdProc, "@ZFGJJBatch", AppData.ZFGJJBatch);
            db.SetParameterValue(cmdProc, "@ZFGJJValue", AppData.ZFGJJValue);
                
            db.SetParameterValue(cmdProc, "@KFX", AppData.KFX);
            db.SetParameterValue(cmdProc, "@KFXBatch", AppData.KFXBatch);
            db.SetParameterValue(cmdProc, "@KFXValue", AppData.KFXValue);
                
            db.SetParameterValue(cmdProc, "@SFGZ", AppData.SFGZ);
            db.SetParameterValue(cmdProc, "@SFGZBegin", AppData.SFGZBegin);
            db.SetParameterValue(cmdProc, "@SFGZEnd", AppData.SFGZEnd);
            db.SetParameterValue(cmdProc, "@SFGZBatch", AppData.SFGZBatch);
            db.SetParameterValue(cmdProc, "@SFGZValue", AppData.SFGZValue);
                
            db.SetParameterValue(cmdProc, "@GZKKSM", AppData.GZKKSM);
            db.SetParameterValue(cmdProc, "@GZKKSMBatch", AppData.GZKKSMBatch);
            db.SetParameterValue(cmdProc, "@GZKKSMValue", AppData.GZKKSMValue);
                
            db.SetParameterValue(cmdProc, "@TJSJ", AppData.TJSJ);
            db.SetParameterValue(cmdProc, "@TJSJBegin", AppData.TJSJBegin);
            db.SetParameterValue(cmdProc, "@TJSJEnd", AppData.TJSJEnd);
            db.SetParameterValue(cmdProc, "@TJSJBatch", AppData.TJSJBatch);
            db.SetParameterValue(cmdProc, "@TJSJValue", AppData.TJSJValue);
                
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
            string strProcName = "SP_UpdateT_BM_GZXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@XM", DbType.String);
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@FFGZNY", DbType.String);
            db.AddInParameter(cmdProc, "@JCGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JSDJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@ZWGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JBGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JKDQJT", DbType.Double);
            db.AddInParameter(cmdProc, "@JKTSGWJT", DbType.Double);
            db.AddInParameter(cmdProc, "@GLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@XJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@TGBF", DbType.Double);
            db.AddInParameter(cmdProc, "@DHF", DbType.Double);
            db.AddInParameter(cmdProc, "@DSZNF", DbType.Double);
            db.AddInParameter(cmdProc, "@FNWSHLF", DbType.Double);
            db.AddInParameter(cmdProc, "@HLF", DbType.Double);
            db.AddInParameter(cmdProc, "@JJ", DbType.Double);
            db.AddInParameter(cmdProc, "@JTF", DbType.Double);
            db.AddInParameter(cmdProc, "@JHLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JT", DbType.Double);
            db.AddInParameter(cmdProc, "@BF", DbType.Double);
            db.AddInParameter(cmdProc, "@QTBT", DbType.Double);
            db.AddInParameter(cmdProc, "@DFXJT", DbType.Double);
            db.AddInParameter(cmdProc, "@YFX", DbType.Double);
            db.AddInParameter(cmdProc, "@QTKK", DbType.Double);
            db.AddInParameter(cmdProc, "@SYBX", DbType.Double);
            db.AddInParameter(cmdProc, "@SDNQF", DbType.Double);
            db.AddInParameter(cmdProc, "@SDS", DbType.Double);
            db.AddInParameter(cmdProc, "@YLBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YLIBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YSSHF", DbType.Double);
            db.AddInParameter(cmdProc, "@ZFGJJ", DbType.Double);
            db.AddInParameter(cmdProc, "@KFX", DbType.Double);
            db.AddInParameter(cmdProc, "@SFGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@GZKKSM", DbType.String);
            db.AddInParameter(cmdProc, "@TJSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@XM", AppData.XM);
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@FFGZNY", AppData.FFGZNY);
            db.SetParameterValue(cmdProc, "@JCGZ", AppData.JCGZ);
            db.SetParameterValue(cmdProc, "@JSDJGZ", AppData.JSDJGZ);
            db.SetParameterValue(cmdProc, "@ZWGZ", AppData.ZWGZ);
            db.SetParameterValue(cmdProc, "@JBGZ", AppData.JBGZ);
            db.SetParameterValue(cmdProc, "@JKDQJT", AppData.JKDQJT);
            db.SetParameterValue(cmdProc, "@JKTSGWJT", AppData.JKTSGWJT);
            db.SetParameterValue(cmdProc, "@GLGZ", AppData.GLGZ);
            db.SetParameterValue(cmdProc, "@XJGZ", AppData.XJGZ);
            db.SetParameterValue(cmdProc, "@TGBF", AppData.TGBF);
            db.SetParameterValue(cmdProc, "@DHF", AppData.DHF);
            db.SetParameterValue(cmdProc, "@DSZNF", AppData.DSZNF);
            db.SetParameterValue(cmdProc, "@FNWSHLF", AppData.FNWSHLF);
            db.SetParameterValue(cmdProc, "@HLF", AppData.HLF);
            db.SetParameterValue(cmdProc, "@JJ", AppData.JJ);
            db.SetParameterValue(cmdProc, "@JTF", AppData.JTF);
            db.SetParameterValue(cmdProc, "@JHLGZ", AppData.JHLGZ);
            db.SetParameterValue(cmdProc, "@JT", AppData.JT);
            db.SetParameterValue(cmdProc, "@BF", AppData.BF);
            db.SetParameterValue(cmdProc, "@QTBT", AppData.QTBT);
            db.SetParameterValue(cmdProc, "@DFXJT", AppData.DFXJT);
            db.SetParameterValue(cmdProc, "@YFX", AppData.YFX);
            db.SetParameterValue(cmdProc, "@QTKK", AppData.QTKK);
            db.SetParameterValue(cmdProc, "@SYBX", AppData.SYBX);
            db.SetParameterValue(cmdProc, "@SDNQF", AppData.SDNQF);
            db.SetParameterValue(cmdProc, "@SDS", AppData.SDS);
            db.SetParameterValue(cmdProc, "@YLBX", AppData.YLBX);
            db.SetParameterValue(cmdProc, "@YLIBX", AppData.YLIBX);
            db.SetParameterValue(cmdProc, "@YSSHF", AppData.YSSHF);
            db.SetParameterValue(cmdProc, "@ZFGJJ", AppData.ZFGJJ);
            db.SetParameterValue(cmdProc, "@KFX", AppData.KFX);
            db.SetParameterValue(cmdProc, "@SFGZ", AppData.SFGZ);
            db.SetParameterValue(cmdProc, "@GZKKSM", AppData.GZKKSM);
            db.SetParameterValue(cmdProc, "@TJSJ", AppData.TJSJ);
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
            string strProcName = "SP_UpdateT_BM_GZXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@XM", DbType.String);
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@FFGZNY", DbType.String);
            db.AddInParameter(cmdProc, "@JCGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JSDJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@ZWGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JBGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JKDQJT", DbType.Double);
            db.AddInParameter(cmdProc, "@JKTSGWJT", DbType.Double);
            db.AddInParameter(cmdProc, "@GLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@XJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@TGBF", DbType.Double);
            db.AddInParameter(cmdProc, "@DHF", DbType.Double);
            db.AddInParameter(cmdProc, "@DSZNF", DbType.Double);
            db.AddInParameter(cmdProc, "@FNWSHLF", DbType.Double);
            db.AddInParameter(cmdProc, "@HLF", DbType.Double);
            db.AddInParameter(cmdProc, "@JJ", DbType.Double);
            db.AddInParameter(cmdProc, "@JTF", DbType.Double);
            db.AddInParameter(cmdProc, "@JHLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JT", DbType.Double);
            db.AddInParameter(cmdProc, "@BF", DbType.Double);
            db.AddInParameter(cmdProc, "@QTBT", DbType.Double);
            db.AddInParameter(cmdProc, "@DFXJT", DbType.Double);
            db.AddInParameter(cmdProc, "@YFX", DbType.Double);
            db.AddInParameter(cmdProc, "@QTKK", DbType.Double);
            db.AddInParameter(cmdProc, "@SYBX", DbType.Double);
            db.AddInParameter(cmdProc, "@SDNQF", DbType.Double);
            db.AddInParameter(cmdProc, "@SDS", DbType.Double);
            db.AddInParameter(cmdProc, "@YLBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YLIBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YSSHF", DbType.Double);
            db.AddInParameter(cmdProc, "@ZFGJJ", DbType.Double);
            db.AddInParameter(cmdProc, "@KFX", DbType.Double);
            db.AddInParameter(cmdProc, "@SFGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@GZKKSM", DbType.String);
            db.AddInParameter(cmdProc, "@TJSJ", DbType.DateTime);
            // 对存储过程参数赋值

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@XM", AppData.XM);
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@FFGZNY", AppData.FFGZNY);
            db.SetParameterValue(cmdProc, "@JCGZ", AppData.JCGZ);
            db.SetParameterValue(cmdProc, "@JSDJGZ", AppData.JSDJGZ);
            db.SetParameterValue(cmdProc, "@ZWGZ", AppData.ZWGZ);
            db.SetParameterValue(cmdProc, "@JBGZ", AppData.JBGZ);
            db.SetParameterValue(cmdProc, "@JKDQJT", AppData.JKDQJT);
            db.SetParameterValue(cmdProc, "@JKTSGWJT", AppData.JKTSGWJT);
            db.SetParameterValue(cmdProc, "@GLGZ", AppData.GLGZ);
            db.SetParameterValue(cmdProc, "@XJGZ", AppData.XJGZ);
            db.SetParameterValue(cmdProc, "@TGBF", AppData.TGBF);
            db.SetParameterValue(cmdProc, "@DHF", AppData.DHF);
            db.SetParameterValue(cmdProc, "@DSZNF", AppData.DSZNF);
            db.SetParameterValue(cmdProc, "@FNWSHLF", AppData.FNWSHLF);
            db.SetParameterValue(cmdProc, "@HLF", AppData.HLF);
            db.SetParameterValue(cmdProc, "@JJ", AppData.JJ);
            db.SetParameterValue(cmdProc, "@JTF", AppData.JTF);
            db.SetParameterValue(cmdProc, "@JHLGZ", AppData.JHLGZ);
            db.SetParameterValue(cmdProc, "@JT", AppData.JT);
            db.SetParameterValue(cmdProc, "@BF", AppData.BF);
            db.SetParameterValue(cmdProc, "@QTBT", AppData.QTBT);
            db.SetParameterValue(cmdProc, "@DFXJT", AppData.DFXJT);
            db.SetParameterValue(cmdProc, "@YFX", AppData.YFX);
            db.SetParameterValue(cmdProc, "@QTKK", AppData.QTKK);
            db.SetParameterValue(cmdProc, "@SYBX", AppData.SYBX);
            db.SetParameterValue(cmdProc, "@SDNQF", AppData.SDNQF);
            db.SetParameterValue(cmdProc, "@SDS", AppData.SDS);
            db.SetParameterValue(cmdProc, "@YLBX", AppData.YLBX);
            db.SetParameterValue(cmdProc, "@YLIBX", AppData.YLIBX);
            db.SetParameterValue(cmdProc, "@YSSHF", AppData.YSSHF);
            db.SetParameterValue(cmdProc, "@ZFGJJ", AppData.ZFGJJ);
            db.SetParameterValue(cmdProc, "@KFX", AppData.KFX);
            db.SetParameterValue(cmdProc, "@SFGZ", AppData.SFGZ);
            db.SetParameterValue(cmdProc, "@GZKKSM", AppData.GZKKSM);
            db.SetParameterValue(cmdProc, "@TJSJ", AppData.TJSJ);
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
            string strProcName = "SP_UpdateT_BM_GZXXByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@XM", DbType.String);
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@FFGZNY", DbType.String);
            db.AddInParameter(cmdProc, "@JCGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JSDJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@ZWGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JBGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JKDQJT", DbType.Double);
            db.AddInParameter(cmdProc, "@JKTSGWJT", DbType.Double);
            db.AddInParameter(cmdProc, "@GLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@XJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@TGBF", DbType.Double);
            db.AddInParameter(cmdProc, "@DHF", DbType.Double);
            db.AddInParameter(cmdProc, "@DSZNF", DbType.Double);
            db.AddInParameter(cmdProc, "@FNWSHLF", DbType.Double);
            db.AddInParameter(cmdProc, "@HLF", DbType.Double);
            db.AddInParameter(cmdProc, "@JJ", DbType.Double);
            db.AddInParameter(cmdProc, "@JTF", DbType.Double);
            db.AddInParameter(cmdProc, "@JHLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JT", DbType.Double);
            db.AddInParameter(cmdProc, "@BF", DbType.Double);
            db.AddInParameter(cmdProc, "@QTBT", DbType.Double);
            db.AddInParameter(cmdProc, "@DFXJT", DbType.Double);
            db.AddInParameter(cmdProc, "@YFX", DbType.Double);
            db.AddInParameter(cmdProc, "@QTKK", DbType.Double);
            db.AddInParameter(cmdProc, "@SYBX", DbType.Double);
            db.AddInParameter(cmdProc, "@SDNQF", DbType.Double);
            db.AddInParameter(cmdProc, "@SDS", DbType.Double);
            db.AddInParameter(cmdProc, "@YLBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YLIBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YSSHF", DbType.Double);
            db.AddInParameter(cmdProc, "@ZFGJJ", DbType.Double);
            db.AddInParameter(cmdProc, "@KFX", DbType.Double);
            db.AddInParameter(cmdProc, "@SFGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@GZKKSM", DbType.String);
            db.AddInParameter(cmdProc, "@TJSJ", DbType.DateTime);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@XM", AppData.XM);
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@FFGZNY", AppData.FFGZNY);
            db.SetParameterValue(cmdProc, "@JCGZ", AppData.JCGZ);
            db.SetParameterValue(cmdProc, "@JSDJGZ", AppData.JSDJGZ);
            db.SetParameterValue(cmdProc, "@ZWGZ", AppData.ZWGZ);
            db.SetParameterValue(cmdProc, "@JBGZ", AppData.JBGZ);
            db.SetParameterValue(cmdProc, "@JKDQJT", AppData.JKDQJT);
            db.SetParameterValue(cmdProc, "@JKTSGWJT", AppData.JKTSGWJT);
            db.SetParameterValue(cmdProc, "@GLGZ", AppData.GLGZ);
            db.SetParameterValue(cmdProc, "@XJGZ", AppData.XJGZ);
            db.SetParameterValue(cmdProc, "@TGBF", AppData.TGBF);
            db.SetParameterValue(cmdProc, "@DHF", AppData.DHF);
            db.SetParameterValue(cmdProc, "@DSZNF", AppData.DSZNF);
            db.SetParameterValue(cmdProc, "@FNWSHLF", AppData.FNWSHLF);
            db.SetParameterValue(cmdProc, "@HLF", AppData.HLF);
            db.SetParameterValue(cmdProc, "@JJ", AppData.JJ);
            db.SetParameterValue(cmdProc, "@JTF", AppData.JTF);
            db.SetParameterValue(cmdProc, "@JHLGZ", AppData.JHLGZ);
            db.SetParameterValue(cmdProc, "@JT", AppData.JT);
            db.SetParameterValue(cmdProc, "@BF", AppData.BF);
            db.SetParameterValue(cmdProc, "@QTBT", AppData.QTBT);
            db.SetParameterValue(cmdProc, "@DFXJT", AppData.DFXJT);
            db.SetParameterValue(cmdProc, "@YFX", AppData.YFX);
            db.SetParameterValue(cmdProc, "@QTKK", AppData.QTKK);
            db.SetParameterValue(cmdProc, "@SYBX", AppData.SYBX);
            db.SetParameterValue(cmdProc, "@SDNQF", AppData.SDNQF);
            db.SetParameterValue(cmdProc, "@SDS", AppData.SDS);
            db.SetParameterValue(cmdProc, "@YLBX", AppData.YLBX);
            db.SetParameterValue(cmdProc, "@YLIBX", AppData.YLIBX);
            db.SetParameterValue(cmdProc, "@YSSHF", AppData.YSSHF);
            db.SetParameterValue(cmdProc, "@ZFGJJ", AppData.ZFGJJ);
            db.SetParameterValue(cmdProc, "@KFX", AppData.KFX);
            db.SetParameterValue(cmdProc, "@SFGZ", AppData.SFGZ);
            db.SetParameterValue(cmdProc, "@GZKKSM", AppData.GZKKSM);
            db.SetParameterValue(cmdProc, "@TJSJ", AppData.TJSJ);
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
            string strProcName = "SP_SelectT_BM_GZXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@FFGZNY", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@FFGZNY", AppData.FFGZNY);
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
            string strProcName = "SP_SelectT_BM_GZXXByObjectID";
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
        public static T_BM_GZXXApplicationData GetDataByObjectID(string strObjectID)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_GZXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // 执行存储过程
            return T_BM_GZXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// 以Key为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static T_BM_GZXXApplicationData GetDataByKey(T_BM_GZXXApplicationData appData)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_GZXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@FFGZNY", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@SFZH", appData.SFZH);
            db.SetParameterValue(cmdProc, "@FFGZNY", appData.FFGZNY);
            // 执行存储过程
            return T_BM_GZXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectT_BM_GZXXByAnyCondition";
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
                
            db.AddInParameter(cmdProc, "@XM", DbType.String);
            db.AddInParameter(cmdProc, "@XMBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@XBBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@SFZHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FFGZNY", DbType.String);
            db.AddInParameter(cmdProc, "@FFGZNYBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JCGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JCGZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JSDJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JSDJGZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@ZWGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@ZWGZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JBGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JBGZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JKDQJT", DbType.Double);
            db.AddInParameter(cmdProc, "@JKDQJTBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JKTSGWJT", DbType.Double);
            db.AddInParameter(cmdProc, "@JKTSGWJTBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@GLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@GLGZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@XJGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@XJGZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@TGBF", DbType.Double);
            db.AddInParameter(cmdProc, "@TGBFBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@DHF", DbType.Double);
            db.AddInParameter(cmdProc, "@DHFBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@DSZNF", DbType.Double);
            db.AddInParameter(cmdProc, "@DSZNFBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@FNWSHLF", DbType.Double);
            db.AddInParameter(cmdProc, "@FNWSHLFBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@HLF", DbType.Double);
            db.AddInParameter(cmdProc, "@HLFBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JJ", DbType.Double);
            db.AddInParameter(cmdProc, "@JJBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JTF", DbType.Double);
            db.AddInParameter(cmdProc, "@JTFBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JHLGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@JHLGZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JT", DbType.Double);
            db.AddInParameter(cmdProc, "@JTBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@BF", DbType.Double);
            db.AddInParameter(cmdProc, "@BFBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@QTBT", DbType.Double);
            db.AddInParameter(cmdProc, "@QTBTBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@DFXJT", DbType.Double);
            db.AddInParameter(cmdProc, "@DFXJTBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@YFX", DbType.Double);
            db.AddInParameter(cmdProc, "@YFXBegin", DbType.Double);
            db.AddInParameter(cmdProc, "@YFXEnd", DbType.Double);
            db.AddInParameter(cmdProc, "@YFXBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@QTKK", DbType.Double);
            db.AddInParameter(cmdProc, "@QTKKBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SYBX", DbType.Double);
            db.AddInParameter(cmdProc, "@SYBXBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SDNQF", DbType.Double);
            db.AddInParameter(cmdProc, "@SDNQFBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SDS", DbType.Double);
            db.AddInParameter(cmdProc, "@SDSBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@YLBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YLBXBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@YLIBX", DbType.Double);
            db.AddInParameter(cmdProc, "@YLIBXBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@YSSHF", DbType.Double);
            db.AddInParameter(cmdProc, "@YSSHFBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@ZFGJJ", DbType.Double);
            db.AddInParameter(cmdProc, "@ZFGJJBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@KFX", DbType.Double);
            db.AddInParameter(cmdProc, "@KFXBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SFGZ", DbType.Double);
            db.AddInParameter(cmdProc, "@SFGZBegin", DbType.Double);
            db.AddInParameter(cmdProc, "@SFGZEnd", DbType.Double);
            db.AddInParameter(cmdProc, "@SFGZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@GZKKSM", DbType.String);
            db.AddInParameter(cmdProc, "@GZKKSMBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@TJSJ", DbType.DateTime);
            db.AddInParameter(cmdProc, "@TJSJBegin", DbType.DateTime);
            db.AddInParameter(cmdProc, "@TJSJEnd", DbType.DateTime);
            db.AddInParameter(cmdProc, "@TJSJBatch", DbType.String);
                
            // 一对一相关表
            
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
      
            db.AddOutParameter(cmdProc, "@YFXSum", DbType.Double, 8);  
            db.AddOutParameter(cmdProc, "@SFGZSum", DbType.Double, 8);    
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
                
            db.SetParameterValue(cmdProc, "@XM", AppData.XM);
            db.SetParameterValue(cmdProc, "@XMBatch", AppData.XMBatch);
                
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@XBBatch", AppData.XBBatch);
                
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@SFZHBatch", AppData.SFZHBatch);
                
            db.SetParameterValue(cmdProc, "@FFGZNY", AppData.FFGZNY);
            db.SetParameterValue(cmdProc, "@FFGZNYBatch", AppData.FFGZNYBatch);
                
            db.SetParameterValue(cmdProc, "@JCGZ", AppData.JCGZ);
            db.SetParameterValue(cmdProc, "@JCGZBatch", AppData.JCGZBatch);
                
            db.SetParameterValue(cmdProc, "@JSDJGZ", AppData.JSDJGZ);
            db.SetParameterValue(cmdProc, "@JSDJGZBatch", AppData.JSDJGZBatch);
                
            db.SetParameterValue(cmdProc, "@ZWGZ", AppData.ZWGZ);
            db.SetParameterValue(cmdProc, "@ZWGZBatch", AppData.ZWGZBatch);
                
            db.SetParameterValue(cmdProc, "@JBGZ", AppData.JBGZ);
            db.SetParameterValue(cmdProc, "@JBGZBatch", AppData.JBGZBatch);
                
            db.SetParameterValue(cmdProc, "@JKDQJT", AppData.JKDQJT);
            db.SetParameterValue(cmdProc, "@JKDQJTBatch", AppData.JKDQJTBatch);
                
            db.SetParameterValue(cmdProc, "@JKTSGWJT", AppData.JKTSGWJT);
            db.SetParameterValue(cmdProc, "@JKTSGWJTBatch", AppData.JKTSGWJTBatch);
                
            db.SetParameterValue(cmdProc, "@GLGZ", AppData.GLGZ);
            db.SetParameterValue(cmdProc, "@GLGZBatch", AppData.GLGZBatch);
                
            db.SetParameterValue(cmdProc, "@XJGZ", AppData.XJGZ);
            db.SetParameterValue(cmdProc, "@XJGZBatch", AppData.XJGZBatch);
                
            db.SetParameterValue(cmdProc, "@TGBF", AppData.TGBF);
            db.SetParameterValue(cmdProc, "@TGBFBatch", AppData.TGBFBatch);
                
            db.SetParameterValue(cmdProc, "@DHF", AppData.DHF);
            db.SetParameterValue(cmdProc, "@DHFBatch", AppData.DHFBatch);
                
            db.SetParameterValue(cmdProc, "@DSZNF", AppData.DSZNF);
            db.SetParameterValue(cmdProc, "@DSZNFBatch", AppData.DSZNFBatch);
                
            db.SetParameterValue(cmdProc, "@FNWSHLF", AppData.FNWSHLF);
            db.SetParameterValue(cmdProc, "@FNWSHLFBatch", AppData.FNWSHLFBatch);
                
            db.SetParameterValue(cmdProc, "@HLF", AppData.HLF);
            db.SetParameterValue(cmdProc, "@HLFBatch", AppData.HLFBatch);
                
            db.SetParameterValue(cmdProc, "@JJ", AppData.JJ);
            db.SetParameterValue(cmdProc, "@JJBatch", AppData.JJBatch);
                
            db.SetParameterValue(cmdProc, "@JTF", AppData.JTF);
            db.SetParameterValue(cmdProc, "@JTFBatch", AppData.JTFBatch);
                
            db.SetParameterValue(cmdProc, "@JHLGZ", AppData.JHLGZ);
            db.SetParameterValue(cmdProc, "@JHLGZBatch", AppData.JHLGZBatch);
                
            db.SetParameterValue(cmdProc, "@JT", AppData.JT);
            db.SetParameterValue(cmdProc, "@JTBatch", AppData.JTBatch);
                
            db.SetParameterValue(cmdProc, "@BF", AppData.BF);
            db.SetParameterValue(cmdProc, "@BFBatch", AppData.BFBatch);
                
            db.SetParameterValue(cmdProc, "@QTBT", AppData.QTBT);
            db.SetParameterValue(cmdProc, "@QTBTBatch", AppData.QTBTBatch);
                
            db.SetParameterValue(cmdProc, "@DFXJT", AppData.DFXJT);
            db.SetParameterValue(cmdProc, "@DFXJTBatch", AppData.DFXJTBatch);
                
            db.SetParameterValue(cmdProc, "@YFX", AppData.YFX);
            db.SetParameterValue(cmdProc, "@YFXBegin", AppData.YFXBegin);
            db.SetParameterValue(cmdProc, "@YFXEnd", AppData.YFXEnd);
            db.SetParameterValue(cmdProc, "@YFXBatch", AppData.YFXBatch);
                
            db.SetParameterValue(cmdProc, "@QTKK", AppData.QTKK);
            db.SetParameterValue(cmdProc, "@QTKKBatch", AppData.QTKKBatch);
                
            db.SetParameterValue(cmdProc, "@SYBX", AppData.SYBX);
            db.SetParameterValue(cmdProc, "@SYBXBatch", AppData.SYBXBatch);
                
            db.SetParameterValue(cmdProc, "@SDNQF", AppData.SDNQF);
            db.SetParameterValue(cmdProc, "@SDNQFBatch", AppData.SDNQFBatch);
                
            db.SetParameterValue(cmdProc, "@SDS", AppData.SDS);
            db.SetParameterValue(cmdProc, "@SDSBatch", AppData.SDSBatch);
                
            db.SetParameterValue(cmdProc, "@YLBX", AppData.YLBX);
            db.SetParameterValue(cmdProc, "@YLBXBatch", AppData.YLBXBatch);
                
            db.SetParameterValue(cmdProc, "@YLIBX", AppData.YLIBX);
            db.SetParameterValue(cmdProc, "@YLIBXBatch", AppData.YLIBXBatch);
                
            db.SetParameterValue(cmdProc, "@YSSHF", AppData.YSSHF);
            db.SetParameterValue(cmdProc, "@YSSHFBatch", AppData.YSSHFBatch);
                
            db.SetParameterValue(cmdProc, "@ZFGJJ", AppData.ZFGJJ);
            db.SetParameterValue(cmdProc, "@ZFGJJBatch", AppData.ZFGJJBatch);
                
            db.SetParameterValue(cmdProc, "@KFX", AppData.KFX);
            db.SetParameterValue(cmdProc, "@KFXBatch", AppData.KFXBatch);
                
            db.SetParameterValue(cmdProc, "@SFGZ", AppData.SFGZ);
            db.SetParameterValue(cmdProc, "@SFGZBegin", AppData.SFGZBegin);
            db.SetParameterValue(cmdProc, "@SFGZEnd", AppData.SFGZEnd);
            db.SetParameterValue(cmdProc, "@SFGZBatch", AppData.SFGZBatch);
                
            db.SetParameterValue(cmdProc, "@GZKKSM", AppData.GZKKSM);
            db.SetParameterValue(cmdProc, "@GZKKSMBatch", AppData.GZKKSMBatch);
                
            db.SetParameterValue(cmdProc, "@TJSJ", AppData.TJSJ);
            db.SetParameterValue(cmdProc, "@TJSJBegin", AppData.TJSJBegin);
            db.SetParameterValue(cmdProc, "@TJSJEnd", AppData.TJSJEnd);
            db.SetParameterValue(cmdProc, "@TJSJBatch", AppData.TJSJBatch);
                
            // 一对一相关表
            
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
    
            if (db.GetParameterValue(cmdProc, "@YFXSum") != DBNull.Value)
            {
                AppData.YFXSum = (Double)db.GetParameterValue(cmdProc, "@YFXSum");
            }
            if (db.GetParameterValue(cmdProc, "@SFGZSum") != DBNull.Value)
            {
                AppData.SFGZSum = (Double)db.GetParameterValue(cmdProc, "@SFGZSum");
            }    
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
            string strProcName = "SP_DeleteT_BM_GZXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@FFGZNY", DbType.String);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@FFGZNY", AppData.FFGZNY);
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
            string strProcName = "SP_DeleteT_BM_GZXXByObjectID";
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
            string strProcName = "SP_DeleteT_BM_GZXXByObjectIDBatch";
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
            string strProcName = "SP_IsExistT_BM_GZXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@FFGZNY", DbType.String);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@FFGZNY", AppData.FFGZNY);
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
            string strProcName = "SP_IsExistT_BM_GZXXByObjectID";
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
                    string strProcName = "SP_SelectT_BM_GZXXByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // 设定存储过程输入参数
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@XM", DbType.String);
                    db.AddInParameter(cmdProc, "@XB", DbType.String);
                    db.AddInParameter(cmdProc, "@SFZH", DbType.String);
                    db.AddInParameter(cmdProc, "@FFGZNY", DbType.String);
                    db.AddInParameter(cmdProc, "@JCGZ", DbType.Double);
                    db.AddInParameter(cmdProc, "@JSDJGZ", DbType.Double);
                    db.AddInParameter(cmdProc, "@ZWGZ", DbType.Double);
                    db.AddInParameter(cmdProc, "@JBGZ", DbType.Double);
                    db.AddInParameter(cmdProc, "@JKDQJT", DbType.Double);
                    db.AddInParameter(cmdProc, "@JKTSGWJT", DbType.Double);
                    db.AddInParameter(cmdProc, "@GLGZ", DbType.Double);
                    db.AddInParameter(cmdProc, "@XJGZ", DbType.Double);
                    db.AddInParameter(cmdProc, "@TGBF", DbType.Double);
                    db.AddInParameter(cmdProc, "@DHF", DbType.Double);
                    db.AddInParameter(cmdProc, "@DSZNF", DbType.Double);
                    db.AddInParameter(cmdProc, "@FNWSHLF", DbType.Double);
                    db.AddInParameter(cmdProc, "@HLF", DbType.Double);
                    db.AddInParameter(cmdProc, "@JJ", DbType.Double);
                    db.AddInParameter(cmdProc, "@JTF", DbType.Double);
                    db.AddInParameter(cmdProc, "@JHLGZ", DbType.Double);
                    db.AddInParameter(cmdProc, "@JT", DbType.Double);
                    db.AddInParameter(cmdProc, "@BF", DbType.Double);
                    db.AddInParameter(cmdProc, "@QTBT", DbType.Double);
                    db.AddInParameter(cmdProc, "@DFXJT", DbType.Double);
                    db.AddInParameter(cmdProc, "@YFX", DbType.Double);
                    db.AddInParameter(cmdProc, "@QTKK", DbType.Double);
                    db.AddInParameter(cmdProc, "@SYBX", DbType.Double);
                    db.AddInParameter(cmdProc, "@SDNQF", DbType.Double);
                    db.AddInParameter(cmdProc, "@SDS", DbType.Double);
                    db.AddInParameter(cmdProc, "@YLBX", DbType.Double);
                    db.AddInParameter(cmdProc, "@YLIBX", DbType.Double);
                    db.AddInParameter(cmdProc, "@YSSHF", DbType.Double);
                    db.AddInParameter(cmdProc, "@ZFGJJ", DbType.Double);
                    db.AddInParameter(cmdProc, "@KFX", DbType.Double);
                    db.AddInParameter(cmdProc, "@SFGZ", DbType.Double);
                    db.AddInParameter(cmdProc, "@GZKKSM", DbType.String);
                    db.AddInParameter(cmdProc, "@TJSJ", DbType.DateTime);
                    // 设定存储过程输出参数
                    db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
              
                    db.AddOutParameter(cmdProc, "@YFXSum", DbType.Double, 8);  
                    db.AddOutParameter(cmdProc, "@SFGZSum", DbType.Double, 8);    
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
            string strProcName = "SP_GetMaxT_BM_GZXXBy";
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
            string strProcName = "SP_CountT_BM_GZXXByAnyCondition";
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
  
