/****************************************************** 
FileName:T_BG_0602BusinessEntityBase.cs
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

namespace  RICH.Common.BM.T_BG_0602
{
    //=========================================================================
    //  ClassName : T_BG_0602BusinessEntityBase
    /// <summary>
    /// T_BG_0602���߼�ʵ����
    /// </summary>
    //=========================================================================
    public class T_BG_0602BusinessEntityBase : BusinessEntityBase
    {
        #region ����ʵ��
        /// <summary>
        /// AppData
        /// </summary>
        private T_BG_0602ApplicationData m_AppData;

        /// <summary>
        /// ȡ���趨AppData
        /// </summary>
        /// <value>AppData</value>
        public T_BG_0602ApplicationData AppData
        {
            get { return m_AppData; }
            set { m_AppData = value; }
        }
        #endregion

        #region �Զ�Ӧ������ʵ��������ݿ����
        //=====================================================================
        //  FunctionName : Insert
        /// <summary>
        /// �����¼
        /// </summary>
        //=====================================================================
        public override void Insert()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_InsertT_BG_0602";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@LMH", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@LMM", DbType.String);
            db.AddInParameter(cmdProc, "@SJLMH", DbType.String);
            db.AddInParameter(cmdProc, "@LMTP", DbType.String);
            db.AddInParameter(cmdProc, "@LMNR", DbType.String);
            db.AddInParameter(cmdProc, "@LMLBYS", DbType.String);
            db.AddInParameter(cmdProc, "@SFLBLM", DbType.String);
            db.AddInParameter(cmdProc, "@SFWBURL", DbType.String);
            db.AddInParameter(cmdProc, "@WBURL", DbType.String);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@LMH", AppData.LMH);
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@LMM", AppData.LMM);
            db.SetParameterValue(cmdProc, "@SJLMH", AppData.SJLMH);
            db.SetParameterValue(cmdProc, "@LMTP", AppData.LMTP);
            db.SetParameterValue(cmdProc, "@LMNR", AppData.LMNR);
            db.SetParameterValue(cmdProc, "@LMLBYS", AppData.LMLBYS);
            db.SetParameterValue(cmdProc, "@SFLBLM", AppData.SFLBLM);
            db.SetParameterValue(cmdProc, "@SFWBURL", AppData.SFWBURL);
            db.SetParameterValue(cmdProc, "@WBURL", AppData.WBURL);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }
        
        //=====================================================================
        //  FunctionName : UpdateByAnyCondition
        /// <summary>
        /// �������������¼�¼
        /// </summary>
        //=====================================================================
        public override void UpdateByAnyCondition()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BG_0602ByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LMH", DbType.String);
            db.AddInParameter(cmdProc, "@LMHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LMHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LMM", DbType.String);
            db.AddInParameter(cmdProc, "@LMMBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LMMValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@SJLMH", DbType.String);
            db.AddInParameter(cmdProc, "@SJLMHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SJLMHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LMTP", DbType.String);
            db.AddInParameter(cmdProc, "@LMTPBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LMTPValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LMNR", DbType.String);
            db.AddInParameter(cmdProc, "@LMNRBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LMNRValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LMLBYS", DbType.String);
            db.AddInParameter(cmdProc, "@LMLBYSBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LMLBYSValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@SFLBLM", DbType.String);
            db.AddInParameter(cmdProc, "@SFLBLMBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SFLBLMValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@SFWBURL", DbType.String);
            db.AddInParameter(cmdProc, "@SFWBURLBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SFWBURLValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@WBURL", DbType.String);
            db.AddInParameter(cmdProc, "@WBURLBatch", DbType.String);
            db.AddInParameter(cmdProc, "@WBURLValue", DbType.String);
                
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@QueryKeywords", AppData.QueryKeywords);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@LMH", AppData.LMH);
            db.SetParameterValue(cmdProc, "@LMHBatch", AppData.LMHBatch);
            db.SetParameterValue(cmdProc, "@LMHValue", AppData.LMHValue);
                
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@LanguageIDBatch", AppData.LanguageIDBatch);
            db.SetParameterValue(cmdProc, "@LanguageIDValue", AppData.LanguageIDValue);
                
            db.SetParameterValue(cmdProc, "@LMM", AppData.LMM);
            db.SetParameterValue(cmdProc, "@LMMBatch", AppData.LMMBatch);
            db.SetParameterValue(cmdProc, "@LMMValue", AppData.LMMValue);
                
            db.SetParameterValue(cmdProc, "@SJLMH", AppData.SJLMH);
            db.SetParameterValue(cmdProc, "@SJLMHBatch", AppData.SJLMHBatch);
            db.SetParameterValue(cmdProc, "@SJLMHValue", AppData.SJLMHValue);
                
            db.SetParameterValue(cmdProc, "@LMTP", AppData.LMTP);
            db.SetParameterValue(cmdProc, "@LMTPBatch", AppData.LMTPBatch);
            db.SetParameterValue(cmdProc, "@LMTPValue", AppData.LMTPValue);
                
            db.SetParameterValue(cmdProc, "@LMNR", AppData.LMNR);
            db.SetParameterValue(cmdProc, "@LMNRBatch", AppData.LMNRBatch);
            db.SetParameterValue(cmdProc, "@LMNRValue", AppData.LMNRValue);
                
            db.SetParameterValue(cmdProc, "@LMLBYS", AppData.LMLBYS);
            db.SetParameterValue(cmdProc, "@LMLBYSBatch", AppData.LMLBYSBatch);
            db.SetParameterValue(cmdProc, "@LMLBYSValue", AppData.LMLBYSValue);
                
            db.SetParameterValue(cmdProc, "@SFLBLM", AppData.SFLBLM);
            db.SetParameterValue(cmdProc, "@SFLBLMBatch", AppData.SFLBLMBatch);
            db.SetParameterValue(cmdProc, "@SFLBLMValue", AppData.SFLBLMValue);
                
            db.SetParameterValue(cmdProc, "@SFWBURL", AppData.SFWBURL);
            db.SetParameterValue(cmdProc, "@SFWBURLBatch", AppData.SFWBURLBatch);
            db.SetParameterValue(cmdProc, "@SFWBURLValue", AppData.SFWBURLValue);
                
            db.SetParameterValue(cmdProc, "@WBURL", AppData.WBURL);
            db.SetParameterValue(cmdProc, "@WBURLBatch", AppData.WBURLBatch);
            db.SetParameterValue(cmdProc, "@WBURLValue", AppData.WBURLValue);
                
            // ִ�д洢����
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // �õ����µļ�¼��
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        }

        //=====================================================================
        //  FunctionName : UpdateByKey
        /// <summary>
        /// ������Ϊ�������¼�¼
        /// </summary>
        //=====================================================================
        public override void UpdateByKey()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BG_0602ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@LMH", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@LMM", DbType.String);
            db.AddInParameter(cmdProc, "@SJLMH", DbType.String);
            db.AddInParameter(cmdProc, "@LMTP", DbType.String);
            db.AddInParameter(cmdProc, "@LMNR", DbType.String);
            db.AddInParameter(cmdProc, "@LMLBYS", DbType.String);
            db.AddInParameter(cmdProc, "@SFLBLM", DbType.String);
            db.AddInParameter(cmdProc, "@SFWBURL", DbType.String);
            db.AddInParameter(cmdProc, "@WBURL", DbType.String);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@LMH", AppData.LMH);
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@LMM", AppData.LMM);
            db.SetParameterValue(cmdProc, "@SJLMH", AppData.SJLMH);
            db.SetParameterValue(cmdProc, "@LMTP", AppData.LMTP);
            db.SetParameterValue(cmdProc, "@LMNR", AppData.LMNR);
            db.SetParameterValue(cmdProc, "@LMLBYS", AppData.LMLBYS);
            db.SetParameterValue(cmdProc, "@SFLBLM", AppData.SFLBLM);
            db.SetParameterValue(cmdProc, "@SFWBURL", AppData.SFWBURL);
            db.SetParameterValue(cmdProc, "@WBURL", AppData.WBURL);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : UpdateByObjectID
        /// <summary>
        /// ��ObjectIDΪ�������¼�¼
        /// </summary>
        //=====================================================================
        public override void UpdateByObjectID()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BG_0602ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@LMH", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@LMM", DbType.String);
            db.AddInParameter(cmdProc, "@SJLMH", DbType.String);
            db.AddInParameter(cmdProc, "@LMTP", DbType.String);
            db.AddInParameter(cmdProc, "@LMNR", DbType.String);
            db.AddInParameter(cmdProc, "@LMLBYS", DbType.String);
            db.AddInParameter(cmdProc, "@SFLBLM", DbType.String);
            db.AddInParameter(cmdProc, "@SFWBURL", DbType.String);
            db.AddInParameter(cmdProc, "@WBURL", DbType.String);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@LMH", AppData.LMH);
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@LMM", AppData.LMM);
            db.SetParameterValue(cmdProc, "@SJLMH", AppData.SJLMH);
            db.SetParameterValue(cmdProc, "@LMTP", AppData.LMTP);
            db.SetParameterValue(cmdProc, "@LMNR", AppData.LMNR);
            db.SetParameterValue(cmdProc, "@LMLBYS", AppData.LMLBYS);
            db.SetParameterValue(cmdProc, "@SFLBLM", AppData.SFLBLM);
            db.SetParameterValue(cmdProc, "@SFWBURL", AppData.SFWBURL);
            db.SetParameterValue(cmdProc, "@WBURL", AppData.WBURL);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : UpdateByObjectIDBatch
        /// <summary>
        /// ��ObjectIDΪ�����������¼�¼
        /// </summary>
        //=====================================================================
        public override void UpdateByObjectIDBatch()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateT_BG_0602ByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@LMH", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@LMM", DbType.String);
            db.AddInParameter(cmdProc, "@SJLMH", DbType.String);
            db.AddInParameter(cmdProc, "@LMTP", DbType.String);
            db.AddInParameter(cmdProc, "@LMNR", DbType.String);
            db.AddInParameter(cmdProc, "@LMLBYS", DbType.String);
            db.AddInParameter(cmdProc, "@SFLBLM", DbType.String);
            db.AddInParameter(cmdProc, "@SFWBURL", DbType.String);
            db.AddInParameter(cmdProc, "@WBURL", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@LMH", AppData.LMH);
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@LMM", AppData.LMM);
            db.SetParameterValue(cmdProc, "@SJLMH", AppData.SJLMH);
            db.SetParameterValue(cmdProc, "@LMTP", AppData.LMTP);
            db.SetParameterValue(cmdProc, "@LMNR", AppData.LMNR);
            db.SetParameterValue(cmdProc, "@LMLBYS", AppData.LMLBYS);
            db.SetParameterValue(cmdProc, "@SFLBLM", AppData.SFLBLM);
            db.SetParameterValue(cmdProc, "@SFWBURL", AppData.SFWBURL);
            db.SetParameterValue(cmdProc, "@WBURL", AppData.WBURL);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : SelectByKey
        /// <summary>
        /// ������Ϊ������ѯ��¼
        /// </summary>
        //=====================================================================
        public override void SelectByKey()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BG_0602ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@LMH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@LMH", AppData.LMH);
            // ִ�д洢����
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // �õ����ؼ�¼��
            AppData.RecordCount = AppData.ResultSet.Tables[0].Rows.Count;
        }

        //=====================================================================
        //  FunctionName : SelectByObjectID
        /// <summary>
        /// ��ObjectIDΪ������ѯ��¼
        /// </summary>
        //=====================================================================
        public override void SelectByObjectID()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BG_0602ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // ִ�д洢����
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // �õ����ؼ�¼��
            AppData.RecordCount = AppData.ResultSet.Tables[0].Rows.Count;
        }
        
        //=====================================================================
        //  FunctionName : GetDataByObjectID
        /// <summary>
        /// ��ObjectIDΪ������ѯ��¼������AppData
        /// </summary>
        //=====================================================================
        public static T_BG_0602ApplicationData GetDataByObjectID(string strObjectID)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BG_0602ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // ִ�д洢����
            return T_BG_0602ApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// ��KeyΪ������ѯ��¼������AppData
        /// </summary>
        //=====================================================================
        public static T_BG_0602ApplicationData GetDataByKey(T_BG_0602ApplicationData appData)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BG_0602ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@LMH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@LMH", appData.LMH);
            // ִ�д洢����
            return T_BG_0602ApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
		
        //=====================================================================
        //  FunctionName : SelectByAnyCondition
        /// <summary>
        /// ������������ѯ��¼
        /// </summary>
        //=====================================================================
        public override void SelectByAnyCondition()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BG_0602ByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@QueryField", DbType.String);
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
            db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
            // ����
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LMH", DbType.String);
            db.AddInParameter(cmdProc, "@LMHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
            db.AddInParameter(cmdProc, "@LanguageIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LMM", DbType.String);
            db.AddInParameter(cmdProc, "@LMMBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SJLMH", DbType.String);
            db.AddInParameter(cmdProc, "@SJLMHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LMTP", DbType.String);
            db.AddInParameter(cmdProc, "@LMTPBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LMNR", DbType.String);
            db.AddInParameter(cmdProc, "@LMNRBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LMLBYS", DbType.String);
            db.AddInParameter(cmdProc, "@LMLBYSBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SFLBLM", DbType.String);
            db.AddInParameter(cmdProc, "@SFLBLMBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SFWBURL", DbType.String);
            db.AddInParameter(cmdProc, "@SFWBURLBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@WBURL", DbType.String);
            db.AddInParameter(cmdProc, "@WBURLBatch", DbType.String);
                
            // һ��һ��ر�
            
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
        
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@QueryField", AppData.QueryField);
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@Sort", AppData.Sort);
            db.SetParameterValue(cmdProc, "@SortField", AppData.SortField);
            db.SetParameterValue(cmdProc, "@PageSize", AppData.PageSize);
            db.SetParameterValue(cmdProc, "@CurrentPage", AppData.CurrentPage);
            // ����
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
                
            db.SetParameterValue(cmdProc, "@LMH", AppData.LMH);
            db.SetParameterValue(cmdProc, "@LMHBatch", AppData.LMHBatch);
                
            db.SetParameterValue(cmdProc, "@LanguageID", AppData.LanguageID);
            db.SetParameterValue(cmdProc, "@LanguageIDBatch", AppData.LanguageIDBatch);
                
            db.SetParameterValue(cmdProc, "@LMM", AppData.LMM);
            db.SetParameterValue(cmdProc, "@LMMBatch", AppData.LMMBatch);
                
            db.SetParameterValue(cmdProc, "@SJLMH", AppData.SJLMH);
            db.SetParameterValue(cmdProc, "@SJLMHBatch", AppData.SJLMHBatch);
                
            db.SetParameterValue(cmdProc, "@LMTP", AppData.LMTP);
            db.SetParameterValue(cmdProc, "@LMTPBatch", AppData.LMTPBatch);
                
            db.SetParameterValue(cmdProc, "@LMNR", AppData.LMNR);
            db.SetParameterValue(cmdProc, "@LMNRBatch", AppData.LMNRBatch);
                
            db.SetParameterValue(cmdProc, "@LMLBYS", AppData.LMLBYS);
            db.SetParameterValue(cmdProc, "@LMLBYSBatch", AppData.LMLBYSBatch);
                
            db.SetParameterValue(cmdProc, "@SFLBLM", AppData.SFLBLM);
            db.SetParameterValue(cmdProc, "@SFLBLMBatch", AppData.SFLBLMBatch);
                
            db.SetParameterValue(cmdProc, "@SFWBURL", AppData.SFWBURL);
            db.SetParameterValue(cmdProc, "@SFWBURLBatch", AppData.SFWBURLBatch);
                
            db.SetParameterValue(cmdProc, "@WBURL", AppData.WBURL);
            db.SetParameterValue(cmdProc, "@WBURLBatch", AppData.WBURLBatch);
                
            // һ��һ��ر�
            
            // ִ�д洢����
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // �õ����ؼ�¼��
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        
        }

        //=====================================================================
        //  FunctionName : DeleteByKey
        /// <summary>
        /// ������Ϊ����ɾ����¼
        /// </summary>
        //=====================================================================
        public override void DeleteByKey()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_BG_0602ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@LMH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@LMH", AppData.LMH);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : DeleteByObjectID
        /// <summary>
        /// ��ObjectIDΪ����ɾ����¼
        /// </summary>
        //=====================================================================
        public override void DeleteByObjectID()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_BG_0602ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : DeleteByObjectIDBatch
        /// <summary>
        /// ��ObjectIDΪ��������ɾ����¼
        /// </summary>
        //=====================================================================
        public override void DeleteByObjectIDBatch()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteT_BG_0602ByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : IsExistByKey
        /// <summary>
        /// ������Ϊ�����жϼ�¼�Ƿ����
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByKey()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistT_BG_0602ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@LMH", DbType.String);
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@LMH", AppData.LMH);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
            // �õ����ؼ�¼��
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
        /// ��ObjectIDΪ�����жϼ�¼�Ƿ����
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByObjectID()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistT_BG_0602ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // ִ�д洢����
            db.ExecuteNonQuery(cmdProc);
            // �õ����ؼ�¼��
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
        /// ��ָ��������ѯָ���ֶ�
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
                    // �������ݿ����� 
                    Database db = DatabaseFactory.CreateDatabase("strConnManager");
                    string strProcName = "SP_SelectT_BG_0602ByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // �趨�洢�����������
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@LMH", DbType.String);
                    db.AddInParameter(cmdProc, "@LanguageID", DbType.String);
                    db.AddInParameter(cmdProc, "@LMM", DbType.String);
                    db.AddInParameter(cmdProc, "@SJLMH", DbType.String);
                    db.AddInParameter(cmdProc, "@LMTP", DbType.String);
                    db.AddInParameter(cmdProc, "@LMNR", DbType.String);
                    db.AddInParameter(cmdProc, "@LMLBYS", DbType.String);
                    db.AddInParameter(cmdProc, "@SFLBLM", DbType.String);
                    db.AddInParameter(cmdProc, "@SFWBURL", DbType.String);
                    db.AddInParameter(cmdProc, "@WBURL", DbType.String);
                    // �趨�洢�����������
                    db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
                
                    // �Դ洢���̲�����ֵ
                    db.SetParameterValue(cmdProc, "@" + strConditionField, strValue);
                    if (!strFixConditionField.IsNullOrWhiteSpace())
                    {
                        if (strFixConditionField != "null")
                        {
                            db.SetParameterValue(cmdProc, "@" + strFixConditionField, strFixConditionValue);
                        }
                    }
                    // ִ�д洢����
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
        /// �õ�ָ���ֶε����ֵ
        /// </summary>
        //=====================================================================
        public override object GetMaxValue(string strPrefix)
        {
            return null;
        }
        public object GetMaxValue(string strPrefix, int intNumber)
        {
            object objReturn = new object();
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetMaxT_BG_0602ByLMH";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@Prefix", DbType.String);
            db.AddInParameter(cmdProc, "@Number", DbType.Int32, 4);
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@MaxValue", DbType.String, 100);
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@Prefix", strPrefix);
            db.SetParameterValue(cmdProc, "@Number", intNumber);
            // ִ�д洢����
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
        /// ����������ͳ��ָ���ֶ�
        /// </summary>
        //=====================================================================
        public override void CountByAnyCondition()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_CountT_BG_0602ByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@CountField", DbType.String);
            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            // ���� 
            
            // һ��һ��ر�
            
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@CountField", AppData.CountField);
            db.SetParameterValue(cmdProc, "@Sort", AppData.Sort);
            db.SetParameterValue(cmdProc, "@SortField", AppData.SortField);
            // ����
            
            // һ��һ��ر�
            
            // ִ�д洢����
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // �õ����ؼ�¼��
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        }
        

        public static DataSet GetTreeData_T_BG_0602_SJLMH(string iDFieldName, string nameFieldName, string parentFieldValue = null, string conditionFieldName = null, string conditionFieldValue = null, bool onlyShowUsed = false)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetTreeData_T_BG_0602_SJLMH";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
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
            // ִ�д洢����
            DataSet ds = db.ExecuteDataSet(cmdProc);
            return ds;
        }
	
        #endregion
    }
}
  
