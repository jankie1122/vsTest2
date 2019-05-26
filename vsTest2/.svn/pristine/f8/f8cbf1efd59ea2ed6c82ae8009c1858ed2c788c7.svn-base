using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class String_Test
    {
        public static void String_Test_Main()
        {
            /*
          int aaa = -1;
          int aaab = 1;
          string bbb = aaa.ToString();
          string bbbc = aaab.ToString();
          Console.WriteLine(bbb+bbbc);
          Console.ReadKey();
          */

            //字符串截取
            /*
            string baiduEditStr = "<p><img src=\"http://114.215.141.69:30892/Scripts/ueditor1_4_3_2-utf8-net/utf8-net/net/upload/image/20180113/6365145207157040513987589.jpg\" style=\"\" title=\"NCS191-净爽洁肤湿巾10片装（芦荟保湿）-订货平台_01.jpg\"/></p> "
           + " <p><img src = \"http://114.215.141.69:30892/Scripts/ueditor1_4_3_2-utf8-net/utf8-net/net/upload/image/20180123/6365231646559672543437362.jpg\" title = \"NCS191-净爽洁肤湿巾10片装（芦荟）-订货平台_02.jpg\" alt = \"NCS191-净爽洁肤湿巾10片装（芦荟）-订货平台_02.jpg\" /></p> "
            + "        <p><img src = \"http://114.215.141.69:30892/Scripts/ueditor1_4_3_2-utf8-net/utf8-net/net/upload/image/20180113/6365145207392981033301263.jpg\" style = \"\" title = \"NCS191-净爽洁肤湿巾10片装（芦荟保湿）-订货平台_03.jpg\" /></p> "
              + "             <p><img src = \"http://114.215.141.69:30892/Scripts/ueditor1_4_3_2-utf8-net/utf8-net/net/upload/image/20180113/6365145207835174194783917.jpg\" style = \"\" title = \"NCS191-净爽洁肤湿巾10片装（芦荟保湿）-订货平台_04.jpg\" /></p> "
                + "                  <p><img src = \"http://114.215.141.69:30892/Scripts/ueditor1_4_3_2-utf8-net/utf8-net/net/upload/image/20180113/6365145207989863671809739.jpg\" style = \"\" title = \"NCS191-净爽洁肤湿巾10片装（芦荟保湿）-订货平台_05.jpg\" /></p> "
                  + "                       <p><br/></p >\" ";

            Console.WriteLine(baiduEditStr);

            // 定义正则表达式用来匹配 img 标签 
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            // 搜索匹配的字符串 
            string test = null;

            MatchCollection matches = regImg.Matches(test == null ? "" : test);
            int i = 0;
            string[] sUrlList = new string[matches.Count];
            // 取得匹配项列表 
            foreach (Match match in matches)
                sUrlList[i++] = match.Groups["imgUrl"].Value;
                */


            /*
            //获取图片的名字
            string imgUrl = "http://114.215.141.69:30892/Scripts/ueditor1_4_3_2-utf8-net/utf8-net/net/upload/image/20180113/6365145207989863671809739.jpg";
            //包括扩展名：
            String fileName = System.IO.Path.GetFileName(imgUrl);
            //不包括扩展名：
            String fileName2 = System.IO.Path.GetFileNameWithoutExtension(imgUrl);
            //仅仅拓展名
            string picSuffix = System.IO.Path.GetExtension(imgUrl).ToLower();//获取文件的后缀名
            Console.WriteLine(fileName);
            Console.WriteLine(fileName2);
            Console.WriteLine(picSuffix);
            */

            //截取中英文混合中的中文字符串
            /*
            string goodsName = "雅新柠檬清香洗衣皂100g*4";
            string name = "确美同纯净防晒乳SPF50+ PA+++ 59ml";

            string s = @"C# Aggh从入 qq门到11精通 ! @ 三个 ￥ %好的";
            Regex reg = new Regex("[\u4e00-\u9fa5]+");
            string zhongwen = "";
            foreach (Match v in reg.Matches(s))
            {
                zhongwen += v;
            }
            Console.WriteLine(zhongwen);
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));

            Random rNum = new Random();//随机生成类
            int aa = rNum.Next(1000, 9999);
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff") + new Random().Next(1000, 9999));
            */

            /*
            string lingshouSystem = "Data Source=124.232.146.124,37628;database=BMIS ;Integrated Security=false;pooling=false;uid=TMUser;";
            string[] array = lingshouSystem.Split(';');
            Console.WriteLine(array[0]);
            Console.WriteLine(lingshouSystem.Split(';')[0]);
            */


            //string str = "1,2";
            //string[] array = str.Split(',');
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]);
            //}
            //string strName = "132"; //"黄色|容量：30ml|50斤";
            //string[] arrayName = strName.Split('|');
            //string strNameGang = "";
            //for (int iName = 0; iName < arrayName.Length; iName++)
            //{
            //    strNameGang += arrayName[iName] + "-";
            //    //Console.WriteLine(strNameGang);
            //}
            //Console.WriteLine(strNameGang.Substring(0, strNameGang.Length - 1));


            //string str = "";
            //string[] array = { "11", "22", "33", "44" };
            //foreach (var item in array)
            //{
            //    str += "'" + item + "'" + ",";
            //}
            //str = str.TrimEnd(',');
            ////string strResult = str.Substring(0, str.Length - 1);
            //Console.WriteLine(str);

            /*
            string strAAA = "1,2,3,4,";
            //str.TrimEnd(',');
            strAAA.Substring(0,strAAA.Length-1);
            Console.WriteLine(strAAA);
            */

            /*
            string aa = "1,2,3,4,";
            aa = aa.Substring(0, aa.Length - 1);//去掉最后一个逗号
            //aa = aa.Substring(1);//去掉第一个字
            Console.WriteLine(aa);
            */

            /*
            //截取后面四位
            string aaa = "0123456789";
            aaa = aaa.Substring(aaa.Length - 4, 4);
            Console.WriteLine(aaa);
            string xingMing = "林小明";
            xingMing = xingMing.Substring(0, 1);
            Console.WriteLine(xingMing);

            string phone = "18814188433";
            phone = phone.Substring(0, 3) + "****" + phone.Substring(phone.Length - 4, 4);
            Console.WriteLine(phone);
            */

            /*
            string bbb = "201804165";
            int len = bbb.Length;
            string result = bbb.Substring(0, bbb.Length - 3) + bbb.Substring(bbb.Length - 3);
            Console.WriteLine(result);
            */

            /*
            //斜杠后面的数字截取            
            string xieGang = "T12559-2";
            int num2 = Convert.ToInt32(xieGang.Split('-')[1])+1;
            Console.WriteLine(num2);
            */

            //斜杠后面的文字截取
            //string erp_AllName = "123";//潮之坊河南郭店-吕钟贤
            //if (erp_AllName==null)
            //{
            //    erp_AllName = "";
            //}
            //Console.WriteLine("长度：" + erp_AllName.Split('-').Length);
            //Console.WriteLine("索引：" + (erp_AllName.Split('-').Length - 1));
            //string name = erp_AllName.Split('-')[erp_AllName.Split('-').Length - 1];
            //Console.WriteLine("最后结果："+name);

            //斜杠截取
            /*
            string yinSheng = "1120180706163208001|F2018092517503676420P1|0|0202|交易订单不存在||36CFCAB398C35953B912DAD54644BBAC|0.0";
            string[] strList = yinSheng.Split('|');
            List<string> yinShengList = new List<string>();
            foreach (var item in strList)
            {
                yinShengList.Add(item);
            }
            */

            /*
            //按指定长度截取字符串
            string goodTitle = "10单盘超威高级蚊香10单盘超威高级蚊香123";
            int charNumber = 5;//charNumber为要截取的每段的长度
            ArrayList arrlist = new ArrayList();
            string tempStr = goodTitle;
            for (int i = 0; i < tempStr.Length; i += charNumber)//首先判断字符串的长度，循环截取，进去循环后首先判断字符串是否大于每段的长度
            {
                if ((tempStr.Length - i) > charNumber)//如果是，就截取
                {
                    arrlist.Add(tempStr.Substring(i, charNumber));
                }
                else
                {
                    arrlist.Add(tempStr.Substring(i));//如果不是，就截取最后剩下的那部分
                }
            }

            foreach (var item in arrlist)
            {
                Console.WriteLine(item);
            }
            */

            //生成固定账号子账户
            //string ramNumOld = "";

            for (int i = 2; i < 1000; i++)
            {
                //固定长度10

                int codeLenth = 10 - (("2" + i).Length);
                if (codeLenth <= 0)
                {
                    Console.WriteLine("子账户长度超出范围");
                    Console.ReadKey();
                }

                //string ramNum = CreateCode(codeLenth);
                string ramNum = Number(codeLenth, true);

                //while (!ramNum.Equals(ramNumOld))
                //{
                //    ramNumOld = ramNum;
                //}


                string subAcc = ramNum + "2" + i;
                //判断数据库不能存在这个子账号


                Console.WriteLine(subAcc);
            }








            //判断字符串是否是P开头
            /*
            string pinTuanStr = "P20180623184702918211";
            string tou = pinTuanStr.Substring(0, 1);
            Console.WriteLine(tou);
            */

            Console.ReadKey();
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


        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        /// <returns></returns>
        public static string Number(int Length, bool Sleep)
        {
            if (Sleep)
            {
                System.Threading.Thread.Sleep(3);
            }
            string result = "";
            Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                result += random.Next(10).ToString();
            }
            return result;
        }


    }
}
