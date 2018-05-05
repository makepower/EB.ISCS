/*
复合任务新增修改
*/
(function () {
    var app = angular.module("TaskCompositeInfoEditApp", ["w5c.validator", "CommonApp"]);
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
            forms_Name: {
                required: "表单名称不能为空",
                minlength: "表单名称长度不能小于{minlength}",
                maxlength: "表单名称长度不能大于{maxlength}"
            },
            formsDepId: {
                required: "请选择部门"
            }
        });
    }]);
    //注册服务
    app.factory("service", ["$http", function ($http) {
        return {
            //获取复合任务信息
            getInfo: function (id) {
                return $http.post("/TaskCompositeInfo/GetById", { 'Id': id });
            },
            //保存复合任务信息
            saveInfo: function (postData) {
                return $http.post("/TaskCompositeInfo/SaveData", postData);
            }
        }
    }]);

    //用户管理
    var Compositelist = {
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service;
            _commonService = commonService;
            _scope.companys = [];
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
                _scope.composite.DepId = comControl.comboxTree.getTreeValue("depId");
                _scope.composite.DicTypeId = comControl.comboxTree.getTreeValue("dicType");
                if (_scope.composite.IsDataEnabled === 1 && _scope.composite.StartDate > _scope.composite.EndDate) {
                    layer.msg("有效期开始日期不能大于有效期截止日期");
                    return false;
                }
                _this.SaveData(_scope.composite);
            }
            //点击关闭
            _scope.onclose = function () {
                parent.layer.close(_index);
            }

            _scope.onSelect = function () {
                comControl.selectRules(function () {
                    var data = parent.$("body").data("body_select_rules");
                    if (data) {
                        $("#forms_rulesName").val(data.text);
                        _scope.$apply();
                    }
                }, true, "");
            }
        },
        //加载数据
        InitData: function (id) {
            var _this = this;
            //获取用户信息
            _service.getInfo(id).success(function (result) {
                _scope.composite = result.Data;

                comControl.dirGet.DicAllTree("dicType", _scope.composite.DicTypeId, enumDicType.Business.ProgramType);
                comControl.departTree("depId", _scope.composite.DepId);

                comControl.datepicker("forms_UseStartTime", _scope.composite.UseStartTime);
                comControl.datepicker("forms_UseStopTime", _scope.composite.UseStopTime);
            }).error(function (error) {
                layer.msg(error.Message, { icon: 5 });
            });
        },
        //保存数据
        SaveData: function (postData) {
            var _this = this;
            _service.saveInfo(postData).success(function (result) {
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

        }
    }



    //控制器
    app.controller("TaskCompositeInfoEditController", function ($scope, service, commonService, $location) {
        Compositelist.InitializePage($scope, service, commonService);
    });

})();