using System;
using System.Threading.Tasks;
using AutoFixture;
using Theatres.BLL.Implementation;
using Theatres.DataAccess.Contracts;
using Theatres.Domain;
using Theatres.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Cinemas.BLL.Tests
{
    public class ScheduleGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_ScheduleExists_DoesNothing()
        {
            // Arrange
            var scheduleContainer = new Mock<IScheduleContainer>();

            var schedule = new Schedule();
            var scheduleDataAccess = new Mock<IScheduleDataAccess>();
            scheduleDataAccess.Setup(x => x.GetByAsync(scheduleContainer.Object)).ReturnsAsync(schedule);

            var scheduleGetService = new ScheduleGetService(scheduleDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => scheduleGetService.ValidateAsync(scheduleContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_ScheduleNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var scheduleContainer = new Mock<IScheduleContainer>();
            scheduleContainer.Setup(x => x.ScheduleId).Returns(id);

            var schedule = new Schedule();
            var scheduleDataAccess = new Mock<IScheduleDataAccess>();
            scheduleDataAccess.Setup(x => x.GetByAsync(scheduleContainer.Object)).ReturnsAsync((Schedule)null);

            var scheduleGetService = new ScheduleGetService(scheduleDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => scheduleGetService.ValidateAsync(scheduleContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Schedule not found by id {id}");
        }
    }
}