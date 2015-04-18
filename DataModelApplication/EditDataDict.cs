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
    public partial class EditDataDict : Form
    {
        private XmlDocument xmlDocumentDataDict;
        private string FileName = "CustomPropertyDataDict.xml";

        public EditDataDict()
        {
            InitializeComponent();
        }

        private void EditDataDict_Load(object sender, EventArgs e)
        {
            try
            {
                //创建XmlDocment类的实例
                xmlDocumentDataDict = new XmlDocument();
                //把指定文件读入内存
                xmlDocumentDataDict.Load(FileName);
                //设置读取XML文件起点
                XmlNodeList xmlNodeListDataDict = xmlDocumentDataDict.SelectNodes("/DataDicts/DataDict");
                foreach (XmlNode nodeDataDict in xmlNodeListDataDict)
                {
                    lbDataDict.Items.Add(nodeDataDict.Attributes["Name"].Value);

                }

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

        private void GetDataDict(string strDataDictName)
        {
            try
            {
                dgvDataDict.Columns.Clear();
                //设置读取XML文件起点
                XmlNodeList xmlNodeListProperty = xmlDocumentDataDict.SelectNodes("/DataDicts/DataDict");
                foreach (XmlNode nodeDataDict in xmlNodeListProperty)
                {
                    if (strDataDictName == nodeDataDict.Attributes["Name"].Value)
                    {
                        foreach (XmlNode xmlNodeAttributes in nodeDataDict.ChildNodes)
                        {
                            if (xmlNodeAttributes.Name == "Attributes")
                            {
                                foreach (XmlNode xmlNodeAttribute in xmlNodeAttributes.ChildNodes)
                                {
                                    DataGridViewColumn dataGridViewColumn;
                                    dataGridViewColumn = new DataGridViewTextBoxColumn();
                                    dataGridViewColumn.Name = xmlNodeAttribute.Attributes["Name"].Value;
                                    dataGridViewColumn.HeaderText = xmlNodeAttribute.Attributes["Remark"].Value;
                                    dgvDataDict.Columns.Add(dataGridViewColumn);
                                }
                                break;
                            }
                        }
                        foreach (XmlNode nodeDataDictData in nodeDataDict.ChildNodes)
                        {
                            if (nodeDataDictData.Name == "Data")
                            {
                                foreach (XmlNode xmlNodeAttributes in nodeDataDict.ChildNodes)
                                {
                                    if (xmlNodeAttributes.Name == "Attributes")
                                    {
                                        int i = dgvDataDict.Rows.Add();
                                        foreach (XmlNode xmlNodeAttribute in xmlNodeAttributes.ChildNodes)
                                        {
                                            dgvDataDict.Rows[i].Cells[xmlNodeAttribute.Attributes["Name"].Value].Value = nodeDataDictData.Attributes[xmlNodeAttribute.Attributes["Name"].Value].Value;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }

            }
            catch (Exception)
            {
                
                throw;
            }
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

        private void lbDataDict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetDataDict(lbDataDict.SelectedItem.ToString());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void dgvDataDict_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SaveDataDict(lbDataDict.SelectedItem.ToString());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void SaveDataDict(string strDataDictName)
        {
            try
            {
                XmlNodeList xmlNodeListProperty = xmlDocumentDataDict.SelectNodes("/DataDicts/DataDict");
                foreach (XmlNode nodeDataDict in xmlNodeListProperty)
                {
                    if (strDataDictName == nodeDataDict.Attributes["Name"].Value)
                    {
                        for (int i = nodeDataDict.ChildNodes.Count-1; i >= 0; i--)
                        {
                            if ("Data" == nodeDataDict.ChildNodes.Item(i).Name)
                            {
                                nodeDataDict.RemoveChild(nodeDataDict.ChildNodes.Item(i));
                            }
                        }
                        foreach (DataGridViewRow dgvr in dgvDataDict.Rows)
                        {
                            if (dgvr.IsNewRow == false)
                            {
                                XmlNode xmlNodeDataAppend = xmlDocumentDataDict.CreateNode(XmlNodeType.Element, "Data", "");
                                foreach (XmlNode xmlNodeAttributes in nodeDataDict.ChildNodes)
                                {
                                    if (xmlNodeAttributes.Name == "Attributes")
                                    {
                                        foreach (XmlNode xmlNodeAttribute in xmlNodeAttributes.ChildNodes)
                                        {
                                            XmlAttribute xmlAttribute = xmlDocumentDataDict.CreateAttribute(xmlNodeAttribute.Attributes["Name"].Value);
                                            xmlAttribute.Value = ((dgvr.Cells[xmlNodeAttribute.Attributes["Name"].Value].Value == null) ? string.Empty : dgvr.Cells[xmlNodeAttribute.Attributes["Name"].Value].Value.ToString());
                                            xmlNodeDataAppend.Attributes.Append(xmlAttribute);
                                        }
                                        break;
                                    }
                                }
                                nodeDataDict.AppendChild(xmlNodeDataAppend);
                            }
                        }
                        break;
                    }
                }               
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnSaveDataDict_Click(object sender, EventArgs e)
        {
            try
            {
                xmlDocumentDataDict.Save(FileName);
                MessageBox.Show("保存完成");
                this.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}