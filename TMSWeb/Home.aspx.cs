using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSAPI.Models;

namespace TMSWeb
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Helper.Alert(Session, Response);
            if (Session["user"] != null)
            {
                loginDiv.Visible = false;
                loggedDiv.Visible = true;
                currentUserLBL.InnerText = ((User)Session["user"]).Name;
            }
            else
            {
                loginDiv.Visible = true;
                loggedDiv.Visible = false;
                currentUserLBL.InnerText = string.Empty;
            }
        }


        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (username.Text.Length <= 0)
            {
                ErrorLBL.Text = "يجب إدخال اسم المستخدم";
                username.Focus();
            }
            else if (password.Text.Length <= 0)
            {
                ErrorLBL.Text = "يجب إدخال كلمة المرور";
                password.Focus();
            }
            else
            {
                List<User> usres = Helper.getAllUsers();
                User user = usres.Where(u => u.Name.ToLower().Equals(username.Text.ToLower()) && u.Password.Equals(Helper.Hash(password.Text))).FirstOrDefault();
                if (user is null)
                {
                    ErrorLBL.Text = "فشل تسجيل الدخول";
                    username.Focus();
                }
                else if (!user.Approved)
                {
                    ErrorLBL.Text = "لم يتم تفعل حسابك";
                    username.Focus();
                }
                else
                {
                    Session["user"] = user;
                    if (user.Role.Equals("admin"))
                    {
                        Response.Redirect("Administration.aspx");
                    }
                    else if(user.Role.Equals("customer"))
                    {
                        Response.Redirect("UserPage.aspx");
                    }
                    else
                    {
                        Response.Redirect("Home.aspx");
                    }
                }
            }

        }

        protected void logout(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void PanelBtn_Click(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                if(((User)Session["user"]).Role.Equals("admin"))
                {
                    Response.Redirect("Administration.aspx");
                }
                else
                {
                    Response.Redirect("UserPage.aspx");
                }
            }
            else
            {
                Helper.Alert(Session,"انتهت جلسة العمل .. الرجاء إعادة الدخول");
                Response.Redirect("Home.aspx");
            }
        }
    }
}