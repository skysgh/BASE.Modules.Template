using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Services;
using App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Interfaces.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.V1.Examples
{
    /// <summary>
    /// REST API controller for ExampleA operations.
    /// </summary>
    [ApiController]
    [Route(ApiRoutes.Rest.V1.ExampleAs.Base)]
    public class ExampleAController : SimpleCrudStateControllerBase<ExampleADto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleAController"/> class.
        /// </summary>
        /// <param name="service">The ExampleA application service.</param>
        public ExampleAController(IExampleAApplicationService service)
            : base(service)
        {
        }
    }
}