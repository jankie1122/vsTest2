using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class Random1
    {
        public static void Random1_Main()
        {
            
        }



        public void RandomTest1() {
            //string buffer = "0123456789";// 随机字符中也可以为汉字（任何）  
            //StringBuilder sb = new StringBuilder();
            //Random r = new Random();
            //int range = buffer.Length;
            ////指定长度为3
            //for (int i = 0; i < 3; i++)
            //{
            //    sb.Append(buffer.Substring(r.Next(range), 1));
            //}         
            //Console.WriteLine(sb.ToString());

            /*
            Random r = new Random();
            int aaa = r.Next(995, 999);
            for (int i = 0; i < 1000; i++)
            {
                aaa += 1;
                string bbb;
                if (aaa.ToString().Length > 3)
                {
                    bbb = aaa.ToString().Substring(1, 3);
                }
                else
                {
                    bbb = aaa.ToString();
                }
                Console.WriteLine(bbb);
            }
            */

            //随机生成三位随机数
            Random r = new Random();
            for (int i = 0; i < 1000; i++)
            {
                //不会出现重复
                int aaa = r.Next(100000, 999999);
                Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff") + aaa);
                //Console.WriteLine(r.Next(100, 999));

                //会出现重复
                //Console.WriteLine(new Random().Next(100, 999));
            }



            Console.ReadKey();
        }

        public void RandomTest2() {
            string code = CreateCode(2);//生成3位随机数
            Console.WriteLine(code);
            Console.ReadKey();
        }

        public void RandomTest3() {
            //抽取随机数的范围，例如1-49中抽取随机数
            int minValue = 1;
            int maxValue = 49;
            //抽取随机数的个数，例如抽取25个
            int num = 7;

            //1-49
            ArrayList list = new ArrayList();//声明一个集合对象
            Random r = new Random();//声明一个随机对象            
            while (list.Count < num)
            {
                int number = r.Next(minValue, maxValue);//生成一个随机数，0-9
                while (list.Contains(number))//判断集合中有没有生成的随机数，如果有，则重新生成一个随机数，直到生成的随机数list集合中没有才退出循环
                {
                    number = r.Next(minValue, maxValue);
                }
                list.Add(number);//将生成的随机数添加到集合对象中
            }

            string msgNotSort = ListNum(list);
            list.Sort();
            string msgSort = ListNum(list);

            string msg = msgNotSort + "\r\n" + msgSort;
            //Console.WriteLine(msg);//在控制台中打印出生成的随机数
            var path = @"D:\桌面\25个随机数.txt";
            WriteMessage(path, msg);
            Console.WriteLine("打印成功！");
            Console.ReadKey();
        }

        public static string ListNum(ArrayList list)
        {
            string msg = "";
            foreach (var item in list)
            {
                msg += item.ToString() + ",";
            }
            msg = msg.Substring(0, msg.Length - 1);
            return msg;
        }

        /// <summary>
        /// 输出指定信息到文本文件
        /// </summary>
        /// <param name="path">文本文件路径</param>        /// <param name="msg">输出信息</param>
        public static void WriteMessage(string path, string msg)
        {
            ////读取文件
            //using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            //{
            //    using (StreamReader sr = new StreamReader(fs,Encoding.Default))
            //    {
            //        //sr.ReadToEnd().Remove(0);
            //        //string content = sr.ReadToEnd();//这个就是文本内容
            //        //content = content.Remove(0);//清除内容
            //        Console.WriteLine(sr.ReadToEnd());
            //        sr.Close();
            //    }
            //    Console.ReadKey();
            //}

            //写入文件
            //FileMode.Create如果文件存在就是覆盖文件，FileMode.OpenOrCreate如果文件存在就是追加文件内容
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine("{0}\r\n", msg, DateTime.Now);
                    sw.Flush();
                }
            }
        }

        /// <summary>
        /// 生成随机数（纯数字）
        /// </summary>
        /// <param name="codeLen">生成长度</param>
        /// <returns></returns>
        public static string CreateCode(int codeLen)
        {
            string codeSerial = "0,1,2,3,4,5,6,7,8,9";
            if (codeLen == 0)
            {
                codeLen = 1;
            }
            string[] arr = codeSerial.Split(',');
            string code = "";
            int randValue = -1;
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < codeLen; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);
                code += arr[randValue];
            }
            return code;
        }

    }
}
