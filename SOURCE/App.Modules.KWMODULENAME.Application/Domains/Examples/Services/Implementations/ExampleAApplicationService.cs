using App.Modules.KWMODULENAME.Infrastructure.Data.EF;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Infrastructure.Services;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services.Implementations
{
    /// <summary>
    /// Implementation of <see cref="IExampleAApplicationService"/>.
    /// Uses <see cref="IObjectMappingService.ProjectTo{TSource, TTarget}"/>
    /// for EF-optimized server-side projection (single SQL query, needed columns only).
    /// </summary>
    public class ExampleAApplicationService : IExampleAApplicationService
    {
        private readonly KWMODULENAMEDbContext _db;
        private readonly IObjectMappingService _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleAApplicationService"/> class.
        /// </summary>
        /// <param name="db">The module database context.</param>
        /// <param name="mapper">The object mapping service for ProjectTo projections.</param>
        public ExampleAApplicationService(KWMODULENAMEDbContext db, IObjectMappingService mapper)
        {
            ArgumentNullException.ThrowIfNull(db);
            ArgumentNullException.ThrowIfNull(mapper);
            this._db = db;
            this._mapper = mapper;
        }

        /// <inheritdoc/>
        public IQueryable<ExampleADto> GetAll()
        {
            return this._mapper.ProjectTo<ExampleA, ExampleADto>(
                this._db.ExampleAs);
        }

        /// <inheritdoc/>
        public IQueryable<ExampleADto> GetById(Guid id)
        {
            return this._mapper.ProjectTo<ExampleA, ExampleADto>(
                this._db.ExampleAs.Where(e => e.Id == id));
        }

        /// <inheritdoc/>
        public IQueryable<ExampleADto> GetModifiedAfter(DateTime modifiedAfter)
        {
            return this._mapper.ProjectTo<ExampleA, ExampleADto>(
                this._db.ExampleAs.Where(e => e.ModifiedUtc != null && e.ModifiedUtc > modifiedAfter));
        }
    }
}
