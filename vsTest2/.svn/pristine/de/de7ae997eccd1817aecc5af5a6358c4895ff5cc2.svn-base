using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线程
{
    class Thread_Jingdian
    {
        public static void Thread_Jingdian_Main()
        {
            //初始化10个线程
            System.Threading.Thread[] threads = new System.Threading.Thread[10];
            //把balance初始化设定为1000
            Account acc = new Account(1000);
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread t = new System.Threading.Thread(
                    new System.Threading.ThreadStart(acc.DoTransactions));
                threads[i] = t;
                threads[i].Name = "Thread" + i.ToString();
            }
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
            Console.ReadKey();
        }
    }

    class Account
    {
        private Object thisLock = new object();
        int balance;
        Random r = new Random();

        public Account(int initial)
        {
            balance = initial;
        }

        /// <summary>
        /// 执行lock
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        int WithDraw(int amount)
        {
            if (balance < 0)
            {
                throw new Exception("负的Balance");
            }
            //确保只有一个线程使用资源，一个进入临界状态，使用对象互斥锁，10个启动了的线程不能全部执行该方法
            lock (thisLock)
            {
                if (balance >= amount)
                {
                    Console.WriteLine("----------------------------:" +
                        System.Threading.Thread.CurrentThread.Name + "---------------");
                    Console.WriteLine("调用Withdrawal之前的Balance:" + balance);
                    Console.WriteLine("把Amount输入 Withdrawal     :-" + amount);
                    //如果没有对象互斥锁，则可能10个线程都执行下面的减法，加减法所耗时间片段非常小，
                    //可能多个线程同时执行，出现负数
                    balance = balance - amount;
                    Console.WriteLine("调用Withdrawal之后的Balance:" + balance);
                    return amount;
                }
                else
                {
                    //最终结果
                    return 0;
                }
            }
        }

        /// <summary>
        /// 产生随机数，执行lock方法
        /// </summary>
        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                //生成balance的被减数amount的随机数
                WithDraw(r.Next(1, 100));
            }
        }
    }
}
