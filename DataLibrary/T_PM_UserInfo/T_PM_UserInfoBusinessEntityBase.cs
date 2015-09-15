/****************************************************** 
FileName:T_PM_UserInfoBusinessEntityBase.cs
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

namespace  RICH.Common.BM.T_PM_UserInfo
{
    //=========================================================================
    //  ClassName : T_PM_UserInfoBusinessEntityBase
    /// <summary>
    /// T_PM_UserInfo���߼�ʵ����
    /// </summary>
    //=========================================================================
    public class T_PM_UserInfoBusinessEntityBase : BusinessEntityBase
    {
        #region ����ʵ��
        /// <summary>
        /// AppData
        /// </summary>
        private T_PM_UserInfoApplicationData m_AppData;

        /// <summary>
        /// ȡ���趨AppData
        /// </summary>
        /// <value>AppData</value>
        public T_PM_UserInfoApplicationData AppData
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
            string strProcName = "SP_InsertT_PM_UserInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@UserLoginName", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@SubjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserNickName", DbType.String);
            db.AddInParameter(cmdProc, "@Password", DbType.String);
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@MZ", DbType.String);
            db.AddInParameter(cmdProc, "@ZZMM", DbType.String);
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@SJH", DbType.String);
            db.AddInParameter(cmdProc, "@BGDH", DbType.String);
            db.AddInParameter(cmdProc, "@JTDH", DbType.String);
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@QQH", DbType.String);
            db.AddInParameter(cmdProc, "@LoginTime", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LastLoginIP", DbType.String);
            db.AddInParameter(cmdProc, "@LastLoginDate", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LoginTimes", DbType.Int32);
            db.AddInParameter(cmdProc, "@UserStatus", DbType.String);
            db.AddInParameter(cmdProc, "@vcode", DbType.String);
            db.AddInParameter(cmdProc, "@lcode", DbType.String);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@UserLoginName", AppData.UserLoginName);
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@SubjectID", AppData.SubjectID);
            db.SetParameterValue(cmdProc, "@UserNickName", AppData.UserNickName);
            db.SetParameterValue(cmdProc, "@Password", AppData.Password);
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@MZ", AppData.MZ);
            db.SetParameterValue(cmdProc, "@ZZMM", AppData.ZZMM);
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@SJH", AppData.SJH);
            db.SetParameterValue(cmdProc, "@BGDH", AppData.BGDH);
            db.SetParameterValue(cmdProc, "@JTDH", AppData.JTDH);
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@QQH", AppData.QQH);
            db.SetParameterValue(cmdProc, "@LoginTime", AppData.LoginTime);
            db.SetParameterValue(cmdProc, "@LastLoginIP", AppData.LastLoginIP);
            db.SetParameterValue(cmdProc, "@LastLoginDate", AppData.LastLoginDate);
            db.SetParameterValue(cmdProc, "@LoginTimes", AppData.LoginTimes);
            db.SetParameterValue(cmdProc, "@UserStatus", AppData.UserStatus);
            db.SetParameterValue(cmdProc, "@vcode", AppData.vcode);
            db.SetParameterValue(cmdProc, "@lcode", AppData.lcode);
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
            string strProcName = "SP_UpdateT_PM_UserInfoByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ObjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@UserIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UserIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserLoginName", DbType.String);
            db.AddInParameter(cmdProc, "@UserLoginNameBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UserLoginNameValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@SubjectID", DbType.String);
            db.AddInParameter(cmdProc, "@SubjectIDBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SubjectIDValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserNickName", DbType.String);
            db.AddInParameter(cmdProc, "@UserNickNameBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UserNickNameValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@Password", DbType.String);
            db.AddInParameter(cmdProc, "@PasswordBatch", DbType.String);
            db.AddInParameter(cmdProc, "@PasswordValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@XBBatch", DbType.String);
            db.AddInParameter(cmdProc, "@XBValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@MZ", DbType.String);
            db.AddInParameter(cmdProc, "@MZBatch", DbType.String);
            db.AddInParameter(cmdProc, "@MZValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@ZZMM", DbType.String);
            db.AddInParameter(cmdProc, "@ZZMMBatch", DbType.String);
            db.AddInParameter(cmdProc, "@ZZMMValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@SFZHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SFZHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@SJH", DbType.String);
            db.AddInParameter(cmdProc, "@SJHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@SJHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@BGDH", DbType.String);
            db.AddInParameter(cmdProc, "@BGDHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@BGDHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@JTDH", DbType.String);
            db.AddInParameter(cmdProc, "@JTDHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@JTDHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@EmailBatch", DbType.String);
            db.AddInParameter(cmdProc, "@EmailValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@QQH", DbType.String);
            db.AddInParameter(cmdProc, "@QQHBatch", DbType.String);
            db.AddInParameter(cmdProc, "@QQHValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LoginTime", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LoginTimeBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LoginTimeValue", DbType.DateTime);
                
            db.AddInParameter(cmdProc, "@LastLoginIP", DbType.String);
            db.AddInParameter(cmdProc, "@LastLoginIPBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LastLoginIPValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@LastLoginDate", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LastLoginDateBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LastLoginDateValue", DbType.DateTime);
                
            db.AddInParameter(cmdProc, "@LoginTimes", DbType.Int32);
            db.AddInParameter(cmdProc, "@LoginTimesBatch", DbType.String);
            db.AddInParameter(cmdProc, "@LoginTimesValue", DbType.Int32);
                
            db.AddInParameter(cmdProc, "@UserStatus", DbType.String);
            db.AddInParameter(cmdProc, "@UserStatusBatch", DbType.String);
            db.AddInParameter(cmdProc, "@UserStatusValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@vcode", DbType.String);
            db.AddInParameter(cmdProc, "@vcodeBatch", DbType.String);
            db.AddInParameter(cmdProc, "@vcodeValue", DbType.String);
                
            db.AddInParameter(cmdProc, "@lcode", DbType.String);
            db.AddInParameter(cmdProc, "@lcodeBatch", DbType.String);
            db.AddInParameter(cmdProc, "@lcodeValue", DbType.String);
                
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@QueryKeywords", AppData.QueryKeywords);
            
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            db.SetParameterValue(cmdProc, "@ObjectIDValue", AppData.ObjectIDValue);
                
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@UserIDBatch", AppData.UserIDBatch);
            db.SetParameterValue(cmdProc, "@UserIDValue", AppData.UserIDValue);
                
            db.SetParameterValue(cmdProc, "@UserLoginName", AppData.UserLoginName);
            db.SetParameterValue(cmdProc, "@UserLoginNameBatch", AppData.UserLoginNameBatch);
            db.SetParameterValue(cmdProc, "@UserLoginNameValue", AppData.UserLoginNameValue);
                
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@UserGroupIDBatch", AppData.UserGroupIDBatch);
            db.SetParameterValue(cmdProc, "@UserGroupIDValue", AppData.UserGroupIDValue);
                
            db.SetParameterValue(cmdProc, "@SubjectID", AppData.SubjectID);
            db.SetParameterValue(cmdProc, "@SubjectIDBatch", AppData.SubjectIDBatch);
            db.SetParameterValue(cmdProc, "@SubjectIDValue", AppData.SubjectIDValue);
                
            db.SetParameterValue(cmdProc, "@UserNickName", AppData.UserNickName);
            db.SetParameterValue(cmdProc, "@UserNickNameBatch", AppData.UserNickNameBatch);
            db.SetParameterValue(cmdProc, "@UserNickNameValue", AppData.UserNickNameValue);
                
            db.SetParameterValue(cmdProc, "@Password", AppData.Password);
            db.SetParameterValue(cmdProc, "@PasswordBatch", AppData.PasswordBatch);
            db.SetParameterValue(cmdProc, "@PasswordValue", AppData.PasswordValue);
                
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@XBBatch", AppData.XBBatch);
            db.SetParameterValue(cmdProc, "@XBValue", AppData.XBValue);
                
            db.SetParameterValue(cmdProc, "@MZ", AppData.MZ);
            db.SetParameterValue(cmdProc, "@MZBatch", AppData.MZBatch);
            db.SetParameterValue(cmdProc, "@MZValue", AppData.MZValue);
                
            db.SetParameterValue(cmdProc, "@ZZMM", AppData.ZZMM);
            db.SetParameterValue(cmdProc, "@ZZMMBatch", AppData.ZZMMBatch);
            db.SetParameterValue(cmdProc, "@ZZMMValue", AppData.ZZMMValue);
                
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@SFZHBatch", AppData.SFZHBatch);
            db.SetParameterValue(cmdProc, "@SFZHValue", AppData.SFZHValue);
                
            db.SetParameterValue(cmdProc, "@SJH", AppData.SJH);
            db.SetParameterValue(cmdProc, "@SJHBatch", AppData.SJHBatch);
            db.SetParameterValue(cmdProc, "@SJHValue", AppData.SJHValue);
                
            db.SetParameterValue(cmdProc, "@BGDH", AppData.BGDH);
            db.SetParameterValue(cmdProc, "@BGDHBatch", AppData.BGDHBatch);
            db.SetParameterValue(cmdProc, "@BGDHValue", AppData.BGDHValue);
                
            db.SetParameterValue(cmdProc, "@JTDH", AppData.JTDH);
            db.SetParameterValue(cmdProc, "@JTDHBatch", AppData.JTDHBatch);
            db.SetParameterValue(cmdProc, "@JTDHValue", AppData.JTDHValue);
                
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@EmailBatch", AppData.EmailBatch);
            db.SetParameterValue(cmdProc, "@EmailValue", AppData.EmailValue);
                
            db.SetParameterValue(cmdProc, "@QQH", AppData.QQH);
            db.SetParameterValue(cmdProc, "@QQHBatch", AppData.QQHBatch);
            db.SetParameterValue(cmdProc, "@QQHValue", AppData.QQHValue);
                
            db.SetParameterValue(cmdProc, "@LoginTime", AppData.LoginTime);
            db.SetParameterValue(cmdProc, "@LoginTimeBatch", AppData.LoginTimeBatch);
            db.SetParameterValue(cmdProc, "@LoginTimeValue", AppData.LoginTimeValue);
                
            db.SetParameterValue(cmdProc, "@LastLoginIP", AppData.LastLoginIP);
            db.SetParameterValue(cmdProc, "@LastLoginIPBatch", AppData.LastLoginIPBatch);
            db.SetParameterValue(cmdProc, "@LastLoginIPValue", AppData.LastLoginIPValue);
                
            db.SetParameterValue(cmdProc, "@LastLoginDate", AppData.LastLoginDate);
            db.SetParameterValue(cmdProc, "@LastLoginDateBatch", AppData.LastLoginDateBatch);
            db.SetParameterValue(cmdProc, "@LastLoginDateValue", AppData.LastLoginDateValue);
                
            db.SetParameterValue(cmdProc, "@LoginTimes", AppData.LoginTimes);
            db.SetParameterValue(cmdProc, "@LoginTimesBatch", AppData.LoginTimesBatch);
            db.SetParameterValue(cmdProc, "@LoginTimesValue", AppData.LoginTimesValue);
                
            db.SetParameterValue(cmdProc, "@UserStatus", AppData.UserStatus);
            db.SetParameterValue(cmdProc, "@UserStatusBatch", AppData.UserStatusBatch);
            db.SetParameterValue(cmdProc, "@UserStatusValue", AppData.UserStatusValue);
                
            db.SetParameterValue(cmdProc, "@vcode", AppData.vcode);
            db.SetParameterValue(cmdProc, "@vcodeBatch", AppData.vcodeBatch);
            db.SetParameterValue(cmdProc, "@vcodeValue", AppData.vcodeValue);
                
            db.SetParameterValue(cmdProc, "@lcode", AppData.lcode);
            db.SetParameterValue(cmdProc, "@lcodeBatch", AppData.lcodeBatch);
            db.SetParameterValue(cmdProc, "@lcodeValue", AppData.lcodeValue);
                
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
            string strProcName = "SP_UpdateT_PM_UserInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@UserLoginName", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@SubjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserNickName", DbType.String);
            db.AddInParameter(cmdProc, "@Password", DbType.String);
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@MZ", DbType.String);
            db.AddInParameter(cmdProc, "@ZZMM", DbType.String);
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@SJH", DbType.String);
            db.AddInParameter(cmdProc, "@BGDH", DbType.String);
            db.AddInParameter(cmdProc, "@JTDH", DbType.String);
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@QQH", DbType.String);
            db.AddInParameter(cmdProc, "@LoginTime", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LastLoginIP", DbType.String);
            db.AddInParameter(cmdProc, "@LastLoginDate", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LoginTimes", DbType.Int32);
            db.AddInParameter(cmdProc, "@UserStatus", DbType.String);
            db.AddInParameter(cmdProc, "@vcode", DbType.String);
            db.AddInParameter(cmdProc, "@lcode", DbType.String);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@UserLoginName", AppData.UserLoginName);
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@SubjectID", AppData.SubjectID);
            db.SetParameterValue(cmdProc, "@UserNickName", AppData.UserNickName);
            db.SetParameterValue(cmdProc, "@Password", AppData.Password);
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@MZ", AppData.MZ);
            db.SetParameterValue(cmdProc, "@ZZMM", AppData.ZZMM);
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@SJH", AppData.SJH);
            db.SetParameterValue(cmdProc, "@BGDH", AppData.BGDH);
            db.SetParameterValue(cmdProc, "@JTDH", AppData.JTDH);
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@QQH", AppData.QQH);
            db.SetParameterValue(cmdProc, "@LoginTime", AppData.LoginTime);
            db.SetParameterValue(cmdProc, "@LastLoginIP", AppData.LastLoginIP);
            db.SetParameterValue(cmdProc, "@LastLoginDate", AppData.LastLoginDate);
            db.SetParameterValue(cmdProc, "@LoginTimes", AppData.LoginTimes);
            db.SetParameterValue(cmdProc, "@UserStatus", AppData.UserStatus);
            db.SetParameterValue(cmdProc, "@vcode", AppData.vcode);
            db.SetParameterValue(cmdProc, "@lcode", AppData.lcode);
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
            string strProcName = "SP_UpdateT_PM_UserInfoByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@UserLoginName", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@SubjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserNickName", DbType.String);
            db.AddInParameter(cmdProc, "@Password", DbType.String);
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@MZ", DbType.String);
            db.AddInParameter(cmdProc, "@ZZMM", DbType.String);
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@SJH", DbType.String);
            db.AddInParameter(cmdProc, "@BGDH", DbType.String);
            db.AddInParameter(cmdProc, "@JTDH", DbType.String);
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@QQH", DbType.String);
            db.AddInParameter(cmdProc, "@LoginTime", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LastLoginIP", DbType.String);
            db.AddInParameter(cmdProc, "@LastLoginDate", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LoginTimes", DbType.Int32);
            db.AddInParameter(cmdProc, "@UserStatus", DbType.String);
            db.AddInParameter(cmdProc, "@vcode", DbType.String);
            db.AddInParameter(cmdProc, "@lcode", DbType.String);
            // �Դ洢���̲�����ֵ

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@UserLoginName", AppData.UserLoginName);
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@SubjectID", AppData.SubjectID);
            db.SetParameterValue(cmdProc, "@UserNickName", AppData.UserNickName);
            db.SetParameterValue(cmdProc, "@Password", AppData.Password);
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@MZ", AppData.MZ);
            db.SetParameterValue(cmdProc, "@ZZMM", AppData.ZZMM);
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@SJH", AppData.SJH);
            db.SetParameterValue(cmdProc, "@BGDH", AppData.BGDH);
            db.SetParameterValue(cmdProc, "@JTDH", AppData.JTDH);
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@QQH", AppData.QQH);
            db.SetParameterValue(cmdProc, "@LoginTime", AppData.LoginTime);
            db.SetParameterValue(cmdProc, "@LastLoginIP", AppData.LastLoginIP);
            db.SetParameterValue(cmdProc, "@LastLoginDate", AppData.LastLoginDate);
            db.SetParameterValue(cmdProc, "@LoginTimes", AppData.LoginTimes);
            db.SetParameterValue(cmdProc, "@UserStatus", AppData.UserStatus);
            db.SetParameterValue(cmdProc, "@vcode", AppData.vcode);
            db.SetParameterValue(cmdProc, "@lcode", AppData.lcode);
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
            string strProcName = "SP_UpdateT_PM_UserInfoByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@UserLoginName", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@SubjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserNickName", DbType.String);
            db.AddInParameter(cmdProc, "@Password", DbType.String);
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@MZ", DbType.String);
            db.AddInParameter(cmdProc, "@ZZMM", DbType.String);
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@SJH", DbType.String);
            db.AddInParameter(cmdProc, "@BGDH", DbType.String);
            db.AddInParameter(cmdProc, "@JTDH", DbType.String);
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@QQH", DbType.String);
            db.AddInParameter(cmdProc, "@LoginTime", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LastLoginIP", DbType.String);
            db.AddInParameter(cmdProc, "@LastLoginDate", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LoginTimes", DbType.Int32);
            db.AddInParameter(cmdProc, "@UserStatus", DbType.String);
            db.AddInParameter(cmdProc, "@vcode", DbType.String);
            db.AddInParameter(cmdProc, "@lcode", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);

            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@UserLoginName", AppData.UserLoginName);
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@SubjectID", AppData.SubjectID);
            db.SetParameterValue(cmdProc, "@UserNickName", AppData.UserNickName);
            db.SetParameterValue(cmdProc, "@Password", AppData.Password);
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@MZ", AppData.MZ);
            db.SetParameterValue(cmdProc, "@ZZMM", AppData.ZZMM);
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@SJH", AppData.SJH);
            db.SetParameterValue(cmdProc, "@BGDH", AppData.BGDH);
            db.SetParameterValue(cmdProc, "@JTDH", AppData.JTDH);
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@QQH", AppData.QQH);
            db.SetParameterValue(cmdProc, "@LoginTime", AppData.LoginTime);
            db.SetParameterValue(cmdProc, "@LastLoginIP", AppData.LastLoginIP);
            db.SetParameterValue(cmdProc, "@LastLoginDate", AppData.LastLoginDate);
            db.SetParameterValue(cmdProc, "@LoginTimes", AppData.LoginTimes);
            db.SetParameterValue(cmdProc, "@UserStatus", AppData.UserStatus);
            db.SetParameterValue(cmdProc, "@vcode", AppData.vcode);
            db.SetParameterValue(cmdProc, "@lcode", AppData.lcode);
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
            string strProcName = "SP_SelectT_PM_UserInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
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
            string strProcName = "SP_SelectT_PM_UserInfoByObjectID";
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
        public static T_PM_UserInfoApplicationData GetDataByObjectID(string strObjectID)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_PM_UserInfoByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // ִ�д洢����
            return T_PM_UserInfoApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// ��KeyΪ������ѯ��¼������AppData
        /// </summary>
        //=====================================================================
        public static T_PM_UserInfoApplicationData GetDataByKey(T_PM_UserInfoApplicationData appData)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_PM_UserInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@UserID", appData.UserID);
            // ִ�д洢����
            return T_PM_UserInfoApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectT_PM_UserInfoByAnyCondition";
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
                
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@UserIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserLoginName", DbType.String);
            db.AddInParameter(cmdProc, "@UserLoginNameBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SubjectID", DbType.String);
            db.AddInParameter(cmdProc, "@SubjectIDBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserNickName", DbType.String);
            db.AddInParameter(cmdProc, "@UserNickNameBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@Password", DbType.String);
            db.AddInParameter(cmdProc, "@PasswordBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@XB", DbType.String);
            db.AddInParameter(cmdProc, "@XBBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@MZ", DbType.String);
            db.AddInParameter(cmdProc, "@MZBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@ZZMM", DbType.String);
            db.AddInParameter(cmdProc, "@ZZMMBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SFZH", DbType.String);
            db.AddInParameter(cmdProc, "@SFZHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@SJH", DbType.String);
            db.AddInParameter(cmdProc, "@SJHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@BGDH", DbType.String);
            db.AddInParameter(cmdProc, "@BGDHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@JTDH", DbType.String);
            db.AddInParameter(cmdProc, "@JTDHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@Email", DbType.String);
            db.AddInParameter(cmdProc, "@EmailBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@QQH", DbType.String);
            db.AddInParameter(cmdProc, "@QQHBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LoginTime", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LoginTimeBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LastLoginIP", DbType.String);
            db.AddInParameter(cmdProc, "@LastLoginIPBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LastLoginDate", DbType.DateTime);
            db.AddInParameter(cmdProc, "@LastLoginDateBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@LoginTimes", DbType.Int32);
            db.AddInParameter(cmdProc, "@LoginTimesBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@UserStatus", DbType.String);
            db.AddInParameter(cmdProc, "@UserStatusBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@vcode", DbType.String);
            db.AddInParameter(cmdProc, "@vcodeBatch", DbType.String);
                
            db.AddInParameter(cmdProc, "@lcode", DbType.String);
            db.AddInParameter(cmdProc, "@lcodeBatch", DbType.String);
                
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
                
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
            db.SetParameterValue(cmdProc, "@UserIDBatch", AppData.UserIDBatch);
                
            db.SetParameterValue(cmdProc, "@UserLoginName", AppData.UserLoginName);
            db.SetParameterValue(cmdProc, "@UserLoginNameBatch", AppData.UserLoginNameBatch);
                
            db.SetParameterValue(cmdProc, "@UserGroupID", AppData.UserGroupID);
            db.SetParameterValue(cmdProc, "@UserGroupIDBatch", AppData.UserGroupIDBatch);
                
            db.SetParameterValue(cmdProc, "@SubjectID", AppData.SubjectID);
            db.SetParameterValue(cmdProc, "@SubjectIDBatch", AppData.SubjectIDBatch);
                
            db.SetParameterValue(cmdProc, "@UserNickName", AppData.UserNickName);
            db.SetParameterValue(cmdProc, "@UserNickNameBatch", AppData.UserNickNameBatch);
                
            db.SetParameterValue(cmdProc, "@Password", AppData.Password);
            db.SetParameterValue(cmdProc, "@PasswordBatch", AppData.PasswordBatch);
                
            db.SetParameterValue(cmdProc, "@XB", AppData.XB);
            db.SetParameterValue(cmdProc, "@XBBatch", AppData.XBBatch);
                
            db.SetParameterValue(cmdProc, "@MZ", AppData.MZ);
            db.SetParameterValue(cmdProc, "@MZBatch", AppData.MZBatch);
                
            db.SetParameterValue(cmdProc, "@ZZMM", AppData.ZZMM);
            db.SetParameterValue(cmdProc, "@ZZMMBatch", AppData.ZZMMBatch);
                
            db.SetParameterValue(cmdProc, "@SFZH", AppData.SFZH);
            db.SetParameterValue(cmdProc, "@SFZHBatch", AppData.SFZHBatch);
                
            db.SetParameterValue(cmdProc, "@SJH", AppData.SJH);
            db.SetParameterValue(cmdProc, "@SJHBatch", AppData.SJHBatch);
                
            db.SetParameterValue(cmdProc, "@BGDH", AppData.BGDH);
            db.SetParameterValue(cmdProc, "@BGDHBatch", AppData.BGDHBatch);
                
            db.SetParameterValue(cmdProc, "@JTDH", AppData.JTDH);
            db.SetParameterValue(cmdProc, "@JTDHBatch", AppData.JTDHBatch);
                
            db.SetParameterValue(cmdProc, "@Email", AppData.Email);
            db.SetParameterValue(cmdProc, "@EmailBatch", AppData.EmailBatch);
                
            db.SetParameterValue(cmdProc, "@QQH", AppData.QQH);
            db.SetParameterValue(cmdProc, "@QQHBatch", AppData.QQHBatch);
                
            db.SetParameterValue(cmdProc, "@LoginTime", AppData.LoginTime);
            db.SetParameterValue(cmdProc, "@LoginTimeBatch", AppData.LoginTimeBatch);
                
            db.SetParameterValue(cmdProc, "@LastLoginIP", AppData.LastLoginIP);
            db.SetParameterValue(cmdProc, "@LastLoginIPBatch", AppData.LastLoginIPBatch);
                
            db.SetParameterValue(cmdProc, "@LastLoginDate", AppData.LastLoginDate);
            db.SetParameterValue(cmdProc, "@LastLoginDateBatch", AppData.LastLoginDateBatch);
                
            db.SetParameterValue(cmdProc, "@LoginTimes", AppData.LoginTimes);
            db.SetParameterValue(cmdProc, "@LoginTimesBatch", AppData.LoginTimesBatch);
                
            db.SetParameterValue(cmdProc, "@UserStatus", AppData.UserStatus);
            db.SetParameterValue(cmdProc, "@UserStatusBatch", AppData.UserStatusBatch);
                
            db.SetParameterValue(cmdProc, "@vcode", AppData.vcode);
            db.SetParameterValue(cmdProc, "@vcodeBatch", AppData.vcodeBatch);
                
            db.SetParameterValue(cmdProc, "@lcode", AppData.lcode);
            db.SetParameterValue(cmdProc, "@lcodeBatch", AppData.lcodeBatch);
                
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
            string strProcName = "SP_DeleteT_PM_UserInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
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
            string strProcName = "SP_DeleteT_PM_UserInfoByObjectID";
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
            string strProcName = "SP_DeleteT_PM_UserInfoByObjectIDBatch";
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
            string strProcName = "SP_IsExistT_PM_UserInfoByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@UserID", AppData.UserID);
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
            string strProcName = "SP_IsExistT_PM_UserInfoByObjectID";
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
                    string strProcName = "SP_SelectT_PM_UserInfoByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // �趨�洢�����������
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        
                    db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@UserID", DbType.String);
                    db.AddInParameter(cmdProc, "@UserLoginName", DbType.String);
                    db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
                    db.AddInParameter(cmdProc, "@SubjectID", DbType.String);
                    db.AddInParameter(cmdProc, "@UserNickName", DbType.String);
                    db.AddInParameter(cmdProc, "@Password", DbType.String);
                    db.AddInParameter(cmdProc, "@XB", DbType.String);
                    db.AddInParameter(cmdProc, "@MZ", DbType.String);
                    db.AddInParameter(cmdProc, "@ZZMM", DbType.String);
                    db.AddInParameter(cmdProc, "@SFZH", DbType.String);
                    db.AddInParameter(cmdProc, "@SJH", DbType.String);
                    db.AddInParameter(cmdProc, "@BGDH", DbType.String);
                    db.AddInParameter(cmdProc, "@JTDH", DbType.String);
                    db.AddInParameter(cmdProc, "@Email", DbType.String);
                    db.AddInParameter(cmdProc, "@QQH", DbType.String);
                    db.AddInParameter(cmdProc, "@LoginTime", DbType.DateTime);
                    db.AddInParameter(cmdProc, "@LastLoginIP", DbType.String);
                    db.AddInParameter(cmdProc, "@LastLoginDate", DbType.DateTime);
                    db.AddInParameter(cmdProc, "@LoginTimes", DbType.Int32);
                    db.AddInParameter(cmdProc, "@UserStatus", DbType.String);
                    db.AddInParameter(cmdProc, "@vcode", DbType.String);
                    db.AddInParameter(cmdProc, "@lcode", DbType.String);
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
            string strProcName = "SP_GetMaxT_PM_UserInfoByUserID";
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
            string strProcName = "SP_CountT_PM_UserInfoByAnyCondition";
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
        

        public static DataSet GetTreeData_T_PM_UserInfo_SubjectID(string iDFieldName, string nameFieldName, string parentFieldValue = null, string conditionFieldName = null, string conditionFieldValue = null, bool onlyShowUsed = false)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetTreeData_T_PM_UserInfo_SubjectID";
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
  
