using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class UserDetails : System.Web.UI.Page
    {
        User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["user"] == null || !((User)Session["user"]).Role.Equals("admin")))
            {
                Response.Redirect("Home.aspx", false);
            }
            else
            {

                String IDP = Request.QueryString["ID"];
                int id;
                if (Int32.TryParse(IDP, out id))
                {
                    user = Helper.getUser(id);
                    if (user != null)
                    {
                        if(!IsPostBack)
                        {
                            if (user.Name.ToLower().Equals("admin"))
                            {
                                userStatue.Enabled = false;
                                userStatue.CssClass = "form-control form-control-lg";
                                phoneTB.ReadOnly = false;
                            }
                            userNameTB.Text = user.Name;
                            emailTB.Text = user.Email;
                            phoneTB.Text = user.PhoneNumber;
                            userRoleTB.Text = user.Role;
                            if (user.Approved)
                            {
                                userStatue.SelectedIndex = 0;
                            }
                            else
                            {
                                userStatue.SelectedIndex = 1;
                            }
                        }
                        else
                        {
                            user.Approved = userStatue.SelectedIndex == 0;
                            user.PhoneNumber = phoneTB.Text;
                            if(!string.IsNullOrEmpty(passwordTB.Text))
                            {
                                user.Password = passwordTB.Text;
                            }
                        } 
                    }
                    return;
                }
                Response.Redirect("UserManager.aspx", false);
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            Helper.UpdateUser(user);
            Response.Redirect("UserManager.aspx", false);
        }
    }
}