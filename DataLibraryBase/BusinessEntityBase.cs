using System;

namespace RICH.Common.Base.BusinessEntity
{
    public abstract class BusinessEntityBase
    {
        public abstract void Insert();
        public abstract void UpdateByKey();
        public abstract void UpdateByObjectID();
        public abstract void UpdateByObjectIDBatch();
        public virtual void UpdateByAnyCondition(){}
        public abstract void SelectByAnyCondition();
        public abstract void SelectByKey();
        public abstract void SelectByObjectID();
        public abstract void DeleteByKey();
        public abstract void DeleteByObjectID();
        public abstract void DeleteByObjectIDBatch();
        public abstract Boolean IsExistByKey();
        public abstract Boolean IsExistByObjectID();
        public abstract object GetValueByFixCondition(string strConditionField, object strConditionValue, string strValueField, string strFixConditionField = null, object strFixConditionValue = null);
        public abstract object GetMaxValue(string strConditionField);
        public abstract void CountByAnyCondition();
    }

}
