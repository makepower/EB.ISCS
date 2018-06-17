var eBchartOption = {
    // =======================map-option-start==========================
    mapItemStyle: {
        normal: {
            borderColor: 'rgba(255, 255, 255, 1)',
            borderWidth: 2,
            areaColor: 'transparent',
            color: 'transparent',
            label: {
                show: false,
                textStyle: {
                    color: '#fff'
                }
            }
        },
        emphasis: {
            shadowOffsetX: 2,
            shadowOffsetY: 2,
            shadowBlur: 20,
            borderWidth: 1,
            shadowColor: 'rgba(5, 5, 0, 0.5)',
            label: {
                show: true,
                textStyle: {
                    color: '#fff'
                }
            }
        }
    },
    mapOption: function (d) {
        return {
            tooltip: {},
            title: {
                text: '网店鹰眼数据分析平台',
                subtext: '全国订单分布'+d.Tag,
                left: 'center',
                textStyle: {
                    fontSize: 20,
                    fontWeight: 'bolder',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    fontSize: 12,
                    color: '#fff'          // 副标题文字颜色
                }
            },
            selectedMode: 'single',
            dataRange: {
                x: 'left',
                y: 'bottom',
                splitList: [
                    { start: 1500 },
                    { start: 500, end: 1500 },
                    { start: 200, end: 500 },
                    { end: 200 }
                ],
                color: ['#eee', '#949fb1', '#f3ce85'],
                textStyle: {
                    color: '#fff'          // 值域文字颜色
                }
            },
            series: [
                {
                    name: '销售额',
                    type: 'map',
                    map: 'china',
                    itemStyle: eBchartOption.mapItemStyle,
                    showLegendSymbol: true,
                    roam: true,
                    data: d.Series[0]
                }
            ]
        }
    },
    //=======================map-option-end===========================


    //==========================char-topn-bottom-sell-start=====================
    //==sell for 30days==
    sellMoneyOption: function (d) {
        return {
            title: {
                text: '最近30天销售金额' + d.Tag,
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {},
            // 网格
            grid: {
                backgroundColor: 'rgba(0,0,0,0)',
                borderWidth: 1,
                borderColor: '#ccc'
            },
            xAxis: {
                data: d.XAxis,
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            yAxis: {
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            series: [{
                name: '金额(元)',
                type: 'line',
                data: d.Series[0]
            }]
        }
    },
    // ==bottom N==
    bottomOption: function (d) {
        return {
            title: {
                text: '滞销商品' + d.Tag,
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {},
            // 网格
            grid: {
                backgroundColor: 'rgba(0,0,0,0)',
                borderWidth: 1,
                borderColor: '#ccc'
            },
            xAxis: {
                data: d.xAxis,
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            yAxis: {
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            series: [{
                name: '销量',
                type: 'bar',
                data: d.Series[0]
            }]
        }
    },
    // ==top n==
    topNoption: function (d) {
        return {
            title: {
                text: '销售榜单' + d.Tag,
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {
                trigger: 'axis'
            },
            calculable: true,
            xAxis: [
                {
                    type: 'category',
                    data: d.XAxis,
                    axisLabel: {
                        show: true,
                        textStyle: {
                            color: '#fff'
                        }
                    }
                }
            ],
            yAxis: [
                {
                    type: 'value',
                    axisLabel: {
                        show: true,
                        textStyle: {
                            color: '#fff'
                        }
                    }
                }
            ],
            series: [
                {
                    name: '销售',
                    type: 'bar',
                    data: d.Series[0]
                }
            ]
        }
    },
    //==========================char-topn-bottom-sell--end=====================


    //==========================char-30days-flow-start=====================
    flowOption: function (d) {
        return {
            title: {
                text: '',
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {
                trigger: 'axis'
            },
            xAxis: {
                type: 'category',
                boundaryGap: false,
                data: d.XAxis,
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            yAxis: {
                type: 'value',
                axisLabel: {
                    formatter: '{value}',
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            series: [
                {
                    name: '流量',
                    type: 'line',
                    data: d.Series[0]
                }
            ]
        }
    },
    //==========================chart-30days-flow-end=====================


    //==========================char-order-start=====================
    // ==order-trans==
    orderTransOption: function (d) {
        return {
            title: {
                text: '订单转化情况' + d.Tag,
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {
                trigger: 'item',
                formatter: "{b}：{c}"
            },
            calculable: true,
            series: [
                {
                    name: '转化率',
                    type: 'funnel',
                    left: '10%',
                    top: 60,
                    //x2: 80,
                    bottom: 60,
                    width: '80%',
                    // height: {totalHeight} - y - y2,
                    min: 0,
                    max: 100,
                    minSize: '0%',
                    maxSize: '100%',
                    sort: 'descending',
                    gap: 2,
                    label: {
                        normal: {
                            show: true,
                            position: 'right'
                        },
                        emphasis: {
                            textStyle: {
                                fontSize: 20
                            }
                        }
                    },
                    labelLine: {
                        normal: {
                            length: 10,
                            lineStyle: {
                                width: 1,
                                type: 'solid'
                            },
                            show: true
                        }
                    },
                    itemStyle: {
                        normal: {
                            borderColor: '#fff',
                            borderWidth: 1
                        }
                    },
                    data: d.Series[0] // name-value
                }
            ]
        }
    },
    // ==order-paychannel==
    orderPayChannel: function (d) {
        return {
            title: {
                text: '付款渠道' + d.Tag,
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {},
            xAxis: {
                data: d.XAxis,
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            yAxis: {
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            series: [{
                name: '订单数',
                type: 'bar',
                data: d.Series[0]
            }]
        }
    },
    // ==order-status==
    orderStatusOption: function (d) {
        return {
            title: {
                text: '近30天订单状态' + d.Tag,
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {},
            xAxis: {
                data: d.XAxis,
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            yAxis: {
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            series: [{
                name: '订单状态',
                type: 'bar',
                data: d.Series[0]
            }]
        }
    },
    //==========================char-order-end=====================


    //==========================char-customer-start=====================
    //==customerType==
    customerTypeOption: function (d) {
        return {
            title: {
                text: '成交客户分析' + d.Tag,
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {
                trigger: 'item',
                formatter: "{b}:{c}"
            },
            series: [
                {
                    name: '客户类型',
                    type: 'pie',
                    radius: ['30%', '50%'],
                    avoidLabelOverlap: true,
                    label: {
                        normal: {
                            show: true,
                            position: 'right'
                        },
                        emphasis: {
                            show: true,
                            textStyle: {
                                fontSize: '15',
                                fontWeight: 'bold'
                            }
                        }
                    },
                    labelLine: {
                        normal: {
                            show: true
                        }
                    },
                    data: d.Series[0] // name -value
                }
            ]
        }
    },
    //==customerAddr==
    customerAddrOption: function (d) {
        return {
            title: {
                text: '客户地址位置分析' + d.Tag,
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {},
            xAxis: {
                data: d.XAxis,
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            yAxis: {
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            series: [{
                name: '区域来源',
                type: 'bar',
                data: d.Series[0]
            }]
        }
    },
    //==========================char-customer--end=====================


    //==========================char-logistics-start=====================
    //==logisticsTime==
    logisticsTimeOption: function (d) {
        return {
            title: {
                text: '各环节供应时间' + d.Tag,
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {
                trigger: 'item',
                formatter: "{b}:{d}%"
            },
            series: [
                {
                    name: '环节',
                    type: 'pie',
                    radius: ['30%', '50%'],
                    avoidLabelOverlap: true,
                    label: {
                        normal: {
                            show: true,
                            position: 'right'
                        },
                        emphasis: {
                            show: true,
                            textStyle: {
                                fontSize: '30',
                                fontWeight: 'bold'
                            }
                        }
                    },
                    labelLine: {
                        normal: {
                            show: true
                        }
                    },
                    data: d.Series[0]
                }
            ]
        }
    },
    //==logistics==
    logisticsOption: function (d) {
        return {
            title: {
                text: '物流花费时间' + d.Tag,
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {},
            xAxis: {
                data: d.XAxis,
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            yAxis: {
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            series: [{
                name: '物流供应商',
                type: 'bar',
                data: d.Series[0]
            }]
        }
    },
    //==========================chart-logistics-end=====================


    //==========================char-complain-start=====================
    //==complain==
    complainOption: function (d) {
        return {
            title: {
                text: '各月投诉率' + d.Tag,
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#aaa'          // 副标题文字颜色
                }
            },
            tooltip: {},
            xAxis: {
                data: d.XAxis,
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            yAxis: {
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            series: [{
                name: '投诉次数',
                type: 'line',
                data: d.Series[0]
            }]
        }
    },
    //==complainType==
    complainTypeOption: function (d) {
        return {
            title: {
                text: '投诉种类' + d.Tag,
                subtext: '',
                x: 'left',                 // 水平安放位置，默认为左对齐，可选为：
                y: 'top',                  // 垂直安放位置，默认为全图顶端，可选为：
                backgroundColor: 'rgba(0,0,0,0)',
                borderColor: '#ccc',       // 标题边框颜色
                borderWidth: 0,            // 标题边框线宽，单位px，默认为0（无边框）
                padding: 5,                // 标题内边距，单位px，默认各方向内边距为5，
                // 接受数组分别设定上右下左边距，同css
                itemGap: 10,               // 主副标题纵向间隔，单位px，默认为10，
                textStyle: {
                    fontSize: 15,
                    fontWeight: 'normal',
                    color: '#fff'          // 主标题文字颜色
                },
                subtextStyle: {
                    color: '#fff'          // 副标题文字颜色
                }
            },
            tooltip: {},
            xAxis: {
                data: d.XAxis,
                axisLabel: {
                    show: true,
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            yAxis: {
                type: 'value',
                axisLabel: {
                    formatter: '{value}',
                    textStyle: {
                        color: '#fff'
                    }
                }
            },
            series: [{
                name: '投诉种类',
                type: 'line',
                smooth: true,
                data: d.Series[0]
            }]
        }
    }
    //==========================chart-complain-end=====================
}
