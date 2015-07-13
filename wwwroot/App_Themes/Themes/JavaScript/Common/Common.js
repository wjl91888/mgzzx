function DoCheckAll(strCheckAllID)
{
    var object = document.getElementById(strCheckAllID);
    var allCheckBox = document.getElementsByTagName("input");
    if(object.checked == false)
    {
        for (var i=0; i<allCheckBox.length; i++)
        {
            if (allCheckBox[i].type == "checkbox")
            {
                allCheckBox[i].checked = false;
            }
        }
        object.checked = false;
    }
    else
    {
        for (var i=0; i<allCheckBox.length; i++)
        {
            if (allCheckBox[i].type == "checkbox") 
            {
                allCheckBox[i].checked = true;
            }
            object.checked = true;
        }
    }
}

function DoCheckAllFlag(strCheckAllID)
{
    var object = document.getElementById(strCheckAllID);
    if (object) {
        var allCheckBox = document.getElementsByTagName("input");
        object.checked = true;
        for (var i = 0; i < allCheckBox.length; i++) {
            if (allCheckBox[i].type == "checkbox" && allCheckBox[i].checked == false) {
                object.checked = false;
            }
        }
    }
}

function OperateConfirmDialog()
{
    var strMessage = '此操作将不可恢复，您确定对所选择记录进行指定操作吗？';
    if (!confirm(strMessage)) {
        return false;
    }
}

function AddConfirmDialog()
{
    var strMessage = '您确定要进行添加操作吗？';
    return confirm(strMessage);
}

function ModifyConfirmDialog()
{
    var strMessage = '您确定要进行修改操作吗？';
    return confirm(strMessage);
}

function DeleteConfirmDialog()
{
    var strMessage = '此操作将不可恢复，您确定对所选择记录进行删除操作吗？';
    if (!confirm(strMessage)) {
        return false;
    }
}

function PrintAllConfirmDialog()
{
    var strMessage = '您确定要进行打印所有数据操作吗？';
    return confirm(strMessage);
}

function PrintConfirmDialog()
{
    var strMessage = '您确定要进行打印当前页数据操作吗？';
    return confirm(strMessage);
}

function ExportAllToFileConfirmDialog()
{
    var strMessage = '导出数据需要时间比较长，您确定要将全部数据导出到文件操作吗？';
    return confirm(strMessage);
}

function ExportToFileConfirmDialog()
{
    var strMessage = '您确定要将当前页数据导出到文件操作吗？';
    return confirm(strMessage);
}

function AddAlertDialog()
{
    var strMessage = '请您再次确认所输入数据的正确性，检查完毕后点击“确认添加”。';
    alert(strMessage);
}

function ModifyAlertDialog()
{
    var strMessage = '请您再次确认所输入数据的正确性，检查完毕后点击“确认修改”。';
    alert(strMessage);
}

function ReturnListConfirmDialog()
{
    var strMessage = '此操作不可恢复，您确定要放弃保存修改内容返回信息列表吗？';
    return confirm(strMessage);
}

function PreviewImg(imgFile, strPreview)
{
    var newPreview = document.getElementById(strPreview);
    newPreview.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgFile.value;
    newPreview.style.width = "130px";
    newPreview.style.height = "160px";
}

function setheight() {
    if (document.getElementById("tddivtree")) {
        document.getElementById("tddivtree").height = document.documentElement.clientHeight;
    }
    if (document.getElementById("tdmiddleblock")) {
        document.getElementById("tdmiddleblock").height = document.documentElement.clientHeight;
    }
}