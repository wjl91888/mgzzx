using System;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;

namespace RICH.Common.Base.ApplicationLogic
{
    public abstract class ApplicationLogicBase
    {

        protected BusinessLogicBase CreateBusinessLogicInstance(Type typeofBusinessLogic)
        {
            BusinessLogicBase businessLogic = (BusinessLogicBase)Activator.CreateInstance(typeofBusinessLogic);
            return businessLogic;
        }

        protected BusinessEntityBase CreateBusinessEntityInstance(Type typeofBusinessEntity)
        {
            BusinessEntityBase businessEntity = (BusinessEntityBase)Activator.CreateInstance(typeofBusinessEntity);
            return businessEntity;
        }

        protected string FillZeroToString(string strObject, int intNumber)
        {
            if (strObject.Length < intNumber)
            {
                int intDec = intNumber - strObject.Length;
                for (int i = 0; i < intDec; i++)
                {
                    strObject = "0" + strObject;
                }
            }
            return strObject;
        }
    }
}
