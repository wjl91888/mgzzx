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
    var allCheckBox = document.getElementsByTagName("input");
    object.checked = true;    
    for (var i=0; i<allCheckBox.length; i++)
    {
        if (allCheckBox[i].type == "checkbox" && allCheckBox[i].checked == false)
        {
            object.checked = false;
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

function OpenModalWindow(Url,Width,Height,WindowObj)
{
    var ReturnStr=showModalDialog(Url,WindowObj,'dialogWidth:'+Width+'pt;dialogHeight:'+Height+'pt;status:no;help:no;scroll:yes;');
    return ReturnStr;
}
//Open Modal Window
function OpenWindowAndSetValue(Url,Width,Height,WindowObj,SetObj)
{
    var ReturnStr=showModalDialog(Url,WindowObj,'dialogWidth:'+Width+'pt;dialogHeight:'+Height+'pt;status:no;help:no;scroll:yes;');
    //	var ReturnStr=OpenEditerWindow(Url,WindowObj,'scrollbars=0,resizable=1,top=50,left=50,width='+Width+',height='+Height);
    if (ReturnStr!='007007007007') SetObj.value=ReturnStr;
    return ReturnStr;
}
//Open Editer Window
function OpenEditerWindow(Url,WindowName,Width,Height)
{
    window.open(Url,WindowName,'toolbar=0,location=0,maximize=1,directories=0,status=1,menubar=0,scrollbars=1,resizable=1,top=50,left=50,width='+Width+',height='+Height);
}

function BtnMouseOver(Obj)
{
    if (event.type!='mouseout')
    {
        Obj.className='BtnMouseOver';
        if (Obj.tagName.toLowerCase()=='td' || Obj.tagName.toLowerCase()=='img')
            window.status=Obj.alt;
        else
            window.status=Obj.title;
    }
    else
    {
        window.status=top.Str_Status;
        Obj.className='BtnMouseOut';
    }
}

function SelectOperationType(obj)
{
    if (obj.options[obj.selectedIndex].value != '')
    {
        OpenWindow(obj.options[obj.selectedIndex].value,770,600,window);
    }
}


function PreviewImg(imgFile, strPreview)
{
    var newPreview = document.getElementById(strPreview);
    newPreview.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgFile.value;
    newPreview.style.width = "130px";
    newPreview.style.height = "160px";
}


/**
*���ݴ����id��ʾ�Ҽ��˵�
*/
function showMenu(id)
{
    popMenu(document.getElementById(id) ,130);
    event.returnValue=false;
    event.cancelBubble=true;
    return false;
}

/**
*��ʾ�����˵�
*menuDiv:�Ҽ��˵�������
*width:����ʾ�Ŀ��
*/

function popMenu(menuDiv, width)
{
    //���������˵�
    var pop=window.createPopup();
    //���õ����˵�������
    pop.document.body.innerHTML=menuDiv.innerHTML;
    var rowObjs=pop.document.body.all[0].rows;
    //��õ����˵�������
    var rowCount=rowObjs.length;
    //ѭ������ÿ�е�����
    for(var i=0;i<rowObjs.length;i++)
    {
        //������껬�����ʱ��Ч��
        rowObjs[i].cells[0].onmouseover=function()
        {
            this.style.background="#818181";
            this.style.color="white";
        }
        //������껬������ʱ��Ч��
        rowObjs[i].cells[0].onmouseout=function(){
            this.style.background="#cccccc";
            this.style.color="black";
        }
    }
    //���β˵��Ĳ˵�
    pop.document.oncontextmenu=function()
    {
            return false;
    }
    //ѡ���Ҽ��˵���һ��󣬲˵�����
    pop.document.onclick=function()
    {
            pop.hide();
    }
    //��ʾ�˵�
    pop.show(event.clientX-1,event.clientY,width,rowCount*25,document.body);
    return true;
}

function setheight() {
    if (document.getElementById("tddivtree")) {
        document.getElementById("tddivtree").height = document.documentElement.clientHeight;
    }
    if (document.getElementById("tdmiddleblock")) {
        document.getElementById("tdmiddleblock").height = document.documentElement.clientHeight;
    }
}