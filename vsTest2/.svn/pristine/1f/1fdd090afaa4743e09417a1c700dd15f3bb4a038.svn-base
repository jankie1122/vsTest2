using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class For_Test
    {
        public static void For_Test_Main()
        {
            int goodsIDTotal = 1151;
            //1135
            //1101   1150

            int responseCount = 50;//每次请求的分页条数
            for (int i = 1; i <= goodsIDTotal; i += responseCount)
            {
                if (goodsIDTotal - i < responseCount)
                {
                    //1101-1150可以进入这里
                    //1101-1151不可以进入这里
                    //所以goodsIDCount - (i) <= 49
                    Console.WriteLine(i + "----" + (goodsIDTotal));
                }
                else
                {
                    Console.WriteLine(i + "----" + (i + (responseCount - 1)));
                }
            }
            Console.ReadKey();
        }
    }
}
