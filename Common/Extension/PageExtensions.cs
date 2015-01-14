using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;

namespace RICH.Common
{
    public static class PageExtensions
    {
        public static void OpenWindow(this Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException("page");
            }
            var ajaxManager = RadAjaxManager.GetCurrent(page);
            if (ajaxManager != null)
            {
                ajaxManager.ResponseScripts.Add("OpenWindow();");
            }
        }

        public static void CloseWindow(this Page page, bool isSetTimeout = false)
        {
            if (page == null)
            {
                throw new ArgumentNullException("page");
            }
            var ajaxManager = RadAjaxManager.GetCurrent(page);
            if (ajaxManager != null)
            {
                ajaxManager.ResponseScripts.Add(isSetTimeout ? "CloseWindowTimeout()" : "CloseWindow();");
            }
        }
    }
}
