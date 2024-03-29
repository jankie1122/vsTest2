﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class DateTime_XingQi
    {

        public static void DateTime_XingQi_Main()
        {

            DateTime beginValue = Convert.ToDateTime("2017-12-12");
            DateTime endValue = Convert.ToDateTime("2017-12-31");

            //给每个星期的星期一，星期三，星期四赋值

            int days = (endValue - beginValue).Days;


            Console.WriteLine(beginValue.DayOfWeek);
            if (DayOfWeek.Tuesday == beginValue.DayOfWeek)
            {
                Console.WriteLine("日期是星期二");
            }



            Console.ReadKey();
        }





        /// <summary>   
        /// 计算本周的周一日期   
        /// </summary>   
        /// <returns></returns>   
        public static DateTime GetMondayDate()
        {
            return GetMondayDate(DateTime.Now);
        }
        /// <summary>   
        /// 计算本周周日的日期   
        /// </summary>   
        /// <returns></returns>   
        public static DateTime GetSundayDate()
        {
            return GetSundayDate(DateTime.Now);
        }
        /// <summary>   
        /// 计算某日起始日期（礼拜一的日期）   
        /// </summary>   
        /// <param name="someDate">该周中任意一天</param>   
        /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns>   
        public static DateTime GetMondayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。   
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Subtract(ts);
        }
        /// <summary>   
        /// 计算某日结束日期（礼拜日的日期）   
        /// </summary>   
        /// <param name="someDate">该周中任意一天</param>   
        /// <returns>返回礼拜日日期，后面的具体时、分、秒和传入值相等</returns>   
        public static DateTime GetSundayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Sunday;
            if (i != 0) i = 7 - i;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。   
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Add(ts);
        }


    }
}
