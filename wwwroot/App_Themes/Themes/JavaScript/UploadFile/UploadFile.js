document.writeln('<iframe bgcolor="#000000" id="uploadFileBackgroundLayer" frameborder="0"style="position: absolute; z-index: 9000; display: none"></iframe>');
document.writeln('<iframe bgcolor="#000000" id="uploadFileLayer" frameborder="0" width="350" height="135" style="border:1px black solid;position: absolute; z-index: 9997; display: none"></iframe>');
//==================================================== WEB 页面显示部分 ======================================================
var w3c=(document.getElementById)? true: false;
var agt=navigator.userAgent.toLowerCase();
var ie = ((agt.indexOf("msie") != -1) && (agt.indexOf("opera") == -1) && (agt.indexOf("omniweb") == -1));
function uploadfile(fileurlfield) //主调函数
{
    var uploadfileframeid = "uploadFileLayer";
    var uploadfilebackgroundframeid = "uploadFileBackgroundLayer";
    objUploadFile = document.getElementById(uploadfileframeid);
    objUploadFileBackground = document.getElementById(uploadfilebackgroundframeid);
    objUploadFile.src = "../../Page/UplaodFile.aspx?param=" + fileurlfield.name;
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
    objUploadFile.style.position = 'absolute';
    objUploadFile.style.top = windowHeight * 0.3 + "px";
    objUploadFile.style.left = windowWidth * 0.3 + "px";
    objUploadFile.style.display = 'Block';
    //alert(fileurlfield + ',' + fileurlfield.style.top + ',' + fileurlfield.style.left);

    objUploadFileBackground.style.position = 'absolute';
    objUploadFileBackground.style.top = 0 + "px";
    objUploadFileBackground.style.left = 0 + "px";
    objUploadFileBackground.style.height = document.body.offsetHeight + "px";
    objUploadFileBackground.style.width = document.body.offsetWidth + "px";
    objUploadFileBackground.style.filter = 'alpha(opacity=60)';
    objUploadFileBackground.style.opacity = '60';

    objUploadFileBackground.style.display = 'Block';
    
        objUploadFile.focus();
    event.returnValue=false;

}

function closeUploadFileLayer()               //这个层的关闭
{
    var uploadfileframeid = "uploadFileLayer";
    var uploadfilebackgroundframeid = "uploadFileBackgroundLayer";
    objUploadFile = document.getElementById(uploadfileframeid);
    objUploadFileBackground = document.getElementById(uploadfilebackgroundframeid);
    objUploadFile.style.display="none";
    objUploadFileBackground.style.display="none";
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
