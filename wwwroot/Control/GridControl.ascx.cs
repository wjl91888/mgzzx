using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.LM;
public partial class GridControl : System.Web.UI.UserControl
{
    private string[] gridColumnName;
    public bool EditMode { get; set; }
    public string GridColumnName
    {
        get
        {
            return string.Join( ConstantsManager.FieldSplitString, gridColumnName);
        }
        set
        {
            gridColumnName = value.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
        }
    }
    private string[] width;
    public string Width
    {
        get
        {
            return string.Join(ConstantsManager.FieldSplitString, gridHeadText);
        }
        set
        {
            width = value.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
        }
    }
    private string[] gridHeadText;
    public string GridHeadText
    {
        get
        {
            return string.Join(ConstantsManager.FieldSplitString, gridHeadText);
        }
        set
        {
            gridHeadText = value.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
        }
    }
    private string[] text;
    public string Text
    {
        get
        {
            text = GetText().Split(new string[] { ConstantsManager.ItemSplitString }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(ConstantsManager.ItemSplitString, text);
        }
        set
        {
            text = value.Split(new string[] { ConstantsManager.ItemSplitString }, StringSplitOptions.RemoveEmptyEntries);
            DataSource = new DataTable();
            for (int i = 0; i < gridColumnName.Length; i++)
            {
                DataColumn dc = new DataColumn(gridColumnName[i]);
                DataSource.Columns.Add(dc);
            }
            if (text != null)
            {
                foreach (string row in text)
                {
                    string[] content = row.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
                    DataRow dr = DataSource.NewRow();
                    for (int i = 0; i < gridColumnName.Length && i < content.Length; i++)
                    {
                        dr[i] = content[i];
                    }
                    DataSource.Rows.Add(dr);
                }
            }
            GridDataBind.DataSource = DataSource;
            GridDataBind.DataBind();
        }
    }

    public Color BackColor { get; set; }

    public DataTable DataSource { get; set; }

    public bool  Enabled
    {
        get
        {
            return GridDataBind.Enabled;
        }
        set
        {
            GridDataBind.Enabled = value;
        }
    }

    public bool ReadOnly
    {
        get
        {
            return !GridDataBind.Enabled;
        }
        set
        {
            GridDataBind.Enabled = !value;
        }
    }

    protected void Page_Init(object sender,EventArgs e)
    {
        for (int i = 0; i < gridColumnName.Length; i++)
        {
            TemplateField tfTemp = new TemplateField();
            tfTemp.HeaderTemplate = new CustomTemplateField(gridHeadText[i]);
            if (EditMode)
            {
                if (width.Length == gridColumnName.Length)
                {
                    tfTemp.ItemTemplate = new CustomTemplateField(gridColumnName[i], gridColumnName[i], CustomTemplateField.TemplateFieldControlType.TextBox, strWidth: width[i]);
                }
                else
                {
                    tfTemp.ItemTemplate = new CustomTemplateField(gridColumnName[i], gridColumnName[i], CustomTemplateField.TemplateFieldControlType.TextBox);
                }
            }
            else
            {
                tfTemp.ItemTemplate = new CustomTemplateField(gridColumnName[i], gridColumnName[i]);
            }
            tfTemp.HeaderStyle.CssClass = "grid_fieldname";
            tfTemp.ItemStyle.CssClass = "grid_fieldinput";
            GridDataBind.Columns.Add(tfTemp);
        }
        if (EditMode)
        {
            operation.Visible = true;
            TemplateField tfTemp = new TemplateField();
            tfTemp.HeaderTemplate = new CustomTemplateField("删除");
            tfTemp.ItemTemplate = new CustomTemplateField("REMOVE", CustomTemplateField.TemplateFieldControlType.LinkButton, null, "删除", strWidth:"50");
            tfTemp.HeaderStyle.CssClass = "grid_fieldname";
            tfTemp.ItemStyle.CssClass = "grid_fieldinput";
            GridDataBind.Columns.Add(tfTemp);
        }
        else
        {
            operation.Visible = false;
        }
        if (!IsPostBack)
        {
            btnAddOneRow_Click(sender, e);
        }
    }

    protected void btnAddOneRow_Click(object sender, EventArgs e)
    {
        DataSource = new DataTable();
        for (int i = 0; i < gridColumnName.Length; i++)
        {
            DataColumn dc = new DataColumn(gridColumnName[i]);
            DataSource.Columns.Add(dc);
        }
        string[] strText = GetText().Split(new string[] { ConstantsManager.ItemSplitString }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string row in strText)
        {
            string[] content = row.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
            DataRow dr = DataSource.NewRow();
            for (int i = 0; i < gridColumnName.Length; i++)
            {
                dr[i] = content[i];
            }
            DataSource.Rows.Add(dr);
        }

        DataSource.Rows.Add(DataSource.NewRow());
        GridDataBind.DataSource = DataSource;
        GridDataBind.DataBind();
    }

    private string GetText(int intRemoveRowIndex = -1)
    {
        string content = string.Empty;
        foreach (GridViewRow row in GridDataBind.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                if (row.RowIndex != intRemoveRowIndex)
                {
                    string strRow = string.Empty;
                    bool boolEmpty = true;
                    for (int i = 0; i < gridColumnName.Length; i++)
                    {
                        if (!DataValidateManager.ValidateIsNull(((TextBox)row.Cells[i].FindControl(gridColumnName[i])).Text))
                        {
                            boolEmpty = false;
                        }
                        if (i == 0)
                        {
                            strRow = ((TextBox)row.Cells[i].FindControl(gridColumnName[i])).Text;
                        }
                        else
                        {
                            strRow = strRow + ConstantsManager.FieldSplitString + ((TextBox)row.Cells[i].FindControl(gridColumnName[i])).Text;
                        }
                    }
                    if (!boolEmpty)
                    {
                        content = content + ConstantsManager.ItemSplitString + strRow;
                    }
                }
            }
        }
        return content;
    }

    protected void GridDataBind_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (EditMode)
        {
            int rowindex;
            if (e.CommandName.Equals("REMOVE") && int.TryParse(e.CommandArgument.ToString(), out rowindex))
            {
                DataSource = new DataTable();
                for(int i = 0; i < gridColumnName.Length; i++)
                {
                    DataColumn dc = new DataColumn(gridColumnName[i]);
                    DataSource.Columns.Add(dc);
                }
                string[] strText = GetText(rowindex).Split(new string[] { ConstantsManager.ItemSplitString }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string row in strText)
                {
                    string[] content = row.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
                    DataRow dr = DataSource.NewRow();
                    for (int i = 0; i < gridColumnName.Length; i++)
                    {
                        dr[i] = content[i];
                    }
                    DataSource.Rows.Add(dr);
                }
                GridDataBind.DataSource = DataSource;
                GridDataBind.DataBind();
            }
        }
    }

    protected void GridDataBind_DataBound(object sender, EventArgs eventArgs)
    {
        if (EditMode)
        {
            foreach (GridViewRow row in GridDataBind.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbDelete = (LinkButton)row.Cells[gridColumnName.Length].FindControl("REMOVE");
                    if (lbDelete != null)
                    {
                        lbDelete.CommandArgument = row.RowIndex.ToString();
                        lbDelete.OnClientClick = "return confirm('您确定要删除此条数据吗？');";
                    }
                }
            }
        }
    }
}
