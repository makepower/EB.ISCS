/*
人员新增修改
*/
(function () {
    var app = angular.module('DiscreteTaskEditApp', ['w5c.validator', 'CommonApp']);
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
                required: '表单名称不能为空',
                minlength: '表单名称长度不能小于{minlength}',
                maxlength: '表单名称长度不能大于{maxlength}'
            },
            formsDepId: {
                required: '请选择部门'
            }
        });
    }]);

    //控制器
    app.controller('DiscreteTaskEditController', function ($scope, service, commonService, $location) {
        formsManage.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory('service', ['$http', function ($http) {
        return {
            //获取用户
            getforms: function (id) {
                return $http.post('/DiscreteTask/GetById', { 'Id': id });
            },
            //保存用户
            saveforms: function (postData) {
                return $http.post('/DiscreteTask/SaveData', postData);
            }
        }
    }]);

    //用户管理
    var formsManage = {
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
                //_scope.forms.DicType = comControl.comboxTree.getTreeValue('dicType');
                if (_scope.fo.IsDataEnabled === 1 && _scope.fo.StartDate > _scope.fo.EndDate) {
                    layer.msg("有效期开始日期不能大于有效期截止日期");
                    return false;
                }
                _this.SaveData(_scope.fo);
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
            _service.getforms(id).success(function (result) {
                _scope.fo = result.Data;

                comControl.dirGet.DicAllTree('dicType', _scope.fo.DicTypeId, enumDicType.Business.ProgramType);
                comControl.datepicker('forms_UseStartTime', _scope.fo.UseStartTime);
                comControl.datepicker('forms_UseStopTime', _scope.fo.UseStopTime);
                $("#forms_rulesName").val(_scope.fo.RulesName);
                _scope.fo.RulesId = _scope.fo.RulesId;
            }).error(function (error) {
                layer.msg(error.Message, { icon: 5 });
            });
        },
        //保存数据
        SaveData: function (postData) {
            var _this = this;
            _service.saveforms(postData).success(function (result) {
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

        },
        //注册控件
        regControl: function (value) {
            var _this = this;
            comControl.datepicker('forms_UseStartTime');
            comControl.datepicker('forms_UseStopTime');
        }
    }
})();