using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.DbContexts.Implementations.Base;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.KWMODULENAME.Infrastructure.Data.EF
{
    /// <summary>
    /// Database context for the KWMODULENAME module.
    /// Each module has its own DbContext to enforce bounded context separation.
    /// Schema configurations are discovered via <c>IEntityTypeConfiguration&lt;T&gt;</c>.
    /// </summary>
    public class ModuleDbContext : ModuleDbContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleDbContext"/> class.
        /// </summary>
        /// <param name="options">The database context options.</param>
        public ModuleDbContext(DbContextOptions<ModuleDbContext> options)
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
            // Set schema before base call so all entities use this module's schema.
            this.SchemaKey = App.Modules.KWMODULENAME.ModuleConstants.DbSchemaKey;

            base.OnModelCreating(modelBuilder);

            // EF configurations are discovered via IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModuleDbContext).Assembly);
        }
    }
}