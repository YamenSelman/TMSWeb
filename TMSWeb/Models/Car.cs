
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMSAPI.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public float Rent { get; set; }
        public int? CompanyId { get; set; }
        public CarCompany Company { get; set; }
    }
}