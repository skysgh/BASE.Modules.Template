namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos
{
    /// <summary>
    /// Data transfer object for <see cref="Shared.Domains.Examples.Models.ExampleA"/>.
    /// Exposed to API consumers — never expose domain entities directly.
    /// </summary>
    public class ExampleADto
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string? Description { get; set; }

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
