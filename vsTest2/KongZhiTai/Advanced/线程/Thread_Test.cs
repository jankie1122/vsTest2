using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程
{
    class Thread_Test
    {
        public static void Thread_Test_Main() {
            Thread t1 = new Thread(new ThreadStart(Run1));
            t1.Name = "我是线程1";
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(Run2));
            t2.Name = "我是线程2";
            t2.Start();
            Thread t3 = new Thread(new ThreadStart(Run3));
            t3.Name = "我是线程3";
            t3.Start();
            Console.ReadKey();
        }

        public static void Run1()
        {
            while (true)
            {
                Thread.Sleep(4000);
                Console.WriteLine("Run1");
            }
        }

        public static void Run2()
        {
            while (true)
            {
                Thread.Sleep(2000);
                Console.WriteLine("----Run222");
            }
        }

        public static void Run3()
        {
            while (true)
            {
                Thread.Sleep(8000);
                Console.WriteLine("-----------Run3");
            }
        }
    }
}
