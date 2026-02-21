using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Application.Domains.Examples.Services;
using App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.V1.Examples
{
    /// <summary>
    /// REST API controller for ExampleA operations.
    /// Query endpoints return IQueryable for OData filtering/paging/sorting.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Collection endpoints accept an optional <c>modifiedAfter</c> watermark date.
    /// Clients pass the last-known timestamp to receive only changes since that point
    /// (incremental sync pattern).
    /// </para>
    /// <para>
    /// OData provides filtering by active status, creation date, etc.
    /// Global middleware enforces MaxTop=100 — no unbounded queries.
    /// </para>
    /// </remarks>
    [ApiController]
    [Route(ApiRoutes.Rest.V1.ExampleAs.Base)]
    public class ExampleAController : ControllerBase, IHasController
    {
        private readonly IExampleAApplicationService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleAController"/> class.
        /// </summary>
        /// <param name="service">The ExampleA application service.</param>
        public ExampleAController(IExampleAApplicationService service)
        {
            ArgumentNullException.ThrowIfNull(service);
            this._service = service;
        }

        /// <summary>
        /// Gets all ExampleA entities.
        /// Supports OData query options (<c>$filter</c>, <c>$orderby</c>, <c>$top</c>, <c>$skip</c>, <c>$select</c>).
        /// </summary>
        /// <param name="modifiedAfter">
        /// Optional watermark date (UTC). When provided, returns only entities
        /// modified after this timestamp. Used for incremental sync.
        /// Example: <c>?modifiedAfter=2025-01-15T00:00:00Z</c>
        /// </param>
        /// <returns>Queryable of ExampleA DTOs.</returns>
        /// <remarks>
        /// <b>Note:</b> The global <c>WatermarkDateFilter</c> also applies <c>?modifiedAfter=</c>
        /// automatically to all IQueryable GET endpoints whose DTO has a timestamp property.
        /// This explicit parameter is kept here for Swagger documentation and as a teaching example
        /// of how the service-level <c>GetModifiedAfter()</c> method works.
        /// </remarks>
        /// <response code="200">Returns the entities.</response>
        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(typeof(IQueryable<ExampleADto>), 200)]
        public IQueryable<ExampleADto> GetAll([FromQuery] DateTime? modifiedAfter = null)
        {
            if (modifiedAfter.HasValue)
            {
                return this._service.GetModifiedAfter(modifiedAfter.Value);
            }

            return this._service.GetAll();
        }

        /// <summary>
        /// Gets a single ExampleA by identifier.
        /// Supports OData query options (<c>$select</c>).
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns>Queryable containing the single entity.</returns>
        /// <response code="200">Returns the entity.</response>
        [HttpGet("{id:guid}")]
        [EnableQuery]
        [ProducesResponseType(typeof(IQueryable<ExampleADto>), 200)]
        public IQueryable<ExampleADto> GetById(Guid id)
        {
            return this._service.GetById(id);
        }
    }
}