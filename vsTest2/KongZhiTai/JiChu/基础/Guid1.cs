using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class Guid1
    {
        public static void Guid1_Main()
        {
            var uuidN = Guid.NewGuid().ToString("N"); // e0a953c3ee6040eaa9fae2b667060e09
            string guidResult = uuidN.Substring(0, 6);
            Console.WriteLine(uuidN);
            Console.WriteLine(uuidN.Length);
            Console.WriteLine(guidResult);


            /*
            var gui1 = Guid.NewGuid().ToString();
            Console.WriteLine(gui1);
            Console.WriteLine(gui1.Length);
            */



            Console.ReadKey();
        }
    }
}
