'use strict';


//Field 20: Sender's Reference
function Validate_20(value) {
    if (value.length > 16) {
        return false;
    }
    return true;
}

//Field 13C: Time Indication
function Validate_13C(value) {
    const index1 = value.indexOf("/");
    const index2 = value.indexOf("/", (index1 + 1));

    var code = value.substring(index1 + 1, index2);
    var time1 = value.substring(index2 + 1, index2 + 5);
    var time2 = value.substring(index2 + 6, index2 + 10);
    var sign = value.substring(index2 + 5, index2 + 6);

    if (["CLSTIME", "RNCTIME", "SNDTIME"].indexOf(code) < 0) {
        return false;
    }

    if (checkNumber(time1, 4) != true) {
        return false;
    }

    if (checkNumber(time2, 4) != true) {
        return false;
    }

    if (["+", "-"].indexOf(sign) < 0) {
        return false;
    }

    return true;
}

//Field 23B: Bank Operation Code
function Validate_23B(value) {
    var code = ["CRED", "CRED", "SPAY", "SPRI", "SSTD"];

    if (value.length != 4) {
        return false;
    }
    if (code.indexOf(value) < 0) {
        return false;
    }

    return true;
}

//Field 23E: Instruction Code
function Validate_23E(value) {
    var code = ["CHQB", "CORT", "HOLD", "INTC", "PHOB", "PHOI", "PHON", "REPA", "SDVA", "TELB", "TELE", "TELI"];
    var str = value.substring(0, 4);

    if (code.indexOf(str) < 0) {
        return false;
    }

    //有額外資訊時檢查字數
    if (value.length > 4) {
        const index1 = value.indexOf("/");
        var addinfo = value.substring(index1 + 1);
        if (addinfo.length > 30) {
            return false;
        }
        
    }

    return true;
}

//Field 26T: Transaction Type Code
function Validate_26T(value) {
        
    if (value.length != 3) {
        return false;
    }

    var re = /[A-Z0-9]{3,}/;
    if (!re.test(value)) {
        return false;
    }

    return true;
}

//Field 32A: Transaction Type Code
function Validate_32A(value) {

    var re;

    var Date = value.substring(0, 6);
    var Currency = value.substring(6, 9);
    var Amount = value.substring(9);

    if (!checkDate_6n(Date)) {
        console.log('Date error.');
        return false;
    }

    if (!checkCurrency(Currency)) {
        console.log('Currency error.');
        return false;
    }

    if (Amount.length > 15) {
        console.log('Amount error.');
        return false;
    }

    return true;
}

//Field 33B: Currency/Instructed Amount
function Validate_33B(value) {

    var Currency = value.substring(0, 3);
    var Amount = value.substring(3);

    if (!checkCurrency(Currency)) {
        console.log('Currency error.');
        return false;
    }
    console.log(Amount);
    if (Amount.length > 15) {
        console.log('Amount error.');
        return false;
    }
    if (!checkAmount(Amount)) {
        console.log('Amount Format error.');
        return false;
    }
    console.log(checkAmount(Amount));

    return true;
}
//判斷字串是否為數字//判斷正整數/[1−9] [0−9]∗]∗/
/**
* 判斷字串是否為數字
*
* @param {Number} str
* @param {Number} num
*/
function checkNumber(str, num) {
    //var re = /\d{4,}/;
    var temp = '\\d{' + num + ',}';     // 反斜線"\"是特殊字元，在字串格式中需採用"\\"來儲存。
    console.log(temp);
    //var re = new RegExp('\d{' + num + ',}');
    var re = new RegExp(temp);
    if (!re.test(str)) {
        return false;
    }
    return true;
}

function checkDate_6n(str) {

    var re = /\d{6,}/;
    if (!re.test(str)) {
        console.log("number format error.")
        return false;
    }

    var Date_YY = str.substring(0, 2);
    var Date_MM = str.substring(2, 4);
    var Date_DD = str.substring(4, 6);

    if (Date_YY > 99 || Date_YY < 1) {
        console.log("Year error.")
        return false;
    }
    if (Date_MM > 12 || Date_MM < 1) {
        console.log("Month error.")
        return false;
    }
    if (Date_DD > getMonthDays("20" + Date_YY, Date_MM) || Date_DD < 1) {
        console.log("Date error.")
        return false;
    }

    return true;
}

function checkCurrency(str) {
    var flag = "N";

    $.ajax({
        url: '../../ISO4217_Currency.xml',
        type: 'GET',
        async: false,   //預設true: 非同步，false: 同步
        timeout: 1000,
        dataType: 'xml',
        error: function (xml) {
            alert('讀取xml錯誤' + xml); //當xml讀取失敗
        },
        success: function (xml) {

            $(xml).find('CcyNtry').each(function (i) {  //取得xml父節點

                var total = $(xml).find('CcyNtry').length;//xml的總筆數
                var Ccy = $(this).children('Ccy').text(); //取得子節點中的Ccy資料

                if (Ccy == str) {
                    flag = "Y";
                }
            }
            );
        }
    })

    if (flag != "Y") {
        return false;
    }

    return true;
}

function checkAmount(str) {
    //var re = /\d+(,\d+)/;
    //var re = /(^\d+$)/;
    //var re = /\d+(\,\d+)|(\d+)/;
    //var re = /(^\d+,\d+$)|((^[1-9]+$)|(^[1-9]+,\d+$))/;       //控卡,位置，但不能控卡第一個數字是0
    var re = /(^\d+,\d+$)|(^[1-9]+\d+$)/;       //控卡,位置，但不能控卡第一個數字是0

    if (!re.test(str)) {
        return false;
    }
    return true;

}

/**
* 判斷年份是否為潤年
*
* @param {Number} year
*/
function isLeapYear(year) {
    return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
}
/**
* 獲取某一年份的某一月份的天數
*
* @param {Number} year
* @param {Number} month
*/
function getMonthDays(year, month) {
    return [31, null, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31][month] || (isLeapYear(year) ? 29 : 28);
}