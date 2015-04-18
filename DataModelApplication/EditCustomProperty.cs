using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DataModelApplication
{
    public partial class EditCustomProperty : Form
    {
        private XmlDocument xmlDocument = new XmlDocument();
        private XmlDocument xmlDocumentDataDict = new XmlDocument();
        private string FileName = "CustomProperty.xml";
        private string DataDictFileName = "CustomPropertyDataDict.xml";

        public EditCustomProperty()
        {
            InitializeComponent();
        }

        private void EditCustomProperty_Load(object sender, EventArgs e)
        {
            try
            {
                //把指定文件读入内存
                xmlDocument.Load(FileName);
                xmlDocumentDataDict.Load(DataDictFileName);

                GetCustomProperty();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnSaveCustomProperty_Click(object sender, EventArgs e)
        {
            try
            {
                xmlDocument.Save(FileName);
                MessageBox.Show("保存完成");
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
 
        }

        private void dgvCustomProperty_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SaveCustomProperty();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void GetCustomProperty()
        {
            try
            {
                dgvCustomProperty.Columns.Clear();
                //设置读取XML文件起点
                XmlNodeList xmlNodeListAttribute = xmlDocument.SelectNodes("/Properties/Attributes/Attribute");
                foreach (XmlNode node in xmlNodeListAttribute)
                {
                    DataGridViewColumn dataGridViewColumn;
                    switch (node.Attributes["ShowType"].Value)
                    {
                        case "TextBox":
                            dataGridViewColumn = new DataGridViewTextBoxColumn();
                            break;
                        case "CheckBox":
                            dataGridViewColumn = new DataGridViewCheckBoxColumn();
                            dataGridViewColumn.ValueType = System.Type.GetType("System.Boolean");
                            break;
                        case "ComboBox":
                            dataGridViewColumn = new DataGridViewComboBoxColumn();
                            if (Convert.ToBoolean(node.Attributes["DataBind"].Value) == true)
                            {
                                XmlNodeList xmlNodeListDataDict = xmlDocumentDataDict.SelectNodes("/DataDicts/DataDict");
                                foreach (XmlNode nodeDataDict in xmlNodeListDataDict)
                                {
                                    if (node.Attributes["DataSource"].Value == nodeDataDict.Attributes["Name"].Value)
                                    {
                                        foreach (XmlNode nodeDataDictData in nodeDataDict.ChildNodes)
                                        {
                                            if ("Data" == nodeDataDictData.Name)
                                            {
                                                ((DataGridViewComboBoxColumn)dataGridViewColumn).Items.Add(nodeDataDictData.Attributes["Name"].Value);
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            dataGridViewColumn = new DataGridViewTextBoxColumn();
                            break;
                    }
                    dataGridViewColumn.Name = node.Attributes["Name"].Value;
                    dataGridViewColumn.HeaderText = node.Attributes["Remark"].Value;
                    dgvCustomProperty.Columns.Add(dataGridViewColumn);
                }

                XmlNodeList xmlNodeListProperty = xmlDocument.SelectNodes("/Properties/Property");
                foreach (XmlNode node in xmlNodeListProperty)
                {
                    object[] obj = new object[node.Attributes.Count];
                    int i = 0;
                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        obj[i] = attribute.Value;
                        i++;
                    }
                    dgvCustomProperty.Rows.Add(obj);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SaveCustomProperty()
        {
            try
            {
                XmlNode xmlNodePropertys = xmlDocument.SelectSingleNode("/Properties");
                for (int i = xmlNodePropertys.ChildNodes.Count - 1; i >= 0; i--)
                {
                    if ("Property" == xmlNodePropertys.ChildNodes.Item(i).Name)
                    {
                        xmlNodePropertys.RemoveChild(xmlNodePropertys.ChildNodes.Item(i));
                    }
                }
                foreach (DataGridViewRow dgvr in dgvCustomProperty.Rows)
                {
                    if (dgvr.IsNewRow == false)
                    {
                        XmlNode xmlNodeDataAppend = xmlDocument.CreateNode(XmlNodeType.Element, "Property", "");
                        foreach (XmlNode xmlNodeAttributes in xmlNodePropertys.ChildNodes)
                        {
                            if (xmlNodeAttributes.Name == "Attributes")
                            {
                                foreach (XmlNode xmlNodeAttribute in xmlNodeAttributes.ChildNodes)
                                {
                                    XmlAttribute xmlAttribute = xmlDocument.CreateAttribute(xmlNodeAttribute.Attributes["Name"].Value);
                                    xmlAttribute.Value = ((dgvr.Cells[xmlNodeAttribute.Attributes["Name"].Value].Value == null) ? string.Empty : dgvr.Cells[xmlNodeAttribute.Attributes["Name"].Value].Value.ToString());
                                    xmlNodeDataAppend.Attributes.Append(xmlAttribute);
                                }
                                break;
                            }
                        }
                        xmlNodePropertys.AppendChild(xmlNodeDataAppend);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}