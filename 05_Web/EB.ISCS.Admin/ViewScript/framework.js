
$(function () {
    //form表单序列化json串
    $.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || "");
            } else {
                o[this.name] = this.value || "";
            }
        });
        return o;
    };
    var t = document.documentElement.clientWidth;
    window.onresize = function () {
        if (t != document.documentElement.clientWidth) {
            t = document.documentElement.clientWidth;
            ZhiDun.doResize("jqGrid");
        }
    }
});


var ZhiDun = {

    doResize: function (gridId) {
        var _this = this;
        var ss = _this.getPageSize();
        $("#" + gridId).jqGrid("setGridWidth", ss.WinW - 10 - 10).jqGrid("setGridHeight", ss.WinH - 100 - 55);
    },
    autoHeight: function (gridId) {
        var _this = this;
        var ss = _this.getPageSize();
        $("#" + gridId).jqGrid("setGridHeight", ss.WinH - 100 - 55);
    },
    getPageSize: function () {
        var winW, winH;
        if (window.innerHeight) {// all except IE 
            winW = window.innerWidth;
            winH = window.innerHeight;
        } else if (document.documentElement && document.documentElement.clientHeight) {// IE 6 Strict Mode 
            winW = document.documentElement.clientWidth;
            winH = document.documentElement.clientHeight;
        } else if (document.body) { // other 
            winW = document.body.clientWidth;
            winH = document.body.clientHeight;
        }  // for small pages with total size less then the viewport  
        return { WinW: winW, WinH: winH };
    },

    setButtonPermission: function (menuId) {
        $("button[data-permisson='actionbutton']").css("display", "none");
        $.post("/Common/GetUserPagePermissions", { menuId: menuId }, function (data) {
            if (data) {
                if (data.permissions != null && data.permissions.length > 0) {
                    var permissions = data.permissions;
                    $.each(permissions,
                        function (i, item) {
                            $("button[data-permisson='actionbutton'][id='" + item.ActionCode + "']").css("display", "block");
                        });
                }
            } else {
                $("button[data-permisson='actionbutton'][style='display: none;']").remove();
            }
        }, "json");
    }
}