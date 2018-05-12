/*
功能模块管理列表
*/
(function () {
    $(function () {
        menu.InitializePage();
    });
    var menu = {
        gridView: null,
        InitializePage: function () {
            var _this = this;
            gridView = $("#jqGrid");
            _this.InitGrid();
            _this.AddEventListener();
            //ZhiDun.setButtonPermission($("#MenuId").val());
        },
        //加载Grid
        InitGrid: function () {
            var _this = this;
            gridView.tgvLoadTreeGrid({
                gvHeadXml: "Sys\\功能模块",
                gvUrl: "/Menu/GetList",
                params: [],    //对应SQL语句参数，若无参数 则不写这个参数数组或者为空数组
                sqlWhere: ""
            }, {
                    sortable: false,
                    sortName: 'Id',
                    sortOrder: 'desc',
                    idField: 'Id',
                    height: 60,
                    pagination: false,    //设置是否有分页
                    singleSelect: true,  //设置是否为单选
                    treeField: 'MenuName',
                    onDblClickRow: function (row) {
                        _this.showEdit(row.Id, '编辑数据字典信息', 'edit');
                    }
                });
        },

        AddEventListener: function () {
            var _this = this;
            $('#btn_add').click(function () {
                _this.showEdit(0, '新增 - 功能模块 （菜单)', 'add');
            });
            $('#btn_edit').click(function () {
                if (gridView.tgvIsSelectRow()) {
                    var row = gridView.tgvGetSelectRow();
                    _this.showEdit(row.Id, '编辑 - 功能模块 （菜单)', 'edit');
                }
            });
            $("#btn_del").click(function () {
                gridView.tgvDeleteRowsUrl("/Menu/DeleteSysMenus",// 删除url
                    function () {
                        gridView.tgvRefreshGrid("");
                    }); // 删除记录后，刷新数据需要的查询条件
                // gridView.tgvDeleteRows();
            });

            $("#btn_refresh").click(function () {
                gridView.tgvRefreshGrid("");
            });
        },

        //弹出编辑窗口
        showEdit: function (id, title, actionType) {
            var _this = this;
            var url = "/Menu/Edit?id=" + id + "&actionType=" + actionType + "&_t=" + Math.random();
            id = id ? id : 0;
            layer.open({
                type: 2,
                title: title,
                area: ['1000px', '510px'],
                fix: false, //不固定
                maxmin: true,
                content: [url, 'no'],
                end: function () {
                    _this.InitGrid();
                }
            });
        }
    }
})();
