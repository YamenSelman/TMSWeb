using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class Administration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).Role.Equals("admin")))
            {
                Response.Redirect("Home.aspx", false);
            }
        }

        protected void logout(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}