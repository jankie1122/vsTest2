using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormTest.MyCookies
{
    public partial class MyCookies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //创建具有子健的Cookies
            HttpCookie newCookie = new HttpCookie("Appointment-" + "111" + "-" + "222");
            newCookie.Values["ApID"] = "ApID123";
            newCookie.Values["BID"] = "BID333";
            newCookie.Values["OpenID"] = "OpenID444";
            newCookie.Values["AvSkuIDList"] = "avSkuIDList123";
            newCookie.Expires = DateTime.Now.AddHours(1);
            //context.Response.Cookies.Add(newCookie);//添加Cookies
            HttpContext.Current.Response.SetCookie(newCookie);  

        }
    }
}