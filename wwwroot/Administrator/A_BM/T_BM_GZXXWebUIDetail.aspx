<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_BM_GZXXWebUIDetail.aspx.cs" Inherits="T_BM_GZXXWebUIDetail" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">工资信息详情</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    .print .detailtitle {font-size:26px; padding-top:10px; padding-bottom:15px;}
    .print .detailtable{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:14px;}
    .print .detailtable_10{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:10px;}
    .print .detailtable_12{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:12px;}
    .print .detailtable_14{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:14px;}
    .print .detailtable_16{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:16px;}
    .print .detailtable_18{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:18px;}
    .print .fieldname{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white; font-weight:bold; height:25px; line-height:18px;text-align:center;}
    .print .fieldinput{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white;text-align:center; height:25px; line-height:18px;}
    .prln { page-break-before: always; page-break-after: always;}
    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <center>
                <div id="detailpage" runat="server" class="detailpage">
                    <div id="nonprintarea">
                        <div class="title">
                            <div class="bar">
                                <div class="lefttitle">
                                    工资信息
                                </div>
                            </div>
                        </div>
                        <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
                        <div class="operation">
                        <div style="display:none;">
                    导出PDF页面设置：大小<asp:DropDownList ID="ddlPrintPageSize" runat="server" Visible = "false"></asp:DropDownList>
                    版面<asp:DropDownList ID="ddlPrintPageOrientation" runat="server" Visible = "false"></asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlExportFileFormat" Visible="false"><asp:ListItem Text="PDF文件(.PDF)" Value="pdf"></asp:ListItem></asp:DropDownList>
                    上边距<asp:TextBox ID="txtMarginTop" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>
                    右边距<asp:TextBox ID="txtMarginRight" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>
                    下边距<asp:TextBox ID="txtMarginBottom" runat="server" Width="20" Text="50" ></asp:TextBox>
                    左边距<asp:TextBox ID="txtMarginLeft" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>
                    <br />
                        </div>
                    <input type="button" id ="btnEditItem" runat ="server" value="修改" class="button" />

                    <input id="btnPrintPage" runat="server" type="button" value="打印本页" onclick="nonprintarea.style.display = 'none'; window.print();nonprintarea.style.display = 'block';" class="button" />
                    <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />
                        </div>
                    </div>
                    <div ID="ControlContainer" runat="server" class="print">
                        <asp:GridView ID="gvPrint" runat="server" AutoGenerateColumns="False" CellSpacing="0" CellPadding="0" HorizontalAlign="Center" BorderWidth="0" onrowdatabound="gvPrint_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="detailtitle" HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        工资信息
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <!-- 主表信息 -->
                                        <div id="divmain" runat="server"></div>
                                        <div id="divvaluearea" runat="server" style = "display:none;">
                                    
                                            <div id = "XM" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XM"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "XB" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XB"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "SFZH" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SFZH"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "FFGZNY" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FFGZNY"), "{0}{1}{2}{3}-{4}{5}") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "JCGZ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JCGZ"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "JSDJGZ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JSDJGZ"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "ZWGZ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZWGZ"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "JBGZ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JBGZ"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "JKDQJT" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JKDQJT"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "JKTSGWJT" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JKTSGWJT"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "GLGZ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "GLGZ"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "XJGZ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XJGZ"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "TGBF" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "TGBF"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "DHF" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DHF"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "DSZNF" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DSZNF"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "FNWSHLF" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FNWSHLF"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "HLF" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HLF"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "JJ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JJ"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "JTF" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JTF"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "JHLGZ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JHLGZ"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "JT" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JT"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "BF" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BF"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "QTBT" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "QTBT"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "DFXJT" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DFXJT"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "YFX" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YFX"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "QTKK" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "QTKK"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "SYBX" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SYBX"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "SDNQF" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SDNQF"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "SDS" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SDS"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "YLBX" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YLBX"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "YLIBX" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YLIBX"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "YSSHF" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YSSHF"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "ZFGJJ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZFGJJ"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "KFX" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KFX"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "SFGZ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SFGZ"), "0.00") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "GZKKSM" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "GZKKSM"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                        </div>
                                        <!-- 一对多相关表信息 -->
                                                
                                        <div id = "relatedtable_1" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>
                                                
                                        <div id = "relatedtable_2" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_3" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>
                                                
                                        <div id = "relatedtable_4" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_5" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_6" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_7" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_8" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_9" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_10" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
        </center>
</asp:Content>

