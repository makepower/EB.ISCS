(function () {
    var parentId = ""; var theLevel = 0;

    var app = angular.module('MenuPermissionApp', ['w5c.validator']);
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
            ActionName: {
                required: '操作名称不能为空'
            },
            ActionCode: {
                required: '操作按钮不能为空'
            }
        });
    }]);
    app.controller('MenuPermissionController', function ($scope, service, $location) {
        $scope.onload = function (id) {
            init(id ? id : 0);
        }
        var index = parent.layer.getFrameIndex(window.name);
        //init($('#hidn_id').val());
        $scope.onSave = function () {
            save($scope.menuPermission);
        }
        $scope.onclose = function () {
            parent.layer.close(index);
        }
        //初始化
        function init(id) {
            service.getMenuPermission(id)
                .success(function (result) {
                    $scope.menuPermission = result.Data;
                    console.log($scope.menuPermission);
                })
                .error(function (error) {
                    $scope.menuPermission = 'Unable to load customer data: ' + error.Message;
                    console.log($scope.menuPermission);
                });
        }

        //保存数据
        function save(postData) {
            postData.MenuId = $(window.parent.document).find("#ModuleId").val();
            service.saveMenuPermission(postData)
                .success(function (result) {
                    layer.msg(result.Message, { icon: 1 });
                    setTimeout(function () {
                        parent.layer.close(index);
                    }, 500);
                })
                .error(function (error) {
                    layer.msg(error.Message, { icon: 5 });
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

        var getMenuPermission = function (id) {
            return $http.post('/MenuPermission/GetMenuPermission', { 'Id': id });
        }
        var saveMenuPermission = function (postData) {
            return $http.post('/MenuPermission/SaveMenuPermission', postData);
        }
        return {
            getMenuPermission: function (id) {
                return getMenuPermission(id);
            },
            saveMenuPermission: function (postData) {
                return saveMenuPermission(postData);
            }

        }

    }]);
})();