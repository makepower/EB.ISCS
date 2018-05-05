/*
人员新增修改
*/
(function () {
    var app = angular.module("TaskSingleCreateApp", ['w5c.validator', 'CommonApp']);
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
    app.controller('TaskSingleCreateController', function ($scope, service, commonService, $location) {
        taskform.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory('service', ['$http', function ($http) {
        return {
            //获取用户
            getDesign: function (id) {
                return $http.post('/TaskSingleInfo/GetById', { 'id': id });
            },
            //保存用户
            saveDesign: function (postData) {
                return $http.post('/TaskSingleInfo/SaveFormData', postData);
            }
        }
    }]);

    //用户管理
    var taskform = {
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        _designer: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service;
            _commonService = commonService;
            _index = parent.layer.getFrameIndex(window.name);
            _designer = EB.ISCS.FormDesign("bars", "sortable", "property");
            _this.AddEventListener();
        },
        //添加事件
        AddEventListener: function () {
            var _this = this;
            //初始化
            _scope.onload = function (id) {
                _this.InitData(id ? id : 0);
                _scope.id = id;
            }
            $("#saves").click(function () {
                var data = _designer.onGetData(_scope.id);
                if (data) {
                    _scope.form.FormDesign = JSON.stringify(data);
                    _this.SaveData(_scope.form);
                } else {
                    layer.msg("无数据用于保存");
                }
            });
            $("#cancel").click(function () {
               // parent.layer.close(_index);
                comControl.closeTabpage();
            });
            $("#preview").click(function () {
                _designer.onPreView();
            });
        },
        //加载数据
        InitData: function (id) {
            var _this = this;
            //获取用户信息
            _service.getDesign(id).success(function (result) {
                _scope.form = result.Data;
                if (result.Data.FormDesign)
                _designer.onLoadData(JSON.parse(result.Data.FormDesign));
            }).error(function (error) {
                layer.msg(error.Message, { icon: 5 });
            });
        },
        //保存数据
        SaveData: function (postData) {
            var _this = this;
            _service.saveDesign(postData).success(function (result) {
                if (result.Code == 10000 && result.Data) {
                    layer.msg(result.Message, { icon: 1 });
                    setTimeout(function () {
                        parent.layer.close(_index);
                    }, 500);
                }
                else {
                    layer.msg(result.Message, { icon: 5 });
                }
            })
                .error(function (error) {
                    layer.msg(result.Message, { icon: 5 });
                });

        }
    }
})();