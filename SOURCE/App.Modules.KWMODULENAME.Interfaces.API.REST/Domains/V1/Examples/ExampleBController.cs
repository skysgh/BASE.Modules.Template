using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Services;
using App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Interfaces.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.V1.Examples
{
    /// <summary>
    /// REST API controller for ExampleB operations.
    /// </summary>
    [ApiController]
    [Route(ApiRoutes.Rest.V1.ExampleBs.Base)]
    public class ExampleBController : SimpleCrudStateControllerBase<ExampleBDto>
    {
        private readonly IExampleBApplicationService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleBController"/> class.
        /// </summary>
        /// <param name="service">The ExampleB application service.</param>
        public ExampleBController(IExampleBApplicationService service)
            : base(service)
        {
            ArgumentNullException.ThrowIfNull(service);
            this._service = service;
        }

        /// <summary>
        /// Gets ExampleB entities for a specific parent.
        /// Supports OData query options (<c>$filter</c>, <c>$orderby</c>, <c>$top</c>, <c>$skip</c>, <c>$select</c>).
        /// </summary>
        /// <param name="parentId">The parent ExampleA identifier.</param>
        /// <returns>Queryable of ExampleB DTOs.</returns>
        [HttpGet("by-parent/{parentId:guid}")]
        [EnableQuery]
        [ProducesResponseType(typeof(IQueryable<ExampleBDto>), 200)]
        public IQueryable<ExampleBDto> GetByParent(Guid parentId)
        {
            return this._service.GetByParent(parentId);
        }
    }
}