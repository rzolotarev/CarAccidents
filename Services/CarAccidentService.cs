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

        const double EQuatorialEarthRadius = 6378.1370D;
        const double D2r = (Math.PI / 180D);

        public CarAccidentService(IDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        public IEnumerable<Accident> GetClosestAccidents(double gpsLongitude, double gpsLatitude)
        {
             return _dbProvider.GetCarAccidents()
                                .Select(a =>
                                {
                                    a.Distance = HaversineInKM(a.GpsLatitude, a.GpsLongitude, gpsLatitude, gpsLongitude);
                                    return a;
                                })
                                .OrderBy(a => a.Distance).ToList();
        }

        private int HaversineInM(double lat1, double long1, double lat2, double long2)
        {
            return (int)(1000D * HaversineInKM(lat1, long1, lat2, long2));
        }

        private double HaversineInKM(double lat1, double long1, double lat2, double long2)
        {
            double dlong = (long2 - long1) * D2r;
            double dlat = (lat2 - lat1) * D2r;
            double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(lat1 * D2r) * Math.Cos(lat2 * D2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
            double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
            double d = EQuatorialEarthRadius * c;

            return d;
        }
    }
}
