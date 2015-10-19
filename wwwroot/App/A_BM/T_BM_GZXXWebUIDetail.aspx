<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_GZXXWebUIDetail.aspx.cs" Inherits="App.T_BM_GZXXWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    ������Ϣ
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XM"), null)%></h4>
            </div>
    
            <div id="XMContainer" runat="server" class="row">
                <div id="XMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����</div>
                <div id="XMContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XM"), null)%>
                
                </div>
            </div>
        
            <div id="XBContainer" runat="server" class="row">
                <div id="XBCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�Ա�</div>
                <div id="XBContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XB"), null)%>
                
                </div>
            </div>
        
            <div id="SFZHContainer" runat="server" class="row">
                <div id="SFZHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">���֤��</div>
                <div id="SFZHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SFZH"), null)%>
                
                </div>
            </div>
        
            <div id="FFGZNYContainer" runat="server" class="row">
                <div id="FFGZNYCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����</div>
                <div id="FFGZNYContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FFGZNY"), "{0}{1}{2}{3}-{4}{5}")%>
                
                </div>
            </div>
        
            <div id="JCGZContainer" runat="server" class="row">
                <div id="JCGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��������</div>
                <div id="JCGZContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JCGZ"), "0.00")%>
                
                </div>
            </div>
        
            <div id="JSDJGZContainer" runat="server" class="row">
                <div id="JSDJGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�����ȼ�����</div>
                <div id="JSDJGZContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JSDJGZ"), "0.00")%>
                
                </div>
            </div>
        
            <div id="ZWGZContainer" runat="server" class="row">
                <div id="ZWGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">ְ����</div>
                <div id="ZWGZContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZWGZ"), "0.00")%>
                
                </div>
            </div>
        
            <div id="JBGZContainer" runat="server" class="row">
                <div id="JBGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">������</div>
                <div id="JBGZContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JBGZ"), "0.00")%>
                
                </div>
            </div>
        
            <div id="JKDQJTContainer" runat="server" class="row">
                <div id="JKDQJTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����������</div>
                <div id="JKDQJTContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JKDQJT"), "0.00")%>
                
                </div>
            </div>
        
            <div id="JKTSGWJTContainer" runat="server" class="row">
                <div id="JKTSGWJTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����ظڽ���</div>
                <div id="JKTSGWJTContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JKTSGWJT"), "0.00")%>
                
                </div>
            </div>
        
            <div id="GLGZContainer" runat="server" class="row">
                <div id="GLGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">���乤��</div>
                <div id="GLGZContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "GLGZ"), "0.00")%>
                
                </div>
            </div>
        
            <div id="XJGZContainer" runat="server" class="row">
                <div id="XJGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">н������</div>
                <div id="XJGZContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XJGZ"), "0.00")%>
                
                </div>
            </div>
        
            <div id="TGBFContainer" runat="server" class="row">
                <div id="TGBFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">10%��߲���</div>
                <div id="TGBFContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "TGBF"), "0.00")%>
                
                </div>
            </div>
        
            <div id="DHFContainer" runat="server" class="row">
                <div id="DHFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�绰��</div>
                <div id="DHFContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DHF"), "0.00")%>
                
                </div>
            </div>
        
            <div id="DSZNFContainer" runat="server" class="row">
                <div id="DSZNFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">������Ů��</div>
                <div id="DSZNFContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DSZNF"), "0.00")%>
                
                </div>
            </div>
        
            <div id="FNWSHLFContainer" runat="server" class="row">
                <div id="FNWSHLFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��Ů������</div>
                <div id="FNWSHLFContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FNWSHLF"), "0.00")%>
                
                </div>
            </div>
        
            <div id="HLFContainer" runat="server" class="row">
                <div id="HLFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�����</div>
                <div id="HLFContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HLF"), "0.00")%>
                
                </div>
            </div>
        
            <div id="JJContainer" runat="server" class="row">
                <div id="JJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">ȡů����</div>
                <div id="JJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JJ"), "0.00")%>
                
                </div>
            </div>
        
            <div id="JTFContainer" runat="server" class="row">
                <div id="JTFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��ͨ��</div>
                <div id="JTFContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JTF"), "0.00")%>
                
                </div>
            </div>
        
            <div id="JHLGZContainer" runat="server" class="row">
                <div id="JHLGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�̻��乤��</div>
                <div id="JHLGZContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JHLGZ"), "0.00")%>
                
                </div>
            </div>
        
            <div id="JTContainer" runat="server" class="row">
                <div id="JTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����</div>
                <div id="JTContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JT"), "0.00")%>
                
                </div>
            </div>
        
            <div id="BFContainer" runat="server" class="row">
                <div id="BFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����</div>
                <div id="BFContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BF"), "0.00")%>
                
                </div>
            </div>
        
            <div id="QTBTContainer" runat="server" class="row">
                <div id="QTBTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��������</div>
                <div id="QTBTContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "QTBT"), "0.00")%>
                
                </div>
            </div>
        
            <div id="DFXJTContainer" runat="server" class="row">
                <div id="DFXJTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�ط��Խ���</div>
                <div id="DFXJTContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DFXJT"), "0.00")%>
                
                </div>
            </div>
        
            <div id="YFXContainer" runat="server" class="row">
                <div id="YFXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">Ӧ����</div>
                <div id="YFXContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YFX"), "0.00")%>
                
                </div>
            </div>
        
            <div id="QTKKContainer" runat="server" class="row">
                <div id="QTKKCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�����ۿ�</div>
                <div id="QTKKContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "QTKK"), "0.00")%>
                
                </div>
            </div>
        
            <div id="SYBXContainer" runat="server" class="row">
                <div id="SYBXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">ʧҵ����</div>
                <div id="SYBXContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SYBX"), "0.00")%>
                
                </div>
            </div>
        
            <div id="SDNQFContainer" runat="server" class="row">
                <div id="SDNQFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">ˮ��ů����</div>
                <div id="SDNQFContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SDNQF"), "0.00")%>
                
                </div>
            </div>
        
            <div id="SDSContainer" runat="server" class="row">
                <div id="SDSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����˰</div>
                <div id="SDSContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SDS"), "0.00")%>
                
                </div>
            </div>
        
            <div id="YLBXContainer" runat="server" class="row">
                <div id="YLBXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">���ϱ���</div>
                <div id="YLBXContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YLBX"), "0.00")%>
                
                </div>
            </div>
        
            <div id="YLIBXContainer" runat="server" class="row">
                <div id="YLIBXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">ҽ�Ʊ���</div>
                <div id="YLIBXContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YLIBX"), "0.00")%>
                
                </div>
            </div>
        
            <div id="YSSHFContainer" runat="server" class="row">
                <div id="YSSHFCaption" runat="server" class="fontbold col-xs-3 paddingleft0">���������</div>
                <div id="YSSHFContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YSSHF"), "0.00")%>
                
                </div>
            </div>
        
            <div id="ZFGJJContainer" runat="server" class="row">
                <div id="ZFGJJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">ס��������</div>
                <div id="ZFGJJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZFGJJ"), "0.00")%>
                
                </div>
            </div>
        
            <div id="KFXContainer" runat="server" class="row">
                <div id="KFXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�۷���</div>
                <div id="KFXContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KFX"), "0.00")%>
                
                </div>
            </div>
        
            <div id="SFGZContainer" runat="server" class="row">
                <div id="SFGZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">ʵ������</div>
                <div id="SFGZContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SFGZ"), "0.00")%>
                
                </div>
            </div>
        
            <div id="GZKKSMContainer" runat="server" class="row">
                <div id="GZKKSMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">˵��</div>
                <div id="GZKKSMContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "GZKKSM"), null)%>
                
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


