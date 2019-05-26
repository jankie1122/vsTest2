using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublishSubscribeMode.ICommon
{
    public class SubscribePublish
    {
        //定义发布事件
        public delegate void PublishHandle(string str);
        //定义发布接口
        public interface IPublish
        {
            /// <summary>
            /// 发布事件
            /// </summary>
            event PublishHandle PublishEvent;
            void Notify(string str);
        }
        //-----------------------------------------------
        //定义订阅事件
        public delegate void SubscribeHandle(string str);
        //定义订阅接口
        public interface ISubscribe
        {
            /// <summary>
            /// 订阅事件
            /// </summary>
            event SubscribeHandle SubscribeEvent;
        }

        //---------------------------------------

        //然后我们来设计订阅器。显然订阅器要实现双向解耦，就一定要继承上面两个接口，
        //这也是我为什么用接口不用抽象类的原因(类是单继承)。

        public class SubPubComponet : ISubscribe, IPublish
        {
            /// <summary>
            /// 订阅器名字
            /// </summary>
            private string _subName;

            /// <summary>
            /// 订阅器
            /// </summary>
            /// <param name="subName">订阅器名字</param>
            public SubPubComponet(string subName)
            {
                this._subName = subName;
                PublishEvent += new PublishHandle(Notify);
            }

            #region 订阅者 ISubscribe Members
            event SubscribeHandle subscribeEvent;
            event SubscribeHandle ISubscribe.SubscribeEvent
            {
                add { subscribeEvent += value; }
                remove { subscribeEvent -= value; }
            }
            #endregion

            #region 发布者 IPublish Members

            public PublishHandle PublishEvent;

            event PublishHandle IPublish.PublishEvent
            {
                add { PublishEvent += value; }
                remove { PublishEvent -= value; }
            }
            #endregion

            /// <summary>
            /// 具体执行事件
            /// </summary>
            /// <param name="str"></param>
            public void Notify(string str)
            {
                if (subscribeEvent != null)
                {
                    subscribeEvent.Invoke(string.Format("消息来源{0}:消息内容:{1}", _subName, str));
                }
            }
        }

        //接下来是设计订阅者S。S类中使用了ISubscribe来与S.P进行解耦。代码如下：

        public class Subscriber
        {
            private string _subscriberName;

            public Subscriber(string subscriberName)
            {
                this._subscriberName = subscriberName;
            }

            public ISubscribe AddSubscribe { set { value.SubscribeEvent += Show; } }
            public ISubscribe RemoveSubscribe { set { value.SubscribeEvent -= Show; } }

            /// <summary>
            /// 打印订阅发布的事件
            /// </summary>
            /// <param name="str"></param>
            private void Show(string str)
            {
                Console.WriteLine(string.Format("我是{0}，我收到订阅的消息是:{1}", _subscriberName, str));
            }
        }

        //最后是发布者P，继承IPublish来对S.P发布消息通知。 
        public class Publisher : IPublish
        {
            private string _publisherName;

            public Publisher(string publisherName)
            {
                this._publisherName = publisherName;
            }

            private event PublishHandle PublishEvent;
            event PublishHandle IPublish.PublishEvent
            {
                add { PublishEvent += value; }
                remove { PublishEvent -= value; }
            }

            public void Notify(string str)
            {
                if (PublishEvent != null)
                {
                    PublishEvent.Invoke(string.Format("我是{0},我发布{1}消息", _publisherName, str));
                }
            }
        }

    }
}