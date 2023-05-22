using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).Role.Equals("customer")))
            {
                Response.Redirect("Home.aspx", false);
            }

            companiesDiv.Visible = false;
            
            User user = (User)Session["user"];
            var managedBy = Helper.getManagedBy(user.ID);
            if (managedBy != null && managedBy.Count > 0)
            {
                foreach (var c in managedBy)
                {
                    switch(c.Key)
                    {
                        case "h":
                            var hotel = Helper.getHotel(c.Value);
                            companies.InnerHtml += $"<a href=\"ManageHotel.aspx?id={c.Value}\" class=\"fs-3 btn btn-outline-dark fw-bold btn-lg w-100 my-1 shadow-lg\" role=\"button\" aria-disabled=\"true\">{hotel.Name}<span class=\"float-end\"><i class=\"fa fa-bed\" aria-hidden=\"true\"></i></span><span class=\"float-start\"><i class=\"fa fa-bed\" aria-hidden=\"true\"></i></span></a>\r\n";
                            break;
                        case "c":
                            var car = Helper.getCarCompany(c.Value);
                            companies.InnerHtml += $"<a href=\"ManageCarCompany.aspx?id={c.Value}\" class=\"fs-3 btn btn-outline-dark fw-bold btn-lg w-100 my-1 shadow-lg\" role=\"button\" aria-disabled=\"true\">{car.Name}<span class=\"float-end\"><i class=\"fa fa-car\" aria-hidden=\"true\"></i></span><span class=\"float-start\"><i class=\"fa fa-car\" aria-hidden=\"true\"></i></span></a>\r\n";
                            break;
                        case "f":
                            var flight = Helper.getFlightCompany(c.Value);
                            companies.InnerHtml += $"<a href=\"ManageFlightCompany.aspx?id={c.Value}\" class=\"fs-3 btn btn-outline-dark fw-bold btn-lg w-100 my-1 shadow-lg\" role=\"button\" aria-disabled=\"true\">{flight.Name}<span class=\"float-end\"><i class=\"fa fa-plane\" aria-hidden=\"true\"></i></span><span class=\"float-start\"><i class=\"fa fa-plane\" aria-hidden=\"true\"></i></span></a>\r\n";
                            break;
                        default:
                            continue;
                    }
                }
                companiesDiv.Visible = true;
            }

            Helper.Alert(Session, Response);
        }

        protected void logout(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}