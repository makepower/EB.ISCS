/*
人员新增修改
*/
(function () {
    var app = angular.module("FlowEditApp", ["w5c.validator", "CommonApp"]);
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
            Code: {
                required: "请填写流程编码"
            },
            Version: {
                required: "请填写版本号"
            }
        });
    }]);

    //控制器
    app.controller("FlowEditController", function ($scope, service, commonService, $location) {
        flowManage.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory("service", ["$http", function ($http) {
        return {
            //获取用户
            getTemplate: function (id) {
                return $http.post("/FlowTemplate/GetById", { 'Id': id });
            },
            //保存数据
            saveTemplate: function (data) {
                return $http.post("/FlowTemplate/SaveData", data);
            }
        }
    }]);

    //用户管理
    var flowManage = {
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
            }
            //点击保存
            _scope.onSave = function () {
                if (_scope.flow.IsDataEnabled === 1 && _scope.flow.StartDate > _scope.flow.EndDate) {
                    layer.msg("有效期开始日期不能大于有效期截止日期");
                    return false;
                }
                _this.SaveData(_scope.flow);
            }
            //点击关闭
            _scope.onclose = function () {
                parent.layer.close(_index);
            }

            _scope.onSelect = function () {
                comControl.selectRules(function () {
                    var data = parent.$("body").data("body_select_rules");
                    if (data) {
                        $("#flow_rulesName").val(data.text);
                        _scope.flow.RulesId = data.id;
                        _scope.$apply();
                    }
                }, true,"");
            }
        },
        //加载数据
        InitData: function (id) {
            var _this = this;
            //获取参数
            _service.getTemplate(id).success(function (result) {
                if (result.Code == 10000 && result.Data) {
                    _scope.flow = result.Data;
                    comControl.datepicker('txt_flowStartDate', _scope.flow.StartDate);
                    comControl.datepicker('txt_flowEndDate', _scope.flow.EndDate);
                    $("#flow_rulesName").val(_scope.flow.RulesName);
                    _scope.flow.RulesId = _scope.flow.RulesId;
                }
                else {
                    layer.msg(result.Message, { icon: 5 });
                }
            }).error(function (error) {
                layer.msg(result.Message, { icon: 5 });
            });
        },
        //保存数据
        SaveData: function (postData) {
            var _this = this;
            _service.saveTemplate(postData).success(function (result) {
                if (result.Code == 10000 && result.Data) {
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
        }
    }
})();