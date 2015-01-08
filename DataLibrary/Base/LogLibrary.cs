using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using RICH.Common.IM;

namespace RICH.Common.LM
{
    //****************************************************** 
    ///<summary>
    ///Module ID：LogLibrary
    ///Depiction：关于日志信息的数据库操作及其他操作
    ///Author：     王景璐
    ///Create Date：2007/03/27
    ///</summary>
    //******************************************************
    public class LogLibrary
    {
        public Boolean IsExistRecordByObjectID(string strObjectID)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExistLogInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddOutParameter(cmdProc, "@IsExist", DbType.Boolean, 1);
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            db.ExecuteNonQuery(cmdProc);
            return (Boolean)db.GetParameterValue(cmdProc, "@IsExist");
        }


        public static void LogWrite(string strLogTypeID, string strLogContent,
            string strMainObjectID, string strOPObjectID, string strQueryString)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_InsertLogInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@LogTypeID", DbType.String);
            db.AddInParameter(cmdProc, "@LogContent", DbType.String);
            db.AddInParameter(cmdProc, "@LogDate", DbType.DateTime);
            db.AddInParameter(cmdProc, "@AccessURL", DbType.String);
            db.AddInParameter(cmdProc, "@FromURL", DbType.String);
            db.AddInParameter(cmdProc, "@FormIP", DbType.String);
            db.AddInParameter(cmdProc, "@FromProxy", DbType.String);
            db.AddInParameter(cmdProc, "@FromLocation", DbType.String);
            db.AddInParameter(cmdProc, "@FromBrowser", DbType.String);
            db.AddInParameter(cmdProc, "@AccessFileName", DbType.String);
            db.AddInParameter(cmdProc, "@QueryString", DbType.String);
            db.AddInParameter(cmdProc, "@MainObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@OPObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);

            db.SetParameterValue(cmdProc, "@LogTypeID", strLogTypeID);
            db.SetParameterValue(cmdProc, "@LogContent", strLogContent);
            db.SetParameterValue(cmdProc, "@MainObjectID", strMainObjectID);
            db.SetParameterValue(cmdProc, "@OPObjectID", strOPObjectID);
            db.SetParameterValue(cmdProc, "@QueryString", (string)HttpContext.Current.Request.ServerVariables["QUERY_STRING"]);
                
            db.SetParameterValue(cmdProc, "@LogDate", DateTime.Now);
            db.SetParameterValue(cmdProc, "@UserID", HttpContext.Current.Session == null ? null : (string)HttpContext.Current.Session[ConstantsManager.SESSION_USER_ID]);
            db.SetParameterValue(cmdProc, "@AccessURL", @"http://" + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"] + "?" + HttpContext.Current.Request.ServerVariables["QUERY_STRING"]);
            db.SetParameterValue(cmdProc, "@FromURL", HttpContext.Current.Request.ServerVariables["HTTP_REFERER"]);
            db.SetParameterValue(cmdProc, "@FormIP", IPAddessLibrary.GetRemoteTrueIP());
            db.SetParameterValue(cmdProc, "@FromProxy", HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            //db.SetParameterValue(cmdProc, "@FromLocation", IPAddessLibrary.GetLocationFromIP(IPAddessLibrary.GetRemoteTrueIP()));
            db.SetParameterValue(cmdProc, "@FromLocation", null);
            db.SetParameterValue(cmdProc, "@FromBrowser", IPAddessLibrary.GetClientInfo());
            db.SetParameterValue(cmdProc, "@AccessFileName", HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"]);
 
            db.ExecuteNonQuery(cmdProc);
        }

        public void UpdateRecordInfo(Hashtable htInputParameter)
        {

        }

        public void DeleteRecordInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_DeleteLogInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.SetParameterValue(cmdProc, "@ObjectID", htInputParameter["ObjectID"]);
            db.ExecuteNonQuery(cmdProc);
        }

        public Hashtable SelectRecordInfo(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_SelectLogInfo";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            db.AddInParameter(cmdProc, "@PageSize", DbType.String);
            db.AddInParameter(cmdProc, "@CurrentPage", DbType.String);

            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@LogTypeID", DbType.String);
            db.AddInParameter(cmdProc, "@LogContent", DbType.String);
            db.AddInParameter(cmdProc, "@LogDate", DbType.DateTime);
            db.AddInParameter(cmdProc, "@AccessURL", DbType.String);
            db.AddInParameter(cmdProc, "@FromURL", DbType.String);
            db.AddInParameter(cmdProc, "@FormIP", DbType.String);
            db.AddInParameter(cmdProc, "@FromProxy", DbType.String);
            db.AddInParameter(cmdProc, "@FromLocation", DbType.String);
            db.AddInParameter(cmdProc, "@FromBrowser", DbType.String);
            db.AddInParameter(cmdProc, "@AccessFileName", DbType.String);
            db.AddInParameter(cmdProc, "@QueryString", DbType.String);
            db.AddInParameter(cmdProc, "@MainObjectID", DbType.String);
            db.AddInParameter(cmdProc, "@OPObjectID", DbType.String);

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
            db.SetParameterValue(cmdProc, "@LogTypeID", (string)htInputParameter["LogTypeID"]);
            db.SetParameterValue(cmdProc, "@LogContent", (string)htInputParameter["LogContent"]);
            if (htInputParameter["LogDate"] != null)
            {
                db.SetParameterValue(cmdProc, "@LogDate", DateTime.Parse((string)htInputParameter["LogDate"])); 
            }
            db.SetParameterValue(cmdProc, "@AccessURL", (string)htInputParameter["AccessURL"]);
            db.SetParameterValue(cmdProc, "@FromURL", (string)htInputParameter["FromURL"]);
            db.SetParameterValue(cmdProc, "@FormIP", (string)htInputParameter["FormIP"]);
            db.SetParameterValue(cmdProc, "@FromProxy", (string)htInputParameter["FromProxy"]);
            db.SetParameterValue(cmdProc, "@FromLocation", (string)htInputParameter["FromLocation"]);
            db.SetParameterValue(cmdProc, "@FromBrowser", (string)htInputParameter["FromBrowser"]);
            db.SetParameterValue(cmdProc, "@AccessFileName", (string)htInputParameter["AccessFileName"]);
            db.SetParameterValue(cmdProc, "@QueryString", (string)htInputParameter["QueryString"]);
            db.SetParameterValue(cmdProc, "@MainObjectID", (string)htInputParameter["MainObjectID"]);
            db.SetParameterValue(cmdProc, "@OPObjectID", (string)htInputParameter["OPObjectID"]);

            htInputParameter[ConstantsManager.QUERY_DATASET_NAME] = db.ExecuteDataSet(cmdProc);
            htInputParameter[ConstantsManager.RECORD_COUNT] = db.GetParameterValue(cmdProc, "@RecordCount");
            return htInputParameter;
        }
    }
}