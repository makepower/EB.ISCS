/*
表单列表
*/
(function () {

    var app = angular.module("BuiltInApp", ["CommonApp"]);
    //控制器
    app.controller("BuiltInController", function ($scope, commonService) {
        builtIn.InitializePage($scope, commonService);
    });

    //表格表头管理
    var builtIn = {
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
                gvHeadXml: "Forms\\系统流程管理",
                gvUrl: "/BuiltInFlow/GetList",
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
            comControl.dirGet.DicTree('dicTypeSelect', null, enumDicType.Business.BuiltInType);

            //点击新增
            $('#btn_add').click(function () {
                _this.showEdit(0, "新建系统内置流程");
            });

            //点击编辑
            $('#btn_edit').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    _this.showEdit(row.Id, "编辑系统内置流程");
                }
            });

            $("#dicTypeSelect").combotree({
                onSelect: function (node) {
                    var search = where;
                    search += " AND DicTypeId =" + node.id;
                    gridView.gvRefreshGrid(search);
                }
            });

            $("#btn_flow").click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = $('#jqGrid').tgvGetSelectRow();
                    var url = "/BuiltInFlow/Create?id=" + row.Id +  "&_t=" + Math.random();
                    layer.open({
                        type: 2,
                        title: '系统内置流程设计器',
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
                gridView.tgvDeleteRowsUrl("/BuiltInFlow/DelData/" + row.Id,// 删除url
                    function () {
                        gridView.gvRefreshGrid("");
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
            var url = "/BuiltInFlow/Edit?id=" + id + "&_t=" + Math.random();
            id = id ? id : 0;
            layer.open({
                type: 2,
                title: title,
                area: ['1000px', '340px'],
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
