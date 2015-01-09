using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace RICH.Common
{
    public class CustomTemplateField : ITemplate
    {
        // 自定义模板列类型
        private ListItemType m_TemplateType = ListItemType.Item;
        public ListItemType TemplateType
        {
            set { m_TemplateType = value; }
            get { return m_TemplateType; }
        }
        // 自定义模板列列名
        private string m_ColumnName = "CustomTemplateField";
        public string ColumnName
        {
            set { m_ColumnName = value; }
            get { return m_ColumnName; }
        }
        // 自定义模板列标题
        private string m_ColumnHeadText = "自定义模板列";
        public string ColumnHeadText
        {
            set { m_ColumnHeadText = value; }
            get { return m_ColumnHeadText; }
        }
        // 自定义模板列底端
        private string m_ColumnFootText = "自定义模板列底端";
        public string ColumnFootText
        {
            set { m_ColumnFootText = value; }
            get { return m_ColumnFootText; }
        }
        // 自定义模板列是否是绑定列
        public bool IsBoundField { get; set; }
        // 自定义模板列绑定列名
        private string m_BoundFieldName = "NoBoundField";
        public string BoundFieldName
        {
            set { m_BoundFieldName = value; }
            get { return m_BoundFieldName; }
        }
        // 自定义模板列控件类型
        public TemplateFieldControlType ControlType { get; set; }

        // 下拉列表储存字段
        public string DropDownListField { get; set; }

        public string DisplayName { get; set; }
        public string CommandArgument { get; set; }
        public string Width { get; set; }
        // 自定义模板列控件类型枚举
        public enum TemplateFieldControlType
        {
            TextBox,
            DropDownList,
            Label,
            CheckBoxList,
            RadioButtonList,
            LinkButton
        }

        public CustomTemplateField()
        {
        }

        public CustomTemplateField(ListItemType litTemplateType,
            string strColumnName,
            string strColumnHeadText,
            string strColumnFootText,
            bool boolIsBoundField,
            string strBoundFieldName,
            TemplateFieldControlType tfctControlType,
            string strDropDownListField = null, 
            string strDisplayName = null, 
            string strCommandArgument = null,
            string strWidth = null
            )
        {
            this.BoundFieldName = strBoundFieldName;
            this.ColumnFootText = strColumnFootText;
            this.ColumnHeadText = strColumnHeadText;
            this.ColumnName = strColumnName;
            this.ControlType = tfctControlType;
            this.IsBoundField = boolIsBoundField;
            this.TemplateType = litTemplateType;
            this.DropDownListField = strDropDownListField;
            this.DisplayName = strDisplayName;
            this.CommandArgument = strCommandArgument;
            this.Width = strWidth;
        }

        public CustomTemplateField(string strColumnHeadText)
        {
            this.ColumnHeadText = strColumnHeadText;
            this.TemplateType = ListItemType.Header;
        }

        public CustomTemplateField(string strColumnName, TemplateFieldControlType tfctControlType, string strDropDownListField = null, string strDisplayName = null, string strCommandArgument = null, string strWidth = null)
        {
            this.ColumnName = strColumnName;
            this.ControlType = tfctControlType;
            this.IsBoundField = false;
            this.TemplateType = ListItemType.Item;
            this.DropDownListField = strDropDownListField;
            this.DisplayName = strDisplayName;
            this.CommandArgument = strCommandArgument;
            this.Width = strWidth; 
        }

        public CustomTemplateField(string strColumnName, string strBoundFieldName)
        {
            this.ColumnName = strColumnName;
            this.ControlType = TemplateFieldControlType.Label;
            this.IsBoundField = true;
            this.BoundFieldName = strBoundFieldName;
            this.TemplateType = ListItemType.Item;
        }

        public CustomTemplateField(string strColumnName, string strBoundFieldName, TemplateFieldControlType tfctControlType, string strDropDownListField = null, string strDisplayName = null, string strCommandArgument = null, string strWidth = null)
        {
            this.ColumnName = strColumnName;
            this.ControlType = tfctControlType;
            this.IsBoundField = true;
            this.BoundFieldName = strBoundFieldName;
            this.TemplateType = ListItemType.Item;
            this.DropDownListField = strDropDownListField;
            this.DisplayName = strDisplayName;
            this.CommandArgument = strCommandArgument;
            this.Width = strWidth;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            // PlaceHolder ph = new PlaceHolder();
            Literal lc = new Literal();
            switch (this.TemplateType)
            {
                case ListItemType.Header:
                    lc.Text = "<B>" + this.ColumnHeadText + "</B>";
                    container.Controls.Add(lc);
                    break;
                case ListItemType.Item:
                    Control webControl = new Control();
                    switch (this.ControlType)
                    {
                        case TemplateFieldControlType.TextBox:
                            webControl = new TextBox();
                            if (RICH.Common.DataValidateManager.ValidateIsNull(this.Width) == false)
                            {
                                ((TextBox) webControl).Width = int.Parse(this.Width);
                            }
                            break;
                        case TemplateFieldControlType.DropDownList:
                            webControl = new DropDownList();
                            if (RICH.Common.DataValidateManager.ValidateIsNull(this.Width) == false)
                            {
                                ((DropDownList)webControl).Width = int.Parse(this.Width);
                            }
                            break;
                        case TemplateFieldControlType.Label:
                            webControl = new Label();
                            break;
                        case TemplateFieldControlType.CheckBoxList:
                            webControl = new CheckBoxList();
                            break;
                        case TemplateFieldControlType.RadioButtonList:
                            webControl = new RadioButtonList();
                            break;
                        case TemplateFieldControlType.LinkButton:
                            webControl = new LinkButton();
                            ((LinkButton)webControl).Text = this.DisplayName;
                            ((LinkButton)webControl).CommandName = this.ColumnName;
                            ((LinkButton)webControl).CommandArgument = this.CommandArgument;
                            if (RICH.Common.DataValidateManager.ValidateIsNull(this.Width) == false)
                            {
                                ((LinkButton)webControl).Width = int.Parse(this.Width);
                            }
                            break;
                        default:
                            webControl = new Label();
                            break;
                    }
                    webControl.ID = this.ColumnName;
                    //if (this.IsBoundField == true)
                    //{
                        webControl.DataBinding += new EventHandler(this.OnDataBinding);
                    //}
                    container.Controls.Add(webControl);
                    break;
                case ListItemType.EditItem:
                    TextBox tbb = new TextBox();
                    tbb.Text = "";
                    container.Controls.Add(tbb);
                    break;
                case ListItemType.Footer:
                    lc.Text = "<I>" + this.ColumnFootText + "</I>";
                    container.Controls.Add(lc);
                    break;
            }
        }
        public void OnDataBinding(object sender, EventArgs e)
        {
            // 发送绑定请求
            Control webControl = (Control)sender;
            GridViewRow container = (GridViewRow)webControl.NamingContainer;
            switch (this.ControlType)
            {
                case TemplateFieldControlType.TextBox:
                    if (this.IsBoundField == true)
                    {
                        ((TextBox)webControl).Text = RICH.Common.DataValidateManager.ValidateIsNull(((System.Data.DataRowView)container.DataItem)[this.BoundFieldName]) == true ? string.Empty : (string)((System.Data.DataRowView)container.DataItem)[this.BoundFieldName];

                    }
                    if (RICH.Common.DataValidateManager.ValidateIsNull(this.DropDownListField) == false)
                    {
                        ((TextBox)webControl).Attributes.Add("onclick", RICH.Common.DataValidateManager.ValidateIsNull(((System.Data.DataRowView)container.DataItem)[this.DropDownListField]) == true ? string.Empty : "openLayer(this, '" + (string)((System.Data.DataRowView)container.DataItem)[this.DropDownListField] + "WebUIListAJAX.aspx');");
                        ((TextBox)webControl).Attributes.Add("onpropertychange", RICH.Common.DataValidateManager.ValidateIsNull(((System.Data.DataRowView)container.DataItem)[this.DropDownListField]) == true ? string.Empty : "openLayer(this, '" + (string)((System.Data.DataRowView)container.DataItem)[this.DropDownListField] + "WebUIListAJAX.aspx');");                        
                    }
                    break;
                case TemplateFieldControlType.DropDownList:
                    if (this.IsBoundField == true)
                    {
                        ((DropDownList)webControl).SelectedValue = RICH.Common.DataValidateManager.ValidateIsNull(((System.Data.DataRowView)container.DataItem)[this.BoundFieldName]) == true ? string.Empty : (string)((System.Data.DataRowView)container.DataItem)[this.BoundFieldName];
                    }
                    break;
                case TemplateFieldControlType.Label:
                    if (this.IsBoundField == true)
                    {
                        ((Label)webControl).Text = RICH.Common.DataValidateManager.ValidateIsNull(((System.Data.DataRowView)container.DataItem)[this.BoundFieldName]) == true ? string.Empty : (string)((System.Data.DataRowView)container.DataItem)[this.BoundFieldName];
                    }
                    break;
                case TemplateFieldControlType.CheckBoxList:
                    if (this.IsBoundField == true)
                    {
                        ((CheckBoxList)webControl).SelectedValue = RICH.Common.DataValidateManager.ValidateIsNull(((System.Data.DataRowView)container.DataItem)[this.BoundFieldName]) == true ? string.Empty : (string)((System.Data.DataRowView)container.DataItem)[this.BoundFieldName];
                    }
                    break;
                case TemplateFieldControlType.RadioButtonList:
                    if (this.IsBoundField == true)
                    {
                        ((RadioButtonList)webControl).SelectedValue = RICH.Common.DataValidateManager.ValidateIsNull(((System.Data.DataRowView)container.DataItem)[this.BoundFieldName]) == true ? string.Empty : (string)((System.Data.DataRowView)container.DataItem)[this.BoundFieldName];
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
