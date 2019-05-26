using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    class RedisManager
    {
        //外部可读get，内部可写set
        public static PooledRedisClientManager ClientManager { get; private set; }
        static RedisManager()
        {
            RedisClientManagerConfig redisConfig = new RedisClientManagerConfig();
            redisConfig.MaxWritePoolSize = 128;
            redisConfig.MaxReadPoolSize = 128;
            //读写分离，多台Redis组成集群，一台Redis服务器瘫痪了，它会自动切换到另外一台服务器。
            //读写分离，几台服务器是用来读取数据的，另外几台服务器是用来写数据的。
            //（new string[] {"127.0.0.1","192.168.1.6"}）数组，可以写多个ip地址，就是多台服务器的意思。
            ClientManager = new PooledRedisClientManager(new string[] { "127.0.0.1" },
                new string[] { "127.0.0.1" }, redisConfig);
        }
    }
}
