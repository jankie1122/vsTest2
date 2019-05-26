using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class decimalTest
    {
        public static void decimalTest_Main()
        {
            #region 赠送金额测试,因为Convert.ToInt32(0.01))会等于0
            /*
            decimal AwardValue;//赠送金额
                               //  decimal AwardValueDB = 0.01m; //(int)AwardValueDB==0
                               //  decimal AwardValueDB =1m;
            decimal AwardValueDB = 00.01m;
            Console.WriteLine(AwardValueDB.ToString());
            Console.WriteLine(Convert.ToInt32(AwardValueDB));
            Console.WriteLine(Math.Ceiling(AwardValueDB));
            Console.WriteLine(Convert.ToInt32(Math.Ceiling(AwardValueDB)));
            if (AwardValueDB.ToString() == "")
            {
                Console.WriteLine("成功转化为“”");
                Console.ReadKey();
            }
            if (AwardValueDB.ToString() == "0")
            {
                Console.WriteLine("成功转化为”0“");
                Console.ReadKey();
            }
            if ((int)AwardValueDB == 0)
            {
                Console.WriteLine("成功转化为int0");
                Console.ReadKey();
            }
            if (AwardValueDB.ToString() == "" || (int)AwardValueDB == 0)//decimal可以为null???
            {
                AwardValue = 0;
            }
            else
            {
                AwardValue = AwardValueDB;
            }
            Console.WriteLine(AwardValue);
            */
            #endregion

            #region----微信企业付款+0.5m----
            //微信企业付款的单位是分，如果数据库金额的字段是保留两位小数的，
            //例如0.01，那么，付款就不会又影响。
            //如果数据库金额的字段是保留3位小数的，例如0.001，那么，转换成int就会有影响了，
            //decimal转换成int，如果不够1，就会进行四舍五入，例如0.4m转成int就是0，0.5m转成int就是1
            //所以在乘以100之后加上精度0.5m,是为了兼容数据库字段乘以100之后还是出现小数的情况。
            decimal amountDecimal = 0.004m * 100;
            int amountInt = (int)(amountDecimal);
            int amountInt2 = (int)(amountDecimal + 0.5m);
            Console.WriteLine(amountInt);
            Console.WriteLine(amountInt2);
            #endregion


            #region 微信支付提交金额测试 
            //decimal creditValue = 0.01m;
            //Console.WriteLine(creditValue.ToString());
            //Console.WriteLine(creditValue.ToString().TrimEnd('0'));
            //Console.WriteLine(creditValue.ToString().TrimEnd('0') == "0");
            //Console.WriteLine("------------------------");
            //Console.WriteLine((creditValue * 100).ToString());
            //Console.WriteLine((creditValue * 100).ToString("F2"));
            //Console.WriteLine((creditValue * 100).ToString("F2") == "0.00");
            //Console.WriteLine(((creditValue).ToString("F0") == "0") ? "012" : "123");
            #endregion

            #region----提成配置，提成的钱----
            /*
            decimal percent1 = 5;
            decimal payment = 92.55m;
            decimal value1 = payment * (percent1 / 100);
            Console.WriteLine(value1);
            Console.WriteLine(decimal.Round(value1, 2));
            Console.WriteLine(decimal.Round(3.234699m, 3));

            decimal value3 = 5m / 100;
            Console.WriteLine(5m / 100);
            */
            #endregion

            #region 提交的金额太小
            /*
            string creditValueSoSmall = "-0.01";
            Console.WriteLine(Convert.ToDecimal(creditValueSoSmall));
            if (Convert.ToDecimal(creditValueSoSmall) < 0.01m)
            {
                Console.WriteLine("提交的金额太小了");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("符合要求");
                Console.ReadKey();
            }
            */
            #endregion

            #region----string正数，负数转换为decimal----
            //string zhengShu = "0.0003000000";
            //decimal zhengShuDecimal = Convert.ToDecimal(zhengShu);
            //Console.WriteLine(zhengShuDecimal);
            #endregion

            Console.ReadKey();
        }
    }
}
