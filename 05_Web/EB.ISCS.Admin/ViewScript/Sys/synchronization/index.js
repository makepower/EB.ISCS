//模块: 同步配置管理
(function () {
    var app = angular.module('CfgApp', ['w5c.validator']);
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
                required: '周期不能为空'
            }
        });
    }]);

    app.controller('CfgController', function ($scope, service, $location) {
        $scope.onload = function (id) {
            init(id > 0 ? id : 0);
        }
        $scope.onSave = function () {
            var nodes = $('#shop-tree').tree('getChecked');
            var ids = new Array();
            for (var i = 0; i < nodes.length; i++) {
                var node = nodes[i];
                if (node.id > 0) {
                    ids.push(node.id);
                }
            }
            $scope.cfg.StoreIds = ids.join();
            save($scope.cfg);
        }
  
        //初始化
        function init(id) {
            $scope.icons = [
                { id: "0", name: "天" },
                { id: "1", name: "小时" }];
 
            $("#shop-tree").tree({
                url: "/Synchronization/GetSyncShopTree",
                lines: true,
                animate: true,
                checkbox: true
            });

            service.getCfg(0).success(function (result) {
                if (result.Code = 10000 && result.Data) {
                    $scope.cfg = result.Data;
                }
                else {
                    layer.msg(result.Message, { icon: 5 });
                }
            }).error(function (error) {
                layer.msg(result.Message, { icon: 5 });
            });
        }

        //保存数据
        function save(postData) {
            service.saveCfg(postData).success(function (result) {
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

    });

    app.factory('service', ['$http', function ($http) {

        var getCfg = function (id) {
            return $http.post('/Synchronization/GetConfig', {  });
        }
        var saveCfg = function (postData) {
            return $http.post('/Synchronization/SaveConfig', postData);
        }
        return {
            getCfg: function (id) {
                return getCfg(id);
            },
            saveCfg: function (postData) {
                return saveCfg(postData);
            }
        }

    }]);
})();