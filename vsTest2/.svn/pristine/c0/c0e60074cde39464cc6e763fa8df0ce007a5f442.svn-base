using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Groupby
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orderList = new List<Order>();
            //for (int i = 0; i < 3; i++)
            //{
            //    Order orderEntity = new Order();
            //    orderEntity.OrderID = 100 + i;
            //    orderEntity.SellerID = i;
            //    orderList.Add(orderEntity);
            //}

            Order orderEntity2 = new Order();
            orderEntity2.OrderID = 400;
            orderEntity2.BID = null;
            orderEntity2.Money = 20;
            orderList.Add(orderEntity2);

            Order orderEntity3 = new Order();
            orderEntity3.OrderID = 400;
            orderEntity3.BID = 3;
            orderEntity3.Money = 30;
            orderList.Add(orderEntity3);

            Order orderEntity4 = new Order();
            orderEntity4.OrderID = 400;
            orderEntity4.BID = 2;
            orderEntity4.Money = 40;
            orderList.Add(orderEntity4);

            Order orderEntity5 = new Order();
            orderEntity5.OrderID = 500;
            orderEntity5.BID = 2;
            orderEntity5.Money = 50;
            orderList.Add(orderEntity5);


            //OrderID去重复
            var orderIDAAA = orderList.Select(a => a.OrderID);
            List<int> orderIDList = orderIDAAA.Distinct().ToList();

            var selleIDG = orderList.GroupBy(i => i.BID).Count();
            //分组数据中，数目大于1的组数有多少组
            var selleIDG2 = orderList.GroupBy(i => i.BID).Where(g => g.Count() > 1).Count();

            var sellerIDGroup = orderList.GroupBy(i => i.BID);
            var sellerIDWhere = sellerIDGroup.Where(g => g.Count() > 1);
            var sellerIDCount = sellerIDWhere.Count() >= 1;

            //判断集合的SellerID是否有重复的值
            bool aaa = orderList.GroupBy(i => i.BID).Where(g => g.Count() > 1).Count() >= 1;
            Console.WriteLine(aaa);


            //按SellerID分组之后，集合行数大于1就代表这个订单需要拆单。
            var sellerIDDaYu1 = orderList.GroupBy(i => i.BID).Count();


            //判断集合中的某个字段是否有重复
            //count2大于1行就是有重复
            int count1 = orderList.Count();
            int count2 = orderList.GroupBy(s => s.BID).Count();


            //将SellerID为Null的打印为666
            //int? aa = 33;
            //var bb = aa;
            //orderList.ForEach(s => Console.WriteLine((s.SellerID == null) ? 666 : s.SellerID));

            ////将SellerID为Null的赋值为777
            //orderList.ForEach(s => s.SellerID = ((s.SellerID == null) ? 777 : s.SellerID));

            //var ccc = orderList.ToArray();

            ////查询分组后的结果
            //var groupSellerID = from t in orderList
            //                    group t by new { SellerIDAA = t.BID } into g
            //                    select g;

            ////拿到分组中的最大值
            //var groupSellerID2 = from t in orderList
            //                     group t by new { SellerIDAA = t.BID } into g
            //                     select new Order
            //                     {
            //                         BID = g.Key.SellerIDAA,
            //                         OrderID = g.Max(v => v.OrderID)
            //                     };

            ////各个分组的最大值相加
            //var groupSellerID3 = (from t in orderList
            //                      group t by new { SellerIDAA = t.BID } into g
            //                      select new Order
            //                      {
            //                          BID = g.Key.SellerIDAA,
            //                          OrderID = g.Max(v => v.OrderID)
            //                      }).Sum(su => su.OrderID);


            //根据某个字段是否重复，去重复
            Console.WriteLine("去重复后的结果");

            ///1，根据BID分组，因为有3个不同的BID，所以分成了3组，每组有N条数据。插入到了g表，这个g表主键为AA。
            ///2，根据这个g表查询字段，每个组的字段要怎么显示？
            ///3，按照下面的查询可以看到：
            ///BID字段默认赋值AA，
            ///OrderID字段默认取小组第一个(也就是N条数据的第一条)，
            ///Money字段赋值为这个小组的总和（也就是N条数据的相加值）。   
            ///如果不想有值，不查询就可以了。
            var distinctByResult = from t in orderList
                                   group t by new { AA = t.BID } into g
                                   select new Order
                                   {
                                       BID = g.Key.AA,
                                       OrderID = g.FirstOrDefault().OrderID,
                                       Money = g.Sum(v => v.Money)
                                   };


            //再加上排序
            var distinctByOrderByResult = (from t in orderList
                                           group t by new { AA = t.BID } into g
                                           select new Order
                                           {
                                               BID = g.Key.AA,
                                               OrderID = g.FirstOrDefault().OrderID,
                                               Money = g.Sum(v => v.Money)
                                           }).OrderBy(o => o.BID);



            Console.ReadKey();
        }
    }

    public class Order
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        public int? BID { get; set; }

        /// <summary>
        /// 金额：单位元
        /// </summary>
        public decimal Money { get; set; }

    }
}
