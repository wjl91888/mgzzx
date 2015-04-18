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

        //在文件中新建一个节点
        public void CreateXMLNode(string strBeginNodeName, string strNodeName, string strNodeValue)
        {
            //创建XmlDocment类的实例
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement xmlElement;
            XmlText xmlText;
            //把指定文件读入内存
            xmlDocument.Load(FileName);
            //设置读取XML文件起点
            XmlNode xmlBeginNode = xmlDocument.SelectSingleNode(strBeginNodeName);
            //判断开始节点是否存在
            if (xmlBeginNode != null)
            {
                //产生指定元素
                xmlElement = xmlDocument.CreateElement("", strNodeName, "");
                //产生该元素文本
                xmlText = xmlDocument.CreateTextNode(strNodeValue);
                //向指定元素中填加文本
                xmlElement.AppendChild(xmlText);
                //把指定节点添加到指定起始节点下面
                xmlBeginNode.AppendChild(xmlElement);
            }
            //把保存指定文件
            xmlDocument.Save(FileName);
        }

        //在文件中修改一个节点
        public void ModifyXMLNode(string strNodeName, string strNodeValue)
        {
        }

        //在文件中删除一个节点
        public void RemoveXMLNode(string strNodeName, string strNodeValue)
        {
        }

        //在文件中读取一个节点
        public string ReadXMLNode(string strBeginNodeName)
        {
            string strReturn = string.Empty;
            //创建XmlDocment类的实例
            XmlDocument xmlDocument = new XmlDocument();
            //把指定文件读入内存
            xmlDocument.Load(FileName);
            //设置读取XML文件起点
            XmlNode xmlBeginNode = xmlDocument.SelectSingleNode(strBeginNodeName);
            //判断开始节点是否存在
            if (xmlBeginNode != null)
            {
                //读取节点值
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
