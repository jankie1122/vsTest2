using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程
{
    class Thread_lock
    {
        DL d = new DL();
        public static void Thread_lock_Main()
        {
            Thread_lock m = new Thread_lock();

            Thread t1 = new Thread(new ThreadStart(m.Run1));
            t1.Name = "线程t1";
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(m.Run2));
            t2.Name = "线程t2";
            t2.Start();
            Console.ReadLine();
        }

        public void Run1()
        {
            this.d.First(10);
        }

        public void Run2()
        {
            this.d.Second(10);
        }
    }

    class DL
    {
        int field1 = 0;
        int field2 = 0;
        private object lock1 = new int[1];
        private object lock2 = new int[1];

        public void First(int val)
        {
            lock (lock1)
            {
                Console.WriteLine("First: Acquired lock 1: "
                    + Thread.CurrentThread.GetHashCode() + " Now Sleeping.");
                //Try commenting Thread.Sleep()
                Thread.Sleep(1000);
                Console.WriteLine("First: Acquired lock 1: "
                    + Thread.CurrentThread.GetHashCode() + " Now wants lock2.");

                lock (lock2)
                {
                    Console.WriteLine("First: Acquired lock 2: "
                        + Thread.CurrentThread.GetHashCode());
                    field1 = val;
                    field2 = val;
                }
            }
        }

        public void Second(int val)
        {
            lock (lock2)
            {
                Console.WriteLine("Second: Acquired lock 2: "
                    + Thread.CurrentThread.GetHashCode());

                lock (lock1)
                {
                    Console.WriteLine("Second: Acquired lock 1: "
                        + Thread.CurrentThread.GetHashCode());
                    field1 = val;
                    field2 = val;
                }
            }
        }
    }
}
