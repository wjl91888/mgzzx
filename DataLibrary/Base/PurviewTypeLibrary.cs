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
namespace RICH.Common.PM
{
    public class PurviewTypeLibrary
    {
        #region PurviewTypeLibrary
        //***************************************************** 
        //  Function Name:  PurviewTypeLibrary
        /// <summary>
        /// 构造函数
        /// </summary>
        //  Writer:         王景璐
        //  Create Date:    2007/03/26
        //******************************************************
        public PurviewTypeLibrary()
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
                string strProcName = "SP_IsExistPurviewTypeInfo";
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
                string strProcName = "SP_IsExistPurviewTypeInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
                db.AddOutParameter(cmdProc, "@IsExist", DbType.Boolean, 1);
                db.SetParameterValue(cmdProc, "@PurviewTypeID", strRecordID);
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
                string strProcName = "SP_InsertPurviewTypeInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewTypeName", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewTypeContent", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewTypeRemark", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewPRI", DbType.Int16);

                db.SetParameterValue(cmdProc, "@PurviewTypeID", (string)htInputParameter["PurviewTypeID"]);
                db.SetParameterValue(cmdProc, "@PurviewTypeName", (string)htInputParameter["PurviewTypeName"]);
                db.SetParameterValue(cmdProc, "@PurviewTypeContent", (string)htInputParameter["PurviewTypeContent"]);
                db.SetParameterValue(cmdProc, "@PurviewTypeRemark", (string)htInputParameter["PurviewTypeRemark"]);
                db.SetParameterValue(cmdProc,"@PurviewPRI",Int32.Parse((string)htInputParameter["PurviewPRI"]));

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
                string strProcName = "SP_UpdatePurviewTypeInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewTypeName", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewTypeContent", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewTypeRemark", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewPRI", DbType.Int16);

                db.SetParameterValue(cmdProc, "@ObjectID", (string)htInputParameter["ObjectID"]);
                db.SetParameterValue(cmdProc, "@PurviewTypeID", (string)htInputParameter["PurviewTypeID"]);
                db.SetParameterValue(cmdProc, "@PurviewTypeName", (string)htInputParameter["PurviewTypeName"]);
                db.SetParameterValue(cmdProc, "@PurviewTypeContent", (string)htInputParameter["PurviewTypeContent"]);
                db.SetParameterValue(cmdProc, "@PurviewTypeRemark", (string)htInputParameter["PurviewTypeRemark"]);
                db.SetParameterValue(cmdProc, "@PurviewPRI", Int32.Parse((string)htInputParameter["PurviewPRI"]));

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
                string strProcName = "SP_DeletePurviewTypeInfo";
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
                string strProcName = "SP_SelectPurviewTypeInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

                db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                db.AddInParameter(cmdProc, "@SortField", DbType.String);
                db.AddInParameter(cmdProc, "@PageSize", DbType.String);
                db.AddInParameter(cmdProc, "@CurrentPage", DbType.String);

                db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewTypeName", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewTypeContent", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewTypeRemark", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewPRI", DbType.Int16);

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
                db.SetParameterValue(cmdProc, "@PurviewTypeID", (string)htInputParameter["PurviewTypeID"]);
                db.SetParameterValue(cmdProc, "@PurviewTypeName", (string)htInputParameter["PurviewTypeName"]);
                db.SetParameterValue(cmdProc, "@PurviewTypeContent", (string)htInputParameter["PurviewTypeContent"]);
                db.SetParameterValue(cmdProc, "@PurviewTypeRemark", (string)htInputParameter["PurviewTypeRemark"]);
                if (htInputParameter["PurviewPRI"] != null)
                {
                    db.SetParameterValue(cmdProc, "@PurviewPRI", Int16.Parse((string)htInputParameter["PurviewPRI"]));
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