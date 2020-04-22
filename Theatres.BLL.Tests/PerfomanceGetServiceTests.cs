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
    public class PerfomanceGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_PerfomanceExists_DoesNothing()
        {
            // Arrange
            var prefomanceContainer = new Mock<IPerfomanceContainer>();

            var perfomance = new Perfomance();
            var perfomanceDataAccess = new Mock<IPerfomanceDataAccess>();
            perfomanceDataAccess.Setup(x => x.GetByAsync(prefomanceContainer.Object)).ReturnsAsync(perfomance);

            var perfomanceGetService = new PerfomanceGetService(perfomanceDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => perfomanceGetService.ValidateAsync(prefomanceContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_PerfomanceNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var perfomanceContainer = new Mock<IPerfomanceContainer>();
            perfomanceContainer.Setup(x => x.PerfomanceId).Returns(id);

            var perfomance = new Perfomance();
            var perfomanceDataAccess = new Mock<IPerfomanceDataAccess>();
            perfomanceDataAccess.Setup(x => x.GetByAsync(perfomanceContainer.Object)).ReturnsAsync((Perfomance)null);

            var perfomanceGetService = new PerfomanceGetService(perfomanceDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => perfomanceGetService.ValidateAsync(perfomanceContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Perfomance not found by id {id}");
        }
    }
}