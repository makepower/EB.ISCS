using System;
using System.Collections.Generic;

namespace EB.ISCS.ToolService.Adapter
{
    /// <summary>  
    /// AccessToken，及sessionKey实体类  
    /// </summary>  
    public class AccessToken
    {
        public string taobao_user_nick { get; set; }
        public string re_expires_in { get; set; }
        public string sub_taobao_user_id { get; set; }
        public string expires_in { get; set; }
        public string expire_time { get; set; }
        public string r1_expires_in { get; set; }
        public string w2_valid { get; set; }
        public string w2_expires_in { get; set; }
        public string taobao_user_id { get; set; }
        public string w1_expires_in { get; set; }
        public string sub_taobao_user_nick { get; set; }
        public string r1_valid { get; set; }
        public string r2_valid { get; set; }
        public string w1_valid { get; set; }
        public string r2_expires_in { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public string refresh_token_valid_time { get; set; }
        public string access_token { get; set; }
    }
    #region 淘宝返回信息类  
    public class TaoBaoReturnMessage
    {
        public trades_sold_get_response trades_sold_get_response { get; set; }
    }

    public class trades_sold_get_response
    {
        /// <summary>  
        /// 返回数据总数  
        /// </summary>  
        public int total_results { get; set; }
        /// <summary>  
        /// 是否存在下页  
        /// </summary>  
        public bool has_next { get; set; }
        /// <summary>  
        /// 订单交易详情  
        /// </summary>  
        public trades trades { get; set; }
    }
    public class trades
    {
        /// <summary>  
        /// 交易集合  
        /// </summary>  
        public List<trade> trade { get; set; }
    }
    /// <summary>  
    /// 交易详情类  
    /// </summary>  
    public class trade
    {
        /// <summary>  
        /// 用户昵称  
        /// </summary>  
        public string seller_nick { get; set; }
        /// <summary>  
        /// 图片链接  
        /// </summary>  
        public string pic_path { get; set; }
        /// <summary>  
        /// 实付金额  
        /// </summary>  
        public string payment { get; set; }
        /// <summary>  
        /// 是否已评价  
        /// </summary>  
        public bool seller_rate { get; set; }
        /// <summary>  
        /// 邮费  
        /// </summary>  
        public string post_fee { get; set; }
        /// <summary>  
        /// 收货人的姓名  
        /// </summary>  
        public string receiver_name { get; set; }
        /// <summary>  
        /// 收货人省份  
        /// </summary>  
        public string receiver_state { get; set; }
        /// <summary>  
        /// 收货人的详细地址  
        /// </summary>  
        public string receiver_address { get; set; }
        /// <summary>  
        /// 收货人的邮编  
        /// </summary>  
        public string receiver_zip { get; set; }
        /// <summary>  
        /// 收货人的手机号码  
        /// </summary>  
        public string receiver_mobile { get; set; }
        /// <summary>  
        /// 收货人的电话号码  
        /// </summary>  
        public string receiver_phone { get; set; }
        /// <summary>  
        /// 卖家发货时间  
        /// </summary>  
        public DateTime consign_time { get; set; }
        /// <summary>  
        /// 卖家实际收到的支付宝打款金额  
        /// </summary>  
        public string received_payment { get; set; }
        /// <summary>  
        /// 收货人国籍  
        /// </summary>  
        public string receiver_country { get; set; }
        /// <summary>  
        /// 收货人街道地址  
        /// </summary>  
        public string receiver_town { get; set; }
        /// <summary>  
        /// 天猫国际官网直供主订单关税税费  
        /// </summary>  
        public string order_tax_fee { get; set; }
        /// <summary>  
        /// 门店自提，总店发货，分店取货的门店自提订单标识  
        /// </summary>  
        public string shop_pick { get; set; }
        /// <summary>  
        /// 交易编号 (父订单的交易编号)  
        /// </summary>  
        public string tid { get; set; }
        /// <summary>  
        /// 商品购买数量。  
        /// </summary>  
        public int num { get; set; }
        /// <summary>  
        /// 商品数字编号  
        /// </summary>  
        public string num_iid { get; set; }
        /// <summary>  
        /// 交易状态。可选值: * TRADE_NO_CREATE_PAY(没有创建支付宝交易) * WAIT_BUYER_PAY(等待买家付款) * SELLER_CONSIGNED_PART(卖家部分发货) * WAIT_SELLER_SEND_GOODS(等待卖家发货,即:买家已付款) * WAIT_BUYER_CONFIRM_GOODS(等待买家确认收货,即:卖家已发货) * TRADE_BUYER_SIGNED(买家已签收,货到付款专用) * TRADE_FINISHED(交易成功) * TRADE_CLOSED(付款以后用户退款成功，交易自动关闭) * TRADE_CLOSED_BY_TAOBAO(付款以前，卖家或买家主动关闭交易) * PAY_PENDING(国际信用卡支付付款确认中) * WAIT_PRE_AUTH_CONFIRM(0元购合约中)  
        /// </summary>  
        public string status { get; set; }
        /// <summary>  
        /// 交易标题，以店铺名作为此标题的值  
        /// </summary>  
        public string title { get; set; }
        /// <summary>  
        /// 交易类型列表，同时查询多种交易类型可用逗号分隔。默认同时查询guarantee_trade, auto_delivery, ec, cod的4种交易类型的数据 可选值 fixed(一口价) auction(拍卖) guarantee_trade(一口价、拍卖) auto_delivery(自动发货) independent_simple_trade(旺店入门版交易) independent_shop_trade(旺店标准版交易) ec(直冲) cod(货到付款) fenxiao(分销) game_equipment(游戏装备) shopex_trade(ShopEX交易) netcn_trade(万网交易) external_trade(统一外部交易)o2o_offlinetrade（O2O交易）step (万人团)nopaid(无付款订单)pre_auth_type(预授权0元购机交易)  
        /// </summary>  
        public string type { get; set; }
        /// <summary>  
        /// 商品价格。精确到2位小数；单位：元。如：200.07，表示：200元7分  
        /// </summary>  
        public string price { get; set; }
        /// <summary>  
        /// 优惠金额  
        /// </summary>  
        public string discount_fee { get; set; }
        /// <summary>  
        /// 商品金额  
        /// </summary>  
        public string total_fee { get; set; }
        /// <summary>  
        /// 交易创建时间  
        /// </summary>  
        public DateTime created { get; set; }
        /// <summary>  
        /// 付款时间  
        /// </summary>  
        public DateTime pay_time { get; set; }
        /// <summary>  
        /// 交易修改时间  
        /// </summary>  
        public DateTime modified { get; set; }
        /// <summary>  
        /// 交易结束时间  
        /// </summary>  
        public DateTime end_time { get; set; }
        /// <summary>  
        /// 卖家备注旗帜  
        /// </summary>  
        public string seller_flag { get; set; }
        /// <summary>  
        /// 买家昵称  
        /// </summary>  
        public string buyer_nick { get; set; }
        /// <summary>  
        /// 判断订单是否有买家留言，有买家留言返回true，否则返回false  
        /// </summary>  
        public bool has_buyer_message { get; set; }
        /// <summary>  
        /// 使用信用卡支付金额数  
        /// </summary>  
        public string credit_card_fee { get; set; }
        /// <summary>  
        /// 分阶段付款的订单状态（例如万人团订单等），目前有三返回状态FRONT_NOPAID_FINAL_NOPAID(定金未付尾款未付)，FRONT_PAID_FINAL_NOPAID(定金已付尾款未付)，FRONT_PAID_FINAL_PAID(定金和尾款都付)  
        /// </summary>  
        public string step_trade_status { get; set; }
        /// <summary>  
        /// 分阶段付款的已付金额（万人团订单已付金额）  
        /// </summary>  
        public string step_paid_fee { get; set; }
        /// <summary>  
        /// 订单出现异常问题的时候，给予用户的描述,没有异常的时候，此值为空  
        /// </summary>  
        public string mark_desc { get; set; }
        /// <summary>  
        /// 创建交易时的物流方式（交易完成前，物流方式有可能改变，但系统里的这个字段一直不变）。可选值：free(卖家包邮),post(平邮),express(快递),ems(EMS),virtual(虚拟发货)，25(次日必达)，26(预约配送)。  
        /// </summary>  
        public string shipping_type { get; set; }
        /// <summary>  
        /// 卖家手工调整金额，精确到2位小数，单位：元。如：200.07，表示：200元7分。来源于订单价格修改，如果有多笔子订单的时候，这个为0，单笔的话则跟[order].adjust_fee一样  
        /// </summary>  
        public string adjust_fee { get; set; }
        /// <summary>  
        /// 交易内部来源。WAP(手机);HITAO(嗨淘);TOP(TOP平台);TAOBAO(普通淘宝);JHS(聚划算)一笔订单可能同时有以上多个标记，则以逗号分隔  
        /// </summary>  
        public string trade_from { get; set; }
        /// <summary>  
        /// 服务子订单列表  
        /// </summary>  
        public service_orders service_orders { get; set; }
        /// <summary>  
        /// 订单列表  
        /// </summary>  
        public orders orders { get; set; }
        /// <summary>  
        /// 买家是否已评价。可选值:true(已评价),false(未评价)。如买家只评价未打分，此字段仍返回false  
        /// </summary>  
        public bool buyer_rate { get; set; }
        /// <summary>  
        /// 收货人的所在城市  
        /// </summary>  
        public string receiver_city { get; set; }
        /// <summary>  
        /// 收货人的所在地区  
        /// </summary>  
        public string receiver_district { get; set; }
        /// <summary>  
        /// 导购宝=crm  
        /// </summary>  
        public string o2o { get; set; }
        /// <summary>  
        /// 导购员id  
        /// </summary>  
        public string o2o_guide_id { get; set; }
        /// <summary>  
        /// 导购员门店id  
        /// </summary>  
        public string o2o_shop_id { get; set; }
        /// <summary>  
        /// 导购员名称  
        /// </summary>  
        public string o2o_guide_name { get; set; }
        /// <summary>  
        /// 导购门店名称  
        /// </summary>  
        public string o2o_shop_name { get; set; }
        /// <summary>  
        /// 导购宝提货方式，inshop：店内提货，online：线上发货  
        /// </summary>  
        public string o2o_delivery { get; set; }
        /// <summary>  
        /// 处方药未审核状态  
        /// </summary>  

        public string rx_audit_status { get; set; }
        /// <summary>  
        /// 邮关订单  
        /// </summary>  
        public bool post_gate_declare { get; set; }
        /// <summary>  
        /// 跨境订单  
        /// </summary>  
        public bool cross_bonded_declare { get; set; }
    }

    /// <summary>  
    /// 服务订单集合  
    /// </summary>  
    public class service_orders
    {
        public List<service_order> service_order { get; set; }
    }
    /// <summary>  
    /// 服务订单详情  
    /// </summary>  
    public class service_order
    {
        /// <summary>  
        /// /虚拟服务子订单订单号  
        /// </summary>  
        public string oid { get; set; }
        /// <summary>  
        /// 服务所属的交易订单号。如果服务为一年包换，则item_oid这笔订单享受改服务的保护  
        /// </summary>  
        public string item_oid { get; set; }
        /// <summary>  
        /// 服务数字id  
        /// </summary>  
        public string service_id { get; set; }
        /// <summary>  
        /// 服务详情的URL地址  
        /// </summary>  
        public string service_detail_url { get; set; }
        /// <summary>  
        /// 购买数量，取值范围为大于0的整数  
        /// </summary>  
        public string num { get; set; }
        /// <summary>  
        /// 服务价格，精确到小数点后两位：单位:元  
        /// </summary>  
        public string price { get; set; }
        /// <summary>  
        /// 子订单实付金额。精确到2位小数，单位:元。如:200.07，表示:200元7分。  
        /// </summary>  
        public string payment { get; set; }
        /// <summary>  
        /// 滚筒洗衣机商品名称  
        /// </summary>  
        public string title { get; set; }
        /// <summary>  
        /// 服务子订单总费用  
        /// </summary>  
        public string total_fee { get; set; }
        /// <summary>  
        /// 卖家昵称  
        /// </summary>  
        public string buyer_nick { get; set; }
        /// <summary>  
        /// 最近退款的id  
        /// </summary>  
        public string refund_id { get; set; }
        /// <summary>  
        /// 卖家昵称  
        /// </summary>  
        public string seller_nick { get; set; }
        /// <summary>  
        /// 服务图片地址  
        /// </summary>  
        public string pic_path { get; set; }
        /// <summary>  
        /// 服务支持家装类物流的类型  
        /// </summary>  
        public string tmser_spu_code { get; set; }
    }
    /// <summary>  
    /// 订单  
    /// </summary>  
    public class orders
    {
        public List<order> order { get; set; }
    }
    /// <summary>  
    /// 订单详情  
    /// </summary>  
    public class order
    {
        public string item_meal_name { get; set; }
        /// <summary>  
        /// 商品图片的绝对路径  
        /// </summary>  
        public string pic_path { get; set; }
        /// <summary>  
        /// 卖家昵称  
        /// </summary>  
        public string seller_nick { get; set; }
        /// <summary>  
        /// 买家昵称  
        /// </summary>  
        public string buyer_nick { get; set; }
        /// <summary>  
        /// SUCCESS(退款成功)退款状态。退款状态。可选值 WAIT_SELLER_AGREE(买家已经申请退款，等待卖家同意) WAIT_BUYER_RETURN_GOODS(卖家已经同意退款，等待买家退货) WAIT_SELLER_CONFIRM_GOODS(买家已经退货，等待卖家确认收货) SELLER_REFUSE_BUYER(卖家拒绝退款) CLOSED(退款关闭) SUCCESS(退款成功)  
        /// </summary>  
        public string refund_status { get; set; }
        /// <summary>  
        /// 商家外部编码(可与商家外部系统对接)。外部商家自己定义的商品Item的id，可以通过taobao.items.custom.get获取商品的Item的信息  
        /// </summary>  
        public string outer_iid { get; set; }
        /// <summary>  
        /// 订单快照URL  
        /// </summary>  
        public string snapshot_url { get; set; }
        /// <summary>  
        /// 自定义值订单快照详细信息  
        /// </summary>  
        public string snapshot { get; set; }
        /// <summary>  
        /// 订单超时到期时间。格式:yyyy-MM-dd HH:mm:ss  
        /// </summary>  
        public DateTime timeout_action_time { get; set; }
        /// <summary>  
        /// 买家是否已评价。可选值：true(已评价)，false(未评价)  
        /// </summary>  
        public bool buyer_rate { get; set; }
        /// <summary>  
        /// 卖家是否已评价。可选值：true(已评价)，false(未评价)  
        /// </summary>  
        public bool seller_rate { get; set; }
        /// <summary>  
        /// 卖家类型，可选值为：B（商城商家），C（普通卖家）  
        /// </summary>  
        public string seller_type { get; set; }
        /// <summary>  
        /// 交易商品对应的类目ID  
        /// </summary>  
        public string cid { get; set; }
        /// <summary>  
        /// 天猫国际官网直供子订单关税税费  
        /// </summary>  
        public string sub_order_tax_fee { get; set; }
        /// <summary>  
        /// 天猫国际官网直供子订单关税税率  
        /// </summary>  
        public string sub_order_tax_rate { get; set; }
        /// <summary>  
        /// 子订单编号  
        /// </summary>  
        public string oid { get; set; }
        /// <summary>  
        /// TRADE_NO_CREATE_PAY订单状态（请关注此状态，如果为TRADE_CLOSED_BY_TAOBAO状态，则不要对此订单进行发货，切记啊！）。可选值:  
        ///TRADE_NO_CREATE_PAY(没有创建支付宝交易) WAIT_BUYER_PAY(等待买家付款) WAIT_SELLER_SEND_GOODS(等待卖家发货,即:买家已付款) WAIT_BUYER_CONFIRM_GOODS(等待买家确认收货,即:卖家已发货) TRADE_BUYER_SIGNED(买家已签收,货到付款专用) TRADE_FINISHED(交易成功) TRADE_CLOSED(付款以后用户退款成功，交易自动关闭) TRADE_CLOSED_BY_TAOBAO(付款以前，卖家或买家主动关闭交易)PAY_PENDING(国际信用卡支付付款确认中)  
        /// </summary>  
        public string status { get; set; }
        /// <summary>  
        /// 商品标题  
        /// </summary>  
        public string title { get; set; }
        /// <summary>  
        /// 交易类型  
        /// </summary>  
        public string type { get; set; }
        /// <summary>  
        /// 商品的字符串编号(注意：iid近期即将废弃，请用num_iid参数)  
        /// </summary>  
        public string iid { get; set; }
        /// <summary>  
        /// 商品价格。精确到2位小数;单位:元。如:200.07，表示:200元7分  
        /// </summary>  
        public string price { get; set; }
        /// <summary>  
        /// 商品数字ID  
        /// </summary>  
        public string num_iid { get; set; }
        /// <summary>  
        /// 套餐ID  
        /// </summary>  
        public string item_meal_id { get; set; }
        /// <summary>  
        /// 商品的最小库存单位Sku的id.可以通过taobao.item.sku.get获取详细的Sku信息  
        /// </summary>  
        public string sku_id { get; set; }
        /// <summary>  
        /// 购买数量。取值范围:大于零的整数  
        /// </summary>  
        public int num { get; set; }
        /// <summary>  
        /// 外部网店自己定义的Sku编号  
        /// </summary>  
        public string outer_sku_id { get; set; }
        /// <summary>  
        /// 子订单来源,如jhs(聚划算)、taobao(淘宝)、wap(无线)  
        /// </summary>  
        public string order_from { get; set; }
        /// <summary>  
        /// 应付金额（商品价格 * 商品数量 + 手工调整金额 - 子订单级订单优惠金额）。精确到2位小数;单位:元。如:200.07，表示:200元7分  
        /// </summary>  
        public string total_fee { get; set; }
        /// <summary>  
        /// 子订单实付金额。精确到2位小数，单位:元。如:200.07，表示:200元7分。对于多子订单的交易，计算公式如下：payment = price * num + adjust_fee - discount_fee ；单子订单交易，payment与主订单的payment一致，对于退款成功的子订单，由于主订单的优惠分摊金额，会造成该字段可能不为0.00元。建议使用退款前的实付金额减去退款单中的实际退款金额计算。  
        /// </summary>  
        public string payment { get; set; }
        /// <summary>  
        /// 子订单级订单优惠金额。精确到2位小数;单位:元。如:200.07，表示:200元7分  
        /// </summary>  
        public string discount_fee { get; set; }
        /// <summary>  
        /// 手工调整金额.格式为:1.01;单位:元;精确到小数点后两位.  
        /// </summary>  
        public string adjust_fee { get; set; }
        /// <summary>  
        /// 订单修改时间，目前只有taobao.trade.ordersku.update会返回此字段。  
        /// </summary>  
        public DateTime modified { get; set; }
        /// <summary>  
        /// 颜色:桔色;尺码:MSKU的值。如：机身颜色:黑色;手机套餐:官方标配  
        /// </summary>  
        public string sku_properties_name { get; set; }
        /// <summary>  
        /// 最近退款ID  
        /// </summary>  
        public string refund_id { get; set; }
        /// <summary>  
        /// 是否超卖  
        /// </summary>  
        public bool is_oversold { get; set; }
        /// <summary>  
        /// 是否是服务订单，是返回true，否返回false。  
        /// </summary>  
        public string is_service_order { get; set; }
        /// <summary>  
        /// 子订单的交易结束时间说明：子订单有单独的结束时间，与主订单的结束时间可能有所不同，在有退款发起的时候或者是主订单分阶段付款的时候，子订单的结束时间会早于主订单的结束时间，所以开放这个字段便于订单结束状态的判断  
        /// </summary>  
        public DateTime end_time { get; set; }
        /// <summary>  
        /// 子订单发货时间，当卖家对订单进行了多次发货，子订单的发货时间和主订单的发货时间可能不一样了，那么就需要以子订单的时间为准。（没有进行多次发货的订单，主订单的发货时间和子订单的发货时间都一样）  
        /// </summary>  
        public DateTime consign_time { get; set; }
        /// <summary>  
        /// 子订单的运送方式（卖家对订单进行多次发货之后，一个主订单下的子订单的运送方式可能不同，用order.shipping_type来区分子订单的运送方式）  
        /// </summary>  
        public string shipping_type { get; set; }
        /// <summary>  
        /// 捆绑的子订单号，表示该子订单要和捆绑的子订单一起发货，用于卖家子订单捆绑发货  
        /// </summary>  
        public string bind_oid { get; set; }
        /// <summary>  
        /// 顺风快递子订单发货的快递公司名称  
        /// </summary>  
        public string logistics_company { get; set; }
        /// <summary>  
        /// 子订单所在包裹的运单号  
        /// </summary>  
        public string invoice_no { get; set; }
        /// <summary>  
        /// 表示订单交易是否含有对应的代销采购单。如果该订单中存在一个对应的代销采购单，那么该值为true；反之，该值为false。  
        /// </summary>  
        public bool is_daixiao { get; set; }
        /// <summary>  
        /// /分摊之后的实付金额  
        /// </summary>  
        public string divide_order_fee { get; set; }
        /// <summary>  
        /// 优惠分摊  
        /// </summary>  
        public string part_mjz_discount { get; set; }
        /// <summary>  
        /// 对应门票有效期的外部id  
        /// </summary>  
        public string ticket_outer_id { get; set; }
        /// <summary>  
        /// 门票有效期的key  
        /// </summary>  
        public string ticket_expdate_key { get; set; }
        /// <summary>  
        /// 发货的仓库编码  
        /// </summary>  
        public string store_code { get; set; }
        /// <summary>  
        /// 子订单是否是www订单  
        /// </summary>  
        public bool is_www { get; set; }
        /// <summary>  
        /// 服务支持家装类物流的类型  
        /// </summary>  
        public string tmser_spu_code { get; set; }
        /// <summary>  
        /// bind_oid字段的升级，支持返回绑定的多个子订单，多个子订单以半角逗号分隔  
        /// </summary>  
        public string bind_oids { get; set; }
        /// <summary>  
        /// 征集预售订单征集状态：1（征集中），2（征集成功），3（征集失败）  
        /// </summary>  
        public string zhengji_status { get; set; }
        /// <summary>  
        /// 免单原因免单资格属性  
        /// </summary>  
        public string md_qualification { get; set; }
        /// <summary>  
        /// 免单金额  
        /// </summary>  
        public string md_fee { get; set; }
        /// <summary>  
        /// 定制信息  
        /// </summary>  
        public string customization { get; set; }
        /// <summary>  
        /// 库存类型：6为在途  
        /// </summary>  
        public string inv_type { get; set; }
        public string xxx { get; set; }
        /// <summary>  
        /// 是否发货  
        /// </summary>  
        public bool is_sh_ship { get; set; }
        /// <summary>  
        /// 仓储信息  
        /// </summary>  
        public string shipper { get; set; }
        /// <summary>  
        /// 订单履行类型，如喵鲜生极速达（jsd）  
        /// </summary>  
        public string f_type { get; set; }
        /// <summary>  
        /// 分单完成订单履行状态，如喵鲜生极速达：分单完成  
        /// </summary>  
        public string f_status { get; set; }
        /// <summary>  
        /// 单履行内容，如喵鲜生极速达：storeId,phone  
        /// </summary>  
        public string f_term { get; set; }
    }
    #endregion
}
