using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class RoomReservation : System.Web.UI.Page
    {
        Hotel hotel;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["user"] == null || !((User)Session["user"]).Role.Equals("customer")))
            {
                Response.Redirect("Home.aspx", false);
            }
            else
            {

                String IDP = Request.QueryString["ID"];
                int id;
                if (Int32.TryParse(IDP, out id))
                {
                    hotel = Helper.getHotel(id);
                    if (hotel != null)
                    {
                        if (!IsPostBack)
                        {
                            roomsGrid.DataSource = Helper.getHotelRooms(id);
                            roomsGrid.DataBind();
                        }
                    }
                    return;
                }
                Response.Redirect("UserManager.aspx", false);
            }
        }
    }
}