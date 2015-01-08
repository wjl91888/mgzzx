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
    public class UserGroupPurviewLibrary
    {
        #region UserGroupPurviewLibrary
        //***************************************************** 
        //  Function Name:  UserGroupPurviewLibrary
        /// <summary>
        /// 构造函数
        /// </summary>
        //  Writer:         王景璐
        //  Create Date:    2007/03/26
        //******************************************************
        public UserGroupPurviewLibrary()
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
                string strProcName = "SP_IsExistUserGroupPurviewInfo";
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

        public Boolean IsExistRecordByRecordID(string strUserGroupID, string strPurviewID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("strConnManager");
                string strProcName = "SP_IsExistUserGroupPurviewInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
                db.AddOutParameter(cmdProc, "@IsExist", DbType.Boolean, 1);
                db.SetParameterValue(cmdProc, "@UserGroupID", strUserGroupID);
                db.SetParameterValue(cmdProc, "@PurviewID", strPurviewID);
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
                string strProcName = "SP_InsertUserGroupPurviewInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewID", DbType.String);


                db.SetParameterValue(cmdProc, "@UserGroupID", (string)htInputParameter["UserGroupID"]);
                db.SetParameterValue(cmdProc, "@PurviewID", (string)htInputParameter["PurviewID"]);


                db.ExecuteNonQuery(cmdProc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateRecordInfo(Hashtable htInputParameter)
        {

        }

        public void DeleteRecordInfo(Hashtable htInputParameter)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("strConnManager");
                string strProcName = "SP_DeleteUserGroupPurviewInfo";
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
                string strProcName = "SP_SelectUserGroupPurviewInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

                db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                db.AddInParameter(cmdProc, "@SortField", DbType.String);
                db.AddInParameter(cmdProc, "@PageSize", DbType.String);
                db.AddInParameter(cmdProc, "@CurrentPage", DbType.String);

                db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewID", DbType.String);


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
                db.SetParameterValue(cmdProc, "@UserGroupID", (string)htInputParameter["UserGroupID"]);
                db.SetParameterValue(cmdProc, "@PurviewID", (string)htInputParameter["PurviewID"]);


                htInputParameter[ConstantsManager.QUERY_DATASET_NAME] = db.ExecuteDataSet(cmdProc);
                htInputParameter[ConstantsManager.RECORD_COUNT] = db.GetParameterValue(cmdProc, "@RecordCount");
            }
            catch (Exception)
            {

                throw;
            }
            return htInputParameter;
        }

        public Hashtable GetUserGroupPurviewInfo(Hashtable htInputParameter)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("strConnManager");
                string strProcName = "SP_GetUserGroupPurviewInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

                db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
                db.AddInParameter(cmdProc, "@PurviewPRI", DbType.Int32);
                db.SetParameterValue(cmdProc, "@UserGroupID", (string)htInputParameter["UserGroupID"]);
                db.SetParameterValue(cmdProc, "@PurviewPRI", (int)htInputParameter["PurviewPRI"]);

                htInputParameter[ConstantsManager.QUERY_DATASET_NAME] = db.ExecuteDataSet(cmdProc);
                return htInputParameter;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Hashtable SetUserGroupPurviewInfo(Hashtable htInputParameter)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("strConnManager");
                string strProcName = "SP_SetUserGroupPurviewInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

                db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupPurview", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupDeletePurview", DbType.String);

                db.SetParameterValue(cmdProc, "@UserGroupID", (string)htInputParameter["UserGroupID"]);
                db.SetParameterValue(cmdProc, "@UserGroupPurview", (string)htInputParameter["UserGroupPurview"]);
                db.SetParameterValue(cmdProc, "@UserGroupDeletePurview", (string)htInputParameter["UserGroupDeletePurview"]);

                db.ExecuteNonQuery(cmdProc);
                return htInputParameter;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}