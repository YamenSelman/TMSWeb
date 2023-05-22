using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class CarReservationPayment : System.Web.UI.Page
    {
        TMSAPI.Models.CarReservation reservation;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).Role.Equals("customer") && Session["carreservaion"] != null))
            {
                Response.Redirect("Home.aspx", false);
            }
            else
            {
                reservation = (TMSAPI.Models.CarReservation)Session["carreservaion"];
                if (reservation != null)
                {
                    int perisumod = (int)(((reservation.EndDate - reservation.StrartDate).TotalDays + 1) * reservation.Car.Rent);
                    sum.Text = perisumod.ToString();
                }
                else
                {
                    Session["error"] = "حدث خطأ في عملية الحجز .. الرجاء المحاولة مرة أخرى";
                    Response.Redirect("CarReservation.aspx");
                }
            }
        }

        protected void confirmRes_Click(object sender, EventArgs e)
        {
            if (Helper.Hash(pass.Text).Equals(((User)Session["user"]).Password))
            {
                reservation.Customer = null;
                reservation.Car = null;
                reservation = Helper.AddCarReservation(reservation);
                Session["carreservaion"] = null;
                Helper.Alert(Session, "تمت عملية حجز السيارة بنجاح");
                Response.Redirect("UserPage.aspx");
            }
            else
            {
                ErrorLBL.Text = "كلمة السر المدخلة غير صحيحة";
            }
        }
    }
}