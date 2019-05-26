using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程
{
    class ThreadPool_Test
    {
        public static int money = 0;
        public static void ThreadPool_Test_Main() {
            #region----普通方法执行
            /*
            Console.WriteLine(DateTime.Now);
            for (int i = 0; i < 6000; i++)//执行12*5次，算5年总收入
            {
                //ThreadPool.QueueUserWorkItem(x => Add(i));
                Add(5000);
            }
            //Thread.Sleep(1);
            //Console.WriteLine(money);

            //Thread.Sleep(5);
            //Console.WriteLine(money);

            //Thread.Sleep(5);
            //Console.WriteLine(money);

            //Thread.Sleep(5);
            //Console.WriteLine(money);

            //Thread.Sleep(5);
            //Console.WriteLine(money);

            Console.WriteLine(money);
            Console.WriteLine(DateTime.Now);
            */
            #endregion

            #region----线程方法执行

            Console.WriteLine(DateTime.Now);
            //a.设置线程池最大最小：
            int workerThreads = 5;//线程池中辅助线程的最大数目。
            int completionPortThreads = 5;//线程池中异步 I/O 线程的最大数目。
            ThreadPool.SetMaxThreads(workerThreads, completionPortThreads);

            for (int i = 0; i < 6000; i++)//执行12*5次，算5年总收入
            {
                //ThreadPool.QueueUserWorkItem(x => Add(i));
                ThreadPool.QueueUserWorkItem(x => Add(5000));
            }
            //Thread.Sleep(1 * 1000);//休眠1秒

            Console.WriteLine(money);

            //Thread.Sleep(1);
            //Console.WriteLine(money);

            //Thread.Sleep(5);
            //Console.WriteLine(money);

            //Thread.Sleep(5);
            //Console.WriteLine(money);

            //Thread.Sleep(5);
            //Console.WriteLine(money);

            //Thread.Sleep(5);
            //Console.WriteLine(money);
            Console.WriteLine(DateTime.Now);

            #endregion

            Console.ReadKey();
        }
        public static void Add(int mny)
        {
            money += mny * 600000000;
            Thread.Sleep(1);
        }
    }
}
