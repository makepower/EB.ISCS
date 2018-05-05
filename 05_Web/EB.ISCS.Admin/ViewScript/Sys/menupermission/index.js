//模块: 系统操作按钮管理
(function () {
    $(function () {
        dictionaryList.InitializePage();
    });

    //数据字典列表管理
    var dictionaryList = {
        gridView: null,
        InitializePage: function () {
            var _this = this;
            gridView = $("#jqGrid");
            _this.InitGrid(0);
            _this.AddEventListener();
            //ZhiDun.setButtonPermission($("#MenuId").val());
        },
        //加载Grid
        InitGrid: function (id) {
            var _this = this;
            if (id > 0) {
                gridView.gvLoadGrid({
                    gvHeadXml: "Sys\\权限管理",
                    gvUrl: '/MenuPermission/GetMenuPermissionListPage/' + id,
                    params: [],  
                    sqlWhere: ""
                }, {
                    sortName: 'id',
                    sortOrder: 'desc',
                    idField: 'id',
                    height: 60,
                    showCheckbox: false,
                    pagination: false,    //设置是否有分页
                    singleSelect: true,  //设置是否为单选
                    pageSize: 15,   //单页显示行数
                    pageList: [15, 40, 50],  //下拉列表改变单页显示行数
                    onClickRow: function (index, row) {

                    },
                    onDblClickRow: function (index, row) {
                        _this.showEdit(row.Id, '编辑 - 功能操作');
                    }
                });
            }
        },

        //添加事件
        AddEventListener: function () {
            var _this = this;
            //点击添加
            $('#btn_add').click(function () {
                if (!$("#ModuleId").val()) {
                    layer.msg("请选择功能模块！");
                    return false;
                }
                _this.showEdit(0, '新增 - 功能操作');
            });

            //点击编辑
            $('#btn_edit').click(function () {
                if (gridView.gvIsSelectRow()) {
                    var row = gridView.gvGetSelectRow();
                    _this.showEdit(row.Id, '编辑 - 功能操作');
                }
            });

            //点击删除
            $("#btn_del").click(function () {
                gridView.gvDeleteRows("DeleteSysMenuPermission", "");
            });

            //点击搜索
            $("#btn_open_search").click(function () {
                layer.open({
                    title: '搜索',
                    type: 1,
                    area: ['600px', '200px'],
                    content: $('#divSerrch').removeAttr("style") //这里content是一个DOM
                });
            });

            //点击刷新
            $("#btn_refresh").click(function () {
                gridView.gvRefreshGrid(" AND MenuId=" + $("#ModuleId").val());
            });

            $('#menuTree').tree({
                url: "/MenuPermission/GetMenuTree",
                method: 'get',
                animate: true,
                lines: true,
                onClick: function (node) {
                    $("#ModuleId").val(node.id);
                    _this.InitGrid(node.id);
                }
            });
        },

        //弹出编辑窗口
        showEdit: function (id, title) {
            var _this = this;
            id = id ? id : 0;
            var url = "/MenuPermission/edit?id=" + id + "&_t=" + Math.random();
            layer.open({
                type: 2,
                title: title,
                area: ['1000px', '450px'],
                fix: false, //不固定
                maxmin: true,
                content: [url, 'no'],
                end: function () {
                    gridView.gvRefreshGrid(" AND MenuId=" + $("#ModuleId").val());
                }
            });
        }
    }



})();