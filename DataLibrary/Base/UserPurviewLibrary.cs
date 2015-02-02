using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace RICH.Common.PM
{
    public class UserPurviewLibrary
    {
        #region UserPurviewLibrary
        //***************************************************** 
        //  Function Name:  UserPurviewLibrary
        /// <summary>
        /// 构造函数
        /// </summary>
        //  Writer:         王景璐
        //  Create Date:    2007/03/23
        //******************************************************
        public UserPurviewLibrary()
        {
            //
            // TODO: Add constructor logic here
            //
        } 
        #endregion

        public Boolean IsExistRecordByObjectID(string strObjectID)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistUserPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddOutParameter(cmdProc, "@IsExist", DbType.Boolean, 1);
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            db.ExecuteNonQuery(cmdProc);
            return (Boolean)db.GetParameterValue(cmdProc, "@IsExist");
        }

        public Boolean IsExistRecordByRecordID(string strRecordID)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistUserPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddOutParameter(cmdProc, "@IsExist", DbType.Boolean, 1);
            db.SetParameterValue(cmdProc, "@UserID", strRecordID);
            db.ExecuteNonQuery(cmdProc);
            return (Boolean)db.GetParameterValue(cmdProc, "@IsExist");
        }

        public void InsertRecordInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_InsertUserPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewLimitation", DbType.DateTime);

            db.SetParameterValue(cmdProc, "@UserID", (string)htInputParameter["UserID"]);
            db.SetParameterValue(cmdProc, "@PurviewID", (string)htInputParameter["PurviewID"]);
            db.SetParameterValue(cmdProc, "@PurviewLimitation", DateTime.Parse((string)htInputParameter["PurviewLimitation"]));

            db.ExecuteNonQuery(cmdProc);
        }

        public void UpdateRecordInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdateUserPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewLimitation", DbType.DateTime);

            db.SetParameterValue(cmdProc, "@ObjectID", (string)htInputParameter["ObjectID"]);
            db.SetParameterValue(cmdProc, "@UserID", (string)htInputParameter["UserID"]);
            db.SetParameterValue(cmdProc, "@PurviewID", (string)htInputParameter["PurviewID"]);
            db.SetParameterValue(cmdProc, "@PurviewLimitation", DateTime.Parse((string)htInputParameter["PurviewLimitation"]));

            db.ExecuteNonQuery(cmdProc);
        }

        public void DeleteRecordInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteUserPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.SetParameterValue(cmdProc, "@ObjectID", htInputParameter["ObjectID"]);
            db.ExecuteNonQuery(cmdProc);
        }

        public Hashtable SelectRecordInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectUserPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            db.AddInParameter(cmdProc, "@PageSize", DbType.String);
            db.AddInParameter(cmdProc, "@CurrentPage", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewLimitation", DbType.DateTime);

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
            db.SetParameterValue(cmdProc, "@UserID", (string)htInputParameter["UserID"]);
            db.SetParameterValue(cmdProc, "@PurviewID", (string)htInputParameter["PurviewID"]);
                
            if (htInputParameter["PurviewLimitation"] != null)
            {
                db.SetParameterValue(cmdProc, "@PurviewLimitation", DateTime.Parse((string)htInputParameter["PurviewLimitation"]));
            }

            htInputParameter[ConstantsManager.QUERY_DATASET_NAME] = db.ExecuteDataSet(cmdProc);
            htInputParameter[ConstantsManager.RECORD_COUNT] = db.GetParameterValue(cmdProc, "@RecordCount");
            return htInputParameter;
        }

        public Hashtable GetUserPurviewInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetUserPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewPRI", DbType.Int32);
            db.AddInParameter(cmdProc, "@IsPageMenu", DbType.Boolean);

            db.SetParameterValue(cmdProc, "@UserID", (string)htInputParameter["UserID"]);
            if (DataValidateManager.ValidateIsNull(htInputParameter["PurviewPRI"]) == false)
            {
                db.SetParameterValue(cmdProc, "@PurviewPRI", (int)htInputParameter["PurviewPRI"]);
            }
            if (DataValidateManager.ValidateBooleanFormat(htInputParameter["IsPageMenu"]) == true)
            {
                db.SetParameterValue(cmdProc, "@IsPageMenu", Boolean.Parse((string)htInputParameter["IsPageMenu"]));
            }

            htInputParameter[ConstantsManager.QUERY_DATASET_NAME] = db.ExecuteDataSet(cmdProc);
            return htInputParameter;
        }

        public Hashtable GetUserPurviewInfoForMenu(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetUserPurviewInfoForMenu";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewPRI", DbType.Int32);
            db.AddInParameter(cmdProc, "@IsPageMenu", DbType.Boolean);

            db.SetParameterValue(cmdProc, "@UserID", (string)htInputParameter["UserID"]);
            if (DataValidateManager.ValidateIsNull(htInputParameter["PurviewPRI"]) == false)
            {
                db.SetParameterValue(cmdProc, "@PurviewPRI", (int)htInputParameter["PurviewPRI"]);
            }
            if (DataValidateManager.ValidateBooleanFormat(htInputParameter["IsPageMenu"]) == true)
            {
                db.SetParameterValue(cmdProc, "@IsPageMenu", Boolean.Parse((string)htInputParameter["IsPageMenu"]));
            }

            htInputParameter[ConstantsManager.QUERY_DATASET_NAME] = db.ExecuteDataSet(cmdProc);
            return htInputParameter;
        }


        public Hashtable SetUserPurviewInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SetUserPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@UserPurview", DbType.String);
            db.AddInParameter(cmdProc, "@UserDeletePurview", DbType.String);

            db.SetParameterValue(cmdProc, "@UserID", (string)htInputParameter["UserID"]);
            db.SetParameterValue(cmdProc, "@UserPurview", (string)htInputParameter["UserPurview"]);
            db.SetParameterValue(cmdProc, "@UserDeletePurview", (string)htInputParameter["UserDeletePurview"]);

            db.ExecuteNonQuery(cmdProc);
            return htInputParameter;
        }
    }
}