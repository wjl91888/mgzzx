<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_Main.aspx.cs" Inherits="Administrator_Default_Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><meta content="IE=7" http-equiv="X-UA-Compatible" />
    <title><%=RICH.Common.ConstantsManager.WEBSITE_NAME%></title>
    <meta http-equiv="Refresh" content="300" />
    <link href="../App_Themes/Themes/Css/mainstyle.css" rev="stylesheet" rel="stylesheet"
        type="text/css" media="screen" charset="gb2312" />

    <script type="text/javascript" src="../App_Themes/Themes/JavaScript/Common/Common.js"
        language="javascript" charset="gb2312"></script>

     <style type="text/css">
    li {
    overflow:hidden;
    white-space : nowrap;
    
    }
    #main_area{width:800px;}
    #left_area{width:595px;float:left;}
    #right_area{width:200px;float:left;}
    /* 左边样式 */
    #left_area .layout
    {
        /*border-right: #6CAAD9 1px solid;
        border-top: #6CAAD9 1px solid;
        border-left: #6CAAD9 1px solid;
        border-bottom: #6CAAD9 1px solid;*/
        color:#000000;
        vertical-align: top;
        width: 595px;
        text-align: center;
        float:left;
        margin:2px 0px 0px 2px;
    }
    #left_area .layouttop{
    }
    #left_area .layoutbottom{

    }
    #left_area .layouttitle{
        width: 580px;
        height:13px;
        padding:5px;
        border:solid 1px #3681C2;
        text-align: left;       
        background-color:#60A2DC;
        color: #ffffff;
        font-weight:bold;
        }
    #left_area .layoutcontent{
        width: 580px;
        margin-top: 3px;
        padding:5px;
        background-color:#ffffff;
        border-top:solid 1px #3681C2;
        border-left:solid 1px #3681C2;
        border-right:solid 1px #3681C2;
    }
    #left_area .layoutcontent ul{
        list-style-type:none;
        list-style-position:outside;
        margin: 0px;
        padding: 0px;
    }
    #left_area .layoutcontent ul li{
        width: 580px;
        height:19px;
        border-bottom:1px #e5e5e5 dotted;
        text-align:left;
    }
    #left_area .layoutmore{
        margin-top:0px;
        text-align: right;
        width: 580px;
        padding:5px;
        background-color:#ffffff;
        border-top:solid 1px #000000;
        border-bottom:solid 1px #3681C2;
        border-left:solid 1px #3681C2;
        border-right:solid 1px #3681C2;
    }
    /* 右边样式 */
    #right_area .layout
    {
        /*border-right: #6CAAD9 1px solid;
        border-top: #6CAAD9 1px solid;
        border-left: #6CAAD9 1px solid;
        border-bottom: #6CAAD9 1px solid;*/
        color:#000000;
        vertical-align: top;
        width: 195px;
        text-align: center;
        float:left;
        margin:2px 0px 0px 2px;
    }
    #right_area .layouttop{
    }
    #right_area .layoutbottom{

    }
    #right_area .layouttitle{
        width: 185px;
        height:13px;
        padding:5px;
        border:solid 1px #3681C2;
        text-align: left;       
        background-color:#60A2DC;
        color: #ffffff;
        font-weight:bold;
        }
    #right_area .layoutcontent{
        width: 185px;
        margin-top: 3px;
        padding:5px;
        text-align: left;       
        background-color:#ffffff;
        border-top:solid 1px #3681C2;
        border-left:solid 1px #3681C2;
        border-right:solid 1px #3681C2;
        line-height:18px;
    }
    #right_area .layoutcontent ul{
        list-style-type:none;
        list-style-position:outside;
        margin: 0px;
        padding: 0px;
    }
    #right_area .layoutcontent ul li{
        width: 185px;
        height:20px;
        border-bottom:1px #e5e5e5 dotted;
        text-align:left;
    }
    #right_area .layoutmore{
        margin-top:0px;
        text-align: right;
        width: 185px;
        padding:5px;
        background-color:#ffffff;
        border-top:solid 1px #000000;
        border-bottom:solid 1px #3681C2;
        border-left:solid 1px #3681C2;
        border-right:solid 1px #3681C2;
    }
    </style>

    <script language="javascript" type="text/javascript">
    function switchcolumn(menuid, tagname, submenuid)
    {
            
          for(i=0;i<document.getElementById(menuid).getElementsByTagName(tagname).length;i++)
          {
            if(document.getElementById(menuid).getElementsByTagName(tagname).item(i).id != ''
                && document.getElementById(menuid).getElementsByTagName(tagname).item(i).id != submenuid)
            {
                document.getElementById(menuid).getElementsByTagName(tagname).item(i).style.display="none";
            }
          
          }
          if(document.getElementById(submenuid).style.display=="none")
          {
             document.getElementById(submenuid).style.display="";
          }
    }
    </script>

</head>
<body scroll="yes" style="padding-top: 5px; font-size: 14px; background-color: #94C2E8;">
    <form id="form1" runat="server">
        <div id="main_area">

        </div>
    </form>
</body>
</html>
