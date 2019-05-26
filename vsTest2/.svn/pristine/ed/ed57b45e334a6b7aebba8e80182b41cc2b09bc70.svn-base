using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class JsonTest
    {
        public static void JsonTest_Main() {
            /*
            string total_fee = "1000";
            string bank_type = "工商银行";//付款银行
            string transaction_id = "123456645";//微信支付订单号
            string time_end = "2017-10-17";//支付完成时间
            decimal payment_back = Convert.ToDecimal(total_fee) / 100;//支付金额
            string resultsJson = "{\"支付金额\":" + payment_back + ",\"付款银行\":" + bank_type + ",\"微信支付订单号\":" + transaction_id
                + ",\"支付完成时间\":" + time_end + "}";

            BasePageResponse<RetrunEntity> value = new BasePageResponse<RetrunEntity>();
            IList<RetrunEntity> list = new List<RetrunEntity>();
            list.Add(new RetrunEntity());
            foreach (var item in list)
            {
                item.payment_back = 1000m;
                item.bank_type = "银行";
            }
            value.Result = list.ToList();
            string data2 = JsonConvert.SerializeObject(resultsJson);
            string data1 = JsonConvert.SerializeObject(list);
            string data = JsonConvert.SerializeObject(value.Result);
            Console.WriteLine(data);
            Console.WriteLine(value.Result);
            string jsoonnn = resultsJson;
            */


            // var json =   ToJObject<RetrunEntity>(resultsJson);



            // var json =  JSON.parse(resultsJson);
            //Console.WriteLine(json);

            /*
            CallBackSuccess returnSuccessDto = new CallBackSuccess();
            returnSuccessDto.success = true;
            string returnSuccess = JsonConvert.SerializeObject(returnSuccessDto);
            Console.WriteLine(returnSuccess);
            string aaa = "{'success':true}";
            Console.WriteLine(aaa);
            string bbb = "{\"success\":true}";
            Console.WriteLine(bbb);
            */

            string s = "aaa";
            Console.WriteLine(s);

            int userID = 24;
            string scene = "{\"UserID\": " + " " + userID.ToString() + "+" + "}";

            Console.WriteLine(scene);

            Console.ReadKey();
        }
    }

    public class CallBackSuccess
    {
        public bool success { get; set; }
    }

    public class BasePageResponse<T>
    {
        public BasePageResponse()
        {
            //Status = BaseResponseStatusEnum.Error;   //默认失败
        }
        public string Msg { get; set; }
        //public BaseResponseStatusEnum Status { get; set; }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public int Total { get; set; }
        public IList<T> Result { get; set; }
    }

    public class RetrunEntity
    {
        public decimal payment_back { get; set; }
        public string bank_type { get; set; }
        public string transaction_id { get; set; }
        public string time_end { get; set; }


    }
}
