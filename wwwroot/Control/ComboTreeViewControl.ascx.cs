using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.LM;
using Telerik.Web.UI;

public partial class ComboTreeViewControl : System.Web.UI.UserControl
{
    private string delimiter = ",";
    public string Delimiter
    {
        set
        {
            if (value != null)
            {
                if (value != "" && value != string.Empty)
                {
                    delimiter = value;
                }
                else
                {
                    delimiter = ",";
                }
            }
            else
            {
                delimiter = ",";
            }
        }
        get
        {
            return delimiter;
        }
    }

    private RadTreeView treeView = null;
    protected RadTreeView TreeView
    {
        get
        {
            return treeView ?? (treeView = this.ComboTreeView.Items[0].FindControl("ColumnTreeView") as RadTreeView);
        }
    }

    private int autoExpandLevel = 1;
    public int AutoExpandLevel
    {
        get
        {
            return autoExpandLevel;
        }
        set
        {
            autoExpandLevel = value;
        }
    }

    public string DataFieldID
    { 
        get
        {
            return TreeView.DataFieldID;
        }  
        set
        {
            TreeView.DataFieldID = value;
        } 
    }

    public string DataFieldParentID
    {
        get
        {
            return TreeView.DataFieldParentID;
        }
        set
        {
            TreeView.DataFieldParentID = value;
        }
    }

    public string DataValueField
    {
        get
        {
            return TreeView.DataValueField;
        }
        set
        {
            TreeView.DataValueField = value;
        }
    }

    public string DataTextField
    {
        get
        {
            return TreeView.DataTextField;
        }
        set
        {
            TreeView.DataTextField = value;
        }
    }

    public bool CheckBoxes
    {
        get
        {
            return TreeView.CheckBoxes;
        }
        set
        {
            TreeView.CheckBoxes = value;
        }
    }

    public bool CheckChildNodes
    {
        get
        {
            return TreeView.CheckChildNodes;
        }
        set
        {
            TreeView.CheckChildNodes = value;
        }
    }

    public object DataSource
    {
        get
        {
            return TreeView.DataSource;
        }
        set
        {
            TreeView.DataSource = value;
        }
    }

    public bool Enabled
    {
        get
        {
            return ComboTreeView.Enabled;
        }
        set
        {
            ComboTreeView.Enabled = value;
        }
    }

    public bool ReadOnly
    {
        get
        {
            return !ComboTreeView.Enabled;
        }
        set
        {
            ComboTreeView.Enabled = !value;
        }
    }

    public Color BackColor
    {
        get
        {
            return ComboTreeView.BackColor;
        }
        set
        {
            ComboTreeView.BackColor = value;
        }
    }

    public string CssClass
    {
        get
        {
            return ComboTreeView.CssClass;
        }
        set
        {
            ComboTreeView.CssClass = value;
        }
    }

    private string selectedValues = string.Empty;
    public string SelectedValues
    {
        get
        {
            bool boolFirstItem = true;
            foreach (var checkedNode in TreeView.CheckedNodes)
            {
                if (boolFirstItem == true)
                {
                    selectedValues = checkedNode.Value;
                    boolFirstItem = false;
                }
                else
                {
                    selectedValues = selectedValues + Delimiter + checkedNode.Value;
                }
            }
            return selectedValues;
        }
        set
        {
            if (!value.IsHtmlNullOrWiteSpace())
            {
                bool boolFirstItem = true;
                string selectedText = string.Empty;
                selectedValues = value;
                string[] strTemp = selectedValues.Split(Delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in strTemp)
                {
                    var node = TreeView.FindNodeByValue(s);
                    if (node != null)
                    {
                        node.Checked = true;
                        if (boolFirstItem == true)
                        {
                            selectedValues = node.Text;
                            boolFirstItem = false;
                        }
                        else
                        {
                            selectedValues = selectedValues + Delimiter + node.Text;
                        }
                    }
                }
                ComboTreeView.Text = selectedText;
            }
        }
    }

    public void ClearCheckedNodes()
    {
        TreeView.UncheckAllNodes();
    }

    public void ExpandAllNodes()
    {
        TreeView.ExpandAllNodes();
    }

    public override void DataBind()
    {
        TreeView.UncheckAllNodes();
        TreeView.DataBind();
        ExpandNodes();
        
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        ComboTreeView.OnClientDropDownClosing = "SetComboTreeViewText_{0}".FormatInvariantCulture(TreeView.ClientID);
        TreeView.OnClientNodeChecked = "SetComboTreeViewText_{0}".FormatInvariantCulture(TreeView.ClientID);
    }


    public void ExpandNodes(int? level = null)
    {
        AutoExpand(level ?? AutoExpandLevel, TreeView.Nodes);
    }

    private void AutoExpand(int level, RadTreeNodeCollection nodes)
    {
        if (level-- <= 0 || nodes.Count == 0)
        {
            return;
        }
        foreach (RadTreeNode node in nodes)
        {
            node.Expanded = true;
            AutoExpand(level, node.Nodes);
        }
    }

}
