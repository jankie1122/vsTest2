using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MultipleSession
{
    class Program
    {
        static void Main(string[] args)
        {
            int apID = 1;
            string decOpenID = "123456123456";
            string avSkuIDList = "List999";
            HttpContext.Current.Session["ApID"] = apID;
            HttpContext.Current.Session["OpenID"] = decOpenID;
            HttpContext.Current.Session["AvSkuIDList"] = avSkuIDList;



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


        static void ThreadStart1()
        {
            //Done(11000);
        }
        static void ThreadStart2()
        {
            //Done(6000);
        }
        static void ThreadStart3()
        {
            //Done(8000);
        }
    }
}
