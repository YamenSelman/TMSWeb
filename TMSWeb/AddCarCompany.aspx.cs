using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class AddCarCompany : System.Web.UI.Page
    {
        CarCompany company = null;
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
                    users.RemoveAll(u => u.Role.Equals("admin"));
                    companyManager.DataSource = users;
                    companyManager.DataValueField = "ID";
                    companyManager.DataTextField = "Name";
                    companyManager.DataBind();
                    companyManager.SelectedIndex = users.Count - 1;

                    company = new CarCompany();
                    company.Cars = new List<Car>();

                    cityDD.DataSource = Helper.Cities;
                    cityDD.DataBind();

                    Session["carCompany"] = company;
                }
                else
                {
                    company = (CarCompany)Session["carCompany"];
                }
                carsGrid.DataSource = company.Cars;
                carsGrid.DataBind();
            }
        }

        public void fillCompany()
        {
            company.Name = companyName.Text;
            company.Description = companyDesc.Text;
            company.PhoneNumber = phoneNumber.Text;
            company.Email = email.Text;
            company.City = cityDD.Text;
            company.AccountNumber = accountNumber.Text;
            if(Int32.TryParse(companyManager.SelectedValue,out _))
            {
                company.ManagerId = Int32.Parse(companyManager.SelectedValue);
            }
        }

        protected void saveCarCompanyBtn_Click(object sender, EventArgs e)
        {
            fillCompany();
            company = Helper.NewCarCompany(company);                    Session["carCompany"] = company;
            Session["carCompany"] = null;
            Response.Redirect("CarCompanyManager.aspx");
        }

        protected void carAddBtn_Click(object sender, EventArgs e)
        {
            addCol.Visible = true;
            gridCol.Visible = false;
            fillCompany();
            Session["carCompany"] = company;
        }

        protected void carAddCancelBtn_Click(object sender, EventArgs e)
        {
            addCol.Visible = false;
            gridCol.Visible = true;
            fillCompany();
            Session["carCompany"] = company;
        }

        protected void carAddSaveBtn_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.Number = carNum.Text;
            car.Description = carDesc.Text;
            car.Model = model.Text;
            car.Year = Int32.Parse(year.Text);
            car.Rent = Int32.Parse(rent.Text);

            company.Cars.Add(car);
            carsGrid.DataSource = company.Cars;
            carsGrid.DataSource = company.Cars;
            carsGrid.DataBind();
            fillCompany();
            Session["carCompany"] = company;

            carNum.Text = string.Empty;
            carDesc.Text = string.Empty;
            model.Text = string.Empty;
            year.Text = string.Empty;
            rent.Text = string.Empty;
            carAddCancelBtn_Click(null, null);
        }

        protected void carsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteCar")
            {
                string parameter = e.CommandArgument.ToString();
                company.Cars.Remove(company.Cars.Where(c => c.Number.Equals(parameter)).FirstOrDefault());
                carsGrid.DataBind();
            }
            fillCompany();
            Session["carCompany"] = company;
        }
    }
}