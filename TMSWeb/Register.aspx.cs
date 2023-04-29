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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void registerBTN_Click(object sender, EventArgs e)
        {
            if (userNameTB.Value.IsNullOrWhiteSpace())
            {
                ErrorLBL.Text = "يجب إدخال اسم المستخدم";
                return;
            }
            if (emailTB.Value.IsNullOrWhiteSpace())
            {
                ErrorLBL.Text = "يجب إدخال البريد الالكتروني";
                return;
            }
            if (phoneTB.Value.IsNullOrWhiteSpace())
            {
                ErrorLBL.Text = "يجب إدخال رقم الهاتف";
                return;
            }
            if (passwordTB.Value.IsNullOrWhiteSpace())
            {
                ErrorLBL.Text = "يجب إدخال كلمة المرور";
                return;
            }
            if (confirmPWTB.Value.IsNullOrWhiteSpace())
            {
                ErrorLBL.Text = "يجب تأكيد كلمة المرور";
                return;
            }
            if (!confirmPWTB.Value.Equals(passwordTB.Value))
            {
                ErrorLBL.Text = "كلمة المرور غير متطابقة";
                return;
            }
            if (accountNumTB.Value.IsNullOrWhiteSpace())
            {
                ErrorLBL.Text = "يجب إدخال رقم الحساب";
                return;
            }
            var users = Helper.getAllUsers();
            User usr = users.Where(u => u.Name.ToLower().Equals(userNameTB.Value.ToLower())).FirstOrDefault();
            if (usr != null)
            {
                ErrorLBL.Text = "اسم المستخدم موجود مسبقاً";
                return;
            }
            usr = users.Where(u => u.Email.ToLower().Equals(emailTB.Value.ToLower())).FirstOrDefault();
            if (usr != null)
            {
                ErrorLBL.Text = "البريد الالكتروني موجود مسبقاً";
                return;
            }

            User user = new User();
            user.Name = userNameTB.Value;
            user.Email = emailTB.Value;
            user.Password = passwordTB.Value;
            user.PhoneNumber = phoneTB.Value;
            user.Role = "customer";

            Customer customer = new Customer();
            customer.User = user;
            customer.AccountNumber = accountNumTB.Value;

            Customer newCustomer = Helper.NewCustomer(customer);
            if (newCustomer != null)
            {
                ErrorLBL.Text = "All Ok";

            }
            else
            {
                ErrorLBL.Text = "Not good";
            }
        }
    }
}