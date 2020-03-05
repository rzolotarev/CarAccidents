using Contracts.Db;
using Contracts.Entities;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace ServiceTests
{
    public class CarAccidentServiceTest
    {
        [Fact]
        public void GetClosestCarAccidents()
        {
            var sourcePoint = new Accident() { GpsLatitude = 51.881917, GpsLongitude = 15.710449, Address = "SourcePoint" };
            var dbProvider = new Mock<IDbProvider>();
            dbProvider.Setup(p => p.GetCarAccidents()).Returns(new List<Accident>() {
                new Accident() { GpsLatitude = 51.913102, GpsLongitude = 14.996338, Address = "Polska1" },
                new Accident() { GpsLatitude = 52.006526, GpsLongitude = 16.259766, Address = "Polska2" }
            });
            var service = new CarAccidentService(dbProvider.Object);
            var accidents = service.GetClosestAccidents(sourcePoint.GpsLongitude, sourcePoint.GpsLatitude).ToList();

            Assert.Equal("Polska1", accidents[1].Address);
            Assert.Equal("Polska2", accidents[0].Address);
        }
    }
}
