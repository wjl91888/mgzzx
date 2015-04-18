<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_BM_GZXXWebUIAdd.aspx.cs" Inherits="T_BM_GZXXWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">工资信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadScriptManager ID="rsmT_BM_GZXX" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_BM_GZXX" runat="server">
        <AjaxSettings>
  
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_GZXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <center>
            <div id="addpage" runat="server" class="addpage">
                <div class="toptoolsbar">
                <div class="title">
                    <div class="bar">
                        <div class="lefttitle">
                            工资信息 
                        </div>
                    </div>
                </div>
                <div class="operation">
                    <center>
                        <asp:Button Text="导入数据" ID="btnInfoFromDS" runat="server" CssClass="button" OnClick="btnInfoFromDS_Click" />
                        <asp:Button Text="Word导入" ID="btnInfoFromDoc" runat="server" CssClass="button" OnClick="btnInfoFromDoc_Click" />
                        <asp:Button Text="批量Word导入" ID="btnInfoFromDocBatch" runat="server" CssClass="button" OnClick="btnInfoFromDocBatch_Click" Visible="false" />
                        <asp:Button Text="取消" ID="btnInfoFromDocCancel" runat="server" CssClass="button" OnClick="btnInfoFromDocCancel_Click" />
                        <input type="button" id ="btnEditItem" runat ="server" value="修改" class="button" />

                        <asp:Button Text="保存" ID="btnAddConfirm" runat="server" CssClass="button" OnClientClick="return AddConfirmDialog();" OnClick="btnSave_Click" />

                        <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />
                    </center>
                </div>
                </div>
                <div class="main">
                     <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
                     <div  id= "ImportControlContainer" runat="server">
                     <div class="content clearboth" id="InfoFromDoc_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">导入文件</div><div class="redstar">*</div>
                         </div>
                         <div class="fieldinput">
                                 <asp:TextBox ID="InfoFromDoc" runat="server" CssClass="input widthfull"></asp:TextBox>
                         </div>
                         <div class="fieldnote" id="InfoFromDoc_Note" runat="server"></div>
                     </div>
                     </div>
                     <div  id= "ControlContainer" runat="server">

                     <div class="content" id="ObjectID_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="ObjectID_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="XM_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          姓名
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="XM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="XM_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="XB_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          性别
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="XB" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="XB_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="SFZH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          身份证号
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="SFZH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="SFZH_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="FFGZNY_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          日期
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="FFGZNY" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="FFGZNY_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JCGZ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          基础工资
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JCGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JCGZ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JSDJGZ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          技术等级工资
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JSDJGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JSDJGZ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="ZWGZ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          职务工资
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="ZWGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="ZWGZ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JBGZ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          级别工资
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JBGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JBGZ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JKDQJT_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          艰苦地区津贴
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JKDQJT" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JKDQJT_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JKTSGWJT_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          艰苦特岗津贴
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JKTSGWJT" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JKTSGWJT_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="GLGZ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          工龄工资
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="GLGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="GLGZ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="XJGZ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          薪级工资
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="XJGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="XJGZ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="TGBF_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          10%提高部分
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="TGBF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="TGBF_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="DHF_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          电话费
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="DHF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="DHF_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="DSZNF_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          独生子女费
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="DSZNF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="DSZNF_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="FNWSHLF_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          妇女卫生费
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="FNWSHLF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="FNWSHLF_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="HLF_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          护理费
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="HLF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="HLF_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JJ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          取暖补贴
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JJ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JTF_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          交通费
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JTF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JTF_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JHLGZ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          教护龄工资
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JHLGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JHLGZ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JT_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          津贴
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JT" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JT_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="BF_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          补发
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="BF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="BF_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="QTBT_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          其他补贴
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="QTBT" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="QTBT_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="DFXJT_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          地方性津贴
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="DFXJT" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="DFXJT_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="YFX_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          应发项
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="YFX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="YFX_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="QTKK_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          其他扣款
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="QTKK" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="QTKK_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="SYBX_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          失业保险
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="SYBX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="SYBX_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="SDNQF_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          水电暖气费
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="SDNQF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="SDNQF_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="SDS_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          所得税
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="SDS" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="SDS_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="YLBX_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          养老保险
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="YLBX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="YLBX_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="YLIBX_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          医疗保险
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="YLIBX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="YLIBX_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="YSSHF_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          遗属生活费
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="YSSHF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="YSSHF_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="ZFGJJ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          住房公积金
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="ZFGJJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="ZFGJJ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="KFX_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          扣发项
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="KFX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="KFX_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="SFGZ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          实发工资
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="SFGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="SFGZ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="GZKKSM_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          说明
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="GZKKSM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="GZKKSM_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="TJSJ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          添加时间
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="TJSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="TJSJ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                <div class="clearboth"></div>
                <telerik:RadTabStrip ID="T_BM_GZXXTabStrip" Visible="false" runat="server" ClickSelectedTab="true" SelectedIndex="0" MultiPageID="T_BM_GZXXMultiPage" >
                    <Tabs>
                        <telerik:RadTab Visible="false" runat = "server" Value="1" PageViewID="PageView1"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="2" PageViewID="PageView2"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="3" PageViewID="PageView3"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="4" PageViewID="PageView4"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="5" PageViewID="PageView5"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="6" PageViewID="PageView6"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="7" PageViewID="PageView7"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="8" PageViewID="PageView8"></telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage CssClass="tab_table" ID="T_BM_GZXXMultiPage" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="PageView1" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView2" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView3" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView4" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView5" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView6" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView7" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView8" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <!-- 相关表批量添加 -->

                </div>
                </div>
            </div>
        </center>
</asp:Content>

