using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程
{
    class Thread_Jiandan
    {
        public static void Thread_Jiandan_Main() {
            Thread thread1 = new Thread(new ThreadStart(ThreadStart1));
            thread1.Name = "Thread1";
            Thread thread2 = new Thread(new ThreadStart(ThreadStart2));
            thread2.Name = "Thread2";
            Thread thread3 = new Thread(new ThreadStart(ThreadStart3));
            thread3.Name = "Thread3";
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Console.ReadKey();
        }

        static object _object = new object();
        static void Done(int millisecondsTimeout)
        {
            Console.WriteLine(string.Format("{0} -> {1}.Start", DateTime.Now.ToString("HH:mm:ss"), Thread.CurrentThread.Name));
            //下边代码段同一时间只能由一个线程在执行 
            lock (_object)
            {
                Console.WriteLine(string.Format("{0} -> {1}进入锁定区域.", DateTime.Now.ToString("HH:mm:ss"), Thread.CurrentThread.Name));
                Thread.Sleep(millisecondsTimeout);
                Console.WriteLine(string.Format("{0} -> {1}退出锁定区域.", DateTime.Now.ToString("HH:mm:ss"), Thread.CurrentThread.Name));
            }
        }
        static void ThreadStart1()
        {
            Done(11000);
        }
        static void ThreadStart2()
        {
            Done(6000);
        }
        static void ThreadStart3()
        {
            Done(8000);
        }
    }
}
