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
    public partial class DeleteAirport : System.Web.UI.Page
    {
        Airport airport;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).Role.Equals("admin")))
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                if (Request.Params["id"] == null)
                {
                    Response.Redirect("AirportManager.aspx");
                }
                else
                {
                    int id = Int32.Parse(Request.Params["id"].ToString());

                    airport = Helper.getAirport(id);

                    if (airport != null)
                    {
                        msg.Text = $"تأكيد حذف المطار ({airport.Name}) بشكل نهائي ؟";
                    }
                    else
                    {
                        Response.Redirect("AirportManager.aspx");
                    }
                }
            }
        }

        protected void deleteAirportBtn_Click(object sender, EventArgs e)
        {
            if(Helper.deleteAirport(airport.Id))
            {
                Helper.Alert(Session, "تم حذف المطار");
                Response.Redirect("AirportManager.aspx");
            }
            else
            {
                Helper.Alert(Session, "حدث خطأ في عملية الحذف");
                Helper.Alert(Session, Response);

            }
        }
    }
}