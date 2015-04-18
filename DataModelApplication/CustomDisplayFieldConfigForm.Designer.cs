namespace DataModelApplication
{
    partial class CustomDisplayFieldConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvCustomDisplayFieldConfig = new System.Windows.Forms.DataGridView();
            this.IsDisplay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsBindData = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BindDataTableOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BindDataTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BindDataFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BindDataRelativeFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsTreeStyle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TreeParentNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TreeParentNodeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataBindCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataBindConditionValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsRestrictedViewCondition = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsRestrictedViewSubItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RestrictedViewCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAdvanceSearch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsRangeSearch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsMoreItemSearch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsSubItemSearch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsStatisticalData = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsRelatedUpdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RelatedUpdateType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RelatedUpdateField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedUpdateValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleRowSpan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleColumnSpan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentRowSpan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentColumnSpan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextAlign = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedInfoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedTableType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RelatedTableOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableWithField = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RelatedTableWithField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsComboTree = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ComboTreeLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsComboTreeLink = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ComboTreeParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsComboTreeRelatedParent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsComboTreeRelatedParentIndependent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ComboTreeRelatedParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComboTreeRelatedParentTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComboTreeRelatedParentDisplayField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComboTreeRelatedParentValueField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComboTreeRelatedParentWithField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsComboTreeRelatedParentLink = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsCustomAdd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CustomAddWithField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDispose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsDisposeOtherTable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DisposeMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DisposeSetValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDisposeReverse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsAddBatchField = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsAddBatchOnlyDisplay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsAddBatchVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsAddBatchModify = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AddBatchDisplaySort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFromMainTable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsFromTemplateTable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FromTableField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSortClassify = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomDisplayFieldConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCustomDisplayFieldConfig);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(670, 419);
            this.splitContainer1.SplitterDistance = 370;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvCustomDisplayFieldConfig
            // 
            this.dgvCustomDisplayFieldConfig.AllowUserToAddRows = false;
            this.dgvCustomDisplayFieldConfig.AllowUserToDeleteRows = false;
            this.dgvCustomDisplayFieldConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomDisplayFieldConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsDisplay,
            this.DisplayName,
            this.DisplayFieldName,
            this.IsBindData,
            this.BindDataTableOwner,
            this.BindDataTableName,
            this.BindDataFieldName,
            this.BindDataRelativeFieldName,
            this.IsTreeStyle,
            this.TreeParentNode,
            this.TreeParentNodeValue,
            this.DataBindCondition,
            this.DataBindConditionValue,
            this.IsRestrictedViewCondition,
            this.IsRestrictedViewSubItem,
            this.RestrictedViewCondition,
            this.IsAdvanceSearch,
            this.IsRangeSearch,
            this.IsMoreItemSearch,
            this.IsSubItemSearch,
            this.IsStatisticalData,
            this.IsRelatedUpdate,
            this.RelatedUpdateType,
            this.RelatedUpdateField,
            this.RelatedUpdateValue,
            this.TitleRow,
            this.TitleColumn,
            this.TitleRowSpan,
            this.TitleColumnSpan,
            this.ContentRow,
            this.ContentColumn,
            this.ContentRowSpan,
            this.ContentColumnSpan,
            this.TextAlign,
            this.SerialNumber,
            this.RelatedInfoName,
            this.RelatedTableType,
            this.RelatedTableOwner,
            this.RelatedTableName,
            this.TableWithField,
            this.RelatedTableWithField,
            this.IsComboTree,
            this.ComboTreeLevel,
            this.IsComboTreeLink,
            this.ComboTreeParent,
            this.IsComboTreeRelatedParent,
            this.IsComboTreeRelatedParentIndependent,
            this.ComboTreeRelatedParent,
            this.ComboTreeRelatedParentTable,
            this.ComboTreeRelatedParentDisplayField,
            this.ComboTreeRelatedParentValueField,
            this.ComboTreeRelatedParentWithField,
            this.IsComboTreeRelatedParentLink,
            this.IsCustomAdd,
            this.CustomAddWithField,
            this.IsDispose,
            this.IsDisposeOtherTable,
            this.DisposeMode,
            this.DisposeSetValue,
            this.IsDisposeReverse,
            this.IsAddBatchField,
            this.IsAddBatchOnlyDisplay,
            this.IsAddBatchVisible,
            this.IsAddBatchModify,
            this.AddBatchDisplaySort,
            this.IsFromMainTable,
            this.IsFromTemplateTable,
            this.FromTableField,
            this.IsSortClassify});
            this.dgvCustomDisplayFieldConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomDisplayFieldConfig.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomDisplayFieldConfig.Name = "dgvCustomDisplayFieldConfig";
            this.dgvCustomDisplayFieldConfig.RowTemplate.Height = 23;
            this.dgvCustomDisplayFieldConfig.Size = new System.Drawing.Size(670, 370);
            this.dgvCustomDisplayFieldConfig.TabIndex = 1;
            // 
            // IsDisplay
            // 
            this.IsDisplay.Frozen = true;
            this.IsDisplay.HeaderText = "显示";
            this.IsDisplay.Name = "IsDisplay";
            this.IsDisplay.Width = 40;
            // 
            // DisplayName
            // 
            this.DisplayName.Frozen = true;
            this.DisplayName.HeaderText = "显示名称";
            this.DisplayName.Name = "DisplayName";
            // 
            // DisplayFieldName
            // 
            this.DisplayFieldName.Frozen = true;
            this.DisplayFieldName.HeaderText = "字段名称";
            this.DisplayFieldName.Name = "DisplayFieldName";
            this.DisplayFieldName.ReadOnly = true;
            this.DisplayFieldName.Width = 150;
            // 
            // IsBindData
            // 
            this.IsBindData.HeaderText = "绑定数据";
            this.IsBindData.Name = "IsBindData";
            this.IsBindData.Width = 60;
            // 
            // BindDataTableOwner
            // 
            this.BindDataTableOwner.HeaderText = "绑定表Owner";
            this.BindDataTableOwner.Name = "BindDataTableOwner";
            // 
            // BindDataTableName
            // 
            this.BindDataTableName.HeaderText = "绑定表名";
            this.BindDataTableName.Name = "BindDataTableName";
            // 
            // BindDataFieldName
            // 
            this.BindDataFieldName.HeaderText = "绑定列名";
            this.BindDataFieldName.Name = "BindDataFieldName";
            // 
            // BindDataRelativeFieldName
            // 
            this.BindDataRelativeFieldName.HeaderText = "绑定对应列名";
            this.BindDataRelativeFieldName.Name = "BindDataRelativeFieldName";
            // 
            // IsTreeStyle
            // 
            this.IsTreeStyle.HeaderText = "树形结构";
            this.IsTreeStyle.Name = "IsTreeStyle";
            this.IsTreeStyle.Width = 60;
            // 
            // TreeParentNode
            // 
            this.TreeParentNode.HeaderText = "上级节点";
            this.TreeParentNode.Name = "TreeParentNode";
            this.TreeParentNode.Width = 80;
            // 
            // TreeParentNodeValue
            // 
            this.TreeParentNodeValue.HeaderText = "上级节点值";
            this.TreeParentNodeValue.Name = "TreeParentNodeValue";
            this.TreeParentNodeValue.Width = 80;
            // 
            // DataBindCondition
            // 
            this.DataBindCondition.HeaderText = "绑定条件列";
            this.DataBindCondition.Name = "DataBindCondition";
            this.DataBindCondition.Width = 80;
            // 
            // DataBindConditionValue
            // 
            this.DataBindConditionValue.HeaderText = "绑定条件值";
            this.DataBindConditionValue.Name = "DataBindConditionValue";
            this.DataBindConditionValue.Width = 80;
            // 
            // IsRestrictedViewCondition
            // 
            this.IsRestrictedViewCondition.HeaderText = "限制浏览";
            this.IsRestrictedViewCondition.Name = "IsRestrictedViewCondition";
            this.IsRestrictedViewCondition.Width = 60;
            // 
            // IsRestrictedViewSubItem
            // 
            this.IsRestrictedViewSubItem.HeaderText = "限制浏览包含子项";
            this.IsRestrictedViewSubItem.Name = "IsRestrictedViewSubItem";
            // 
            // RestrictedViewCondition
            // 
            this.RestrictedViewCondition.HeaderText = "限制浏览条件";
            this.RestrictedViewCondition.Name = "RestrictedViewCondition";
            // 
            // IsAdvanceSearch
            // 
            this.IsAdvanceSearch.HeaderText = "高级查询";
            this.IsAdvanceSearch.Name = "IsAdvanceSearch";
            this.IsAdvanceSearch.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsAdvanceSearch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsAdvanceSearch.Width = 60;
            // 
            // IsRangeSearch
            // 
            this.IsRangeSearch.HeaderText = "范围查询";
            this.IsRangeSearch.Name = "IsRangeSearch";
            this.IsRangeSearch.Width = 60;
            // 
            // IsMoreItemSearch
            // 
            this.IsMoreItemSearch.HeaderText = "多项查询";
            this.IsMoreItemSearch.Name = "IsMoreItemSearch";
            this.IsMoreItemSearch.Width = 60;
            // 
            // IsSubItemSearch
            // 
            this.IsSubItemSearch.HeaderText = "子项查询";
            this.IsSubItemSearch.Name = "IsSubItemSearch";
            this.IsSubItemSearch.Width = 60;
            // 
            // IsStatisticalData
            // 
            this.IsStatisticalData.HeaderText = "统计数据";
            this.IsStatisticalData.Name = "IsStatisticalData";
            this.IsStatisticalData.Width = 60;
            // 
            // IsRelatedUpdate
            // 
            this.IsRelatedUpdate.HeaderText = "相关更新";
            this.IsRelatedUpdate.Name = "IsRelatedUpdate";
            this.IsRelatedUpdate.Width = 60;
            // 
            // RelatedUpdateType
            // 
            this.RelatedUpdateType.HeaderText = "相关更新类型";
            this.RelatedUpdateType.Items.AddRange(new object[] {
            "加一",
            "减一",
            "加",
            "减",
            "自定义"});
            this.RelatedUpdateType.Name = "RelatedUpdateType";
            this.RelatedUpdateType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RelatedUpdateType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // RelatedUpdateField
            // 
            this.RelatedUpdateField.HeaderText = "更新取值字段";
            this.RelatedUpdateField.Name = "RelatedUpdateField";
            // 
            // RelatedUpdateValue
            // 
            this.RelatedUpdateValue.HeaderText = "更新代码";
            this.RelatedUpdateValue.Name = "RelatedUpdateValue";
            // 
            // TitleRow
            // 
            this.TitleRow.HeaderText = "标题行";
            this.TitleRow.Name = "TitleRow";
            this.TitleRow.Width = 60;
            // 
            // TitleColumn
            // 
            this.TitleColumn.HeaderText = "标题列";
            this.TitleColumn.Name = "TitleColumn";
            this.TitleColumn.Width = 60;
            // 
            // TitleRowSpan
            // 
            this.TitleRowSpan.HeaderText = "标题跨行";
            this.TitleRowSpan.Name = "TitleRowSpan";
            this.TitleRowSpan.Width = 60;
            // 
            // TitleColumnSpan
            // 
            this.TitleColumnSpan.HeaderText = "标题跨列";
            this.TitleColumnSpan.Name = "TitleColumnSpan";
            this.TitleColumnSpan.Width = 60;
            // 
            // ContentRow
            // 
            this.ContentRow.HeaderText = "内容行";
            this.ContentRow.Name = "ContentRow";
            this.ContentRow.Width = 60;
            // 
            // ContentColumn
            // 
            this.ContentColumn.HeaderText = "内容列";
            this.ContentColumn.Name = "ContentColumn";
            this.ContentColumn.Width = 60;
            // 
            // ContentRowSpan
            // 
            this.ContentRowSpan.HeaderText = "内容跨行";
            this.ContentRowSpan.Name = "ContentRowSpan";
            this.ContentRowSpan.Width = 60;
            // 
            // ContentColumnSpan
            // 
            this.ContentColumnSpan.HeaderText = "内容跨列";
            this.ContentColumnSpan.Name = "ContentColumnSpan";
            this.ContentColumnSpan.Width = 60;
            // 
            // TextAlign
            // 
            this.TextAlign.HeaderText = "内容位置";
            this.TextAlign.Items.AddRange(new object[] {
            "Center",
            "Left",
            "Right"});
            this.TextAlign.Name = "TextAlign";
            // 
            // SerialNumber
            // 
            this.SerialNumber.HeaderText = "序号";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SerialNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SerialNumber.Visible = false;
            this.SerialNumber.Width = 40;
            // 
            // RelatedInfoName
            // 
            this.RelatedInfoName.HeaderText = "相关信息名称";
            this.RelatedInfoName.Name = "RelatedInfoName";
            this.RelatedInfoName.Visible = false;
            this.RelatedInfoName.Width = 110;
            // 
            // RelatedTableType
            // 
            this.RelatedTableType.HeaderText = "类型";
            this.RelatedTableType.Name = "RelatedTableType";
            this.RelatedTableType.Visible = false;
            this.RelatedTableType.Width = 80;
            // 
            // RelatedTableOwner
            // 
            this.RelatedTableOwner.HeaderText = "相关表Owner";
            this.RelatedTableOwner.Name = "RelatedTableOwner";
            this.RelatedTableOwner.Visible = false;
            // 
            // RelatedTableName
            // 
            this.RelatedTableName.HeaderText = "相关表名称";
            this.RelatedTableName.Name = "RelatedTableName";
            this.RelatedTableName.Visible = false;
            // 
            // TableWithField
            // 
            this.TableWithField.HeaderText = "主表关联字段";
            this.TableWithField.Name = "TableWithField";
            this.TableWithField.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TableWithField.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TableWithField.Visible = false;
            this.TableWithField.Width = 110;
            // 
            // RelatedTableWithField
            // 
            this.RelatedTableWithField.HeaderText = "对应字段";
            this.RelatedTableWithField.Name = "RelatedTableWithField";
            this.RelatedTableWithField.Visible = false;
            // 
            // IsComboTree
            // 
            this.IsComboTree.HeaderText = "组合树";
            this.IsComboTree.Name = "IsComboTree";
            this.IsComboTree.Width = 60;
            // 
            // ComboTreeLevel
            // 
            this.ComboTreeLevel.HeaderText = "组合树级别";
            this.ComboTreeLevel.Name = "ComboTreeLevel";
            this.ComboTreeLevel.Width = 80;
            // 
            // IsComboTreeLink
            // 
            this.IsComboTreeLink.HeaderText = "组合树链接";
            this.IsComboTreeLink.Name = "IsComboTreeLink";
            this.IsComboTreeLink.Width = 80;
            // 
            // ComboTreeParent
            // 
            this.ComboTreeParent.HeaderText = "组合树父节点";
            this.ComboTreeParent.Name = "ComboTreeParent";
            // 
            // IsComboTreeRelatedParent
            // 
            this.IsComboTreeRelatedParent.HeaderText = "存在相关父节点";
            this.IsComboTreeRelatedParent.Name = "IsComboTreeRelatedParent";
            // 
            // IsComboTreeRelatedParentIndependent
            // 
            this.IsComboTreeRelatedParentIndependent.HeaderText = "独立相关父节点";
            this.IsComboTreeRelatedParentIndependent.Name = "IsComboTreeRelatedParentIndependent";
            // 
            // ComboTreeRelatedParent
            // 
            this.ComboTreeRelatedParent.HeaderText = "相关父节点";
            this.ComboTreeRelatedParent.Name = "ComboTreeRelatedParent";
            // 
            // ComboTreeRelatedParentTable
            // 
            this.ComboTreeRelatedParentTable.HeaderText = "相关父节点表";
            this.ComboTreeRelatedParentTable.Name = "ComboTreeRelatedParentTable";
            // 
            // ComboTreeRelatedParentDisplayField
            // 
            this.ComboTreeRelatedParentDisplayField.HeaderText = "相关父节点显示列";
            this.ComboTreeRelatedParentDisplayField.Name = "ComboTreeRelatedParentDisplayField";
            // 
            // ComboTreeRelatedParentValueField
            // 
            this.ComboTreeRelatedParentValueField.HeaderText = "相关父节点值列";
            this.ComboTreeRelatedParentValueField.Name = "ComboTreeRelatedParentValueField";
            // 
            // ComboTreeRelatedParentWithField
            // 
            this.ComboTreeRelatedParentWithField.HeaderText = "相关父节点对应列";
            this.ComboTreeRelatedParentWithField.Name = "ComboTreeRelatedParentWithField";
            // 
            // IsComboTreeRelatedParentLink
            // 
            this.IsComboTreeRelatedParentLink.HeaderText = "相关父节点链接";
            this.IsComboTreeRelatedParentLink.Name = "IsComboTreeRelatedParentLink";
            // 
            // IsCustomAdd
            // 
            this.IsCustomAdd.HeaderText = "定制添加";
            this.IsCustomAdd.Name = "IsCustomAdd";
            this.IsCustomAdd.Width = 60;
            // 
            // CustomAddWithField
            // 
            this.CustomAddWithField.HeaderText = "定制添加对应字段";
            this.CustomAddWithField.Name = "CustomAddWithField";
            // 
            // IsDispose
            // 
            this.IsDispose.HeaderText = "快速处理";
            this.IsDispose.Name = "IsDispose";
            this.IsDispose.Width = 60;
            // 
            // IsDisposeOtherTable
            // 
            this.IsDisposeOtherTable.HeaderText = "处理其他表";
            this.IsDisposeOtherTable.Name = "IsDisposeOtherTable";
            this.IsDisposeOtherTable.Width = 80;
            // 
            // DisposeMode
            // 
            this.DisposeMode.HeaderText = "处理方式";
            this.DisposeMode.Items.AddRange(new object[] {
            "Insert",
            "Update",
            "Delete"});
            this.DisposeMode.Name = "DisposeMode";
            this.DisposeMode.Width = 60;
            // 
            // DisposeSetValue
            // 
            this.DisposeSetValue.HeaderText = "处理赋值";
            this.DisposeSetValue.Name = "DisposeSetValue";
            this.DisposeSetValue.Width = 80;
            // 
            // IsDisposeReverse
            // 
            this.IsDisposeReverse.HeaderText = "反向处理";
            this.IsDisposeReverse.Name = "IsDisposeReverse";
            this.IsDisposeReverse.Width = 60;
            // 
            // IsAddBatchField
            // 
            this.IsAddBatchField.HeaderText = "批量添加字段";
            this.IsAddBatchField.Name = "IsAddBatchField";
            // 
            // IsAddBatchOnlyDisplay
            // 
            this.IsAddBatchOnlyDisplay.HeaderText = "列表中存在";
            this.IsAddBatchOnlyDisplay.Name = "IsAddBatchOnlyDisplay";
            // 
            // IsAddBatchVisible
            // 
            this.IsAddBatchVisible.HeaderText = "可见";
            this.IsAddBatchVisible.Name = "IsAddBatchVisible";
            this.IsAddBatchVisible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsAddBatchVisible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsAddBatchModify
            // 
            this.IsAddBatchModify.HeaderText = "可修改";
            this.IsAddBatchModify.Name = "IsAddBatchModify";
            // 
            // AddBatchDisplaySort
            // 
            this.AddBatchDisplaySort.HeaderText = "批量添加显示序号";
            this.AddBatchDisplaySort.Name = "AddBatchDisplaySort";
            // 
            // IsFromMainTable
            // 
            this.IsFromMainTable.HeaderText = "从主表获取值";
            this.IsFromMainTable.Name = "IsFromMainTable";
            // 
            // IsFromTemplateTable
            // 
            this.IsFromTemplateTable.HeaderText = "从模板表取值";
            this.IsFromTemplateTable.Name = "IsFromTemplateTable";
            // 
            // FromTableField
            // 
            this.FromTableField.HeaderText = "取值对应他表字段";
            this.FromTableField.Name = "FromTableField";
            // 
            // IsSortClassify
            // 
            this.IsSortClassify.HeaderText = "排序分类";
            this.IsSortClassify.Name = "IsSortClassify";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(365, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(226, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CustomDisplayFieldConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 419);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "CustomDisplayFieldConfigForm";
            this.Text = "配置显示字段";
            this.Load += new System.EventHandler(this.CustomDisplayFieldConfigForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomDisplayFieldConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvCustomDisplayFieldConfig;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayFieldName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsBindData;
        private System.Windows.Forms.DataGridViewTextBoxColumn BindDataTableOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn BindDataTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BindDataFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BindDataRelativeFieldName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsTreeStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TreeParentNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TreeParentNodeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataBindCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataBindConditionValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRestrictedViewCondition;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRestrictedViewSubItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestrictedViewCondition;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAdvanceSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRangeSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsMoreItemSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSubItemSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsStatisticalData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRelatedUpdate;
        private System.Windows.Forms.DataGridViewComboBoxColumn RelatedUpdateType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedUpdateField;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedUpdateValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleRowSpan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleColumnSpan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentRowSpan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentColumnSpan;
        private System.Windows.Forms.DataGridViewComboBoxColumn TextAlign;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedInfoName;
        private System.Windows.Forms.DataGridViewComboBoxColumn RelatedTableType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedTableOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedTableName;
        private System.Windows.Forms.DataGridViewComboBoxColumn TableWithField;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedTableWithField;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsComboTree;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComboTreeLevel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsComboTreeLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComboTreeParent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsComboTreeRelatedParent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsComboTreeRelatedParentIndependent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComboTreeRelatedParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComboTreeRelatedParentTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComboTreeRelatedParentDisplayField;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComboTreeRelatedParentValueField;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComboTreeRelatedParentWithField;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsComboTreeRelatedParentLink;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCustomAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomAddWithField;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDispose;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDisposeOtherTable;
        private System.Windows.Forms.DataGridViewComboBoxColumn DisposeMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisposeSetValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDisposeReverse;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAddBatchField;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAddBatchOnlyDisplay;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAddBatchVisible;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAddBatchModify;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddBatchDisplaySort;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsFromMainTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsFromTemplateTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromTableField;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSortClassify;

    }
}