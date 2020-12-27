using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Practice.Models.Home
{
    public class MT103Format
    {
        //TAG->20 英文：Sender's Reference 中文：發訊行號碼
        public string SendersReference { get; set; }

        //TAG->13C 英文：Time Indication 中文：時間指示
        public string TimeIndication { get; set; }

        //TAG->23B 英文：Bank Operation Code 中文：銀行作業代號
        public string BankOprationCode { get; set; }

        //TAG->23E 英文：Instruction Code 中文：指示代號
        public string InstructionCode { get; set; }

        //TAG->26T 英文：Transaction Type Code 中文：交易型態代號
        public string TransactionTypeCode { get; set; }

        //TAG->32A 英文：Value Date/Currency/Interbank Settled Amount 中文：生效日、幣別碼、金額、銀行間清算金額
        public string ValueDate_CurrencyCode_Amount { get; set; }

        //TAG->33B 英文：Currency/Instructed Amount 中文：幣別代碼、指示之金額
        public string Currency_InstructedAmount { get; set; }

        //TAG->36 英文：Exchange Rate 中文：匯率
        public string ExchangeRate { get; set; }

        //TAG->50A 英文：Ordering Customer 中文：匯款申請人
        public string OrderingCustomer { get; set; }

        //TAG->51A 英文：Sending Institution 中文：發訊銀行機構
        public string SendingInstitution { get; set; }

        //TAG->52A 英文：Ordering Institution 中文：匯款申請機構
        public string OrderingInstitution { get; set; }

        //TAG->53A 英文：Sender's Correspondent 中文：發訊行之通匯行
        public string SendersCorrespondent { get; set; }

        //TAG->54A 英文：Receiver's Correspondent 中文：收訊行之通匯行
        public string ReceiversCorrespondent { get; set; }

        //TAG->55A 英文：Third Reimbursement Institution 中文：第三補償機構
        public string ThirdReimbursementInstitution { get; set; }

        //TAG->56A 英文：Intermediary Institution 中文：中間銀行
        public string IntermediaryInstitution { get; set; }

        //TAG->57A 英文：Account With Institution 中文：設帳銀行
        public string AccountWithInstitution { get; set; }

        //TAG->59 英文：Beneficiary Customer 中文：受益顧客
        public string BeneficiaryCustomer { get; set; }

        //TAG->70 英文：Remittance Information 中文：付款明細
        public string RemittanceInformation { get; set; }

        //TAG->71A 英文：Details of Charges 中文：收費明細(對象)
        public string DetailsofCharges { get; set; }

        //TAG->71F 英文：Sender's Charges 中文：發訊行之費用
        public string SendersCharges { get; set; }

        //TAG->71G 英文：Receiver's Charges 中文：收訊行之費用
        public string ReceiversCharges { get; set; }

        //TAG->72 英文：Sender to Receiver Information 中文：發訊行予收訊行之訊息
        public string SendertoReceiverInformation { get; set; }

        //TAG->77B 英文：Regulatory Reporting 中文：申報之規定
        public string RegulatoryReporting { get; set; }


    }
}