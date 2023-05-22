using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class HotelReservationPayment : System.Web.UI.Page
    {
        TMSAPI.Models.HotelReservation reservation;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).Role.Equals("customer") && Session["hotelreservaion"] != null))
            {
                Response.Redirect("Home.aspx", false);
            }
            else
            {
                reservation = (TMSAPI.Models.HotelReservation)Session["hotelreservaion"];
                if(reservation != null) {
                    int perisumod = (int)(((reservation.EndDate - reservation.StrartDate).TotalDays + 1) * reservation.HotelRoom.Rent);
                    sum.Text = perisumod.ToString();
                }
                else
                {
                    Session["error"] = "حدث خطأ في عملية الحجز .. الرجاء المحاولة مرة أخرى";
                    Response.Redirect("HotelReservation.aspx");
                }
            }
        }

        protected void confirmRes_Click(object sender, EventArgs e)
        {
            if (Helper.Hash(pass.Text).Equals(((User)Session["user"]).Password))
            {
                reservation.Customer = null;
                reservation.HotelRoom = null;
                reservation = Helper.AddHotelReservation(reservation);
                Session["hotelreservaion"] = null;
                Helper.Alert(Session, "تمت عملية حجز الفندق بنجاح");
                Response.Redirect("UserPage.aspx");
            }
            else
            {
                ErrorLBL.Text = "كلمة السر المدخلة غير صحيحة";
            }
        }
    }
}