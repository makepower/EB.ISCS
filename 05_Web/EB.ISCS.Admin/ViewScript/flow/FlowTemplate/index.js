/*
表单列表
*/
(function () {

    var app = angular.module("FlowApp", ["CommonApp"]);
    //控制器
    app.controller("FlowController", function ($scope, commonService) {
        flowList.InitializePage($scope, commonService);
    });

    //表格表头管理
    var flowList = {
        gridView: null,
        where: null,
        _scope: null,
        _commonService: null,
        InitializePage: function (scope, commonService) {
            var _this = this;
            _scope = scope;
            _commonService = commonService;
            gridView = $("#jqGrid");
            where = "";
            _this.InitData();
            _this.AddEventListener();
            //ZhiDun.setButtonPermission($("#MenuId").val());

        },
        //加载Grid
        InitGrid: function () {
            var _this = this;
            gridView.gvLoadGrid({
                gvHeadXml: "Forms\\流程管理",
                gvUrl: "/FlowTemplate/GetList",
                params: [],    //对应SQL语句参数，若无参数 则不写这个参数数组或者为空数组
                sqlWhere: where
            }, {
                    sortName: 'id',
                    sortOrder: 'desc',
                    idField: 'id',
                    height: 60,
                    showCheckbox: false,
                    pagination: true, //设置是否有分页
                    singleSelect: true, //设置是否为单选
                    pageSize: 15, //单页显示行数
                    pageList: [15, 40, 50], //下拉列表改变单页显示行数
                    onClickRow: function (index, row) {

                    },
                    onDblClickRow: function (index, row) {
                        // _this.showEdit(row.Id, '编辑员工信息');
                    }
                }
            );
        },
        InitData: function () {
            var _this = this;
            _this.InitGrid();
        },
        //添加事件
        AddEventListener: function () {
            var _this = this;
            _scope.add = function () {
            }

            $('#rulesTree').tree({
                url: "/FlowRules/GetRulesTree/1300",
                method: 'get',
                animate: true,
                lines: true,
                onClick: function (node) {
                    var search = "And RulesId=" + node.id;
                    gridView.gvRefreshGrid(search);
                }
            });

            //点击新增
            $('#btn_add').click(function () {
                _this.showEdit(0, "新建流程");
            });

            //点击编辑
            $('#btn_edit').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    _this.showEdit(row.Id, "编辑表头设计");
                }
            });

            $("#btn_flow").click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = $('#jqGrid').tgvGetSelectRow();
                    var url = "/FlowTemplate/Create?id=" + row.Id + "&pId=" + row.RulesId + "&_t=" + Math.random();
                    layer.open({
                        type: 2,
                        title: '流程设计器',
                        area: ['1500px', '750px'],
                        fix: false, //不固定
                        maxmin: true,
                        content: [url, 'no'],
                        end: function () {
                            gridView.gvRefreshGrid(where);
                        }
                    });
                } else {
                    layer.msg("请先选择行数据");
                }
            });

            //点击删除
            $("#btn_del").click(function () {
                gridView.tgvDeleteRows();
                var row = $('#jqGrid').tgvGetSelectRow();
                gridView.tgvDeleteRowsUrl("/TableTemplate/DelData/" + row.Id,// 删除url
                    function () {
                        gridView.gvRefreshGrid("");
                    }
                );
            });

            //点击打开查询窗口
            $("#btn_open_search").click(function () {
                layer.open({
                    title: "搜索",
                    type: 1,
                    area: ["600px", "200px"],
                    content: $("#divSerrch").removeAttr("style") //这里content是一个DOM
                });
            });

            //点击确认查询
            $("#btn_search").click(function () {
                var search = where;
                var EmployeeCode = $('#txt_EmployeeCode').val().trim();
                var FullName = $('#txt_FullName').val().trim();
                if (EmployeeCode) {
                    search += " AND EmployeeCode Like '%" + EmployeeCode + "%'";
                }
                if (FullName) {
                    search += " AND FullName Like '%" + FullName + "%'";
                }
                gridView.gvRefreshGrid(search);
                layer.closeAll();
            });

            //点击刷新
            $("#btn_refresh").click(function () {
                gridView.gvRefreshGrid(where);
            });

            $("#btn_tableDesign").click(function () {
                var row = gridView.tgvGetSelectRow();
                if (row.Id > 0) {
                    var _this = this;
                    var url = desginConfig.IframeUrlMap.buildTable + "?id=" + row.Id + "&_t=" + Math.random();
                    layer.open({
                        type: 2,
                        title: "表头设计",
                        area: ['1000px', '750px'],
                        fix: false, //不固定
                        maxmin: true,
                        content: [url, 'no'],
                        end: function () {
                            gridView.gvRefreshGrid(where);
                        }
                    });
                } else {
                    layer.msg("请先选择行!");
                }
            });
        },

        //弹出编辑窗口
        showEdit: function (id, title) {
            var _this = this;
            var url = "/FlowTemplate/Edit?id=" + id + "&_t=" + Math.random();
            id = id ? id : 0;
            layer.open({
                type: 2,
                title: title,
                area: ['1000px', '420px'],
                fix: false, //不固定
                maxmin: true,
                content: [url, 'no'],
                end: function () {
                    gridView.gvRefreshGrid(where);
                }
            });
        }
    }
})();
