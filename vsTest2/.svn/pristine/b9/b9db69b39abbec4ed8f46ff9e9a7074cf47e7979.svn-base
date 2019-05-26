using Log4netLevel.Enums;
using Log4netLevel.Utility.Log;
using System;
using System.Web.Mvc;

namespace Log4netLevel.Controllers
{
    public class SysGoodsController : Controller
    {
        // GET: SysGoods
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult WriteLog()
        {
            //OFF > FATAL（致命错误） > ERROR（一般错误） > WARN（警告） > INFO（一般信息） > DEBUG（调试信息） > ALL

            try
            {
                //ServicesLogName文件夹
                Log4NetHelper.Log(LogTypeEnum.ServicesLogName, LogLevelEnum.Error, "（1）一般错误啦啦啦");
                Log4NetHelper.Log(LogTypeEnum.ServicesLogName, LogLevelEnum.Warn, "（2）警告啦啦啦");
                Log4NetHelper.Log(LogTypeEnum.ServicesLogName, LogLevelEnum.Info, "（3）一般信息啦啦啦");
                Log4NetHelper.Log(LogTypeEnum.ServicesLogName, LogLevelEnum.Debug, "（4）调试信息啦啦啦");

                //PayLogName
                Log4NetHelper.Log(LogTypeEnum.PayLogName, LogLevelEnum.Error, "（1）一般错误啦啦啦");
                Log4NetHelper.Log(LogTypeEnum.PayLogName, LogLevelEnum.Warn, "（2）警告啦啦啦");
                Log4NetHelper.Log(LogTypeEnum.PayLogName, LogLevelEnum.Info, "（3）一般信息啦啦啦");
                Log4NetHelper.Log(LogTypeEnum.PayLogName, LogLevelEnum.Debug, "（4）调试信息啦啦啦");


                DateTime aa = Convert.ToDateTime("13");

            }
            catch (Exception ex)
            {
                Log4NetHelper.Log(LogTypeEnum.ServicesLogName, LogLevelEnum.Error, "（5）一般错误啦啦啦", ex);
                Log4NetHelper.Log(LogTypeEnum.ServicesLogName, LogLevelEnum.Warn, "（6）警告啦啦啦", ex);
                Log4NetHelper.Log(LogTypeEnum.ServicesLogName, LogLevelEnum.Info, "（7）一般信息啦啦啦", ex);
                Log4NetHelper.Log(LogTypeEnum.ServicesLogName, LogLevelEnum.Debug, "（8）调试信息啦啦啦", ex);


                Log4NetHelper.Log(LogTypeEnum.PayLogName, LogLevelEnum.Error, "（5）一般错误啦啦啦", ex);
                Log4NetHelper.Log(LogTypeEnum.PayLogName, LogLevelEnum.Warn, "（6）警告啦啦啦", ex);
                Log4NetHelper.Log(LogTypeEnum.PayLogName, LogLevelEnum.Info, "（7）一般信息啦啦啦", ex);
                Log4NetHelper.Log(LogTypeEnum.PayLogName, LogLevelEnum.Debug, "（7）调试信息啦啦啦", ex);

            }

            return Json("哈哈哈");
        }

    }
}