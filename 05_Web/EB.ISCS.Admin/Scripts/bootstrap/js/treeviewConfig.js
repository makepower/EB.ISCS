/*


    树形列表配置文件
    依赖文件 
    
    <script src="~/Scripts/bootstrap/js/bootstrap-treeview.js"></script>
    <link href="~/Scripts/bootstrap/css/treeviewConfig.css" rel="stylesheet" />


*/

$(function () {
    $(".choseDepartment").on("click", function () {

        $(".treeview-selectable").toggle();

    });





    var newData = [
        {
            "id": "0",
            "text": "---请选择---",
            "children": null,
            "attributes": null
        },
        {
            "id": "471",
            "text": "陕西XX科技集团",
            "children": [
                {
                    "id": "1",
                    "text": "上海鞅立信息科技有限公司",
                    "children": [
                        {
                            "id": "111",
                            "text": "财务部",
                            "children": [],
                            "attributes": null
                        },
                        {
                            "id": "451",
                            "text": "开发部",
                            "children": [],
                            "attributes": null
                        }
                    ],
                    "attributes": null
                },
                {
                    "id": "101",
                    "text": "西安质盾信息科技有限公司",
                    "children": [
                        {
                            "id": "61",
                            "text": "开发部",
                            "children": [],
                            "attributes": null
                        },
                        {
                            "id": "431",
                            "text": "人事部",
                            "children": [],
                            "attributes": null
                        },
                        {
                            "id": "441",
                            "text": "项目部",
                            "children": [],
                            "attributes": null
                        }
                    ],
                    "attributes": null
                }
            ],
            "attributes": null
        }
    ];


    var defaultData = [
        {
            text: 'Parent 1',
            href: '#parent1',
            tags: ['4'],
            nodes: [
                {
                    text: 'Child 1',
                    href: '#child1',
                    tags: ['2'],
                    nodes: [
                        {
                            text: 'Grandchild 1',
                            href: '#grandchild1',
                            tags: ['0']
                        },
                        {
                            text: 'Grandchild 2',
                            href: '#grandchild2',
                            tags: ['0']
                        }
                    ]
                },
                {
                    text: 'Child 2',
                    href: '#child2',
                    tags: ['0']
                }
            ]
        },
        {
            text: 'Parent 2',
            href: '#parent2',
            tags: ['0']
        },
        {
            text: 'Parent 3',
            href: '#parent3',
            tags: ['0']
        },
        {
            text: 'Parent 4',
            href: '#parent4',
            tags: ['0']
        },
        {
            text: 'Parent 5',
            href: '#parent5',
            tags: ['0']
        }
    ];
    var initSelectableTree = function () {
        return $('.treeview-selectable').treeview({
            data: defaultData,
            multiSelect: true,
            onNodeSelected: function (event, node) {
                //$('#selectable-output').prepend('<p>' + node.text + ' was selected</p>');
                $(".choseDepartment").text(node.text);
                //$(".treeview-selectable").toggle();
                //debugger;
            },
            onNodeUnselected: function (event, node) {
                //$('#selectable-output').prepend('<p>' + node.text + ' was unselected</p>');

            }
        });
    };

    var $selectableTree = initSelectableTree();

    var findSelectableNodes = function () {
        return $selectableTree.treeview('search',
            [$('#input-select-node').val(), { ignoreCase: false, exactMatch: false }]);
    };
    var selectableNodes = findSelectableNodes();

    $('#chk-select-multi:checkbox').on('change',
        function () {
            console.log('multi-select change');
            $selectableTree = initSelectableTree();
            selectableNodes = findSelectableNodes();
        });

    // Select/unselect/toggle nodes
    $('#input-select-node').on('keyup',
        function (e) {
            selectableNodes = findSelectableNodes();
            $('.select-node').prop('disabled', !(selectableNodes.length >= 1));
        });

    $('#btn-select-node.select-node').on('click',
        function (e) {
            $selectableTree.treeview('selectNode',
                [selectableNodes, { silent: $('#chk-select-silent').is(':checked') }]);
        });

    $('#btn-unselect-node.select-node').on('click',
        function (e) {
            $selectableTree.treeview('unselectNode',
                [selectableNodes, { silent: $('#chk-select-silent').is(':checked') }]);
        });

    $('#btn-toggle-selected.select-node').on('click',
        function (e) {
            $selectableTree.treeview('toggleNodeSelected',
                [selectableNodes, { silent: $('#chk-select-silent').is(':checked') }]);
        });




});

