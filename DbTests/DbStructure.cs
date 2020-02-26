using Contracts;
using Contracts.Entities;
using DB;
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
                context.Users.Add(new User() { Name = "Kolya", Email = "k@gmail.com", NotificationMode = Contracts.NotificationMode.LessThan20Km });
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

        [Fact]
        public void IsMessageTableIsConfigured()
        {
            var options = new DbContextOptionsBuilder<CarAccidentContext>()
                            .UseInMemoryDatabase(databaseName: "Test_Messages_Structure")
                            .Options;

            var userSender = new User() { Name = "Kolya", Email = "k@gmail.com", NotificationMode = NotificationMode.LessThan20Km };
            var userReceiver = new User() { Name = "Vasya", Email = "v@gmail.com", NotificationMode = NotificationMode.LessThan50Km };
            using (var context = new CarAccidentContext(options))
            {

                context.Messages.Add(new Message() { ReceiverUser = userReceiver, SenderUser = userSender, Content = "Hi" });
                context.SaveChanges();
            }

            using (var context = new CarAccidentContext(options))
            {
                Assert.Equal(1, context.Messages.Count());
                Assert.Equal("Vasya", context.Messages.Include(m => m.ReceiverUser).Single().ReceiverUser.Name);
                Assert.Equal("Kolya", context.Messages.Include(m => m.SenderUser).Single().SenderUser.Name);
                Assert.Equal("Hi", context.Messages.Single().Content);
            }
        }
    }
}
