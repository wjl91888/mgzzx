using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace DataModelApplication
{
    public partial class GenerateCodeForm : Form
    {
        private string strTableConfigFileName;
        public string TableConfigFileName
        {
            set
            {
                strTableConfigFileName = value;
            }
            get
            {
                return strTableConfigFileName;
            }
        }

        private string strTemplateFilePath = "Template";
        public string TemplateFilePath
        {
            set
            {
                strTemplateFilePath = value;
            }
            get
            {
                return strTemplateFilePath;
            }
        }

        public GenerateCodeForm()
        {
            InitializeComponent();
        }

        public GenerateCodeForm(string strInitTableConfigFileName)
        {
            InitializeComponent();
            TableConfigFileName = strInitTableConfigFileName;
        }

        private void GetTemplateList(string strFilePath)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(strFilePath);
                lbTemplateList.Items.Clear();
                foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.xsl"))
                {
                    lbTemplateList.Items.Add(fileInfo.FullName.Substring(fileInfo.FullName.LastIndexOf("\\")+1));
                }
            }
            catch (Exception)
            {

                MessageBox.Show("ָ��ģ��·�������ڡ�");
            }
        }

        private void btnSelectTemplateDir_Click(object sender, EventArgs e)
        {
            try
            {
                DataModelApplication.Common.FolderDialog folderDialog = new DataModelApplication.Common.FolderDialog();
                folderDialog.DisplayDialog("ѡ��ģ������·��");
                if (Directory.Exists(folderDialog.Path) == true)
                {

                    GetTemplateList(folderDialog.Path);
                    TemplateFilePath = folderDialog.Path;
                    lblCurrentTemplatePath.Text = TemplateFilePath;
                    lblTableConfigFilePath.Text = TableConfigFileName;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void lbTemplateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                FileStream fsTemplate;
                fsTemplate = new FileStream(lblCurrentTemplatePath.Text + "\\" + lbTemplateList.SelectedItem.ToString(), FileMode.Open);
                StreamReader srTemplate = new StreamReader(fsTemplate, System.Text.Encoding.GetEncoding("gb2312"));
                txtCodeView.Text = srTemplate.ReadToEnd();
                srTemplate.Close();
                fsTemplate.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GenerateCodeForm_Load(object sender, EventArgs e)
        {
            try
            {
                FileInfo fiTableConfig = new FileInfo(TableConfigFileName);
                if (fiTableConfig.Exists == true)
                {
                    GetTemplateList(Directory.GetCurrentDirectory());
                    lblCurrentTemplatePath.Text = Directory.GetCurrentDirectory();
                    lblTableConfigFilePath.Text = TableConfigFileName;
                }
                else
                {
                    MessageBox.Show("�Ҳ������������ļ������ȱ����ļ���");
                    this.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            try
            {
                //����Xslʵ��
                XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
                //����XmlDocment���ʵ��
                XmlDocument xmlDocument = new XmlDocument();
                //��ָ���ļ������ڴ�
                xmlDocument.Load(TableConfigFileName);

                txtCodeView.Text =
                    DataModelApplication.Common.XMLFileLibrary.ToSourceCode(
                    lblCurrentTemplatePath.Text + "\\" + lbTemplateList.SelectedItem.ToString(),
                    xmlDocument.InnerXml);
            }
            catch (Exception ex)
            {

                MessageBox.Show("��ʽ�Ƿ���ȷ��\r\n �������£�\r\n" + ex.InnerException);
            }
        }

        private void gbTableInfo_Enter(object sender, EventArgs e)
        {

        }

        private void btnCopyToBoard_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodeView.Text != string.Empty)
                {
                    Clipboard.SetDataObject(txtCodeView.Text);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}