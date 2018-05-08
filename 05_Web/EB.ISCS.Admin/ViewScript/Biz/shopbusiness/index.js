/*
 店铺管理列表
*/
(function () {

    var app = angular.module('ShopApp', ['CommonApp']);
    //控制器
    app.controller('ShopController', function ($scope, service, commonService) {
        shopManager.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory('service', ['$http', function ($http) {
        return {
            //删除节点
            deleteShop: function (id) {
                return $http.post('/ShopBusiness/DelShop', { 'Id': id });
            }
        }
    }]);

    //用户管理
    var shopManager = {
        _searchcondition: null,
        gridView: null,
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        where: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _scope.companys = [];
            _service = service;
            _commonService = commonService,
                gridView = $("#jqGrid");
            where = " ";
            _this.InitData();
            _this.AddEventListener();
        },

        InitData: function () {
            var _this = this;
            _this.InitGrid();
        },
        //加载Grid
        InitGrid: function () {
            var _this = this;
            gridView.gvLoadGrid({
                gvHeadXml: "Biz\\店铺信息管理",
                gvUrl: '/ShopBusiness/GetShopListByQuery',
                params: [],    //对应SQL语句参数，若无参数 则不写这个参数数组或者为空数组
                sqlWhere: where
            }, {
                    lines: true,
                    sortName: 'id',
                    sortOrder: 'desc',
                    idField: 'id',
                    customsort: false,
                    height: 60,
                    showCheckbox: false,
                    pagination: true,    //设置是否有分页
                    singleSelect: true,  //设置是否为单选
                    pageSize: 15,   //单页显示行数
                    pageList: [15, 40, 50],  //下拉列表改变单页显示行数
                    onClickRow: function (index, row) {

                    },
                    onDblClickRow: function (index, row) {
                        _this.showEdit(row.Id, '编辑店铺信息');
                    }
                });

            //comControl.postWithDepartmentTree("SelectPost", null);
        },

        //添加事件
        AddEventListener: function () {
            var _this = this;

            //点击新增
            $('#btn_add').click(function () {
                _this.showEdit(0, '编辑店铺信息');
            });

            //点击编辑
            $('#btn_edit').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    _this.showEdit(row.Id, '编辑店铺信息');
                }
            });

            //点击删除
            $("#btn_del").click(function () {
                var row = gridView.tgvGetSelectRow();
                if (row && row.Id) {
                    layer.confirm('确认要删除选择的数据吗？',
                        {
                            time: 20000,
                            btn: ['确定', '取消']
                        },
                        function () {
                            _service.deleteShop(row.Id).success(function (result) {
                                if (result.Code == 10000) {
                                    layer.msg("删除成功");
                                    _this.InitGrid();
                                } else {
                                    layer.msg(result.Message);
                                }
                            });
                        },
                        function () {
                        });
                }
                else {
                    layer.msg("请选择要删除的数据");
                }
            });


            //点击刷新
            $("#btn_refresh").click(function () {
                gridView.gvRefreshGrid(where);
            });
        },

        //弹出编辑窗口
        showEdit: function (id, title) {
            var _this = this;
            var url = "/ShopBusiness/Edit?id=" + id + "&_t=" + Math.random();
            id = id ? id : 0;
            layer.open({
                type: 2,
                title: title,
                area: ['1000px', '460px'],
                fix: true, //不固定
                scrollbar: false,
                maxmin: true,
                content: [url, 'no'],
                end: function () {
                    gridView.gvRefreshGrid(where);
                }
            });
        }

    }
})();
