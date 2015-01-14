using System.Collections.Generic;
using System.Web.UI.HtmlControls;

namespace ExtJS.Ext
{
    public sealed class ExtHelper
    {
        #region MemberVariable

        public static readonly string EXT_BASE = System.Configuration.ConfigurationSettings.AppSettings["EXT_BASE"] ?? "/js/ext";
        /// <summary>
        /// ext-all.css
        /// </summary>
        public static readonly string EXT_CSS_ALL = EXT_BASE + "/resources/css/ext-all.css";
        /// <summary>
        /// ext-all.js
        /// </summary>
        public static readonly string EXT_JS_ALL = EXT_BASE + "/ext-all.js";
        /// <summary>
        /// ext-base.js
        /// </summary>
        public static readonly string EXT_JS_BASE = EXT_BASE + "/adapter/ext/ext-base.js";
        /// <summary>
        /// ext-lang-zh_CN.js
        /// </summary>
        public static readonly string EXT_JS_LANGUAGE = EXT_BASE + "/source/locale/ext-lang-zh_CN.js";
        /// <summary>
        /// easy-ext.js
        /// </summary>
        public static readonly string EXT_JS_EASYEXT = EXT_BASE + "/plugins/easy-ext.js";

        /// <summary>
        ///  0    ext-all.css
        ///  1    ext-base.js
        ///  2    ext-all.js
        ///  3    ext-lang-zh_CN.js
        ///  4    easy-ext.js
        /// </summary>
        private static readonly IList<HtmlGenericControl> extresource;

        #endregion

        #region Constructors

        static ExtHelper()
        {
            extresource = new List<HtmlGenericControl>();

            //ext-all.css
            HtmlGenericControl css_ext_all = new HtmlGenericControl("link");
            css_ext_all.Attributes.Add("type", "text/css");
            css_ext_all.Attributes.Add("rel", "stylesheet");
            css_ext_all.Attributes.Add("href", EXT_CSS_ALL);
            extresource.Add(css_ext_all);

            //ext-base.js
            HtmlGenericControl js_ext_base = new HtmlGenericControl("script");
            js_ext_base.Attributes.Add("type", "text/javascript");
            js_ext_base.Attributes.Add("src", EXT_JS_BASE);
            extresource.Add(js_ext_base);

            //ext-all.js
            HtmlGenericControl js_ext_all = new HtmlGenericControl("script");
            js_ext_all.Attributes.Add("type", "text/javascript");
            js_ext_all.Attributes.Add("src", EXT_JS_ALL);
            extresource.Add(js_ext_all);

            //ext-lang-zh_CN.js
            HtmlGenericControl js_ext_lang = new HtmlGenericControl("script");
            js_ext_lang.Attributes.Add("type", "text/javascript");
            js_ext_lang.Attributes.Add("src", EXT_JS_LANGUAGE);
            extresource.Add(js_ext_lang);

            //easy-ext.js
            HtmlGenericControl js_ext_easyext = new HtmlGenericControl("script");
            js_ext_easyext.Attributes.Add("type", "text/javascript");
            js_ext_easyext.Attributes.Add("src", EXT_JS_EASYEXT);
            extresource.Add(js_ext_easyext);

        }

        #endregion

        #region Method

        /// <summary>
        /// 添加Ext资源文件
        /// </summary>
        /// <param name="head"></param>
        /// <param name="page"></param>
        public static void Add(HtmlHead head, System.Web.UI.Page page)
        {
            if (head != null)
            {
                if (extresource != null)
                {
                    //head.Controls[0]为title
                    head.Controls.AddAt(1, extresource[0]);
                    head.Controls.AddAt(2, extresource[1]);
                    head.Controls.AddAt(3, extresource[2]);
                    head.Controls.AddAt(4, extresource[3]);
                    head.Controls.AddAt(5, extresource[4]);
                }
            }
        }

        #endregion
    }
}
