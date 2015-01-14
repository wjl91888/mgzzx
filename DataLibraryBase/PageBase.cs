using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Reflection;
using ExtJS.Ext;


namespace RICH.Common.Base.WebUI
{
    /// <summary>
    /// 主要用于全局控制
    /// </summary>
    public class PageBase : WebUIBaseNoCallBack
    {
        #region Member Variable

        /// <summary>
        /// 路由搜索方法:search
        /// </summary>
        public const string ROUTE_METHOD_SEARCH = "search";
        /// <summary>
        /// 路由修改方法:modify
        /// </summary>
        public const string ROUTE_METHOD_MODIFY = "modify";
        /// <summary>
        /// 路由删除方法:remove
        /// </summary>
        public const string ROUTE_METHOD_REMOVE = "remove";
        /// <summary>
        /// 路由添加方法:add
        /// </summary>
        public const string ROUTE_METHOD_ADD = "add";
        /// <summary>
        /// 路由详情方法:detail
        /// </summary>
        public const string ROUTE_METHOD_DETAIL = "detail";

        #endregion

        #region Method

        #region override method

        /// <summary>
        /// 预初始化，在初始化页面OnInit事件前触发
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            #region 权限认证


            #endregion

            #region 路由请求

            //路由请求
            string reqMethod = Request.QueryString["method"];

            if (!string.IsNullOrEmpty(reqMethod))
            {
                switch (reqMethod.ToLower())
                {
                    case ROUTE_METHOD_MODIFY:
                        Response.Write(Modify());
                        break;
                    case ROUTE_METHOD_SEARCH:
                        Response.Write(Search());
                        break;
                    case ROUTE_METHOD_REMOVE:
                        Response.Write(Remove());
                        break;
                    case ROUTE_METHOD_ADD:
                        Response.Write(Add());
                        break;
                    case ROUTE_METHOD_DETAIL:
                        Response.Write(Detail());
                        break;
                    default:
                        //反射
                        MethodInfo method = this.GetType().GetMethod(reqMethod);
                        if (method != null)
                        {
                            method.Invoke(this, null);
                        }
                        break;
                }
                End();
            }

            #endregion

            base.OnPreInit(e);
        }

        /// <summary>
        /// 初始化(OnInit)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            #region ExtJS

            ExtHelper.Add(this.Header, this);

            #endregion

            base.OnInit(e);
        }

        #endregion

        #region virtual method

        /// <summary>
        /// 搜索
        /// </summary>
        /// <returns></returns>
        public virtual string Search()
        {
            return string.Empty;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public virtual string Modify()
        {
            return string.Empty;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public virtual string Remove()
        {
            return string.Empty;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public virtual string Add()
        {
            return string.Empty;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        public virtual string Detail()
        {
            return string.Empty;
        }

        /// <summary>
        /// 可以覆盖做其他处理
        /// Response.End();
        /// </summary>
        public virtual void End()
        {
            Response.End();
        }

        #endregion

        #endregion
    }
}