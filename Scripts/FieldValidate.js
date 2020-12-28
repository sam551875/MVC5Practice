'use strict';

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

    if (checkNumber(time1) != true) {
        return false;
    }

    if (checkNumber(time2) != true) {
        return false;
    }

    if (["+", "-"].indexOf(sign) < 0) {
        return false;
    }

    return true;
}

//Field 20: Sender's Reference
function Validate_20(value) {
    if (value.length > 13) {
        return false;
    }
    return true;
}

//判斷字串是否為數字//判斷正整數/[1−9] [0−9]∗]∗/
function checkNumber(str) {
    var re = /^[0-9] .?[0-9]*/;
    if (!re.test(str)) {
        return false;
    }
    return true;
}
