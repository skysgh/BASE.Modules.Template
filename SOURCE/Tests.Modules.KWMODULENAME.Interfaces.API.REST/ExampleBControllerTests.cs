using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Services;
using App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.V1.Examples;
using NSubstitute;

namespace Tests.Modules.KWMODULENAME.Interfaces.API.REST
{
    /// <summary>
    /// Tests for <see cref="ExampleBController"/>.
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
        public void WhenGetAllCalled_ThenDelegatesToQuery()
        {
            // Arrange
            IQueryable<ExampleBDto> expectedDtos = new List<ExampleBDto>
            {
                new ExampleBDto { Id = Guid.NewGuid(), Name = "First" },
                new ExampleBDto { Id = Guid.NewGuid(), Name = "Second" }
            }.AsQueryable();
            this._mockService.Query().Returns(expectedDtos);

            // Act
            IQueryable<ExampleBDto> result = this._controller.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
            this._mockService.Received(1).Query();
        }

        [Fact]
        public void WhenGetByParentCalled_ThenDelegatesToService()
        {
            // Arrange
            Guid parentId = Guid.NewGuid();
            IQueryable<ExampleBDto> expectedDtos = new List<ExampleBDto>
            {
                new ExampleBDto { Id = Guid.NewGuid(), ExampleAId = parentId, Name = "Child" }
            }.AsQueryable();
            this._mockService.GetByParent(parentId).Returns(expectedDtos);

            // Act
            IQueryable<ExampleBDto> result = this._controller.GetByParent(parentId);

            // Assert
            Assert.Single(result);
            this._mockService.Received(1).GetByParent(parentId);
        }

        [Fact]
        public void WhenGetByIdCalled_ThenDelegatesToQueryById()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            IQueryable<ExampleBDto> expectedDtos = new List<ExampleBDto>
            {
                new ExampleBDto { Id = id, Name = "Found" }
            }.AsQueryable();
            this._mockService.QueryById(id).Returns(expectedDtos);

            // Act
            IQueryable<ExampleBDto> result = this._controller.GetById(id);

            // Assert
            Assert.Single(result);
            this._mockService.Received(1).QueryById(id);
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