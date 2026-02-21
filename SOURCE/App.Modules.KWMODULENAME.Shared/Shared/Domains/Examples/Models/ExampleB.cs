namespace App.Modules.KWMODULENAME.Shared.Domains.Examples.Models
{
    /// <summary>
    /// Example entity B — demonstrates a child/related domain entity
    /// that references <see cref="ExampleA"/> via a foreign key.
    /// Replace with your actual domain entity when cloning.
    /// </summary>
    public class ExampleB
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the parent <see cref="ExampleA"/> identifier.
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