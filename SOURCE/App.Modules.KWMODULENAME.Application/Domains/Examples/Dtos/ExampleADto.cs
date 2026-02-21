using App.Modules.Sys.Shared.Models;
using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos
{
    /// <summary>
    /// Data transfer object for <see cref="Shared.Domains.Examples.Models.ExampleA"/>.
    /// Exposed to API consumers — never expose domain entities directly.
    /// </summary>
    /// <remarks>
    /// Implements Substrate contracts for the properties it exposes,
    /// enabling use of <c>MapBuilderExtensions</c> shorthand in object maps.
    /// </remarks>
    public class ExampleADto :
        IHasGuidId,
        IHasTitleAndDescription
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <inheritdoc/>
        public string Title { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether this entity is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date this entity was created (UTC).
        /// </summary>
        public DateTime CreatedUtc { get; set; }

        /// <summary>
        /// Gets or sets the date this entity was last modified (UTC).
        /// </summary>
        public DateTime? ModifiedUtc { get; set; }
    }
}