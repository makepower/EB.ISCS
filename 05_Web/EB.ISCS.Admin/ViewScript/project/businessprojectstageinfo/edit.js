/*
项目阶段详情新增修改
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
            //Name: {
            //    required: "名称不能为空",
            //    minlength: "名称长度不能小于{minlength}",
            //    maxlength: "名称长度不能大于{maxlength}"
            //},
            //Remark: {
            //    required: "备注不能为空",
            //    minlength: "名称长度不能小于{minlength}",
            //    maxlength: "名称长度不能大于{maxlength}"
            //},
            //GroupType: {
            //    required: "请选择组类型！"
            //},
            //group_enabled: {
            //    required: "请选择是否启用！"
            //}
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
                return $http.post("/BusinessProjectStageInfo/GetModelById", { 'Id': id });
            },
            //保存数据
            setModel: function (data) {
                return $http.post("/BusinessProjectStageInfo/SaveModel", data);
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
            }
            //点击保存
            _scope.onSave = function () {
                _scope.model.ProjectId = $("#project").combobox("getValue");
                _scope.model.ProjectStageId = $("#projectStage").combobox("getValue");
                if (!_scope.model.ProjectId || _scope.model.ProjectId == "0") {
                    layer.msg("请先选择项目！");
                } else if (!_scope.model.ProjectStageId || _scope.model.ProjectStageId == "0") {
                    layer.msg("请先选择项目阶段！");
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
                    //comControl.dirGet.DicTree("GroupType", result.Data.GroupType, enumDicType.Business.GroupType);
                    $("#project").combobox({
                        url: "/BusinessProject/GetAllStaged",
                        valueField: "Id",
                        textField: "Name",
                        onLoadSuccess: function (data) {
                            //console.info(data);
                            if (data.Data) {
                                $(this).combobox("loadData", data.Data);
                                if (result.Data.ProjectId) {
                                    $(this).combobox("setValue", result.Data.ProjectId);
                                } else {
                                    $(this).combobox("setValue", data.Data[0].Id);
                                }
                            }
                        },
                        onChange: function (newValue) {
                            if (newValue) {
                                $("#projectStage").combobox({
                                    url: "/BusinessProjectStage/GetByProject?projectId=" + newValue,
                                    valueField: "Id",
                                    textField: "Name",
                                    disabled: false,
                                    onLoadSuccess: function (data) {
                                        if (data.Data) {
                                            $(this).combobox("loadData", data.Data);
                                            $(this).combobox("setValue", data.Data[0].Id);
                                        }
                                    }
                                });
                            }
                        }
                    });
                    if (result.Data.ProjectStageId) {
                        $("#projectStage").combobox("setValue", result.Data.ProjectStageId);
                    }
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
            console.info(postData);
            _service.setModel(postData).success(function (result) {
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