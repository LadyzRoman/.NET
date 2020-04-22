using System;
using System.Threading.Tasks;
using Theatres.BLL.Contracts;
using Theatres.BLL.Implementation;
using Theatres.DataAccess.Contracts;
using Theatres.Domain;
using Theatres.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Cinemas.BLL.Tests
{
    public class ScheduleUpdateServiceTests
    {
        [Test]
        public async Task UpdateAsync_DepartmentValidationSucceed_CreatesScreening()
        {
            // Arrange
            var schedule = new ScheduleUpdateModel();
            var expected = new Schedule();
            
            var theatreGetService = new Mock<ITheatreGetService>();
            theatreGetService.Setup(x => x.ValidateAsync(schedule));

            var perfomanceGetService = new Mock<IPerfomanceGetService>();
            perfomanceGetService.Setup(x => x.ValidateAsync(schedule));

            var scheduleDataAccess = new Mock<IScheduleDataAccess>();
            scheduleDataAccess.Setup(x => x.UpdateAsync(schedule)).ReturnsAsync(expected);
            
            var scheduleGetService = new ScheduleUpdateService(scheduleDataAccess.Object, theatreGetService.Object, perfomanceGetService.Object);
            
            // Act
            var result = await scheduleGetService.UpdateAsync(schedule);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task UpdateAsync_CinemaValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var schedule = new ScheduleUpdateModel();
            var expected = fixture.Create<string>();
            
            var theatreGetService = new Mock<ITheatreGetService>();
            theatreGetService
                .Setup(x => x.ValidateAsync(schedule))
                .Throws(new InvalidOperationException(expected));

            var perfomanceGetService = new Mock<IPerfomanceGetService>();
            perfomanceGetService.Setup(x => x.ValidateAsync(schedule)).Throws(new InvalidOperationException(expected));

            
            var scheduleDataAccess = new Mock<IScheduleDataAccess>();

            var scheduleGetService = new ScheduleUpdateService(scheduleDataAccess.Object, theatreGetService.Object, perfomanceGetService.Object);
            
            // Act
            var action = new Func<Task>(() => scheduleGetService.UpdateAsync(schedule));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            scheduleDataAccess.Verify(x => x.UpdateAsync(schedule), Times.Never);
        }
    }
}