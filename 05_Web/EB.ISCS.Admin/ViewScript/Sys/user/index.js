/*
 用户管理列表
*/
(function () {
       
    var app = angular.module('UserApp', ['CommonApp']);
    //控制器
    app.controller('UserController', function ($scope, service, commonService) {
        userList.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory('service', ['$http', function ($http) {
        return {
            //删除节点
            deleteUser: function (id) {
                return $http.post('/User/DelUser', { 'Id': id });
            }
        }
    }]);

    //用户管理
    var userList = {
        _searchcondition: null,
        gridView: null,
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        where: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _scope.companys = [];
            _service = service;
            _commonService = commonService,
            gridView = $("#jqGrid");
            where = " AND UserType=0";
            _this.InitData();
            _this.AddEventListener();
            //ZhiDun.setButtonPermission($("#MenuId").val());
        },

        InitData: function () {
            var _this = this;
            _this.InitGrid();
        },
        //加载Grid
        InitGrid: function () {
            var _this = this;
            gridView.gvLoadGrid({
                gvHeadXml: "Sys\\用户管理",
                gvUrl: '/User/GetUserListByQuery',
                params: [],    //对应SQL语句参数，若无参数 则不写这个参数数组或者为空数组
                sqlWhere: where
            }, {
                lines: true,
                sortName: 'id',
                sortOrder: 'desc',
                idField: 'id',
                customsort: false,
                height: 60,
                showCheckbox: false,
                pagination: true,    //设置是否有分页
                singleSelect: true,  //设置是否为单选
                pageSize: 15,   //单页显示行数
                pageList: [15, 40, 50],  //下拉列表改变单页显示行数
                onClickRow: function (index, row) {

                },
                onDblClickRow: function (index, row) {
                    _this.showEdit(row.Id, '编辑用户信息');
                }
            });

            //comControl.postWithDepartmentTree("SelectPost", null);
        },

        //添加事件
        AddEventListener: function () {
            var _this = this;

            //点击新增
            $('#btn_add').click(function () {
                _this.showEdit(0, '新增用户信息');
            });

            //点击编辑
            $('#btn_edit').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    _this.showEdit(row.Id, '编辑用户信息');
                }
            });
            //点击角色分配
            $('#btn_user_role').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    _this.showUserRole(row.Id, '用户角色信息');
                }
            });
            //点击用户权限
            $('#btn_user_Permissions').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    _this.showUserPermission(row.Id, '用户权限信息');
                }
            });
            //点击删除
            $("#btn_del").click(function () {
                var row = gridView.tgvGetSelectRow();
                if (row.Id) {
                    layer.confirm('确认要删除选择的数据吗？',
                        {
                            time: 20000,
                            btn: ['确定', '取消']
                        },
                        function() {
                            _service.deleteUser(row.Id).success(function (result) {
                                if (result.Code == 10000) {
                                    layer.msg("删除成功");
                                    _this.InitGrid();
                                } else {
                                    layer.msg(result.Message);
                                }
                            });
                        },
                        function() {
                        });
                }
            });

            //点击搜索
            $("#btn_open_search").click(function () {
                layer.open({
                    title: '搜索',
                    type: 1,
                    area: ['600px', _scope.userIsManage == 1 ? '260px' : '200px'],
                    content: $('#divSerrch').removeAttr("style") //这里content是一个DOM
                });
            });
            //点击确认查询
            $("#btn_search").click(function () {
                var search = where;
                if (_scope.userIsManage == 1) {
                }
                var loginName = $('#txt_LoginName').val().trim();
                var userName = $('#txt_UserName').val().trim();
                if (loginName) {
                    search += " AND LoginName Like '%" + loginName + "%'";
                }
                if ($('#txt_UserName').val()) {
                    search += " AND UserName Like '%" + userName + "%'";
                }
                gridView.gvRefreshGrid(search);
                layer.closeAll();
            });

            //点击刷新
            $("#btn_refresh").click(function () {
                gridView.gvRefreshGrid(where);
            });
        },

        //弹出编辑窗口
        showEdit: function (id, title) {
            var _this = this;
            var url = "/User/Edit?id=" + id + "&_t=" + Math.random();
            id = id ? id : 0;
            layer.open({
                type: 2,
                title: title,
                area: ['1000px', id > 0 ? '450px' : '520px'],
                fix: true, //不固定
                scrollbar: false,
                maxmin: true,
                content: [url, 'no'],
                end: function () {
                    gridView.gvRefreshGrid(where);
                }
            });
        },

        //弹出角色编辑窗口
        showUserRole: function (id, title) {
            var _this = this;
            var url = "/User/UserRole?id=" + id + "&_t=" + Math.random();
            id = id ? id : 0;
            layer.open({
                type: 2,
                title: title,
                area: ['800px', '600px'],
                fix: false, //不固定
                maxmin: true,
                content: [url, 'no'],
                end: function () {
                    gridView.gvRefreshGrid(where);
                }
            });
        },
        //弹出用户权限窗口
        showUserPermission: function (id, title) {
            var _this = this;
            var url = "/User/UserPermissions?id=" + id + "&_t=" + Math.random();
            id = id ? id : 0;
            layer.open({
                type: 2,
                title: title,
                area: ['600px', '500px'],
                fix: false, //不固定
                maxmin: true,
                content: [url, 'no'],
                end: function () {
                    gridView.gvRefreshGrid(where);
                }
            });
        }
    }
})();
