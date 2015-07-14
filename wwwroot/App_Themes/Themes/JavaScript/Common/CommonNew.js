//Fancybox operations
var $_cancelfancybox = false;
function getscreenheight() {
    var documentHeight = document.body.offsetHeight;
    if (self.innerHeight) { // all except Explorer
        windowWidth = self.innerWidth;
        windowHeight = self.innerHeight;
    }
    else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode
        windowWidth = document.documentElement.clientWidth;
        windowHeight = document.documentElement.clientHeight;
    }
    else if (document.body) { // other Explorers
        windowWidth = document.body.clientWidth;
        windowHeight = document.body.clientHeight;
    }
    documentHeight = documentHeight > windowHeight ? documentHeight : windowHeight;
    return documentHeight;
}

$(document).ready(function () {
    $("a.fancyboxlink").fancybox({
        'type': 'iframe',
        'padding': 0,
        'margin': 0,
        'fitToView': false,
        'autoScale': true,
        'autoSize': true,
        'autoHeight': true,
        'autoWidth': true,
        'autoDimensions': true,
        'scrolling': 'auto',
        'transitionOut': 'none',
        'closeBtn': false,
        'modal': true,
        'onComplete': function () {
            $("body").css("overflow", "hidden");
        },
        'afterClose': function () {
            if ($_cancelfancybox == false) {
                if (typeof(EditorWindowClose) != 'undefined') {
                    EditorWindowClose();
                }
            }
            $_cancelfancybox = false;
            $("body").css("overflow", "auto");
        }
    });
});

function OpenWindow(Url, Width, Height, WindowObj) {
    $("a.fancyboxlink").attr("href", Url);
    $("a.fancyboxlink").trigger("click");
}

function CloseWindowTimeout() {
    $_cancelfancybox = false; 
    $(document).ready(function () {
        setTimeout(function () {
            if (parent.$) {
                if (parent.$.fancybox) {
                    parent.$.fancybox.close();
                }
            }
        }, 2000);
    });
}

function CloseWindow() {
    $_cancelfancybox = true;
    $(document).ready(function () {
        if (parent.$) {
            if (parent.$.fancybox) {
                parent.$.fancybox.close();
            }
        }
        else {
            window.close();
        }
    });
}

function CloseWindowAndRefresh() {
    $_cancelfancybox = false;
    $(document).ready(function () {
        if (parent.$) {
            if (parent.$.fancybox) {
                parent.$.fancybox.close();
            }
        }
        else {
            window.close();
        }
    });
}


$(document).ready(function () {
    $(window).load(function () { setheight() });
    $(window).resize(function () { setheight() });
});

function CheckAll(object) {
    $(".checkboxbatch").attr("checked", object.checked);
}

//CSS±³¾°¿ØÖÆ
function overColor(Obj) {
    var elements = Obj.childNodes;
    for (var i = 0; i < elements.length; i++) {
        $(elements[i]).css("background-color", "#f5f5f5");
        $(elements[i]).css("cursor", "pointer");
    }

}
function outColor(Obj) {
    var elements = Obj.childNodes;
    for (var i = 0; i < elements.length; i++) {
        $(elements[i]).css("background-color", "");
    }
}


var imgArrowLeft = new Image();
var imgArrowRight = new Image();

imgArrowLeft.src = "../../App_Themes/Themes/Image/arrow_left.gif";
imgArrowRight.src = "../../App_Themes/Themes/Image/arrow_right.gif";

function changeWin() {
    //return; //¹Ø±Õ
    if (document.getElementById('divtree').style.display == "none") {
        document.getElementById('divtree').style.display = "block";
        document.getElementById('menuSwitch').src = imgArrowLeft.src;
        document.getElementById('menuSwitch').alt = "Òþ²Ø";
        $('.listpage').addClass('listpageleftposition');
        $('.listpage .toptoolsbar').addClass('listpageleftposition');
    }
    else {
        document.getElementById('divtree').style.display = "none";
        document.getElementById('menuSwitch').src = imgArrowRight.src;
        document.getElementById('menuSwitch').alt = "ÏÔÊ¾";
        $('.listpage').removeClass('listpageleftposition');
        $('.listpage .toptoolsbar').removeClass('listpageleftposition');
    }
}

var isMobile = {
    Android: function () {
        return navigator.userAgent.match(/Android/i) ? true : false;
    },
    BlackBerry: function () {
        return navigator.userAgent.match(/BlackBerry/i) ? true : false;
    },
    iOS: function () {
        return navigator.userAgent.match(/iPhone|iPad|iPod/i) ? true : false;
    },
    Windows: function () {
        return navigator.userAgent.match(/IEMobile/i) ? true : false;
    },
    any: function () {
        return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Windows());
    }
};
