using Log4netLevel.Enums;
using System;

namespace Log4netLevel.Utility.Log
{
    /// <summary>
    /// Log4Net日志分层文件夹写入类
    /// </summary>
    public class Log4NetWriter
    {
        /// <summary>
        /// 日志接口
        /// </summary>
        private log4net.ILog _log4Net;
        public Log4NetWriter(LogTypeEnum logType)
        {
            _log4Net = log4net.LogManager.GetLogger(logType.ToString());
        }


        /// <summary>
        /// 记录系统日志
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="message">输出的消息</param>
        public void WriteLog(LogLevelEnum logLevel, string message)
        {
            //OFF > FATAL（致命错误） > ERROR（一般错误） > WARN（警告） > INFO（一般信息） > DEBUG（调试信息） > ALL
            switch (logLevel)
            {
                case LogLevelEnum.Error:
                    _log4Net.Error(message);
                    break;
                case LogLevelEnum.Warn:
                    _log4Net.Warn(message);
                    break;
                case LogLevelEnum.Info:
                    _log4Net.Info(message);
                    break;
                case LogLevelEnum.Debug:
                    _log4Net.Debug(message);
                    break;
            }
        }

        /// <summary>
        /// 记录带异常系统日志
        /// </summary>
        /// <param name="message">输出的消息</param>
        /// <param name="ex">ex</param>
        public void WriteLogException(string message, Exception ex)
        {
            string errorMsg = string.Empty;
            if (!string.IsNullOrEmpty(message) && ex == null)
            {
                errorMsg = string.Format("<br/>【附加信息】 : {0}<br>", new object[] { message });
            }
            else if (!string.IsNullOrEmpty(message) && ex != null)
            {
                var erroEx = BeautyErrorMsg(ex);
                errorMsg = string.Format("<br/>【附加信息】 : {0}<br>{1}", new object[] { message, erroEx });
            }
            else if (string.IsNullOrEmpty(message) && ex != null)
            {
                errorMsg = BeautyErrorMsg(ex);
            }
            WriteLog(LogLevelEnum.Error, errorMsg);
        }
        /// <summary>
        /// 美化错误信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns>错误信息</returns>
        public string BeautyErrorMsg(Exception ex)
        {
            string errorMsg = string.Format("【异常类型】：{0} <br>【异常信息】：{1} <br>【堆栈调用】：{2}",
                new object[] { ex.GetType().Name, ex.Message, ex.StackTrace });
            errorMsg = errorMsg.Replace("\r\n", "<br>");
            errorMsg = errorMsg.Replace("位置", "<strong style=\"color:red\">位置</strong><br/>");
            return errorMsg;
        }


        //OFF > FATAL（致命错误） > ERROR（一般错误） > WARN（警告） > INFO（一般信息） > DEBUG（调试信息） > ALL

        ///// <summary>
        ///// 输出错误级别日志
        ///// </summary>
        ///// <param name="message">输出的消息</param>
        //public void Error(string message)
        //{
        //    //记录日志
        //    WriteLog(LogLevelEnum.Error, message);
        //}

        ///// <summary>
        ///// 输出警告级别日志
        ///// </summary>
        ///// <param name="message">输出的消息</param>
        //public void Warning(string message)
        //{
        //    //记录日志
        //    WriteLog(LogLevelEnum.Warn, message);
        //}

        ///// <summary>
        ///// 输出信息级别日志
        ///// </summary>
        ///// <param name="message">输出的消息</param>
        //public void Info(string message)
        //{
        //    //记录日志
        //    WriteLog(LogLevelEnum.Info, message);
        //}

        ///// <summary>
        ///// 输出调试级别日志
        ///// </summary>
        ///// <param name="message">输出的消息</param>
        //public void Debug(string message)
        //{
        //    //记录日志
        //    WriteLog(LogLevelEnum.Debug, message);
        //}
    }
}