using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class AddHotel : System.Web.UI.Page
    {
        Hotel hotel = null;
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
                    hotelManager.DataSource = users;
                    hotelManager.DataValueField = "ID";
                    hotelManager.DataTextField = "Name";
                    hotelManager.DataBind();
                    hotelManager.SelectedIndex = users.Count - 1;

                    hotel = new Hotel();
                    hotel.Rooms = new List<HotelRoom>();

                    cityDD.DataSource = Helper.Cities;
                    cityDD.DataBind();

                    Session["hotel"] = hotel;
                }
                else
                {
                    hotel = (Hotel)Session["hotel"];
                }
                roomsGrid.DataSource = hotel.Rooms;
                roomsGrid.DataBind();
            }
        }

        public void fillHotel()
        {
            hotel.Name = hotelName.Text;
            hotel.Description = hotelDesc.Text;
            hotel.PhoneNumber = phoneNmuber.Text;
            hotel.Email = email.Text;
            hotel.City = cityDD.Text;
            hotel.AccountNumber = accountNumber.Text;
            if (Int32.TryParse(hotelManager.SelectedValue, out _))
            {
                hotel.ManagerId = Int32.Parse(hotelManager.SelectedValue);
            }
        }

        protected void saveHotelBtn_Click(object sender, EventArgs e)
        {
            fillHotel();
            hotel = Helper.NewHotel(hotel);
            Session["hotel"] = null;
            Response.Redirect("HotelManager.aspx");
        }

        protected void roomAddCancelBtn_Click(object sender, EventArgs e)
        {
            addCol.Visible = false;
            gridCol.Visible = true;
            fillHotel();
            Session["hotel"] = hotel;
        }

        protected void roomAddBtn_Click(object sender, EventArgs e)
        {
            addCol.Visible = true;
            gridCol.Visible = false;
            fillHotel();
            Session["hotel"] = hotel;
        }

        protected void roomAddSaveBtn_Click(object sender, EventArgs e)
        {
            HotelRoom room = new HotelRoom();
            room.Number = roomNum.Text;
            room.Description = roomDesc.Text;
            room.Capacity = Int32.Parse(capacity.Text);
            room.Rent = Int32.Parse(rent.Text);

            hotel.Rooms.Add(room);
            roomsGrid.DataSource = hotel.Rooms;
            roomsGrid.DataBind();
            fillHotel();
            Session["hotel"] = hotel;

            roomNum.Text = string.Empty;
            roomDesc.Text = string.Empty;
            capacity.Text = string.Empty;
            rent.Text = string.Empty;
            roomAddCancelBtn_Click(null, null);
        }

        protected void roomsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteRoom")
            {
                string parameter = e.CommandArgument.ToString();
                hotel.Rooms.Remove(hotel.Rooms.Where(r => r.Number.Equals(parameter)).FirstOrDefault());
                roomsGrid.DataBind();
            }
            fillHotel();
            Session["hotel"] = hotel;
        }
    }
}