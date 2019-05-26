using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class HashValue_Test
    {
        public static void HashValue_Test_Main()
        {
            //string valueStr = "";
            //bool strBool = false;

            int? valueInt = null;
            bool intBool = valueInt.HasValue;
            if (intBool == true)
            {
                Console.WriteLine("Int有值");
            }
            else
            {
                Console.WriteLine("Int没有值");
            }
            Console.ReadKey();
        }
    }
}
