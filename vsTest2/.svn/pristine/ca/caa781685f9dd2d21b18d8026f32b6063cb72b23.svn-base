using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class ObjectTest
    {
        public static void ObjectTest_Main()
        {
            /*
           //object aa = { "{" + " \"userID\": 4023, \"tradeID\": \"T2018012609403330210\"" + "}" };
           object aaa = new { userID = 4023, tradeID = "123456" };
           Console.WriteLine(aaa);

           var bbb = aaa.GetType().GetProperties().ToList();

           var member = new { ID = 1, Age = 21, Name = "郭美美" };
           //member.GetType().GetProperties().ToList().ForEach(x => Console.WriteLine(x.Name));
           object value = member.GetType().GetProperties().Where(x => x.Name == "ID").First().GetValue(member, null);
           Console.WriteLine(value);

           string line_colorStr = " \"r\":\"0\", \"g\":\"0\", \"b\":\"0\" ";
           string line_colorJson = JsonConvert.SerializeObject(line_colorStr);
           Console.WriteLine(line_colorJson);
           object line_color = JsonConvert.DeserializeObject(line_colorJson);
           Console.WriteLine(line_color);

           object weixin = new { r = 0, g = 0, b = 0 };
           Console.WriteLine(weixin);
           */

            //获取对象的名字
            /*
            BusinessInfoInquiryResponse responseEntity = new BusinessInfoInquiryResponse();
            string name = responseEntity.GetType().Name;
            Console.WriteLine(name);
            Console.ReadKey();
            */

            //装箱和拆箱
            //int i = 2000;
            //object o = i;
            //i = 2001;
            //int j = (int)o;
            //Console.WriteLine("i={0},o={1},j={2}", i, o, j);

            //对象赋值
            Boy a = new Boy();
            a.Age = 10;
            a.Name = "a";

            Boy b = a;
            b.Age = 11;
            b.Name = "b";

            //output: a.Age b.Age

            Console.WriteLine("a.Age:" + a.Age + "b.Age:" + b.Age);
            Console.ReadKey();

        }
    }

    public class Boy
    {
        public int Age { get; set; }

        public string Name { get; set; }
    }
    public class BusinessInfoInquiryResponse
    {
        /// <summary>
        /// 商户代码 8 是
        /// </summary>
        public string MerchantNo { get; set; }

        /// <summary>
        /// 企业性质 80 是
        /// </summary>
        public string CompanyProperty { get; set; }

        /// <summary>
        /// 经营范围 128 否
        /// </summary>
        public string CreadScope { get; set; }
    }
}
