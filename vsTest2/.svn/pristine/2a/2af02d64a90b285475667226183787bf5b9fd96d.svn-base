using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class FindIndexTest
    {
        public static void FindIndexTest_Main()
        {
            List<string> dinosaurs = new List<string>();
            dinosaurs.Add("Compsognathus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Oviraptor");
            dinosaurs.Add("Velociraptor");
            dinosaurs.Add("Deinonychus");
            dinosaurs.Add("Dilophosaurus");
            dinosaurs.Add("Gallimimus");
            dinosaurs.Add("Triceratops");
            Console.WriteLine(dinosaurs.FindIndex(s => s == "Amargasaurus"));//匹配到了返回集合当前占据位置
            Console.WriteLine(dinosaurs.FindIndex(s => s == "viraptor"));//匹配不到返回-1            
            //如果集合条数为0,匹配不到，也是返回-1

            /*
            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }
            */


            /*
            Console.WriteLine("\nFindIndex(EndsWithSaurus): {0}",
                dinosaurs.FindIndex(EndsWithSaurus));

            Console.WriteLine("\nFindIndex(2, EndsWithSaurus): {0}",
                dinosaurs.FindIndex(2, EndsWithSaurus));

            Console.WriteLine("\nFindIndex(2, 3, EndsWithSaurus): {0}",
                dinosaurs.FindIndex(2, 3, EndsWithSaurus));
                */

            Console.ReadKey();
        }

        private static bool EndsWithSaurus(String s)
        {
            if ((s.Length > 5) &&
                (s.Substring(s.Length - 6).ToLower() == "saurus"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
