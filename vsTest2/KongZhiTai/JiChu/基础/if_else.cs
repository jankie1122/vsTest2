using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class if_else
    {
        public static void if_else_Main()
        {
            /*
            string encRemainValue = "";

            if (encRemainValue == "")

                Console.WriteLine("000");

            if (encRemainValue == "0")
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine("123");
            }
            Console.ReadKey();
            */

        }

        #region----计算商家可以提现多少钱----
        /// <summary>
        /// 计算商家可以提现多少钱     
        /// </summary>
        /// <param name="clientSubAccCanUserMoney">商家子账户可用的钱（元）</param>
        /// <returns></returns>
        public static OutMoneyCalculateResponse ClientOutMoneyCalculate(decimal clientSubAccCanUserMoney)
        {
            /// 手续费计算方式（1、用手续费试算接口查询手续费；2、直接用这里的文档查询手续费）：
            /// 1万元以下（含1万）      3.5元/笔
            /// 1-10万元（含10万元）    7元/笔
            /// 10-50万元（含50万元）   10.5元/笔
            /// 50-100万元（含100万元） 14元/笔
            /// 100万元以上             万分之0.14收取，最高140元

            OutMoneyCalculateResponse response = new OutMoneyCalculateResponse();

            if (clientSubAccCanUserMoney < 3.51m)
            {
                response.WithdrawMoney = 0;
                response.ShouXuFei = 0;
                return response;
            }
            //0.01 + 3.5 = 3.51
            //10000 + 3.5 = 10003.5
            else if (3.51m <= clientSubAccCanUserMoney && clientSubAccCanUserMoney <= 10003.5m)
            {
                response.WithdrawMoney = clientSubAccCanUserMoney - 3.5m;
                response.ShouXuFei = 3.5m;
                return response;
            }
            //这个范围按10000元，3.5提现
            else if (10003.5m < clientSubAccCanUserMoney && clientSubAccCanUserMoney < 10007.01m)
            {
                response.WithdrawMoney = 10000m;
                response.ShouXuFei = 3.5m;
                return response;
            }
            //10000.01 + 7 = 10007.01
            //100000 + 7 = 100007
            else if (10007.01m <= clientSubAccCanUserMoney && clientSubAccCanUserMoney <= 100007m)
            {
                response.WithdrawMoney = clientSubAccCanUserMoney - 7m;
                response.ShouXuFei = 7m;
                return response;
            }
            //这个范围按100000元，7提现
            else if (100007m < clientSubAccCanUserMoney && clientSubAccCanUserMoney < 100010.51m)
            {
                response.WithdrawMoney = 100000m;
                response.ShouXuFei = 7m;
                return response;
            }
            //100000.01 + 10.5 = 100010.51
            //500000 + 10.5 = 500010.5
            else if (100010.51m <= clientSubAccCanUserMoney && clientSubAccCanUserMoney <= 500010.5m)
            {
                response.WithdrawMoney = clientSubAccCanUserMoney - 10.5m;
                response.ShouXuFei = 10.5m;
                return response;
            }
            //这个范围按500000元，10.5提现
            else if (500010.5m < clientSubAccCanUserMoney && clientSubAccCanUserMoney < 500014.01m)
            {
                response.WithdrawMoney = 500000m;
                response.ShouXuFei = 10.5m;
                return response;
            }
            //500000.01 + 14 = 500014.01
            //1000000 + 14 = 1000014
            else if (500014.01m <= clientSubAccCanUserMoney && clientSubAccCanUserMoney <= 1000014m)
            {
                response.WithdrawMoney = clientSubAccCanUserMoney - 14m;
                response.ShouXuFei = 14m;
                return response;
            }
            //这个范围按1000000元，14提现
            else if (1000014.01m == clientSubAccCanUserMoney)
            {
                response.WithdrawMoney = 1000000;
                response.ShouXuFei = 14m;
                return response;
            }
            //1000000.01 + (1000000.01 * 0.14/10000) =  1000014.01000014
            //10000000 + (10000000 * 0.14/10000) = 10000140
            else if (1000014.02m <= clientSubAccCanUserMoney)
            {
                //如果超过140元手续费，按最高140手续费算
                if (clientSubAccCanUserMoney > 10000140)
                {
                    response.WithdrawMoney = clientSubAccCanUserMoney - 140m;
                    response.ShouXuFei = 140m;
                    return response;
                }
                response.WithdrawMoney = Math.Floor(clientSubAccCanUserMoney / Convert.ToDecimal(1 + 0.14 / 10000));
                response.ShouXuFei = response.WithdrawMoney * Convert.ToDecimal(0.14 / 10000);
                return response;
            }
            else
            {
                //计算出错，默认返回0
                response.WithdrawMoney = 0;
                response.ShouXuFei = 0;
                return response;
            }
        }
        #endregion
    }

    /// <summary>
    /// 提现金额手续费计算返回类
    /// </summary>
    public class OutMoneyCalculateResponse
    {
        /// <summary>
        /// 提现金额（到银行卡金额）
        /// </summary>
        public decimal WithdrawMoney { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal ShouXuFei { get; set; }
    }
}
