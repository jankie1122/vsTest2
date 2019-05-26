using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redis
{
    class XiaoFeiZhe
    {
        public static void XiaoFeiZheTest() {
            using (var client = RedisManager.ClientManager.GetClient())
            {
                while (true)
                {
                    string email = client.DequeueItemFromList("testqueue");//从消息队列里把它取出来
                    if (email == null)
                    {
                        Console.WriteLine("没有找到数据");
                        Thread.Sleep(2000);//消息队列中没有数据，防止cpu空转，让它停两秒
                        continue;//没找到就进行下一次循环，否侧它会继续往后走
                    }
                    Console.WriteLine("给" + email + "发送邮件");
                    Thread.Sleep(3000);
                    Console.WriteLine("给" + email + "发送邮件完成");
                }
            }
        }
    }
}
