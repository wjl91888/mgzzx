using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using RICH.Common;

namespace RICH.Common.LM
{
    public class LogTypeLibrary
    {
        #region LogTypeLibrary
        //***************************************************** 
        //  Function Name:  LogTypeLibrary
        /// <summary>
        /// 构造函数
        /// </summary>
        //  Writer:         王景璐
        //  Create Date:    2007/03/27
        //******************************************************
        public LogTypeLibrary()
        {
            //
            // TODO: Add constructor logic here
            //
        } 
        #endregion

        public Boolean IsExistRecordByObjectID(string strObjectID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("strConnManager");
                string strProcName = "SP_IsExistLogTypeInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                db.AddOutParameter(cmdProc, "@IsExist", DbType.Boolean, 1);
                db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
                db.ExecuteNonQuery(cmdProc);
                return (Boolean)db.GetParameterValue(cmdProc, "@IsExist");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Boolean IsExistRecordByRecordID(string strRecordID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("strConnManager");
                string strProcName = "SP_IsExistLogTypeInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@LogTypeID", DbType.String);
                db.AddOutParameter(cmdProc, "@IsExist", DbType.Boolean, 1);
                db.SetParameterValue(cmdProc, "@LogTypeID", strRecordID);
                db.ExecuteNonQuery(cmdProc);
                return (Boolean)db.GetParameterValue(cmdProc, "@IsExist");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertRecordInfo(Hashtable htInputParameter)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("strConnManager");
                string strProcName = "SP_InsertLogTypeInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@LogTypeID", DbType.String);
                db.AddInParameter(cmdProc, "@LogTypeName", DbType.String);
                db.AddInParameter(cmdProc, "@LogTypeRemark", DbType.String);
                db.AddInParameter(cmdProc, "@IsPublic", DbType.Boolean);
                db.AddInParameter(cmdProc, "@IsLog", DbType.Boolean);

                db.SetParameterValue(cmdProc, "@LogTypeID", (string)htInputParameter["LogTypeID"]);
                db.SetParameterValue(cmdProc, "@LogTypeName", (string)htInputParameter["LogTypeName"]);
                db.SetParameterValue(cmdProc, "@LogTypeRemark", (string)htInputParameter["LogTypeRemark"]);
                db.SetParameterValue(cmdProc, "@IsPublic", Boolean.Parse((string)htInputParameter["IsPublic"]));
                db.SetParameterValue(cmdProc, "@IsLog", Boolean.Parse((string)htInputParameter["IsLog"]));

                db.ExecuteNonQuery(cmdProc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateRecordInfo(Hashtable htInputParameter)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("strConnManager");
                string strProcName = "SP_UpdateLogTypeInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                db.AddInParameter(cmdProc, "@LogTypeID", DbType.String);
                db.AddInParameter(cmdProc, "@LogTypeName", DbType.String);
                db.AddInParameter(cmdProc, "@LogTypeRemark", DbType.String);
                db.AddInParameter(cmdProc, "@IsPublic", DbType.Boolean);
                db.AddInParameter(cmdProc, "@IsLog", DbType.Boolean);

                db.SetParameterValue(cmdProc, "@ObjectID", (string)htInputParameter["ObjectID"]);
                db.SetParameterValue(cmdProc, "@LogTypeID", (string)htInputParameter["LogTypeID"]);
                db.SetParameterValue(cmdProc, "@LogTypeName", (string)htInputParameter["LogTypeName"]);
                db.SetParameterValue(cmdProc, "@LogTypeRemark", (string)htInputParameter["LogTypeRemark"]);
                if (htInputParameter["IsPublic"] != null)
                {
                    db.SetParameterValue(cmdProc, "@IsPublic", Boolean.Parse((string)htInputParameter["IsPublic"])); 
                }
                if (htInputParameter["IsLog"] != null)
                {
                    db.SetParameterValue(cmdProc, "@IsLog", Boolean.Parse((string)htInputParameter["IsLog"])); 
                }

                db.ExecuteNonQuery(cmdProc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteRecordInfo(Hashtable htInputParameter)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("strConnManager");
                string strProcName = "SP_DeleteLogTypeInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                db.SetParameterValue(cmdProc, "@ObjectID", htInputParameter["ObjectID"]);
                db.ExecuteNonQuery(cmdProc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Hashtable SelectRecordInfo(Hashtable htInputParameter)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("strConnManager");
                string strProcName = "SP_SelectLogTypeInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

                db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                db.AddInParameter(cmdProc, "@SortField", DbType.String);
                db.AddInParameter(cmdProc, "@PageSize", DbType.String);
                db.AddInParameter(cmdProc, "@CurrentPage", DbType.String);

                db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                db.AddInParameter(cmdProc, "@LogTypeID", DbType.String);
                db.AddInParameter(cmdProc, "@LogTypeName", DbType.String);
                db.AddInParameter(cmdProc, "@LogTypeRemark", DbType.String);
                db.AddInParameter(cmdProc, "@IsPublic", DbType.Boolean);
                db.AddInParameter(cmdProc, "@IsLog", DbType.Boolean);

                db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);

                if (htInputParameter["Sort"] != null)
                {
                    db.SetParameterValue(cmdProc, "@Sort", Boolean.Parse((string)htInputParameter["Sort"]));
                }
                db.SetParameterValue(cmdProc, "@SortField", (string)htInputParameter["SortField"]);
                if (htInputParameter["PageSize"] != null)
                {
                    db.SetParameterValue(cmdProc, "@PageSize", Int32.Parse((string)htInputParameter["PageSize"]));
                }
                if (htInputParameter["CurrentPage"] != null)
                {
                    db.SetParameterValue(cmdProc, "@CurrentPage", Int32.Parse((string)htInputParameter["CurrentPage"]));
                }

                db.SetParameterValue(cmdProc, "@ObjectID", (string)htInputParameter["ObjectID"]);
                db.SetParameterValue(cmdProc, "@LogTypeID", (string)htInputParameter["LogTypeID"]);
                db.SetParameterValue(cmdProc, "@LogTypeName", (string)htInputParameter["LogTypeName"]);
                db.SetParameterValue(cmdProc, "@LogTypeRemark", (string)htInputParameter["LogTypeRemark"]);
                if (htInputParameter["IsPublic"] != null)
                {
                    db.SetParameterValue(cmdProc, "@IsPublic", Boolean.Parse((string)htInputParameter["IsPublic"])); 
                }
                if (htInputParameter["IsLog"] != null)
                {
                    db.SetParameterValue(cmdProc, "@IsLog", Boolean.Parse((string)htInputParameter["IsLog"])); 
                }

                htInputParameter[ConstantsManager.QUERY_DATASET_NAME] = db.ExecuteDataSet(cmdProc);
                htInputParameter[ConstantsManager.RECORD_COUNT] = db.GetParameterValue(cmdProc, "@RecordCount");
            }
            catch (Exception)
            {

                throw;
            }
            return htInputParameter;
        }
    }
}