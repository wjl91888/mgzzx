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
    //****************************************************** 
    ///<summary>
    ///Module ID：UserGroupLibrary
    ///Depiction：关于课程信息的数据库操作及其他操作
    ///Author：     王景璐
    ///Create Date：2007/03/26
    ///</summary>
    //******************************************************
    public class UserGroupLibrary
    {
        #region UserGroupLibrary
        //***************************************************** 
        //  Function Name:  UserGroupLibrary
        /// <summary>
        /// 构造函数
        /// </summary>
        //  Writer:         王景璐
        //  Create Date:    2007/03/26
        //******************************************************
        public UserGroupLibrary()
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
                string strProcName = "SP_IsExistUserGroupInfo";
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
                string strProcName = "SP_IsExistUserGroupInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
                db.AddOutParameter(cmdProc, "@IsExist", DbType.Boolean, 1);
                db.SetParameterValue(cmdProc, "@UserGroupID", strRecordID);
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
                string strProcName = "SP_InsertUserGroupInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupName", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupContent", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupRemark", DbType.String);

                db.SetParameterValue(cmdProc, "@UserGroupID", (string)htInputParameter["UserGroupID"]);
                db.SetParameterValue(cmdProc, "@UserGroupName", (string)htInputParameter["UserGroupName"]);
                db.SetParameterValue(cmdProc, "@UserGroupContent", (string)htInputParameter["UserGroupContent"]);
                db.SetParameterValue(cmdProc, "@UserGroupRemark", (string)htInputParameter["UserGroupRemark"]);

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
                string strProcName = "SP_UpdateUserGroupInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupName", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupContent", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupRemark", DbType.String);

                db.SetParameterValue(cmdProc, "@ObjectID", (string)htInputParameter["ObjectID"]);
                db.SetParameterValue(cmdProc, "@UserGroupName", (string)htInputParameter["UserGroupName"]);
                db.SetParameterValue(cmdProc, "@UserGroupContent", (string)htInputParameter["UserGroupContent"]);
                db.SetParameterValue(cmdProc, "@UserGroupRemark", (string)htInputParameter["UserGroupRemark"]);

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
                string strProcName = "SP_DeleteUserGroupInfo";
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
                string strProcName = "SP_SelectUserGroupInfo";
                DbCommand cmdProc = db.GetStoredProcCommand(strProcName);

                db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                db.AddInParameter(cmdProc, "@SortField", DbType.String);
                db.AddInParameter(cmdProc, "@PageSize", DbType.String);
                db.AddInParameter(cmdProc, "@CurrentPage", DbType.String);

                db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupID", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupName", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupContent", DbType.String);
                db.AddInParameter(cmdProc, "@UserGroupRemark", DbType.String);

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
                db.SetParameterValue(cmdProc, "@UserGroupName", (string)htInputParameter["UserGroupName"]);
                db.SetParameterValue(cmdProc, "@UserGroupContent", (string)htInputParameter["UserGroupContent"]);
                db.SetParameterValue(cmdProc, "@UserGroupRemark", (string)htInputParameter["UserGroupRemark"]);

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