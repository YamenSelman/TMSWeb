using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class CarReservation : System.Web.UI.Page
    {
        List<CarCompany> companies;

        public CarCompany selectedCompany
        {
            get
            {
                return (CarCompany)Session["selectedCompany"];
            }
            set
            {
                Session["selectedCompany"] = value;
                if (value == null)
                {
                    selectedCar = null;
                    carsDiv.Visible = false;
                    resDiv.Visible = false;
                }
                getCars(null, null);
            }
        }

        public Car selectedCar
        {
            get
            {
                return (Car)Session["selectedCar"];
            }
            set
            {
                Session["selectedCar"] = value;
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
                    if (Session["error"] != null)
                    {
                        ErrorLBL.Text = Session["error"].ToString();
                        Session["error"] = null;
                    }

                    selectedCompany = null;
                    selectedCar = null;

                    cityDD.DataSource = Helper.Cities;
                    cityDD.DataBind();

                    sdate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                    edate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                }


                companies = Helper.getAllCarCompanies();
                companiesGrid.DataSource = companies.Where(h => h.City.Equals(cityDD.Text)).ToList();
                companiesGrid.DataBind();
            }
        }

        protected void hlb_Click(object sender, EventArgs e)
        {
            String IDP = ((LinkButton)sender).CommandArgument.ToString();
            int id;
            if (Int32.TryParse(IDP, out id))
            {
                selectedCompany = companies.Where(h => h.Id == id).FirstOrDefault();
            }
            else
            {
                selectedCompany = null;
            }
        }

        protected void rlb_Click(object sender, EventArgs e)
        {
            String IDP = ((LinkButton)sender).CommandArgument.ToString();
            int id;
            if (Int32.TryParse(IDP, out id))
            {
                selectedCar = Helper.getCar(id);
                if (selectedCar != null)
                {
                    int period = ((int)(DateTime.Parse(edate.Text) - DateTime.Parse(sdate.Text)).TotalDays) + 1;
                    resDiv.Visible = true;
                    rescompany.Text = selectedCompany.Name;
                    rescar.Text =  $"{selectedCar.Model} {selectedCar.Year}";
                    resperiod.Text = period.ToString() + " يوم";
                    resprice.Text = (period * selectedCar.Rent).ToString();
                }
                else
                {
                    resDiv.Visible = false;
                }
            }
        }

        public void getCars(object sender, EventArgs e)
        {
            resDiv.Visible = false;
            if (selectedCompany != null)
            {
                carsDiv.Visible = false;
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
                    carsGrid.DataSource = Helper.getAvailableCars(selectedCompany.Id, DateTime.Parse(sdate.Text), DateTime.Parse(edate.Text));
                    carsGrid.DataBind();
                    carsDiv.Visible = true;
                    ErrorLBL.Text = "";
                }

            }
            else
            {
                carsDiv.Visible = false;
            }
        }

        protected void confirmRes_Click(object sender, EventArgs e)
        {
            TMSAPI.Models.CarReservation carreservaion = new TMSAPI.Models.CarReservation();
            Customer cust = Helper.getCurrentCustomer(((User)Session["user"]).ID);
            carreservaion.CustomerId = cust.Id;
            carreservaion.EndDate = DateTime.Parse(edate.Text).Date;
            carreservaion.StrartDate = DateTime.Parse(sdate.Text).Date;
            carreservaion.CarId = selectedCar.Id;
            carreservaion.Car = selectedCar;
            carreservaion.Customer = cust;
            if (carreservaion != null)
            {
                Session["carreservaion"] = carreservaion;
                Response.Redirect("CarReservationPayment.aspx");
            }
        }

        protected void cityDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCompany = null;
            companies = Helper.getAllCarCompanies();
            companiesGrid.DataSource = companies.Where(h => h.City.Equals(cityDD.Text)).ToList();
            companiesGrid.DataBind();
        }
    }
}