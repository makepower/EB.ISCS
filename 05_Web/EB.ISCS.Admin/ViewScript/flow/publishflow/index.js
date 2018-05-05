/*表单列表*/
(function () {

    var app = angular.module('PublishFlowListApp', ['CommonApp']);

    //人员管理
    var employeeList = {
        gridView: null,
        where: null,
        _scope: null,
        _commonService: null,
        _service: null,
        _selectRow:null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _commonService = commonService;
            _service = service;
            gridView = $("#jqGrid");
            where = "";
            _this.InitData();
            _this.AddEventListener();
            _scope.visable = true;
            //ZhiDun.setButtonPermission($("#MenuId").val());
            comControl.dirGet.DicAllTree('dicTypeSelect', null, enumDicType.Business.ProgramType);
        },
        //加载Grid
        InitGrid: function () {
            var _this = this;
            gridView.gvLoadGrid({
                gvHeadXml: "Task\\单线任务管理",
                gvUrl: "/PublishFlow/GetList",
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
                        if (row.Status == 4) {
                            document.getElementById("btn_edit").innerHTML = '撤销发布';
                        }
                        else {
                            document.getElementById("btn_edit").innerHTML ='发布';
                        }
                    },
                    onDblClickRow: function (index, row) {
                        // _this.showEdit(row.Id, '编辑表单信息');
                    }
                });
        },
        InitData: function () {
            var _this = this;
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
            //点击编辑
            $('#btn_edit').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    _selectRow = row;
                    _service.changeStatus(row).success(function (result) {
                        if (result.Code === 10000 && result.Data) {
                            layer.msg(result.Message, { icon: 1 });
                            setTimeout(function () {
                                gridView.gvRefreshGrid(where);
                                if (_selectRow != null) {
                                    if (row.Status == 4) {
                                        document.getElementById("btn_edit").innerHTML = '撤销发布';
                                    }
                                    else {
                                        document.getElementById("btn_edit").innerHTML = '发布';
                                    }
                                }
                            }, 500);
                        }
                        else {
                            layer.msg(result.Message, { icon: 5 });
                        }
                    }).error(function (error) {
                        layer.msg(result.Message, { icon: 5 });
                    });;
                }
            });

            //点击刷新
            $("#btn_refresh").click(function () {
                gridView.gvRefreshGrid(where);
            });

        }

    }

    //控制器
    app.controller("PublishFlowListController", function ($scope, service, commonService) {
        employeeList.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory("service", ["$http", function ($http) {
        return {
            //修改状态
            changeStatus: function (postData) {
                return $http.post("/PublishFlow/ChangeFlowState", postData);
            }
        }
    }]);
})();

