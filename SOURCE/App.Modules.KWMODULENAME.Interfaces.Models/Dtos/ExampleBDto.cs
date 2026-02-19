namespace App.Modules.KWMODULENAME.Interfaces.Models.Dtos
{
    /// <summary>
    /// Data transfer object for <see cref="Shared.Domains.Examples.Models.ExampleB"/>.
    /// Exposed to API consumers — never expose domain entities directly.
    /// </summary>
    public class ExampleBDto
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the parent ExampleA identifier.
        /// </summary>
        public Guid ExampleAId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the date this entity was created (UTC).
        /// </summary>
        public DateTime CreatedUtc { get; set; }
    }
}
