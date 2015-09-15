/****************************************************** 
FileName:ShortMessageApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.ShortMessage
{
    //=========================================================================
    //  ClassName : ShortMessageApplicationData
    /// <summary>
    /// ShortMessage的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class ShortMessageApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 标题DXXBT
        /// </summary>
        /// <value>DXXBT</value>
        public String DXXBT { get; set; }
    
        /// <summary>
        /// 类型DXXLX
        /// </summary>
        /// <value>DXXLX</value>
        public String DXXLX { get; set; }
    
        /// <summary>
        /// 内容DXXNR
        /// </summary>
        /// <value>DXXNR</value>
        public String DXXNR { get; set; }
    
        /// <summary>
        /// 附件DXXFJ
        /// </summary>
        /// <value>DXXFJ</value>
        public String DXXFJ { get; set; }
    
        /// <summary>
        /// 发送时间FSSJ
        /// </summary>
        /// <value>FSSJ</value>
        public DateTime? FSSJ { get; set; }
    
        /// <summary>
        /// 发送时间开始FSSJBegin
        /// </summary>
        /// <value>FSSJBegin</value>
        public DateTime? FSSJBegin { get; set; }

        /// <summary>
        /// 发送时间结束FSSJEnd
        /// </summary>
        /// <value>FSSJEnd</value>
        public DateTime? FSSJEnd { get; set; }
    
        /// <summary>
        /// 发送人FSR
        /// </summary>
        /// <value>FSR</value>
        public String FSR { get; set; }
    
        /// <summary>
        /// 发送部门FSBM
        /// </summary>
        /// <value>FSBM</value>
        public String FSBM { get; set; }
    
        /// <summary>
        /// 发送IPFSIP
        /// </summary>
        /// <value>FSIP</value>
        public String FSIP { get; set; }
    
        /// <summary>
        /// 接收人JSR
        /// </summary>
        /// <value>JSR</value>
        public String JSR { get; set; }
    
        /// <summary>
        /// 查看状态SFCK
        /// </summary>
        /// <value>SFCK</value>
        public Boolean? SFCK { get; set; }
    
        /// <summary>
        /// 查看时间CKSJ
        /// </summary>
        /// <value>CKSJ</value>
        public DateTime? CKSJ { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 标题DXXBTBatch
        /// </summary>
        /// <value>DXXBT</value>
        public String DXXBTBatch { get; set; }

        /// <summary>
        /// 类型DXXLXBatch
        /// </summary>
        /// <value>DXXLX</value>
        public String DXXLXBatch { get; set; }

        /// <summary>
        /// 内容DXXNRBatch
        /// </summary>
        /// <value>DXXNR</value>
        public String DXXNRBatch { get; set; }

        /// <summary>
        /// 附件DXXFJBatch
        /// </summary>
        /// <value>DXXFJ</value>
        public String DXXFJBatch { get; set; }

        /// <summary>
        /// 发送时间FSSJBatch
        /// </summary>
        /// <value>FSSJ</value>
        public String FSSJBatch { get; set; }

        /// <summary>
        /// 发送人FSRBatch
        /// </summary>
        /// <value>FSR</value>
        public String FSRBatch { get; set; }

        /// <summary>
        /// 发送部门FSBMBatch
        /// </summary>
        /// <value>FSBM</value>
        public String FSBMBatch { get; set; }

        /// <summary>
        /// 发送IPFSIPBatch
        /// </summary>
        /// <value>FSIP</value>
        public String FSIPBatch { get; set; }

        /// <summary>
        /// 接收人JSRBatch
        /// </summary>
        /// <value>JSR</value>
        public String JSRBatch { get; set; }

        /// <summary>
        /// 查看状态SFCKBatch
        /// </summary>
        /// <value>SFCK</value>
        public String SFCKBatch { get; set; }

        /// <summary>
        /// 查看时间CKSJBatch
        /// </summary>
        /// <value>CKSJ</value>
        public String CKSJBatch { get; set; }

        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 标题批量更新DXXBTValue
        /// </summary>
        /// <value>DXXBTValue</value>
        public String DXXBTValue { get; set; }
    
        /// <summary>
        /// 类型批量更新DXXLXValue
        /// </summary>
        /// <value>DXXLXValue</value>
        public String DXXLXValue { get; set; }
    
        /// <summary>
        /// 内容批量更新DXXNRValue
        /// </summary>
        /// <value>DXXNRValue</value>
        public String DXXNRValue { get; set; }
    
        /// <summary>
        /// 附件批量更新DXXFJValue
        /// </summary>
        /// <value>DXXFJValue</value>
        public String DXXFJValue { get; set; }
    
        /// <summary>
        /// 发送时间批量更新FSSJValue
        /// </summary>
        /// <value>FSSJValue</value>
        public DateTime? FSSJValue { get; set; }
    
        /// <summary>
        /// 发送人批量更新FSRValue
        /// </summary>
        /// <value>FSRValue</value>
        public String FSRValue { get; set; }
    
        /// <summary>
        /// 发送部门批量更新FSBMValue
        /// </summary>
        /// <value>FSBMValue</value>
        public String FSBMValue { get; set; }
    
        /// <summary>
        /// 发送IP批量更新FSIPValue
        /// </summary>
        /// <value>FSIPValue</value>
        public String FSIPValue { get; set; }
    
        /// <summary>
        /// 接收人批量更新JSRValue
        /// </summary>
        /// <value>JSRValue</value>
        public String JSRValue { get; set; }
    
        /// <summary>
        /// 查看状态批量更新SFCKValue
        /// </summary>
        /// <value>SFCKValue</value>
        public Boolean? SFCKValue { get; set; }
    
        /// <summary>
        /// 查看时间批量更新CKSJValue
        /// </summary>
        /// <value>CKSJValue</value>
        public DateTime? CKSJValue { get; set; }
        
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
                              ,"DXXBT"
                              ,"DXXLX"
                              ,"DXXNR"
                              ,"DXXFJ"
                              ,"FSSJ"
                              ,"FSR"
                              ,"FSBM"
                              ,"FSIP"
                              ,"JSR"
                              ,"SFCK"
                              ,"CKSJ"
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
                              ,SqlDbType.DateTime
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.Bit
                              ,SqlDbType.DateTime
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
                              "ObjectID"
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
                              "DXXLX"
                              ,"DXXNR"
                              ,"DXXFJ"
                              ,"FSSJ"
                              ,"FSR"
                              ,"FSBM"
                              ,"FSIP"
                              ,"SFCK"
                              ,"CKSJ"
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

        public static IEnumerable<ShortMessageApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<ShortMessageApplicationData> collection = new List<ShortMessageApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                ShortMessageApplicationData applicationData = new ShortMessageApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    DXXBT = dr.ReadString("DXXBT"),
    DXXLX = dr.ReadString("DXXLX"),
    DXXNR = dr.ReadString("DXXNR"),
    DXXFJ = dr.ReadString("DXXFJ"),
    FSSJ = dr.ReadDateTimeNullable("FSSJ"),
    FSR = dr.ReadString("FSR"),
    FSBM = dr.ReadString("FSBM"),
    FSIP = dr.ReadString("FSIP"),
    JSR = dr.ReadString("JSR"),
    SFCK = dr.ReadBooleanNullable("SFCK"),
    CKSJ = dr.ReadDateTimeNullable("CKSJ"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static ShortMessageApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new ShortMessageApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    DXXBT = reader.ReadString("DXXBT"),
    DXXLX = reader.ReadString("DXXLX"),
    DXXNR = reader.ReadString("DXXNR"),
    DXXFJ = reader.ReadString("DXXFJ"),
    FSSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "FSSJ" : "FSSJ"),
    FSR = reader.ReadString("FSR"),
    FSBM = reader.ReadString("FSBM"),
    FSIP = reader.ReadString("FSIP"),
    JSR = reader.ReadString("JSR"),
    SFCK = reader.ReadBooleanNullable(fromImportDataSet ? "SFCK" : "SFCK"),
    CKSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "CKSJ" : "CKSJ"),
    
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

  
