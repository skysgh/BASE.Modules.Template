using App.Modules.KWMODULENAME.Infrastructure.Data.EF;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Infrastructure.Services;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services.Implementations
{
    /// <summary>
    /// Implementation of <see cref="IExampleBApplicationService"/>.
    /// Uses <see cref="IObjectMappingService.ProjectTo{TSource, TTarget}"/>
    /// for EF-optimized server-side projection.
    /// </summary>
    public class ExampleBApplicationService : IExampleBApplicationService
    {
        private readonly KWMODULENAMEDbContext _db;
        private readonly IObjectMappingService _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleBApplicationService"/> class.
        /// </summary>
        /// <param name="db">The module database context.</param>
        /// <param name="mapper">The object mapping service for ProjectTo projections.</param>
        public ExampleBApplicationService(KWMODULENAMEDbContext db, IObjectMappingService mapper)
        {
            ArgumentNullException.ThrowIfNull(db);
            ArgumentNullException.ThrowIfNull(mapper);
            this._db = db;
            this._mapper = mapper;
        }

        /// <inheritdoc/>
        public IQueryable<ExampleBDto> GetAll()
        {
            return this._mapper.ProjectTo<ExampleB, ExampleBDto>(
                this._db.ExampleBs);
        }

        /// <inheritdoc/>
        public IQueryable<ExampleBDto> GetByParent(Guid exampleAId)
        {
            return this._mapper.ProjectTo<ExampleB, ExampleBDto>(
                this._db.ExampleBs.Where(e => e.ExampleAId == exampleAId));
        }

        /// <inheritdoc/>
        public IQueryable<ExampleBDto> GetById(Guid id)
        {
            return this._mapper.ProjectTo<ExampleB, ExampleBDto>(
                this._db.ExampleBs.Where(e => e.Id == id));
        }
    }
}
