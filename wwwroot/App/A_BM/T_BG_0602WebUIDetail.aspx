<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BG_0602WebUIDetail.aspx.cs" Inherits="App.T_BG_0602WebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    ������Ϣ��Ŀ
</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>


<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
<div id="AppDetailPage">
    <asp:Repeater ID="rptDetail" runat="server">
        <ItemTemplate>
            <div class="page-header">
                <h4>
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LMM"), null)%></h4>
            </div>
    
            <div id="LMHContainer" runat="server" class="row">
                <div id="LMHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��Ŀ��</div>
                <div id="LMHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LMH"), null)%>
                
                </div>
            </div>
        
            <div id="LMMContainer" runat="server" class="row">
                <div id="LMMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��Ŀ��</div>
                <div id="LMMContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LMM"), null)%>
                
                </div>
            </div>
        
            <div id="SJLMHContainer" runat="server" class="row">
                <div id="SJLMHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�ϼ���Ŀ</div>
                <div id="SJLMHContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "SJLMH_T_BG_0602_LMM")%>
        
                </div>
            </div>
        
            <div id="LMTPContainer" runat="server" class="row">
                <div id="LMTPCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��ĿͼƬ</div>
                <div id="LMTPContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "LMTP") == DBNull.Value ? "" : "<img class='img-responsive' src='" + DataBinder.Eval(Container.DataItem, "LMTP") + "' />"%>
                
                </div>
            </div>
        
            <div id="LMNRContainer" runat="server" class="row">
                <div id="LMNRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��Ŀ��ʾ����</div>
                <div id="LMNRContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LMNR"), null)%>
                
                </div>
            </div>
        
            <div id="LMLBYSContainer" runat="server" class="row">
                <div id="LMLBYSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��Ŀ�б���ʽ</div>
                <div id="LMLBYSContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "LMLBYS_Dictionary_MC")%>
        
                </div>
            </div>
        
            <div id="SFLBLMContainer" runat="server" class="row">
                <div id="SFLBLMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�б�������Ŀ</div>
                <div id="SFLBLMContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "SFLBLM_Dictionary_MC")%>
        
                </div>
            </div>
        
            <div id="SFWBURLContainer" runat="server" class="row">
                <div id="SFWBURLCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�ⲿ��Ŀ</div>
                <div id="SFWBURLContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "SFWBURL_Dictionary_MC")%>
        
                </div>
            </div>
        
            <div id="WBURLContainer" runat="server" class="row">
                <div id="WBURLCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�ⲿ��Ŀ����</div>
                <div id="WBURLContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "WBURL"), null)%>
                
                </div>
            </div>
        

        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
    <ul id="PageInfo" runat="server" class="nav  navbar-default">
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <input type="button" id ="btnEditItem" runat ="server" value="�޸�" class="btn btn-default navbar-btn" />
        </li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    </ul>
</asp:Content>


