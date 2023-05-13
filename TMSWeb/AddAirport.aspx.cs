using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class AddAirport : System.Web.UI.Page
    {
        Airport airport = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).Role.Equals("admin")))
            {
                Response.Redirect("Home.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                    airport = new Airport();

                    cityDD.DataSource = Helper.Cities;
                    cityDD.DataBind();

                    Session["airport"] = airport;
                }
                else
                {
                    airport = (Airport)Session["airport"];
                }
            }
        }

        protected void saveAirportBtn_Click(object sender, EventArgs e)
        {
            Airport airport = new Airport();
            airport.Name = airportName.Text;
            airport.City = cityDD.Text;

            airport = Helper.NewAirport(airport);
            Response.Redirect("AirportManager.aspx");
        }
    }
}