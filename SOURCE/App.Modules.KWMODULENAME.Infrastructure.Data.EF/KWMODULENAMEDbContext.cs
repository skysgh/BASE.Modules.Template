using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.KWMODULENAME.Infrastructure.Data.EF
{
    /// <summary>
    /// Database context for the KWMODULENAME module.
    /// Each module has its own DbContext to enforce bounded context separation.
    /// Schema configurations are discovered via <c>IEntityTypeConfiguration&lt;T&gt;</c>.
    /// </summary>
    public class KWMODULENAMEDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KWMODULENAMEDbContext"/> class.
        /// </summary>
        /// <param name="options">The database context options.</param>
        public KWMODULENAMEDbContext(DbContextOptions<KWMODULENAMEDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the ExampleA entities.
        /// </summary>
        public DbSet<ExampleA> ExampleAs { get; set; } = null!;

        /// <summary>
        /// Gets or sets the ExampleB entities.
        /// </summary>
        public DbSet<ExampleB> ExampleBs { get; set; } = null!;

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);
            base.OnModelCreating(modelBuilder);

            // EF configurations are discovered via IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KWMODULENAMEDbContext).Assembly);
        }
    }
}
