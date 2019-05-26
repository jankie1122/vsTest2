using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Log4netTest.Controllers
{
    public class WriteLogController : Controller
    {
        // GET: WriteLog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WriteLog4netInfo()
        {
            //经过测试，即使中途报错，还是可以记录前面的日志

            int currentInt = 444;
            LogHelper.RecordInfo(currentInt + "银行支付，支付中心，RecordInfo");
            LogHelper.Info(currentInt + "银行支付，支付中心，Info");

            string aaa = "123asd";
            int bbb = Convert.ToInt32(aaa);

            LogHelper.Error(currentInt + "银行支付，Error");
            Exception ex1 = new Exception();
            LogHelper.RecordErro(currentInt + "银行支付，RecordError", ex1);



            return Json("<script>alert('记录成功!')</script>");
        }
    }


    /// <summary>
    /// Log4Net日志帮助类
    /// 采用多线程,基于内存队列在不影响性能的情况下记录日志。
    /// 主要使用方法：RecordErro()
    /// RecordInfo()
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// 信息标志
        /// </summary>
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("LogInfo");
        /// <summary>
        /// 错误标志
        /// </summary>
        private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("LogError");

        /// <summary>
        /// Log4Net异常记录封装  
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void RecordErro(string message, Exception ex)
        {
            RecordLog(Error, message, ex);
        }

        /// <summary>
        ///  Log4Net一般信息记录封装
        /// </summary>
        /// <param name="message"></param>
        public static void RecordInfo(string message)
        {
            RecordLog(Info, message);
        }

        /// <summary>
        /// Log4Net信息记录封装  
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void Info(string message)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(message);
            }
        }

        /// <summary>
        /// Log4Net错误记录封装   
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void Error(string message)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(message);
            }
        }

        /// <summary>
        /// Log4Net错误记录封装   
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static void Error(string message, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                if (!string.IsNullOrEmpty(message) && ex == null)
                {
                    logerror.ErrorFormat("<br/>【附加信息】 : {0}<br>", new object[] { message });
                }
                else if (!string.IsNullOrEmpty(message) && ex != null)
                {
                    string errorMsg = BeautyErrorMsg(ex);
                    logerror.ErrorFormat("<br/>【附加信息】 : {0}<br>{1}", new object[] { message, errorMsg });
                }
                else if (string.IsNullOrEmpty(message) && ex != null)
                {
                    string errorMsg = BeautyErrorMsg(ex);
                    logerror.Error(errorMsg);
                }
            }
        }

        /// <summary>
        /// 美化错误信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns>错误信息</returns>
        private static string BeautyErrorMsg(Exception ex)
        {
            string errorMsg = string.Format("【异常类型】：{0} <br>【异常信息】：{1} <br>【堆栈调用】：{2}",
                new object[] { ex.GetType().Name, ex.Message, ex.StackTrace });
            errorMsg = errorMsg.Replace("\r\n", "<br>");
            errorMsg = errorMsg.Replace("位置", "<strong style=\"color:red\">位置</strong><br/>");
            return errorMsg;
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="method">日志记录类型的方法</param>
        /// <param name="message">消息内容</param>
        private static void RecordLog(Action<string> method, string message)
        {
            ThreadPool.QueueUserWorkItem(x => method(message));
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="method">日志记录类型的方法</param>
        /// <param name="message">消息内容</param>
        /// <param name="ex">异常</param>
        private static void RecordLog(Action<string, Exception> method, string message, Exception ex)
        {
            ThreadPool.QueueUserWorkItem(x => method(message, ex));
            //think about this soluation later
            //Task.Factory.StartNew(() => Logger.Error(message, ex));
        }
    }
}