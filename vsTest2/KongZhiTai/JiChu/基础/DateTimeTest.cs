using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class DateTimeTest
    {
        public static void DateTime_Main()
        {

        }

        public static void DateTimeTest1()
        {
            #region----判断是否是正确的日期格式----
            /*
            string strDate = "20180904";
            //DateTime dtDate;
            if (DateTime.TryParse(strDate, out dtDate))
            {
                Console.WriteLine(dtDate);
            }
            else
            {
                //throw new Exception("不是正确的日期格式类型！");
                //Console.WriteLine(new Exception("不是正确的日期格式类型！"));
                Console.WriteLine("不是正确的日期格式类型");
            }

            if (!DateTime.TryParse(strDate, out dtDate))
            {
                Console.WriteLine("不是正确的日期格式类型");
               
            }
           
            //Console.WriteLine(dtDate);
            */
            #endregion



            #region----将日期转换为字符串----
            string strDate = "2017-12-15 1:00:00";
            string endDate = null;
            string aaa = Convert.ToDateTime(strDate).ToString("d") + " " + endDate;
            DateTime bbb = Convert.ToDateTime(aaa);
            Console.WriteLine(bbb);
            Console.WriteLine(aaa);
            Console.WriteLine(Convert.ToDateTime(Convert.ToDateTime(strDate).ToString("d")));

            string dateStr = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime dateStrDateTime = Convert.ToDateTime(dateStr);
            string dateStr2 = DateTime.Now.ToString("d");
            #endregion

            //string strTime = "9:00";
            //DateTime strDate = Convert.ToDateTime(strTime);
            //Console.WriteLine(strDate);

            //string str = Convert.ToDateTime(strDate).ToString("t");
            //Console.WriteLine(str);

            /*
            DateTime? appointment_EndDate = null;
            bool isTrue = DateTime.Now > appointment_EndDate;
            if (DateTime.Now > appointment_EndDate)
            {
                Console.WriteLine("时间？");
            }
            */

            #region----字符串转换为日期----
            //string inDateStr = "2019-01-17";
            //DateTime inDateDateTime = Convert.ToDateTime(inDateStr);
            //Console.WriteLine(inDateDateTime);
            #endregion

            #region----字符串转换为日期，并且判断日期不能等于今天----
            /*
            string requestDateStr = "20180905";
            int year = Convert.ToInt32(requestDateStr.Substring(0, 4));
            int month = Convert.ToInt32(requestDateStr.Substring(4, 2));
            int day = Convert.ToInt32(requestDateStr.Substring(6, 2));
            DateTime dateRequest = new DateTime(year, month, day);
            DateTime dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //限制日切日期一定要小于当前日期
            if (!(dateRequest < dateNow))
            {
                Console.WriteLine("日期超了");
            }
            else
            {
                Console.WriteLine("日期正常");
            }
            */


            #endregion

            #region----日期转换为一串数字----
            //日期转换为一串数字
            /*
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff")); // 20180202150832321
            Console.WriteLine(DateTime.Now.ToString("yyyy年MM月dd日HH是mm分ss秒fff毫秒"));//2018年02月02日15是08分32秒349毫秒
            */
            //Console.WriteLine(DateTime.Now.ToString("ddHHmmss"));
            #endregion

            #region----获取今天，昨天，今月，开始时间和结束时间----
            /*
            var thisYear = DateTime.Now.Year;
            var thisMonth = DateTime.Now.Month;
            var thisDay = DateTime.Now.Day;
            //今天开始时间
            DateTime todayStartTime = new DateTime(thisYear, thisMonth, thisDay, 0, 0, 0, 0);
            //今天结束时间
            DateTime todayEndTime = new DateTime(thisYear, thisMonth, thisDay, 23, 59, 59, 999);


            //昨天开始时间
            DateTime yesterdayStartTime = todayStartTime.AddDays(-1);
            //昨天结束时间
            DateTime yesterdayEndTime = todayEndTime.AddDays(-1);

            //本月开始时间,例如2018-06-01 00:00:00.000
            DateTime thisMonthStartTime = new DateTime(thisYear, thisMonth, 1, 0, 0, 0, 0);
            //本月结束时间,例如2018-06-30 23:59:59.999
            DateTime thisMonthEndTime = (new DateTime(thisYear, thisMonth, 1, 23, 59, 59, 999)).AddMonths(1).AddDays(-1);

            Console.WriteLine("今天开始时间" + todayStartTime);
            Console.WriteLine("今天结束时间" + todayEndTime);
            Console.WriteLine("昨天开始时间" + yesterdayStartTime);
            Console.WriteLine("昨天结束时间" + yesterdayEndTime);
            Console.WriteLine("本月开始时间" + thisMonthStartTime);
            Console.WriteLine("本月结束时间" + thisMonthEndTime);
            Console.WriteLine();
            */
            #endregion

            #region----时间刻度----
            //DateTime date = new DateTime();
            #endregion

            Console.ReadKey();
        }

        public static void DateTimeTest2()
        {
            int createTime = 882345679;
            long time_JAVA_Long = createTime * 1000L;//java长整型日期，毫秒为单位               
            DateTime dt_1970 = new DateTime(1970, 1, 1, 0, 0, 0);
            long tricks_1970 = dt_1970.Ticks;//1970年1月1日刻度                        
            long time_tricks = tricks_1970 + time_JAVA_Long * 10000;//日志日期刻度                        
            DateTime dt = new DateTime(time_tricks).AddHours(8);//转化为DateTime
            Console.WriteLine(dt.ToString());
            Console.ReadKey();
        }
    }
}
