using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Domain.Domains.Examples.Repositories;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Domains.Diagnostics;
using App.Modules.Sys.Infrastructure.Services;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services.Implementations
{
    /// <summary>
    /// Implementation of <see cref="IExampleBApplicationService"/>.
    /// </summary>
    public class ExampleBApplicationService : SimpleCrustStateAppServiceBase<ExampleB, ExampleBDto>, IExampleBApplicationService
    {
        private readonly IExampleBRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleBApplicationService"/> class.
        /// </summary>
        /// <param name="repository">The ExampleB repository.</param>
        /// <param name="mapper">The object mapping service for ProjectTo projections.</param>
        /// <param name="logger">Logger instance for diagnostics.</param>
        public ExampleBApplicationService(
            IExampleBRepository repository,
            IObjectMappingService mapper,
            IAppLogger logger)
            : base(repository, mapper, logger)
        {
            this._repository = repository;
        }

        /// <inheritdoc/>
        public IQueryable<ExampleBDto> GetByParent(Guid exampleAId)
        {
            return this.ObjectMappingService.ProjectTo<ExampleB, ExampleBDto>(
                this._repository.QueryByParent(exampleAId));
        }
    }
}