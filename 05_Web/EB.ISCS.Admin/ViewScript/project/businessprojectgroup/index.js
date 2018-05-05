/*
项目列表
*/
(function () {

    var app = angular.module("ListApp", ["CommonApp"]);
    //控制器
    app.controller("ListController", function ($scope, commonService) {
        projectList.InitializePage($scope, commonService);
    });

    //项目列表管理
    var projectList = {
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
                gvHeadXml: "Project\\项目组管理",
                gvUrl: "/BusinessProjectGroup/GetList",
                params: [],    //对应SQL语句参数，若无参数 则不写这个参数数组或者为空数组
                sqlWhere: where
            }, {
                    sortName: 'Id',
                    sortOrder: 'desc',
                    idField: 'Id',
                    height: 60,
                    showCheckbox: false,
                    pagination: true, //设置是否有分页
                    singleSelect: true, //设置是否为单选
                    pageSize: 15, //单页显示行数
                    pageList: [15, 40, 50], //下拉列表改变单页显示行数
                    onClickRow: function (index, row) {

                    },
                    onDblClickRow: function (index, row) {
                        // _this.showEdit(row.Id, '编辑信息');
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
            //点击新增
            $('#btn_add').click(function () {
                _this.showEdit(0, "新增项目组");
            });

            //点击编辑
            $('#btn_edit').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    _this.showEdit(row.Id, "编辑项目组");
                }
            });

            //点击删除
            $("#btn_del").click(function () {
                //gridView.tgvDeleteRows();
                var row = $('#jqGrid').tgvGetSelectRow();
                gridView.tgvDeleteRowsUrl(
                    "/BusinessProjectGroup/DelData/" + row.Id,// 删除url
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

            $('#projectTree').tree({
                url: "/BusinessProject/GetProjectTree",
                animate: true,
                lines: true,
                onClick: function (node) {
                    var search = "And ProjectId=" + node.id;
                    gridView.gvRefreshGrid(search);
                }
            });
        },

        //弹出编辑窗口
        showEdit: function (id, title) {
            var _this = this;
            var url = "/BusinessProjectGroup/Edit?id=" + id + "&_t=" + Math.random();
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
