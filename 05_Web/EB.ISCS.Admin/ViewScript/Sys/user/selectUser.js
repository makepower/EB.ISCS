/*
 选择用户
*/
(function () {
    var app = angular.module('UserApp', ['CommonApp']);
    //控制器
    app.controller('UserController', function ($scope, commonService) {
        selectUserList.InitializePage($scope, commonService);
    });

    //选择用户
    var selectUserList = {
        _index: null,
        gridView: null,
        _scope: null,
        _commonService: null,
        where: null,
        InitializePage: function (scope, commonService) {
            var _this = this;
            gridView = $("#jqGrid");
            where = $("#hidSqlWhere").val();
            _scope = scope;
            _commonService = commonService,
            this.InitData();
            _this.AddEventListener();
            _index = parent.layer.getFrameIndex(window.name);
        },

        InitData: function () {
            var _this = this;
            //获取用户信息
            _commonService.getCurrentUser()
                .success(function (result) {
                    _this.InitGrid();
                })
                .error(function (error) {
                    layer.msg(error.Message, { icon: 5 });
                });
            _scope.userTypes = [{ 'id': 0, text: '员工', 'id': 1, text: '工人' }];
        },
        //加载Grid
        InitGrid: function () {
            var _this = this;
            gridView.gvLoadGrid({
                gvHeadXml: "Sys\\用户管理",
                gvUrl: "/Employee/GetEmployeeList",
                params: [],    //对应SQL语句参数，若无参数 则不写这个参数数组或者为空数组
                sqlWhere: where
            }, {
                sortName: 'id',
                sortOrder: 'desc',
                idField: 'id',
                height: 60,
                showCheckbox: false,
                pagination: true,    //设置是否有分页
                singleSelect: true,  //设置是否为单选
                pageSize: 15,   //单页显示行数
                pageList: [15, 40, 50],  //下拉列表改变单页显示行数
                onClickRow: function (index, row) {

                }
            });
        },
        //添加事件
        AddEventListener: function () {
            var _this = this;
            //点击确认
            $('#btn_ok').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var data = gridView.gvGetSelectRow();
                    parent.$("body").data("dataUser", data);
                    parent.layer.close(_index);
                }
            });

            //点击取消
            $('#btn_cancel').click(function () {
                parent.layer.close(_index);
            });
            //点击打开查询窗口
            $("#btn_open_search").click(function () {
                layer.open({
                    title: '搜索',
                    type: 1,
                    area: ['600px', '260px'],
                    content: $('#divSerrch').removeAttr("style") //这里content是一个DOM
                });
            });

            //点击确认查询
            $("#btn_search").click(function () {
                var search = where;
                var loginName = $('#txt_LoginName').val().trim();
                var userName = $('#txt_UserName').val().trim();
                var userType = $('#txt_userType').val().trim();
                if (loginName) {
                    search = " AND LoginName Like '%" + loginName + "%'";
                }
                if (userName) {
                    search += " AND UserName Like '%" + userName + "%'";
                }
                if (userType) {
                    search += " AND UserType =" + userType;
                }
                gridView.gvRefreshGrid(search);
                layer.closeAll();
            });

            //点击刷新
            $("#btn_refresh").click(function () {
                gridView.gvRefreshGrid(where);
            });
        }
    }
})();