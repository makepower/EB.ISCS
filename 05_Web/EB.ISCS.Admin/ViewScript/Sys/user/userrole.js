/*
用户分配角色
*/
(function () {
    //注册模块
    var app = angular.module('UserRoleApp', []);

    //控制器
    app.controller('UserRoleController', function ($scope, service, $location) {
        userroleManage.InitializePage($scope, service);
    });

    //注册服务
    app.factory('service', ['$http', function ($http) {
        return {
            //获取角色列表
            getRoleList: function (id) {
                return $http.post('/User/GetRoleList', { 'UserId': id });
            },
            //保存用户角色
            saveUser: function (postData) {
                return $http.post('/User/SaveUserRole', postData);
            },
            //获取用户
            getUser: function (id) {
                return $http.post('/User/GetUser', { 'Id': id });
            }
        }

    }]);

    //用户角色管理
    var userroleManage = {
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service,
            _commonService = commonService,
            _index = parent.layer.getFrameIndex(window.name),
            _this.AddEventListener();
        },
        //添加事件
        AddEventListener: function () {
            var _this = this;
            //初始化
            _scope.onload = function (id) {
                _scope.UserId = id;
                _this.regControl();
                _this.InitData(id ? id : 0);
            }
            //点击保存
            _scope.onSave = function () {
                var arr = new Array();
                angular.element('#multiselect_to').find("option").each(function () {
                    arr.push($(this).val());
                });
                _this.SaveData({ UserId: _scope.UserId, RoleIds: arr.join(',') });
            }
            //点击关闭
            _scope.onclose = function () {
                parent.layer.close(_index);
            }
        },
        //加载数据
        InitData: function (id) {
            var _this = this;
            //获取用户信息
            _service.getUser(id).success(function (result) {
                _scope.userName = result.Data.UserName;
            });
            
            //获取未分配和已分配的用户信息
            _service.getRoleList(id)
                .success(function (result) {
                    _scope.selectIds = result.relation;
                    _scope.selectIds = result.noRelation;
                    _scope.roleList = result.relation;
                    _scope.noRoleList = result.noRelation;
                })
                .error(function (error) {
                    layer.msg(error.Message,{icon:5});
                });
        },
        //保存数据
        SaveData: function (postData) {
            var _this = this;
            _service.saveUser(postData)
                .success(function (result) {
                    if (result.Code == 10000 && result.Data) {
                        layer.msg(result.Message, { icon: 1 });
                        setTimeout(function () {
                            parent.layer.close(_index);
                        }, 500);
                    }
                })
                .error(function (error) {
                    layer.msg(error.Message, { icon: 5 });
                });
        },
        //注册控件
        regControl: function (value) {
            var _this = this;
            //angular.element('multiselect').multiselect();
        }
    }
})();