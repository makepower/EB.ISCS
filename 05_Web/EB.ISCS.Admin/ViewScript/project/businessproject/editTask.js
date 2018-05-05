
(function () {
    var app = angular.module("App", ["CommonApp"]);
    //注册服务
    app.factory("service", ["$http", function ($http) {
        return {
            //保存数据
            saveData: function (d) {
                console.info(d);
                //return $http.post("/BusinessProjectTask/AddEntities?id=" + d.id + "&flowRules=" + d.flowRules);
                return $http.post("/BusinessProjectTask/AddEntities", d);
            }
        }
    }]);
    var model = {
        gridView: null,
        where: null,
        _scope: null,
        _service: null,
        _commonService: null,
        //_index: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service;
            _commonService = commonService;
            gridView = $("#jqGrid");
            where = " and ProjectId=" + $("#hidId").val();
            //_index = parent.layer.getFrameIndex(window.name);
            _this.AddEventListener();
            _this.InitData();
            //ZhiDun.setButtonPermission($("#MenuId").val());
        },
        //加载Grid
        InitGrid: function () {
            var _this = this;
            gridView.gvLoadGrid({
                gvHeadXml: "Project\\项目任务管理",
                gvUrl: "/BusinessProjectTask/GetList",
                params: [], //对应SQL语句参数，若无参数 则不写这个参数数组或者为空数组
                sqlWhere: where
            },
                {
                    sortName: 'id',
                    sortOrder: 'desc',
                    idField: 'id',
                    height: 60,
                    showCheckbox: false,
                    pagination: true, //设置是否有分页
                    singleSelect: true, //设置是否为单选
                    pageSize: 15, //单页显示行数
                    pageList: [15, 40, 50] //下拉列表改变单页显示行数
                }
            );
        },
        InitData: function () {
            var _this = this;
            //获取参数
            _commonService.getDictionaryList(enumDicType.Business.ProgramType).success(function (result) {
                if (result.Data) {
                    _scope.ruleTypes = result.Data;
                }
            });
            _this.InitGrid();
        },
        //添加事件
        AddEventListener: function () {
            var _this = this;
            _scope.onload = function (id) {
                _scope.id = id ? id : 0;
                //console.info(_scope.id);
            };
            _scope.add = function () {
            };
            //点击新增
            $('#btn_add').click(function () {
                comControl.selectRules(function () {
                    var data = parent.$('body').data("body_select_rules");
                    if (data) {
                        //console.info(data);
                        //console.info(data.join(","));
                        //$.post({
                        //    url: "/BusinessProjectTask/AddEntities",
                        //    contentType:"application/json; charset=utf-8",
                        //    data: { id: _scope.id, flowRules: data.join(",") },
                        //    success: function (r) {
                        //        console.info(r);
                        //        gridView.gvRefreshGrid(where);
                        //    },
                        //    dataType: "json"
                        //});
                        _service.saveData({ id: _scope.id, flowRules: data.join(",") }).success(function (result) {
                            if (result.Code == 10000 && result.Data) {
                                layer.msg(result.Message, { icon: 1 });
                                //setTimeout(function () {
                                //    parent.layer.close(_index);
                                //}, 500);
                                gridView.gvRefreshGrid(where);
                            }
                            else {
                                layer.msg(result.Message, { icon: 5 });
                            }
                        }).error(function (error) {
                            layer.msg(result.Message, { icon: 5 });
                        });
                    }
                }, false, "");
            });

            //点击编辑
            $('#btn_edit_order').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    _this.showEdit(row.Id, "编辑程序信息");
                }
            });

            //点击删除
            $("#btn_del").click(function () {
                gridView.tgvDeleteRows();
                var row = $('#jqGrid').tgvGetSelectRow();
                gridView.tgvDeleteRowsUrl("/BusinessProjectTask/DelData/" + row.Id, // 删除url
                    function () {
                        gridView.gvRefreshGrid(where);
                    }
                );
            });

            //点击刷新
            $("#btn_refresh").click(function () {
                gridView.gvRefreshGrid(where);
            });
        },

        //弹出编辑窗口
        showEdit: function (id, title) {
            var _this = this;
            var url = "/BusinessProjectTask/Edit?id=" + id + "&_t=" + Math.random();
            id = id ? id : 0;
            parent.layer.open({
                type: 2,
                title: title,
                area: ['500px', '300px'],
                fix: false, //不固定
                maxmin: true,
                content: [url, 'no'],
                end: function () {
                    gridView.gvRefreshGrid(where);
                }
            });

            //parent.layer.open({
            //    type: 2,
            //    title: title,
            //    area: ['600px', '400px'],
            //    fix: false, //不固定
            //    maxmin: true,
            //    zIndex: 20161010,
            //    content: [url, 'no'],
            //    end: function () {
            //        if (callback && $.isFunction(callback)) {
            //            callback();
            //        }
            //    }
            //});
        }
    };

    //控制器
    app.controller("Controller", function ($scope, service, commonService) {
        model.InitializePage($scope, service, commonService);
    });

})();
