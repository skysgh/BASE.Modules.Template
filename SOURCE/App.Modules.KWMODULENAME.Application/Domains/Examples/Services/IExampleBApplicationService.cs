using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.Sys.Application;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services
{
    /// <summary>
    /// Application service contract for ExampleB operations.
    /// Returns IQueryable for OData filtering at the API boundary.
    /// </summary>
    public interface IExampleBApplicationService : IHasApplicationService
    {
        /// <summary>
        /// Gets a queryable collection of all ExampleB entities as DTOs.
        /// </summary>
        /// <returns>An IQueryable of <see cref="ExampleBDto"/>.</returns>
        IQueryable<ExampleBDto> GetAll();

        /// <summary>
        /// Gets ExampleB entities belonging to a specific ExampleA parent.
        /// </summary>
        /// <param name="exampleAId">The parent entity identifier.</param>
        /// <returns>An IQueryable of <see cref="ExampleBDto"/> filtered by parent.</returns>
        IQueryable<ExampleBDto> GetByParent(Guid exampleAId);

        /// <summary>
        /// Gets a queryable for a single ExampleB by ID as DTO.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns>An IQueryable of <see cref="ExampleBDto"/> filtered by the specified ID.</returns>
        IQueryable<ExampleBDto> GetById(Guid id);
    }
}
