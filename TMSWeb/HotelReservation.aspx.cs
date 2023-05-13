using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class HotelReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).Role.Equals("customer")))
            {
                Response.Redirect("Home.aspx", false);
            }
            else
            {
                hotelsGrid.DataSource = Helper.getAllHotels();
                hotelsGrid.DataBind();
            }
        }

        protected void hotelsGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page_Load(null, null);
        }
    }
}