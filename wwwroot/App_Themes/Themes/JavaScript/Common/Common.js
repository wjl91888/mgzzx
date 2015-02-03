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
*根据传入的id显示右键菜单
*/
function showMenu(id)
{
    popMenu(document.getElementById(id) ,130);
    event.returnValue=false;
    event.cancelBubble=true;
    return false;
}

/**
*显示弹出菜单
*menuDiv:右键菜单的内容
*width:行显示的宽度
*/

function popMenu(menuDiv, width)
{
    //创建弹出菜单
    var pop=window.createPopup();
    //设置弹出菜单的内容
    pop.document.body.innerHTML=menuDiv.innerHTML;
    var rowObjs=pop.document.body.all[0].rows;
    //获得弹出菜单的行数
    var rowCount=rowObjs.length;
    //循环设置每行的属性
    for(var i=0;i<rowObjs.length;i++)
    {
        //设置鼠标滑入该行时的效果
        rowObjs[i].cells[0].onmouseover=function()
        {
            this.style.background="#818181";
            this.style.color="white";
        }
        //设置鼠标滑出该行时的效果
        rowObjs[i].cells[0].onmouseout=function(){
            this.style.background="#cccccc";
            this.style.color="black";
        }
    }
    //屏蔽菜单的菜单
    pop.document.oncontextmenu=function()
    {
            return false;
    }
    //选择右键菜单的一项后，菜单隐藏
    pop.document.onclick=function()
    {
            pop.hide();
    }
    //显示菜单
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