<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WeiXinBasePage.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="Index.aspx.cs"
    Inherits="WeiXin.Index" %>

<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder"
    runat="server">
    首页测试</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="MainContainer" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <div class="row">
        <div class="col-sm-12 col-xs-12">
            <div class="carousel" id="carousel1">
                <div class="slide">
                    <img src="images/1.jpg" class="cover1" />
                </div>
                <div class="slide">
                    <img src="images/2.jpg" class="cover1" />
                </div>
                <div class="slide">
                    <img src="images/3.jpg" class="cover1" />
                </div>
                <a class="controls left"><i class="icon-arrow-left-3"></i></a><a class="controls right">
                    <i class="icon-arrow-right-3"></i></a>
                <div class="markers default">
                    <ul>
                        <li class="active"><a href="javascript:void(0)" data-num="0"></a></li>
                        <li class=""><a href="javascript:void(0)" data-num="1"></a></li>
                        <li class=""><a href="javascript:void(0)" data-num="2"></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4 col-xs-4">
            <div class="tile bg-darkPink">
                <div class="tile-content icon">
                    <i class="icon-cart-2"></i>
                </div>
                <div class="tile-status">
                    <span class="name">已购买宠物</span>
                </div>
            </div>
        </div>
        <div class="col-sm-4 col-xs-4">
            <div class="tile   bg-amber">
                <div class="tile-content image">
                    <img src="images/spface.jpg">
                </div>
                <div class="brand bg-black">
                    <span class="label fg-white">宠物视频</span>
                    <div class="badge bg-darkRed paused">
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-4 col-xs-4">
            <div class="tile   bg-amber">
                <div class="tile-content image">
                    <img src="images/1.jpg">
                </div>
                <div class="brand bg-black">
                    <span class="label fg-white">宠物监控</span>
                    <div class="badge bg-darkRed icon-eye">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4 col-xs-4">
            <div class="tile   bg-amber">
                <div class="tile-content icon">
                    <i class="icon-home"></i>
                </div>
                <div class="tile-status">
                    <span class="label fg-white">宠物领养</span>
                </div>
            </div>
        </div>
        <div class="col-sm-8 col-xs-8">
            <div class="tile double">
                <div class="tile-content image-set">
                    <img src="images/1.jpg">
                    <img src="images/2.jpg">
                    <img src="images/3.jpg">
                    <img src="images/4.jpg">
                    <img src="images/5.jpg">
                </div>
            </div>
        </div>
        <div class="col-sm-4 col-xs-4">
            <div class="tile bg-lightOlive">
                <div class="brand">
                    <div class="badge bg-red"><i class="icon-broadcast"></i></div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4 col-xs-4">
            <div class="tile   bg-cyan">
                <div class="tile-content icon">
                    <i class=" icon-feed"></i>
                </div>
                <div class="tile-status">
                    <span class="label fg-white">宠物百科</span>
                </div>
            </div>
        </div>
        <div class="col-sm-4 col-xs-4">
            <div class="tile   bg-red">
                <div class="tile-content icon">
                    <i class="icon-help"></i>
                </div>
                <div class="tile-status">
                    <span class="label fg-white">常见问题</span>
                </div>
            </div>
        </div>
        <div class="col-sm-4 col-xs-4">
            <div class="tile   bg-amber">
                <div class="tile-content icon">
                    <i class="icon-user"></i>
                </div>
                <div class="tile-status">
                    <span class="label fg-white">联系我们</span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="NavContainer" ContentPlaceHolderID="NavContainerPlaceHolder" runat="server">
    <nav class="navigation-bar-content">
            <item class="element col-sm-4 col-xs-4 text-center" >
                <a class="fg-white" href="tel:13840816169"><i class="icon-phone"> </i>     </a>
            </item>
            <item class="element  col-sm-4 col-xs-4  text-center">     <a class="fg-white" href="sms:13840816169"><i class="icon-mail"> </i></a></item>

            <item class="element  col-sm-4 col-xs-4 text-center"> <i class="icon-location"> </i></item>
        </nav>
</asp:Content>
