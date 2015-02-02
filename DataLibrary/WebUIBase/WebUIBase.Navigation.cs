namespace RICH.Common.Base.WebUI
{
    public abstract partial class WebUIBase
    {
        public string GetAddPageUrl()
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}?a=a".FormatInvariantCulture(WEBUI_ADD_FILENAME)
                       : "{0}?a=a&p={1}".FormatInvariantCulture(WEBUI_ADD_FILENAME, CustomPermission);
        }
        public string GetEditPageUrl(string objectID)
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}?a=e&ObjectID={1}".FormatInvariantCulture(WEBUI_ADD_FILENAME, objectID)
                       : "{0}?a=e&ObjectID={1}&p={2}".FormatInvariantCulture(WEBUI_ADD_FILENAME, objectID, CustomPermission);
        }
        public string GetCopyPageUrl(string objectID)
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}?a=c&ObjectID={1}".FormatInvariantCulture(WEBUI_ADD_FILENAME, objectID)
                       : "{0}?a=c&ObjectID={1}&p={2}".FormatInvariantCulture(WEBUI_ADD_FILENAME, objectID, CustomPermission);
        }
        public string GetViewPageUrl(string objectID)
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}?a=v&ObjectID={1}".FormatInvariantCulture(WEBUI_ADD_FILENAME, objectID)
                       : "{0}?a=v&ObjectID={1}&p={2}".FormatInvariantCulture(WEBUI_ADD_FILENAME, objectID, CustomPermission);
        }
        public string GetImportDocPageUrl()
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}?a=doc".FormatInvariantCulture(WEBUI_ADD_FILENAME)
                       : "{0}?a=doc&p={1}".FormatInvariantCulture(WEBUI_ADD_FILENAME, CustomPermission);
        }
        public string GetImportDSPageUrl()
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}?a=ds".FormatInvariantCulture(WEBUI_ADD_FILENAME)
                       : "{0}?a=ds&p={1}".FormatInvariantCulture(WEBUI_ADD_FILENAME, CustomPermission);
        }
        public string GetDetailPageUrl(string objectID)
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}?ObjectID={1}".FormatInvariantCulture(WEBUI_DETAIL_FILENAME, objectID)
                       : "{0}?ObjectID={1}&p={2}".FormatInvariantCulture(WEBUI_DETAIL_FILENAME, objectID, CustomPermission);
        }
        public string GetSearchPageUrl()
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}".FormatInvariantCulture(WEBUI_SEARCH_FILENAME)
                       : "{0}?p={1}".FormatInvariantCulture(WEBUI_SEARCH_FILENAME, CustomPermission);
        }
        public string GetStatisicPageUrl()
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}".FormatInvariantCulture(WEBUI_STATISTIC_FILENAME)
                       : "{0}?p={1}".FormatInvariantCulture(WEBUI_STATISTIC_FILENAME, CustomPermission);
        }
        public string GetImagePageUrl()
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}".FormatInvariantCulture(WEBUI_IMAGE_FILENAME)
                       : "{0}?p={1}".FormatInvariantCulture(WEBUI_IMAGE_FILENAME, CustomPermission);
        }

        public string GetWebUISearchAccessPurviewID()
        {
            return
                "{0}".FormatInvariantCulture(CustomPermission.IsHtmlNullOrWiteSpace()
                                                 ? WEBUI_SEARCH_ACCESS_PURVIEW_ID
                                                 : CustomPermission);
        }

        public string GetWebUIAddAccessPurviewID()
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}".FormatInvariantCulture(WEBUI_ADD_ACCESS_PURVIEW_ID)
                       : "{0}_Add".FormatInvariantCulture(CustomPermission);
        }

        public string GetWebUIModifyAccessPurviewID()
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}".FormatInvariantCulture(WEBUI_MODIFY_ACCESS_PURVIEW_ID)
                       : "{0}_Modify".FormatInvariantCulture(CustomPermission);
        }

        public string GetWebUIDetailAccessPurviewID()
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}".FormatInvariantCulture(WEBUI_DETAIL_ACCESS_PURVIEW_ID)
                       : "{0}_Detail".FormatInvariantCulture(CustomPermission);
        }

        public string GetOperationDeletePurviewID()
        {
            return CustomPermission.IsHtmlNullOrWiteSpace()
                       ? "{0}".FormatInvariantCulture(OPERATION_DELETE_PURVIEW_ID)
                       : "{0}_Delete".FormatInvariantCulture(CustomPermission);
        }
    }
}
