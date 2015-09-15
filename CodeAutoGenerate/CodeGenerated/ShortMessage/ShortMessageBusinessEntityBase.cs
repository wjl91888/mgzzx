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
    /// ShortMessage���߼�ʵ����
    /// </summary>
    //=========================================================================
    public class ShortMessageBusinessEntityBase : BusinessEntityBase
    {
        #region ����ʵ��
        /// <summary>
        /// AppData
        /// </summary>
        private ShortMessageApplicationData m_AppData;

        /// <summary>
        /// ȡ���趨AppData
        /// </summary>
        /// <value>AppData</value>
        public ShortMessageApplicationData AppData
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
            string strProcName = "SP_InsertShortMessage";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            string strProcName = "SP_UpdateShortMessageByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
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
                
            // �趨�洢�����������
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // �Դ洢���̲�����ֵ
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
            string strProcName = "SP_UpdateShortMessageByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            string strProcName = "SP_UpdateShortMessageByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������

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
            // �Դ洢���̲�����ֵ

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
            string strProcName = "SP_UpdateShortMessageByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
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
            // �Դ洢���̲�����ֵ
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
            string strProcName = "SP_SelectShortMessageByKey";
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
            string strProcName = "SP_SelectShortMessageByObjectID";
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
        public static ShortMessageApplicationData GetDataByObjectID(string strObjectID)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectShortMessageByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // ִ�д洢����
            return ShortMessageApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// ��KeyΪ������ѯ��¼������AppData
        /// </summary>
        //=====================================================================
        public static ShortMessageApplicationData GetDataByKey(ShortMessageApplicationData appData)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectShortMessageByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // �趨�洢�����������
            
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // �Դ洢���̲�����ֵ
            
            db.SetParameterValue(cmdProc, "@ObjectID", appData.ObjectID);
            // ִ�д洢����
            return ShortMessageApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
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
            string strProcName = "SP_SelectShortMessageByAnyCondition";
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
            string strProcName = "SP_DeleteShortMessageByKey";
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
            string strProcName = "SP_DeleteShortMessageByObjectID";
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
            string strProcName = "SP_DeleteShortMessageByObjectIDBatch";
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
            string strProcName = "SP_IsExistShortMessageByKey";
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
            string strProcName = "SP_IsExistShortMessageByObjectID";
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
                    string strProcName = "SP_SelectShortMessageByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // �趨�洢�����������
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
            string strProcName = "SP_GetMaxShortMessageBy";
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
            string strProcName = "SP_CountShortMessageByAnyCondition";
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
        

        public static DataSet GetTreeData_ShortMessage_JSR(string iDFieldName, string nameFieldName, string parentFieldValue = null, string conditionFieldName = null, string conditionFieldValue = null, bool onlyShowUsed = false)
        {
            // �������ݿ����� 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetTreeData_ShortMessage_JSR";
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
  
