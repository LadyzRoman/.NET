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
    public class TheatreGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_TheatreExists_DoesNothing()
        {
            // Arrange
            var theatreContainer = new Mock<ITheatreContainer>();

            var theatre = new Theatre();
            var theatreDataAccess = new Mock<ITheatreDataAccess>();
            theatreDataAccess.Setup(x => x.GetByAsync(theatreContainer.Object)).ReturnsAsync(theatre);

            var cinemaGetService = new TheatreGetService(theatreDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => cinemaGetService.ValidateAsync(theatreContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_TheatreNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var theatreContainer = new Mock<ITheatreContainer>();
            theatreContainer.Setup(x => x.TheatreId).Returns(id);

            var theatre = new Theatre();
            var theatreDataAccess = new Mock<ITheatreDataAccess>();
            theatreDataAccess.Setup(x => x.GetByAsync(theatreContainer.Object)).ReturnsAsync((Theatre)null);

            var cinemaGetService = new TheatreGetService(theatreDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => cinemaGetService.ValidateAsync(theatreContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Theatre not found by id {id}");
        }
    }
}