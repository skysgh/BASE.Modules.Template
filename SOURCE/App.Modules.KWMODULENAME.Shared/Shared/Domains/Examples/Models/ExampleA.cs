namespace App.Modules.KWMODULENAME.Shared.Domains.Examples.Models
{
    /// <summary>
    /// Example entity A — demonstrates a simple domain entity
    /// with an owned title, description, and active flag.
    /// Replace with your actual domain entity when cloning.
    /// </summary>
    public class ExampleA
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