<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilmList.aspx.cs" Inherits="SDWxPro.Web.FilmList" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>影视资源</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0,maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <!--<!-- 微软的老式浏览器 -->
    <meta name="MobileOptimized" content="320">
    <meta name="applicable-device" content="mobile">
    <!--禁用电话自动识别-->
    <meta name="format-detection" content="telephone=no">
    <!--删除默认的苹果工具栏和菜单栏-->
    <meta name="apple-touch-fullscreen" content="yes" />
    <%--<link rel="stylesheet" href="/statics/release/ql2.0/css/style.css">--%>
    <link href="css/style.css" rel="stylesheet" />

    <script>
        //声明_czc对象:
        var _czc = _czc || [];
        //绑定siteid，请用您的siteid替换下方"XXXXXXXX"部分
        _czc.push(["_setAccount", "1260839900"]);
    </script>
</head>

<body>
    <div class="zykZhong warp indexSlide">


        <input type="hidden" value="<%=flag %>" id="type" />
        <%--<input type="hidden" value="1" id="page" />--%>
        <div class="tab2">
            <ul class="clearfix indexSlideTab">
                <li class="mtab1 <%=flag=="1"?"active":"" %>">
                    <a href="http://wx.sudiny.ltd/FilmList.aspx?m=wap&c=index&a=wx_movie&flag=1">
                        <p class="title">电影</p>
                        <p class="h2">MOVIE</p>
                        <span class="line"></span>
                    </a>
                </li>
                <li class="mtab2 <%=flag=="2"?"active":"" %>">
                    <a href="http://wx.sudiny.ltd/FilmList.aspx?m=wap&c=index&a=wx_movie&flag=2">
                        <p class="title">电视剧</p>
                        <p class="h2">SERIES</p>
                        <span class="line"></span>
                    </a>
                </li>
                <li class="mtab3 <%=flag=="3"?"active":"" %>">
                    <a href="http://wx.sudiny.ltd/FilmList.aspx?m=wap&c=index&a=wx_movie&flag=3">
                        <p class="title">综艺</p>
                        <p class="h2">SHOW</p>
                        <span class="line"></span>
                    </a>
                </li>
                <li class="mtab4 <%=flag=="4"?"active":"" %>">
                    <a href="http://wx.sudiny.ltd/FilmList.aspx?m=wap&c=index&a=wx_movie&flag=4">
                        <p class="title">动漫</p>
                        <p class="h2">ANIME</p>
                        <span class="line"></span>
                    </a>
                </li>
            </ul>
        </div>
        <div class="zykCont">

            <div class="Cont recommend paddB changeCont">
                <ul class="ulCont clearfix active mtab1" id="content">
                    <%-- <li class="item" mytitle="全职高手" copyword="全职高手" mytype='动漫' onclick="_czc.push(['_trackEvent', '全职高手', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0407/20170407014018757.jpg" />
                        <p class="l-ell">全职高手</p>
                    </li>
                    <li class="item" mytitle="纯情罗曼史" copyword="纯情罗曼史" mytype='动漫' onclick="_czc.push(['_trackEvent', '纯情罗曼史', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0809/20170809051827658.png" />
                        <p class="l-ell">纯情罗曼史</p>
                    </li>
                    <li class="item" mytitle="岁月的童话" copyword="岁月的童话" mytype='动漫' onclick="_czc.push(['_trackEvent', '岁月的童话', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0803/20170803035748442.jpg" />
                        <p class="l-ell">岁月的童话</p>
                    </li>
                    <li class="item" mytitle="出包王女" copyword="出包王女" mytype='动漫' onclick="_czc.push(['_trackEvent', '出包王女', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0802/20170802052443833.jpg" />
                        <p class="l-ell">出包王女</p>
                    </li>
                    <li class="item" mytitle="约会大作战" copyword="约会大作战" mytype='动漫' onclick="_czc.push(['_trackEvent', '约会大作战', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0726/20170726054514587.jpg" />
                        <p class="l-ell">约会大作战</p>
                    </li>
                    <li class="item" mytitle="捏造陷阱 -NTR- " copyword="捏造陷阱 -NTR- " mytype='动漫' onclick="_czc.push(['_trackEvent', '捏造陷阱 -NTR- ', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0725/20170725015936773.png" />
                        <p class="l-ell">捏造陷阱 -NTR- </p>
                    </li>
                    <li class="item" mytitle="心灵想要大声呼喊" copyword="心灵想要大声呼喊" mytype='动漫' onclick="_czc.push(['_trackEvent', '心灵想要大声呼喊', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0725/20170725110400750.png" />
                        <p class="l-ell">心灵想要大声呼喊</p>
                    </li>
                    <li class="item" mytitle="命运/外典Fate Apocrypha" copyword="命运/外典Fate Apocrypha" mytype='动漫' onclick="_czc.push(['_trackEvent', '命运/外典Fate Apocrypha', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0724/20170724024730877.png" />
                        <p class="l-ell">命运/外典Fate Apocrypha</p>
                    </li>
                    <li class="item" mytitle="全职法师" copyword="全职法师" mytype='动漫' onclick="_czc.push(['_trackEvent', '全职法师', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0724/20170724114601850.jpg" />
                        <p class="l-ell">全职法师</p>
                    </li>
                    <li class="item" mytitle="怪诞小镇" copyword="怪诞小镇" mytype='动漫' onclick="_czc.push(['_trackEvent', '怪诞小镇', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0721/20170721032225424.png" />
                        <p class="l-ell">怪诞小镇</p>
                    </li>
                    <li class="item" mytitle="灵域" copyword="灵域" mytype='动漫' onclick="_czc.push(['_trackEvent', '灵域', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0721/20170721092331445.png" />
                        <p class="l-ell">灵域</p>
                    </li>
                    <li class="item" mytitle="虞美人盛开的山坡" copyword="虞美人盛开的山坡" mytype='动漫' onclick="_czc.push(['_trackEvent', '虞美人盛开的山坡', '影视大全', '访问','1','visit']);">
                        <img src="http://www.vrqile.com/uploadfile/2017/0720/20170720022630276.png" />
                        <p class="l-ell">虞美人盛开的山坡</p>
                    </li>--%>


                    <asp:Repeater runat="server" ID="rpFilm">
                        <ItemTemplate>

                            <li class="item" mytitle="<%#Eval("Name") %>" copyword="<%#Eval("Name") %>" mytype='<%#GetType(SDWxPro.Tool.Security.ToNum(Eval("Type"))) %>' onclick="_czc.push(['_trackEvent', '<%#Eval("Name") %>', '影视大全', '访问','1','visit']);">
                                <%--<a href="<%#Eval("LinkUrl") %>">--%>
                                <img src="<%#GetMainImage(SDWxPro.Tool.Security.ToNum(Eval("Id"))) %>" />
                                <p class="l-ell"><%#Eval("Name") %></p>
                                <%--</a>--%>

                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>

            </div>

        </div>

        <!--底部tab-->
        <div class="tabBot">
            <div class="tab">
                <a href="http://m.vrqile.com/kanju/zt/1.html" onclick="_czc.push(['_trackEvent', '专题', '事件', '点击数','1','visit']);">
                    <span>
                        <div class="zt">
                        </div>
                        <div class="p">专题</div>
                    </span>
                </a>
            </div>
            <div class="tab active">
                <a href="http://wx.sudiny.ltd/FileList.aspx?m=wap&c=index&a=wx_movie" onclick="_czc.push(['_trackEvent', '专题', '资源库', '点击数','1','visit']);">
                    <span>
                        <div class="zy">
                        </div>
                        <div class="p">资源库</div>
                    </span>
                </a>
            </div>
            <div class="tab ">
                <a href="http://m.vrqile.com/index.php?m=wap&c=index&a=search_ziyuan" onclick="_czc.push(['_trackEvent', '搜索', '事件', '点击数','1','visit']);">
                    <span>
                        <div class="ss">
                        </div>
                        <div class="p">搜索</div>
                    </span>
                </a>
            </div>
        </div>
        <!--弹出框-->
        <!--遮罩-->
        <div class="js-tc">

            <!--框体-->
            <div class="js-tc-div">
                <div class="alert-header">
                    <h2 class="">生化危机生化危机</h2>
                </div>
                <div class="alert-body animated fadeIn">
                    <p>回复：<span id="copy_key_ios_nb" class="share" data-taowords="@214">生化危机生化危机</span></p>
                    <p>即可获得资源地址</p>
                </div>
                <div class="taotip2 animated bounceIn" id="nbcopy">
                    <span id="copybtn" class="btn">一键复制</span>
                    <div class="share_content"></div>
                </div>
                <div class="close "></div>
            </div>
            <div class="js-tc-tip animated pulse hide">
                <!--复制成功，快去</br>
                公众号粘贴回复吧～-->
            </div>
            <!--小图标-->
            <div class="js-tc-moviceIco animated bounceInLeft">

                <img src="images/model-movice.png" />
            </div>
        </div>
    </div>
    <input type="hidden" id="page" value="" />
    <input type="hidden" id="all" value="" />
</body>
<%--<script src="/statics/release/ql2.0/js/vr_movie2.min.js"></script>--%>
<script src="js/jquery.min.js"></script>
<script src="js/vr_movie2.min.js"></script>
<script>

    window.onload = function () {
        $("#page").val("2");
        $("#all").val("1");

    };
    var flag = 1;
    //滚动底部自动加载数据
    $(window).scroll(function () {
        var scrollTop = $(this).scrollTop();
        var scrollHeight = $(document).height();
        var windowHeight = $(this).height();
        if (scrollHeight - (scrollTop + windowHeight) <= 0) {
            var page = $("#page").val();
            var all = $("#all").val();
            if (all == 1 && flag == 1) {

                
                glist_json(page);
            }
        }
    });

    //获取数据
    function glist_json(page) {
        
        flag = 0;
        var type = $("#type").val();
        $.getJSON('/ashx/getFileList.ashx?m=wap&c=index&a=wx_movie&type=' + type + '&flag=' + flag + '&page=' + page, function (data) {

            if (data) {
                for (var i = 0; i < data.length; i++) {
                    var ul = '<li class="item" mytitle="' + data[i].title + '" copyWord="' + data[i].keyword + '" mytype="' + data[i].flag + '">';
                    ul += '<img src="' + data[i].image + '" />';
                    ul += '<p class="l-ell">' + data[i].title + '</p>';
                    ul += '</li>';
                    $("#content").append(ul);
                    $("#page").val(parseInt($("#page").val()) + 1);
                }
            }
            else {

            }

            //alert(data[0].sum);
            //if (data[0].sum != 1) {
            //    $("#page").val(data[0].page);
                
            //    if (data[0].page <= data[0].sum) {

            //    } else if (data[0].page > data[0].sum) {
            //        $("#all").val(2);
            //    }
            //    flag = 1;
            //} else {
            //    $("#all").val(2);
            //}
        });
    }
</script>
</html>
