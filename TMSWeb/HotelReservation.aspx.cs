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

        List<Hotel> hotels;

        public Hotel selectedHotel
        {
            get
            {
                return (Hotel)Session["selectedHotel"];
            }
            set
            {
                Session["selectedHotel"] = value;
                if(value == null)
                {
                    selectedRoom = null;
                    roomsDiv.Visible = false;
                }
                getRooms(null,null);
            }
        }

        public HotelRoom selectedRoom
        {
            get
            {
                return (HotelRoom)Session["selectedRoom"];
            }
            set
            {
                Session["selectedRoom"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).Role.Equals("customer")))
            {
                Response.Redirect("Home.aspx", false);
            }
            else
            {


                if (!IsPostBack)
                {
                    selectedHotel = null;
                    selectedRoom = null;

                    cityDD.DataSource = Helper.Cities;
                    cityDD.DataBind();

                    sdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    edate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }


                hotels = Helper.getAllHotels();
                hotelsGrid.DataSource = hotels.Where(h => h.City.Equals(cityDD.Text)).ToList();
                hotelsGrid.DataBind();
            }
        }

        public void getRooms(object sender, EventArgs e)
        {
            if (selectedHotel != null)
            {
                roomsGrid.DataSource = Helper.getAvailableRooms(selectedHotel.Id, DateTime.Parse(sdate.Text), DateTime.Parse(edate.Text), Int32.Parse(beds.Text));
                roomsGrid.DataBind();
                roomsDiv.Visible = true;
            }
            else
            {
                roomsDiv.Visible = false;
            }
        }
        protected void rlb_Click(object sender, EventArgs e)
        {
            String IDP = ((LinkButton)sender).CommandArgument.ToString();
            int id;
            if (Int32.TryParse(IDP, out id))
            {
                selectedRoom = Helper.getRoom(id);
                if(selectedRoom !=null)
                {
                    resDiv.Visible = true;
                }
                else
                {
                    resDiv.Visible = false;
                }
            }
        }

        protected void hlb_Click(object sender, EventArgs e)
        {
            String IDP = ((LinkButton)sender).CommandArgument.ToString();
            int id;
            if (Int32.TryParse(IDP, out id))
            {
                selectedHotel = hotels.Where(h=>h.Id == id).FirstOrDefault();
            }
            else
            {
                selectedHotel = null;
            }
        }

        protected void confirmRes_Click(object sender, EventArgs e)
        {

        }

        protected void cityDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedHotel = null;
            hotels = Helper.getAllHotels();
            hotelsGrid.DataSource = hotels.Where(h => h.City.Equals(cityDD.Text)).ToList();
            hotelsGrid.DataBind();
        }
    }
}