using Contracts;
using DB;
using DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace DbTests
{
    public class DbStructure
    {
        [Fact]
        public void IsUserTableIsConfigured()
        {
            var options = new DbContextOptionsBuilder<CarAccidentContext>()
                            .UseInMemoryDatabase(databaseName: "Test_Structure")
                            .Options;

            using (var context = new CarAccidentContext(options))
            {
                context.Users.Add(new DB.Entities.User() { Name = "Kolya", Email = "k@gmail.com", NotificationMode = Contracts.NotificationMode.LessThan20Km });
                context.SaveChanges();
            }

            using (var context = new CarAccidentContext(options))
            {
                Assert.Equal(1, context.Users.Count());
                Assert.Equal(NotificationMode.LessThan20Km, context.Users.Single().NotificationMode);
            }
        }

        [Fact]
        public void IsAccidentsTableIsConfigured()
        {
            var options = new DbContextOptionsBuilder<CarAccidentContext>()
                            .UseInMemoryDatabase(databaseName: "Test_Accidents_Structure")
                            .Options;

            var user = new User() { Name = "Kolya", Email = "k@gmail.com", NotificationMode = Contracts.NotificationMode.LessThan20Km };
            var accident = new Accident() { User = user, CreatingTime = DateTime.UtcNow, GpsCoordinates = "0.1, 0.2" };
            using (var context = new CarAccidentContext(options))
            {
                
                context.Accidents.Add(accident);
                context.SaveChanges();
            }

            using (var context = new CarAccidentContext(options))
            {
                Assert.Equal(1, context.Accidents.Count());
                Assert.Equal(user.Id, context.Accidents.Single().UserId);
                Assert.Equal("0.1, 0.2", context.Accidents.Single().GpsCoordinates);
            }
        }
    }
}
