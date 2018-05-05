/*表单列表*/
(function () {

    var app = angular.module('TaskSingleListApp', ['CommonApp']);

    //人员管理
    var employeeList = {
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
                gvHeadXml: "Task\\单线任务管理",
                gvUrl: "/TaskSingleInfo/PageList",
                params: [],    //对应SQL语句参数，若无参数 则不写这个参数数组或者为空数组
                sqlWhere: where
            }, {
                    sortName: 'id',
                    sortOrder: 'desc',
                    idField: 'id',
                    height: 60,
                    showCheckbox: false,
                    pagination: true,    //设置是否有分页
                    singleSelect: true,  //设置是否为单选
                    pageSize: 15,   //单页显示行数
                    pageList: [15, 40, 50],  //下拉列表改变单页显示行数
                    onClickRow: function (index, row) {

                    },
                    onDblClickRow: function (index, row) {
                        // _this.showEdit(row.Id, '编辑表单信息');
                    }
                });
        },
        InitData: function () {
            var _this = this;
            comControl.dirGet.DicAllTree('dicTypeSelect', null, enumDicType.Business.ProgramType);
            _commonService.getCurrentUser().success(function (result) {
                _scope.userIsManage = result.UserIsManage;
                if (result.UserIsManage != 1) {
                    where += " ";
                }
                _this.InitGrid();
            });
        },
        //添加事件
        AddEventListener: function () {
            var _this = this;
            _scope.onload = function (id) {
                _this.InitData(id ? id : 0);
            }
            //点击新增
            $('#btn_add').click(function () {
                _this.showEdit(0, '新增表单信息');
            });

            //点击编辑
            $('#btn_edit').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    _this.showEdit(row.Id, '编辑表单信息');
                }
            });

            //点击删除
            $("#btn_del").click(function () {
                var row = $('#jqGrid').tgvGetSelectRow();
                if (row.Id) {
                    $.post("/DiscreteTask/FormDelete/" + row.Id, function (result) {
                        if (result.Code == 10000) {
                            layer.msg("删除成功");
                            _this.InitGrid();
                        } else {
                            layer.msg(result.Message);
                        }
                    });
                }
            });

            //打开表单创建
            $("#btn_createform").click(function () {
                var he = $(".wrapper").height();
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    comControl.openTabpage("TaskSingleInfo/CreateForm/" + row.Id, "编辑【" + row.Name + "】表单");
                    //var layerFr = layer.open({
                    //    type: 2,
                    //    title: "任务模板 【 " + row.Name + " 】编辑",
                    //    shadeClose: true,
                    //    move: false,
                    //    maxmin: false, //开启最大化最小化按钮
                    //    area: ["1100px", he + "px"],
                    //    content: ["/TaskSingleInfo/CreateForm/" + row.Id, "no"]
                    //});
                    //layer.full(layerFr);
                }
            });
            //打开表单创建
            $("#btn_createflow").click(function () {
                var he = $(".wrapper").height();
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    comControl.openTabpage("TaskSingleInfo/CreateFlow/" + row.Id, "编辑【" + row.Name + "】流程");
                    //var layerFr = layer.open({
                    //    type: 2,
                    //    title: "任务模板 【 " + row.Name + " 】编辑",
                    //    shadeClose: true,
                    //    move: false,
                    //    maxmin: false, //开启最大化最小化按钮
                    //    area: ["1100px", he + "px"],
                    //    content: ["/TaskSingleInfo/CreateFlow/" + row.Id, "no"]
                    //});
                    //layer.full(layerFr);
                }
            });

            //点击刷新
            $("#btn_refresh").click(function () {
                gridView.gvRefreshGrid(where);
            });

            $('#rulesTree').tree({
                url: "/DiscreteTask/GetRulesTree/1300",
                method: 'get',
                animate: true,
                lines: true,
                onClick: function (node) {
                    var search = "And RulesId=" + node.id;
                    gridView.gvRefreshGrid(search);
                }
            });
        },

        //弹出编辑窗口
        showEdit: function (id, title) {
            var _this = this;
            var url = "/TaskSingleInfo/Edit?id=" + id + "&_t=" + Math.random();
            id = id ? id : 0;
            layer.open({
                type: 2,
                title: title,
                area: ['1000px', '490px'],
                fix: false, //不固定
                maxmin: true,
                content: [url, 'no'],
                end: function () {
                    gridView.gvRefreshGrid(where);
                }
            });
        }
    }

    //控制器
    app.controller("TaskSingleListController", function ($scope, commonService) {
        employeeList.InitializePage($scope, commonService);
    });
})();

