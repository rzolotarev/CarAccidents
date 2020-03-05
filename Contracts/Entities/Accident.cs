using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Entities
{
    public class Accident
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Address { get; set; }

        public double GpsLongitude { get; set; }

        public double GpsLatitude { get; set; }

        public DateTime CreatingTime { get; set; }

        public DateTime? CompletingTime { get; set; }

        public User User { get; set; }

        public double Distance { get; set; }

        public string Description { get; set; }
    }
}
