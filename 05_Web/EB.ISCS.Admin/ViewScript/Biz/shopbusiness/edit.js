/*
人员新增修改
*/
(function () {
    var app = angular.module('ShopApp', ['w5c.validator', 'CommonApp']);
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
            ShopName: {
                required: '店铺名称不能为空',
                minlength: '店铺名称长度不能小于{minlength}',
                maxlength: '店铺名称长度不能大于{maxlength}'
            },
            Appkey: {
                required: '请填写AppKey'
            },
            AppSecrect: {
                required: '请填写AppSecrect'
            }
        });
    }]);

    //控制器
    app.controller('ShopController', function ($scope, service, commonService, $location) {
        ShopManage.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory('service', ['$http', function ($http) {
        return {
            //获取用户
            getShop: function (id) {
                return $http.post('/ShopBusiness/GetShipInfo', { 'Id': id });
            },
            //保存用户
            saveShop: function (postData) {
                return $http.post('/ShopBusiness/SaveShop', postData);
            }
        }
    }]);

    //用户管理
    var ShopManage = {
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service,
                _commonService = commonService,
                _scope.companys = [];
            _index = parent.layer.getFrameIndex(window.name),
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
                _this.SaveData(_scope.Shop);
            }
            //点击关闭
            _scope.onclose = function () {
                parent.layer.close(_index);
            }
        },
        //加载数据
        InitData: function (id) {
            _commonService.getCurrentUser().success(function (result) {
                _scope.UserIsManage = result.UserIsManage;
            });


            _scope.plats = [{ id: "0", name: "淘宝" },
                { id: "1", name: "天猫" },{ id: "2", name: "京东" }];

            //获取信息
            _service.getShop(id).success(function (result) {
                _scope.Shop = result.Data;
                comControl.datepicker('txt_InDate', _scope.Shop.InDate);
            }).error(function (error) {
                layer.msg(error.Message, { icon: 5 });
            });
        },
        //保存数据
        SaveData: function (postData) {
            var _this = this;
            _service.saveShop(postData)
                .success(function (result) {
                    if (result.Code == 10000 && result.Data) {
                        layer.msg(result.Message, { icon: 1 });
                        setTimeout(function () {
                            parent.layer.close(_index);
                        },
                            500);
                    } else {
                        layer.msg(result.Message, { icon: 5 });
                    }
                })
                .error(function (error) {
                    layer.msg(result.Message, { icon: 5 });
                });
        },
    }
})();