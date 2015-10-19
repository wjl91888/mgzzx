using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RICH.Common.Base.WebUI
{
    public partial class WebUIBase
    {
        public const string NO_ACCESS_PURVIEW_ID = "NO_ACCESS_PERMISSON";
        public const string AndChar = "&";
        protected const Int32 DEFAULT_PAGE_SIZE = 50;
        protected const Int32 DEFAULT_CURRENT_PAGE = 1;
        public const string OpenWindowJsCode = @"OpenWindow('{0}',770,600,window);";
        public const string RedirectJsCode = @"window.location = '{0}';";
    }
}
