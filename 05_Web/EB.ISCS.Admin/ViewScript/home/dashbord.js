// =======================map-start==========================
var map_chart = echarts.init(document.getElementById('main_map'));
var itemStyle = {
    normal: {
        borderColor: 'rgba(255, 255, 255, 1)',
        borderWidth:2,
        areaColor: 'transparent',
        color: 'transparent',
        label: {
            show: false,
            textStyle:{
                  color:'#fff'
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
            textStyle:{
                color:'#fff'
            }
        }
    }
};
map_chart.setOption({
    tooltip: {},
    title: {
        text: '网店宝数据分析平台',
        left: 'center',
        textStyle: {
            fontSize: 20,
            fontWeight: 'bolder',
            color: '#fff'          // 主标题文字颜色
        },
        subtextStyle: {
            color: '#fff'          // 副标题文字颜色
        }
    },
    selectedMode: 'single',

    series: [
        {
            name: '销售额',
            type: 'map',
            map: 'china',
            itemStyle: itemStyle,
            showLegendSymbol: true,
            roam: false,
            data: [
                {name: '北京', value: Math.round(Math.random() * 1000)},
                {name: '天津', value: Math.round(Math.random() * 1000)},
                {name: '上海', value: Math.round(Math.random() * 1000)},
                {name: '重庆', value: Math.round(Math.random() * 1000)},
                {name: '河北', value: Math.round(Math.random() * 1000)},
                {name: '河南', value: Math.round(Math.random() * 1000)},
                {name: '云南', value: Math.round(Math.random() * 1000)},
                {name: '辽宁', value: Math.round(Math.random() * 1000)},
                {name: '黑龙江', value: Math.round(Math.random() * 1000)},
                {name: '湖南', value: Math.round(Math.random() * 1000)},
                {name: '安徽', value: Math.round(Math.random() * 1000)},
                {name: '山东', value: Math.round(Math.random() * 1000)},
                {name: '新疆', value: Math.round(Math.random() * 1000)},
                {name: '江苏', value: Math.round(Math.random() * 1000)},
                {name: '浙江', value: Math.round(Math.random() * 1000)},
                {name: '江西', value: Math.round(Math.random() * 1000)},
                {name: '湖北', value: Math.round(Math.random() * 1000)},
                {name: '广西', value: Math.round(Math.random() * 1000)},
                {name: '甘肃', value: Math.round(Math.random() * 1000)},
                {name: '山西', value: Math.round(Math.random() * 1000)},
                // {name: '内蒙古',value: Math.round(Math.random()*1000)},
                {name: '陕西', value: Math.round(Math.random() * 1000)},
                {name: '吉林', value: Math.round(Math.random() * 1000)},
                {name: '福建', value: Math.round(Math.random() * 1000)},
                {name: '贵州', value: Math.round(Math.random() * 1000)},
                {name: '广东', value: Math.round(Math.random() * 1000)},
                // {name: '青海',value: Math.round(Math.random()*1000)},
                {name: '西藏', value: Math.round(Math.random() * 1000)},
                {name: '四川', value: Math.round(Math.random() * 1000)},
                {name: '宁夏', value: Math.round(Math.random() * 1000)},
                {name: '海南', value: Math.round(Math.random() * 1000)},
                {name: '台湾', value: Math.round(Math.random() * 1000)},
                {name: '香港', value: Math.round(Math.random() * 1000)},
                {name: '澳门', value: Math.round(Math.random() * 1000)}
            ]
        }
    ]
});
//=======================map-end===========================

//==========================char-topn-start=====================
// 基于准备好的dom，初始化echarts实例

var chart_topn = echarts.init(document.getElementById('main_line_1'));

// 使用刚指定的配置项和数据显示图表。
chart_topn.setOption({
    title: {
        text: '最近30天销售金额',
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
        data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"],
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
        type: 'line',
        data: [5, 20, 36, 10, 10, 20]
    }]
});

var chart_topn_2 = echarts.init(document.getElementById('main_line_2'), 'bluecast');

// 使用刚指定的配置项和数据显示图表。
chart_topn_2.setOption({
    title: {
        text: '滞销商品',
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
        data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"],
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
        }},
    series: [{
        name: '销量',
        type: 'bar',
        data: [5, 20, 36, 10, 10, 20]
    }]
});

var chart_topn_3 = echarts.init(document.getElementById('main_line_3'), 'shine');

// 使用刚指定的配置项和数据显示图表。
chart_topn_3.setOption({
    title: {
        text: '销售榜单',
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
            data: ['狗头枣', '小麦', '牛奶', '尿布', '辣条'],
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
            data: [2.0, 4.9, 7.0, 23.2, 25.6]
        }
    ]
});
//==========================chart-topn-end=====================

//==========================char-topn-start=====================
// 基于准备好的dom，初始化echarts实例
var chart_30days = echarts.init(document.getElementById('main_1'));

// 使用刚指定的配置项和数据显示图表。
chart_30days.setOption({
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
        data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日'],
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
            formatter: '{value} °C',
            textStyle:{
                color:'#fff'
            }
        }
    },
    series: [
        {
            name: '京东',
            type: 'line',
            data: [11, 11, 15, 13, 12, 13, 10]
        },
        {
            name: '阿里',
            type: 'line',
            data: [1, -2, 2, 5, 3, 2, 0]
        }
    ]
});

//==========================chart-topn-end=====================


//==========================char-topn-start=====================
// 基于准备好的dom，初始化echarts实例
var chart_order = echarts.init(document.getElementById('main_2_1'));

// 使用刚指定的配置项和数据显示图表。
chart_order.setOption({
    title: {
        text: '订单转化情况',
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
        formatter: "{a} <br/>{b} : {c}%"
    },
    calculable: true,
    series: [
        {
            name: '漏斗图',
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
            data: [
                {value: 60, name: '访问'},
                {value: 40, name: '咨询'},
                {value: 20, name: '订单'},
                {value: 80, name: '点击'},
                {value: 100, name: '展现'}
            ]
        }
    ]
});

var chart_pay = echarts.init(document.getElementById('main_2_2'));

// 使用刚指定的配置项和数据显示图表。
chart_pay.setOption({
    title: {
        text: '付款渠道',
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
        data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"],
        axisLabel: {
            show: true,
            textStyle: {
                color: '#fff'
            }
        }
    },
    yAxis: {axisLabel: {
            show: true,
            textStyle: {
                color: '#fff'
            }
        }},
    series: [{
        name: '销量',
        type: 'bar',
        data: [5, 20, 36, 10, 10, 20]
    }]
});
//==========================chart-topn-end=====================


//==========================char-topn-start=====================
// 基于准备好的dom，初始化echarts实例
var chart_orderstate = echarts.init(document.getElementById('main_3'));

// 使用刚指定的配置项和数据显示图表。
chart_orderstate.setOption({
    title: {
        text: '近30天订单状态',
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
        data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"],
        axisLabel: {
            show: true,
            textStyle: {
                color: '#fff'
            }
        }
    },
    yAxis: {axisLabel: {
            show: true,
            textStyle: {
                color: '#fff'
            }
        }},
    series: [{
        name: '销量',
        type: 'bar',
        data: [5, 20, 36, 10, 10, 20]
    }]
});

//==========================chart-topn-end=====================

//==========================char-topn-start=====================
// 基于准备好的dom，初始化echarts实例
var chart_custom = echarts.init(document.getElementById('main_4_1'));

// 使用刚指定的配置项和数据显示图表。
chart_custom.setOption({
    title: {
        text: '成交客户分析',
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
        formatter: "{a} <br/>{b}: {c} ({d}%)"
    },
    series: [
        {
            name: '访问来源',
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
            data: [
                {value: 335, name: '直接访问'},
                {value: 310, name: '邮件营销'},
                {value: 234, name: '联盟广告'},
                {value: 135, name: '视频广告'},
                {value: 1548, name: '搜索引擎'}
            ]
        }
    ]
});

var chart_custom_address = echarts.init(document.getElementById('main_4_2'));

// 使用刚指定的配置项和数据显示图表。
chart_custom_address.setOption({
    title: {
        text: '客户地址位置分析',
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
        data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"],
        axisLabel: {
            show: true,
            textStyle: {
                color: '#fff'
            }
        }
    },
    yAxis: {axisLabel: {
            show: true,
            textStyle: {
                color: '#fff'
            }
        }},
    series: [{
        name: '销量',
        type: 'bar',
        data: [5, 20, 36, 10, 10, 20]
    }]
});

//==========================chart-topn-end=====================

//==========================char-topn-start=====================
// 基于准备好的dom，初始化echarts实例
var chart_logistics_time = echarts.init(document.getElementById('main_5_1'));

// 使用刚指定的配置项和数据显示图表。
chart_logistics_time.setOption({
    title: {
        text: '各环节供应时间',
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
        formatter: "{a} <br/>{b}: {c} ({d}%)"
    },
    series: [
        {
            name: '访问来源',
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
            data: [
                {value: 335, name: '直接访问'},
                {value: 310, name: '邮件营销'},
                {value: 234, name: '联盟广告'},
                {value: 135, name: '视频广告'},
                {value: 1548, name: '搜索引擎'}
            ]
        }
    ]
});

var chart_logistics = echarts.init(document.getElementById('main_5_2'));

// 使用刚指定的配置项和数据显示图表。
chart_logistics.setOption({
    title: {
        text: '物流花费时间',
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
        data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"],
        axisLabel: {
            show: true,
            textStyle: {
                color: '#fff'
            }
        }
    },
    yAxis: {axisLabel: {
            show: true,
            textStyle: {
                color: '#fff'
            }
        }},
    series: [{
        name: '销量',
        type: 'bar',
        data: [5, 20, 36, 10, 10, 20]
    }]
});
//==========================chart-topn-end=====================


//==========================char-topn-start=====================
// 基于准备好的dom，初始化echarts实例
var chart_monthcomplain = echarts.init(document.getElementById('main_6_1'));

// 使用刚指定的配置项和数据显示图表。
chart_monthcomplain.setOption({
    title: {
        text: '各月投诉率',
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
        data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"],
        axisLabel: {
            show: true,
            textStyle: {
                color: '#fff'
            }
        }
    },
    yAxis: {axisLabel: {
            show: true,
            textStyle: {
                color: '#fff'
            }
        }},
    series: [{
        name: '销量',
        type: 'line',
        data: [5, 20, 36, 10, 10, 20]
    }]
});

var chart_complain = echarts.init(document.getElementById('main_6_2'));

// 使用刚指定的配置项和数据显示图表。
chart_complain.setOption({
    title: {
        text: '投诉种类',
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
        data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"],
        axisLabel: {
            show: true,
            textStyle: {
                color: '#fff'
            }
        }
    },
    yAxis: {
        type: 'value',
        axisLabel : {
            formatter: '{value}',
            textStyle: {
                color: '#fff'
            }
        }},
    series: [{
        name: '销量',
        type: 'line',
        smooth: true,
        data: [5, 2, 26, 8, 35, 20]
    }]
});
//==========================chart-topn-end=====================


var titleoption = function (title, subtitle) {
    return {
        text: title,
        subtext: subtitle,
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
    }
}

//公共函数库
var comChartControl = (function (jq) {
    return {
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
        }
    }
})(jQuery);
