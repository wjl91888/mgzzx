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
    /// T_PM_UserInfo������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_PM_UserInfoApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// �û����UserID
        /// </summary>
        /// <value>UserID</value>
        public String UserID { get; set; }
    
        /// <summary>
        /// �û���UserLoginName
        /// </summary>
        /// <value>UserLoginName</value>
        public String UserLoginName { get; set; }
    
        /// <summary>
        /// �û���UserGroupID
        /// </summary>
        /// <value>UserGroupID</value>
        public String UserGroupID { get; set; }
    
        /// <summary>
        /// ������λSubjectID
        /// </summary>
        /// <value>SubjectID</value>
        public String SubjectID { get; set; }
    
        /// <summary>
        /// ����UserNickName
        /// </summary>
        /// <value>UserNickName</value>
        public String UserNickName { get; set; }
    
        /// <summary>
        /// ����Password
        /// </summary>
        /// <value>Password</value>
        public String Password { get; set; }
    
        /// <summary>
        /// �Ա�XB
        /// </summary>
        /// <value>XB</value>
        public String XB { get; set; }
    
        /// <summary>
        /// ����MZ
        /// </summary>
        /// <value>MZ</value>
        public String MZ { get; set; }
    
        /// <summary>
        /// ������òZZMM
        /// </summary>
        /// <value>ZZMM</value>
        public String ZZMM { get; set; }
    
        /// <summary>
        /// ���֤��SFZH
        /// </summary>
        /// <value>SFZH</value>
        public String SFZH { get; set; }
    
        /// <summary>
        /// �ֻ�SJH
        /// </summary>
        /// <value>SJH</value>
        public String SJH { get; set; }
    
        /// <summary>
        /// �칫�绰BGDH
        /// </summary>
        /// <value>BGDH</value>
        public String BGDH { get; set; }
    
        /// <summary>
        /// ��ͥ�绰JTDH
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
        /// ��¼ʱ��LoginTime
        /// </summary>
        /// <value>LoginTime</value>
        public DateTime? LoginTime { get; set; }
    
        /// <summary>
        /// ��¼IPLastLoginIP
        /// </summary>
        /// <value>LastLoginIP</value>
        public String LastLoginIP { get; set; }
    
        /// <summary>
        /// �ϴ�ʱ��LastLoginDate
        /// </summary>
        /// <value>LastLoginDate</value>
        public DateTime? LastLoginDate { get; set; }
    
        /// <summary>
        /// ��¼����LoginTimes
        /// </summary>
        /// <value>LoginTimes</value>
        public Int32? LoginTimes { get; set; }
    
        /// <summary>
        /// �û�״̬UserStatus
        /// </summary>
        /// <value>UserStatus</value>
        public String UserStatus { get; set; }
    
        /// <summary>
        /// ��֤��vcode
        /// </summary>
        /// <value>vcode</value>
        public String vcode { get; set; }
    
        /// <summary>
        /// ��¼��lcode
        /// </summary>
        /// <value>lcode</value>
        public String lcode { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// �û����UserIDBatch
        /// </summary>
        /// <value>UserID</value>
        public String UserIDBatch { get; set; }

        /// <summary>
        /// �û���UserLoginNameBatch
        /// </summary>
        /// <value>UserLoginName</value>
        public String UserLoginNameBatch { get; set; }

        /// <summary>
        /// �û���UserGroupIDBatch
        /// </summary>
        /// <value>UserGroupID</value>
        public String UserGroupIDBatch { get; set; }

        /// <summary>
        /// ������λSubjectIDBatch
        /// </summary>
        /// <value>SubjectID</value>
        public String SubjectIDBatch { get; set; }

        /// <summary>
        /// ����UserNickNameBatch
        /// </summary>
        /// <value>UserNickName</value>
        public String UserNickNameBatch { get; set; }

        /// <summary>
        /// ����PasswordBatch
        /// </summary>
        /// <value>Password</value>
        public String PasswordBatch { get; set; }

        /// <summary>
        /// �Ա�XBBatch
        /// </summary>
        /// <value>XB</value>
        public String XBBatch { get; set; }

        /// <summary>
        /// ����MZBatch
        /// </summary>
        /// <value>MZ</value>
        public String MZBatch { get; set; }

        /// <summary>
        /// ������òZZMMBatch
        /// </summary>
        /// <value>ZZMM</value>
        public String ZZMMBatch { get; set; }

        /// <summary>
        /// ���֤��SFZHBatch
        /// </summary>
        /// <value>SFZH</value>
        public String SFZHBatch { get; set; }

        /// <summary>
        /// �ֻ�SJHBatch
        /// </summary>
        /// <value>SJH</value>
        public String SJHBatch { get; set; }

        /// <summary>
        /// �칫�绰BGDHBatch
        /// </summary>
        /// <value>BGDH</value>
        public String BGDHBatch { get; set; }

        /// <summary>
        /// ��ͥ�绰JTDHBatch
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
        /// ��¼ʱ��LoginTimeBatch
        /// </summary>
        /// <value>LoginTime</value>
        public String LoginTimeBatch { get; set; }

        /// <summary>
        /// ��¼IPLastLoginIPBatch
        /// </summary>
        /// <value>LastLoginIP</value>
        public String LastLoginIPBatch { get; set; }

        /// <summary>
        /// �ϴ�ʱ��LastLoginDateBatch
        /// </summary>
        /// <value>LastLoginDate</value>
        public String LastLoginDateBatch { get; set; }

        /// <summary>
        /// ��¼����LoginTimesBatch
        /// </summary>
        /// <value>LoginTimes</value>
        public String LoginTimesBatch { get; set; }

        /// <summary>
        /// �û�״̬UserStatusBatch
        /// </summary>
        /// <value>UserStatus</value>
        public String UserStatusBatch { get; set; }

        /// <summary>
        /// ��֤��vcodeBatch
        /// </summary>
        /// <value>vcode</value>
        public String vcodeBatch { get; set; }

        /// <summary>
        /// ��¼��lcodeBatch
        /// </summary>
        /// <value>lcode</value>
        public String lcodeBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// �û������������UserIDValue
        /// </summary>
        /// <value>UserIDValue</value>
        public String UserIDValue { get; set; }
    
        /// <summary>
        /// �û�����������UserLoginNameValue
        /// </summary>
        /// <value>UserLoginNameValue</value>
        public String UserLoginNameValue { get; set; }
    
        /// <summary>
        /// �û�����������UserGroupIDValue
        /// </summary>
        /// <value>UserGroupIDValue</value>
        public String UserGroupIDValue { get; set; }
    
        /// <summary>
        /// ������λ��������SubjectIDValue
        /// </summary>
        /// <value>SubjectIDValue</value>
        public String SubjectIDValue { get; set; }
    
        /// <summary>
        /// ������������UserNickNameValue
        /// </summary>
        /// <value>UserNickNameValue</value>
        public String UserNickNameValue { get; set; }
    
        /// <summary>
        /// ������������PasswordValue
        /// </summary>
        /// <value>PasswordValue</value>
        public String PasswordValue { get; set; }
    
        /// <summary>
        /// �Ա���������XBValue
        /// </summary>
        /// <value>XBValue</value>
        public String XBValue { get; set; }
    
        /// <summary>
        /// ������������MZValue
        /// </summary>
        /// <value>MZValue</value>
        public String MZValue { get; set; }
    
        /// <summary>
        /// ������ò��������ZZMMValue
        /// </summary>
        /// <value>ZZMMValue</value>
        public String ZZMMValue { get; set; }
    
        /// <summary>
        /// ���֤����������SFZHValue
        /// </summary>
        /// <value>SFZHValue</value>
        public String SFZHValue { get; set; }
    
        /// <summary>
        /// �ֻ���������SJHValue
        /// </summary>
        /// <value>SJHValue</value>
        public String SJHValue { get; set; }
    
        /// <summary>
        /// �칫�绰��������BGDHValue
        /// </summary>
        /// <value>BGDHValue</value>
        public String BGDHValue { get; set; }
    
        /// <summary>
        /// ��ͥ�绰��������JTDHValue
        /// </summary>
        /// <value>JTDHValue</value>
        public String JTDHValue { get; set; }
    
        /// <summary>
        /// Email��������EmailValue
        /// </summary>
        /// <value>EmailValue</value>
        public String EmailValue { get; set; }
    
        /// <summary>
        /// QQ��������QQHValue
        /// </summary>
        /// <value>QQHValue</value>
        public String QQHValue { get; set; }
    
        /// <summary>
        /// ��¼ʱ����������LoginTimeValue
        /// </summary>
        /// <value>LoginTimeValue</value>
        public DateTime? LoginTimeValue { get; set; }
    
        /// <summary>
        /// ��¼IP��������LastLoginIPValue
        /// </summary>
        /// <value>LastLoginIPValue</value>
        public String LastLoginIPValue { get; set; }
    
        /// <summary>
        /// �ϴ�ʱ����������LastLoginDateValue
        /// </summary>
        /// <value>LastLoginDateValue</value>
        public DateTime? LastLoginDateValue { get; set; }
    
        /// <summary>
        /// ��¼������������LoginTimesValue
        /// </summary>
        /// <value>LoginTimesValue</value>
        public Int32? LoginTimesValue { get; set; }
    
        /// <summary>
        /// �û�״̬��������UserStatusValue
        /// </summary>
        /// <value>UserStatusValue</value>
        public String UserStatusValue { get; set; }
    
        /// <summary>
        /// ��֤����������vcodeValue
        /// </summary>
        /// <value>vcodeValue</value>
        public String vcodeValue { get; set; }
    
        /// <summary>
        /// ��¼����������lcodeValue
        /// </summary>
        /// <value>lcodeValue</value>
        public String lcodeValue { get; set; }
        
        #endregion
        #region һ��һ��ر�

        #endregion
        #region ��������
        /// <summary>
        /// ResultSet
        /// </summary>
        private DataSet m_ResultSet = new DataSet();

        /// <summary>
        /// ��ѯ���ؽ����ResultSet
        /// </summary>
        /// <value>ResultSet</value>
        public DataSet ResultSet
        {
            get { return m_ResultSet; }
            set { m_ResultSet = value; }
        }

        /// <summary>
        /// ��ѯ��ʽQueryType
        /// </summary>
        /// <value>QueryType</value>
        public String QueryType { get; set; }

        /// <summary>
        /// ��ѯ�ֶ�QueryField
        /// </summary>
        /// <value>QueryField</value>
        public String QueryField { get; set; }

        /// <summary>
        /// ��ѯ�ؼ���QueryKeywords
        /// </summary>
        /// <value>QueryKeywords</value>
        public String QueryKeywords { get; set; }

        /// <summary>
        /// ��ѯ����ʽSort
        /// </summary>
        /// <value>Sort</value>
        public Boolean Sort { get; set; }

        /// <summary>
        /// ��ѯ����ؼ���SortField
        /// </summary>
        /// <value>SortField</value>
        public String SortField { get; set; }

        /// <summary>
        /// ͳ�Ƽ�¼���ֶ�CountField
        /// </summary>
        /// <value>CountField</value>
        public String CountField { get; set; }

        /// <summary>
        /// ��ѯÿҳ��¼��PageSize
        /// </summary>
        /// <value>PageSize</value>
        public Int32 PageSize { get; set; }

        /// <summary>
        /// ��ѯ��ǰҳ��CurrentPage
        /// </summary>
        /// <value>CurrentPage</value>
        public Int32 CurrentPage { get; set; }

        /// <summary>
        /// ��ѯ��¼��RecordCount
        /// </summary>
        /// <value>RecordCount</value>
        public Int32 RecordCount { get; set; }

        /// <summary>
        /// ��Ч��¼��ValidRecordCount
        /// </summary>
        /// <value>ValidRecordCount</value>
        public Int32 ValidRecordCount { get; set; }

        /// <summary>
        /// ��Ч��¼ƽ��ֵAvgValue
        /// </summary>
        /// <value>AvgValue</value>
        public Double AvgValue { get; set; }

        /// <summary>
        /// ��Ч��¼���SumValue
        /// </summary>
        /// <value>SumValue</value>
        public Double SumValue { get; set; }
		
        /// <summary>
        /// ���ֵMaxValue
        /// </summary>
        /// <value>MaxValue</value>
        public object MaxValue { get; set; }

        /// <summary>
        /// ��СֵMinValue
        /// </summary>
        /// <value>MinValue</value>
        public Int32 MinValue { get; set; }

        /// <summary>
        /// �������ResultCode
        /// </summary>
        /// <value>ResultCode</value>
        public ResultState ResultCode { get; set; }

        /// <summary>
        /// ��Ϣ����MessageCode
        /// </summary>
        /// <value>MessageCode</value>
        public string[] MessageCode { get; set; }
        
        /// <summary>
        /// ���ݿ������ʽ����OPCode
        /// </summary>
        /// <value>OPCode</value>
        public OPType OPCode { get; set; }
        #endregion

        #region ����ʵ����в���
        /// <summary>
        /// �����б�
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
        /// ȡ�������б�
        /// </summary>
        /// <returns>�����б�</returns>
        //=====================================================================
        public override string[] GetColumnName()
        {
            return columnList;
        }

        /// <summary>
        /// �����������б�
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
        /// ȡ�������������б�
        /// </summary>
        /// <returns>�����������б�</returns>
        //=====================================================================
        public override SqlDbType[] GetColumnType()
        {
            return columnTypeList;
        }

        /// <summary>
        /// �����б�
        /// </summary>
        private static string[] primaryKeyList 
                = new string[] {
                              "UserID"
                                };

        //=====================================================================
        //  FunctionName : GetPrimaryKey
        /// <summary>
        /// ȡ�������б�
        /// </summary>
        /// <returns>�����б�</returns>
        //=====================================================================
        public override string[] GetPrimaryKey()
        {
            return primaryKeyList;
        }

        /// <summary>
        /// ����ΪNull���������б�
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
        /// ȡ������ΪNull���������б�
        /// </summary>
        /// <returns>����ΪNull���������б�</returns>
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

  
