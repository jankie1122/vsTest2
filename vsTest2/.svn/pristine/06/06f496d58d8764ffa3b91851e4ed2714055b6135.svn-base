//using CacheManageLibrary1.Redis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    class Program
    {
        //private static readonly string redis_string_test = "redis_string_test";
        //private static readonly string redis_string_model = "redis_string_model";
        //private static readonly string StringIncrement = "StringIncrement";
        //private static readonly string list = "list";
        /// <summary>
        /// 入栈，出栈
        /// </summary>
        //private static readonly string listLeft = "listLeft";//入栈，出栈
        static void Main(string[] args)
        {
            // RedisHelper redis = new RedisHelper(1);

            #region String           


            #region --------------------保存单个key value，获取单个key的值
            /*
            string str = "";
            var result = redis.StringSet(redis_string_test, str);
            if (result == false)
            {
                Console.WriteLine("保存单个key value失败");
                return;
            }
            Console.WriteLine("保存单个key value成功");
            Console.ReadKey();
            Console.WriteLine("按回车读取");
            Console.ReadKey();
            var str1 = redis.StringGet(redis_string_test);
            Console.WriteLine("读取结果：" + str1);
            Console.ReadKey();
            */

            #endregion -----------------保存单个key value，获取单个key的值

            #region -------------------保存一个对象，读取一个对象
            /*
            Demo demo = new Demo()
            {
                Id = 2,
                Name = "jankie1"
            };
            bool result = redis.StringSet(redis_string_model, demo);
            if (result == false)
            {
                Console.WriteLine("保存一个对象失败");
                return;
            }
            Console.WriteLine("保存成功");
            Console.ReadKey();
            Demo model = redis.StringGet<Demo>(redis_string_model);
            Console.WriteLine("Id:" + model.Id);
            Console.WriteLine("Name:" + model.Name);
            Console.ReadKey();
            */
            #endregion -------------------保存一个对象，读取一个对象

            #region  Redis递增，递减
            /*
            Console.WriteLine("开始时候的数值：" + redis.StringGet(StringIncrement));
            Console.WriteLine("递增开始");
            for (int i = 0; i < 3; i++)
            {
                redis.StringIncrement(StringIncrement, 4);
                Console.WriteLine(redis.StringGet(StringIncrement));
                Thread.Sleep(2000);
            }
            Console.WriteLine("开始递减");
            for (int i = 0; i < 3; i++)
            {
                redis.StringDecrement(StringIncrement, 3);
                Console.WriteLine(redis.StringGet(StringIncrement));
                Thread.Sleep(2000);
            }
            Console.ReadKey();
            */
            #endregion Redis递增，递减


            #endregion String

            #region  ---------------List
            /*
            Console.WriteLine("程序开始的时候，redis队列的key的value[0]的值：" + (redis.ListRange<string>(list))[0]);
            //for (int i = 0; i < 10; i++)
            //{
            //    redis.ListRightPush(list, i);
            //    //Console.WriteLine("redis的key的值：" + redis.StringGet(list));
            //    Thread.Sleep(3000);
            //}
            var list1 = redis.ListRange<int>(list);

            for (int i = 0; i < list1.Count; i++)
            {
                Console.WriteLine("出队：redis key键：{0}，值：{1}", i + 1, list1[i]);
            }
            Console.WriteLine("出完对列后，移除后面的排队的人");
            Console.ReadKey();
            //redis.ListRemove<string>(list,"9");//没有生效
            Console.WriteLine("移除完成");
            */


            /*
            for (int i = 0; i < 5; i++)
            {
                redis.ListLeftPush(listLeft, i);
                Console.WriteLine("程序此刻redis的value里面的key的值：" + (redis.ListRange<string>(listLeft))[0]);
                Console.ReadKey();
            }
            var listZhan = redis.ListRange<int>(listLeft);

            for (int i = 0; i < listZhan.Count; i++)
            {
                Console.WriteLine("出栈：redis key键：{0}，值：{1}", i + 1, listZhan[i]);
            }
            Console.WriteLine("结束了");
            Console.ReadKey();
            */
            #endregion  ---------------List

            #region Hash

            RedisHelper redis = new RedisHelper(1);
            Demo demo = new Demo()
            {
                Id = 1,
                Name = "jankie",
            };
            Console.WriteLine("准备插入");
            Console.ReadKey();
            redis.HashSet("user", "u1", "123");
            Console.WriteLine("u1插入成功");
            Console.ReadKey();
            redis.HashSet("user", "u2", demo);
            Console.WriteLine("u2插入成功");
            Console.ReadKey();
            redis.HashSet("user", "u3", JsonConvert.SerializeObject(demo));
            Console.WriteLine("u3插入成功");
            Console.ReadKey();
            Demo newsU2 = redis.HashGet<Demo>("user", "u2");
            string newsU3 = redis.HashGet<string>("user", "u3");
            Console.WriteLine("u2：" + redis.HashExists("user", "u2"));
            Console.WriteLine("u3：" + redis.HashExists("user", "u3"));
            Console.WriteLine(newsU2);
            Console.WriteLine(newsU3);
            Console.ReadKey();

            #endregion Hash

            #region----授权信息，----
            /*
             * 覆盖，如果之前是stringSet,现在变为hashSet,不能成功覆盖。
             * 如果之前是HashSet,现在变为StringSet,可以成功覆盖。
             * 
            RedisHelper redis = new RedisHelper(1);
            Demo demo = new Demo()
            {
                Id = 1,
                Name = "jankie",
            };
            Console.WriteLine("准备插入");
            Console.ReadKey();
            redis.StringSet("user","123456");
            Console.WriteLine("插入成功");
            Console.ReadKey();
            Console.WriteLine("准备取出");
            Console.ReadKey();
            string hahah = redis.StringGet("user");
            Console.WriteLine("取出成功"+hahah);

            Console.ReadKey();
            */
            #endregion

            #region 发布订阅
            /*
            while (true)
            {
                redis.Subscribe("Channel1");
                Thread.Sleep(2000);




                //for (int i = 0; i < 5; i++)
                //{
                //    Console.WriteLine("准备发布");
                //    Console.ReadKey();
                //    redis.Publish("Channel1", "msg" + i);
                //    Console.WriteLine("一条消息发布完毕");
                //    Console.ReadKey();
                //    //if (i==2)
                //    //{
                //    //    redis.Unsubscribe("Channel1");
                //    //}
                //}
               

            Console.WriteLine("程序执行完毕");
            
            //Console.ReadKey();
        }
         */
            #endregion


            #region----微信泛型List存到redis测试----
            /*
            RedisHelper redis = new RedisHelper(2);

            QueryAuthResult queryAuthResultEntity = new QueryAuthResult();

            AuthorizationInfo authorizationInfo = new AuthorizationInfo();
            authorizationInfo.authorizer_appid = "appid";
            authorizationInfo.authorizer_access_token = "accessToken";
            authorizationInfo.expires_in = 7200;
            authorizationInfo.authorizer_refresh_token = "refresh_token";

            AuthorizationInfo_FuncscopeCategory authorizationInfo_FuncscopeCategory = new AuthorizationInfo_FuncscopeCategory();
            authorizationInfo_FuncscopeCategory.id = (FuncscopeCategory.业务通知权限集);

            FuncscopeCategoryItem funcscopeCategoryItem = new FuncscopeCategoryItem();
            funcscopeCategoryItem.funcscope_category = authorizationInfo_FuncscopeCategory;
            List<FuncscopeCategoryItem> func_info = new List<FuncscopeCategoryItem>();
            func_info.Add(funcscopeCategoryItem);

            queryAuthResultEntity.authorization_info = authorizationInfo;
            queryAuthResultEntity.authorization_info.func_info = func_info;

            //判断授权码是否为空
            string isNUll = queryAuthResultEntity.authorization_info.authorizer_access_token;
            

            //将泛型集合对象转换成Json
            string json = JsonConvert.SerializeObject(queryAuthResultEntity);

            QueryAuthResult aaa = new QueryAuthResult();
            //将Json转换成泛型集合对象
            aaa = JsonConvert.DeserializeObject<QueryAuthResult>(json);

            //redis.StringSet("OAuthTestQueryAuthResultEntity",);

            
    */

            #endregion
        }
    }

    public class Demo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IJsonResult
    {
        string errmsg { get; set; }
        object P2PData { get; set; }
    }
    public interface IWxJsonResult : IJsonResult
    {
        ReturnCode errcode { get; set; }
    }
    /// <summary>
    /// 公众号JSON返回结果（用于菜单接口等）
    /// </summary>
    public class WxJsonResult : IWxJsonResult
    {
        public ReturnCode errcode { get; set; }
        public string errmsg { get; set; }
        /// <summary>
        /// 为P2P返回结果做准备
        /// </summary>
        public virtual object P2PData { get; set; }
        //public ReturnCode ReturnCode
        //{
        //    get
        //    {
        //        try
        //        {
        //            return (ReturnCode) errorcode;
        //        }
        //        catch
        //        {
        //            return ReturnCode.系统繁忙;//如果有“其他错误”的话可以指向其他错误
        //        }
        //    }
        //}
    }

    public class QueryAuthResult : WxJsonResult
    {
        /// <summary>
        /// 授权信息
        /// </summary>
        public AuthorizationInfo authorization_info { get; set; }
    }

    public class AuthorizationInfo
    {
        /// <summary>
        /// 授权方appid
        /// </summary>
        public string authorizer_appid { get; set; }
        /// <summary>
        /// 授权方令牌（在授权的公众号具备API权限时，才有此返回值）
        /// </summary>
        public string authorizer_access_token { get; set; }
        /// <summary>
        /// 有效期（在授权的公众号具备API权限时，才有此返回值）
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 刷新令牌（在授权的公众号具备API权限时，才有此返回值），刷新令牌主要用于公众号第三方平台获取和刷新已授权用户的access_token，只会在授权时刻提供，请妥善保存。 一旦丢失，只能让用户重新授权，才能再次拿到新的刷新令牌
        /// </summary>
        public string authorizer_refresh_token { get; set; }
        /// <summary>
        /// 公众号授权给开发者的权限集列表（请注意，当出现用户已经将消息与菜单权限集授权给了某个第三方，再授权给另一个第三方时，由于该权限集是互斥的，后一个第三方的授权将去除此权限集，开发者可以在返回的func_info信息中验证这一点，避免信息遗漏），
        /// 1到8分别代表：
        ///消息与菜单权限集
        ///用户管理权限集
        ///帐号管理权限集
        ///网页授权权限集
        ///微信小店权限集
        ///多客服权限集
        ///业务通知权限集
        ///微信卡券权限集
        /// </summary>
        public List<FuncscopeCategoryItem> func_info { get; set; }
    }

    public class FuncscopeCategoryItem
    {
        public AuthorizationInfo_FuncscopeCategory funcscope_category { get; set; }
    }

    public class AuthorizationInfo_FuncscopeCategory
    {
        public FuncscopeCategory id { get; set; }
    }
    public enum FuncscopeCategory
    {
        消息与菜单权限集 = 1,
        用户管理权限集 = 2,
        帐号管理权限集 = 3,
        网页授权权限集 = 4,
        微信小店权限集 = 5,
        多客服权限集 = 6,
        业务通知权限集 = 7,
        微信卡券权限集 = 8,
        素材管理权限集 = 9,
        摇一摇周边权限集 = 10,
        线下门店权限集 = 11,
        微信连WIFI权限集 = 12,
        未知类型 = 13
    }
    public enum ReturnCode
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        系统繁忙此时请开发者稍候再试 = -1,
        请求成功 = 0,
        获取access_token时AppSecret错误或者access_token无效 = 40001,
        不合法的凭证类型 = 40002,
        不合法的OpenID = 40003,
        不合法的媒体文件类型 = 40004,
        不合法的文件类型 = 40005,
        不合法的文件大小 = 40006,
        不合法的媒体文件id = 40007,
        不合法的消息类型 = 40008,
        不合法的图片文件大小 = 40009,
        不合法的语音文件大小 = 40010,
        不合法的视频文件大小 = 40011,
        不合法的缩略图文件大小 = 40012,
        不合法的APPID = 40013,
        不合法的access_token = 40014,
        不合法的菜单类型 = 40015,
        不合法的按钮个数1 = 40016,
        不合法的按钮个数2 = 40017,
        不合法的按钮名字长度 = 40018,
        不合法的按钮KEY长度 = 40019,
        不合法的按钮URL长度 = 40020,
        不合法的菜单版本号 = 40021,
        不合法的子菜单级数 = 40022,
        不合法的子菜单按钮个数 = 40023,
        不合法的子菜单按钮类型 = 40024,
        不合法的子菜单按钮名字长度 = 40025,
        不合法的子菜单按钮KEY长度 = 40026,
        不合法的子菜单按钮URL长度 = 40027,
        不合法的自定义菜单使用用户 = 40028,
        不合法的oauth_code = 40029,
        不合法的refresh_token = 40030,
        不合法的openid列表 = 40031,
        不合法的openid列表长度 = 40032,
        不合法的请求字符不能包含uxxxx格式的字符 = 40033,
        不合法的参数 = 40035,

        //小程序、 公众号都有
        template_id不正确 = 40037,

        不合法的请求格式 = 40038,
        不合法的URL长度 = 40039,
        不合法的分组id = 40050,
        分组名字不合法 = 40051,
        appsecret不正确 = 40125,//invalid appsecret
        缺少access_token参数 = 41001,
        缺少appid参数 = 41002,
        缺少refresh_token参数 = 41003,
        缺少secret参数 = 41004,
        缺少多媒体文件数据 = 41005,
        缺少media_id参数 = 41006,
        缺少子菜单数据 = 41007,
        缺少oauth_code = 41008,
        缺少openid = 41009,

        //小程序
        form_id不正确_或者过期 = 41028,
        form_id已被使用 = 41029,
        page不正确 = 41030,

        access_token超时 = 42001,
        refresh_token超时 = 42002,
        oauth_code超时 = 42003,
        需要GET请求 = 43001,
        需要POST请求 = 43002,
        需要HTTPS请求 = 43003,
        需要接收者关注 = 43004,
        需要好友关系 = 43005,
        多媒体文件为空 = 44001,
        POST的数据包为空 = 44002,
        图文消息内容为空 = 44003,
        文本消息内容为空 = 44004,
        多媒体文件大小超过限制 = 45001,
        消息内容超过限制 = 45002,
        标题字段超过限制 = 45003,
        描述字段超过限制 = 45004,
        链接字段超过限制 = 45005,
        图片链接字段超过限制 = 45006,
        语音播放时间超过限制 = 45007,
        图文消息超过限制 = 45008,
        接口调用超过限制 = 45009,
        创建菜单个数超过限制 = 45010,
        回复时间超过限制 = 45015,
        系统分组不允许修改 = 45016,
        分组名字过长 = 45017,
        分组数量超过上限 = 45018,
        不存在媒体数据 = 46001,
        不存在的菜单版本 = 46002,
        不存在的菜单数据 = 46003,
        解析JSON_XML内容错误 = 47001,
        api功能未授权 = 48001,
        用户未授权该api = 50001,
        参数错误invalid_parameter = 61451,
        无效客服账号invalid_kf_account = 61452,
        客服帐号已存在kf_account_exsited = 61453,
        /// <summary>
        /// 客服帐号名长度超过限制(仅允许10个英文字符，不包括@及@后的公众号的微信号)(invalid kf_acount length)
        /// </summary>
        客服帐号名长度超过限制 = 61454,
        /// <summary>
        /// 客服帐号名包含非法字符(仅允许英文+数字)(illegal character in kf_account)
        /// </summary>
        客服帐号名包含非法字符 = 61455,
        /// <summary>
        ///  	客服帐号个数超过限制(10个客服账号)(kf_account count exceeded)
        /// </summary>
        客服帐号个数超过限制 = 61456,
        无效头像文件类型invalid_file_type = 61457,
        系统错误system_error = 61450,
        日期格式错误 = 61500,
        日期范围错误 = 61501,

        //新加入的一些类型，以下文字根据P2P项目格式组织，非官方文字
        发送消息失败_48小时内用户未互动 = 10706,
        发送消息失败_该用户已被加入黑名单_无法向此发送消息 = 62751,
        发送消息失败_对方关闭了接收消息 = 10703,
        对方不是粉丝 = 10700,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    }


}
