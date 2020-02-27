using Contracts.Db;
using Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CarAccidentService
    {
        private readonly IDbProvider _dbProvider;

        public CarAccidentService(IDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        //TODO: calculated in a wrong way
        //http://www.movable-type.co.uk/scripts/latlong.html
        //https://stackoverflow.com/questions/365826/calculate-distance-between-2-gps-coordinates
        public IEnumerable<Accident> GetClosestAccidents(double gpsLongitude, double gpsLatitude)
        {
             return _dbProvider.GetCarAccidents()
                                .Select(a =>
                                {
                                    a.Distance = Math.Sqrt(Math.Pow(a.GpsLongitude - gpsLongitude, 2) +
                                                    Math.Pow(a.GpsLatitude - gpsLatitude, 2));
                                    return a;
                                })
                                .OrderBy(a => a.Distance).ToList();
        }
    }
}
