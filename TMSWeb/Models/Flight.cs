using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace TMSAPI.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public int? OriginId { get; set; }
        public Airport Origin { get; set; }
        public int? DestinationId { get; set; }
        public Airport Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArriveDate { get; set; }
        public int? CompanyId { get; set; }
        public FlightCompany Company { get; set; }
        public float Price { get; set; }
        public int Capacity { get; set; }
        public List<Customer> Passengers { get; set; }
    }
}