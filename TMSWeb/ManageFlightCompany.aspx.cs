using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class ManageFlightCompany : System.Web.UI.Page
    {
        FlightCompany company;
        List<Airport> oas, das;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).Role.Equals("customer")))
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                if (Request.Params["id"] == null)
                {
                    Response.Redirect("UserPage.aspx");
                }
                else
                {
                    int id = Int32.Parse(Request.Params["id"].ToString());

                    company = Helper.getFlightCompany(id);

                    if (company != null)
                    {
                        company.Flights = Helper.getFlightsByCompany(company.Id);

                        flightsGrid.DataSource = company.Flights;
                        flightsGrid.DataBind();

                        oas = Helper.getAllAirports();
                        das = Helper.getAllAirports();

                        companyName.Text = company.Name;
                        email.Text = company.Email;
                        phoneNumber.Text = company.PhoneNumber;
                        companyDesc.Text = company.Description;
                        accountNumber.Text = company.AccountNumber;

                        if (!IsPostBack)
                        {
                            originDD.DataSource = oas;
                            originDD.DataValueField = "Id";
                            originDD.DataTextField = "Name";
                            originDD.DataBind();
                            destinationDD.DataSource = das;
                            destinationDD.DataValueField = "Id";
                            destinationDD.DataTextField = "Name";
                            destinationDD.DataBind();

                            sdate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                            edate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                            stime.Text = DateTime.Now.ToString("HH:mm");
                            etime.Text = DateTime.Now.ToString("HH:mm");
                        }
                    }
                    else
                    {
                        Response.Redirect("UserPage.aspx");
                    }
                }
            }
        }

        protected void flightAddSaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Flight flight = new Flight();
                if (Int32.TryParse(originDD.SelectedValue, out _))
                {
                    flight.OriginId = Int32.Parse(originDD.SelectedValue);
                }
                else
                {
                    Helper.Alert(Session, "الرجاء اختيار مطار الانطلاق");
                    return;
                }
                if (Int32.TryParse(destinationDD.SelectedValue, out _))
                {
                    int did = Int32.Parse(destinationDD.SelectedValue);
                    if (flight.OriginId == did)
                    {
                        Helper.Alert(Session, "مطار الوصول لا يمكن أن يكون نفس مطار الانطلاق");
                        return;
                    }
                    else
                    {
                        flight.DestinationId = did;
                    }
                }
                else
                {
                    Helper.Alert(Session, "الرجاء اختيار مطار الوصول");
                    return;
                }
                int nu;
                if (Int32.TryParse(capacity.Text, out nu))
                {
                    flight.Capacity = nu;
                }
                else
                {
                    Helper.Alert(Session, "الرجاء ادخال عدد المقاعد");
                    return;
                }
                if (Int32.TryParse(price.Text, out nu))
                {
                    flight.Price = nu;
                }
                else
                {
                    Helper.Alert(Session, "الرجاء ادخال سعر التذكرة");
                    return;
                }

                flight.CompanyId = company.Id;

                flight.DepartureDate = DateTime.ParseExact($"{sdate.Text} {stime.Text}", "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture); 
                flight.ArriveDate = DateTime.ParseExact($"{edate.Text} {etime.Text}", "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                flight = Helper.NewFlight(flight);
                flight.Origin = oas.Where(a => a.Id == flight.OriginId).FirstOrDefault();
                flight.Destination = das.Where(a => a.Id == flight.DestinationId).FirstOrDefault();

                company.Flights.Add(flight);
                addCol.Visible = false;
                gridCol.Visible = true;
            }
            catch (Exception ex)
            {
                Helper.Alert(Session, ex.Message);
            }
            finally
            {
                Helper.Alert(Session, Response);

                flightsGrid.DataSource = company.Flights;
                flightsGrid.DataBind();
            }
        }

        protected void flightAddCancelBtn_Click(object sender, EventArgs e)
        {
            addCol.Visible = false;
            gridCol.Visible = true;
        }

        protected void flightAddBtn_Click(object sender, EventArgs e)
        {
            addCol.Visible = true;
            gridCol.Visible = false;
        }
    }
}