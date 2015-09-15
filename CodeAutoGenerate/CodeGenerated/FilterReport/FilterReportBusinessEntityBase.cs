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
    /// FilterReport���߼�ʵ����
    /// </summary>
    //=========================================================================
    public class FilterReportBusinessEntityBase : BusinessEntityBase
    {
        #region ����ʵ��
        /// <summary>
        /// AppData
        /// </summary>
        private FilterReportApplicationData m_AppData;

        /// <summary>
        /// ȡ���趨AppData
        /// </summary>
        /// <value>AppData</value>
        public FilterReportApplicationData AppData
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
            string strProcName = "SP_InsertFilterReport";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BGMC", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@BGLX", DbType.String);
            db.AddInParameter(cmdProc, "@GXBG", DbType.String);
            db.AddInParameter(cmdProc, "@XTBG", DbType.String);
            db.AddInParameter(cmdProc, "@BGCXTJ", DbType.String);
            db.AddInParameter(cmdProc, "@BGCJSJ", DbType.DateTime);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BGMC", AppData.BGMC);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@BGLX", AppData.BGLX);
            db.SetParameterValue(cmdProc, "@GXBG", AppData.GXBG);
            db.SetParameterValue(cmdProc, "@XTBG", AppData.XTBG);
            db.SetParameterValue(cmdProc, "@BGCXTJ", AppData.BGCXTJ);
            db.SetParameterValue(cmdProc, "@BGCJSJ", AppData.BGCJSJ);
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
            string strProcName = "SP_UpdateFilterReportByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
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
                
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
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
            string strProcName = "SP_UpdateFilterReportByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BGMC", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@BGLX", DbType.String);
            db.AddInParameter(cmdProc, "@GXBG", DbType.String);
            db.AddInParameter(cmdProc, "@XTBG", DbType.String);
            db.AddInParameter(cmdProc, "@BGCXTJ", DbType.String);
            db.AddInParameter(cmdProc, "@BGCJSJ", DbType.DateTime);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BGMC", AppData.BGMC);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@BGLX", AppData.BGLX);
            db.SetParameterValue(cmdProc, "@GXBG", AppData.GXBG);
            db.SetParameterValue(cmdProc, "@XTBG", AppData.XTBG);
            db.SetParameterValue(cmdProc, "@BGCXTJ", AppData.BGCXTJ);
            db.SetParameterValue(cmdProc, "@BGCJSJ", AppData.BGCJSJ);
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
            string strProcName = "SP_UpdateFilterReportByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BGMC", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@BGLX", DbType.String);
            db.AddInParameter(cmdProc, "@GXBG", DbType.String);
            db.AddInParameter(cmdProc, "@XTBG", DbType.String);
            db.AddInParameter(cmdProc, "@BGCXTJ", DbType.String);
            db.AddInParameter(cmdProc, "@BGCJSJ", DbType.DateTime);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BGMC", AppData.BGMC);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@BGLX", AppData.BGLX);
            db.SetParameterValue(cmdProc, "@GXBG", AppData.GXBG);
            db.SetParameterValue(cmdProc, "@XTBG", AppData.XTBG);
            db.SetParameterValue(cmdProc, "@BGCXTJ", AppData.BGCXTJ);
            db.SetParameterValue(cmdProc, "@BGCJSJ", AppData.BGCJSJ);
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
            string strProcName = "SP_UpdateFilterReportByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@BGMC", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@BGLX", DbType.String);
            db.AddInParameter(cmdProc, "@GXBG", DbType.String);
            db.AddInParameter(cmdProc, "@XTBG", DbType.String);
            db.AddInParameter(cmdProc, "@BGCXTJ", DbType.String);
            db.AddInParameter(cmdProc, "@BGCJSJ", DbType.DateTime);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@BGMC", AppData.BGMC);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@BGLX", AppData.BGLX);
            db.SetParameterValue(cmdProc, "@GXBG", AppData.GXBG);
            db.SetParameterValue(cmdProc, "@XTBG", AppData.XTBG);
            db.SetParameterValue(cmdProc, "@BGCXTJ", AppData.BGCXTJ);
            db.SetParameterValue(cmdProc, "@BGCJSJ", AppData.BGCJSJ);
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
            string strProcName = "SP_SelectFilterReportByKey";
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
        //  FunctionName : SelectByObjectID
        /// <summary>
        /// ��ObjectIDΪ������ѯ��¼
        /// </summary>
        //=====================================================================
        public override void SelectByObjectID()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectFilterReportByObjectID";
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
        public static FilterReportApplicationData GetDataByObjectID(string strObjectID)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectFilterReportByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // ִ�д洢����
            return FilterReportApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// ��KeyΪ������ѯ��¼������AppData
        /// </summary>
        //=====================================================================
        public static FilterReportApplicationData GetDataByKey(FilterReportApplicationData appData)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectFilterReportByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@ObjectID", appData.ObjectID);
            // ִ�д洢����
            return FilterReportApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectFilterReportByAnyCondition";
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
            string strProcName = "SP_DeleteFilterReportByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
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
            string strProcName = "SP_DeleteFilterReportByObjectID";
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
            string strProcName = "SP_DeleteFilterReportByObjectIDBatch";
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
            string strProcName = "SP_IsExistFilterReportByKey";
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
        //  FunctionName : IsExistByObjectID
        /// <summary>
        /// ��ObjectIDΪ�����жϼ�¼�Ƿ����
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByObjectID()
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistFilterReportByObjectID";
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
                    string strProcName = "SP_SelectFilterReportByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // �趨�洢�����������
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
            string strProcName = "SP_GetMaxFilterReportBy";
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
            string strProcName = "SP_CountFilterReportByAnyCondition";
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
        

        #endregion
    }
}
  
