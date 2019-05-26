using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PublishSubscribeMode.ICommon.SubscribePublish;

namespace PublishSubscribeMode.Controllers
{

    public class SubPubController : Controller
    {
        // GET: SubPub
        public ActionResult Index()
        {
            //新建两个订阅器
            SubPubComponet subPubComponet1 = new SubPubComponet("订阅器1");
            SubPubComponet subPubComponet2 = new SubPubComponet("订阅器2");



            return View();
        }

        public ActionResult AjaxSubPub()
        {
            //新建两个订阅器
            SubPubComponet subPubComponet1 = new SubPubComponet("订阅器1");
            SubPubComponet subPubComponet2 = new SubPubComponet("订阅器2");
            //新建两个发布者
            IPublish publisher1 = new Publisher("TJVictor1");
            IPublish publisher2 = new Publisher("TJVictor2");
            //与订阅器关联
            publisher1.PublishEvent += subPubComponet1.PublishEvent;
            publisher1.PublishEvent += subPubComponet2.PublishEvent;
            publisher2.PublishEvent += subPubComponet2.PublishEvent;
            //新建两个订阅者
            Subscriber s1 = new Subscriber("订阅人1");
            Subscriber s2 = new Subscriber("订阅人2");
            //进行订阅
            s1.AddSubscribe = subPubComponet1;
            s1.AddSubscribe = subPubComponet2;
            s2.AddSubscribe = subPubComponet2;
            //发布者发布消息
            publisher1.Notify("博客1");
            publisher2.Notify("博客2");
            //发送结束符号
            Console.WriteLine("".PadRight(50, '-'));
            //s1取消对订阅器2的订阅
            s1.RemoveSubscribe = subPubComponet2;
            //发布者发布消息
            publisher1.Notify("博客1");
            publisher2.Notify("博客2");
            //发送结束符号
            Console.WriteLine("".PadRight(50, '-'));


            Console.ReadLine();
            Console.ReadLine();

            return Json("成功");
        }













    }
}