using System.Data;
using System.Reflection;

namespace RICH.Common.Base.ApplicationData
{
    //===========================================================================
    //  ClassName : ColumnInfo
    /// <summary>
    /// ApplicationDataBase的数据实体的列的数据类
    /// </summary>
    //===========================================================================
    public class ColumnInfo
    {
        #region 属性信息
        /// <summary>
        /// 属性信息
        /// </summary>
        private PropertyInfo columnProperty = null;

        /// <summary>
        /// 设定取得属性信息
        /// </summary>
        /// <value>属性</value>
        public PropertyInfo ColumnProperty
        {
            get { return columnProperty; }
            set { columnProperty = value; }
        }
        #endregion

        #region 数据库数据类型

        /// <summary>
        /// 设定取得数据库数据类型
        /// </summary>
        /// <value>数据库数据类型</value>
        public SqlDbType ColumnType { get; set; }

        #endregion

        #region 是否是主键

        /// <summary>
        /// 设定取得是否是主键标示
        /// </summary>
        /// <value>
        /// 是主键的情况 true
        /// 不是主键的情况 false
        /// </value>
        public bool IsPrimaryKey { get; set; }

        #endregion

        #region 是否可以为Null

        /// <summary>
        /// 设置取得是否可以为Null标示
        /// </summary>
        /// <value>
        /// 可以为Null true
        /// 不可以为Null false
        /// </value>
        public bool IsNullable { get; set; }

        #endregion

        #region 构造函数
        //=========================================================================
        //  FunctionName : ColumnInfo
        /// <summary>
        /// ColumnInfo构造函数
        /// </summary>
        //=========================================================================
        public ColumnInfo()
        {
            IsPrimaryKey = false;
            IsNullable = false;
        }

        #endregion
    }

}
