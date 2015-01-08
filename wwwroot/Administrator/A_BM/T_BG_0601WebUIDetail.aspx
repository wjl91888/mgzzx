<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_BG_0601WebUIDetail.aspx.cs" Inherits="T_BG_0601WebUIDetail" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">公共信息详情</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    .print .detailtitle {font-size:26px; padding-top:10px; padding-bottom:15px;}
    .print .detailtable{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:12px;}
    .print .detailtable_10{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:10px;}
    .print .detailtable_12{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:12px;}
    .print .detailtable_14{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:14px;}
    .print .detailtable_16{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:16px;}
    .print .detailtable_18{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:18px;}
    .print .fieldname{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white; font-weight:bold; height:25px; line-height:18px;text-align:center;}
    .print .fieldinput{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white;text-align:center; height:25px; line-height:18px;}
    .prln { page-break-before: always; page-break-after: always;}
    </style>
    <script type="text/javascript">
        function OpenEditor() {
            window.location='T_BG_0601WebUIAdd.aspx?a=e<%=AndChar%>ObjectID=<%=base.ObjectID%>';
        }
        function OpenCopyEditor() {
            window.location = 'T_BG_0601WebUIAdd.aspx?a=c<%=AndChar%>ObjectID=<%=base.ObjectID%>';
        }
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <center>
                <div id="detailpage" runat="server" class="detailpage">
                    <div id="nonprintarea">
                        <div class="title">
                            <div class="bar">
                                <div class="lefttitle">
                                    公共信息
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
                    <input type="button" id ="btnEditItem" runat ="server" value="修改" onclick="OpenEditor();" class="button" />

                    <input type="button" value="打印本页" onclick="nonprintarea.style.display = 'none'; window.print();nonprintarea.style.display = 'block';" class="button" />
                    <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />
                        </div>
                    </div>
                    <div class="print">
                        <asp:GridView ID="gvPrint" runat="server" AutoGenerateColumns="False" CellSpacing="0" CellPadding="0" HorizontalAlign="Center" BorderWidth="0" onrowdatabound="gvPrint_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="detailtitle" HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        公共信息
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <!-- 主表信息 -->
                                        <div id="divmain" runat="server"></div>
                                        <div id="divvaluearea" runat="server" style = "display:none;">
                                    
                                            <div id = "BT" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BT"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "FBLM" runat = "server" >
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "FBLM_T_BG_0602_LMM") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                           </div>
                                      
                                            <div id = "XXLX" runat = "server" >
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "XXLX_Dictionary_MC") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                           </div>
                                      
                                            <div id = "XXTPDZ" runat = "server" >
                                        
                               <%# DataBinder.Eval(Container.DataItem, "XXTPDZ") == DBNull.Value ? "" : "<a href='" + DataBinder.Eval(Container.DataItem, "XXTPDZ") + "' target='_blank'><img src='" + DataBinder.Eval(Container.DataItem, "XXTPDZ") + "' width = '130' border=0 /></a>"%>
                                                
                                           </div>
                                      
                                            <div id = "XXNR" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XXNR"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "FJXZDZ" runat = "server" >
                                        
                               <%# DataBinder.Eval(Container.DataItem, "FJXZDZ") == DBNull.Value ? "" : "<a href='" + DataBinder.Eval(Container.DataItem, "FJXZDZ") + "' target='_blank'>下载</a>"%>
                               <%# DataBinder.Eval(Container.DataItem, "FJXZDZ") == DBNull.Value ? "" : "<a href='../../PreviewDocument/PreviewDocument.aspx?file=" + DataBinder.Eval(Container.DataItem, "FJXZDZ") + "' target='_blank'>预览</a>"%>
                                                
                                           </div>
                                      
                                            <div id = "FBRJGH" runat = "server" >
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "FBRJGH_T_PM_UserInfo_UserNickName") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                           </div>
                                      
                                            <div id = "FBSJRQ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FBSJRQ"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "FBIP" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FBIP"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
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

