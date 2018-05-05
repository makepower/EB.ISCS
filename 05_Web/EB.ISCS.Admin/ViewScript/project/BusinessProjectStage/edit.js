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
            Name: {
                required: "名称不能为空",
                minlength: "名称长度不能小于{minlength}",
                maxlength: "名称长度不能大于{maxlength}"
            },
            //Describe: {
            //    required: "描述不能为空",
            //    minlength: "名称长度不能小于{minlength}",
            //    maxlength: "名称长度不能大于{maxlength}"
            //},
            Sort: {
                required: "请填写阶段排序号！"
            },
            //Enabled: {
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
                return $http.post("/BusinessProjectStage/GetModelById", { 'Id': id });
            },
            //保存数据
            setModel: function (data) {
                return $http.post("/BusinessProjectStage/SaveModel", data);
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
                _scope.model.Leader = $("#leader").combobox("getValue");
                _this.SaveData(_scope.model);
                //if (!_scope.model.ProjectId || _scope.model.ProjectId == "0") {
                //    layer.msg("请选择项目！");
                //} else {

                //}
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
                //console.info(result);
                if (result.Code == 10000 && result.Data) {
                    _scope.model = result.Data;
                    //console.info(_scope.model);
                    //_scope.model.ProjectId = 0;
                    //_scope.model.Leader = 0;
                    $("#project").combobox({
                        url: "/BusinessProject/GetAllStaged",
                        valueField: "Id",
                        textField: "Name",
                        onLoadSuccess: function (d) {
                            //console.info(data);
                            if (d.Data && d.Data.length > 0) {
                                $(this).combobox("loadData", d.Data);
                                if (result.Data.ProjectId) {
                                    $(this).combobox("setValue", result.Data.ProjectId);
                                } else {
                                    $(this).combobox("setValue", d.Data[0].Id);
                                }
                            }
                        },
                        onChange(n, o) {
                            //console.info(n);
                            $("#leader").combobox({
                                url: "/GroupUser/GetGroupUsersByProject?projectId=" + n,
                                valueField: "Id",
                                textField: "UserName",
                                disabled: true,
                                onLoadSuccess: function (r) {
                                    //console.info(r);
                                    //console.info(r.Data);
                                    if (r.Data && r.Data.length > 0) {
                                        $("#leader").combobox("enable");
                                        $("#leader").combobox("loadData", r.Data);
                                        if (result.Data.Leader) {
                                            $("#leader").combobox("setValue", result.Data.Leader);
                                        } else {
                                            $("#leader").combobox("setValue", r.Data[0].Id);
                                        }
                                    } else {
                                        $("#leader").combobox("clear");
                                    }
                                }
                            });
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