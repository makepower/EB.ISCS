
(function () {
    var app = angular.module("BuiltInCreateApp", ["CommonApp"]);

    //控制器
    app.controller("BuiltInCreateController", function ($scope, service, commonService) {
        var height = $(document).height() - 65;
        $("#flowCanvas").css("height", height + "px");
        flowCreate.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory("service", ["$http", function ($http) {
        return {
            //获取流程
            getFlow: function (id) {
                return $http.post("/BuiltInFlow/GetById/" + id);
            },
            //保存流程数据
            saveFlow: function (postData) {
                return $http.post("/BuiltInFlow/SaveFlowData", postData);
            }
        }
    }]);

    var flowCreate = {
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        _this: null,
        _goo: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service;
            _commonService = commonService;
            _index = parent.layer.getFrameIndex(window.name);
            _this.AddEventListener();
        },

        AddEventListener: function () {
            var _this = this;
            //初始化
            _scope.onload = function (id) {
                _scope.id = id ? id : 0;
                // _goo = DesignFlow("property", 0, 0);
                _goo = EB.ISCS.Flow("property", 1, 0);
                _this.InitData(id ? id : 0);
            }
            //获取GooFlow Json数据
            $("#btn_save").click(function () {
                if (_goo.comFlowHasNode() > 0) {
                    var d = _goo.onExprotData();
                    var datas = {
                        Info: { Id: _scope.id, FlowDesign: JSON.stringify(d.data) },
                        List: d.list
                    };
                    _service.saveFlow(datas).success(function (result) {
                        if (result.Data == true) {
                            layer.msg("保存成功", { icon: 1 });
                            setTimeout(function () {
                                parent.layer.close(_index);
                            }, 1000);
                        } else {
                            layer.msg("发生了错误，请联系管理员", { icon: 5 });
                        }
                    });
                } else {
                    layer.msg("无数据，不可保存", { icon: 5 });
                }
            });

            //重做
            $("#btn_refresh").click(function () {
                var index = layer.confirm("确定要重新开始制作流程？", {
                    btn: ["确定", "点错了"] //按钮
                }, function () {
                    _goo.gooFlowClear();
                    layer.close(index);
                }, function () {
                    layer.close(index);
                });

            });


            $("#btn_pre").click(function () {
                var datas = _goo.onExprotData();
            });
        },
        InitData: function (id) {
            var _this = this;
            _service.getFlow(id).success(function (result) {
                if (result.Data.Info) {
                    _goo.onLoadData(result.Data.Info.FlowDesign, result.Data.List);
                }
            });
        }
    };
})();

