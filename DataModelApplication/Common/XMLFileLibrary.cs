using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;

namespace DataModelApplication.Common
{
    class XMLFileLibrary
    {
        private string strFileName = string.Empty;

        public string FileName
        {
            get
            {
                return strFileName;
            }
            set
            {
                strFileName = value;
            }
        }
        private string strFilePath = string.Empty;

        public string FilePath
        {
            get
            {
                return strFilePath;
            }
            set
            {
                strFilePath = value;
            }
        }

        //���ļ����½�һ���ڵ�
        public void CreateXMLNode(string strBeginNodeName, string strNodeName, string strNodeValue)
        {
            //����XmlDocment���ʵ��
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement xmlElement;
            XmlText xmlText;
            //��ָ���ļ������ڴ�
            xmlDocument.Load(FileName);
            //���ö�ȡXML�ļ����
            XmlNode xmlBeginNode = xmlDocument.SelectSingleNode(strBeginNodeName);
            //�жϿ�ʼ�ڵ��Ƿ����
            if (xmlBeginNode != null)
            {
                //����ָ��Ԫ��
                xmlElement = xmlDocument.CreateElement("", strNodeName, "");
                //������Ԫ���ı�
                xmlText = xmlDocument.CreateTextNode(strNodeValue);
                //��ָ��Ԫ��������ı�
                xmlElement.AppendChild(xmlText);
                //��ָ���ڵ���ӵ�ָ����ʼ�ڵ�����
                xmlBeginNode.AppendChild(xmlElement);
            }
            //�ѱ���ָ���ļ�
            xmlDocument.Save(FileName);
        }

        //���ļ����޸�һ���ڵ�
        public void ModifyXMLNode(string strNodeName, string strNodeValue)
        {
        }

        //���ļ���ɾ��һ���ڵ�
        public void RemoveXMLNode(string strNodeName, string strNodeValue)
        {
        }

        //���ļ��ж�ȡһ���ڵ�
        public string ReadXMLNode(string strBeginNodeName)
        {
            string strReturn = string.Empty;
            //����XmlDocment���ʵ��
            XmlDocument xmlDocument = new XmlDocument();
            //��ָ���ļ������ڴ�
            xmlDocument.Load(FileName);
            //���ö�ȡXML�ļ����
            XmlNode xmlBeginNode = xmlDocument.SelectSingleNode(strBeginNodeName);
            //�жϿ�ʼ�ڵ��Ƿ����
            if (xmlBeginNode != null)
            {
                //��ȡ�ڵ�ֵ
                strReturn = xmlBeginNode.InnerText;
            }
            return strReturn;
        }

        public static string ToSourceCode(string xsltFileName, string xmlString)
        {
            string strXML = xmlString;
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltFileName);
            StringWriter output = new StringWriter();
            StringReader sr = new StringReader(strXML);
            XPathDocument oXPath = new XPathDocument(sr);
            xslt.Transform(oXPath, null, output);
            return output.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n", "").Replace("&lt;", "<").Replace("&gt;", ">");
             //return output.ToString();
        }
    }
}
