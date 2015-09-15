<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administrator_Default" %>
<%@ Import Namespace="RICH.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=System.Configuration.ConfigurationManager.AppSettings["WEBSITE_NAME"]%></title>
    <meta content="IE=7" http-equiv="X-UA-Compatible" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta content="<%=System.Configuration.ConfigurationManager.AppSettings["WEBSITE_NAME"]%>" name="keywords" />
    <link href="../App_Themes/Themes/Css/mainstyle.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
	<!--
    var canResize = false;
    var allowChangeView = true ;
    function noChangeSize( )
    {
        if ( ! canResize )
        {
            right_area.rows = "*,0" ;
        }
    }
	//-->

    </script>

    <meta content="MSHTML 6.00.2900.3059" name="GENERATOR" />
</head>
<FRAME id="ContentFrame" name="ContentFrame" marginwidth="0" marginheight="0" src="<%="index.aspx?lcode={0}".FormatInvariantCulture(Request.QueryString["lcode"])%>" frameborder="0" scrolling="yes"></FRAME>
</html>
