/*
 用户分配权限
*/
(function () {
    $(function () {
        var treeId = "menu-tree";
        var allPermissionActionUrl = "/User/GetUserMenuById";
        var saveRoleMenuPermissionActionUrl = "/User/SaveUserMenuPermissions";
        rolePermission.InitializePage(treeId, allPermissionActionUrl, saveRoleMenuPermissionActionUrl);
    });
    //用户权限
    var rolePermission = {
        treeId: null,
        actionUrl: null,
        saveUrl: null,
        index: parent.layer.getFrameIndex(window.name),

        //初始化
        InitializePage: function (id, url, saveUrl) {
            var _this = this;
            _this.treeId = id;
            _this.actionUrl = url;
            _this.saveUrl = saveUrl;
            _this.loadTree();
            _this.AddEventListener();
        },

        //添加事件
        AddEventListener: function () {
            var _this = this;
            $("#btn_save_permission").click(function () {
                _this.assignRoleMenuPermission();
            });
        },

        //加载树
        loadTree: function () {
            var _this = this;
            var userId = $("#UserId").val();
            $("#" + _this.treeId).tree({
                url: _this.actionUrl,
                lines: true,
                animate: true,
                checkbox: true
            });
        },
        //转换成树结构数据
        convertTreeData: function (rows) {
            var nodes = [];
            for (var i = 0; i < rows.length; i++) {
                var row = rows[i];
                nodes.push({
                    id: row.Id,  // 这里绑定你的字段
                    text: row.Title, // 这里绑定你的字段
                    //state:row.State,// 这里绑定你的字段
                    children: function () {
                        if (row.Children)
                            return _this.convertTreeData(row.Children);
                    },
                    checked: row.Checked// 这里绑定你的字段
                    //attributes:row.attributes // 这里绑定你的字段
                });
            }
            return nodes;
        },

        //获取设置权限并保存
        assignRoleMenuPermission: function () {
            var userId = $("#UserId").val();
            var inUser = $('#InUser').val();
            var userMenus = new Array();
            var userActions = new Array();
            var _this = this;
            var nodes = $('#' + _this.treeId).tree('getChecked', 'indeterminate');
            var nodes1 = $('#' + _this.treeId).tree('getChecked');

            for (var i = 0; i < nodes.length; i++) {
                var node = nodes[i];
                if (node.attributes.isMenu) {
                    userMenus.push({
                        UserId: userId,
                        MenuId: node.id,
                        MenuName: node.text,
                        InUser: inUser,
                        CheckBoxState: 0
                    });
                }
                else {
                    userActions.push({
                        UserId: userId,
                        MenuActionId: node.id,
                        MenuId: $('#' + _this.treeId).tree('getParent', node.target).id,
                        ActionName: node.text,
                        InUser: inUser,
                        CheckBoxState: 0
                    });
                }
            }
            for (var i = 0; i < nodes1.length; i++) {
                var node1 = nodes1[i];
                if (node1.attributes.isMenu) {
                    userMenus.push({
                        UserId: userId,
                        MenuId: node1.id,
                        MenuName: node1.text,
                        InUser: inUser,
                        CheckBoxState: 1
                    });
                }
                else {
                    userActions.push({
                        UserId: userId,
                        MenuActionId: node1.id,
                        MenuId: $('#' + _this.treeId).tree('getParent', node1.target).id,
                        ActionName: node1.text,
                        InUser: inUser,
                        CheckBoxState: 1
                    });
                }
            }

            var postData = {
                "UserMenuViewModel": userMenus,
                "UserPermissionViewModel": userActions
            };

            $.ajax({
                url: _this.saveUrl,
                data: postData,
                type: "post",
                success: function (data) {
                    var json = JSON.parse(data);
                    if (json.Code == 10000 && json.Data) {
                        layer.msg("分配用户权限成功！", { icon: 1 });
                        setTimeout(function () {
                            parent.layer.close(_this.index);
                        }, 500);
                    } else {
                        layer.msg("分配用户权限失败！", { icon: 5 });
                    }
                },
                error: function () {
                    layer.msg("分配用户权限失败！", { icon: 5 });
                }
            });

            console.info(userMenus);
            console.info(userActions);
        },

    }
})();