(function () {
    var app = angular.module('MenuApp', ['w5c.validator']);
    //全局配置
    app.config(["w5cValidatorProvider", function (w5cValidatorProvider) {
        // 验证规则
        w5cValidatorProvider.config({
            blurTrig: false, //是否失去焦点时触发
            showError: true, //显示错误
            removeError: true //移除错误
        });
        //提示信息
        w5cValidatorProvider.setRules({
            MenuName: {
                required: '模块名称不能为空'
            }
        });
    }]);

    app.controller('MenuController', function ($scope, service, $location) {
        $scope.onload = function (actionType, id) {
            init(actionType, id > 0 ? id : 0);
        }
        var index = parent.layer.getFrameIndex(window.name);
        $scope.onSave = function () {
            $scope.menu.Id = $scope.menu.Id;
            var selectNode = $("#selMenuFrom").combotree('tree').tree('getSelected'); // 得到树对象  
            if (selectNode) {
                $scope.menu.FatherId = selectNode.id;
            }
            else {
                layer.msg("请选择父级模块！");
                return false;
            }
            save($scope.menu);
        }

        $scope.onclose = function () {
            parent.layer.close(index);
        }

        //加载部门树
        function initTree(fatherId, id) {
            angular.element('#selMenuFrom').combotree({
                url: '/Menu/GetMenuTree',
                valueField: 'id',
                textField: 'text',
                required: false,
                editable: false,
                onClick: function (node) {
                    if (node.id == id && id != 0) {
                        layer.msg("不能选择自己为父模块！");
                        return false;
                    }
                }, //全部折叠
                onLoadSuccess: function (node, data) {
                    angular.element('#selMenuFrom').combotree('setValue', fatherId);
                }
            });
        }

        //初始化
        function init(actionType, id) {
            $scope.icons = [
                { id: "fa fa-th", name: "fa fa-th" },
                { id: "fa fa-book", name: "fa fa-book" },
                { id: "fa fa-edit", name: "fa fa-edit" },
                { id: "fa fa-table", name: "fa fa-table" },
                { id: "fa fa-laptop", name: "fa fa-laptop" },
                { id: "fa fa-files-o", name: "fa fa-files-o" },
                { id: "fa fa-envelope", name: "fa fa-envelope" },
                { id: "fa fa-calendar", name: "fa fa-calendar" },
                { id: "fa fa-circle-o", name: "fa fa-circle-o" },
                { id: "fa fa-pie-chart", name: "fa fa-pie-chart" },
                { id: "fa fa-dashboard", name: "fa fa-dashboard" }];
            if (actionType)
                $("#ActionType").val(actionType);
            service.getMenuInfo(id).success(function (result) {
                $scope.menu = result.Data;
                $scope.menu.MenuState = 1;
                $scope.menu.ActionType = actionType;
                initTree($scope.menu.FatherId, id);
            }).error(function (error) {
                console.log(error.Message);
            });
        }

        //保存数据
        function save(postData) {
            service.saveMenuInfo(postData).success(function (result) {
                if (result.Code = 10000 && result.Data) {
                    layer.msg(result.Message, { icon: 1 });
                    setTimeout(function () {
                        parent.layer.close(index);
                    }, 500);
                }
                else {
                    layer.msg(result.Message, { icon: 5 });
                }
            }).error(function (error) {
                layer.msg(result.Message, { icon: 5 });
            });
        }

        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]);
            return null;
        }

    });

    app.factory('service', ['$http', function ($http) {

        var getMenuInfo = function (id) {
            return $http.post('/Menu/GetMenuInfo', { 'Id': id });
        }
        var saveMenuInfo = function (postData) {
            return $http.post('/Menu/SaveMenuInfo', postData);
        }
        return {
            getMenuInfo: function (id) {
                return getMenuInfo(id);
            },
            saveMenuInfo: function (postData) {
                return saveMenuInfo(postData);
            }
        }

    }]);
})();