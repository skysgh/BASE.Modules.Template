using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Services.Implementations;
using App.Modules.KWMODULENAME.Domain.Domains.Examples.Repositories;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Infrastructure.Domains.Diagnostics;
using App.Modules.Sys.Infrastructure.Services;
using NSubstitute;

namespace Tests.Modules.KWMODULENAME.Application
{
    /// <summary>
    /// Tests for <see cref="ExampleAApplicationService"/>.
    /// </summary>
    public class ExampleAApplicationServiceTests
    {
        private readonly IExampleARepository _repository;
        private readonly IObjectMappingService _mapper;
        private readonly IAppLogger _logger;
        private readonly ExampleAApplicationService _service;

        /// <summary>
        /// Sets up mocked dependencies for each test.
        /// </summary>
        public ExampleAApplicationServiceTests()
        {
            this._repository = Substitute.For<IExampleARepository>();
            this._mapper = Substitute.For<IObjectMappingService>();
            this._logger = Substitute.For<IAppLogger>();
            this._service = new ExampleAApplicationService(this._repository, this._mapper, this._logger);
        }

        [Fact]
        public void WhenQueryCalled_ThenProjectToIsInvokedOnce()
        {
            // Arrange
            IQueryable<ExampleA> entities = new List<ExampleA>().AsQueryable();
            IQueryable<ExampleADto> expectedDtos = new List<ExampleADto>().AsQueryable();
            this._repository.Query().Returns(expectedDtos.Provider.CreateQuery<ExampleA>(entities.Expression));
            this._mapper.ProjectTo<ExampleA, ExampleADto>(Arg.Any<IQueryable<ExampleA>>()).Returns(expectedDtos);

            // Act
            IQueryable<ExampleADto> result = this._service.Query();

            // Assert
            Assert.Same(expectedDtos, result);
            this._repository.Received(1).Query();
            this._mapper.Received(1).ProjectTo<ExampleA, ExampleADto>(Arg.Any<IQueryable<ExampleA>>());
        }

        [Fact]
        public void WhenQueryByIdCalled_ThenProjectToIsInvokedOnce()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            IQueryable<ExampleA> entities = new List<ExampleA>().AsQueryable();
            IQueryable<ExampleADto> expectedDtos = new List<ExampleADto>().AsQueryable();
            this._repository.QueryById(id).Returns(expectedDtos.Provider.CreateQuery<ExampleA>(entities.Expression));
            this._mapper.ProjectTo<ExampleA, ExampleADto>(Arg.Any<IQueryable<ExampleA>>()).Returns(expectedDtos);

            // Act
            IQueryable<ExampleADto> result = this._service.QueryById(id);

            // Assert
            Assert.Same(expectedDtos, result);
            this._repository.Received(1).QueryById(id);
            this._mapper.Received(1).ProjectTo<ExampleA, ExampleADto>(Arg.Any<IQueryable<ExampleA>>());
        }

        [Fact]
        public void WhenConstructedWithNullRepository_ThenThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new ExampleAApplicationService(null!, this._mapper, this._logger));
        }

        [Fact]
        public void WhenConstructedWithNullMapper_ThenThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new ExampleAApplicationService(this._repository, null!, this._logger));
        }

        [Fact]
        public void WhenConstructedWithNullLogger_ThenThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new ExampleAApplicationService(this._repository, this._mapper, null!));
        }
    }
}