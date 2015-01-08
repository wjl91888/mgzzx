//==================================================== 参数设定部分 =======================================================
var bMoveable=false;		//设置日历是否可以拖动
var _VersionInfo="Version:2.0"	//版本信息

//==================================================== WEB 页面显示部分 =====================================================
var strFrame;		// HTML代码
document.writeln('<iframe bgcolor="#000000" id=suggestLayer frameborder=0 height=300 style="position: absolute;  z-index: 9998; display: none"></iframe>');
strFrame='信息读取中...';

window.frames.suggestLayer.document.writeln(strFrame);
window.frames.suggestLayer.document.close();		//解决ie进度条不结束的问题

//==================================================== WEB 页面显示部分 ======================================================
var outObject;
var outButton;		//点击的按钮

function openLayer(tt, filename) //主调函数
{
	var dads  = document.all.suggestLayer.style;
	var th = tt;
	var ttop  = tt.offsetTop;     //TT控件的定位点高
	var thei  = tt.clientHeight;  //TT控件本身的高
	var tleft = tt.offsetLeft;    //TT控件的定位点宽
	var ttyp  = tt.type;          //TT控件的类型
	while (tt = tt.offsetParent){ttop+=tt.offsetTop; tleft+=tt.offsetLeft;}
	dads.top  = (ttyp=="image")? ttop+thei : ttop+thei+6;
	dads.left = tleft;
	outObject =  th ;
	outButton = th;	//设定外部点击的按钮
	dads.display = '';
	
	document.all.suggestLayer.src = filename + '?KEYWORD=' + outObject.value + '&RETURNID=' +  outObject.id;
	event.returnValue=false;
}

document.onclick = function () //任意点击时关闭该控件	//ie6的情况可以由下面的切换焦点处理代替
{ 
with(window.event)
{ if (srcElement != outObject && srcElement != outButton)
	closeSuggestLayer();
}
}

document.onkeyup = function ()
{
    // 选中第一行数据
    // 按Esc键关闭，切换焦点关闭
	if (window.event.keyCode==27){
		if(outObject)outObject.blur();
		closeSuggestLayer();
	}
	else if(document.activeElement)
	{
		if(document.activeElement != outObject && document.activeElement != outButton)
		{
			closeSuggestLayer();
		}
    }
}


function selectItem(objSelectValue, returnID)  //点击显示框选取日期，主输入函数*************
{
    outObject = window.parent.document.getElementById(returnID);
    if (outObject)
    {
	    outObject.value=objSelectValue; //注：在这里你可以输出改成你想要的格式
	    window.parent.document.all.suggestLayer.style.display="none";
    }
    else 
    {
	    window.parent.document.all.suggestLayer.style.display="none";
        alert("您所要输出的控件对象并不存在！");
    }
}



function closeSuggestLayer()               //这个层的关闭
{
	document.all.suggestLayer.style.display="none";
	closeLayer(); 
}
