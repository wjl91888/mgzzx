using System;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.Base.WebService
{
    public class WebServiceBase : System.Web.Services.WebService
    {
        protected ApplicationLogicBase CreateApplicationLogicInstance(Type typeofApplicationLogic)
        {
            ApplicationLogicBase applicationLogic = (ApplicationLogicBase)Activator.CreateInstance(typeofApplicationLogic);
            return applicationLogic;
        }

        protected string GetValue(object objValue)
        {
            string strReturn = string.Empty;
            if (objValue != DBNull.Value)
            {
                strReturn = objValue.ToString();
            }
            else if (objValue != null)
            {
                strReturn = objValue.ToString();
            }
            return strReturn;
        }
    }
}
