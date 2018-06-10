/*
 首页数据注入管理列表
*/
(function () {

    var app = angular.module('DashBoardApp', ['CommonApp']);
    //控制器
    app.controller('DashBoardController', function ($scope, service, commonService) {
        dashBoardManager.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory('service', ['$http', function ($http) {
        return {
            //删除节点
            queryTodayReal: function () {
                return $http.post('/DashBoard/TodayReal', null);
            }
        }
    }]);

    //用户管理
    var dashBoardManager = {
        _service: null,
        _scope: null,
        _commonService: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service;
            _commonService = commonService,
            _this.InitData();
        },

        InitData: function () {
            var _this = this;
            _service.queryTodayReal().success(function (result) {
                if (result.Code == 10000 && result.Data.length == 4) {
                    _scope.PayOrder = result.Data[0];
                    _scope.PayMoney = result.Data[1];
                    _scope.Visttor = result.Data[2];
                    _scope.PayGoodNum = result.Data[3];
                }


            }).error(function (error) {
                layer.msg(error.Message, { icon: 5 });
            });
        }



    }
})();
