using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据批量插入.Domain.TradePercent
{
    class WxTradePercent
    {
        /// <summary>
        /// 自增主键ID
        /// </summary>
        public int TpID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string TradeID { get; set; }
        /// <summary>
        /// 2018-05-10 17:55新增
        /// 商品ID
        /// </summary>
        public int? GoodsID { get; set; }
        /// <summary>
        /// 2018-05-10 17:55新增
        /// 配置类型
        /// platform  统一佣金
        /// goods 按单品配置
        /// </summary>
        public string PtType { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public int BID { get; set; }
        /// <summary>
        /// 购买者
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 受益者
        /// </summary>
        public int GiveToUserID { get; set; }
        /// <summary>
        /// 提成金额
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// WxTrade.Payment
        /// 订单支付金额
        /// </summary>
        public decimal TradePayment { get; set; }
        /// <summary>
        /// 按订单：
        /// 提成比例:Percent1/Percent2的值
        /// 按单品，提成价格：Null
        /// </summary>
        public decimal? PercentTage { get; set; }
        /// <summary>
        /// 提成等级
        /// </summary>
        public int PecentLevel { get; set; }
        /// <summary>
        /// TradePercentEnum
        /// 0新增默认已支付未完成 
        /// 1已支付已确认完成
        /// 2已提现已打款 
        /// 3已退款或者已取消订单提成无效
        /// 4已申请提现
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime InsertTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 提现记录ID
        /// </summary>
        public int? DrawID { get; set; }

    }
}
