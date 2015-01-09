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
        'width': '100%',
        'height': '100%',
        'fitToView': false,
        'autoScale': true,
        'autoDimensions': true,
        'scrolling': 'auto',
        'transitionOut': 'none',
        'showCloseButton': false,
        'hideOnOverlayClick': false,
        'onComplete': function () {
            $("body").css("overflow", "hidden");
        },
        'onClosed': function () {
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
            parent.$.fancybox.close(); 
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