/*
des: DataGrid
module:
*/
$.jgrid.defaults.responsive = true;
$.jgrid.defaults.styleUI = 'Bootstrap';
dataGrid = (function () {
    var grid = {
        _options: null,
        init: function (options) {
            _this = this;
            if (!options.gridId) {
                layer.msg('jQGrid的Id不能为空！');
                return false;
            }
            if (!options.pagerId) {
                layer.msg('分页控件id不能为空！');
                return false;
            }
            if (!options.searchurl) {
                layer.msg('加载数据的Url不能为空！');
                return false;
            }
            if (!options.cols || options.cols.length < 1) {
                layer.msg('展示列不能为空！');
                return false;
            }
            _options = options;
            if (options.isTree) {
                _this.bindTreeGrid();
            }
            else {
                _this.bindJQGrid();
            }
            //_this.autoHeight(_options.gridId);
            //_this.windowResize(_options.gridId);
        },
        bindJQGrid: function () {
            var _this = this;
            var gridparam = {
                url: _options.searchurl,
                datatype: "json",
                colModel: _options.cols,//列头
                loadonce: _options.loadonce, //如果为ture则数据只从服务器端抓取一次，之后所有操作都是在客户端执行，翻页功能会被禁用
                autowidth: _options.autowidth, //自动宽度
                rownumbers: _options.rownumbers, //是否显示行号
                rownumWidth: _options.rownumWidth, //行号列宽
                multiselect: _options.multiselect, //是否多选
                gridview: _options.gridview, //加速显示
                rowNum: _options.rowNum, //每页初始显示条数
                rowList: _options.rowList, //可选择的条数
                viewrecords: _options.viewrecords,//是否要显示总记录数
                pgtext: '第{0}页 共{1}页', //显示页数
                recordtext: '第 {0} - {1}条记录, 总共 {2} 条数据 ',  //显示记录数信息。{0} 为记录数开始，{1}为记录数结束。viewrecords为ture时才能起效，且总记录数大于0时才会显示此信息
                footerrow: false, //
                userDataOnFooter: false, // use the userData parameter of the JSON response to display data on footer
                search: true, // show search button on the toolbar
                add: true,
                edit: true,
                autoScroll: _options.autoScroll,// 添加滚动条
                shrinkToFit: _options.shrinkToFit, // 列宽自适应
                del: true,
                refresh: true,
                pager: "#" + _options.pagerId,
                gridComplete: _this.initGrid,
                loadComplete: _this.gridLoaded,
                onSelectRow: function (rowid) {
                    if (_options.onSelectRow && $.isFunction(_options.onSelectRow)) {
                        _options.onSelectRow(rowid);
                    }
                },
                //行双击事件
                ondblClickRow: function (rowid, iRow, iCol, e) {
                    if (_options.ondblClickRow && $.isFunction(_options.ondblClickRow)) {
                        _options.ondblClickRow(rowid);
                    }
                },
                //单元格选中事件
                onCellSelect: function (rowid, iCol, cellcontent, e) {
                    layer.tips(cellcontent, '');
                },
                //排序事件
                onSortCol: function (index, colindex, sortorder) {
                    
                    var formJson = null;
                    if (_options.searchcondition) {
                        formJson = _options.searchcondition;
                    } else {
                        formJson = $("#" + _options.formId).serializeObject();
                    }
                    formJson.OrderBy = " " + index + " " + sortorder;
                    var formdata = JSON.stringify(formJson);
                    $("#" + _options.gridId).jqGrid('setGridParam', { url: _options.searchurl + "?parameterJson=" + escape(formdata) }).trigger("reloadGrid"); //重新载入
                }

            }
            //单选
            if (_options.singleselect) {
                gridparam.multiselect = true;
                gridparam.multiboxonly = true;
                gridparam.beforeSelectRow = function () {
                    $("#" + _options.gridId).jqGrid('resetSelection');
                    $("#" + _options.gridId).trigger("jqGridSelectAll", false);
                    return (true);
                }
            }
            //分页
            if (!_options.ispage) {
                gridparam.pager = 0;
                gridparam.rowNum = 10000;
                gridparam.rowList = 0;
            }
            if (_options.searchcondition) {
                gridparam.url = _options.searchurl + "?parameterJson=" + JSON.stringify(_options.searchcondition);
            }
            $("#" + _options.gridId).jqGrid(gridparam);
        },
        bindTreeGrid: function () {
            var _this = this;
            _this.grid = $("#" + _options.gridId).jqGrid({
                url: _options.searchurl,
                datatype: "json",
                autowidth: true,
                height: "auto",
                loadui: "disable",
                colModel: _options.cols,
                treeGrid: true,
                loadonce: false,
                treeGridModel: _options.treeGridModel,
                ExpandColumn: _options.expandColumn,
                treeIcons: { leaf: 'ui-icon-document-b' },
                rownumWidth: 35,
                gridview: true, //加速显示
                rowNum: -1,
                jsonReader: {
                    repeatitems: false,
                    root: "dataRows",
                },
                ondblClickRow: function (rowid, iRow, iCol, e) {
                    if (_options.ondblClickRow && $.isFunction(_options.ondblClickRow)) {
                        _options.ondblClickRow(rowid);
                    }
                },
            });
        },
        initGrid: function () {
            var _this = this;
            $(_this).contextMenu('contextMenu', {
                menuStyle: {
                    width: "150px"
                },
                bindings: {
                    'del': function (t) {
                        grid.deleteGridRows();
                    }
                },
                onContextMenu: function (event, menu) {
                    var rowId = $(event.target).parent("tr").attr("id")
                    //var grid = $("#jqGrid");
                    $("#" + _options.gridId).setSelection(rowId);
                    return true;
                }
            });

            document.onkeydown = function (e) {
                var ev = document.all ? window.event : e;
                if (ev.keyCode == 13) {
                    grid.searchGrid(_options.searchcondition);//处理事件
                    layer.closeAll();
                }
            }

        },
        gridLoaded: function () { // 如果数据不存在，提示信息
            var _this = this;
            var rowNum = $("#" + _options.gridId).jqGrid('getGridParam', 'records');
            if (rowNum == 0) {
                if ($("#norecords").html() == null) {
                    $("#" + _options.gridId).parent().append("<div id=\"norecords\"><pre> 没有查询记录！</pre></div> ");
                }
                $("#norecords").show();
            } else { // 如果存在记录，则隐藏提示信息。
                $("#norecords").hide();
            }

            $("#jqGrid tr").click(function () {
                var slced = $(this).attr("aria-selected");
                if (slced == "true") {
                    $(this).attr("aria-selected", "false").removeClass("success");
                }
                else {
                    $(this).attr("aria-selected", "true").addClass("success");
                }
            });
            grid.setSelectRows(_options.keys);
        },
        //是否选中
        hasSelection: function () {
            var _this = this;
            var key = _this.getSelectKey();
            var keys = _this.getSelectKeys();
            if (!key && (!keys || keys.length < 1)) {
                layer.msg('未选中数据行！');
                return false;
            }
            return true;
        },

        //查询
        searchGrid: function (searchcondition) {
            var _this = this;
            var formdata;
            if (!searchcondition) {
                formdata = JSON.stringify($("#" + _options.formId).serializeObject());
            }
            else {
                formdata = JSON.stringify(searchcondition);
            }
            $("#" + _options.gridId).jqGrid('setGridParam', { url: _options.searchurl + "?parameterJson=" + escape(formdata) }).trigger("reloadGrid"); //重新载入
        },
        //删除行
        deleteGridRows: function () {
            var _this = this;
            if (_this.hasSelection()) {
                layer.msg('确认要删除选择的数据吗？', {
                    time: 20000,
                    btn: ['确定', '取消'], //按钮
                    function () {
                        var selectedIDs = _this.getSelectKeys();
                        if (!selectedIDs || selectedIDs.length < 1) {
                            selectedIDs.push(_this.getSelectKey());
                        }
                        if (!_options.deleteurl) {
                            layer.msg("删除数据URL不能为空！");
                            return false;
                        }
                        var selectedLength = selectedIDs.length;
                        $.ajax({
                            url: _options.deleteurl,
                            type: 'post',
                            data: 'ids=' + selectedIDs.join(","),
                            async: false, //默认为true 异步   
                            error: function () {
                                alert('error');
                            },
                            success: function (data) {
                                if (data.Code == 10000 && data.Data) {
                                    if (selectedLength > 1) {
                                        for (var i = 0; i < selectedLength; i++) {
                                            var id = selectedIDs[0];
                                            $("#" + _options.gridId).jqGrid('delRowData', id);
                                        }
                                        if (selectedIDs.length == 0)
                                            layer.msg("删除成功!", { icon: 1 });
                                        else
                                            layer.msg("还有" + selectedIDs.length + "尚未删除!", { icon: 5 });
                                    } else {
                                        var id = selectedIDs[0];
                                        $("#" + _options.gridId).jqGrid('delRowData', id);
                                        layer.msg("删除成功!", { icon: 1 });
                                    }
                                    _this.refreshGrid();
                                }
                                else {
                                    layer.msg("删除失败： " + data.Message, { icon: 5 });
                                }
                            }
                        });
                    }, function () {
                    }
                });
            }

        },
        //刷新Grid
        refreshGrid: function () {
            var _this = this;
            $("#" + _options.gridId).trigger("reloadGrid");
        },
        ///获取选中的Keys
        getSelectKeys: function () {
            var _this = this;
            return $("#" + _options.gridId).getGridParam("selarrrow");
        },

        getSelectKey: function () {
            var _this = this;
            return $("#" + _options.gridId).getGridParam("selrow");;
        },
        getSelectRowData: function () {
            var _this = this;
            var key = $("#" + _options.gridId).getGridParam("selrow");
            return $("#" + _options.gridId).jqGrid('getRowData', key);
        },
        getSelectRowDatas: function () {
            var _this = this;
            var arr = [];
            var keys = $("#" + _options.gridId).getGridParam("selarrrow");
            if (keys && keys.length > 0) {
                for (var i = 0; i < keys.length; i++) {
                    arr.push($("#" + _options.gridId).jqGrid('getRowData', keys[i]));
                }
            }
            return arr;
        },

        setSelectRows(keys) {
            var _this = this;
            if (keys && keys.length > 0) {
                for (var i = 0; i < keys.length; i++) {
                    $("#" + _options.gridId).jqGrid('setSelection', keys[i]);
                }
            }
        },
        doResize: function (gridId) {
            var _this = this;
            var ss = grid.getPageSize();
            $("#" + gridId).jqGrid('setGridWidth', ss.WinW - 10 - 10).jqGrid('setGridHeight', ss.WinH - 100 - 55);
        },
        autoHeight: function (gridId) {
            var _this = this;
            var ss = grid.getPageSize();
            if (_options.ispage) {
                $("#" + gridId).jqGrid('setGridHeight', ss.WinH - 100 - 55);
            }
            else {
                $("#" + gridId).jqGrid('setGridHeight', ss.WinH - 85);
            }
        },
        getPageSize: function () {
            var winW, winH;
            if (window.innerHeight) {// all except IE 
                winW = window.innerWidth;
                winH = window.innerHeight;
            } else if (document.documentElement && document.documentElement.clientHeight) {// IE 6 Strict Mode 
                winW = document.documentElement.clientWidth;
                winH = document.documentElement.clientHeight;
            } else if (document.body) { // other 
                winW = document.body.clientWidth;
                winH = document.body.clientHeight;
            }  // for small pages with total size less then the viewport  
            return { WinW: winW, WinH: winH };
        },
        windowResize: function () {
            var _this = this;
            var t = document.documentElement.clientWidth;
            window.onresize = function () {
                if (t != document.documentElement.clientWidth) {
                    t = document.documentElement.clientWidth;
                    //_this.autoHeight(_options.gridId);
                }
            }
        }
    }
    return {
        //初始化DataGrid
        initGrid: function (options) {
            options = $.extend({
                gridId: 'jqGrid', //jqGrid Id
                pagerId: 'jqGridPager', // jqGrid 分页控件Id
                searchurl: '', //加载数据Url
                deleteurl: '', //删除数据Url
                cols: [], //展示列
                isTree: false, //是否展示树
                treeGridModel: "adjacency",//树形模式
                expandColumn: "NameShort",//展开收缩列
                formId: 'search_form', //查询条件表单Id
                loadonce: false, //如果为ture则数据只从服务器端抓取一次，之后所有操作都是在客户端执行，翻页功能会被禁用
                autowidth: true, //自动宽度
                rownumbers: true, //是否显示行号
                rownumWidth: 35, //行号列宽
                multiselect: true, //是否多选
                singleselect: false,//是否单选
                gridview: true, //加速显示
                autoScroll: true,// 添加滚动条
                ispage: true, //是否分页
                rowNum: 20, //每页初始显示条数
                rowList: [15, 20, 30], //可选择的条数
                viewrecords: true,//是否要显示总记录数
                shrinkToFit: true,// 列宽自适应
                searchcondition: null,
                onSelectRow: function (rowid) { },
                ondblClickRow: function (rowId) { },
                keys: null //默认选中的值
            }, options || {});

            grid.init(options);
            grid.autoHeight(options.gridId);
            //$("#"+options.gridId).closest(".ui-jqgrid-bdiv").css({ 'overflow-x': 'hidden' });
        },
        //刷新Grid
        refreshGrid: grid.refreshGrid,

        //删除Grid行
        deleteGridRows: grid.deleteGridRows,

        //获取选中的值（多选）
        getSelectKeys: grid.getSelectKeys,

        //获取选中的值（单选）
        getSelectKey: grid.getSelectKey,

        //获取选中的行数据（单选）
        getSelectRowData: grid.getSelectRowData,

        //获取选中的行数据（多选）
        getSelectRowDatas: grid.getSelectRowDatas,

        //是否选中
        hasSelection: grid.hasSelection,

        //查询
        searchGrid: grid.searchGrid,

        //自动调整Grid大小
        doResize: grid.doResize,

        //自动调整Grid高度
        autoHeight: grid.autoHeight,
        //设置选中的行
        setSelectRows: grid.setSelectRows
    }
})();


//扩展方法的定义
(function ($) {


    /*****************************开始 easyui - datagrid***************************/

    /**
      *列表加载方法-适用easyui-datagrid
      *
      *jsonWhere--必须项--（json列表数据配置）
      *示例：      {
      *              gvHeadXml:"表头配置XML名称",    （必选项---字符串）
      *              sqlName:"查询用SQL名称",    （必选项---字符串）
      *              params:"查询用参数",        （可选项---字符串 格式为数组[参数1,参数2,……]）
      *              sqlWhere:"拼接where条件"    （可选项---字符串 sql语句拼接用）
      *            }
      *options--可选项--列表配置项（默认项除外），
      */
    $.fn.gvLoadGrid = function (jsonWhere, options) {
        var i_PageSize = $.cookie('page_size');
        if (i_PageSize == null) {
            i_PageSize = 15;
        }
        var iSelectedIndex = -1;
        var strGridId = $(this).attr('Id');  //当前列表ID
        var iHeight = 40;  //默认减掉的高度
        var iPageSize = i_PageSize;
        var arrPageList = [15, 20, 30, 50];
        var isHasOptions = false;
        var fOnLoadSuccess = function (data) { };
        var fOnSelect = function (index, row) { };
        var fOnUnSelect = function (index, row) { };
        if (typeof (options) != 'undefined') {
            isHasOptions = true;
        }
        if (isHasOptions && $.isFunction(options.onSuccess)) {
            fOnLoadSuccess = options.onSuccess;
        }

        var _this = this;
        var strGVUrl = '/Common/GetDataListGrid', strGVHeadXml = '', strSQLName = '', strWhere = '', customsort = true, editor = false;;
        var arrPapameters = [];   //参数数组

        //查询用Controll
        if (jsonWhere["gvUrl"]) {
            strGVUrl = jsonWhere["gvUrl"];
        }

        //表头XML名称
        if (jsonWhere["gvHeadXml"]) {
            strGVXml = jsonWhere["gvHeadXml"];
        }

        //查询用XML名称
        if (jsonWhere["sqlName"]) {
            strSQLName = jsonWhere["sqlName"];
        }

        //查询用数组
        if (jsonWhere["params"] && $.isArray(jsonWhere["params"])) {
            arrPapameters = jsonWhere["params"];
        }

        if (jsonWhere["sqlWhere"]) {
            strWhere = jsonWhere["sqlWhere"];
        }
        //是否排序customsort = true表示不排序，默认排序
        if (jsonWhere["customsort"]) {
            customsort = false;
        }

        if (jsonWhere["editor"]) {
            editor = true;
        }

        if (isHasOptions) {
            if (typeof (options["height"]) == 'undefined') {
                options["height"] = iHeight;
            }

            if (typeof (options["pageSize"]) != 'number') {
                options["pageSize"] = iPageSize;
            }

            if (!(typeof (options["pageList"]) != 'undefined' && $.isArray(options["pageList"]))) {
                options["pageList"] = arrPageList;
            }

            if (typeof (options["pageSize"]) != 'number') {
                options["pageSize"] = iPageSize;
            }

            if (typeof (options["onSelect"]) == 'function') {
                fOnSelect = options["onSelect"];
                options["onSelect"] = undefined;
            }

            if (typeof (options["onUnselect"]) == 'function') {
                fOnUnSelect = options["onUnselect"];
                options["onUnselect"] = undefined;
            }
        }
        iHeight = options["height"];

        if (typeof (options["fixedheight"]) == 'undefined') {
            options["height"] = $(window).height() - iHeight;
        } else {
            options["height"] = options["fixedheight"];
        }


        //请求加载表头信息
        $.post('/Common/GetGridHeader', { GV_XML: strGVXml }, function (jsonData) {
            if (jsonData != null && jsonData.length > 0 && typeof (jsonData) == 'string') {
                jsonData = $.parseJSON(jsonData);
            }

            //表头信息配置
            var arrColumns = [];

            //显示复选框
            var arrHideColumns = [];
            if (isHasOptions && options["showCheckbox"] == true) {
                arrColumns.push({
                    field: "CHECKBOX", checkbox: false, width: "30", formatter: function (value, row, index) {
                        if (row.CHECKBOX == 'true') {
                            return '<input type="checkbox" checked="true" data-level="son" />';
                        } else {
                            return '<input type="checkbox" data-level="son" />';
                        }
                    }, title: '<input type="checkbox" data-level="parent" />'
                });
            }
            $.each(jsonData, function (i, item) {
                var ISSORT = true;
                if (item.ISSORT == 'false') {
                    ISSORT = false;
                }
                if (item.WIDTH == '0') {
                    arrHideColumns.push(item.FIELDNAME);
                }
                if (editor) {
                    if (item.IF_EDITOR != "1") {
                        arrColumns.push({
                            field: item.FIELDNAME, title: item.NAME, width: item.WIDTH, sortable: ISSORT, editor: { type: 'validatebox', options: { required: false } }
                        });
                    } else {
                        arrColumns.push({
                            field: item.FIELDNAME, title: item.NAME, width: item.WIDTH, sortable: ISSORT
                        });
                    }
                } else {
                    if (isHasOptions && options["showCheckbox"] == true) {
                        arrColumns.push({
                            field: item.FIELDNAME, title: item.NAME, width: item.WIDTH, sortable: ISSORT, editor: { type: 'validatebox', options: { required: false } }
                        });
                    } else {
                        arrColumns.push({
                            field: item.FIELDNAME, title: item.NAME, width: item.WIDTH, sortable: ISSORT, editor: { type: 'validatebox', options: { required: false } }, formatter: function (value, row, index) {
                                if (typeof value == "undefined") {
                                    value = '';
                                }
                                else if (!value && typeof value != "undefined" && value != 0) {
                                    value = '';
                                }
                                return '<div data-p1=' + index + ' class="easyui-tooltip" style="width:100% ; height:15px">' + value + '</div>';
                                //return '<span data-p1=' + index + ' class="easyui-tooltip" style="border:2px solid #0E2D5F ; width:500%">' + value + '</span>';
                            }
                        });
                    }

                }
            });

            //查询参数 
            var queryParamsJson = {
                SQL_NAME: strSQLName,
                SQL_WHERE: strWhere,
            };

            //若查询数组长度大于0说明已经传入数组则需要给参数
            if (arrPapameters.length > 0) {
                queryParamsJson["PARAMETERS"] = arrPapameters.join(',');
            }

            var defaultConfig = {
                //title: '用户列表',
                url: strGVUrl,
                queryParams: queryParamsJson,
                fitColumns: true,
                iconCls: 'icon-save',
                method: 'post',
                loadMsg: '加载中...',
                striped: true, //奇偶行是否区分
                columns: [arrColumns],  //表头信息
                frozenColumns: [[]],   //固定列
                rownumbers: true,  //启用行号显示
                checkOnSelect: true,  //点击行时是否选中复选框
                onSelect: function (index, row) {
                    //当选中行时该行checkbox置为相反状态（选中checkbox本身除外）
                    var $checkbox = $(this).datagrid('getPanel').find('table.datagrid-btable').find('tr:eq(' + index + ')').find(':checkbox');
                    //if ($(event.target).attr('type') == 'checkbox') {

                    //} else {
                    //    $checkbox.prop('checked', !$checkbox.prop('checked'));
                    //    /**if (!$checkbox.prop('checked')) {

                    //        $(this).parent('div').find(':checkbox[data-level="parent"]').prop('checked', false);
                    //    }*/
                    //}
                    $checkbox.prop('checked', !$checkbox.prop('checked'));
                    if ($(_this).parent('div').find(':checkbox:checked[data-level="son"]').length != $(_this).parent('div').find(':checkbox[data-level!="parent"]').length) {
                        $(this).parent('div').find(':checkbox[data-level="parent"]').prop('checked', false);
                    }

                    fOnSelect(index, row);

                    iSelectedIndex = index;
                },
                onUnselect: function (index, row) {
                    //当选中行时该行checkbox置为相反状态（选中checkbox本身除外）
                    var $checkbox = $(this).datagrid('getPanel').find('table.datagrid-btable').find('tr:eq(' + index + ')').find(':checkbox');

                    //if ($(event.target).attr('type') == 'checkbox') {

                    //} else {
                    //    $checkbox.prop('checked', !$checkbox.prop('checked'));
                    //}
                    $checkbox.prop('checked', !$checkbox.prop('checked'));
                    $(this).parent('div').find(':checkbox[data-level="parent"]').prop('checked', false);

                    fOnUnSelect(index, row);
                },
                onLoadSuccess: function (data) {
                    var _this = this;
                    $(this).parent('div').find(':checkbox[data-level="parent"]').click(function () {
                        $(_this).parent('div').find(':checkbox[data-level="son"]').prop("checked", this.checked);
                    });

                    //选中用户行高亮显示
                    $(this).parent('div').find(':checkbox:checked[data-level="son"]').each(function () {
                        $(this).parents('tr').addClass('datagrid-row-checked datagrid-row-selected');
                    });

                    //解决IE下不能选择的问题
                    if (window.navigator.userAgent.toLowerCase().indexOf('msie') > -1) {
                        $(this).parent('div').find(':checkbox[data-level="son"]').click(function () {
                            $(this).prop('checked', !$(this).prop('checked'));
                        });
                    }


                    if ($.isFunction(fOnLoadSuccess)) {
                        fOnLoadSuccess(data);
                    }
                    $('.datagrid-row').css({ height: '35px' });
                    if (iSelectedIndex != -1) {
                        $(this).datagrid('selectRow', iSelectedIndex);
                    }
                }
                /**onBeforeLoad: function (param) {
                    //加载前事件
                },
                onLoadError: function () {
                    //出现错误时触发事件
                },
                onClickCell: function (rowIndex, field, value) {
                    //单击事件
                },
                onSelect: function (index, row) {
                }*/
            };

            //合并选项
            var gridConfig = $.extend(defaultConfig, options);

            //datagrid生成
            $(_this).datagrid(gridConfig);

            for (var i = 0; i < arrHideColumns.length; i++) {
                $(_this).datagrid('hideColumn', arrHideColumns[i]);
            }

            if (gridConfig.pagination == true) {
                //设置分页控件
                var p = $(_this).datagrid('getPager');

                if (typeof (gridConfig.simplify) == 'undefined') {
                    $(p).pagination({
                        pageSize: options["pageSize"],//每页显示的记录条数，默认为10
                        pageList: options["pageList"],//可以设置每页记录条数的列表
                        beforePageText: '第',//页数文本框前显示的汉字
                        afterPageText: '页 共{pages}页',
                        displayMsg: '共{total}条'//'当前显示 {from} - {to} 条记录   共 {total} 条记录'
                    });
                } else {
                    $(p).pagination({
                        layout: ['first', 'prev', 'next', 'last'],
                        displayMsg: '共{total}条'//'当前显示 {from} - {to} 条记录   共 {total} 条记录'
                    });
                }

            }
        });

        /**表头设置画面打开**/
        $('#' + strGridId + '_listConfig').click(function () {
            var strConfigUrl = '/Common/ListConfig?MENU_NAME=' + encodeURIComponent(strGVXml);
            var if_divListConfig = $("#divListConfig");
            if (if_divListConfig.length > 0) { } else {
                var divListConfig = '<div id="divListConfig" style="overflow:hidden"><iframe scrolling="no" id="lstConfigUrl" frameborder="0"  src="' + strConfigUrl + '" style="width:100%;height:100%;" /><button data-type="closeDialog"></button></div>';
                $(divListConfig).appendTo('body');
            }
            //点击关闭按钮退出
            $('button[data-type="closeDialog"]').click(function () {
                $('#divListConfig').dialog('close');
            });
            $('#divListConfig').dialog({
                title: '列表表头配置',
                width: 1000,
                height: 450,
                cache: false,
                collapsible: true,
                maximizable: true,
                resizable: true,
                modal: true,
                closed: false,
                onClose: function () {
                    //关闭事件
                    $('#divListConfig').remove();
                    $(this).dialog('destroy');
                }
            }).dialog('open');
        });
        $(window).resize(function () {
            setTimeout(function () {
                $('#' + strGridId).datagrid('resize', {
                    height: $(window).height() - iHeight
                });
            }, 100);
        });
    };

    //是否选中行-适用easyui-datagrid
    $.fn.gvIsSelectRow = function () {
        var row = $(this).datagrid('getSelected');
        var rows = $(this).datagrid('getSelections');
        var checkrows = $(this).datagrid('getChecked');
        if ((!row && (!rows || rows.length < 1) && (!checkrows || checkrows.length < 1)) || typeof (row) == "string") {
            layer.msg('请选择需要操作的数据！');
            return false;
        }
        return true;

    }

    //获取选中的行-适用easyui-datagrid
    $.fn.gvGetSelectRow = function () {
        return $(this).datagrid('getSelected');
    }

    //获取选中行（多行）-适用easyui-datagrid
    $.fn.gvGetSelectRows = function () {
        rows = $(this).datagrid('getSelections');
        if (rows && rows.length > 0) {
            return rows;
        }
        else {
            return $(this).datagrid('getChecked');
        }
    }

    //刷新grid-适用easyui-datagrid
    $.fn.gvRefreshGrid = function (sqlWhere) {
        $(this).datagrid('options').queryParams.SQL_WHERE = sqlWhere;
        $(this).datagrid('reload');
    }

    /**
    * 删除数据-适用easyui-datagrid
    *delSqlName--删除语句，
    *sqlWhere--删除记录后，刷新数据需要的查询条件
    */
    $.fn.gvDeleteRows = function (delSqlName, sqlWhere) {
        var _this = $(this);
        if (_this.gvIsSelectRow()) {
            layer.confirm('确认要删除选择的数据吗？', {
                btn: ['确定', '取消']
            }, //按钮
                function () {
                    var rows = _this.gvGetSelectRows();
                    var selectedIDs = [];
                    for (var i = 0; i < rows.length; i++) {
                        selectedIDs.push(rows[i].Id);
                    }
                    $.ajax({
                        url: '/Common/DelDataListGrid',
                        type: 'post',
                        data: {
                            SqlName: delSqlName,
                            DelString: selectedIDs.join(","),
                            rnd: Math.random().toString()
                        },
                        async: false, //默认为true 异步   
                        error: function () {
                            layer.msg('删除失败!');
                        },
                        success: function (data) {
                            if (data.Code == 10000 && data.Data) {
                                layer.msg('删除成功！', { icon: 1 });
                                _this.gvRefreshGrid(sqlWhere);
                            }
                            else {
                                layer.msg('删除失败:' + data.Message, { icon: 5 });
                            }
                        }
                    });
                },
                function () { });
        }
    }
    $.fn.gvDeleteRowsUrl = function (url, callback) {
        var _this = $(this);
        if (_this.gvIsSelectRow()) {
            layer.confirm('确认要删除选择的数据吗？', {
                btn: ['确定', '取消']
            }, //按钮
                function () {
                    var rows = _this.gvGetSelectRows();
                    var selectedIDs = [];
                    for (var i = 0; i < rows.length; i++) {
                        selectedIDs.push(rows[i].Id);
                    }
                    $.ajax({
                        url: url,
                        type: 'post',
                        data: {
                            ids: selectedIDs.join(",")
                        },
                        async: false, //默认为true 异步   
                        error: function () {
                            layer.msg('删除失败!');
                        },
                        success: function (data) {
                            if (data.Code == 10000 && data.Data) {
                                layer.msg('删除成功！', { icon: 1 });
                                if (callback && $.isFunction(callback)) {
                                    callback();
                                }
                            }
                            else {
                                layer.msg('删除失败:' + data.Message, { icon: 5 });
                            }
                        }
                    });
                },
                function () { });
        }
    }
    /*****************************结束 easyui - datagrid***************************/




    /*****************************开始 easyui - treegrid***************************/

    /**
    *列表加载方法-适用easyui-treegrid
    *
    *jsonWhere--必须项--（json列表数据配置）
    *示例：      {
    *              gvHeadXml:"表头配置XML名称",    （必选项---字符串）
    *              gvUrl:"查询用Controll",    （必选项---字符串）
    *              params:"查询用参数",        （可选项---字符串 格式为数组[参数1,参数2,……]）
    *              sqlWhere:"拼接where条件"    （可选项---字符串 sql语句拼接用）
    *            }
    *options--可选项--列表配置项（默认项除外），
    */
    $.fn.tgvLoadTreeGrid = function (jsonWhere, options) {
        var i_PageSize = $.cookie('page_size');
        if (i_PageSize == null) {
            i_PageSize = 15;
        }
        var iSelectedIndex = -1;
        var strGridId = $(this).attr('Id');  //当前列表ID
        var iHeight = 40;  //默认减掉的高度
        var iPageSize = i_PageSize;
        var arrPageList = [15, 20, 30, 50];
        var isHasOptions = false;
        var fOnLoadSuccess = function (data) { };
        var fOnSelect = function (index, row) { };
        var fOnUnSelect = function (index, row) { };
        if (typeof (options) != 'undefined') {
            isHasOptions = true;
        }
        if (isHasOptions && $.isFunction(options.onSuccess)) {
            fOnLoadSuccess = options.onSuccess;
        }

        var _this = this;
        var strGVUrl = '', strGVHeadXml = '', strGVUrl = '', strWhere = '', customsort = true, editor = false;;
        var arrPapameters = [];   //参数数组

        //表头XML名称
        if (jsonWhere["gvHeadXml"]) {
            strGVXml = jsonWhere["gvHeadXml"];
        }

        //查询用Controll
        if (jsonWhere["gvUrl"]) {
            strGVUrl = jsonWhere["gvUrl"];
        }

        //查询用数组
        if (jsonWhere["params"] && $.isArray(jsonWhere["params"])) {
            arrPapameters = jsonWhere["params"];
        }

        if (jsonWhere["sqlWhere"]) {
            strWhere = jsonWhere["sqlWhere"];
        }
        //是否排序customsort = true表示不排序，默认排序
        if (jsonWhere["customsort"]) {
            customsort = false;
        }

        if (jsonWhere["editor"]) {
            editor = true;
        }

        if (isHasOptions) {
            if (typeof (options["height"]) == 'undefined') {
                options["height"] = iHeight;
            }

            if (typeof (options["pageSize"]) != 'number') {
                options["pageSize"] = iPageSize;
            }

            if (!(typeof (options["pageList"]) != 'undefined' && $.isArray(options["pageList"]))) {
                options["pageList"] = arrPageList;
            }

            if (typeof (options["pageSize"]) != 'number') {
                options["pageSize"] = iPageSize;
            }

            if (typeof (options["onSelect"]) == 'function') {
                fOnSelect = options["onSelect"];
                options["onSelect"] = undefined;
            }

            if (typeof (options["onUnselect"]) == 'function') {
                fOnUnSelect = options["onUnselect"];
                options["onUnselect"] = undefined;
            }
        }
        iHeight = options["height"];

        if (typeof (options["fixedheight"]) == 'undefined') {
            options["height"] = $(window).height() - iHeight;
        } else {
            options["height"] = options["fixedheight"];
        }


        //请求加载表头信息
        $.post('/Common/GetGridHeader', { GV_XML: strGVXml }, function (jsonData) {
            if (jsonData != null && jsonData.length > 0 && typeof (jsonData) == 'string') {
                jsonData = $.parseJSON(jsonData);
            }

            //表头信息配置
            var arrColumns = [];

            //显示复选框
            var arrHideColumns = [];
            if (isHasOptions && options["showCheckbox"] == true) {
                arrColumns.push({
                    field: "CHECKBOX", checkbox: false, width: "30", formatter: function (value, row, index) {
                        if (row.CHECKBOX == 'true') {
                            return '<input type="checkbox" checked="true" data-level="son" />';
                        } else {
                            return '<input type="checkbox" data-level="son" />';
                        }
                    }, title: '<input type="checkbox" data-level="parent" />'
                });
            }

            $.each(jsonData, function (i, item) {
                var ISSORT = true;
                if (item.ISSORT == 'false') {
                    ISSORT = false;
                }
                if (item.WIDTH == '0') {
                    arrHideColumns.push(item.FIELDNAME);
                }
                if (editor) {
                    if (item.IF_EDITOR != "1") {
                        arrColumns.push({
                            field: item.FIELDNAME, title: item.NAME, width: item.WIDTH, sortable: ISSORT, editor: { type: 'validatebox', options: { required: false } }
                        });
                    } else {
                        arrColumns.push({
                            field: item.FIELDNAME, title: item.NAME, width: item.WIDTH, sortable: ISSORT
                        });
                    }
                } else {
                    if (isHasOptions && options["showCheckbox"] == true) {
                        arrColumns.push({
                            field: item.FIELDNAME, title: item.NAME, width: item.WIDTH, sortable: ISSORT, editor: { type: 'validatebox', options: { required: false } }
                        });
                    } else {
                        arrColumns.push({
                            field: item.FIELDNAME, title: item.NAME, width: item.WIDTH, sortable: ISSORT, editor: { type: 'validatebox', options: { required: false } }, formatter: function (value, row, index) {
                                if (typeof value == "undefined") {
                                    value = '';
                                }
                                else if (!value && typeof value != "undefined" && value != 0) {
                                    value = '';
                                }
                                return '<div data-p1=' + index + ' class="easyui-tooltip" style="width:100% ; height:15px">' + value + '</div>';
                                //return '<span data-p1=' + index + ' class="easyui-tooltip" style="border:2px solid #0E2D5F ; width:500%">' + value + '</span>';
                            }
                        });
                    }

                }
            });

            //查询参数 
            var queryParamsJson = {
                SQL_WHERE: strWhere,
            };

            //若查询数组长度大于0说明已经传入数组则需要给参数
            if (arrPapameters.length > 0) {
                queryParamsJson["PARAMETERS"] = arrPapameters.join(',');
            }

            var defaultConfig = {
                //title: '用户列表',
                url: strGVUrl,
                queryParams: queryParamsJson,
                fitColumns: true,
                iconCls: 'icon-save',
                method: 'post',
                loadMsg: '加载中...',
                animate: true,//节点展开或折叠的时候是否显示动画效果
                striped: true, //奇偶行是否区分
                columns: [arrColumns],  //表头信息
                frozenColumns: [[]],   //固定列
                rownumbers: true,  //启用行号显示
                checkOnSelect: true,  //点击行时是否选中复选框
                onSelect: function (index, row) {
                    //当选中行时该行checkbox置为相反状态（选中checkbox本身除外）
                    var $checkbox = $(this).datagrid('getPanel').find('table.datagrid-btable').find('tr:eq(' + index + ')').find(':checkbox');
                    //if ($(event.target).attr('type') == 'checkbox') {

                    //} else {
                    //    $checkbox.prop('checked', !$checkbox.prop('checked'));
                    //    /**if (!$checkbox.prop('checked')) {

                    //        $(this).parent('div').find(':checkbox[data-level="parent"]').prop('checked', false);
                    //    }*/
                    //}
                    $checkbox.prop('checked', !$checkbox.prop('checked'));
                    if ($(_this).parent('div').find(':checkbox:checked[data-level="son"]').length != $(_this).parent('div').find(':checkbox[data-level!="parent"]').length) {
                        $(this).parent('div').find(':checkbox[data-level="parent"]').prop('checked', false);
                    }

                    fOnSelect(index, row);

                    iSelectedIndex = index;
                },
                onUnselect: function (index, row) {
                    //当选中行时该行checkbox置为相反状态（选中checkbox本身除外）
                    var $checkbox = $(this).datagrid('getPanel').find('table.datagrid-btable').find('tr:eq(' + index + ')').find(':checkbox');

                    //if ($(event.target).attr('type') == 'checkbox') {

                    //} else {
                    //    $checkbox.prop('checked', !$checkbox.prop('checked'));
                    //}
                    $checkbox.prop('checked', !$checkbox.prop('checked'));
                    $(this).parent('div').find(':checkbox[data-level="parent"]').prop('checked', false);

                    fOnUnSelect(index, row);
                },
                onLoadSuccess: function (data) {
                    var _this = this;
                    $(this).parent('div').find(':checkbox[data-level="parent"]').click(function () {
                        $(_this).parent('div').find(':checkbox[data-level="son"]').prop("checked", this.checked);
                    });

                    //选中用户行高亮显示
                    $(this).parent('div').find(':checkbox:checked[data-level="son"]').each(function () {
                        $(this).parents('tr').addClass('datagrid-row-checked datagrid-row-selected');
                    });

                    //解决IE下不能选择的问题
                    if (window.navigator.userAgent.toLowerCase().indexOf('msie') > -1) {
                        $(this).parent('div').find(':checkbox[data-level="son"]').click(function () {
                            $(this).prop('checked', !$(this).prop('checked'));
                        });
                    }


                    if ($.isFunction(fOnLoadSuccess)) {
                        fOnLoadSuccess(data);
                    }
                    $('.datagrid-row').css({ height: '35px' });
                    $('.datagrid-header-row').css({ height: '35px' });


                    if (iSelectedIndex != -1) {
                        $(this).datagrid('selectRow', iSelectedIndex);
                    }
                }
                /**onBeforeLoad: function (param) {
                    //加载前事件
                },
                onLoadError: function () {
                    //出现错误时触发事件
                },
                onClickCell: function (rowIndex, field, value) {
                    //单击事件
                },
                onSelect: function (index, row) {
                }*/
            };

            //合并选项
            var gridConfig = $.extend(defaultConfig, options);

            //datagrid生成
            $(_this).treegrid(gridConfig);

            for (var i = 0; i < arrHideColumns.length; i++) {
                $(_this).datagrid('hideColumn', arrHideColumns[i]);
            }

            if (gridConfig.pagination == true) {
                //设置分页控件
                var p = $(_this).datagrid('getPager');

                if (typeof (gridConfig.simplify) == 'undefined') {
                    $(p).pagination({
                        pageSize: options["pageSize"],//每页显示的记录条数，默认为10
                        pageList: options["pageList"],//可以设置每页记录条数的列表
                        beforePageText: '第',//页数文本框前显示的汉字
                        afterPageText: '页 共{pages}页',
                        displayMsg: '共{total}条'//'当前显示 {from} - {to} 条记录   共 {total} 条记录'
                    });
                } else {
                    $(p).pagination({
                        layout: ['first', 'prev', 'next', 'last'],
                        displayMsg: '共{total}条'//'当前显示 {from} - {to} 条记录   共 {total} 条记录'
                    });
                }

            }
        });

        /**表头设置画面打开**/
        $('#' + strGridId + '_listConfig').click(function () {
            var strConfigUrl = '/Common/ListConfig?MENU_NAME=' + encodeURIComponent(strGVXml);
            var if_divListConfig = $("#divListConfig");
            if (if_divListConfig.length > 0) { } else {
                var divListConfig = '<div id="divListConfig" style="overflow:hidden"><iframe scrolling="no" id="lstConfigUrl" frameborder="0"  src="' + strConfigUrl + '" style="width:100%;height:100%;" /><button data-type="closeDialog"></button></div>';
                $(divListConfig).appendTo('body');
            }
            //点击关闭按钮退出
            $('button[data-type="closeDialog"]').click(function () {
                $('#divListConfig').dialog('close');
            });
            $('#divListConfig').dialog({
                title: '列表表头配置',
                width: 1000,
                height: 450,
                cache: false,
                collapsible: true,
                maximizable: true,
                resizable: true,
                modal: true,
                closed: false,
                onClose: function () {
                    //关闭事件
                    $('#divListConfig').remove();
                    $(this).dialog('destroy');
                }
            }).dialog('open');
        });
        $(window).resize(function () {
            setTimeout(function () {
                $('#' + strGridId).datagrid('resize', {
                    height: $(window).height() - iHeight
                });
            }, 100);
        });
    };

    //是否选中行-适用easyui-treegrid
    $.fn.tgvIsSelectRow = function () {
        var row = $(this).datagrid('getSelected');
        var rows = $(this).datagrid('getSelections');
        var checkrows = $(this).datagrid('getChecked');
        if ((!row && (!rows || rows.length < 1) && (!checkrows || checkrows.length < 1)) || row == "id") {
            layer.msg('请选择需要操作的数据！');
            return false;
        }
        return true;

    }

    //获取选中行（多行）-适用easyui-datagrid
    $.fn.tgvGetSelectRows = function () {
        rows = $(this).treegrid('getSelections');
        if (rows && rows.length > 0) {
            return rows;
        }
        else {
            return $(this).treegrid('getChecked');
        }
    }

    //获取选中的行-适用easyui-treegrid
    $.fn.tgvGetSelectRow = function () {
        return $(this).treegrid('getSelected');
    }

    /**
    * 删除数据-适用easyui-treegrid
    *delSqlName--删除语句，
    *sqlWhere--删除记录后，刷新数据需要的查询条件
    */
    $.fn.tgvDeleteRows = function (delSqlName, sqlWhere) {
        var _this = $(this);
        if (_this.tgvIsSelectRow()) {
            layer.confirm('确认要删除选择的数据吗？', {
                btn: ['确定', '取消']
            }, //按钮
                function () {
                    var rows = _this.tgvGetSelectRows();
                    var selectedIDs = [];
                    for (var i = 0; i < rows.length; i++) {
                        selectedIDs.push(rows[i].Id);
                    }
                    $.ajax({
                        url: '/Common/DelDataListGrid',
                        type: 'post',
                        data: {
                            SqlName: delSqlName,
                            DelString: selectedIDs.join(","),
                            rnd: Math.random().toString()
                        },
                        async: false, //默认为true 异步   
                        error: function () {
                            layer.msg('删除失败!');
                        },
                        success: function (data) {
                            if (data.Code == 10000 && data.Data) {
                                layer.msg('删除成功！', { icon: 1 });
                                _this.tgvRefreshGrid(sqlWhere);
                            }
                            else {
                                layer.msg('删除失败:' + data.Message, { icon: 5 });
                            }
                        }
                    });
                },
                function () { });
        }
    }
    $.fn.tgvDeleteRowsUrl = function (url, callback) {
        var _this = $(this);
        if (_this.tgvIsSelectRow()) {
            layer.confirm('确认要删除选择的数据吗？', {
                btn: ['确定', '取消']
            }, //按钮
                function () {
                    var rows = _this.tgvGetSelectRows();
                    var selectedIDs = [];
                    for (var i = 0; i < rows.length; i++) {
                        selectedIDs.push(rows[i].Id);
                    }
                    $.ajax({
                        url: url,
                        type: 'post',
                        data: {
                            ids: selectedIDs.join(",")
                        },
                        async: false, //默认为true 异步   
                        error: function () {
                            layer.msg('删除失败!');
                        },
                        success: function (data) {
                            if (data) {
                                var r = JSON.parse(data);
                                if (r.Code == 10000 && r.Data) {
                                    layer.msg('删除成功！', { icon: 1 });
                                    if (callback && $.isFunction(callback)) {
                                        callback(r);
                                    }
                                }
                                else {
                                    layer.msg('删除失败:' + r.Message, { icon: 5 });
                                }
                            }
                        }
                    });
                },
                function () { });
        }
    }
    //刷新treegrid-适用easyui-treegrid
    $.fn.tgvRefreshGrid = function (sqlWhere) {
        $(this).treegrid('options').queryParams.SQL_WHERE = sqlWhere;
        $(this).treegrid('reload');
    }

    /*****************************结束 easyui - treegrid***************************/





    /*****************************开始 easyui - comobox***************************/

    // 获取tree的选中level-适用easyui-comobox
    //$.fn.treeGetLevel = function () {
    //    var l = $(this).parentsUntil("ul.tree", "ul");
    //    return l.length + 1;
    //}

    $.fn.treeGetLeafChildren = function (params) {

        var nodes = [];

        $(params).next().children().children("div.tree-node").each(function () {

            nodes.push($(this[0]).tree('getNode', this));

        });
        return nodes;
    }

    /*****************************结束 easyui - comobox***************************/
})(jQuery);


