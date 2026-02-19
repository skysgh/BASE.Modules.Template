using App.Modules.KWMODULENAME.Application.Domains.Examples.Services;
using App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.Constants;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using App.Modules.Sys.Controllers;

namespace App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.V1.Examples
{
    /// <summary>
    /// REST API controller for ExampleB operations.
    /// Demonstrates a child entity controller with parent-scoped queries.
    /// </summary>
    /// <remarks>
    /// ExampleB entities belong to an ExampleA parent.
    /// OData provides filtering, and parent-scoped lookup via <c>parentId</c>.
    /// </remarks>
    [ApiController]
    [Route(ApiRoutes.Rest.V1.ExampleBs.Base)]
    [Produces("application/json")]
    public class ExampleBController : ControllerBase, IHasController
    {
        private readonly IExampleBApplicationService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleBController"/> class.
        /// </summary>
        /// <param name="service">The ExampleB application service.</param>
        public ExampleBController(IExampleBApplicationService service)
        {
            ArgumentNullException.ThrowIfNull(service);
            this._service = service;
        }

        /// <summary>
        /// Gets all ExampleB entities.
        /// Supports OData query options (<c>$filter</c>, <c>$orderby</c>, <c>$top</c>, <c>$skip</c>, <c>$select</c>).
        /// </summary>
        /// <param name="parentId">
        /// Optional parent ExampleA identifier. When provided, returns only child entities
        /// belonging to this parent. Example: <c>?parentId=00000000-0000-0000-0000-000000000001</c>
        /// </param>
        /// <returns>Queryable of ExampleB DTOs.</returns>
        /// <response code="200">Returns the entities.</response>
        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(typeof(IQueryable<ExampleBDto>), 200)]
        public IQueryable<ExampleBDto> GetAll([FromQuery] Guid? parentId = null)
        {
            if (parentId.HasValue)
            {
                return this._service.GetByParent(parentId.Value);
            }

            return this._service.GetAll();
        }

        /// <summary>
        /// Gets a single ExampleB by identifier.
        /// Supports OData query options (<c>$select</c>).
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns>Queryable containing the single entity.</returns>
        /// <response code="200">Returns the entity.</response>
        [HttpGet("{id:guid}")]
        [EnableQuery]
        [ProducesResponseType(typeof(IQueryable<ExampleBDto>), 200)]
        public IQueryable<ExampleBDto> GetById(Guid id)
        {
            return this._service.GetById(id);
        }
    }
}
