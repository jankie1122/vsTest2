using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormTest.MyCookies
{
    public partial class CookiesGet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpContext.Current.Request.Cookies["Appointment-" + "111" + "-" + "222"];
        }
    }
}