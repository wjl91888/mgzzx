<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_GZXXWebUIAdd.aspx.cs" Inherits="App.T_BM_GZXXWebUIAdd" %>
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
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_BM_GZXX" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_BM_GZXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_GZXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="XMContainer" runat="server" class="row">
                <div id="XMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">姓名</div>
                <div id="XMContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="XM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="XBContainer" runat="server" class="row">
                <div id="XBCaption" runat="server" class="fontbold col-xs-3 paddingleft0">性别</div>
                <div id="XBContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="XB" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SFZHContainer" runat="server" class="row">
                <div id="SFZHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">身份证号</div>
                <div id="SFZHContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="SFZH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="FFGZNYContainer" runat="server" class="row">
                <div id="FFGZNYCaption" runat="server" class="fontbold col-xs-3 paddingleft0">日期</div>
                <div id="FFGZNYContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="FFGZNY" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JCGZContainer" runat="server" class="row">
                <div id="JCGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">基础工资</div>
                <div id="JCGZContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="JCGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JSDJGZContainer" runat="server" class="row">
                <div id="JSDJGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">技术等级工资</div>
                <div id="JSDJGZContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="JSDJGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="ZWGZContainer" runat="server" class="row">
                <div id="ZWGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">职务工资</div>
                <div id="ZWGZContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="ZWGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JBGZContainer" runat="server" class="row">
                <div id="JBGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">级别工资</div>
                <div id="JBGZContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="JBGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JKDQJTContainer" runat="server" class="row">
                <div id="JKDQJTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">艰苦地区津贴</div>
                <div id="JKDQJTContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="JKDQJT" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JKTSGWJTContainer" runat="server" class="row">
                <div id="JKTSGWJTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">艰苦特岗津贴</div>
                <div id="JKTSGWJTContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="JKTSGWJT" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="GLGZContainer" runat="server" class="row">
                <div id="GLGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">工龄工资</div>
                <div id="GLGZContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="GLGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="XJGZContainer" runat="server" class="row">
                <div id="XJGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">薪级工资</div>
                <div id="XJGZContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="XJGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="TGBFContainer" runat="server" class="row">
                <div id="TGBFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">10%提高部分</div>
                <div id="TGBFContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="TGBF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="DHFContainer" runat="server" class="row">
                <div id="DHFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">电话费</div>
                <div id="DHFContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="DHF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="DSZNFContainer" runat="server" class="row">
                <div id="DSZNFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">独生子女费</div>
                <div id="DSZNFContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="DSZNF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="FNWSHLFContainer" runat="server" class="row">
                <div id="FNWSHLFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">妇女卫生费</div>
                <div id="FNWSHLFContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="FNWSHLF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="HLFContainer" runat="server" class="row">
                <div id="HLFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">护理费</div>
                <div id="HLFContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="HLF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JJContainer" runat="server" class="row">
                <div id="JJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">取暖补贴</div>
                <div id="JJContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="JJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JTFContainer" runat="server" class="row">
                <div id="JTFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">交通费</div>
                <div id="JTFContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="JTF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JHLGZContainer" runat="server" class="row">
                <div id="JHLGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">教护龄工资</div>
                <div id="JHLGZContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="JHLGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JTContainer" runat="server" class="row">
                <div id="JTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">津贴</div>
                <div id="JTContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="JT" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="BFContainer" runat="server" class="row">
                <div id="BFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">补发</div>
                <div id="BFContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="BF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="QTBTContainer" runat="server" class="row">
                <div id="QTBTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">其他补贴</div>
                <div id="QTBTContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="QTBT" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="DFXJTContainer" runat="server" class="row">
                <div id="DFXJTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">地方性津贴</div>
                <div id="DFXJTContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="DFXJT" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="YFXContainer" runat="server" class="row">
                <div id="YFXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">应发项</div>
                <div id="YFXContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="YFX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="QTKKContainer" runat="server" class="row">
                <div id="QTKKCaption" runat="server" class="fontbold col-xs-3 paddingleft0">其他扣款</div>
                <div id="QTKKContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="QTKK" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SYBXContainer" runat="server" class="row">
                <div id="SYBXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">失业保险</div>
                <div id="SYBXContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="SYBX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SDNQFContainer" runat="server" class="row">
                <div id="SDNQFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">水电暖气费</div>
                <div id="SDNQFContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="SDNQF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SDSContainer" runat="server" class="row">
                <div id="SDSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">所得税</div>
                <div id="SDSContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="SDS" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="YLBXContainer" runat="server" class="row">
                <div id="YLBXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">养老保险</div>
                <div id="YLBXContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="YLBX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="YLIBXContainer" runat="server" class="row">
                <div id="YLIBXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">医疗保险</div>
                <div id="YLIBXContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="YLIBX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="YSSHFContainer" runat="server" class="row">
                <div id="YSSHFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">遗属生活费</div>
                <div id="YSSHFContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="YSSHF" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="ZFGJJContainer" runat="server" class="row">
                <div id="ZFGJJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">住房公积金</div>
                <div id="ZFGJJContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="ZFGJJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KFXContainer" runat="server" class="row">
                <div id="KFXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">扣发项</div>
                <div id="KFXContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="KFX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SFGZContainer" runat="server" class="row">
                <div id="SFGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">实发工资</div>
                <div id="SFGZContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="SFGZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="GZKKSMContainer" runat="server" class="row">
                <div id="GZKKSMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">说明</div>
                <div id="GZKKSMContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="GZKKSM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="TJSJContainer" runat="server" class="row">
                <div id="TJSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">添加时间</div>
                <div id="TJSJContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="TJSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
        </div>
    <script>
        Sys.Application.add_load(function () {
            $('body,html').animate({ scrollTop: 0 }, 10);
        });
    </script>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
  <ul id="PageInfo" runat="server" class="nav  navbar-default">
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
      <asp:Button Text="保存" ID="btnAddConfirm" runat="server" CssClass="btn btn-default navbar-btn" OnClick="btnSave_Click" />
    </li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
  </ul>
</asp:Content>

