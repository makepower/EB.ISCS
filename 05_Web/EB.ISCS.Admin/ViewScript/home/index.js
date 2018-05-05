
$(function () {
    changePassword.init();
});

var changePassword = {
    init: function () {
        this.registerEvents();
    },

    registerEvents: function () {
        var _this = this;
        $('#btn_changepassword').click(function () {
            _this.showEdit('修改密码');
        });

    },

    //弹出窗口
    showEdit: function (title) {
        var _this = this;
        var url = "/Account/ChangePassword?_t=" + Math.random();
        layer.open({
            type: 2,
            title: title,
            area: ['400px', '380px'],
            fix: false, //不固定
            maxmin: true,
            content: [url, 'no'],
            end: function () {
                //parent.window.href = "/Account/LogOff";
            }
        });
    }
}