using App.Modules.KWMODULENAME.Application.Domains.Examples.Services.Implementations;
using App.Modules.KWMODULENAME.Infrastructure.Data.EF;
using App.Modules.KWMODULENAME.Interfaces.Models.Dtos;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Tests.Modules.KWMODULENAME.Application
{
    /// <summary>
    /// Tests for <see cref="ExampleAApplicationService"/>.
    /// Verifies that the service correctly delegates to <see cref="IObjectMappingService.ProjectTo{TSource, TTarget}"/>
    /// and returns IQueryable for deferred execution.
    /// </summary>
    public class ExampleAApplicationServiceTests : IDisposable
    {
        private readonly KWMODULENAMEDbContext _db;
        private readonly IObjectMappingService _mapper;
        private readonly ExampleAApplicationService _service;

        /// <summary>
        /// Sets up a fresh in-memory DbContext and mocked mapper for each test.
        /// </summary>
        public ExampleAApplicationServiceTests()
        {
            var options = new DbContextOptionsBuilder<KWMODULENAMEDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            this._db = new KWMODULENAMEDbContext(options);
            this._mapper = Substitute.For<IObjectMappingService>();
            this._service = new ExampleAApplicationService(this._db, this._mapper);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this._db.Dispose();
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void WhenGetAllCalled_ThenProjectToIsInvokedOnce()
        {
            // Arrange
            var expectedDtos = new List<ExampleADto>().AsQueryable();
            this._mapper
                .ProjectTo<ExampleA, ExampleADto>(Arg.Any<IQueryable<ExampleA>>())
                .Returns(expectedDtos);

            // Act
            var result = this._service.GetAll();

            // Assert
            Assert.NotNull(result);
            this._mapper.Received(1)
                .ProjectTo<ExampleA, ExampleADto>(Arg.Any<IQueryable<ExampleA>>());
        }

        [Fact]
        public void WhenGetByIdCalled_ThenProjectToIsInvokedOnce()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedDtos = new List<ExampleADto>().AsQueryable();
            this._mapper
                .ProjectTo<ExampleA, ExampleADto>(Arg.Any<IQueryable<ExampleA>>())
                .Returns(expectedDtos);

            // Act
            var result = this._service.GetById(id);

            // Assert
            Assert.NotNull(result);
            this._mapper.Received(1)
                .ProjectTo<ExampleA, ExampleADto>(Arg.Any<IQueryable<ExampleA>>());
        }

        [Fact]
        public void WhenGetModifiedAfterCalled_ThenProjectToIsInvokedOnce()
        {
            // Arrange
            var watermark = DateTime.UtcNow.AddDays(-1);
            var expectedDtos = new List<ExampleADto>().AsQueryable();
            this._mapper
                .ProjectTo<ExampleA, ExampleADto>(Arg.Any<IQueryable<ExampleA>>())
                .Returns(expectedDtos);

            // Act
            var result = this._service.GetModifiedAfter(watermark);

            // Assert
            Assert.NotNull(result);
            this._mapper.Received(1)
                .ProjectTo<ExampleA, ExampleADto>(Arg.Any<IQueryable<ExampleA>>());
        }

        [Fact]
        public void WhenConstructedWithNullDb_ThenThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new ExampleAApplicationService(null!, this._mapper));
        }

        [Fact]
        public void WhenConstructedWithNullMapper_ThenThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new ExampleAApplicationService(this._db, null!));
        }
    }
}
