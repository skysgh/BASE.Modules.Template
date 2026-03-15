using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services
{
    /// <summary>
    /// Application service contract for ExampleA operations.
    /// </summary>
    public interface IExampleAApplicationService : ICrudStateAppService<ExampleADto, ExampleADto, ExampleADto>
    {
    }
}