/*
工单新增修改
*/
(function () {
    var app = angular.module("NewTaskEditApp", ["w5c.validator", "CommonApp"]);
    //控制器
    app.controller("NewTaskEditController", function ($scope, service, commonService, $location) {
        formsManage.InitializePage($scope, service, commonService);
    });

    //注册服务
    app.factory("service", ["$http", function ($http) {
        return {
            //获取模板信息{ 'Id': id, "editType": editType }
            getTaskInfo: function (id) {
                return $http.post("/MyTaskOrder/GetTaskBaseInfo?id=" + id, null);
            },
            saveTaskExecInfo(postData) {
                return $http.post("/MyTaskOrder/SaveExecData", { 'info': postData });
            }
        }
    }]);

    //管理
    var formsManage = {
        _service: null,
        _scope: null,
        _commonService: null,
        _index: null,
        InitializePage: function (scope, service, commonService) {
            var _this = this;
            _scope = scope;
            _scope.SelfProcessing = false;
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
            _scope.onload = function (id, editType) {
                _this.InitData(id ? id : 0, editType ? editType : 0);
            }
            //点击保存
            _scope.onSave = function () {
                //parent.$("body").data("task_create_task_id", comControl.comboxTree.getTreeValue("taskList")); /* 将任务模板编号传递给父页面 */
                _this.SaveData(_scope.flowInfo)
            }
            //点击关闭
            _scope.onclose = function () {
                parent.layer.close(_index);
            }
            _scope.onSelectElp = function () {
                //选择用户
                comControl.selectEmployee(function () {
                    var data = parent.$('body').data("dataUser");
                    if (data) {
                        _scope.flowInfo.ExecutorData = JSON.stringify({ "username": data.Name, "userId:": data.Id });
                        _scope.UserName = data.Name;
                        _scope.$apply();
                    }
                }, true, "");
            }
        },
        //加载数据
        InitData: function (id, editType) {
            this.regControl();
            var _this = this;
            _service.getTaskInfo(id).success(function (result) {
                _scope.flowInfo = result.Data.TaskInstanceInfo;
                var execData = '';
                if (_scope.flowInfo.Id > 0) {
                    execData = result.Data.TaskInstanceInfo.ExecutorData;
                } else {
                    execData = result.Data.FlowInfo.FlowFromInfo;
                }
                if (result.Data.FlowInfo.ExecType == 0) {
                    _this.SetFormStyleSheet();
                    _scope.SelfProcessing = true;
                    // 自理型
                    var e = new EB.ISCSPreView(JSON.parse(execData));
            
                } else if (result.Data.FlowInfo.ExecType == 1) {
                    // 指派型
                    var json = JSON.parse(execData);
                    _scope.UserName = json.username;
                    _scope.SelfProcessing = false;
                }

            }).error(function (error) {
                layer.msg(error.Message, { icon: 5 });
            });
        },
        SetFormStyleSheet: function () {
            // 找到head
            var doc_head = document.head;
            // 找到所有的link标签
            var link_list = document.getElementsByTagName("link");
            if (link_list) {
                for (var i = 0; i < link_list.length; i++) {
                    // 找到我们需要替换的link，
                    // 一般情况下有些样式是公共样式，我们可以写到功能样式文件中，不用来做替换；
                    // 这样可以避免每次替换的时候样式文件都很大；可以节省加载速度；
                    if (link_list[i].getAttribute("ty") === "theme") {
                        // 找到后将这个link标签重head中移除
                        doc_head.removeChild(link_list[i]);
                    }
                }
            }
            var title = "../Scripts/EB.ISCSDesigner/forms/css/EB.ISCS.designpreview.css";
            // 创建一个新link标签
            var link_style = document.createElement("link");
            // 对link标签中的属性赋值
            link_style.setAttribute("rel", "stylesheet");
            link_style.setAttribute("type", "text/css");
            link_style.setAttribute("href", title);
            link_style.setAttribute("ty", "theme");
            // 加载到head中最后的位置
            doc_head.appendChild(link_style);
        },
        //保存数据
        SaveData: function (postData) {
            if (_scope.flowInfo.StartDate > _scope.flowInfo.EndDate) {
                layer.msg("有效期开始日期不能大于有效期截止日期");
                return false;
            }
            _service.saveTaskExecInfo(postData).success(function (result) {
                if (result.Code == 10000) {
                    layer.msg("保存成功", { icon: 1 });
                    setTimeout(function () {
                        parent.layer.close(_index);
                    }, 500);
                    parent.layer.close(_index);
                } else {
                    layer.msg(result.Message);
                }
            }).error(function (error) {
                layer.msg(error.Message, { icon: 5 });
            });
        },

        //注册控件
        regControl: function (value) {
            var _this = this;
            comControl.datepicker("forms_UseStartTime");
            comControl.datepicker("forms_UseStopTime");
        }
    }
})();