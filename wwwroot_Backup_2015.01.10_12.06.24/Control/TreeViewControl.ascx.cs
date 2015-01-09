using System;
using System.Drawing;
using RICH.Common;
using Telerik.Web.UI;

public partial class TreeViewControl : System.Web.UI.UserControl
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
            return TreeView.Enabled;
        }
        set
        {
            TreeView.Enabled = value;
        }
    }

    public bool ReadOnly
    {
        get
        {
            return !TreeView.Enabled;
        }
        set
        {
            TreeView.Enabled = !value;
        }
    }

    public Color BackColor
    {
        get
        {
            return TreeView.BackColor;
        }
        set
        {
            TreeView.BackColor = value;
        }
    }

    public string CssClass
    {
        get
        {
            return TreeView.CssClass;
        }
        set
        {
            TreeView.CssClass = value;
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
                selectedValues = value;
                string[] strTemp = selectedValues.Split(Delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in strTemp)
                {
                    var node = TreeView.FindNodeByValue(s);
                    if (node != null)
                    {
                        node.Checked = true;
                    }
                }
            }
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        TreeView.OnClientNodeChecked = "SetComboTreeViewText_{0}".FormatInvariantCulture(TreeView.ClientID);
    }

    public void ClearCheckedNodes()
    {
        TreeView.ClearCheckedNodes();
    }

    public void ExpandAllNodes()
    {
        TreeView.ExpandAllNodes();
    }

    public void DataBind()
    {
        TreeView.ClearCheckedNodes();
        TreeView.DataBind();
        AutoExpandLevel = 1;
        ExpandNodes();
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
