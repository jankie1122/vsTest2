using Log4netLevel.Enums;
using System;
using System.Threading;

namespace Log4netLevel.Utility.Log
{
    /// <summary>
    /// Log4Net日志帮助类
    /// 采用多线程,基于内存队列在不影响性能的情况下记录日志。
    /// </summary>
    public class Log4NetHelper
    {
        /// <summary>
        /// 标准化日志类
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="logLevel"></param>
        /// <param name="message">比如[XXXServices.Add]新增一条XX异常,参数:"++"</param>
        public static void Log(LogTypeEnum logType, LogLevelEnum logLevel, string message, Exception ex = null)
        {
            ThreadPool.QueueUserWorkItem(x => LogByThread(logType, logLevel, message, ex));
        }

        /// <summary>
        /// 基础日志线程
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        private static void LogByThread(LogTypeEnum logType, LogLevelEnum logLevel, string message, Exception ex = null)
        {
            Log4NetWriter log = new Log4NetWriter(logType);
            if (null != ex)
                log.WriteLogException(message, ex);
            else
                log.WriteLog(logLevel, message);
        }
    }
}