using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    class ShengChanZhe
    {
        public void ShengChanZheTest()
        {
            while (true)
            {
                string line = Console.ReadLine();
                using (var client = RedisManager.ClientManager.GetClient())
                {
                    //EnQueue:入队列：DeQueue:出队列。acdw，先入先出
                    client.EnqueueItemOnList("testqueue", line);
                }
            }
        }
    }
}
