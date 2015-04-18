<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" encoding="GB2312"/>
  <xsl:variable name="FileName" select="'ApplicationData.cs.xsl'"/>
  <xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>
{
    //=========================================================================
    //  ClassName : <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData
    /// <summary>
    /// <xsl:value-of select="/NewDataSet/TableName"/>的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData : ApplicationDataBase
    {
        #region 主表
<xsl:for-each select="/NewDataSet/RecordInfo">
        /// <summary>
        /// <xsl:value-of select="FieldRemark"/><xsl:value-of select="FieldName"/>
        /// </summary>
        /// <value><xsl:value-of select="FieldName"/></value>
  <xsl:choose>
    <xsl:when test="FieldType = 'DateTime'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/> { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Byte'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/> { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Int16'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/> { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Int32'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/> { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Int64'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/> { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Single'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/> { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Money'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/> { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Double'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/> { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Decimal'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/> { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Boolean'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/> { get; set; }
    </xsl:when>
    <xsl:otherwise>
        public <xsl:value-of select="FieldType"/><xsl:value-of select="' '"/><xsl:value-of select="FieldName"/> { get; set; }
    </xsl:otherwise>
  </xsl:choose>
  <xsl:choose>
    <xsl:when test="IsRangeSearch = 'true'">
        /// <summary>
        /// <xsl:value-of select="FieldRemark"/>开始<xsl:value-of select="FieldName"/>Begin
        /// </summary>
        /// <value><xsl:value-of select="FieldName"/>Begin</value>
        public <xsl:value-of select="FieldType"/><xsl:if test="IsString = 'false'">?</xsl:if><xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Begin { get; set; }

        /// <summary>
        /// <xsl:value-of select="FieldRemark"/>结束<xsl:value-of select="FieldName"/>End
        /// </summary>
        /// <value><xsl:value-of select="FieldName"/>End</value>
        public <xsl:value-of select="FieldType"/><xsl:if test="IsString = 'false'">?</xsl:if><xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>End { get; set; }
    </xsl:when>
  </xsl:choose>
</xsl:for-each>    

<xsl:for-each select="/NewDataSet/RecordInfo">
        /// <summary>
        /// <xsl:value-of select="FieldRemark"/><xsl:value-of select="FieldName"/>Batch
        /// </summary>
        /// <value><xsl:value-of select="FieldName"/></value>
        public String<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Batch { get; set; }
</xsl:for-each>    

<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsSum = 'true'">  
        /// <summary>
        /// <xsl:value-of select="FieldRemark"/>聚合求和<xsl:value-of select="FieldName"/>Sum
        /// </summary>
        /// <value><xsl:value-of select="FieldName"/>Sum</value>
        public <xsl:value-of select="FieldType"/><xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Sum { get; set; }
    </xsl:if>
</xsl:for-each>    

<xsl:for-each select="/NewDataSet/RecordInfo">
        /// <summary>
        /// <xsl:value-of select="FieldRemark"/>批量更新<xsl:value-of select="FieldName"/>Value
        /// </summary>
        /// <value><xsl:value-of select="FieldName"/>Value</value>
  <xsl:choose>
    <xsl:when test="FieldType = 'DateTime'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Value { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Byte'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Value { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Int16'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Value { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Int32'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Value { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Int64'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Value { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Single'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Value { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Money'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Value { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Double'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Value { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Decimal'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Value { get; set; }
    </xsl:when>
    <xsl:when test="FieldType = 'Boolean'">
        public <xsl:value-of select="FieldType"/>?<xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Value { get; set; }
    </xsl:when>
    <xsl:otherwise>
        public <xsl:value-of select="FieldType"/><xsl:value-of select="' '"/><xsl:value-of select="FieldName"/>Value { get; set; }
    </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>    
        #endregion
        #region 一对一相关表
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
    <xsl:if test="RelatedTableType = '1_to_1'">
        <xsl:if test="IsAdvanceSearch = 'true'">  
            <xsl:choose>
                <xsl:when test="IsRangeSearch = 'true'">
        /// <summary>
        /// <xsl:value-of select="DisplayName"/><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>
        /// </summary>
        /// <value><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/></value>
        public String<xsl:value-of select="' '"/><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> { get; set; }
 
        /// <summary>
        /// <xsl:value-of select="DisplayName"/>开始<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin
        /// </summary>
        /// <value><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin</value>
        public String<xsl:value-of select="' '"/><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin { get; set; }

        /// <summary>
        /// <xsl:value-of select="DisplayName"/>结束<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End
        /// </summary>
        /// <value><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End</value>
        public String<xsl:value-of select="' '"/><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End { get; set; }
                </xsl:when>
                <xsl:otherwise>
        /// <summary>
        /// <xsl:value-of select="DisplayName"/><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>
        /// </summary>
        /// <value><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/></value>
        public String<xsl:value-of select="' '"/><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> { get; set; }
                </xsl:otherwise>
            </xsl:choose>
        /// <summary>
        /// <xsl:value-of select="DisplayName"/><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch
        /// </summary>
        /// <value><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/></value>
        public String<xsl:value-of select="' '"/><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch { get; set; }
        </xsl:if>
    </xsl:if>
</xsl:for-each>
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
                              <xsl:for-each select="/NewDataSet/RecordInfo">
                                <xsl:choose>
                                  <xsl:when test="position() = 1">"<xsl:value-of select="FieldName"/>"</xsl:when>
                                  <xsl:otherwise>
                              ,"<xsl:value-of select="FieldName"/>"</xsl:otherwise>
                                </xsl:choose></xsl:for-each>
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
                              <xsl:for-each select="/NewDataSet/RecordInfo">
                                <xsl:choose>
                                  <xsl:when test="position() = 1">SqlDbType.<xsl:value-of select="DBType"/>
                                  </xsl:when>
                                  <xsl:otherwise>
                              ,SqlDbType.<xsl:value-of select="DBType"/>
                                  </xsl:otherwise>
                                </xsl:choose></xsl:for-each>
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
                              <xsl:for-each select="/NewDataSet/RecordInfo">
                                <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
                                <xsl:if test="IsPrimaryKey = 'true'">
                                  <xsl:choose>
                                  <xsl:when test="position() = 1">"<xsl:value-of select="FieldName"/>"</xsl:when>
                                  <xsl:otherwise>
                              ,"<xsl:value-of select="FieldName"/>"</xsl:otherwise>
                                  </xsl:choose></xsl:if></xsl:for-each>
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
                              <xsl:for-each select="/NewDataSet/RecordInfo">
                                <xsl:sort data-type="text" order="descending" select="IsNull"/>
                                <xsl:if test="IsNull = 'true'">
                                  <xsl:choose>
                                  <xsl:when test="position() = 1">"<xsl:value-of select="FieldName"/>"</xsl:when>
                                  <xsl:otherwise>
                              ,"<xsl:value-of select="FieldName"/>"</xsl:otherwise>
                                  </xsl:choose></xsl:if></xsl:for-each>
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

<![CDATA[        public static IEnumerable<]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[ApplicationData> GetCollectionFromImportDataTable(DataTable dt)]]>
<![CDATA[        {]]>
<![CDATA[            List<]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[ApplicationData> collection = new List<]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[ApplicationData>();]]>
<![CDATA[            foreach (DataRow dr in dt.Rows)]]>
<![CDATA[            {]]>
<![CDATA[                ]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[ApplicationData applicationData = new ]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[ApplicationData()]]>
<![CDATA[                {]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="DBType = 'UniqueIdentifier'">
                    <xsl:value-of select="FieldName"/> = (dr.ReadGuidNullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>") == null ? null : dr.ReadGuidNullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>").ToString()),
    </xsl:when>
    <xsl:when test="FieldType = 'DateTime'">
                    <xsl:value-of select="FieldName"/> = dr.ReadDateTimeNullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Byte'">
                    <xsl:value-of select="FieldName"/> = dr.ReadByteNullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Int16'">
                    <xsl:value-of select="FieldName"/> = dr.ReadInt16Nullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Int32'">
                    <xsl:value-of select="FieldName"/> = dr.ReadInt32Nullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Int64'">
                    <xsl:value-of select="FieldName"/> = dr.ReadInt64Nullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Single'">
                    <xsl:value-of select="FieldName"/> = dr.ReadSingleNullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Money'">
                    <xsl:value-of select="FieldName"/> = dr.ReadMoneyNullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Double'">
                    <xsl:value-of select="FieldName"/> = dr.ReadDoubleNullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Decimal'">
                    <xsl:value-of select="FieldName"/> = dr.ReadDecimalNullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Boolean'">
                    <xsl:value-of select="FieldName"/> = dr.ReadBooleanNullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Byte[]'">
                    <xsl:value-of select="FieldName"/> = dr.ReadBytesNullable("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:when>
    <xsl:otherwise>
                    <xsl:value-of select="FieldName"/> = dr.Read<xsl:value-of select="FieldType"/>("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>"),
    </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>
<![CDATA[                };]]>
<![CDATA[                collection.Add(applicationData);]]>
<![CDATA[            }]]>
<![CDATA[            return collection;]]>
<![CDATA[        }]]>

		internal static <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData
                {
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="DBType = 'UniqueIdentifier'">
                    <xsl:value-of select="FieldName"/> = (reader.ReadGuidNullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>").ToString()),
    </xsl:when>
    <xsl:when test="FieldType = 'DateTime'">
                    <xsl:value-of select="FieldName"/> = reader.ReadDateTimeNullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Byte'">
                    <xsl:value-of select="FieldName"/> = reader.ReadByteNullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Int16'">
                    <xsl:value-of select="FieldName"/> = reader.ReadInt16Nullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Int32'">
                    <xsl:value-of select="FieldName"/> = reader.ReadInt32Nullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Int64'">
                    <xsl:value-of select="FieldName"/> = reader.ReadInt64Nullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Single'">
                    <xsl:value-of select="FieldName"/> = reader.ReadSingleNullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Money'">
                    <xsl:value-of select="FieldName"/> = reader.ReadMoneyNullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Double'">
                    <xsl:value-of select="FieldName"/> = reader.ReadDoubleNullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Decimal'">
                    <xsl:value-of select="FieldName"/> = reader.ReadDecimalNullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Boolean'">
                    <xsl:value-of select="FieldName"/> = reader.ReadBooleanNullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>"),
    </xsl:when>
    <xsl:when test="FieldType = 'Byte[]'">
                    <xsl:value-of select="FieldName"/> = reader.ReadBytesNullable(fromImportDataSet ? "<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>" : "<xsl:value-of select="FieldName"/>"),
    </xsl:when>
    <xsl:otherwise>
                    <xsl:value-of select="FieldName"/> = reader.Read<xsl:value-of select="FieldType"/>("<xsl:value-of select="FieldName"/>"),
    </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>
                };
            }
            return null;
        }

        #endregion
        
        private DataTable GetImportColumn(DataTable dt)
        {
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsFromDataSet = 'true'">
            dt.Columns.Add("<xsl:choose><xsl:when test="DataSetMapColumnName"><xsl:value-of select="DataSetMapColumnName"/></xsl:when><xsl:otherwise><xsl:value-of select="FieldName"/></xsl:otherwise></xsl:choose>", Type.GetType("System.<xsl:value-of select="FieldType"/>"));</xsl:if>  
</xsl:for-each>
            return dt;
        }

    }
}

  </xsl:template>
</xsl:stylesheet>