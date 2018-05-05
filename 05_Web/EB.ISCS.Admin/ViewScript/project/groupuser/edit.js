/*
项目新增修改
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
            Duty: {
                required: "职责不能为空",
                minlength: "职责长度不能小于{minlength}",
                maxlength: "职责长度不能大于{maxlength}"
            },
            Remark: {
                required: "备注不能为空",
                minlength: "备注长度不能小于{minlength}",
                maxlength: "备注长度不能大于{maxlength}"
            },
            User: {
                required: "请选择组成员！"
            },
            group: {
                required: "请选择所属项目组！"
            },
            enabled: {
                required: "请选择是否启用！"
            }
        });
    }]);

    //控制器
    app.controller("EditController", function ($scope, service, commonService, $location) {
        model.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory("service", ["$http", function ($http) {
        return {
            //获取用户
            getModel: function (id) {
                return $http.post("/GroupUser/GetModelById", { 'Id': id });
            },
            //保存数据
            setModel: function (data) {
                return $http.post("/GroupUser/SaveModel", data);
            }
        }
    }]);

    //用户管理
    var model = {
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
                //comControl.dirGet.GroupType("GroupType");
            }
            //点击保存
            _scope.onSave = function () {
                _scope.model.GroupId = $("#group").combobox("getValue");
                _scope.model.UserId = $("#user").combobox("getValue");
                if (!_scope.model.GroupId || _scope.model.GroupId == "0") {
                    layer.msg("请先选择所属项目组！");
                } else if (!_scope.model.UserId || _scope.model.UserId == "0") {
                    layer.msg("请选择组成员！");
                } else {
                    _this.SaveData(_scope.model);
                }
            }
            //点击关闭
            _scope.onclose = function () {
                parent.layer.close(_index);
            }
        },
        //加载数据
        InitData: function (id) {
            var _this = this;
            //获取参数
            _service.getModel(id).success(function (result) {
                if (result.Code == 10000 && result.Data) {
                    _scope.model = result.Data;
                    if (_scope.model.Id == 0) {
                        _scope.model.Enabled = 1;
                    }

                    $("#group").combobox({
                        url: "/BusinessProjectGroup/GetAllList",
                        textField: "Name",
                        valueField: "Id",
                        onLoadSuccess: function (data) {
                            //console.info(data.Data);
                            if (data.Data) {
                                data.Data.unshift({ Id: 0, Name: "无" });
                                $(this).combobox("loadData", data.Data);
                                if (result.Data.GroupId) {
                                    $(this).combobox("setValue", result.Data.GroupId);
                                } else {
                                    $(this).combobox("setValue", data.Data[0].Id);
                                }
                            }
                        }
                    });
                    $("#user").combobox({
                        url: "/User/GetAllList",
                        textField: "UserName",
                        valueField: "Id",
                        onLoadSuccess: function (data) {
                            //console.info(data.Data);
                            if (data.Data) {
                                data.Data.unshift({ Id: 0, Name: "无" });
                                $(this).combobox("loadData", data.Data);
                                if (result.Data.UserId) {
                                    $(this).combobox("setValue", result.Data.UserId);
                                } else {
                                    $(this).combobox("setValue", data.Data[0].Id);
                                }
                            }
                        }
                    });
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
            //console.info(postData);
            _service.setModel(postData).success(function (result) {
                console.info(result);
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