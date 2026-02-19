using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Services
{
    /// <summary>
    /// Application service contract for ExampleA operations.
    /// Returns IQueryable for OData filtering at the API boundary.
    /// </summary>
    public interface IExampleAApplicationService : IHasApplicationService
    {
        /// <summary>
        /// Gets a queryable collection of all ExampleA entities as DTOs.
        /// </summary>
        /// <returns>An IQueryable of <see cref="ExampleADto"/>.</returns>
        IQueryable<ExampleADto> GetAll();

        /// <summary>
        /// Gets a queryable for a single ExampleA by ID as DTO.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns>An IQueryable of <see cref="ExampleADto"/> filtered by the specified ID.</returns>
        IQueryable<ExampleADto> GetById(Guid id);

        /// <summary>
        /// Gets a queryable collection of all ExampleA entities modified after the given watermark.
        /// Used for incremental sync — clients pass the last-known timestamp to get only changes.
        /// </summary>
        /// <param name="modifiedAfter">Only return entities modified after this UTC timestamp.</param>
        /// <returns>An IQueryable of <see cref="ExampleADto"/> filtered by modification date.</returns>
        IQueryable<ExampleADto> GetModifiedAfter(DateTime modifiedAfter);
    }
}
