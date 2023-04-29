using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMSAPI.Models
{
    public class CarReservation
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? CarId { get; set; }
        public Car Car { get; set; }
        public DateTime StrartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}