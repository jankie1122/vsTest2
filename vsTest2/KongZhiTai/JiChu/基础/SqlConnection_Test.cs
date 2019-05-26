using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class SqlConnection_Test
    {
        public static void SqlConnection_Test_Main()
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
                StringBuilder commandTextSB = new StringBuilder();
                commandTextSB.Append(" DECLARE @StuID Varchar(50) set @StuID=@StuIDAAA update Students set StuName=@StuName where charindex(',' + cast(StuID as varchar) + ',',',' + @StuID + ',') > 0");
                //创建命令对象
                SqlCommand cmd = new SqlCommand(commandTextSB.ToString(), myConn);
                //执行命令
                string stuIDArray = "1,2";
                cmd.Parameters.Add(new SqlParameter("@StuIDAAA", stuIDArray));
                cmd.Parameters.Add(new SqlParameter("@StuName", "2222"));
                int exeInt = cmd.ExecuteNonQuery();
                Console.WriteLine(exeInt);

                //创建一个 DataSet对象
                DataSet myDataSet = new DataSet();
                //执行查询语句
                string querySql = " select * from Students";
                SqlDataAdapter myCommand = new SqlDataAdapter(querySql, myConn);
                myCommand.Fill(myDataSet, "Students");

                DataTable datable = myDataSet.Tables[0];

                for (int i = 0; i < datable.Rows.Count; i++)
                {
                    var stuName = datable.Rows[i]["StuName"];
                    Console.WriteLine(stuName);
                    var stuAge = datable.Rows[i]["StuAge"];
                    Console.WriteLine(stuAge);
                }

                myConn.Close();//关闭连接        
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1);
            }
            Console.ReadKey();
        }
    }
}
