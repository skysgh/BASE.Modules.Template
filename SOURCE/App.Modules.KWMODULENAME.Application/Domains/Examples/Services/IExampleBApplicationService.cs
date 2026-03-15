using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services
{
    /// <summary>
    /// Application service contract for ExampleB operations.
    /// </summary>
    public interface IExampleBApplicationService : ICrudStateAppService<ExampleBDto, ExampleBDto, ExampleBDto>
    {
        /// <summary>
        /// Gets ExampleB entities belonging to a specific ExampleA parent.
        /// </summary>
        IQueryable<ExampleBDto> GetByParent(Guid exampleAId);
    }
}