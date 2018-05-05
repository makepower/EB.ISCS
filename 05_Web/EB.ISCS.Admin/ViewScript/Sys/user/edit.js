/*
人员新增修改
*/
(function () {
    var app = angular.module('UserApp', ['w5c.validator', 'CommonApp']);
    //全局配置
    app.config(["w5cValidatorProvider", function (w5cValidatorProvider) {
        // 验证规则
        w5cValidatorProvider.config({
            blurTrig: false, //是否失去焦点时触发
            showError: true, //显示错误
            removeError: true //移除错误
        });
        //提示信息
        w5cValidatorProvider.setRules({
            LoginName: {
                required: '登录名称不能为空',
                minlength: '登录名称长度不能小于{minlength}',
                maxlength: '登录名称长度不能大于{maxlength}'
            },
            UserName: {
                required: '员工姓名不能为空',
                minlength: '员工姓名长度不能小于{minlength}',
                maxlength: '员工姓名长度不能大于{maxlength}'
            },
            PassWord: {
                required: '密码不能为空',
                minlength: '密码长度不能小于{minlength}',
                maxlength: '密码长度不能大于{maxlength}'
            },
            SurePwd: {
                required: '确认密码不能为空',
                repeat: '两次密码输入不一致'
            },
            UserPosition: {
                required: '请选择职位'
            },
            UserDepId: {
                required: '请选择部门'
            }, Securitylevel: {
                required: '请选择安全级别'
            }
        });
    }]);

    //控制器
    app.controller('UserController', function ($scope, service, commonService, $location) {
        userManage.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory('service', ['$http', function ($http) {
        return {
            //获取用户
            getUser: function (id) {
                return $http.post('/User/GetUser', { 'Id': id });
            },
            //保存用户
            saveUser: function (postData) {
                return $http.post('/User/SaveUser', postData);
            }
        }
    }]);

    //用户管理
    var userManage = {
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service,
                _commonService = commonService,
                _scope.companys = [];
            _index = parent.layer.getFrameIndex(window.name),
                _this.AddEventListener();
        },
        //添加事件
        AddEventListener: function () {
            var _this = this;
            //初始化
            _scope.onload = function (id) {
                _this.InitData(id ? id : 0);
            }
            //选择用户
            _scope.onSelect = function () {
                comControl.selectEmployee(function () {
                    var data = parent.$('body').data("dataUser");
                    if (data) {
                        if (_scope.user) {
                            _scope.user.UserName = data.Name;
                            _scope.user.EmployeeId = data.Id;
                            _scope.$apply();
                        } else {
                            
                        }
                    }
                }, false," and (b.id is null or  b.DelState =1)");

            }
            //点击保存
            _scope.onSave = function () {
                if (_scope.user.IsExpireDate === 1 && _scope.user.BeginDate > _scope.user.ExpireDade) {
                    layer.msg("有效期开始日期不能大于有效期截止日期");
                    return false;
                }

                _this.SaveData(_scope.user);
            }
            //点击关闭
            _scope.onclose = function () {
                parent.layer.close(_index);
            }
        },
        //加载数据
        InitData: function (id) {
            _commonService.getCurrentUser().success(function (result) {
                _scope.UserIsManage = result.UserIsManage;
            });

            //获取参数
            _commonService.getDictionaryList(enumDicType.System.Securitylevel).success(function (result) {
                if (result.Data) {
                    //职位
                    _scope.securitylevels = result.Data;
                }
            });
            //获取用户信息
            _service.getUser(id).success(function (result) {
                _scope.user = result.Data;
                comControl.datepicker('txt_BeginDate', _scope.user.BeginDate);
                comControl.datepicker('txt_ExpireDade', _scope.user.ExpireDade);
            }).error(function (error) {
                layer.msg(error.Message, { icon: 5 });
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
                        },
                            500);
                    } else {
                        layer.msg(result.Message, { icon: 5 });
                    }
                })
                .error(function (error) {
                    layer.msg(result.Message, { icon: 5 });
                });

        },
    }
})();