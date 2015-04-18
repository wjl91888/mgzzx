using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataModelApplication
{
    public partial class CustomDisplayFieldConfigForm : Form
    {
        public DataTable CustomDisplayFieldConfig { get; set; }

        public DataTable Fields { get; set; }

        public bool SaveFlag { get; set; }

        public CustomDisplayFieldConfigForm()
        {
            SaveFlag = false;
            CustomDisplayFieldConfig = new DataTable();
            InitializeComponent();
            this.IsDisplay.ValueType = System.Type.GetType("System.Boolean");
            this.IsBindData.ValueType = System.Type.GetType("System.Boolean");
            this.IsAdvanceSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsMoreItemSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsRangeSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsSubItemSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsTreeStyle.ValueType = System.Type.GetType("System.Boolean");
            this.IsStatisticalData.ValueType = System.Type.GetType("System.Boolean");
            this.IsRestrictedViewCondition.ValueType = System.Type.GetType("System.Boolean");
            this.IsRestrictedViewSubItem.ValueType = System.Type.GetType("System.Boolean");
            this.IsRelatedUpdate.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTree.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeLink.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeRelatedParent.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeRelatedParentLink.ValueType = System.Type.GetType("System.Boolean");
            this.IsCustomAdd.ValueType = System.Type.GetType("System.Boolean");
            this.IsDispose.ValueType = System.Type.GetType("System.Boolean");
            this.IsDisposeReverse.ValueType = System.Type.GetType("System.Boolean");
            this.IsDisposeOtherTable.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeRelatedParentIndependent.ValueType = System.Type.GetType("System.Boolean");
            this.IsAddBatchField.ValueType = System.Type.GetType("System.Boolean");
            this.IsAddBatchOnlyDisplay.ValueType = System.Type.GetType("System.Boolean");
            this.IsAddBatchModify.ValueType = System.Type.GetType("System.Boolean");
            this.IsFromMainTable.ValueType = System.Type.GetType("System.Boolean");
            this.IsFromTemplateTable.ValueType = System.Type.GetType("System.Boolean");
            this.IsAddBatchVisible.ValueType = System.Type.GetType("System.Boolean");
            this.IsSortClassify.ValueType = System.Type.GetType("System.Boolean");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveFlag = false;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFlag = true;
            CustomDisplayFieldConfig = new DataTable();
            this.IsDisplay.ValueType = System.Type.GetType("System.Boolean");
            this.IsBindData.ValueType = System.Type.GetType("System.Boolean");
            this.IsAdvanceSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsMoreItemSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsRangeSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsSubItemSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsTreeStyle.ValueType = System.Type.GetType("System.Boolean");
            this.IsStatisticalData.ValueType = System.Type.GetType("System.Boolean");
            this.IsRestrictedViewCondition.ValueType = System.Type.GetType("System.Boolean");
            this.IsRestrictedViewSubItem.ValueType = System.Type.GetType("System.Boolean");
            this.IsRelatedUpdate.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTree.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeLink.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeRelatedParent.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeRelatedParentLink.ValueType = System.Type.GetType("System.Boolean");
            this.IsCustomAdd.ValueType = System.Type.GetType("System.Boolean");
            this.IsDispose.ValueType = System.Type.GetType("System.Boolean");
            this.IsDisposeReverse.ValueType = System.Type.GetType("System.Boolean");
            this.IsDisposeOtherTable.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeRelatedParentIndependent.ValueType = System.Type.GetType("System.Boolean");
            this.IsAddBatchField.ValueType = System.Type.GetType("System.Boolean");
            this.IsAddBatchOnlyDisplay.ValueType = System.Type.GetType("System.Boolean");
            this.IsAddBatchModify.ValueType = System.Type.GetType("System.Boolean");
            this.IsFromMainTable.ValueType = System.Type.GetType("System.Boolean");
            this.IsFromTemplateTable.ValueType = System.Type.GetType("System.Boolean");
            this.IsAddBatchVisible.ValueType = System.Type.GetType("System.Boolean");
            this.IsSortClassify.ValueType = System.Type.GetType("System.Boolean");
            foreach (DataGridViewColumn dgvcTemp in dgvCustomDisplayFieldConfig.Columns)
            {
                if (dgvcTemp.ValueType == null)
                {
                    CustomDisplayFieldConfig.Columns.Add(dgvcTemp.Name);
                }
                else
                {
                    CustomDisplayFieldConfig.Columns.Add(dgvcTemp.Name, dgvcTemp.ValueType);
                }
            }
            foreach (DataGridViewRow dgvrTemp in dgvCustomDisplayFieldConfig.Rows)
            {
                DataRow drTemp = CustomDisplayFieldConfig.NewRow();
                foreach (DataGridViewCell dgvcTemp in dgvrTemp.Cells)
                {
                    if (dgvcTemp.Value == null)
                    {
                        if (dgvcTemp.ValueType == System.Type.GetType("System.Boolean"))
                        {
                            drTemp[dgvcTemp.ColumnIndex] = "false";
                        }
                        else
                        {
                            drTemp[dgvcTemp.ColumnIndex] = DBNull.Value;
                        }
                    }
                    else
                    {
                        drTemp[dgvcTemp.ColumnIndex] = dgvcTemp.Value;
                    }
                }
                CustomDisplayFieldConfig.Rows.Add(drTemp);
            }
            this.Close();
        }

        private void CustomDisplayFieldConfigForm_Load(object sender, EventArgs e)
        {
            dgvCustomDisplayFieldConfig.AutoGenerateColumns = false;
            dgvCustomDisplayFieldConfig.DataSource = CustomDisplayFieldConfig;
            dgvCustomDisplayFieldConfig.Columns["IsDisplay"].DataPropertyName = "IsDisplay";
            dgvCustomDisplayFieldConfig.Columns["DisplayName"].DataPropertyName = "DisplayName";
            dgvCustomDisplayFieldConfig.Columns["DisplayFieldName"].DataPropertyName = "DisplayFieldName";
            dgvCustomDisplayFieldConfig.Columns["SerialNumber"].DataPropertyName = "SerialNumber";
            dgvCustomDisplayFieldConfig.Columns["RelatedInfoName"].DataPropertyName = "RelatedInfoName";
            dgvCustomDisplayFieldConfig.Columns["RelatedTableType"].DataPropertyName = "RelatedTableType";
            dgvCustomDisplayFieldConfig.Columns["RelatedTableOwner"].DataPropertyName = "RelatedTableOwner";
            dgvCustomDisplayFieldConfig.Columns["RelatedTableName"].DataPropertyName = "RelatedTableName";
            dgvCustomDisplayFieldConfig.Columns["TableWithField"].DataPropertyName = "TableWithField";
            dgvCustomDisplayFieldConfig.Columns["RelatedTableWithField"].DataPropertyName = "RelatedTableWithField";
            dgvCustomDisplayFieldConfig.Columns["IsBindData"].DataPropertyName = "IsBindData";
            dgvCustomDisplayFieldConfig.Columns["BindDataTableOwner"].DataPropertyName = "BindDataTableOwner";
            dgvCustomDisplayFieldConfig.Columns["BindDataTableName"].DataPropertyName = "BindDataTableName";
            dgvCustomDisplayFieldConfig.Columns["BindDataFieldName"].DataPropertyName = "BindDataFieldName";
            dgvCustomDisplayFieldConfig.Columns["BindDataRelativeFieldName"].DataPropertyName = "BindDataRelativeFieldName";
            dgvCustomDisplayFieldConfig.Columns["IsAdvanceSearch"].DataPropertyName = "IsAdvanceSearch";
            dgvCustomDisplayFieldConfig.Columns["IsMoreItemSearch"].DataPropertyName = "IsMoreItemSearch";
            dgvCustomDisplayFieldConfig.Columns["IsRangeSearch"].DataPropertyName = "IsRangeSearch";
            dgvCustomDisplayFieldConfig.Columns["IsSubItemSearch"].DataPropertyName = "IsSubItemSearch";
            dgvCustomDisplayFieldConfig.Columns["IsTreeStyle"].DataPropertyName = "IsTreeStyle";
            dgvCustomDisplayFieldConfig.Columns["TreeParentNode"].DataPropertyName = "TreeParentNode";
            dgvCustomDisplayFieldConfig.Columns["TreeParentNodeValue"].DataPropertyName = "TreeParentNodeValue";
            dgvCustomDisplayFieldConfig.Columns["IsStatisticalData"].DataPropertyName = "IsStatisticalData";
            dgvCustomDisplayFieldConfig.Columns["DataBindCondition"].DataPropertyName = "DataBindCondition";
            dgvCustomDisplayFieldConfig.Columns["DataBindConditionValue"].DataPropertyName = "DataBindConditionValue";
            dgvCustomDisplayFieldConfig.Columns["IsRestrictedViewCondition"].DataPropertyName = "IsRestrictedViewCondition";
            dgvCustomDisplayFieldConfig.Columns["IsRestrictedViewSubItem"].DataPropertyName = "IsRestrictedViewSubItem";
            dgvCustomDisplayFieldConfig.Columns["RestrictedViewCondition"].DataPropertyName = "RestrictedViewCondition";
            dgvCustomDisplayFieldConfig.Columns["IsRelatedUpdate"].DataPropertyName = "IsRelatedUpdate";
            dgvCustomDisplayFieldConfig.Columns["RelatedUpdateType"].DataPropertyName = "RelatedUpdateType";
            dgvCustomDisplayFieldConfig.Columns["RelatedUpdateValue"].DataPropertyName = "RelatedUpdateValue";
            dgvCustomDisplayFieldConfig.Columns["RelatedUpdateField"].DataPropertyName = "RelatedUpdateField";

            dgvCustomDisplayFieldConfig.Columns["TitleRow"].DataPropertyName = "TitleRow";
            dgvCustomDisplayFieldConfig.Columns["TitleColumn"].DataPropertyName = "TitleColumn";
            dgvCustomDisplayFieldConfig.Columns["TitleRowSpan"].DataPropertyName = "TitleRowSpan";
            dgvCustomDisplayFieldConfig.Columns["TitleColumnSpan"].DataPropertyName = "TitleColumnSpan";
            dgvCustomDisplayFieldConfig.Columns["ContentRow"].DataPropertyName = "ContentRow";
            dgvCustomDisplayFieldConfig.Columns["ContentColumn"].DataPropertyName = "ContentColumn";
            dgvCustomDisplayFieldConfig.Columns["ContentRowSpan"].DataPropertyName = "ContentRowSpan";
            dgvCustomDisplayFieldConfig.Columns["ContentColumnSpan"].DataPropertyName = "ContentColumnSpan";
            dgvCustomDisplayFieldConfig.Columns["ComboTreeLevel"].DataPropertyName = "ComboTreeLevel";
            dgvCustomDisplayFieldConfig.Columns["IsComboTree"].DataPropertyName = "IsComboTree";
            dgvCustomDisplayFieldConfig.Columns["IsComboTreeLink"].DataPropertyName = "IsComboTreeLink";
            dgvCustomDisplayFieldConfig.Columns["ComboTreeParent"].DataPropertyName = "ComboTreeParent";
            dgvCustomDisplayFieldConfig.Columns["IsComboTreeRelatedParent"].DataPropertyName = "IsComboTreeRelatedParent";
            dgvCustomDisplayFieldConfig.Columns["ComboTreeRelatedParentTable"].DataPropertyName = "ComboTreeRelatedParentTable";
            dgvCustomDisplayFieldConfig.Columns["ComboTreeRelatedParent"].DataPropertyName = "ComboTreeRelatedParent";
            dgvCustomDisplayFieldConfig.Columns["ComboTreeRelatedParentDisplayField"].DataPropertyName = "ComboTreeRelatedParentDisplayField";
            dgvCustomDisplayFieldConfig.Columns["ComboTreeRelatedParentValueField"].DataPropertyName = "ComboTreeRelatedParentValueField";
            dgvCustomDisplayFieldConfig.Columns["ComboTreeRelatedParentWithField"].DataPropertyName = "ComboTreeRelatedParentWithField";
            dgvCustomDisplayFieldConfig.Columns["IsComboTreeRelatedParentLink"].DataPropertyName = "IsComboTreeRelatedParentLink";
            dgvCustomDisplayFieldConfig.Columns["IsCustomAdd"].DataPropertyName = "IsCustomAdd";
            dgvCustomDisplayFieldConfig.Columns["CustomAddWithField"].DataPropertyName = "CustomAddWithField";
            dgvCustomDisplayFieldConfig.Columns["TextAlign"].DataPropertyName = "TextAlign";
            dgvCustomDisplayFieldConfig.Columns["IsDispose"].DataPropertyName = "IsDispose";
            dgvCustomDisplayFieldConfig.Columns["DisposeSetValue"].DataPropertyName = "DisposeSetValue";
            dgvCustomDisplayFieldConfig.Columns["IsDisposeReverse"].DataPropertyName = "IsDisposeReverse";
            dgvCustomDisplayFieldConfig.Columns["IsDisposeOtherTable"].DataPropertyName = "IsDisposeOtherTable";
            dgvCustomDisplayFieldConfig.Columns["DisposeMode"].DataPropertyName = "DisposeMode";
            dgvCustomDisplayFieldConfig.Columns["IsComboTreeRelatedParentIndependent"].DataPropertyName = "IsComboTreeRelatedParentIndependent";

            dgvCustomDisplayFieldConfig.Columns["IsAddBatchField"].DataPropertyName = "IsAddBatchField";
            dgvCustomDisplayFieldConfig.Columns["IsAddBatchOnlyDisplay"].DataPropertyName = "IsAddBatchOnlyDisplay";
            dgvCustomDisplayFieldConfig.Columns["IsAddBatchModify"].DataPropertyName = "IsAddBatchModify";
            dgvCustomDisplayFieldConfig.Columns["IsFromMainTable"].DataPropertyName = "IsFromMainTable";
            dgvCustomDisplayFieldConfig.Columns["IsFromTemplateTable"].DataPropertyName = "IsFromTemplateTable";
            dgvCustomDisplayFieldConfig.Columns["FromTableField"].DataPropertyName = "FromTableField";
            dgvCustomDisplayFieldConfig.Columns["AddBatchDisplaySort"].DataPropertyName = "AddBatchDisplaySort";
            dgvCustomDisplayFieldConfig.Columns["IsAddBatchVisible"].DataPropertyName = "IsAddBatchVisible";
            dgvCustomDisplayFieldConfig.Columns["IsSortClassify"].DataPropertyName = "IsSortClassify";
        }
    }
}