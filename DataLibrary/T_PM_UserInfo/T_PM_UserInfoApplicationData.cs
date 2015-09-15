/****************************************************** 
FileName:T_PM_UserInfoApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_PM_UserInfo
{
    //=========================================================================
    //  ClassName : T_PM_UserInfoApplicationData
    /// <summary>
    /// T_PM_UserInfo的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_PM_UserInfoApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 用户编号UserID
        /// </summary>
        /// <value>UserID</value>
        public String UserID { get; set; }
    
        /// <summary>
        /// 用户名UserLoginName
        /// </summary>
        /// <value>UserLoginName</value>
        public String UserLoginName { get; set; }
    
        /// <summary>
        /// 用户组UserGroupID
        /// </summary>
        /// <value>UserGroupID</value>
        public String UserGroupID { get; set; }
    
        /// <summary>
        /// 所属单位SubjectID
        /// </summary>
        /// <value>SubjectID</value>
        public String SubjectID { get; set; }
    
        /// <summary>
        /// 姓名UserNickName
        /// </summary>
        /// <value>UserNickName</value>
        public String UserNickName { get; set; }
    
        /// <summary>
        /// 密码Password
        /// </summary>
        /// <value>Password</value>
        public String Password { get; set; }
    
        /// <summary>
        /// 性别XB
        /// </summary>
        /// <value>XB</value>
        public String XB { get; set; }
    
        /// <summary>
        /// 民族MZ
        /// </summary>
        /// <value>MZ</value>
        public String MZ { get; set; }
    
        /// <summary>
        /// 政治面貌ZZMM
        /// </summary>
        /// <value>ZZMM</value>
        public String ZZMM { get; set; }
    
        /// <summary>
        /// 身份证号SFZH
        /// </summary>
        /// <value>SFZH</value>
        public String SFZH { get; set; }
    
        /// <summary>
        /// 手机SJH
        /// </summary>
        /// <value>SJH</value>
        public String SJH { get; set; }
    
        /// <summary>
        /// 办公电话BGDH
        /// </summary>
        /// <value>BGDH</value>
        public String BGDH { get; set; }
    
        /// <summary>
        /// 家庭电话JTDH
        /// </summary>
        /// <value>JTDH</value>
        public String JTDH { get; set; }
    
        /// <summary>
        /// EmailEmail
        /// </summary>
        /// <value>Email</value>
        public String Email { get; set; }
    
        /// <summary>
        /// QQQQH
        /// </summary>
        /// <value>QQH</value>
        public String QQH { get; set; }
    
        /// <summary>
        /// 登录时间LoginTime
        /// </summary>
        /// <value>LoginTime</value>
        public DateTime? LoginTime { get; set; }
    
        /// <summary>
        /// 登录IPLastLoginIP
        /// </summary>
        /// <value>LastLoginIP</value>
        public String LastLoginIP { get; set; }
    
        /// <summary>
        /// 上次时间LastLoginDate
        /// </summary>
        /// <value>LastLoginDate</value>
        public DateTime? LastLoginDate { get; set; }
    
        /// <summary>
        /// 登录次数LoginTimes
        /// </summary>
        /// <value>LoginTimes</value>
        public Int32? LoginTimes { get; set; }
    
        /// <summary>
        /// 用户状态UserStatus
        /// </summary>
        /// <value>UserStatus</value>
        public String UserStatus { get; set; }
    
        /// <summary>
        /// 验证码vcode
        /// </summary>
        /// <value>vcode</value>
        public String vcode { get; set; }
    
        /// <summary>
        /// 登录码lcode
        /// </summary>
        /// <value>lcode</value>
        public String lcode { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 用户编号UserIDBatch
        /// </summary>
        /// <value>UserID</value>
        public String UserIDBatch { get; set; }

        /// <summary>
        /// 用户名UserLoginNameBatch
        /// </summary>
        /// <value>UserLoginName</value>
        public String UserLoginNameBatch { get; set; }

        /// <summary>
        /// 用户组UserGroupIDBatch
        /// </summary>
        /// <value>UserGroupID</value>
        public String UserGroupIDBatch { get; set; }

        /// <summary>
        /// 所属单位SubjectIDBatch
        /// </summary>
        /// <value>SubjectID</value>
        public String SubjectIDBatch { get; set; }

        /// <summary>
        /// 姓名UserNickNameBatch
        /// </summary>
        /// <value>UserNickName</value>
        public String UserNickNameBatch { get; set; }

        /// <summary>
        /// 密码PasswordBatch
        /// </summary>
        /// <value>Password</value>
        public String PasswordBatch { get; set; }

        /// <summary>
        /// 性别XBBatch
        /// </summary>
        /// <value>XB</value>
        public String XBBatch { get; set; }

        /// <summary>
        /// 民族MZBatch
        /// </summary>
        /// <value>MZ</value>
        public String MZBatch { get; set; }

        /// <summary>
        /// 政治面貌ZZMMBatch
        /// </summary>
        /// <value>ZZMM</value>
        public String ZZMMBatch { get; set; }

        /// <summary>
        /// 身份证号SFZHBatch
        /// </summary>
        /// <value>SFZH</value>
        public String SFZHBatch { get; set; }

        /// <summary>
        /// 手机SJHBatch
        /// </summary>
        /// <value>SJH</value>
        public String SJHBatch { get; set; }

        /// <summary>
        /// 办公电话BGDHBatch
        /// </summary>
        /// <value>BGDH</value>
        public String BGDHBatch { get; set; }

        /// <summary>
        /// 家庭电话JTDHBatch
        /// </summary>
        /// <value>JTDH</value>
        public String JTDHBatch { get; set; }

        /// <summary>
        /// EmailEmailBatch
        /// </summary>
        /// <value>Email</value>
        public String EmailBatch { get; set; }

        /// <summary>
        /// QQQQHBatch
        /// </summary>
        /// <value>QQH</value>
        public String QQHBatch { get; set; }

        /// <summary>
        /// 登录时间LoginTimeBatch
        /// </summary>
        /// <value>LoginTime</value>
        public String LoginTimeBatch { get; set; }

        /// <summary>
        /// 登录IPLastLoginIPBatch
        /// </summary>
        /// <value>LastLoginIP</value>
        public String LastLoginIPBatch { get; set; }

        /// <summary>
        /// 上次时间LastLoginDateBatch
        /// </summary>
        /// <value>LastLoginDate</value>
        public String LastLoginDateBatch { get; set; }

        /// <summary>
        /// 登录次数LoginTimesBatch
        /// </summary>
        /// <value>LoginTimes</value>
        public String LoginTimesBatch { get; set; }

        /// <summary>
        /// 用户状态UserStatusBatch
        /// </summary>
        /// <value>UserStatus</value>
        public String UserStatusBatch { get; set; }

        /// <summary>
        /// 验证码vcodeBatch
        /// </summary>
        /// <value>vcode</value>
        public String vcodeBatch { get; set; }

        /// <summary>
        /// 登录码lcodeBatch
        /// </summary>
        /// <value>lcode</value>
        public String lcodeBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 用户编号批量更新UserIDValue
        /// </summary>
        /// <value>UserIDValue</value>
        public String UserIDValue { get; set; }
    
        /// <summary>
        /// 用户名批量更新UserLoginNameValue
        /// </summary>
        /// <value>UserLoginNameValue</value>
        public String UserLoginNameValue { get; set; }
    
        /// <summary>
        /// 用户组批量更新UserGroupIDValue
        /// </summary>
        /// <value>UserGroupIDValue</value>
        public String UserGroupIDValue { get; set; }
    
        /// <summary>
        /// 所属单位批量更新SubjectIDValue
        /// </summary>
        /// <value>SubjectIDValue</value>
        public String SubjectIDValue { get; set; }
    
        /// <summary>
        /// 姓名批量更新UserNickNameValue
        /// </summary>
        /// <value>UserNickNameValue</value>
        public String UserNickNameValue { get; set; }
    
        /// <summary>
        /// 密码批量更新PasswordValue
        /// </summary>
        /// <value>PasswordValue</value>
        public String PasswordValue { get; set; }
    
        /// <summary>
        /// 性别批量更新XBValue
        /// </summary>
        /// <value>XBValue</value>
        public String XBValue { get; set; }
    
        /// <summary>
        /// 民族批量更新MZValue
        /// </summary>
        /// <value>MZValue</value>
        public String MZValue { get; set; }
    
        /// <summary>
        /// 政治面貌批量更新ZZMMValue
        /// </summary>
        /// <value>ZZMMValue</value>
        public String ZZMMValue { get; set; }
    
        /// <summary>
        /// 身份证号批量更新SFZHValue
        /// </summary>
        /// <value>SFZHValue</value>
        public String SFZHValue { get; set; }
    
        /// <summary>
        /// 手机批量更新SJHValue
        /// </summary>
        /// <value>SJHValue</value>
        public String SJHValue { get; set; }
    
        /// <summary>
        /// 办公电话批量更新BGDHValue
        /// </summary>
        /// <value>BGDHValue</value>
        public String BGDHValue { get; set; }
    
        /// <summary>
        /// 家庭电话批量更新JTDHValue
        /// </summary>
        /// <value>JTDHValue</value>
        public String JTDHValue { get; set; }
    
        /// <summary>
        /// Email批量更新EmailValue
        /// </summary>
        /// <value>EmailValue</value>
        public String EmailValue { get; set; }
    
        /// <summary>
        /// QQ批量更新QQHValue
        /// </summary>
        /// <value>QQHValue</value>
        public String QQHValue { get; set; }
    
        /// <summary>
        /// 登录时间批量更新LoginTimeValue
        /// </summary>
        /// <value>LoginTimeValue</value>
        public DateTime? LoginTimeValue { get; set; }
    
        /// <summary>
        /// 登录IP批量更新LastLoginIPValue
        /// </summary>
        /// <value>LastLoginIPValue</value>
        public String LastLoginIPValue { get; set; }
    
        /// <summary>
        /// 上次时间批量更新LastLoginDateValue
        /// </summary>
        /// <value>LastLoginDateValue</value>
        public DateTime? LastLoginDateValue { get; set; }
    
        /// <summary>
        /// 登录次数批量更新LoginTimesValue
        /// </summary>
        /// <value>LoginTimesValue</value>
        public Int32? LoginTimesValue { get; set; }
    
        /// <summary>
        /// 用户状态批量更新UserStatusValue
        /// </summary>
        /// <value>UserStatusValue</value>
        public String UserStatusValue { get; set; }
    
        /// <summary>
        /// 验证码批量更新vcodeValue
        /// </summary>
        /// <value>vcodeValue</value>
        public String vcodeValue { get; set; }
    
        /// <summary>
        /// 登录码批量更新lcodeValue
        /// </summary>
        /// <value>lcodeValue</value>
        public String lcodeValue { get; set; }
        
        #endregion
        #region 一对一相关表

        #endregion
        #region 功能属性
        /// <summary>
        /// ResultSet
        /// </summary>
        private DataSet m_ResultSet = new DataSet();

        /// <summary>
        /// 查询返回结果集ResultSet
        /// </summary>
        /// <value>ResultSet</value>
        public DataSet ResultSet
        {
            get { return m_ResultSet; }
            set { m_ResultSet = value; }
        }

        /// <summary>
        /// 查询方式QueryType
        /// </summary>
        /// <value>QueryType</value>
        public String QueryType { get; set; }

        /// <summary>
        /// 查询字段QueryField
        /// </summary>
        /// <value>QueryField</value>
        public String QueryField { get; set; }

        /// <summary>
        /// 查询关键字QueryKeywords
        /// </summary>
        /// <value>QueryKeywords</value>
        public String QueryKeywords { get; set; }

        /// <summary>
        /// 查询排序方式Sort
        /// </summary>
        /// <value>Sort</value>
        public Boolean Sort { get; set; }

        /// <summary>
        /// 查询排序关键字SortField
        /// </summary>
        /// <value>SortField</value>
        public String SortField { get; set; }

        /// <summary>
        /// 统计记录数字段CountField
        /// </summary>
        /// <value>CountField</value>
        public String CountField { get; set; }

        /// <summary>
        /// 查询每页记录数PageSize
        /// </summary>
        /// <value>PageSize</value>
        public Int32 PageSize { get; set; }

        /// <summary>
        /// 查询当前页码CurrentPage
        /// </summary>
        /// <value>CurrentPage</value>
        public Int32 CurrentPage { get; set; }

        /// <summary>
        /// 查询记录数RecordCount
        /// </summary>
        /// <value>RecordCount</value>
        public Int32 RecordCount { get; set; }

        /// <summary>
        /// 有效记录数ValidRecordCount
        /// </summary>
        /// <value>ValidRecordCount</value>
        public Int32 ValidRecordCount { get; set; }

        /// <summary>
        /// 有效记录平均值AvgValue
        /// </summary>
        /// <value>AvgValue</value>
        public Double AvgValue { get; set; }

        /// <summary>
        /// 有效记录求和SumValue
        /// </summary>
        /// <value>SumValue</value>
        public Double SumValue { get; set; }
		
        /// <summary>
        /// 最大值MaxValue
        /// </summary>
        /// <value>MaxValue</value>
        public object MaxValue { get; set; }

        /// <summary>
        /// 最小值MinValue
        /// </summary>
        /// <value>MinValue</value>
        public Int32 MinValue { get; set; }

        /// <summary>
        /// 结果代码ResultCode
        /// </summary>
        /// <value>ResultCode</value>
        public ResultState ResultCode { get; set; }

        /// <summary>
        /// 消息代码MessageCode
        /// </summary>
        /// <value>MessageCode</value>
        public string[] MessageCode { get; set; }
        
        /// <summary>
        /// 数据库操作方式代码OPCode
        /// </summary>
        /// <value>OPCode</value>
        public OPType OPCode { get; set; }
        #endregion

        #region 数据实体的列操作
        /// <summary>
        /// 列名列表
        /// </summary>
        private static string[] columnList 
                = new string[] {
                              "ObjectID"
                              ,"UserID"
                              ,"UserLoginName"
                              ,"UserGroupID"
                              ,"SubjectID"
                              ,"UserNickName"
                              ,"Password"
                              ,"XB"
                              ,"MZ"
                              ,"ZZMM"
                              ,"SFZH"
                              ,"SJH"
                              ,"BGDH"
                              ,"JTDH"
                              ,"Email"
                              ,"QQH"
                              ,"LoginTime"
                              ,"LastLoginIP"
                              ,"LastLoginDate"
                              ,"LoginTimes"
                              ,"UserStatus"
                              ,"vcode"
                              ,"lcode"
                                };

        //=====================================================================
        //  FunctionName : GetColumnName
        /// <summary>
        /// 取得列名列表
        /// </summary>
        /// <returns>列名列表</returns>
        //=====================================================================
        public override string[] GetColumnName()
        {
            return columnList;
        }

        /// <summary>
        /// 列数据类型列表
        /// </summary>
        private static SqlDbType[] columnTypeList 
                = new SqlDbType[] {
                              SqlDbType.UniqueIdentifier
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.DateTime
                              ,SqlDbType.NVarChar
                              ,SqlDbType.DateTime
                              ,SqlDbType.Int
                              ,SqlDbType.NVarChar
                              ,SqlDbType.UniqueIdentifier
                              ,SqlDbType.UniqueIdentifier
                                  };

        //=====================================================================
        //  FunctionName : GetColumnType
        /// <summary>
        /// 取得列数据类型列表
        /// </summary>
        /// <returns>列数据类型列表</returns>
        //=====================================================================
        public override SqlDbType[] GetColumnType()
        {
            return columnTypeList;
        }

        /// <summary>
        /// 主键列表
        /// </summary>
        private static string[] primaryKeyList 
                = new string[] {
                              "UserID"
                                };

        //=====================================================================
        //  FunctionName : GetPrimaryKey
        /// <summary>
        /// 取得主键列表
        /// </summary>
        /// <returns>主键列表</returns>
        //=====================================================================
        public override string[] GetPrimaryKey()
        {
            return primaryKeyList;
        }

        /// <summary>
        /// 允许为Null的列名称列表
        /// </summary>
        private static string[] nullableList
                = new string[] {
                              "ObjectID"
                              ,"BGDH"
                              ,"JTDH"
                              ,"Email"
                              ,"QQH"
                              ,"LoginTime"
                              ,"LastLoginIP"
                              ,"LastLoginDate"
                              ,"LoginTimes"
                              ,"vcode"
                              ,"lcode"
                                };


        //=====================================================================
        //  FunctionName : GetNullableColumn
        /// <summary>
        /// 取得允许为Null的列名称列表
        /// </summary>
        /// <returns>允许为Null的列名称列表</returns>
        //=====================================================================
        public override string[] GetNullableColumn()
        {
            return nullableList;
        }

        public static IEnumerable<T_PM_UserInfoApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_PM_UserInfoApplicationData> collection = new List<T_PM_UserInfoApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_PM_UserInfoApplicationData applicationData = new T_PM_UserInfoApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    UserID = dr.ReadString("UserID"),
    UserLoginName = dr.ReadString("UserLoginName"),
    UserGroupID = dr.ReadString("UserGroupID"),
    SubjectID = dr.ReadString("SubjectID"),
    UserNickName = dr.ReadString("UserNickName"),
    Password = dr.ReadString("Password"),
    XB = dr.ReadString("XB"),
    MZ = dr.ReadString("MZ"),
    ZZMM = dr.ReadString("ZZMM"),
    SFZH = dr.ReadString("SFZH"),
    SJH = dr.ReadString("SJH"),
    BGDH = dr.ReadString("BGDH"),
    JTDH = dr.ReadString("JTDH"),
    Email = dr.ReadString("Email"),
    QQH = dr.ReadString("QQH"),
    LoginTime = dr.ReadDateTimeNullable("LoginTime"),
    LastLoginIP = dr.ReadString("LastLoginIP"),
    LastLoginDate = dr.ReadDateTimeNullable("LastLoginDate"),
    LoginTimes = dr.ReadInt32Nullable("LoginTimes"),
    UserStatus = dr.ReadString("UserStatus"),
    vcode = (dr.ReadGuidNullable("vcode") == null ? null : dr.ReadGuidNullable("vcode").ToString()),
    lcode = (dr.ReadGuidNullable("lcode") == null ? null : dr.ReadGuidNullable("lcode").ToString()),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_PM_UserInfoApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_PM_UserInfoApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    UserID = reader.ReadString("UserID"),
    UserLoginName = reader.ReadString("UserLoginName"),
    UserGroupID = reader.ReadString("UserGroupID"),
    SubjectID = reader.ReadString("SubjectID"),
    UserNickName = reader.ReadString("UserNickName"),
    Password = reader.ReadString("Password"),
    XB = reader.ReadString("XB"),
    MZ = reader.ReadString("MZ"),
    ZZMM = reader.ReadString("ZZMM"),
    SFZH = reader.ReadString("SFZH"),
    SJH = reader.ReadString("SJH"),
    BGDH = reader.ReadString("BGDH"),
    JTDH = reader.ReadString("JTDH"),
    Email = reader.ReadString("Email"),
    QQH = reader.ReadString("QQH"),
    LoginTime = reader.ReadDateTimeNullable(fromImportDataSet ? "LoginTime" : "LoginTime"),
    LastLoginIP = reader.ReadString("LastLoginIP"),
    LastLoginDate = reader.ReadDateTimeNullable(fromImportDataSet ? "LastLoginDate" : "LastLoginDate"),
    LoginTimes = reader.ReadInt32Nullable(fromImportDataSet ? "LoginTimes" : "LoginTimes"),
    UserStatus = reader.ReadString("UserStatus"),
    vcode = (reader.ReadGuidNullable(fromImportDataSet ? "vcode" : "vcode") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "vcode" : "vcode").ToString()),
    lcode = (reader.ReadGuidNullable(fromImportDataSet ? "lcode" : "lcode") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "lcode" : "lcode").ToString()),
    
                };
            }
            return null;
        }

        #endregion
        
        private DataTable GetImportColumn(DataTable dt)
        {

            return dt;
        }

    }
}

  
