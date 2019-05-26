using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class Program
    {
        static void Main(string[] args)
        {
            //字符串类
            //String_Test.String_Test_Main();

            //时间类
            // DateTimeTest.DateTimeTest1();

            //ObjectTest.ObjectTest_Main();

            //decimal aaa = decimal.Round(Convert.ToDecimal(1.01400014), 2);
            //Console.WriteLine(aaa);

            //decimal bbb = decimal.Round(Convert.ToDecimal(1.01500014 - 0.005), 2);
            //Console.WriteLine(bbb);

            //Console.WriteLine(decimal.Round(Convert.ToDecimal(1.01560014 - 0.005), 2));


            //decimal ccc = decimal.Round(Convert.ToDecimal(1.01400014), 2);
            //Console.WriteLine(ccc);

            //decimal ddd = decimal.Round(Convert.ToDecimal(1.01400014), 2);
            //Console.WriteLine(ddd);



            List<decimal> clientSubAccMoneyList = new List<decimal>();
            clientSubAccMoneyList.Add(3.51m);
            clientSubAccMoneyList.Add(10003.5m);
            clientSubAccMoneyList.Add(10005m);//特殊范围
            clientSubAccMoneyList.Add(10007.01m);
            clientSubAccMoneyList.Add(100007m);
            clientSubAccMoneyList.Add(100008m);//特殊范围
            clientSubAccMoneyList.Add(100010.51m);
            clientSubAccMoneyList.Add(500010.5m);
            clientSubAccMoneyList.Add(500012m);//特殊范围
            clientSubAccMoneyList.Add(500014.01m);
            clientSubAccMoneyList.Add(1000014m);
            clientSubAccMoneyList.Add(1000014.01m);//特殊范围
            clientSubAccMoneyList.Add(1000014.02m);
            clientSubAccMoneyList.Add(1000014.03m);
            clientSubAccMoneyList.Add(1000015m);
            clientSubAccMoneyList.Add(1000016m);
            clientSubAccMoneyList.Add(1000017m);
            clientSubAccMoneyList.Add(1000030m);
            clientSubAccMoneyList.Add(1000050m);
            clientSubAccMoneyList.Add(1000090m);
            clientSubAccMoneyList.Add(10000000m);
            clientSubAccMoneyList.Add(10000000.01m);
            clientSubAccMoneyList.Add(10000001m);

            clientSubAccMoneyList = clientSubAccMoneyList.ToList();


            foreach (var item in clientSubAccMoneyList)
            {
                OutMoneyCalculateResponse withDrawMoney = if_else.ClientOutMoneyCalculate(item);
                //Console.WriteLine("提现金额:" + withDrawMoney.WithdrawMoney + "。手续费：" + withDrawMoney.ShouXuFei + "。提现总扣费："+(withDrawMoney.WithdrawMoney+withDrawMoney.ShouXuFei)+ "。商家金额：" + item);
                Console.WriteLine("" + withDrawMoney.WithdrawMoney +"--"+   withDrawMoney.ShouXuFei + "--" + (withDrawMoney.WithdrawMoney + withDrawMoney.ShouXuFei) + "--" + item);
            }

            Console.ReadKey();
        }
    }
}
