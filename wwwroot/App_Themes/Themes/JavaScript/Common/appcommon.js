//Fancybox operations
var $_cancelfancybox = false;
$(document).ready(function () {
    $("a.fancyboxlink").fancybox({
        'type': 'iframe',
        'padding': 0,
        'margin': 0,
        'fitToView': true,
        'autoScale': true,
        'autoHeight': true,
        'autoWidth': true,
        'autoDimensions': true,
        'scrolling': 'auto',
        'transitionOut': 'none',
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
        }
    });
    $("a.fancyboxmodellink").fancybox({
        'type': 'iframe',
        'padding': 0,
        'fitToView': true,
        'autoScale': true,
        'autoHeight': true,
        'autoWidth': true,
        'autoDimensions': true,
        'scrolling': 'auto',
        'transitionOut': 'none',
        'onComplete': function () {
            $("body").css("overflow", "hidden");
        },
        'afterClose': function () {
            if ($_cancelfancybox == false) {
                if (typeof (EditorWindowClose) != 'undefined') {
                    EditorWindowClose();
                }
            }
            $_cancelfancybox = false;
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
