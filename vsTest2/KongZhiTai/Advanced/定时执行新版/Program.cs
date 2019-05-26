using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 定时执行新版
{
    class Program
    {

        static void Main(string[] args)
        {
            startQuartz();

        }
    
        //如果是网站项目，将这个执行方法放到Global里面
        private static void startQuartz()
        {
            IScheduler sched = new StdSchedulerFactory().GetScheduler();

            //给老板的报表开始
            JobDetailImpl jdBossReport
                = new JobDetailImpl("jdBossReport", typeof(BossReportJob));
            IMutableTrigger triggerBossReport
                = CronScheduleBuilder.DailyAtHourAndMinute(14, 11).Build();//每天23:45执行一次
            triggerBossReport.Key = new TriggerKey("triggerBossReport");
            sched.ScheduleJob(jdBossReport, triggerBossReport);
            //给老板的报表结束

            sched.Start();
        }
    }



    public class BossReportJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine("开始执行了");
            }
            catch (Exception ex)
            {
                Console.WriteLine("给老板发报表出错", ex);
            }
        }
    }

}
