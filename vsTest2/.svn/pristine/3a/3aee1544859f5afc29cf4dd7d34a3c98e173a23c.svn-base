using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 定时执行
{
    class Quartz_1_0
    {
        public static void Quartz_1_0_Main()
        {

            //每隔一段时间执行任务
            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sched = sf.GetScheduler();
            //括号里是为实现了IJob接口的类
            JobDetail job = new JobDetail("job1", "group1", typeof(MyJog));
            //5秒后开始第一次运行
            DateTime ts = TriggerUtils.GetNextGivenSecondDate(null, 5);

            //每隔9秒执行一次
            //TimeSpan interval = TimeSpan.FromSeconds(9);
            //时间段，每隔1小时执行一次
            //TimeSpan interval = TimeSpan.FromHours(1);

            //每隔24小时执行一次
            TimeSpan interval = TimeSpan.FromHours(24);
            Trigger trigger = new SimpleTrigger("trigger1", "group1", "job1", "group1", ts, null,
                  //每若干小时运行一次，小时间隔由appsettings中的IndexIntervalHour参数指定
                  SimpleTrigger.RepeatIndefinitely, interval);


            //Quartz比Timer更加精准，
            sched.AddJob(job, true);
            sched.ScheduleJob(trigger);
            sched.Start();
            //要关闭任务定时则需要sched.Shutdown(true)
        }
    }

    public class MyJog : IJob
    {
        public void Execute(JobExecutionContext context)
        {
            Console.WriteLine("执行啦");
        }
    }
}
