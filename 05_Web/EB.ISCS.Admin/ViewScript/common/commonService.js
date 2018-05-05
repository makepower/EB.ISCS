/*
des: 注册公共服务接口
module:
*/
(function () {
    var app = angular.module('CommonApp', []);
    app.factory('commonService', ['$http', function ($http) {

        return {
            //根据SQl条件查询数据列表
            getDataList: function (query) {
                return $http.post('/Common/GetDataList', query);
            },
            //获取当前用户信息
            getCurrentUser: function () {
                return $http.post('/Common/GetCurrentUser');
            },
            //获取用户信息
            getUsers: function () {
                return $http.post('/Employee/GetEmployeeList');
            },
            //获取用户信息
            getDepartTree: function () {
                return $http.post('/Department/GetDepartmentTree');
            }
        }
    }]);
})();
