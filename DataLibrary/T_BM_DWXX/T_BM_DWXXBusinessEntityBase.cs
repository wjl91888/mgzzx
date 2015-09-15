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
    /// T_BM_DWXX���߼�ʵ����
    /// </summary>
    //=========================================================================
    public class T_BM_DWXXBusinessEntityBase : BusinessEntityBase
    {
        #region ����ʵ��
        /// <summary>
        /// AppData
        /// </summary>
        private T_BM_DWXXApplicationData m_AppData;

        /// <summary>
        /// ȡ���趨AppData
        /// </summary>
        /// <value>AppData</value>
        public T_BM_DWXXApplicationData AppData
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
            string strProcName = "SP_InsertT_BM_DWXX";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            string strProcName = "SP_UpdateT_BM_DWXXByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
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
                
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
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
            string strProcName = "SP_UpdateT_BM_DWXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            string strProcName = "SP_UpdateT_BM_DWXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            string strProcName = "SP_UpdateT_BM_DWXXByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
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
            // �Դ洢���̲�����ֵ
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
            string strProcName = "SP_SelectT_BM_DWXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
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
            string strProcName = "SP_SelectT_BM_DWXXByObjectID";
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
        public static T_BM_DWXXApplicationData GetDataByObjectID(string strObjectID)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_DWXXByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // ִ�д洢����
            return T_BM_DWXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// ��KeyΪ������ѯ��¼������AppData
        /// </summary>
        //=====================================================================
        public static T_BM_DWXXApplicationData GetDataByKey(T_BM_DWXXApplicationData appData)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectT_BM_DWXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@DWBH", appData.DWBH);
            // ִ�д洢����
            return T_BM_DWXXApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectT_BM_DWXXByAnyCondition";
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
            string strProcName = "SP_DeleteT_BM_DWXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
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
            string strProcName = "SP_DeleteT_BM_DWXXByObjectID";
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
            string strProcName = "SP_DeleteT_BM_DWXXByObjectIDBatch";
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
            string strProcName = "SP_IsExistT_BM_DWXXByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@DWBH", DbType.String);
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@DWBH", AppData.DWBH);
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
            string strProcName = "SP_IsExistT_BM_DWXXByObjectID";
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
                    string strProcName = "SP_SelectT_BM_DWXXByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // �趨�洢�����������
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
            string strProcName = "SP_GetMaxT_BM_DWXXByDWBH";
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
            string strProcName = "SP_CountT_BM_DWXXByAnyCondition";
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
        

        public static DataSet GetTreeData_T_BM_DWXX_SJDWBH(string iDFieldName, string nameFieldName, string parentFieldValue = null, string conditionFieldName = null, string conditionFieldValue = null, bool onlyShowUsed = false)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetTreeData_T_BM_DWXX_SJDWBH";
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
  
