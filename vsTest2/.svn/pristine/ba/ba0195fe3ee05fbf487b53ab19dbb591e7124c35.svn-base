using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace List_ConvertTo_DataTable
{
    class Program
    {
        static void Main(string[] args)
        {

            List<ValueCardSaveTradeFlow> flowList = new List<ValueCardSaveTradeFlow>();
            for (int i = 0; i < 3; i++)
            {
                ValueCardSaveTradeFlow flowEntity = new ValueCardSaveTradeFlow()
                {
                    TradeID = "T132456",
                    CardID = "55669",
                    DebitValue = 0,
                    CreditValue = 300,
                    AwardValue = 10 + i,
                    CardValue = 999,
                    CreateDate = DateTime.Now,
                    FinishPayDate = DateTime.Now,
                    OuterID = "88888999999666654",
                    TradeMemo = "备注"
                };
                flowList.Add(flowEntity);
            }



            ValueCardSaveTradeFlow flowEntityType = flowList[0];
            //拿到实体类型
            Type entityType = flowEntityType.GetType();
            //创建table并设置table的名字
            DataTable dt = new DataTable(entityType.Name);
            //遍历创建列的名字
            foreach (PropertyInfo propertyInfo in entityType.GetProperties())
            {
                //这里可以改变列的名字
                string columnName = propertyInfo.Name;

                switch (columnName)
                {
                    case "TradeID":
                        columnName = "订单号";
                        break;
                    case "CardID":
                        columnName = "卡号";
                        break;
                    case "DebitValue":
                        columnName = "支出";
                        break;
                    case "CreditValue":
                        columnName = "实付金额";
                        break;
                    case "AwardValue":
                        columnName = "赠送金额";
                        break;
                    case "CardValue":
                        columnName = "余额";
                        break;
                    case "CreateDate":
                        columnName = "创建时间";
                        break;
                    case "FinishPayDate":
                        columnName = "完成支付时间";
                        break;
                    case "OuterID":
                        columnName = "交易号";
                        break;
                    case "TradeMemo":
                        columnName = "订单备注";
                        break;
                }

                //DataColumn columu = new DataColumn(propertyInfo.Name);
                dt.Columns.Add(columnName);

                //---------------------------------               
            }




            //开始给每行赋值
            DataRow dr;
            foreach (object itemFlow in flowList)
            {
                dr = dt.NewRow();
                //给每个字段赋值
                foreach (PropertyInfo propertyInfo in entityType.GetProperties())
                {
                    //当前字段的索引
                    int index = entityType.GetProperties().ToList().IndexOf(propertyInfo);
                    dr[index] = propertyInfo.GetValue(itemFlow, null);
                }
                dt.Rows.Add(dr);
            }




            ////开始给每行赋值
            //DataRow dr;
            //foreach (object itemFlow in flowList)
            //{
            //    dr = dt.NewRow();
            //    //给每个字段赋值
            //    foreach (PropertyInfo propertyInfo in entityType.GetProperties())
            //    {
            //        //当前字段的索引
            //        int index = entityType.GetProperties().ToList().IndexOf(propertyInfo);

            //        if (propertyInfo.Name.Equals(itemFlow.GetType().GetProperties()[index].Name))
            //        {                        
            //            dr[index] = propertyInfo.GetValue(itemFlow, null);
            //        }
            //    }
            //    dt.Rows.Add(dr);
            //}

            //开始给每行赋值
            //DataRow dr;
            //foreach (var itemFlow in flowList)
            //{
            //    dr = dt.NewRow();

            //    //dr["TradeID"] = itemFlow.TradeID;
            //    //dr["CardID"] = itemFlow.CardID;

            //    //给每个字段赋值
            //    foreach (PropertyInfo propertyInfo in entityType.GetProperties())
            //    {
            //        //当前字段的索引
            //        int index = entityType.GetProperties().ToList().IndexOf(propertyInfo);

            //        if (propertyInfo.Name.Equals(itemFlow.GetType().GetProperties()[index].Name))
            //        {
            //            //string lieMing = propertyInfo.Name;
            //            //string lieZhi = itemFlow.GetType().GetProperties().GetValue(index).ToString();//使用这种是获取不了值的。
            //            //var lieZhi = propertyInfo.GetValue(itemFlow, null);
            //            dr[propertyInfo.Name] = propertyInfo.GetValue(itemFlow, null);
            //        }
            //    }
            //    dt.Rows.Add(dr);
            //}

            //--------------------------------------------------------------


            //输出属性的名字和值
            //foreach (PropertyInfo i in flowList[0].GetType().GetProperties())
            //{
            //    if (i.PropertyType == typeof(string))//属性的类型判断  
            //    {
            //        string name = i.Name;
            //        object obj = i.GetValue(flowList[0], null);
            //        Console.WriteLine(name);
            //        Console.WriteLine();
            //    }
            //}

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    //列名
                    var sa = dt.Columns[j].ColumnName;
                    Console.WriteLine(sa);
                    //这一行，这一列的值
                    var value = dt.Rows[i][j];
                    Console.WriteLine(value);
                }
            }

            Console.ReadKey();

        }
    }

    public class ValueCardSaveTradeFlow
    {
        /// <summary>
        /// 订单流水ID 主键，商家订单号，内部订单号
        /// </summary>
        public string TradeID { get; set; }


        /// <summary>
        /// 卡ID 主键
        /// </summary>
        public string CardID { get; set; }

        /// <summary>
        /// 支出
        /// </summary>
        public decimal DebitValue { get; set; }

        /// <summary>
        /// 存入，就是实付金额
        /// </summary>
        public decimal CreditValue { get; set; }

        /// <summary>
        /// 赠送
        /// </summary>
        public decimal AwardValue { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal CardValue { get; set; }

        /// <summary>
        /// 操作时间日期时分秒
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 已完成充值时间
        /// </summary>
        public DateTime FinishPayDate { get; set; }

        /// <summary>
        /// 微信支付流水号，外部订单号，交易号
        /// </summary>
        public string OuterID { get; set; }

        /// <summary>
        /// 订单备注
        /// </summary>
        public string TradeMemo { get; set; }

    }
}
