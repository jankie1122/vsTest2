using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class SanYuanYunSuan
    {
        public static void SanYuanYunSuan_Main()
        {
            decimal? Price = 3;
            decimal? aaa = (Price == null ? 0 : Price);
            Console.WriteLine(aaa);
            Console.ReadKey();
        }
    }
}
