using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace RICH.Common
{
    /// <summary>
    /// Summary description for SystemValidateLibrary
    /// </summary>
    public class SystemValidateLibrary
    {
        public static Hashtable ValidateUserLogin(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_ValidateLogin";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@UserLoginName", DbType.String);
            db.AddInParameter(cmdProc, "@Password", DbType.String);
            db.AddInParameter(cmdProc, "@LastLoginIP", DbType.String);
            db.AddInParameter(cmdProc, "@lcodeFromUrl", DbType.String);

            db.AddOutParameter(cmdProc, "@UserID", DbType.String, 50);
            db.AddOutParameter(cmdProc, "@UserGroupID", DbType.String, 4000);
            db.AddOutParameter(cmdProc, "@SubjectID", DbType.String, 50);
            db.AddOutParameter(cmdProc, "@UserNickName", DbType.String, 50);
            db.AddOutParameter(cmdProc, "@MessageID", DbType.String, 50);
            db.AddOutParameter(cmdProc, "@LastLoginDate", DbType.DateTime, 16);
            db.AddOutParameter(cmdProc, "@lcode", DbType.String, 50);

            db.SetParameterValue(cmdProc, "@UserLoginName", (string)htInputParameter["UserLoginName"]);
            db.SetParameterValue(cmdProc, "@Password", (string)htInputParameter["Password"]);
            db.SetParameterValue(cmdProc, "@LastLoginIP", (string)htInputParameter["LastLoginIP"]);
            db.SetParameterValue(cmdProc, "@lcodeFromUrl", (string)htInputParameter["lcode"]);

            db.ExecuteNonQuery(cmdProc);

            htInputParameter["UserID"] = db.GetParameterValue(cmdProc, "@UserID");
            htInputParameter["UserGroupID"] = db.GetParameterValue(cmdProc, "@UserGroupID");
            htInputParameter["SubjectID"] = db.GetParameterValue(cmdProc, "@SubjectID");
            htInputParameter["UserNickName"] = db.GetParameterValue(cmdProc, "@UserNickName");
            htInputParameter[ConstantsManager.MESSAGE_ID] = db.GetParameterValue(cmdProc, "@MessageID");
            htInputParameter["LastLoginDate"] = db.GetParameterValue(cmdProc, "@LastLoginDate");
            htInputParameter["lcode"] = db.GetParameterValue(cmdProc, "@lcode");

            return htInputParameter;
        }

        public static Hashtable ValidatePassword(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_ValidatePassword";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@Password", DbType.String);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);

            db.AddOutParameter(cmdProc, "@MessageID", DbType.String, 50);

            db.SetParameterValue(cmdProc, "@UserID", (string)htInputParameter["UserID"]);
            db.SetParameterValue(cmdProc, "@Password", (string)htInputParameter["Password"]);

            db.ExecuteNonQuery(cmdProc);

            htInputParameter[ConstantsManager.MESSAGE_ID] = db.GetParameterValue(cmdProc, "@MessageID");

            return htInputParameter;
        }

        public static Hashtable ValidateUserPurview(Hashtable htInputParameter)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_ValidatePurview";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);

            db.AddOutParameter(cmdProc, "@MessageID", DbType.String, 50);

            db.SetParameterValue(cmdProc, "@UserID", (string)htInputParameter["UserID"]);
            db.SetParameterValue(cmdProc, "@UserGroupID", (string)htInputParameter["UserGroupID"]);
            db.SetParameterValue(cmdProc, "@PurviewID", (string)htInputParameter["PurviewID"]);

            db.ExecuteNonQuery(cmdProc);

            htInputParameter[ConstantsManager.MESSAGE_ID] = db.GetParameterValue(cmdProc, "@MessageID");

            return htInputParameter;
        }

        public static bool ValidateUserPurview(string strUserID, string strUserGroupID, string strPurviewID)
        {
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_ValidatePurview";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            db.AddInParameter(cmdProc, "@UserID", DbType.String);
            db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
            db.AddInParameter(cmdProc, "@PurviewID", DbType.String);

            db.AddOutParameter(cmdProc, "@MessageID", DbType.String, 50);

            db.SetParameterValue(cmdProc, "@UserID", strUserID);
            db.SetParameterValue(cmdProc, "@UserGroupID", strUserGroupID);
            db.SetParameterValue(cmdProc, "@PurviewID", strPurviewID);

            db.ExecuteNonQuery(cmdProc);

            return DataValidateManager.ValidateIsNull(db.GetParameterValue(cmdProc, "@MessageID"));
        }
    }
}