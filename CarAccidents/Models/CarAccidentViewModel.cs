using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Entities;

namespace CarAccidents.Models
{
    public class CarAccidentViewModel
    {
        public static CarAccidentViewModel From(Accident a)
        {
            return new CarAccidentViewModel(a.Address, a.GpsLatitude, a.GpsLongitude, a.CreatingTime, a.Description, a.User.Name, a.Distance);
        }

        
        public string Address { get; set; }

        public double GpsLongitude { get; set; }

        public double GpsLatitude { get; set; }

        public DateTime CreatingTime { get; set; }

        public string Description { get; set; }

        public string User { get; set; }

        public double Distance { get; set; }


        public CarAccidentViewModel(string address, double gpsLattitude, double gpsLongitude, 
                                    DateTime creatingTime, string description, string userName, double distance)
        {
            Address = address;
            GpsLatitude = gpsLattitude;
            GpsLongitude = gpsLongitude;
            CreatingTime = creatingTime;
            Description = description;
            User = userName;
            Distance = distance;
        }
    }
}
