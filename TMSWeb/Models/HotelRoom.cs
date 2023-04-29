using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMSAPI.Models
{
    public class HotelRoom
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public float Rent { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}