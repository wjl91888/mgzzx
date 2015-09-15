/****************************************************** 
FileName:T_PM_UserGroupInfoBusinessEntityBase.cs
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

namespace  RICH.Common.BM.T_PM_UserGroupInfo
{
    //=========================================================================
    //  ClassName : T_PM_UserGroupInfoBusinessEntityBase
    /// <summary>
    /// T_PM_UserGroupInfo���߼�ʵ����
    /// </summary>
    //=========================================================================
    public class T_PM_UserGroupInfoBusinessEntityBase : BusinessEntityBase
    {
        #region ����ʵ��
        /// <summary>
        /// AppData
        /// </summary>
        private T_PM_UserGroupInfoApplicationData m_AppData;

        /// <summary>
        /// ȡ���趨AppData
        /// </summary>
        /// <value>AppData</value>
        public T_PM_UserGroupInfoApplicationData AppData
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
            string strProcName = "SP_InsertT_PM_UserGroupInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupName", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupContent", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupRemark", DbType.String);
            db.AddInParameter(cmdProc, "@DefaultPage", DbType.String);
            db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@UserGroupName", AppData.UserGroupName);
            db.SetParameterValue(cmdProc, "@UserGroupContent", AppData.UserGroupContent);
            db.SetParameterValue(cmdProc, "@UserGroupRemark", AppData.UserGroupRemark);
            db.SetParameterValue(cmdProc, "@DefaultPage", AppData.DefaultPage);
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
            string strProcName = "SP_UpdateT_PM_UserGroupInfoByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserGroupName", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupNameBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupNameValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserGroupContent", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupContentBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupContentValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserGroupRemark", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupRemarkBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupRemarkValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@DefaultPage", DbType.String);
            db.AddInParameter(cmdProc, "@DefaultPageBatch", DbType.String);
            db.AddInParameter(cmdProc, "@DefaultPageValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
            db.AddInParameter(cmdProc, "@UpdateDateBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UpdateDateValue", DbType.DateTime);
                
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@QueryKeywords", AppData.QueryKeywords);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@UserGroupIDBatch", AppData.UserGroupIDBatch);
            db.SetParameterValue(cmdProc, "@UserGroupIDValue", AppData.UserGroupIDValue);
                
            db.SetParameterValue(cmdProc, "@UserGroupName", AppData.UserGroupName);
            db.SetParameterValue(cmdProc, "@UserGroupNameBatch", AppData.UserGroupNameBatch);
            db.SetParameterValue(cmdProc, "@UserGroupNameValue", AppData.UserGroupNameValue);
                
            db.SetParameterValue(cmdProc, "@UserGroupContent", AppData.UserGroupContent);
            db.SetParameterValue(cmdProc, "@UserGroupContentBatch", AppData.UserGroupContentBatch);
            db.SetParameterValue(cmdProc, "@UserGroupContentValue", AppData.UserGroupContentValue);
                
            db.SetParameterValue(cmdProc, "@UserGroupRemark", AppData.UserGroupRemark);
            db.SetParameterValue(cmdProc, "@UserGroupRemarkBatch", AppData.UserGroupRemarkBatch);
            db.SetParameterValue(cmdProc, "@UserGroupRemarkValue", AppData.UserGroupRemarkValue);
                
            db.SetParameterValue(cmdProc, "@DefaultPage", AppData.DefaultPage);
            db.SetParameterValue(cmdProc, "@DefaultPageBatch", AppData.DefaultPageBatch);
            db.SetParameterValue(cmdProc, "@DefaultPageValue", AppData.DefaultPageValue);
                
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
            string strProcName = "SP_UpdateT_PM_UserGroupInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupName", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupContent", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupRemark", DbType.String);
            db.AddInParameter(cmdProc, "@DefaultPage", DbType.String);
            db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@UserGroupName", AppData.UserGroupName);
            db.SetParameterValue(cmdProc, "@UserGroupContent", AppData.UserGroupContent);
            db.SetParameterValue(cmdProc, "@UserGroupRemark", AppData.UserGroupRemark);
            db.SetParameterValue(cmdProc, "@DefaultPage", AppData.DefaultPage);
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
            string strProcName = "SP_UpdateT_PM_UserGroupInfoByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupName", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupContent", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupRemark", DbType.String);
            db.AddInParameter(cmdProc, "@DefaultPage", DbType.String);
            db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@UserGroupName", AppData.UserGroupName);
            db.SetParameterValue(cmdProc, "@UserGroupContent", AppData.UserGroupContent);
            db.SetParameterValue(cmdProc, "@UserGroupRemark", AppData.UserGroupRemark);
            db.SetParameterValue(cmdProc, "@DefaultPage", AppData.DefaultPage);
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
            string strProcName = "SP_UpdateT_PM_UserGroupInfoByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupName", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupContent", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupRemark", DbType.String);
            db.AddInParameter(cmdProc, "@DefaultPage", DbType.String);
            db.AddInParameter(cmdProc, "@UpdateDate", DbType.DateTime);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@UserGroupName", AppData.UserGroupName);
            db.SetParameterValue(cmdProc, "@UserGroupContent", AppData.UserGroupContent);
            db.SetParameterValue(cmdProc, "@UserGroupRemark", AppData.UserGroupRemark);
            db.SetParameterValue(cmdProc, "@DefaultPage", AppData.DefaultPage);
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
            string strProcName = "SP_SelectT_PM_UserGroupInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
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
            string strProcName = "SP_SelectT_PM_UserGroupInfoByObjectID";
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
        public static T_PM_UserGroupInfoApplicationData GetDataByObjectID(string strObjectID)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_PM_UserGroupInfoByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // ִ�д洢����
            return T_PM_UserGroupInfoApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// ��KeyΪ������ѯ��¼������AppData
        /// </summary>
        //=====================================================================
        public static T_PM_UserGroupInfoApplicationData GetDataByKey(T_PM_UserGroupInfoApplicationData appData)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_PM_UserGroupInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@UserGroupID", appData.UserGroupID);
            // ִ�д洢����
            return T_PM_UserGroupInfoApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectT_PM_UserGroupInfoByAnyCondition";
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
                
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserGroupName", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupNameBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserGroupContent", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupContentBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserGroupRemark", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupRemarkBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@DefaultPage", DbType.String);
            db.AddInParameter(cmdProc, "@DefaultPageBatch", DbType.String);
                
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
                
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@UserGroupIDBatch", AppData.UserGroupIDBatch);
                
            db.SetParameterValue(cmdProc, "@UserGroupName", AppData.UserGroupName);
            db.SetParameterValue(cmdProc, "@UserGroupNameBatch", AppData.UserGroupNameBatch);
                
            db.SetParameterValue(cmdProc, "@UserGroupContent", AppData.UserGroupContent);
            db.SetParameterValue(cmdProc, "@UserGroupContentBatch", AppData.UserGroupContentBatch);
                
            db.SetParameterValue(cmdProc, "@UserGroupRemark", AppData.UserGroupRemark);
            db.SetParameterValue(cmdProc, "@UserGroupRemarkBatch", AppData.UserGroupRemarkBatch);
                
            db.SetParameterValue(cmdProc, "@DefaultPage", AppData.DefaultPage);
            db.SetParameterValue(cmdProc, "@DefaultPageBatch", AppData.DefaultPageBatch);
                
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
            string strProcName = "SP_DeleteT_PM_UserGroupInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
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
            string strProcName = "SP_DeleteT_PM_UserGroupInfoByObjectID";
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
            string strProcName = "SP_DeleteT_PM_UserGroupInfoByObjectIDBatch";
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
            string strProcName = "SP_IsExistT_PM_UserGroupInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
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
            string strProcName = "SP_IsExistT_PM_UserGroupInfoByObjectID";
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
                    string strProcName = "SP_SelectT_PM_UserGroupInfoByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // �趨�洢�����������
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
                    db.AddInParameter(cmdProc, "@UserGroupName", DbType.String);
                    db.AddInParameter(cmdProc, "@UserGroupContent", DbType.String);
                    db.AddInParameter(cmdProc, "@UserGroupRemark", DbType.String);
                    db.AddInParameter(cmdProc, "@DefaultPage", DbType.String);
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
            string strProcName = "SP_GetMaxT_PM_UserGroupInfoBy";
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
            string strProcName = "SP_CountT_PM_UserGroupInfoByAnyCondition";
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
  
