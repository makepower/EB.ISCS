﻿/*
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
            Name: {
                required: "名称不能为空",
                minlength: "名称长度不能小于{minlength}",
                maxlength: "名称长度不能大于{maxlength}"
            },
            Describe: {
                required: "描述不能为空",
                minlength: "描述长度不能小于{minlength}",
                maxlength: "描述长度不能大于{maxlength}"
            },
            ProjectType: {
                required: "请选择项目类型！"
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
                return $http.post("/BusinessProject/GetModelById", { 'Id': id });
            },
            //保存数据
            setModel: function (data) {
                return $http.post("/BusinessProject/SaveModel", data);
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
                _scope.model.ParentId = $("#parentProject").combobox("getValue");
                _scope.model.ProjectType = comControl.comboxTree.getTreeValue("projectType");
                if (!_scope.model.ProjectType || _scope.model.ProjectType == "0") {
                    layer.msg("请选择项目类型！");
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
                        _scope.model.IsStage = 0;
                        _scope.model.Enabled = 1;
                    }
                    comControl.dirGet.DicTree("projectType", result.Data.ProjectType, enumDicType.Business.ProjectType);
                    $("#parentProject").combobox({
                        url: "/BusinessProject/GetAllList",
                        textField: "Name",
                        valueField: "Id",
                        onLoadSuccess: function (data) {
                            //console.info(data.Data);
                            if (data.Data) {
                                data.Data.unshift({ Id: 0, Name: "无" });
                                $(this).combobox("loadData", data.Data);
                                if (result.Data.ParentId) {
                                    $(this).combobox("setValue", result.Data.ParentId);
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
                //console.info(result);
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