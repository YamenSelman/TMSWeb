using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class AddFlightCompany : System.Web.UI.Page
    {
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
                    List<User> users = Helper.getAllUsers();
                    companyManager.DataSource = users;
                    companyManager.DataValueField = "ID";
                    companyManager.DataTextField = "Name";
                    companyManager.DataBind();
                    companyManager.SelectedIndex = users.Count - 1;
                }
            }
        }

        protected void saveFlightCompanyBtn_Click(object sender, EventArgs e)
        {
            FlightCompany company = new FlightCompany();
            company.Name = companyName.Text;
            company.Description = companyDesc.Text;
            company.PhoneNumber = phoneNumber.Text;
            company.Email = email.Text;
            company.AccountNumber = accountNumber.Text;
            company.ManagerId = Int32.Parse(companyManager.SelectedValue);
            company = Helper.NewFlightCompany(company);
            Response.Redirect("FlightCompanyManager.aspx");
        }
    }
}