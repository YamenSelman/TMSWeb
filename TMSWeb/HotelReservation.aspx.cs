using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
                    resDiv.Visible = false;
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
                    if(Session["error"] != null)
                    {
                        ErrorLBL.Text = Session["error"].ToString();
                        Session["error"] = null;
                    }

                    selectedHotel = null;
                    selectedRoom = null;

                    cityDD.DataSource = Helper.Cities;
                    cityDD.DataBind();

                    sdate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                    edate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                }


                hotels = Helper.getAllHotels();
                hotelsGrid.DataSource = hotels.Where(h => h.City.Equals(cityDD.Text)).ToList();
                hotelsGrid.DataBind();
            }
        }

        public void getRooms(object sender, EventArgs e)
        {
            resDiv.Visible = false;
            if (selectedHotel != null)
            {
                roomsDiv.Visible = false;
                if ((DateTime.Parse(sdate.Text) - DateTime.Parse(edate.Text)).TotalDays > 0)
                {
                    ErrorLBL.Text = "خطأ في اختيار التواريخ";
                }
                else if ((DateTime.Now - DateTime.Parse(sdate.Text)).TotalDays > 0)
                {
                    ErrorLBL.Text = "لا يمكن الحجز بتاريخ سابق";
                }
                else
                {
                    roomsGrid.DataSource = Helper.getAvailableRooms(selectedHotel.Id, DateTime.Parse(sdate.Text), DateTime.Parse(edate.Text), Int32.Parse(beds.Text));
                    roomsGrid.DataBind();
                    roomsDiv.Visible = true;
                    ErrorLBL.Text = "";
                }

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
                    int period = ((int)(DateTime.Parse(edate.Text) - DateTime.Parse(sdate.Text)).TotalDays)+1;
                    resDiv.Visible = true;
                    reshotel.Text = selectedHotel.Name;
                    resroom.Text = "رقم " + selectedRoom.Number;
                    resperiod.Text = period.ToString() + " يوم";
                    resprice.Text = (period * selectedRoom.Rent).ToString();
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
            TMSAPI.Models.HotelReservation hotelReservation = new TMSAPI.Models.HotelReservation();
            Customer cust = Helper.getCurrentCustomer(((User)Session["user"]).ID);
            hotelReservation.CustomerId = cust.Id;
            hotelReservation.EndDate = DateTime.Parse(edate.Text).Date;
            hotelReservation.StrartDate = DateTime.Parse(sdate.Text).Date;
            hotelReservation.HotelRoomId = selectedRoom.Id;
            hotelReservation.HotelRoom = selectedRoom;
            hotelReservation.Customer = cust;
            if(hotelReservation != null)
            {
                Session["hotelreservaion"] = hotelReservation;
                Response.Redirect("HotelReservationPayment.aspx");
            }
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