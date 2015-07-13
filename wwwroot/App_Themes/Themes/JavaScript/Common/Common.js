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
    var strMessage = '�˲��������ɻָ�����ȷ������ѡ���¼����ָ��������';
    if (!confirm(strMessage)) {
        return false;
    }
}

function AddConfirmDialog()
{
    var strMessage = '��ȷ��Ҫ������Ӳ�����';
    return confirm(strMessage);
}

function ModifyConfirmDialog()
{
    var strMessage = '��ȷ��Ҫ�����޸Ĳ�����';
    return confirm(strMessage);
}

function DeleteConfirmDialog()
{
    var strMessage = '�˲��������ɻָ�����ȷ������ѡ���¼����ɾ��������';
    if (!confirm(strMessage)) {
        return false;
    }
}

function PrintAllConfirmDialog()
{
    var strMessage = '��ȷ��Ҫ���д�ӡ�������ݲ�����';
    return confirm(strMessage);
}

function PrintConfirmDialog()
{
    var strMessage = '��ȷ��Ҫ���д�ӡ��ǰҳ���ݲ�����';
    return confirm(strMessage);
}

function ExportAllToFileConfirmDialog()
{
    var strMessage = '����������Ҫʱ��Ƚϳ�����ȷ��Ҫ��ȫ�����ݵ������ļ�������';
    return confirm(strMessage);
}

function ExportToFileConfirmDialog()
{
    var strMessage = '��ȷ��Ҫ����ǰҳ���ݵ������ļ�������';
    return confirm(strMessage);
}

function AddAlertDialog()
{
    var strMessage = '�����ٴ�ȷ�����������ݵ���ȷ�ԣ������Ϻ�����ȷ����ӡ���';
    alert(strMessage);
}

function ModifyAlertDialog()
{
    var strMessage = '�����ٴ�ȷ�����������ݵ���ȷ�ԣ������Ϻ�����ȷ���޸ġ���';
    alert(strMessage);
}

function ReturnListConfirmDialog()
{
    var strMessage = '�˲������ɻָ�����ȷ��Ҫ���������޸����ݷ�����Ϣ�б���';
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