using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Reflection;
using ExtJS.Ext;


namespace RICH.Common.Base.WebUI
{
    /// <summary>
    /// ��Ҫ����ȫ�ֿ���
    /// </summary>
    public class PageBase : WebUIBaseNoCallBack
    {
        #region Member Variable

        /// <summary>
        /// ·����������:search
        /// </summary>
        public const string ROUTE_METHOD_SEARCH = "search";
        /// <summary>
        /// ·���޸ķ���:modify
        /// </summary>
        public const string ROUTE_METHOD_MODIFY = "modify";
        /// <summary>
        /// ·��ɾ������:remove
        /// </summary>
        public const string ROUTE_METHOD_REMOVE = "remove";
        /// <summary>
        /// ·����ӷ���:add
        /// </summary>
        public const string ROUTE_METHOD_ADD = "add";
        /// <summary>
        /// ·�����鷽��:detail
        /// </summary>
        public const string ROUTE_METHOD_DETAIL = "detail";

        #endregion

        #region Method

        #region override method

        /// <summary>
        /// Ԥ��ʼ�����ڳ�ʼ��ҳ��OnInit�¼�ǰ����
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            #region Ȩ����֤


            #endregion

            #region ·������

            //·������
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
                        //����
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
        /// ��ʼ��(OnInit)
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
        /// ����
        /// </summary>
        /// <returns></returns>
        public virtual string Search()
        {
            return string.Empty;
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <returns></returns>
        public virtual string Modify()
        {
            return string.Empty;
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <returns></returns>
        public virtual string Remove()
        {
            return string.Empty;
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public virtual string Add()
        {
            return string.Empty;
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public virtual string Detail()
        {
            return string.Empty;
        }

        /// <summary>
        /// ���Ը�������������
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