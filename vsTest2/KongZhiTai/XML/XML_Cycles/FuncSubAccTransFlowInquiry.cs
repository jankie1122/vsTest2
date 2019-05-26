using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Cycles
{
    /// <summary>
    /// 104080子账户交易流水查询
    /// </summary>
    public class FuncSubAccTransFlowInquiry
    {
        /// <summary>
        /// 交易流水号
        /// </summary>
        [Required(ErrorMessage = "交易流水号不能为空")]
        public string TransCodeId { get; set; }

        /// <summary>
        /// 交易码
        /// </summary>
        [Required(ErrorMessage = "交易码不能为空")]
        public string TransCode { get; set; }

        //----------------------------------------

        /// <summary>
        /// 支付单号 32 否
        /// </summary>
        public string PayCode { get; set; }

        /// <summary>
        /// 子账号 32 否
        /// </summary>
        public string SubAccount { get; set; }

        /// <summary>
        /// 交易会员代码 32 否
        /// （若子账户为交易会员子账户，则该字段必填）
        /// </summary>
        public string TradeMemCode { get; set; }

        /// <summary>
        /// 查询方式 1 是
        /// 1-按照交易日期查询（商户交易日）
        /// 2-按照交易时间查询（机器时间）
        /// 选择1则开始日期1与终止日期1不允许为空
        /// 选择2则开始时间1与开始时间2不允许为空
        /// </summary>
        public string QueryMode { get; set; }

        /// <summary>
        /// 开始时间 14 否
        /// YYYYMMDDHH24MISS 
        /// </summary>
        public string StartTimes { get; set; }

        /// <summary>
        /// 终止时间 14 否
        /// YYYYMMDDHH24MISS  
        /// </summary>
        public string EndTimes { get; set; }

        /// <summary>
        /// 查询页码 6 是
        /// 数字，如1.2.3.4……..
        /// </summary>
        public string Paging { get; set; }

        /// <summary>
        /// 交易类型 1 是
        /// 0全部 1.入金2.出金3.支付4.资金冻结5.资金解冻6.入金同步7.出金同步8.结息9. 991转账入金 
        /// </summary>
        public string AppType { get; set; }

        /// <summary>
        /// 备注1 100 否
        /// </summary>
        public string Remark1 { get; set; }

        /// <summary>
        /// 备注2 100 否
        /// </summary>
        public string Remark2 { get; set; }
    }

    /// <summary>
    /// 104080子账户交易流水查询，应答报文
    /// </summary>
    public class FuncSubAccTransFlowInquiryResponse
    {
        /// <summary>
        /// 总记录条数 8 是
        /// 满足查询条件的总记录数
        /// </summary>
        public string Count { get; set; }

        /// <summary>
        /// 循环体
        /// </summary>
        public AAABB Cycles { get; set; }

        /// <summary>
        /// 备注1 100 
        /// </summary>
        public string Remark1 { get; set; }

        /// <summary>
        /// 备注2 100
        /// </summary>
        public string Remark2 { get; set; }
    }

    public class AAABB
    {
        public List<SubAccTransFlowInquiryCycle> Cycle { get; set; }
    }

    /// <summary>
    /// 104080子账户交易流水查询，应答报文循环体
    /// </summary>
    public class SubAccTransFlowInquiryCycle
    {
        /// <summary>
        /// 子账号 32 是
        /// 交易发起的的子账户
        /// </summary>
        public string SubAccount { get; set; }

        /// <summary>
        /// 序号 8 是
        /// 每页记录的序号
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// 支付单号 32 是
        /// 商户上送的支付单号
        /// </summary>
        public string PayCode { get; set; }

        /// <summary>
        /// 交易码 6 是
        /// 暂时不用判断
        /// </summary>
        public string TransCode { get; set; }

        /// <summary>
        /// 付款账号 32 否
        /// </summary>
        public string PayAcc { get; set; }

        /// <summary>
        /// 付款账户名称 64 否
        /// </summary>
        public string PayAccName { get; set; }

        /// <summary>
        /// 付款方开户行名称 64 否
        /// </summary>
        public string PayOpenBank { get; set; }

        /// <summary>
        /// 收款账号 32 否
        /// </summary>
        public string RevAcc { get; set; }

        /// <summary>
        /// 收款账户名称 64 否
        /// </summary>
        public string RevAccName { get; set; }

        /// <summary>
        /// 收款方开户行名称 64 否
        /// </summary>
        public string RevOpenBank { get; set; }

        /// <summary>
        /// 交易额 18 是
        /// 交易金额=发生额+手续费 单位为分（该字段无用）
        /// </summary>
        public string TotalAmt { get; set; }

        /// <summary>
        /// 发生额 18 是
        /// 交易金额 单位为分
        /// </summary>
        public string CreMoney { get; set; }

        /// <summary>
        /// 交易类型 1 是
        /// 1.入金2.出金3.支付4.资金冻结5.资金解冻6.入金同步7.出金同步8.结息9. 991转账入金  
        /// </summary>
        public string AppType { get; set; }

        /// <summary>
        /// CurrCode 3 是
        /// (RMB-人民币 HKD-港币 USD-美元,国际标准，见字典)
        /// </summary>
        public string CurrCode { get; set; }

        /// <summary>
        /// 手续费 18 否
        /// 手续费=客户自付手续费+商户代付手续费 单位为分
        /// </summary>
        public string FeeAmt { get; set; }

        /// <summary>
        /// 客户自付手续费  18 否
        /// 单位为分
        /// </summary>
        public string CustPayFee { get; set; }

        /// <summary>
        /// 商户代付手续费  18 否
        /// 单位为分
        /// </summary>
        public string MerchantPayFee { get; set; }

        /// <summary>
        /// 错误码 8 否      
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 错误信息  128 否
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 商户流水号 32 否
        /// 商户的交易流水号
        /// </summary>
        public string MerchantSeqId { get; set; }

        /// <summary>
        /// 交易状态 1 否
        /// 1-成功 2-失败 3-未知   
        /// </summary>
        public string TranStat { get; set; }

        /// <summary>
        /// 处理状态 1 否
        /// 1-成功 
        /// 2-失败 
        /// 3-未知 
        /// 4-出金成功，大额转出已受理 
        /// 5-出金成功，大额系统失败 
        /// 6-出金失败，转大额成功
        /// 7-出金失败，转大额失败
        /// 8-待调账 
        /// 9-出金失败，转大额未知
        /// </summary>
        public string SysStat { get; set; }

        /// <summary>
        /// 子账户余额 18 否
        /// 单位为分
        /// </summary>
        public string SubAccountMoney { get; set; }

        /// <summary>
        /// 系统流水号 32 否
        /// 991转账入金对应流水号
        /// </summary>
        public string TransCodeId { get; set; }

        /// <summary>
        /// 交易时间 14 否
        /// YYYYMMDDHH24MISS ，银行发生交易时间，机器时间
        /// </summary>
        public string TradeTimes { get; set; }

        /// <summary>
        /// 交易摘要 512 否
        /// 交易进行时填写的摘要信息
        /// </summary>
        public string BusiSummary { get; set; }

        /// <summary>
        /// 备注1 40 否
        /// </summary>
        public string Remark1 { get; set; }

        /// <summary>
        /// 备注2 40 否
        /// </summary>
        public string Remark2 { get; set; }

        /// <summary>
        /// 备注3 40 否
        /// </summary>
        public string Remark3 { get; set; }

        /// <summary>
        /// 备注4 40 否
        /// </summary>
        public string Remark4 { get; set; }

        /// <summary>
        /// 备注5 40 否
        /// </summary>
        public string Remark5 { get; set; }
    }

}
