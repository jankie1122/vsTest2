using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 异步
{
    class Async_Await_2
    {
        public static void Async_Await_2_Main() {
            //使用Async与Await进行异步编程
            Console.WriteLine("主线程测试开始");
            AsyncMethod();
            Thread.Sleep(3000);
            Console.WriteLine("主线程测试结束..");
            Console.ReadLine();
        }

        static async void AsyncMethod()
        {
            Console.WriteLine("开始异步代码");
            int result = await MyMethod();
            Console.WriteLine(result);
        }

        static async Task<int> MyMethod()
        {
            int returnNum = -1;
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("异步执行" + i.ToString() + "...");
                returnNum = i;
                await Task.Delay(1000);//模拟耗时操作
            }
            return returnNum;
        }
    }
}
