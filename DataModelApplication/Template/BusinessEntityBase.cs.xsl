<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" encoding="GB2312"/>
  <xsl:variable name="FileName" select="'BusinessEntityBase.cs.xsl'"/>
  <xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntityBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using RICH.Common;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.BusinessEntity;

namespace  RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>
{
    //=========================================================================
    //  ClassName : <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntityBase
    /// <summary>
    /// <xsl:value-of select="/NewDataSet/TableName"/>的逻辑实体类
    /// </summary>
    //=========================================================================
    public class <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntityBase : BusinessEntityBase
    {
        #region 数据实体
        /// <summary>
        /// AppData
        /// </summary>
        private <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData m_AppData;

        /// <summary>
        /// 取得设定AppData
        /// </summary>
        /// <value>AppData</value>
        public <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData AppData
        {
            get { return m_AppData; }
            set { m_AppData = value; }
        }
        #endregion

        #region 对对应的数据实体进行数据库操作
        //=====================================================================
        //  FunctionName : Insert
        /// <summary>
        /// 插入记录
        /// </summary>
        //=====================================================================
        public override void Insert()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Insert<xsl:value-of select="/NewDataSet/TableName"/>";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
<xsl:for-each select="/NewDataSet/RecordInfo"><xsl:choose><xsl:when test="FieldType = 'Byte[]'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.Binary);</xsl:when><xsl:otherwise>
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);</xsl:otherwise></xsl:choose></xsl:for-each>
            // 对存储过程参数赋值
<xsl:for-each select="/NewDataSet/RecordInfo">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);</xsl:for-each>
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }
        
        //=====================================================================
        //  FunctionName : UpdateByAnyCondition
        /// <summary>
        /// 以任意条件更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByAnyCondition()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            <xsl:for-each select="/NewDataSet/RecordInfo">
          <xsl:choose>
              <xsl:when test="FieldType = 'Byte[]'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.Binary);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", DbType.String); 
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Value", DbType.Binary);
              </xsl:when><xsl:otherwise>
              <xsl:choose>
                <xsl:when test="IsRangeSearch = 'true'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Begin", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>End", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", DbType.String);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Value", DbType.<xsl:value-of select="FieldType"/>);
                </xsl:when>
                <xsl:otherwise>
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", DbType.String);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Value", DbType.<xsl:value-of select="FieldType"/>);
                </xsl:otherwise>
              </xsl:choose>
              </xsl:otherwise>
          </xsl:choose>
            </xsl:for-each>
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            <xsl:for-each select="/NewDataSet/RecordInfo">
              <xsl:choose>
                <xsl:when test="IsRangeSearch = 'true'">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Begin", AppData.<xsl:value-of select="FieldName"/>Begin);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>End", AppData.<xsl:value-of select="FieldName"/>End);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", AppData.<xsl:value-of select="FieldName"/>Batch);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Value", AppData.<xsl:value-of select="FieldName"/>Value);
                </xsl:when>
                <xsl:otherwise>
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", AppData.<xsl:value-of select="FieldName"/>Batch);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Value", AppData.<xsl:value-of select="FieldName"/>Value);
                </xsl:otherwise>
              </xsl:choose>
            </xsl:for-each>
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到更新的记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        }

        //=====================================================================
        //  FunctionName : UpdateByKey
        /// <summary>
        /// 以主键为条件更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
<xsl:for-each select="/NewDataSet/RecordInfo"><xsl:choose><xsl:when test="FieldType = 'Byte[]'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.Binary);</xsl:when><xsl:otherwise>
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);</xsl:otherwise></xsl:choose></xsl:for-each>
            // 对存储过程参数赋值
<xsl:for-each select="/NewDataSet/RecordInfo">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);</xsl:for-each>
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : UpdateByObjectID
        /// <summary>
        /// 以ObjectID为条件更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
<xsl:for-each select="/NewDataSet/RecordInfo"><xsl:choose><xsl:when test="FieldType = 'Byte[]'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.Binary);</xsl:when><xsl:otherwise>
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);</xsl:otherwise></xsl:choose></xsl:for-each>
            // 对存储过程参数赋值
<xsl:for-each select="/NewDataSet/RecordInfo">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);</xsl:for-each>
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : UpdateByObjectIDBatch
        /// <summary>
        /// 以ObjectID为条件批量更新记录
        /// </summary>
        //=====================================================================
        public override void UpdateByObjectIDBatch()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
<xsl:for-each select="/NewDataSet/RecordInfo"><xsl:choose><xsl:when test="FieldType = 'Byte[]'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.Binary);</xsl:when><xsl:otherwise>
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);</xsl:otherwise></xsl:choose></xsl:for-each>
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
<xsl:for-each select="/NewDataSet/RecordInfo">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);</xsl:for-each>
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : SelectByKey
        /// <summary>
        /// 以主键为条件查询记录
        /// </summary>
        //=====================================================================
        public override void SelectByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            <xsl:for-each select="/NewDataSet/RecordInfo">
            <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
            <xsl:if test="IsPrimaryKey = 'true'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);</xsl:if>
            </xsl:for-each>
            // 对存储过程参数赋值
            <xsl:for-each select="/NewDataSet/RecordInfo">
            <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
            <xsl:if test="IsPrimaryKey = 'true'">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);</xsl:if>
            </xsl:for-each>
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = AppData.ResultSet.Tables[0].Rows.Count;
        }

        //=====================================================================
        //  FunctionName : SelectByObjectID
        /// <summary>
        /// 以ObjectID为条件查询记录
        /// </summary>
        //=====================================================================
        public override void SelectByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = AppData.ResultSet.Tables[0].Rows.Count;
        }
        
        //=====================================================================
        //  FunctionName : GetDataByObjectID
        /// <summary>
        /// 以ObjectID为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData GetDataByObjectID(string strObjectID)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", strObjectID);
            // 执行存储过程
            return <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
        
        //=====================================================================
        //  FunctionName : GetDataByKey
        /// <summary>
        /// 以Key为条件查询记录并返回AppData
        /// </summary>
        //=====================================================================
        public static <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData GetDataByKey(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            <xsl:for-each select="/NewDataSet/RecordInfo">
            <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
            <xsl:if test="IsPrimaryKey = 'true'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);</xsl:if>
            </xsl:for-each>
            // 对存储过程参数赋值
            <xsl:for-each select="/NewDataSet/RecordInfo">
            <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
            <xsl:if test="IsPrimaryKey = 'true'">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", appData.<xsl:value-of select="FieldName"/>);</xsl:if>
            </xsl:for-each>
            // 执行存储过程
            return <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData.FillDataFromDataReader(db.ExecuteReader(cmdProc));
        }
		
        //=====================================================================
        //  FunctionName : SelectByAnyCondition
        /// <summary>
        /// 以任意条件查询记录
        /// </summary>
        //=====================================================================
        public override void SelectByAnyCondition()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@QueryField", DbType.String);
            db.AddInParameter(cmdProc, "@QueryType", DbType.String);
            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
            db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
            // 主表
            <xsl:for-each select="/NewDataSet/RecordInfo">
          <xsl:choose>
              <xsl:when test="FieldType = 'Byte[]'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.Binary);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", DbType.String); 
              </xsl:when><xsl:otherwise>
              <xsl:choose>
                <xsl:when test="IsRangeSearch = 'true'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Begin", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>End", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", DbType.String);
                </xsl:when>
                <xsl:otherwise>
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", DbType.String);
                </xsl:otherwise>
              </xsl:choose>
              </xsl:otherwise>
          </xsl:choose>
            </xsl:for-each>
            // 一对一相关表
            <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
                <xsl:if test="RelatedTableType = '1_to_1'">
                    <xsl:if test="IsAdvanceSearch = 'true'">
                        <xsl:choose>
                            <xsl:when test="IsRangeSearch = 'true'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>", DbType.String);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin", DbType.String);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End", DbType.String);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch", DbType.String);
                            </xsl:when>
                            <xsl:otherwise>
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>", DbType.String);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch", DbType.String);
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:if>
                </xsl:if>
            </xsl:for-each>
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
    <xsl:for-each select="/NewDataSet/RecordInfo">
        <xsl:if test="IsSum = 'true'">  
            db.AddOutParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Sum", DbType.<xsl:value-of select="FieldType"/>, <xsl:value-of select="DataSize"/>);</xsl:if>
    </xsl:for-each>    
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@QueryField", AppData.QueryField);
            db.SetParameterValue(cmdProc, "@QueryType", AppData.QueryType);
            db.SetParameterValue(cmdProc, "@Sort", AppData.Sort);
            db.SetParameterValue(cmdProc, "@SortField", AppData.SortField);
            db.SetParameterValue(cmdProc, "@PageSize", AppData.PageSize);
            db.SetParameterValue(cmdProc, "@CurrentPage", AppData.CurrentPage);
            // 主表
            <xsl:for-each select="/NewDataSet/RecordInfo">
              <xsl:choose>
                <xsl:when test="IsRangeSearch = 'true'">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Begin", AppData.<xsl:value-of select="FieldName"/>Begin);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>End", AppData.<xsl:value-of select="FieldName"/>End);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", AppData.<xsl:value-of select="FieldName"/>Batch);
                </xsl:when>
                <xsl:otherwise>
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", AppData.<xsl:value-of select="FieldName"/>Batch);
                </xsl:otherwise>
              </xsl:choose>
            </xsl:for-each>
            // 一对一相关表
            <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
                <xsl:if test="RelatedTableType = '1_to_1'">
                    <xsl:if test="IsAdvanceSearch = 'true'">
                        <xsl:choose>
                            <xsl:when test="IsRangeSearch = 'true'">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch);
                            </xsl:when>
                            <xsl:otherwise>
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch);
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:if>
                </xsl:if>
            </xsl:for-each>
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
    <xsl:for-each select="/NewDataSet/RecordInfo">
        <xsl:if test="IsSum = 'true'">
            if (db.GetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Sum") != DBNull.Value)
            {
                AppData.<xsl:value-of select="FieldName"/>Sum = (<xsl:value-of select="FieldType"/>)db.GetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Sum");
            }</xsl:if>
    </xsl:for-each>    
        }

        //=====================================================================
        //  FunctionName : DeleteByKey
        /// <summary>
        /// 以主键为条件删除记录
        /// </summary>
        //=====================================================================
        public override void DeleteByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            <xsl:for-each select="/NewDataSet/RecordInfo">
            <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
            <xsl:if test="IsPrimaryKey = 'true'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);</xsl:if>
            </xsl:for-each>
            // 对存储过程参数赋值
            <xsl:for-each select="/NewDataSet/RecordInfo">
            <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
            <xsl:if test="IsPrimaryKey = 'true'">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);</xsl:if>
            </xsl:for-each>
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : DeleteByObjectID
        /// <summary>
        /// 以ObjectID为条件删除记录
        /// </summary>
        //=====================================================================
        public override void DeleteByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : DeleteByObjectIDBatch
        /// <summary>
        /// 以ObjectID为条件批量删除记录
        /// </summary>
        //=====================================================================
        public override void DeleteByObjectIDBatch()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByObjectIDBatch";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectIDBatch", DbType.String);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectIDBatch", AppData.ObjectIDBatch);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
        }

        //=====================================================================
        //  FunctionName : IsExistByKey
        /// <summary>
        /// 以主键为条件判断记录是否存在
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByKey()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExist<xsl:value-of select="/NewDataSet/TableName"/>ByKey";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            <xsl:for-each select="/NewDataSet/RecordInfo">
            <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
            <xsl:if test="IsPrimaryKey = 'true'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);</xsl:if>
            </xsl:for-each>
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            <xsl:for-each select="/NewDataSet/RecordInfo">
            <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
            <xsl:if test="IsPrimaryKey = 'true'">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);</xsl:if>
            </xsl:for-each>
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
            if (AppData.RecordCount > 0)
            {
              return true;
            }
            else if(AppData.RecordCount == 0)
            {
              return false;
            }
            else
            {
              return false; 
            }
        }

        //=====================================================================
        //  FunctionName : IsExistByObjectID
        /// <summary>
        /// 以ObjectID为条件判断记录是否存在
        /// </summary>
        //=====================================================================
        public override Boolean IsExistByObjectID()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_IsExist<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@ObjectID", DbType.String);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@ObjectID", AppData.ObjectID);
            // 执行存储过程
            db.ExecuteNonQuery(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
            if (AppData.RecordCount > 0)
            {
              return true;
            }
            else if(AppData.RecordCount == 0)
            {
              return false;
            }
            else
            {
              return false; 
            }
        }

        //=====================================================================
        //  FunctionName : GetValueByFixCondition
        /// <summary>
        /// 以指定条件查询指定字段
        /// </summary>
        //=====================================================================
        public override object GetValueByFixCondition(string strConditionField, object strConditionValue, string strValueField, string strFixConditionField = null, object strFixConditionValue = null)
        {
            object objReturn = new object();
            StringBuilder sbReturn = new StringBuilder();
            if ((strConditionValue == DBNull.Value || strConditionValue == null) == false)
            {
                string[] strArrayConditionValue = strConditionValue.ToString().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
                bool boolFirstItem = true;
                foreach (string strValue in strArrayConditionValue)
                {
                    DataSet dsTemp = new DataSet();
                    // 创建数据库连接 
                    Database db = DatabaseFactory.CreateDatabase("strConnManager");
                    string strProcName = "SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition";
                    DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
                    // 设定存储过程输入参数
                    db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
                    db.AddInParameter(cmdProc, "@SortField", DbType.String);
                    db.AddInParameter(cmdProc, "@PageSize", DbType.Int32);
                    db.AddInParameter(cmdProc, "@CurrentPage", DbType.Int32);
        <xsl:for-each select="/NewDataSet/RecordInfo"><xsl:choose><xsl:when test="FieldType = 'Byte[]'">
                    db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.Binary);</xsl:when><xsl:otherwise>
                    db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);</xsl:otherwise></xsl:choose></xsl:for-each>
                    // 设定存储过程输出参数
                    db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            <xsl:for-each select="/NewDataSet/RecordInfo">
                <xsl:if test="IsSum = 'true'">  
                    db.AddOutParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Sum", DbType.<xsl:value-of select="FieldType"/>, <xsl:value-of select="DataSize"/>);</xsl:if>
            </xsl:for-each>    
                    // 对存储过程参数赋值
                    db.SetParameterValue(cmdProc, "@" + strConditionField, strValue);
                    if (!strFixConditionField.IsNullOrWhiteSpace())
                    {
                        if (strFixConditionField != "null")
                        {
                            db.SetParameterValue(cmdProc, "@" + strFixConditionField, strFixConditionValue);
                        }
                    }
                    // 执行存储过程
                    dsTemp = (DataSet)db.ExecuteDataSet(cmdProc);
                    if ((Int32)db.GetParameterValue(cmdProc, "@RecordCount") > 0)
                    {
                        if (boolFirstItem == false)
                        {
                            sbReturn.Append(",");
                            sbReturn.Append(dsTemp.Tables[0].Rows[0][strValueField]);
                        }
                        else if (boolFirstItem == true)
                        {
                            sbReturn.Append(dsTemp.Tables[0].Rows[0][strValueField]);
                            boolFirstItem = false;
                        }
                    }
                }
                objReturn = (object)sbReturn.ToString();
            }
            else
            {
                objReturn = (object)string.Empty;
            }
            return objReturn;
        }

        //=====================================================================
        //  FunctionName : GetMaxValue
        /// <summary>
        /// 得到指定字段的最大值
        /// </summary>
        //=====================================================================
        public override object GetMaxValue(string strPrefix)
        {
            return null;
        }
        public object GetMaxValue(string strPrefix, int intNumber)
        {
            object objReturn = new object();
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetMax<xsl:value-of select="/NewDataSet/TableName"/>By<xsl:value-of select="/NewDataSet/AutoGenerateField"/>";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@Prefix", DbType.String);
            db.AddInParameter(cmdProc, "@Number", DbType.Int32, 4);
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@MaxValue", DbType.String, 100);
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@Prefix", strPrefix);
            db.SetParameterValue(cmdProc, "@Number", intNumber);
            // 执行存储过程
            db.ExecuteDataSet(cmdProc);
            if ((int)db.GetParameterValue(cmdProc, "@RecordCount") > 0)
            {
                objReturn = db.GetParameterValue(cmdProc, "@MaxValue");
            }
            else
            {
                objReturn = (object)string.Empty;
            }
            return objReturn;
        }

        //=====================================================================
        //  FunctionName : CountByAnyCondition
        /// <summary>
        /// 以任意条件统计指定字段
        /// </summary>
        //=====================================================================
        public override void CountByAnyCondition()
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Count<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@CountField", DbType.String);
            db.AddInParameter(cmdProc, "@Sort", DbType.Boolean);
            db.AddInParameter(cmdProc, "@SortField", DbType.String);
            // 主表 
            <xsl:for-each select="/NewDataSet/RecordInfo">
                <xsl:if test="IsStatisticalCondition = 'true'">
                  <xsl:choose>
                    <xsl:when test="IsRangeSearch = 'true'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Begin", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>End", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", DbType.String);
                    </xsl:when>
                    <xsl:otherwise>
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>", DbType.<xsl:value-of select="FieldType"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", DbType.String);
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:if>
            </xsl:for-each>
            // 一对一相关表
            <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
                <xsl:if test="RelatedTableType = '1_to_1'">
                    <xsl:if test="IsAdvanceSearch = 'true'">
                        <xsl:choose>
                            <xsl:when test="IsRangeSearch = 'true'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>", DbType.String);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin", DbType.String);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End", DbType.String);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch", DbType.String);
                            </xsl:when>
                            <xsl:otherwise>
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>", DbType.String);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch", DbType.String);
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:if>
                </xsl:if>
            </xsl:for-each>
            // 设定存储过程输出参数
            db.AddOutParameter(cmdProc, "@RecordCount", DbType.Int32, 4);
            // 对存储过程参数赋值
            db.SetParameterValue(cmdProc, "@CountField", AppData.CountField);
            db.SetParameterValue(cmdProc, "@Sort", AppData.Sort);
            db.SetParameterValue(cmdProc, "@SortField", AppData.SortField);
            // 主表
            <xsl:for-each select="/NewDataSet/RecordInfo">
                <xsl:if test="IsStatisticalCondition = 'true'">
                  <xsl:choose>
                    <xsl:when test="IsRangeSearch = 'true'">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Begin", AppData.<xsl:value-of select="FieldName"/>Begin);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>End", AppData.<xsl:value-of select="FieldName"/>End);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", AppData.<xsl:value-of select="FieldName"/>Batch);
                    </xsl:when>
                    <xsl:otherwise>
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>", AppData.<xsl:value-of select="FieldName"/>);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="FieldName"/>Batch", AppData.<xsl:value-of select="FieldName"/>Batch);
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:if>
            </xsl:for-each>
            // 一对一相关表
            <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
                <xsl:if test="RelatedTableType = '1_to_1'">
                    <xsl:if test="IsAdvanceSearch = 'true'">
                        <xsl:choose>
                            <xsl:when test="IsRangeSearch = 'true'">
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch);
                            </xsl:when>
                            <xsl:otherwise>
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch", AppData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch);
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:if>
                </xsl:if>
            </xsl:for-each>
            // 执行存储过程
            AppData.ResultSet = (DataSet)db.ExecuteDataSet(cmdProc);
            // 得到返回记录数
            AppData.RecordCount = db.GetParameterValue(cmdProc, "@RecordCount") == DBNull.Value ? 0 : (Int32)db.GetParameterValue(cmdProc, "@RecordCount");
        }
        
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="OnlyDisplayUsedNode = 'true'">
      <xsl:if test="IsDataBind = 'true'">
        public static DataSet Get<xsl:value-of select="DataBindTableName"/>_Exist_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>(RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationData appDate)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_Get<xsl:value-of select="DataBindTableName"/>_Exist_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@<xsl:value-of select="DataBindValueField"/>", DbType.String);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="DataBindValueField"/>", appDate.<xsl:value-of select="DataBindValueField"/>);
            db.AddInParameter(cmdProc, "@<xsl:value-of select="DataBindTextField"/>", DbType.String);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="DataBindTextField"/>", appDate.<xsl:value-of select="DataBindTextField"/>);
            <xsl:if test="IsTreeStyle = 'true'">
            db.AddInParameter(cmdProc, "@<xsl:value-of select="TreeParentNode"/>", DbType.String);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="TreeParentNode"/>", appDate.<xsl:value-of select="TreeParentNode"/>);
            </xsl:if>
            <xsl:choose>
                <xsl:when test="DataBindCondition = 'null'">
                </xsl:when>
                <xsl:otherwise>
            db.AddInParameter(cmdProc, "@<xsl:value-of select="DataBindCondition"/>", DbType.String);
            db.SetParameterValue(cmdProc, "@<xsl:value-of select="DataBindCondition"/>", appDate.<xsl:value-of select="DataBindCondition"/>);
                </xsl:otherwise>
            </xsl:choose>
            // 执行存储过程
            DataSet ds = db.ExecuteDataSet(cmdProc);
            return ds;
        }
      </xsl:if>
  </xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/RecordInfo">
	<xsl:if test="IsDataBind = 'true'">
	<xsl:if test="IsTreeStyle = 'true'">
        public static DataSet GetTreeData_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>(string iDFieldName, string nameFieldName, string parentFieldValue = null, string conditionFieldName = null, string conditionFieldValue = null, bool onlyShowUsed = false)
        {
            // 创建数据库连接 
            Database db = DatabaseFactory.CreateDatabase("strConnManager");
            string strProcName = "SP_GetTreeData_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>";
            DbCommand cmdProc = db.GetStoredProcCommand(strProcName);
            // 设定存储过程输入参数
            db.AddInParameter(cmdProc, "@IDFieldName", DbType.String);
            db.SetParameterValue(cmdProc, "@IDFieldName", iDFieldName);
            db.AddInParameter(cmdProc, "@NameFieldName", DbType.String);
            db.SetParameterValue(cmdProc, "@NameFieldName", nameFieldName);
            db.AddInParameter(cmdProc, "@ParentIDFieldValue", DbType.String);
            db.SetParameterValue(cmdProc, "@ParentIDFieldValue", parentFieldValue);
            db.AddInParameter(cmdProc, "@ConditionFieldName", DbType.String);
            db.SetParameterValue(cmdProc, "@ConditionFieldName", conditionFieldName);
            db.AddInParameter(cmdProc, "@ConditionFieldValue", DbType.String);
            db.SetParameterValue(cmdProc, "@ConditionFieldValue", conditionFieldValue);
            db.AddInParameter(cmdProc, "@OnlyShowUsed", DbType.Boolean);
            db.SetParameterValue(cmdProc, "@OnlyShowUsed", onlyShowUsed);
            // 执行存储过程
            DataSet ds = db.ExecuteDataSet(cmdProc);
            return ds;
        }
	</xsl:if>
	</xsl:if>
</xsl:for-each>
        #endregion
    }
}
  </xsl:template>
</xsl:stylesheet>