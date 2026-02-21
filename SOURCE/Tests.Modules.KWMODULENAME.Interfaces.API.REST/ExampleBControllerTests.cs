using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Services;
using App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.V1.Examples;
using NSubstitute;

namespace Tests.Modules.KWMODULENAME.Interfaces.API.REST
{
    /// <summary>
    /// Tests for <see cref="ExampleBController"/>.
    /// Verifies controller delegates to service and returns IQueryable.
    /// </summary>
    public class ExampleBControllerTests
    {
        private readonly IExampleBApplicationService _mockService;
        private readonly ExampleBController _controller;

        /// <summary>
        /// Sets up a mocked service and controller for each test.
        /// </summary>
        public ExampleBControllerTests()
        {
            this._mockService = Substitute.For<IExampleBApplicationService>();
            this._controller = new ExampleBController(this._mockService);
        }

        [Fact]
        public void WhenGetAllCalled_ThenReturnsQueryable()
        {
            // Arrange
            var expectedDtos = new List<ExampleBDto>
            {
                new ExampleBDto { Id = Guid.NewGuid(), Name = "First" },
                new ExampleBDto { Id = Guid.NewGuid(), Name = "Second" }
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
        public void WhenGetAllCalledWithParentId_ThenDelegatesToGetByParent()
        {
            // Arrange
            var parentId = Guid.NewGuid();
            var expectedDtos = new List<ExampleBDto>
            {
                new ExampleBDto { Id = Guid.NewGuid(), ExampleAId = parentId, Name = "Child" }
            }.AsQueryable();

            this._mockService.GetByParent(parentId).Returns(expectedDtos);

            // Act
            var result = this._controller.GetAll(parentId: parentId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            this._mockService.Received(1).GetByParent(parentId);
            this._mockService.DidNotReceive().GetAll();
        }

        [Fact]
        public void WhenGetAllCalledWithoutParentId_ThenDelegatesToGetAll()
        {
            // Arrange
            var expectedDtos = new List<ExampleBDto>().AsQueryable();
            this._mockService.GetAll().Returns(expectedDtos);

            // Act
            this._controller.GetAll(parentId: null);

            // Assert
            this._mockService.Received(1).GetAll();
            this._mockService.DidNotReceive().GetByParent(Arg.Any<Guid>());
        }

        [Fact]
        public void WhenGetByIdCalled_ThenDelegatesToService()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedDtos = new List<ExampleBDto>
            {
                new ExampleBDto { Id = id, Name = "Found" }
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
                new ExampleBController(null!));
        }
    }
}