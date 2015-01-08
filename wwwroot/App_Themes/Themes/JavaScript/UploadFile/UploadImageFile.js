document.writeln('<iframe bgcolor="#000000" id="UplaodImageFileBackgroundLayer" frameborder="0"style="position: absolute; z-index: 9001; display: none"></iframe>');
document.writeln('<iframe bgcolor="#000000" id="UplaodImageFileLayer" frameborder="0" width="400" height="300" style="border:1px black solid;position: absolute; z-index: 9998; display: none"></iframe>');
//==================================================== WEB 页面显示部分 ======================================================
var w3c=(document.getElementById)? true: false;
var agt=navigator.userAgent.toLowerCase();
var ie = ((agt.indexOf("msie") != -1) && (agt.indexOf("opera") == -1) && (agt.indexOf("omniweb") == -1));
function UplaodImageFile(fileurlfield) //主调函数
{
    var UplaodImageFileframeid = "UplaodImageFileLayer";
    var UplaodImageFilebackgroundframeid = "UplaodImageFileBackgroundLayer";
    objUplaodImageFile = document.getElementById(UplaodImageFileframeid);
    objUplaodImageFileBackground = document.getElementById(UplaodImageFilebackgroundframeid);
    objUplaodImageFile.src = "../../Page/UplaodImageFile.aspx?param=" + fileurlfield.name;
    if (self.innerHeight) 
    { // all except Explorer
        windowWidth = self.innerWidth;
        windowHeight = self.innerHeight;
    } 
    else if (document.documentElement && document.documentElement.clientHeight) 
    { // Explorer 6 Strict Mode
        windowWidth = document.documentElement.clientWidth;
        windowHeight = document.documentElement.clientHeight;
    } 
    else if (document.body) 
    { // other Explorers
        windowWidth = document.body.clientWidth;
        windowHeight = document.body.clientHeight;
    }
    
    var yScrolltop;
    var xScrollleft;
    if (self.pageYOffset || self.pageXOffset) {
        yScrolltop = self.pageYOffset;
        xScrollleft = self.pageXOffset;
    } 
    else if (document.documentElement && document.documentElement.scrollTop || document.documentElement.scrollLeft )
    {     // Explorer 6 Strict
        yScrolltop = document.documentElement.scrollTop;
        xScrollleft = document.documentElement.scrollLeft;
    } 
    else if (document.body) 
    {// all other Explorers
        yScrolltop = document.body.scrollTop;
        xScrollleft = document.body.scrollLeft;
    }
    //alert(xScrollleft+','+yScrolltop+','+windowWidth+','+windowHeight+','+document.body.scrollHeight+','+document.documentElement.scrollTop);
    objUplaodImageFile.style.position = 'absolute';
    objUplaodImageFile.style.top = windowHeight * 0.3 + "px";
    objUplaodImageFile.style.left = windowWidth * 0.3 + "px";

    objUplaodImageFile.style.display = 'Block';

    objUplaodImageFileBackground.style.position = 'absolute';
    objUplaodImageFileBackground.style.top = 0 + "px";
    objUplaodImageFileBackground.style.left = 0 + "px";
    objUplaodImageFileBackground.style.height = document.body.offsetHeight + "px";
    objUplaodImageFileBackground.style.width = document.body.offsetWidth + "px";
    objUplaodImageFileBackground.style.filter = 'alpha(opacity=60)';

    objUplaodImageFileBackground.style.display = 'Block';
    objUplaodImageFile.focus();
    event.returnValue=false;
}

function closeUplaodImageFileLayer()               //这个层的关闭
{
    var UplaodImageFileframeid = "UplaodImageFileLayer";
    var UplaodImageFilebackgroundframeid = "UplaodImageFileBackgroundLayer";
    objUplaodImageFile = document.getElementById(UplaodImageFileframeid);
    objUplaodImageFileBackground = document.getElementById(UplaodImageFilebackgroundframeid);
    objUplaodImageFile.style.display="none";
    objUplaodImageFileBackground.style.display="none";
}


function IeTrueBody(){
return (document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body;
}

function GetScrollTop(){
 return ie ? IeTrueBody().scrollTop : window.pageYOffset;
}

function GetScrollLeft(){
 return ie ? IeTrueBody().scrollLeft : window.pageXOffset;
}
