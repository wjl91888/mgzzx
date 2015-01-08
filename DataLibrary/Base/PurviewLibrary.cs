using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace RICH.Common.PM
{
    public class PurviewLibrary
    {
        #region PurviewLibrary
        //***************************************************** 
        //  Function Name:  PurviewLibrary
        /// <summary>
        /// 构造函数
        /// </summary>
        //  Writer:         王景璐
        //  Create Date:    2007/03/25
        //******************************************************
        public PurviewLibrary()
        {
            //
            // TODO: Add constructor logic here
            //
        } 
        #endregion

        public Boolean IsExistRecordByObjectID(string strObjectID)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddOutParameter(cmdProc, "@IsExist", DbType.Boolean, 1);
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            db.ExecuteNonQuery(cmdProc);
            return (Boolean)db.GetParameterValue(cmdProc, "@IsExist");
        }

        public static Boolean IsExistRecordByRecordID(string strRecordID)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddOutParameter(cmdProc, "@IsExist", DbType.Boolean, 1);
            db.SetParameterValue(cmdProc, "@PurviewID", strRecordID);
            db.ExecuteNonQuery(cmdProc);
            return (Boolean)db.GetParameterValue(cmdProc, "@IsExist");
        }

        public void InsertRecordInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_InsertPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewName", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewContent", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewRemark", DbType.String);
            db.AddInParameter(cmdProc, "@IsPageMenu", DbType.Boolean);
            db.AddInParameter(cmdProc, "@PageFileName", DbType.String);
            db.AddInParameter(cmdProc, "@PageFileParameter", DbType.String);
            db.AddInParameter(cmdProc, "@PageFilePath", DbType.String);

            db.SetParameterValue(cmdProc, "@PurviewID", (string)htInputParameter["PurviewID"]);
            db.SetParameterValue(cmdProc, "@PurviewName", (string)htInputParameter["PurviewName"]);
            db.SetParameterValue(cmdProc, "@PurviewTypeID", (string)htInputParameter["PurviewTypeID"]);
            db.SetParameterValue(cmdProc, "@PurviewContent", (string)htInputParameter["PurviewContent"]);
            db.SetParameterValue(cmdProc, "@PurviewRemark", (string)htInputParameter["PurviewRemark"]);
            if (DataValidateManager.ValidateBooleanFormat(htInputParameter["IsPageMenu"]) == true)
            {
                db.SetParameterValue(cmdProc, "@IsPageMenu", Boolean.Parse((string)htInputParameter["IsPageMenu"]));
            }
            db.SetParameterValue(cmdProc, "@PageFileName", (string)htInputParameter["PageFileName"]);
            db.SetParameterValue(cmdProc, "@PageFileParameter", (string)htInputParameter["PageFileParameter"]);
            db.SetParameterValue(cmdProc, "@PageFilePath", (string)htInputParameter["PageFilePath"]);

            db.ExecuteNonQuery(cmdProc);
        }

        public void UpdateRecordInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_UpdatePurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
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

            db.SetParameterValue(cmdProc, "@ObjectID", (string)htInputParameter["ObjectID"]);
            db.SetParameterValue(cmdProc, "@PurviewID", (string)htInputParameter["PurviewID"]);
            db.SetParameterValue(cmdProc, "@PurviewName", (string)htInputParameter["PurviewName"]);
            db.SetParameterValue(cmdProc, "@PurviewTypeID", (string)htInputParameter["PurviewTypeID"]);
            db.SetParameterValue(cmdProc, "@PurviewContent", (string)htInputParameter["PurviewContent"]);
            db.SetParameterValue(cmdProc, "@PurviewRemark", (string)htInputParameter["PurviewRemark"]);
            if (DataValidateManager.ValidateBooleanFormat(htInputParameter["IsPageMenu"]) == true)
            {
                db.SetParameterValue(cmdProc, "@IsPageMenu", Boolean.Parse((string)htInputParameter["IsPageMenu"]));
            }
            db.SetParameterValue(cmdProc, "@PageFileName", (string)htInputParameter["PageFileName"]);
            db.SetParameterValue(cmdProc, "@PageFileParameter", (string)htInputParameter["PageFileParameter"]);
            db.SetParameterValue(cmdProc, "@PageFilePath", (string)htInputParameter["PageFilePath"]);

            db.ExecuteNonQuery(cmdProc);
        }

        public void DeleteRecordInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeletePurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.SetParameterValue(cmdProc, "@ObjectID", htInputParameter["ObjectID"]);
            db.ExecuteNonQuery(cmdProc);
        }

        public Hashtable SelectRecordInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            db.AddInParameter(cmdProc, "@PageSize", DbType.String);
            db.AddInParameter(cmdProc, "@CurrentPage", DbType.String);

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
            db.SetParameterValue(cmdProc, "@PurviewID", (string)htInputParameter["PurviewID"]);
            db.SetParameterValue(cmdProc, "@PurviewName", (string)htInputParameter["PurviewName"]);
            db.SetParameterValue(cmdProc, "@PurviewTypeID", (string)htInputParameter["PurviewTypeID"]);
            db.SetParameterValue(cmdProc, "@Purviewcontent", (string)htInputParameter["Purviewcontent"]);
            db.SetParameterValue(cmdProc, "@PurviewRemark", (string)htInputParameter["PurviewRemark"]);
            if (DataValidateManager.ValidateBooleanFormat(htInputParameter["IsPageMenu"]) == true)
            {
                db.SetParameterValue(cmdProc, "@IsPageMenu", Boolean.Parse((string)htInputParameter["IsPageMenu"]));
            }
            db.SetParameterValue(cmdProc, "@PageFileName", (string)htInputParameter["PageFileName"]);
            db.SetParameterValue(cmdProc, "@PageFileParameter", (string)htInputParameter["PageFileParameter"]);
            db.SetParameterValue(cmdProc, "@PageFilePath", (string)htInputParameter["PageFilePath"]);

            htInputParameter[ConstantsManager.QUERY_DATASET_NAME] = db.ExecuteDataSet(cmdProc);
            htInputParameter[ConstantsManager.RECORD_COUNT] = db.GetParameterValue(cmdProc, "@RecordCount");
            return htInputParameter;
        }

        public Hashtable GetPurviewInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@PurviewPRI", DbType.Int32);
            db.SetParameterValue(cmdProc, "@PurviewPRI", (int)htInputParameter["PurviewPRI"]);

            htInputParameter[ConstantsManager.QUERY_DATASET_NAME] = db.ExecuteDataSet(cmdProc);
            return htInputParameter;
        }

        public static void AddPurviewInfo(string strPurviewID, string strPurviewName, string strPurviewTypeID)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_InsertPurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewName", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewTypeID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewContent", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewRemark", DbType.String);

            db.SetParameterValue(cmdProc, "@PurviewID", strPurviewID);
            db.SetParameterValue(cmdProc, "@PurviewName", strPurviewName);
            db.SetParameterValue(cmdProc, "@PurviewTypeID", strPurviewTypeID);
            db.SetParameterValue(cmdProc, "@PurviewContent", strPurviewName);
            db.SetParameterValue(cmdProc, "@PurviewRemark", strPurviewName);

            db.ExecuteNonQuery(cmdProc);
        }

        public static void RemovePurviewInfo(string strPurviewID)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeletePurviewInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);
            db.SetParameterValue(cmdProc, "@PurviewID", strPurviewID);
            db.ExecuteNonQuery(cmdProc);
        }

    }
}