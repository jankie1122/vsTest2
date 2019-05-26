using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using 数据批量插入.Domain.TradePercent;

namespace 数据批量插入
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {


                //创建一个 SqlConnection对象 
                //string strCon = "server=服务器名称;uid=登录名称;pwd=登录密码;database=数据库名称";//Sql Server身份验证
                string strCon = "server=.;database=ClassTest;Trusted_Connection=SSPI";//Windows身份验证
                                                                                      //New一个新的数据库对象
                SqlConnection myConn = new SqlConnection(strCon);
                //打开数据库连接
                myConn.Open();
                //执行的查询语句
                //更新多条数据 where id in (1,2,3)              
                //StringBuilder commandTextSB = new StringBuilder();
                //commandTextSB.Append(" DECLARE @StuID Varchar(50) set @StuID=@StuIDAAA update Students set StuName=@StuName where charindex(',' + cast(StuID as varchar) + ',',',' + @StuID + ',') > 0");
                ////创建命令对象
                //SqlCommand cmd = new SqlCommand(commandTextSB.ToString(), myConn);


                //创建一个 DataSet对象
                DataSet myDataSet = new DataSet();
                //执行查询
                string sql = " select * from WxTradePercent  ";
                SqlDataAdapter myCommand = new SqlDataAdapter(sql, myConn);
                myCommand.Fill(myDataSet, "WxTradePercent");

                var result = myDataSet.Tables;

                //插入数据

                WxTradePercent entity1 = new WxTradePercent();
                entity1.TradeID = "";
                entity1.GoodsID = null;
                entity1.PtType ="goods";
                entity1.BID = 957;
                entity1.UserID = 123;
                entity1.GiveToUserID = 456;
                entity1.Value = 100;
                entity1.TradePayment = 200;
                entity1.PercentTage = null;
                entity1.PecentLevel = 1;
                entity1.Status = 1;
                entity1.InsertTime = DateTime.Now;
                entity1.UpdateTime = null;
                entity1.DrawID = null;

                //创建命令对象
                string sqlInsert =@" insert into WxTradePercent 
(TradeID, GoodsID, PtType, BID, UserID,
GiveToUserID, Value, TradePayment, PercentTage, PecentLevel,
Status, InsertTime, UpdateTime, DrawID)
select @TradeID, @GoodsID, @PtType, @BID, @UserID,
@GiveToUserID, @Value, @TradePayment, @PercentTage, @PecentLevel,
@Status, @InsertTime, @UpdateTime, @DrawID";
                SqlCommand cmd = new SqlCommand(sqlInsert, myConn);

                var para = new SqlParameter();
             
                cmd.Parameters.Add(para);

                SqlDataAdapter adapterInsert = new SqlDataAdapter();
                adapterInsert.InsertCommand = cmd;
                DataSet dataSetInsert = new DataSet();
                
              

              int insertCount =  cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {

                throw ex;
            }




        }


    }
}
