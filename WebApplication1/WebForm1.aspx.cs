using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Application.Lock();
            Application["PagerequestCount"] = ((int)Application["PagerequestCount"]) + 1;
            Application.UnLock();
            sm1.RegisterAsyncPostBackControl(button1);
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            int intreqcount = 0;
            Application.Lock();
            Application["PagerequestCount"] = ((int)Application["PagerequestCount"]) + 1;
            Application.UnLock();
            Response.Write(((int)Application["PagerequestCount"]));
            if(intreqcount > 0)  panel3.Update();
        }
    }
}