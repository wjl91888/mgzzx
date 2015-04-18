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
    /// T_PM_PurviewInfo���߼�ʵ����
    /// </summary>
    //=========================================================================
    public class T_PM_PurviewInfoBusinessEntityBase : BusinessEntityBase
    {
        #region ����ʵ��
        /// <summary>
        /// AppData
        /// </summary>
        private T_PM_PurviewInfoApplicationData m_AppData;

        /// <summary>
        /// ȡ���趨AppData
        /// </summary>
        /// <value>AppData</value>
        public T_PM_PurviewInfoApplicationData AppData
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
            string strProcName = "SP_InsertT_PM_PurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            string strProcName = "SP_UpdateT_PM_PurviewInfoByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
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
                
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
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
            string strProcName = "SP_UpdateT_PM_PurviewInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            string strProcName = "SP_UpdateT_PM_PurviewInfoByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            string strProcName = "SP_UpdateT_PM_PurviewInfoByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
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
            // �Դ洢���̲�����ֵ
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
            string strProcName = "SP_SelectT_PM_PurviewInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
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
            string strProcName = "SP_SelectT_PM_PurviewInfoByObjectID";
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
        public static T_PM_PurviewInfoApplicationData GetDataByObjectID(string strObjectID)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_PM_PurviewInfoByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // ִ�д洢����
            return T_PM_PurviewInfoApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// ��KeyΪ������ѯ��¼������AppData
        /// </summary>
        //=====================================================================
        public static T_PM_PurviewInfoApplicationData GetDataByKey(T_PM_PurviewInfoApplicationData appData)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_PM_PurviewInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@PurviewID", appData.PurviewID);
            // ִ�д洢����
            return T_PM_PurviewInfoApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectT_PM_PurviewInfoByAnyCondition";
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
            string strProcName = "SP_DeleteT_PM_PurviewInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
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
            string strProcName = "SP_DeleteT_PM_PurviewInfoByObjectID";
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
            string strProcName = "SP_DeleteT_PM_PurviewInfoByObjectIDBatch";
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
            string strProcName = "SP_IsExistT_PM_PurviewInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@PurviewID", AppData.PurviewID);
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
            string strProcName = "SP_IsExistT_PM_PurviewInfoByObjectID";
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
                    string strProcName = "SP_SelectT_PM_PurviewInfoByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // �趨�洢�����������
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
            string strProcName = "SP_GetMaxT_PM_PurviewInfoBy";
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
            string strProcName = "SP_CountT_PM_PurviewInfoByAnyCondition";
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
  
