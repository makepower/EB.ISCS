
// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (o.hasOwnProperty(k))
            if (new RegExp("(" + k + ")").test(fmt))
                fmt = fmt.replace(RegExp.$1,
                    (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

/*
 *获取url中的参数
 *name: url 参数名称
 *child <int> 指定是否是子级（当前需要获取参数页面是否是子级）
 * 1:无父级，2:一级父级，3:二级父级
**/
getUrlParam = function (name, child) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var url = "";
    switch (child) {
        case 1:
            url = window.location.search;
            break;
        case 2:
            url = window.parent.location.search;
            break;
        case 3:
            url = window.parent.parent.location.search;
            break;
    }
    var r = url.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

//公共函数库
var comControl = (function (jq) {
    return {
        /**
         * 打开新标签页
         * @param {controller function address / params：访问地址+参数} c 
         * @param {title：标签页名称} t 
         * @returns {} 
         */
        openTabpage: function (c, t) {
            var e = "?content=content-info&title=" + t + "&iframe=true&isExtUrl=false";
            parent.window.location.hash = "#/" + c + e;
        },
        /**
         * 关闭调用方法js所引用的页面
         * 因为，如果要操作关闭方法，必须在一个激活的页面才能操作
         * 所以，能够调用此方法的页面，就是一个激活的页面
         * @returns {} 
         */
        closeTabpage: function () {
            var n;
            $("#J_mainTabs .page-tabs-content", window.parent.document).children("[data-id]").not(":first").not(".content-edit").each(function () {
                if ($(this).hasClass("active")) {
                    n = $(this).attr("data-id");
                    return $(this).hasClass("active")
                        && ($(this).next(".J_menuTab").size() ? $(this).next(".J_menuTab:eq(0)").addClass("active") : $(this).prev(".J_menuTab").size()
                            && $(this).prev(".J_menuTab:last").addClass("active")),
                        $(this).remove(),
                        $("#J_mainContent .J_content").each(function () {
                            if ($(this).attr("data-id") === n)
                                return $(this).remove(), !1;
                        }), parent.window.location.hash = $("#J_mainTabs .J_menuTab.active", window.parent.document).attr("data-id"), !1;
                }
            });
        },
        //时间控件
        datepicker: function (elmId, value) {
            $('#' + elmId).datepicker({
                show: true,
                format: 'yyyy-mm-dd',
                language: 'zh-CN',
                weekStart: 1,
                autoclose: true,
                orientation: 'left',
                todayBtn: 'linked'
            });
            if (value != null) {
                $('#' + elmId).datepicker('setDate', new Date(value));
            }
        },
        //下拉树
        comboxTree: {
            /*
             * e:control Id
             * v:default value
             * url:api url
             * scb:onSelect callback func
             */
            returnTree: function (e, v, url, scb) {
                var t = jq("#" + e);
                t.combotree({
                    url: url,
                    valueField: "Id",
                    textField: "DetailName",
                    required: true,
                    onClick: function (node) {
                        if (node.children) {
                            if (node.children.length > 0) {
                                t.tree('uncheck', node.target);
                            }
                        }
                    },
                    onLoadSuccess: function (node, data) {
                        if (data && data.length > 0) {
                            if (v) {
                                t.combotree("setValue", v);
                            } else {
                                t.combotree("setValue", data[0].id);
                            }
                        }
                    },
                    onSelect: function (row) {
                        if (row != null && scb != null && $.isFunction(scb)) {
                            scb(row);
                        }
                    }
                });
            },

            /*
             * 只能选中叶子节点
             * e:control Id
             * v:default value
             * url:api url
             */
            onlyLeafTree: function (e, v, url, scb) {
                var t = jq("#" + e);
                t.combotree({
                    url: url,
                    valueField: "id",
                    textField: "text",
                    parentField: 'fatherId',
                    required: true,
                    onBeforeSelect: function (node) {
                        //返回树对象 
                        //选中的节点是否为叶子节点,如果不是叶子节点,清除选中 
                        return t.combotree("tree").tree('isLeaf', node.target);
                    },
                    onClick: function (node) {

                    },
                    onSelect: function (row) {
                        if (row != null && scb != null && $.isFunction(scb)) {
                            scb(row);
                        }
                    },
                    onLoadSuccess: function (node, data) {
                        t.combotree("tree").tree('insert', { id: 100000, text: "----请选择----" });
                        if (data) {
                            if (v) {
                                t.combotree("setValue", v);
                            } else {
                                t.combotree("setValue", data[0].id);
                            }
                        }
                    }
                });
            },
            getTreeValue: function (e) {
                var selectNode = $("#" + e).combotree("tree").tree("getSelected"); // 得到树对象  
                if (selectNode) {
                    return selectNode.id;
                }
                return "";
            }
        },
        //部门控件
        departTree: function (elmId, value) {
            var $elm = $("#" + elmId + "");
            $("#" + elmId + "").combotree({
                url: "/Department/GetDepartmentTree",
                valueField: "id",
                textField: "text",
                required: true,
                editable: false,
                onClick: function (node) {
                },
                onLoadSuccess: function (node, data) {
                    $elm.combotree('setValue', value);
                },
                onSelect: function (row) {
                    if (row != null) {
                        $("#employee_EmpPostion").combotree({
                            url: "/Post/GetPostListByDepartmentId/" + row.id + "?&isGrid=" + false,
                            onLoadSuccess: function (node, data) {
                                $element.combotree('setValue', 0);
                            }
                        });
                    }
                }
            });
        },

        //员工职务控件
        postTree: function (elementId, value, departmentId) {
            var $element = $('#' + elementId + '');
            $('#' + elementId).combotree({
                url: "/Post/GetPostListByDepartmentId/" + departmentId + "?&isGrid=" + false,
                valueField: 'id',
                textField: 'text',
                required: true,
                editable: false,
                onClick: function (node) {
                },
                onLoadSuccess: function (node, data) {
                    $element.combotree('setValue', value);
                }
            });
        },

        postWithDepartmentTree: function (elementId, value) {
            var $element = $('#' + elementId + '');
            $('#' + elementId).combotree({
                url: "/Post/GetPostWithDepartmentTreeList",
                valueField: 'id',
                textField: 'text',
                required: true,
                editable: false,
                checkbox: true,
                onSelect: function (node) {
                    if (node.isDepartment != 0) {
                        layer.msg("请选择岗位！", { icon: 5 });
                        $element.combotree('setValue', 0);
                    }
                },
                onLoadSuccess: function (node, data) {
                    $element.combotree('setValue', value);
                },
                onShowPanel: function () {
                    var tree = $('#' + elementId).combotree("tree");
                    var roots = tree.tree('getRoots');
                    var nodes = [];
                    roots.forEach(function (v) {
                        nodes.push(v);
                    });

                    for (var j = 0, len1 = roots.length; j < len1; j++) {
                        tree.tree('getChildren', roots[j].target).forEach(function (v) {
                            nodes.push(v);
                        });
                    }

                    for (var i = 0, len2 = nodes.length; i < len2; i++) {
                        if (nodes[i].isDepartment !== 0) {
                            $("#" + nodes[i].domId + " .tree-checkbox").remove();
                        }
                    }
                }
            });
        },

        //获取树形Model值
        getTreeModel: function (elmId) {
            var selectNode = $("#" + elmId).combotree("tree").tree("getSelected"); // 得到树对象  
            if (selectNode) {
                return selectNode;
            }
            return "";
        },
        //数据字典函数库
        dirGet: {
            //返回字典详情列表
            DicTree: function (e, v, d) {
                comControl.comboxTree.returnTree(e, v, "/Dictionary/GetDetailListBykey/" + d, null);
            },
            //返回字典大类下所有子类及字典详情
            DicAllTree: function (e, v, d, scb) {
                comControl.comboxTree.onlyLeafTree(e, v, "/Dictionary/GetDicWithDetail/" + d, scb);
            }
        },
        //任务类型控制器
        taskGet: {
            /**
             * 获取任务类型树
             * @param {Html Element Control id} e 
             * @param {Default Value} v 
             * @param {Params} d 
             * @returns {} 
             */
            type: function (e, v, d) {
                comControl.comboxTree.returnTree(e, v, "/Common/GetEnumKeyDescripion?name=" + d, null);
            },
            flowTaskList: function (e, v, d, scb) {
                comControl.comboxTree.returnTree(e, v, "/MyTaskOrder/GetTaskTmpList?dicTypeId=" + d, scb);
            }
        },
        //选择程序
        selectRules: function (callback, isSingleSelect, sqlWhere) {
            var index2, body;
            parent.layer.open({
                type: 2,
                title: "选择用户信息",
                area: ["1000px", "650px"],
                fix: false, //不固定
                maxmin: true,
                zIndex: 20161010,
                content: ["/FlowRules/SelectRules?_t=" + Math.random() +
                    "&isSingleSelect=" + isSingleSelect +
                    "&sqlWhere=" + sqlWhere, "no"],
                end: function () {
                    if (callback && $.isFunction(callback)) {
                        callback();
                    }
                }
            });
        },
        //选择用户
        selectUser: function (callback, sqlWhere) {
            var index2, body;
            parent.layer.open({
                type: 2,
                title: '选择用户信息',
                area: ['800px', '680px'],
                fix: false, //不固定
                maxmin: true,
                zIndex: 20161010,
                content: ["/User/SelectUser?_t=" + Math.random() +
                    "&sqlWhere=" + sqlWhere, 'no'],
                end: function () {
                    if (callback && $.isFunction(callback)) {
                        callback();
                    }
                }
            });
        },
        //选择员工
        selectEmployee: function (callback, isSingleSelect, sqlWhere) {
            var index2, body;
            parent.layer.open({
                type: 2,
                title: '选择员工信息',
                area: ['800px', '600px'],
                fix: false, //不固定
                maxmin: true,
                zIndex: 20161010,
                content: ["/Employee/Select?_t=" + Math.random() + "&isSingleSelect=" + isSingleSelect + "&sqlWhere=" + sqlWhere, 'no'],
                end: function () {
                    if (callback && $.isFunction(callback)) {
                        callback();
                    }
                }
            });
        }
    };
})(jQuery);

var dynamicLoading = {
    css: function (path) {
        if (!path || path.length === 0) {
            throw new Error('argument "path" is required !');
        }
        var head = document.getElementsByTagName('head')[0];
        var link = document.createElement('link');
        link.href = path;
        link.rel = 'stylesheet';
        link.type = 'text/css';
        head.appendChild(link);
    },
    js: function (path) {
        if (!path || path.length === 0) {
            throw new Error('argument "path" is required !');
        }

        var head = document.getElementsByTagName('head')[0];
        var script = document.createElement('script');
        script.src = path;
        script.type = 'text/javascript';
        head.append(script);
    }
};

/**
 * 字典类型映射
 */
enumDicType = (function () {
    return {
        //
        Business: {
            BuiltInType: 1200,//内置流程分类
            ProgramType: 1300,//程序分类
            InnerType: 1310,//内置程序分类
            BusinType: 1320,//业务程序分类
            ProjectType: 2010,//项目分类
            GroupType: 2020,//项目组分类
        },
        System: {
            PostDictionary: 3010,
            PostType: 3011,
            Securitylevel: 3012,
            SealType: 3013
        }
    };
})();