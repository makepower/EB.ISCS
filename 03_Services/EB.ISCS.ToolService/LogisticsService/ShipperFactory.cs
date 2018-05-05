using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.ToolService.LogisticsService
{
    public class ShipperFactory
    {
        const string shiper = @"顺丰速运
, 百世快递
, 中通快递
, 申通快递
, 圆通速递
, 韵达速递
, 邮政快递包裹
, EMS
, 天天快递
, 京东物流
, 优速快递
, 德邦
, 快捷快递
, 宅急送
, TNT快递
, UPS
, DHL
, FEDEX联邦(国内件）
, FEDEX联邦(国际件）
, 安捷快递
, 阿里跨境电商物流
, 安讯物流
, 安邮美国
, 亚马逊物流
, 澳门邮政
, 安能物流
, 澳多多
, 澳邮专线
, 八达通
, 百腾物流
, 北极星快运
, 巴伦支快运
, 奔腾物流
, 百福东方
, 贝海国际
, 北青小红帽
, 八方安运
, 百世快运
, CCES快递
, 春风物流
, 诚通物流
, 出口易
, 传喜物流
, 程光
, 城市100
, 城际快递
, CNPEX中邮快递
, COE东方快递
, 长沙创一
, 成都善途速运
, 联合运通
, 疯狂快递
, CBO钏博物流
, D速物流
, 到了港
, 递四方速递
, 大田物流
, 东骏快捷物流
, 德坤
, E特快
, EWE
, 快服务
, 飞康达
, 富腾达
, 冠达
, 国通快递
, 广东邮政
, 共速达
, 广通
, 迦递快递
, 港快速递
, 高铁速递
, 汇丰物流
, 黑狗冷链
, 恒路物流
, 天地华宇
, 鸿桥供应链
, 海派通物流公司
, 华强物流
, 环球速运
, 华夏龙物流
, 豪翔物流
, 合肥汇文
, 华翰物流
, 辉隆物流
, 华企快递
, 韩润物流
, 青岛恒通快递
, 货运皇物流
, 好来运快递
, 捷安达
, 京广速递
, 九曳供应链
, 佳吉快运
, 嘉里物流
, 捷特快递
, 急先达
, 晋越快递
, 加运美
, 景光物流
, 佳怡物流
, 跨越速运
, 跨越物流
, 快速递物流
, 龙邦快递
, 立即送
, 联昊通速递
, 民邦快递
, 民航快递
, 美快
, 门对门快递
, 迈隆递运
, 明亮物流
, 南方
, 能达速递
, 平安达腾飞快递
, 泛捷快递
, 品骏
, PCA Express
, 全晨快递
, 全峰快递
, 全日通快递
, 快客快递
, 全信通
, 如风达
, 日日顺物流
, 瑞丰速递
, 赛澳递
, 苏宁物流
, 圣安物流
, 盛邦物流
, 上大物流
, 盛丰物流
, 盛辉物流
, 速通物流
, 速腾快递
, 速必达物流
, 速递e站
, 速呈宅配
, 速尔快递
, 台湾邮政
, 唐山申通
, 全一快递
, 优联吉运
, UEQ Express
, 万家康
, 万家物流
, 万象物流
, 武汉同舟行
, 维普恩
, 微特派
, 新邦物流
, 迅驰物流
, 信丰物流
, 希优特
, 新杰物流
, 源安达快递
, 远成物流
, 远成快运
, 义达国际物流
, 易达通
, 越丰物流
, 原飞航物流
, 亚风快递
, 运通快递
, 亿翔快递
, 运东西
, 壹米滴答
, 邮政国内标快
, 一站通速运
, 驭丰速运
, 增益快递
, 汇强快递
, 众通快递
, 中铁快运
, 中铁物流
, 中邮物流
, 郑州速捷
, 中通快运
, AAE全球专递
, 阿里跨境电商物流
, ACS雅仕快递
, ADP Express Tracking
, 安圭拉邮政
, APAC
, Aramex
, 奥地利邮政
, Australia Post Tracking
, 比利时邮政
, BHT快递
, 秘鲁邮政
, 巴西邮政
, 不丹邮政
, CDEK
, 加拿大邮政
, 递必易国际物流
, 大道物流
, 德国云快递
, 到了港
, 到乐国际
, DHL德国
, DHL(英文版)
, DHL全球
, DHL Global Mail
, 丹麦邮政
, DPD
, DPEX
, EMS国际
, E特快
, 易客满
, EPS(联众国际快运)
, EShipper
, 丰程物流
, 法翔速运
, FQ
, 国际e邮宝
, 国际邮政包裹
, GE2D
, 冠泰
, GLS
, 安的列斯群岛邮政
, 欧洲专线(邮政)
, 澳大利亚邮政
, 阿尔巴尼亚邮政
, 阿尔及利亚邮政
, 阿富汗邮政
, 安哥拉邮政
, 阿根廷邮政
, 埃及邮政
, 阿鲁巴邮政
, 奥兰群岛邮政
, 阿联酋邮政
, 阿曼邮政
, 阿塞拜疆邮政
, 埃塞俄比亚邮政
, 爱沙尼亚邮政
, 阿森松岛邮政
, 博茨瓦纳邮政
, 波多黎各邮政
, 冰岛邮政
, 白俄罗斯邮政
, 波黑邮政
, 保加利亚邮政
, 巴基斯坦邮政
, 黎巴嫩邮政
, 便利速递
, 玻利维亚邮政
, 巴林邮政
, 百慕达邮政
, 波兰邮政
, 宝通达
, 贝邮宝
, 出口易
, 达方物流
, 德国邮政
, 爱尔兰邮政
, 厄瓜多尔邮政
, 俄罗斯邮政
, 厄立特里亚邮政
, 飞特物流
, 瓜德罗普岛EMS
, 瓜德罗普岛邮政
, 俄速递
, 哥伦比亚邮政
, 格陵兰邮政
, 哥斯达黎加邮政
, 韩国邮政
, 华翰物流
, 互联易
, 哈萨克斯坦邮政
, 黑山邮政
, 津巴布韦邮政
, 吉尔吉斯斯坦邮政
, 捷克邮政
, 加纳邮政
, 柬埔寨邮政
, 克罗地亚邮政
, 肯尼亚邮政
, 科特迪瓦EMS
, 科特迪瓦邮政
, 卡塔尔邮政
, 利比亚邮政
, 林克快递
, 罗马尼亚邮政
, 卢森堡邮政
, 拉脱维亚邮政
, 立陶宛邮政
, 列支敦士登邮政
, 马尔代夫邮政
, 摩尔多瓦邮政
, 马耳他邮政
, 孟加拉国EMS
, 摩洛哥邮政
, 毛里求斯邮政
, 马来西亚EMS
, 马来西亚邮政
, 马其顿邮政
, 马提尼克EMS
, 马提尼克邮政
, 墨西哥邮政
, 南非邮政
, 尼日利亚邮政
, 挪威邮政
, 葡萄牙邮政
, 全球快递
, 全通物流
, 苏丹邮政
, 萨尔瓦多邮政
, 塞尔维亚邮政
, 斯洛伐克邮政
, 斯洛文尼亚邮政
, 塞内加尔邮政
, 塞浦路斯邮政
, 沙特阿拉伯邮政
, 土耳其邮政
, 泰国邮政
, 特立尼达和多巴哥EMS
, 突尼斯邮政
, 坦桑尼亚邮政
, 危地马拉邮政
, 乌干达邮政
, 乌克兰EMS
, 乌克兰邮政
, 乌拉圭邮政
, 文莱邮政
, 乌兹别克斯坦EMS
, 乌兹别克斯坦邮政
, 西班牙邮政
, 小飞龙物流
, 新喀里多尼亚邮政
, 新加坡EMS
, 新加坡邮政
, 叙利亚邮政
, 希腊邮政
, 夏浦世纪
, 夏浦物流
, 新西兰邮政
, 匈牙利邮政
, 意大利邮政
, 印度尼西亚邮政
, 印度邮政
, 英国邮政
, 伊朗邮政
, 亚美尼亚邮政
, 也门邮政
, 越南邮政
, 以色列邮政
, 易通关
, 燕文物流
, 直布罗陀邮政
, 智利邮政
, 日本邮政
, 今枫国际
, 极光转运
, 吉祥邮转运
, 嘉里国际
, 绝配国际速递
, 佳惠尔
, 联运通
, 联合快递
, 林道国际
, 荷兰邮政
, 新顺丰
, ONTRAC
, OCS
, 全球邮政
, POSTEIBE
, 啪啪供应链
, 秦远海运
, 启辰国际
, 瑞典邮政
, SKYPOST
, 瑞士邮政
, 首达速运
, 穗空物流
, 首通快运
, 申通快递国际单
, 上海久易国际
, 泰国138
, USPS美国邮政
, 万国邮政
, 星空国际
, 迅达国际
, 香港邮政
, 喜来快递
, 鑫世锐达
, 新元国际
, ADLER雄鹰国际速递
, 日本大和运输(Yamato)
, YODEL
, 一号线
, 约旦邮政
, 玥玛速运
, 鹰运
, 易境达
, 洋包裹
, AOL（澳通）
, BCWELT
, 笨鸟国际
, COE快递
, 优邦国际速运
, UEX
, 韵达国际
, 爱购转运
, 爱欧洲
, 澳世速递
, AXO
, 澳转运
, 八达网
, 蜜蜂速递
, 贝海速递
, 百利快递
, 斑马物流
, 败欧洲
, 百通物流
, 贝易购
, 策马转运
, 赤兔马转运
, CUL中美速递
, 德国海淘之家
, 德运网
, EFS POST
, 宜送转运
, ETD
, 飞碟快递
, 飞鸽快递
, 风雷速递
, 风行快递
, 风行速递
, 飞洋快递
, 皓晨快递
, 皓晨优递
, 海带宝
, 汇丰美中速递
, 豪杰速递
, 360hitao转运
, 海淘村
, 365海淘客
, 华通快运
, 海星桥快递
, 华兴速运
, 海悦速递
, LogisticsY
, 君安快递
, 时代转运
, 骏达快递
, 骏达转运
, 久禾快递
, 金海淘
, 联邦转运FedRoad
, 领跑者快递
, 龙象快递
, 量子物流
, 明邦转运
, 美国转运
, 美嘉快递
, 美速通
, 美西转运
, 168 美中快递
, 欧e捷
, 欧洲疯
, 欧洲GO
, 全美通
, QQ - EX
, 润东国际快线
, 瑞天快递
, 瑞天速递
, SCS国际物流
, 速达快递
, 四方转运
, SOHO苏豪国际
, Sonic - Ex速递
, 上腾快递
, 通诚美中快递
, 天际快递
, 天马转运
, 滕牛快递
, TrakPak
, 太平洋快递
, 唐三藏转运
, 天天海淘
, TWC转运世界
, 同心快递
, 天翼快递
, 同舟快递
, UCS合众快递
, 文达国际DCS
, 星辰快递
, 迅达快递
, 信达速运
, 先锋快递
, 新干线快递
, 西邮寄
, 信捷转运
, 优购快递
, 友家速递(UCS)
, 云畔网
, 云骑快递
, 一柒物流
, 优晟速递
, 易送网
, 运淘美国
, 至诚速递
, 增速海淘
, 中驰物流
, 中欧快运
, 准实快运
, 中外速运
, 郑州建华";
        const string logisticCode = @"SF
,HTKY
,ZTO
,STO
,YTO
,YD
,YZPY
,EMS
,HHTT
,JD
,UC
,DBL
,FAST
,ZJS
,TNT
,UPS
,DHL
,FEDEX
,FEDEX_GJ
,AJ
,ALKJWL
,AXWL
,AYUS
,AMAZON
,AOMENYZ
,ANE
,ADD
,AYCA
,BDT
,BETWL
,BJXKY
,BLZ
,BNTWL
,BFDF
,BHGJ
,BQXHM
,BFAY
,BTWL
,CCES
,CFWL
,CHTWL
,CKY
,CXHY
,CG
,CITY100
,CJKD
,CNPEX
,COE
,CSCY
,CDSTKY
,CTG
,CRAZY
,CBO
,DSWL
,DLG 
,D4PX
,DTWL
,DJKJWL
,DEKUN
,ETK
,EWE
,KFW
,FKD
,FTD
,GD
,GTO
,GDEMS
,GSD
,GTONG
,GAI
,GKSD
,GTSD
,HFWL
,HGLL
,HLWL
,HOAU
,HOTSCM
,HPTEX
,hq568
,HQSY
,HXLWL
,HXWL
,HFHW
,HHWL
,HLONGWL
,HQKD
,HRWL
,HTKD
,HYH
,HYLSD
,JAD
,JGSD
,JIUYE
,JJKY
,JLDT
,JTKD
,JXD
,JYKD
,JYM
,JGWL
,JYWL
,KYSY
,KYWL
,KSDWL
,LB
,LJSKD
,LHT
,MB
,MHKD
,MK
,MDM
,MRDY
,MLWL
,NF
,NEDA
,PADTF
,PANEX
,PJ
,PCA
,QCKD
,QFKD
,QRT
,QUICK
,QXT
,RFD
,RRS
,RFEX
,SAD
,SNWL
,SAWL
,SBWL
,SDWL
,SFWL
,SHWL
,ST
,STWL
,SUBIDA
,SDEZ
,SCZPDS
,SURE
,TAIWANYZ
,TSSTO
,UAPEX
,ULUCKEX
,UEQ
,WJK
,WJWL
,WXWL
,WHTZX
,WPE
,WTP
,XBWL
,XCWL
,XFEX
,XYT
,XJ
,YADEX
,YCWL
,YCSY
,YDH
,YDT
,YFEX
,YFHEX
,YFSD
,YTKD
,YXKD
,YUNDX
,YMDD
,YZBK
,YZTSY
,YFSUYUN
,ZENY
,ZHQKD
,ZTE
,ZTKY
,ZTWL
,ZYWL
,SJ
,ZTOKY
,AAE
,ALKJWL
,ACS
,ADP
,ANGUILAYOU
,APAC
,ARAMEX
,AT
,AUSTRALIA
,BEL
,BHT
,BILUYOUZHE
,BR
,BUDANYOUZH
,CDEK
,CA
,DBYWL
,DDWL
,DGYKD
,DLG
,DLGJ
,DHL_DE
,DHL_EN
,DHL_GLB
,DHLGM
,DK
,DPD
,DPEX
,EMSGJ
,ETK
,EKM
,EPS
,ESHIPPER
,FCWL
,FX
,FQ
,GJEYB
,GJYZ
,GE2D
,GT
,GLS
,IADLSQDYZ
,IOZYZ
,IADLYYZ
,IAEBNYYZ
,IAEJLYYZ
,IAFHYZ
,IAGLYZ
,IAGTYZ
,IAJYZ
,IALBYZ
,IALQDYZ
,IALYYZ
,IAMYZ
,IASBJYZ
,IASEBYYZ
,IASNYYZ
,IASSDYZ
,IBCWNYZ
,IBDLGYZ
,IBDYZ
,IBELSYZ
,IBHYZ
,IBJLYYZ
,IBJSTYZ
,IBLNYZ
,IBLSD
,IBLWYYZ
,IBLYZ
,IBMDYZ
,IBOLYZ
,IBTD
,IBYB
,ICKY
,IDFWL
,IDGYZ
,IE
,IEGDEYZ
,IELSYZ
,IELTLYYZ
,IFTWL
,IGDLPDEMS
,IGDLPDYZ
,IGJESD
,IGLBYYZ
,IGLLYZ
,IGSDLJYZ
,IHGYZ
,IHHWL
,IHLY
,IHSKSTYZ
,IHSYZ
,IJBBWYZ
,IJEJSSTYZ
,IJKYZ
,IJNYZ
,IJPZYZ
,IKNDYYZ
,IKNYYZ
,IKTDWEMS
,IKTDWYZ
,IKTEYZ
,ILBYYZ
,ILKKD
,ILMNYYZ
,ILSBYZ
,ILTWYYZ
,ILTWYZ
,ILZDSDYZ
,IMEDFYZ
,IMEDWYZ
,IMETYZ
,IMJLGEMS
,IMLGYZ
,IMLQSYZ
,IMLXYEMS
,IMLXYYZ
,IMQDYZ
,IMTNKEMS
,IMTNKYZ
,IMXGYZ
,INFYZ
,INRLYYZ
,INWYZ
,IPTYYZ
,IQQKD
,IQTWL
,ISDYZ
,ISEWDYZ
,ISEWYYZ
,ISLFKYZ
,ISLWNYYZ
,ISNJEYZ
,ISPLSYZ
,ISTALBYZ
,ITEQYZ
,ITGYZ
,ITLNDHDBGE
,ITNSYZ
,ITSNYYZ
,IWDMLYZ
,IWGDYZ
,IWKLEMS
,IWKLYZ
,IWLGYZ
,IWLYZ
,IWZBKSTEMS
,IWZBKSTYZ
,IXBYYZ
,IXFLWL
,IXGLDNYYZ
,IXJPEMS
,IXJPYZ
,IXLYYZ
,IXLYZ
,IXPSJ
,IXPWL
,IXXLYZ
,IXYLYZ
,IYDLYZ
,IYDNXYYZ
,IYDYZ
,IYGYZ
,IYLYZ
,IYMNYYZ
,IYMYZ
,IYNYZ
,IYSLYZ
,IYTG
,IYWWL
,IZBLTYZ
,IZLYZ
,JP
,JFGJ
,JGZY
,JXYKD
,JLDT
,JPKD
,SYJHE
,LYT
,LHKDS
,SHLDHY
,NL
,NSF
,ONTRAC
,OCS
,QQYZ
,POSTEIBE
,PAPA
,QYHY
,VENUCIA
,RDSE
,SKYPOST
,SWCH
,SDSY
,SK
,STONG
,STO_INTL
,JYSD
,TAILAND138
,USPS
,UPU
,XKGJ
,XD
,XGYZ
,XLKD
,XSRD
,XYGJ
,XYGJSD
,YAMA
,YODEL
,YHXGJSD
,YUEDANYOUZ
,YMSY
,YYSD
,YJD
,YBG
,AOL
,BCWELT
,BN
,COE
,UBONEX
,UEX
,YDGJ
,ZY_AG
,ZY_AOZ
,ZY_AUSE
,ZY_AXO
,ZY_AZY
,ZY_BDA
,ZY_BEE
,ZY_BH
,ZY_BL
,ZY_BM
,ZY_BOZ
,ZY_BT
,ZY_BYECO
,ZY_CM
,ZY_CTM
,ZY_CUL
,ZY_DGHT
,ZY_DYW
,ZY_EFS
,ZY_ESONG
,ZY_ETD
,ZY_FD
,ZY_FG
,ZY_FLSD
,ZY_FX
,ZY_FXSD
,ZY_FY
,ZY_HC
,ZY_HCYD
,ZY_HDB
,ZY_HFMZ
,ZY_HJSD
,ZY_HTAO
,ZY_HTCUN
,ZY_HTKE
,ZY_HTONG
,ZY_HXKD
,ZY_HXSY
,ZY_HYSD
,ZY_IHERB
,ZY_JA
,ZY_JD
,ZY_JDKD
,ZY_JDZY
,ZY_JH
,ZY_JHT
,ZY_LBZY
,ZY_LPZ
,ZY_LX
,ZY_LZWL
,ZY_MBZY
,ZY_MGZY
,ZY_MJ
,ZY_MST
,ZY_MXZY
,ZY_MZ
,ZY_OEJ
,ZY_OZF
,ZY_OZGO
,ZY_QMT
,ZY_QQEX
,ZY_RDGJ
,ZY_RT
,ZY_RTSD
,ZY_SCS
,ZY_SDKD
,ZY_SFZY
,ZY_SOHO
,ZY_SONIC
,ZY_ST
,ZY_TCM
,ZY_TJ
,ZY_TM
,ZY_TN
,ZY_TPAK
,ZY_TPY
,ZY_TSZ
,ZY_TTHT
,ZY_TWC
,ZY_TX
,ZY_TY
,ZY_TZH
,ZY_UCS
,ZY_WDCS
,ZY_XC
,ZY_XDKD
,ZY_XDSY
,ZY_XF
,ZY_XGX
,ZY_XIYJ
,ZY_XJ
,ZY_YGKD
,ZY_YJSD
,ZY_YPW
,ZY_YQ
,ZY_YQWL
,ZY_YSSD
,ZY_YSW
,ZY_YTUSA
,ZY_ZCSD
,ZYZOOM
,ZH
,ZO
,ZSKY
,ZWSY
,ZZJH";

        /// <summary>
        /// 目前支持的物流供应商
        /// </summary>
        public static Dictionary<string, string> ShipperLogisticDic
        {
            get;
        }

        static ShipperFactory()
        {
            ShipperLogisticDic = new Dictionary<string, string>();
            var sArray = shiper.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var lArray = logisticCode.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (sArray.Length == lArray.Length)
            {
                for (int i = 0; i < sArray.Length; i++)
                {
                    ShipperLogisticDic.Add(sArray[i].Trim(), lArray[i].Trim());
                }
            }
        }

        /// <summary>
        /// 获取物流供应商代码
        /// </summary>
        /// <param name="shipper"></param>
        /// <returns></returns>
        public static string GetLogisticByShipperName(string shipper)
        {
            if (string.IsNullOrEmpty(shipper))
                return string.Empty;
            if (ShipperLogisticDic.ContainsKey(shipper))
                return ShipperLogisticDic[shipper];
            var keys = ShipperLogisticDic.Keys;
            foreach (var item in keys)
            {
                if (shipper.Contains(item))
                    return ShipperLogisticDic[item];
            }
            return string.Empty;
        }
    }
}
