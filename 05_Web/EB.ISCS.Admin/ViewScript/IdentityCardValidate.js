
var IdentityCardValidate = (function ($) {
    var _this = this;
    return {
        checkFormat: function (identityCardId) {
            //验证长度与格式规范性的正则  
            var pattern = new RegExp(/(^\d{15}$)|(^\d{17}(\d|x|X)$)/i);
            if (!pattern.test(identityCardId))
                return false;
            return true;
        },
        // 合法性校验
        verifyLegitimacy: function (identityCardId) {
            //验证身份证的合法性的正则  
            var sum = 0;
            var pattern = new RegExp(/^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/);
            if (!pattern.test(identityCardId)) {
                identityCardId = identityCardId.replace(/x|X$/i, "a");
                //校验18位身份证号码的合法性  
                for (var i = 17; i >= 0; i--) {
                    sum += (Math.pow(2, i) % 11) * parseInt(identityCardId.charAt(17 - i), 11);
                }
                if (sum % 11 != 1) {
                    return false;
                }
            }
            return true;
        },
        // 校验地区
        verifyDistrict: function (identityCardId) {
            //检测证件地区的合法性
            //身份证的地区代码对照  
            var aCity = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外" };
            if (aCity[parseInt(identityCardId.substring(0, 2))] == null) {
                return false;
            }
            return true;
        },
        // 校验生日
        verifyBirthday: function (identityCardId) {
            //验证身份证的合法性的正则  
            var pattern = new RegExp(/^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/);
            if (pattern.test(identityCardId)) {
                //获取15位证件号中的出生日期并转位正常日期       
                birthday = "19" + identityCardId.substring(6, 8) + "-" + identityCardId.substring(8, 10) + "-" + identityCardId.substring(10, 12);
            }
            else {
                identityCardId = identityCardId.replace(/x|X$/i, "a");
                //获取18位证件号中的出生日期  
                birthday = identityCardId.substring(6, 10) + "-" + identityCardId.substring(10, 12) + "-" + identityCardId.substring(12, 14);
            }
            var dateStr = new Date(birthday.replace(/-/g, "/"));
            var month = dateStr.getMonth();
            month = ((month + 1)<10 ? ("0"+(month + 1)) :(month + 1));
            var day = dateStr.getDate();
            day = day<10?("0"+day):day;
            if (birthday != (dateStr.getFullYear() + "-" + month + "-" + day)) {
                return false;
            }
            return true;
        },

        // 校验年龄 (业务验证 18岁以下 75岁以上 无效)
        verifyAge: function (identityCardId) {
            //获取年龄 
            var myDate = new Date();
            var month = myDate.getMonth() + 1;
            var day = myDate.getDate();

            var age = myDate.getFullYear() - identityCardId.substring(6, 10) - 1;
            if (identityCardId.substring(10, 12) < month || identityCardId.substring(10, 12) == month && identityCardId.substring(12, 14) <= day) {
                age++;
            }
            //年龄 age
            if (age < 18)
                return false;
            else if (age >= 75)
                return false;
            return true;
        }
    }
})(jQuery);