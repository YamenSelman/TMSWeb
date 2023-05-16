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

        Hotel selectedHotel = null;
        List<Hotel> hotels;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).Role.Equals("customer")))
            {
                Response.Redirect("Home.aspx", false);
            }
            else
            {
                if(!Page.IsPostBack)
                {
                    sdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    edate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                hotels = Helper.getAllHotels();
                hotelsGrid.DataSource = hotels;
                hotelsGrid.DataBind();
            }
        }

        protected void hotelsGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Page_Load(null, null);
        }

        protected void rlb_Click(object sender, EventArgs e)
        {

        }

        protected void hlb_Click(object sender, EventArgs e)
        {
            String IDP = ((LinkButton)sender).CommandArgument.ToString();
            int id;
            if (Int32.TryParse(IDP, out id))
            {
                selectedHotel = hotels.Where(h => h.Id.Equals(id)).FirstOrDefault();
                if (selectedHotel != null)
                {
                    List<HotelRoom> rooms = Helper.getHotelRooms(id);
                    if (rooms.Count > 0)
                    {
                        roomsDiv.Visible = true;
                        roomsGrid.DataSource = rooms;
                        roomsGrid.DataBind();
                    }
                    else
                    {
                        roomsDiv.Visible = false;
                    }

                }
                return;
            }
        }
    }
}