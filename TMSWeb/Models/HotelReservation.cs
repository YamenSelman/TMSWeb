using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMSAPI.Models
{
    public class HotelReservation
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? HotelRoomId { get; set; }
        public HotelRoom HotelRoom { get; set; }
        public DateTime StrartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}