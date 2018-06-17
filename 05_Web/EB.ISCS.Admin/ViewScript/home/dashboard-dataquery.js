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
            },
            queryChartData: function (id) {
                return $http.post('/DashBoard/GetChartData/' + id, null);
            }
        }
    }]);

    //用户管理
    var dashBoardManager = {
        _service: null,
        _scope: null,
        _commonService: null,
        _chartOptionArray: [],

        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service;
            _commonService = commonService,
            _this.Register();
            _this.InitData();
        },
        // 注册初始化元素
        Register: function () {
            this._chartOptionArray = new Array();
            this._chartOptionArray.push({ K: charBizEnum.Map, C: "div_map", P: eBchartOption.mapOption });
            this._chartOptionArray.push({ K: charBizEnum.BootomN, C: "div_bottomN", P: eBchartOption.bottomOption });
            this._chartOptionArray.push({ K: charBizEnum.TopN, C: "div_topN", P: eBchartOption.topNoption });
            this._chartOptionArray.push({ K: charBizEnum.Sell_ForMonth, C: "div_sellMoney", P: eBchartOption.sellMoneyOption });
            this._chartOptionArray.push({ K: charBizEnum.Complain_Type, C: "div_complainType", P: eBchartOption.complainTypeOption });
            this._chartOptionArray.push({ K: charBizEnum.ComplainForYear, C: "div_complain", P: eBchartOption.complainOption });
            this._chartOptionArray.push({ K: charBizEnum.Custo_From_Analy, C: "div_customerAddr", P: eBchartOption.customerAddrOption });
            this._chartOptionArray.push({ K: charBizEnum.Custom_Analy, C: "div_customerType", P: eBchartOption.customerTypeOption });
            this._chartOptionArray.push({ K: charBizEnum.Flow_ForMonth, C: "div_flow", P: eBchartOption.flowOption });
            this._chartOptionArray.push({ K: charBizEnum.Logistics_Segment_Time_Analy, C: "div_logisticsTime", P: eBchartOption.logisticsTimeOption });
            this._chartOptionArray.push({ K: charBizEnum.Logistics_SpendTime, C: "div_logistics", P: eBchartOption.logisticsOption });
            this._chartOptionArray.push({ K: charBizEnum.Order_Status_ForMonth, C: "div_orderStatus", P: eBchartOption.orderStatusOption });
            this._chartOptionArray.push({ K: charBizEnum.Order_Trans, C: "div_orderTrans", P: eBchartOption.orderTransOption });
            this._chartOptionArray.push({ K: charBizEnum.Pay_Channel, C: "div_orderPay", P: eBchartOption.orderPayChannel });
        },
        // 初始化数据
        InitData: function () {
            var _this = this;
            // 首页视图
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
            //加载业务图表数据
            this._chartOptionArray.forEach(function (v, i, array) {
                _service.queryChartData(v.K).success(function (result) {
                    if (result.Code == 10000) {
                        var option = v.P(result.Data);
                        var chart_div = document.getElementById(v.C);
                        echarts.init(chart_div).setOption(option);
                    }
                }).error(function (error) {
                    layer.msg(error.Message, { icon: 5 });
                });
            });
        }

    }
})();
