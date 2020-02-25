using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entities
{
    public class Accident
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Address { get; set; }

        public string GpsCoordinates { get; set; }

        public DateTime CreatingTime { get; set; }

        public DateTime? CompletingTime { get; set; }

        public User User { get; set; }
    }
}
