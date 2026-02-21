using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Services;
using App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.V1.Examples;
using NSubstitute;

namespace Tests.Modules.KWMODULENAME.Interfaces.API.REST
{
    /// <summary>
    /// Tests for <see cref="ExampleAController"/>.
    /// Verifies controller delegates to service and returns IQueryable.
    /// </summary>
    public class ExampleAControllerTests
    {
        private readonly IExampleAApplicationService _mockService;
        private readonly ExampleAController _controller;

        /// <summary>
        /// Sets up a mocked service and controller for each test.
        /// </summary>
        public ExampleAControllerTests()
        {
            this._mockService = Substitute.For<IExampleAApplicationService>();
            this._controller = new ExampleAController(this._mockService);
        }

        [Fact]
        public void WhenGetAllCalled_ThenReturnsQueryable()
        {
            // Arrange
            var expectedDtos = new List<ExampleADto>
            {
                new ExampleADto { Id = Guid.NewGuid(), Title = "First" },
                new ExampleADto { Id = Guid.NewGuid(), Title = "Second" }
            }.AsQueryable();

            this._mockService.GetAll().Returns(expectedDtos);

            // Act
            var result = this._controller.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            this._mockService.Received(1).GetAll();
        }

        [Fact]
        public void WhenGetAllCalledWithWatermark_ThenDelegatesToGetModifiedAfter()
        {
            // Arrange
            var watermark = DateTime.UtcNow.AddDays(-1);
            var expectedDtos = new List<ExampleADto>
            {
                new ExampleADto { Id = Guid.NewGuid(), Title = "Modified" }
            }.AsQueryable();

            this._mockService.GetModifiedAfter(watermark).Returns(expectedDtos);

            // Act
            var result = this._controller.GetAll(modifiedAfter: watermark);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            this._mockService.Received(1).GetModifiedAfter(watermark);
            this._mockService.DidNotReceive().GetAll();
        }

        [Fact]
        public void WhenGetAllCalledWithoutWatermark_ThenDelegatesToGetAll()
        {
            // Arrange
            var expectedDtos = new List<ExampleADto>().AsQueryable();
            this._mockService.GetAll().Returns(expectedDtos);

            // Act
            this._controller.GetAll(modifiedAfter: null);

            // Assert
            this._mockService.Received(1).GetAll();
            this._mockService.DidNotReceive().GetModifiedAfter(Arg.Any<DateTime>());
        }

        [Fact]
        public void WhenGetByIdCalled_ThenDelegatesToService()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedDtos = new List<ExampleADto>
            {
                new ExampleADto { Id = id, Title = "Found" }
            }.AsQueryable();

            this._mockService.GetById(id).Returns(expectedDtos);

            // Act
            var result = this._controller.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            this._mockService.Received(1).GetById(id);
        }

        [Fact]
        public void WhenConstructedWithNullService_ThenThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new ExampleAController(null!));
        }
    }
}