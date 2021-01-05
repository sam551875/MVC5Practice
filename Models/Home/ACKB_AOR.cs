using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Practice.Models.Home
{
    public class ACKB_AOR
    {
        //Field 32 Remittance Currency and Amount 匯款幣別及金額
        public string F32A { get; set; }

        //Field 50 Ordering customer 申請人
        public string F50A { get; set; }
        public string F50K { get; set; }
        public string F50_ChineseName { get; set; }
        public string F50_EnglishName { get; set; }
        public string F50_IdNo { get; set; }
        public string F50_Tel { get; set; }
        public string F50_Address { get; set; }

        //Field 56 Intermediary Institution 中間銀行
        public string F56A { get; set; }

        //Field 57 Account with Institution 受款銀行
        public string F57A { get; set; }
        public string F57_BankNameBranchInformation { get; set; }
        public string F57_SwiftCode_CnapsNo_AbaNo { get; set; }
        public string F57_Address { get; set; }

        //Field 59 Beneficiary 受款人
        public string F59 { get; set; }
        public string F59_AccNo_IbanCode { get; set; }
        public string F59_EnglishName { get; set; }
        public string F59_Address { get; set; }
        public string F59_Tel { get; set; }
        
        //Field 70 Remittance Information 匯款明細
        public string F70 { get; set; }

        //Field 71 Details of Charges 匯款銀行費用
        public string F71A { get; set; }

        //Payment Method  付款方式
        public string PaymentMethod { get; set; }





    }
}