﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMSAPI.Models
{
    public class CarCompany
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int? ManagerId { get; set; }
        public User Manager { get; set; }
        public List<Car> Cars { get; set; }
        public string AccountNumber { get; set; }
    }
}