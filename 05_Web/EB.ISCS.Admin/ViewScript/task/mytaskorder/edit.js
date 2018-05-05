/*
工单新增修改
*/
(function () {
    var app = angular.module("MyTaskOrderEditApp", ["w5c.validator", "CommonApp"]);

    //控制器
    app.controller("MyTaskOrderEditController", function ($scope, service, commonService, $location) {
        formsManage.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory("service", ["$http", function ($http) {
        saveTaskInfo(postData) {
            return $http.post("/MyTaskOrder/SaveData", { 'info': postData });
        }
    }]);

    //用户管理
    var formsManage = {
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _service = service;
            _commonService = commonService;
            _scope.companys = [];
            _index = parent.layer.getFrameIndex(window.name);
            _this.AddEventListener();
        },
        //添加事件
        AddEventListener: function () {
            var _this = this;
            //初始化
            _scope.onload = function (id) {
                _this.InitData(id ? id : 0);
            }
            //点击保存
            _scope.onSave = function () {
                var t_id = comControl.comboxTree.getTreeValue("taskList");
                if (t_id && t_id > 0) {

                    parent.$("body").data("task_create_flow_id", t_id); /* 将任务模板编号传递给父页面 */
                    var postdata = { "TaskId": t_id };
                    _this.SaveData(postdata);
                } else {
                    layer.msg('请选择任务模板', { icon: 5 });
                }
            }
            //点击关闭
            _scope.onclose = function () {
                parent.layer.close(_index);
            }
        },
        //加载数据
        InitData: function (id) {
            var _this = this;
            comControl.dirGet.DicAllTree("dicTypeSelect", null, enumDicType.Business.ProgramType, _this.OnTypeChanged);

            comControl.taskGet.flowTaskList("taskList", null, null);

        },

        OnTypeChanged: function (row) {
            comControl.taskGet.flowTaskList("taskList", null, row.id, null);
        },

        SaveData: function (postData) {
            _service.saveTaskInfo(postData).success(function (result) {
                if (result.Code == 10000) {
                    parent.$("body").data("task_create_task_id", result.Data); /* 将任务id传递给父页面 */
                    layer.msg("创建成功", { icon: 1 });
                    setTimeout(function () {
                        parent.layer.close(_index);
                    }, 500);

                } else {
                    layer.msg(result.Message);
                }
            }).error(function (error) {
                layer.msg(error.Message, { icon: 5 });
            });
        }

    }
})();