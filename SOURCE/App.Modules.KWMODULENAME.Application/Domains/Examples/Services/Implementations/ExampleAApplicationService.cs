using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Domain.Domains.Examples.Repositories;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Domains.Diagnostics;
using App.Modules.Sys.Infrastructure.Services;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services.Implementations
{
    /// <summary>
    /// Implementation of <see cref="IExampleAApplicationService"/>.
    /// </summary>
    public class ExampleAApplicationService : SimpleCrustStateAppServiceBase<ExampleA, ExampleADto>, IExampleAApplicationService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleAApplicationService"/> class.
        /// </summary>
        /// <param name="repository">The ExampleA repository.</param>
        /// <param name="mapper">The object mapping service for ProjectTo projections.</param>
        /// <param name="logger">Logger instance for diagnostics.</param>
        public ExampleAApplicationService(
            IExampleARepository repository,
            IObjectMappingService mapper,
            IAppLogger logger)
            : base(repository, mapper, logger)
        {
        }
    }
}