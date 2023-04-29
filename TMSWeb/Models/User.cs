using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMSAPI.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Approved { get; set; }
        public Customer Customer {get;set;}
        public string isApproved
        {
            get
            {
                return Approved ? "مفعل" : "غير مفعل";
            }
        }
    }
}