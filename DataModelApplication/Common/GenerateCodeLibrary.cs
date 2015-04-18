using System;
using System.Collections.Generic;
using System.Text;

namespace DataModelApplication.Common
{
    class GenerateCodeLibrary
    {
        private string strXMLDataFileName = string.Empty;
        public string XMLDataFileName
        {
            get
            {
                return strXMLDataFileName;
            }
            set
            {
                strXMLDataFileName = value;
            }
        }

        private string strXMLConfigFileName = string.Empty;
        public string XMLConfigFileName
        {
            get
            {
                return strXMLConfigFileName;
            }
            set
            {
                strXMLConfigFileName = value;
            }
        }

        private string strXSLTTemplateFileName = string.Empty;
        public string XSLTTemplateFileName
        {
            get
            {
                return strXSLTTemplateFileName;
            }
            set
            {
                strXSLTTemplateFileName = value;
            }
        }

    }
}
