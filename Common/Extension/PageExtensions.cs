using System;
using System.Collections.Generic;
using System.Linq;
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


        public static Boolean IsMobileDevice(this Page page)
        {
            string[] mobileAgents = { "iphone", "android", "phone", "mobile", "wap", "netfront", "java", "opera mobi", "opera mini", "ucweb", "windows ce", "symbian", "series", "webos", "sony", "blackberry", "dopod", "nokia", "samsung", "palmsource", "xda", "pieplus", "meizu", "midp", "cldc", "motorola", "foma", "docomo", "up.browser", "up.link", "blazer", "helio", "hosin", "huawei", "novarra", "coolpad", "webos", "techfaith", "palmsource", "alcatel", "amoi", "ktouch", "nexian", "ericsson", "philips", "sagem", "wellcom", "bunjalloo", "maui", "smartphone", "iemobile", "spice", "bird", "zte-", "longcos", "pantech", "gionee", "portalmmm", "jig browser", "hiptop", "benq", "haier", "^lct", "320x320", "240x320", "176x220", "w3c ", "acs-", "alav", "alca", "amoi", "audi", "avan", "benq", "bird", "blac", "blaz", "brew", "cell", "cldc", "cmd-", "dang", "doco", "eric", "hipt", "inno", "ipaq", "java", "jigs", "kddi", "keji", "leno", "lg-c", "lg-d", "lg-g", "lge-", "maui", "maxo", "midp", "mits", "mmef", "mobi", "mot-", "moto", "mwbp", "nec-", "newt", "noki", "oper", "palm", "pana", "pant", "phil", "play", "port", "prox", "qwap", "sage", "sams", "sany", "sch-", "sec-", "send", "seri", "sgh-", "shar", "sie-", "siem", "smal", "smar", "sony", "sph-", "symb", "t-mo", "teli", "tim-", "tosh", "tsm-", "upg1", "upsi", "vk-v", "voda", "wap-", "wapa", "wapi", "wapp", "wapr", "webc", "winw", "winw", "xda", "xda-", "Googlebot-Mobile" };
            bool isMoblie = false;
            if (!string.IsNullOrWhiteSpace(page.Request.UserAgent))
            {
                isMoblie = mobileAgents.Any(t => page.Request.UserAgent.ToString().ToLower().IndexOf(t) >= 0);
            }
            return isMoblie;
        }

    }
}
