using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RICH.Common.Base.WebUI
{
    public abstract partial class WebUIBase : System.Web.UI.Page
    {
        public abstract string FilterReportType { get; }
        public static string AndChar = "&";
        public virtual bool NeedLogin
        {
            get { return true; }
        }

        #region 页面名称定义
        /// <summary>
        /// 当前页面所在文件路径
        /// </summary>
        public abstract string CURRENT_PATH { get; }
        /// <summary>
        /// 编辑页面文件名
        /// </summary>
        public abstract string WEBUI_ADD_FILENAME { get; }
        /// <summary>
        /// 查询页面文件名
        /// </summary>
        public abstract string WEBUI_SEARCH_FILENAME { get; }
        /// <summary>
        /// 详情页面文件名
        /// </summary>
        public abstract string WEBUI_DETAIL_FILENAME { get; }
        /// <summary>
        /// 统计页面文件名
        /// </summary>
        public abstract string WEBUI_STATISTIC_FILENAME { get; }
        #endregion

        #region 权限编号定义
        /// <summary>
        /// 添加权限
        /// </summary>
        public abstract string WEBUI_ADD_ACCESS_PURVIEW_ID { get; }
        /// <summary>
        /// 修改权限
        /// </summary>
        public abstract string WEBUI_MODIFY_ACCESS_PURVIEW_ID { get; }
        /// <summary>
        /// 浏览权限
        /// </summary>
        public abstract string WEBUI_SEARCH_ACCESS_PURVIEW_ID { get; }
        /// <summary>
        /// 详情权限
        /// </summary>
        public abstract string WEBUI_DETAIL_ACCESS_PURVIEW_ID { get; }
        /// <summary>
        /// 统计权限
        /// </summary>
        public abstract string WEBUI_STATISTIC_ACCESS_PURVIEW_ID { get; }
        /// <summary>
        /// 删除权限
        /// </summary>
        public abstract string OPERATION_DELETE_PURVIEW_ID { get; }
        /// <summary>
        /// 导出权限
        /// </summary>
        public abstract string OPERATION_EXPORTALL_PURVIEW_ID { get; }
        /// <summary>
        /// 导入权限
        /// </summary>
        public abstract string OPERATION_IMPORT_PURVIEW_ID { get; }
        /// <summary>
        /// 导入数据集权限
        /// </summary>
        public abstract string OPERATION_IMPORT_DS_PURVIEW_ID { get; }
        #endregion

    }
}
