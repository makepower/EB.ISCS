
(function () {
    var app = angular.module("FormPartChoiceApp", ["CommonApp"]);

    //控制器
    app.controller("FormPartChoiceController", function ($scope, service, commonService) {
        flowCreate.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory('service', ['$http', function ($http) {
        return {
            //获取单线任务表单
            getTaskForm: function (id) {
                return $http.post("/TaskSingleInfo/GetById/" + id);
            }
        }
    }]);

    var flowCreate = {
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        _this: null,
        _select: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service;
            _select = "";
            _commonService = commonService;
            _index = parent.layer.getFrameIndex(window.name);
            _this.AddEventListener();
        },

        AddEventListener: function () {
            var _this = this;
            //初始化
            _scope.onload = function (id, pid) {
                _scope.id = id ? id : 0;
                _this.InitData(id ? id : 0);
            }

            $("#btn_conform").click(function () {
                var s = _select.substring(0, _select.length - 1);
                parent.$("body").data("formChoicePart_20180411", s);
                parent.layer.close(_index);
            });

            $("#btn_cancel").click(function () {
                parent.layer.close(_index);
            });

            //f作为，选择器过滤
            var f = "#P1,#P2";
            $("#preViewDiv").selectable({
                filter: ".form-group",
                stop: function () {
                    $(".ui-selected", this).each(function () {
                        // var index = $("#preViewDiv .form-group").index(this);
                        var index = $(this).attr("id");
                        _select += index + ",";
                    });
                }
            });
        },
        InitData: function (id) {
            var _this = this;
            _service.getTaskForm(id).success(function (result) {
                if (result.Data.FormDesign) {
                    var e = new EB.ISCSPreView(JSON.parse(result.Data.FormDesign));
                }
            });
        }
    };
})();

