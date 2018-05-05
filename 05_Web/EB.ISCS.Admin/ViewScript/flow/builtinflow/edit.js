/*
人员新增修改
*/
(function () {
    var app = angular.module("EditApp", ["w5c.validator", "CommonApp"]);
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
            Name: {
                required: "流程名称不能为空",
                minlength: "流程名称长度不能小于{minlength}",
                maxlength: "流程名称长度不能大于{maxlength}"
            },
            Version: {
                required: "请填写版本号"
            }
        });
    }]);

    //控制器
    app.controller("EditController", function ($scope, service, commonService, $location) {
        builtManage.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory("service", ["$http", function ($http) {
        return {
            //获取用户
            getModel: function (id) {
                return $http.post("/BuiltInFlow/GetById", { 'Id': id });
            },
            //保存数据
            saveModel: function (data) {
                return $http.post("/BuiltInFlow/SaveData", data);
            }
        }
    }]);

    //用户管理
    var builtManage = {
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service;
            _commonService = commonService;
            _index = parent.layer.getFrameIndex(window.name);
            _this.AddEventListener();
        },
        //添加事件
        AddEventListener: function () {
            var _this = this;
            //初始化
            _scope.onload = function (id) {
               _this.InitData(id ? id : 0);
                comControl.dirGet.DicTree('dicTypeSelect', null, enumDicType.Business.BuiltInType);
            };
            //点击保存
            _scope.onSave = function () {
                _scope.built.DicTypeId = comControl.comboxTree.getTreeValue('dicTypeSelect');
                _service.saveModel(_scope.built).success(function (result) {
                    if (result.Code === 10000 && result.Data) {
                        layer.msg(result.Message, { icon: 1 });
                        setTimeout(function () {
                            parent.layer.close(_index);
                        }, 500);
                    }
                    else {
                        layer.msg(result.Message, { icon: 5 });
                    }
                }).error(function (error) {
                    layer.msg(result.Message, { icon: 5 });
                });
            };
            //点击关闭
            _scope.onclose = function () {
                parent.layer.close(_index);
            };
        },
        //加载数据
        InitData: function (id) {
            var _this = this;
            //获取参数
            _service.getModel(id).success(function (result) {
                if (result.Code === 10000 && result.Data) {
                    _scope.built = result.Data;
                }
                else {
                    layer.msg(result.Message, { icon: 5 });
                }
            }).error(function (error) {
                layer.msg(result.Message, { icon: 5 });
            });
        }
    }
})();