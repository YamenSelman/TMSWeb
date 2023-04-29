using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMSAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public List<Flight> Flights { get; set; }
        public List<HotelReservation> HotelReservations { get; set; }
        public List<CarReservation> CarReservations { get; set; }
        public string AccountNumber { get; set; }
    }
}