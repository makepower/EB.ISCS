/*
人员新增修改
*/
(function () {
    var app = angular.module("TaskTemplateEditApp", ["w5c.validator", "CommonApp"]);
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
            template_Name: {
                required: "表单名称不能为空",
                minlength: "表单名称长度不能小于{minlength}",
                maxlength: "表单名称长度不能大于{maxlength}"
            },
            dicType: {
                required: "请选择部门"
            }
        });
    }]);
    //注册服务
    app.factory("service", ["$http", function ($http) {
        return {
            //获取用户
            getInfo: function (id) {
                return $http.post("/TaskTemplate/GetById", { 'Id': id });
            },
            //保存用户
            saveInfo: function (postData) {
                return $http.post("/TaskTemplate/SaveData", postData);
            }
        }
    }]);

    //用户管理
    var singlelist = {
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
                _scope.template.DepId = comControl.comboxTree.getTreeValue("DepId");
                _scope.template.DicTypeId = comControl.comboxTree.getTreeValue("DicTypeId");
                if (_scope.template.IsDataEnabled === 1 && _scope.template.StartDate > _scope.template.EndDate) {
                    layer.msg("有效期开始日期不能大于有效期截止日期");
                    return false;
                }
                _this.SaveData(_scope.template);
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
                _scope.template = result.Data;

                comControl.dirGet.DicAllTree("DicTypeId", _scope.template.DicTypeId, enumDicType.Business.ProgramType);
                comControl.departTree("DepId", _scope.template.DepId);

                comControl.datepicker("forms_UseStartTime", _scope.template.UseStartTime);
                comControl.datepicker("forms_UseStopTime", _scope.template.UseStopTime);
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
    app.controller("TaskTemplateEditController", function ($scope, service, commonService, $location) {
        singlelist.InitializePage($scope, service, commonService);
    });

})();