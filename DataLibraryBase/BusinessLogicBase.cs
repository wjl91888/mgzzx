using System;
using RICH.Common.Base.BusinessEntity;

namespace RICH.Common.Base.BusinessLogic
{
    public abstract class BusinessLogicBase
    {
        protected BusinessEntityBase CreateBusinessEntityInstance(Type typeofBusinessEntity)
        {
            BusinessEntityBase businessEntity = (BusinessEntityBase)Activator.CreateInstance(typeofBusinessEntity);
            return businessEntity;
        }
    }
}
