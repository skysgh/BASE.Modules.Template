using App.Modules.KWMODULENAME.Domain.Domains.Examples.Repositories;
using App.Modules.KWMODULENAME.Infrastructure.Data.EF;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Infrastructure.Domains.Diagnostics;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;

namespace App.Modules.KWMODULENAME.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations
{
    /// <summary>
    /// CRUST repository for <see cref="ExampleA"/> entities.
    /// Extends <see cref="CrustStateRepositoryBase{TEntity}"/> with domain-specific state transition logic.
    /// </summary>
    public class ExampleARepository : CrustStateRepositoryBase<ExampleA>, IExampleARepository
    {
        private const string StateActive = "Active";
        private const string StateInactive = "Inactive";

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleARepository"/> class.
        /// </summary>
        /// <param name="db">The module database context.</param>
        /// <param name="logger">Logger instance for diagnostics.</param>
        public ExampleARepository(ModuleDbContext db, IAppLogger logger)
            : base(logger, db)
        {
        }

        /// <inheritdoc/>
        public override async Task TransitionStateAsync(
            Guid id,
            string stateKey,
            CancellationToken cancellationToken = default)
        {
            ExampleA entity = await this.GetForUpdateAsync(id, cancellationToken)
                ?? throw new InvalidOperationException(
                    "ExampleA with ID " + id + " was not found.");

            switch (stateKey)
            {
                case StateActive:
                    entity.IsActive = true;
                    break;
                case StateInactive:
                    entity.IsActive = false;
                    break;
                default:
                    throw new InvalidOperationException(
                        "Invalid state '" + stateKey + "' for ExampleA. Valid states: "
                        + StateActive + ", " + StateInactive + ".");
            }

            await this.DbContext.SaveChangesAsync(cancellationToken);
            this.LoggerService.LogInformation(
                "Transitioned ExampleA " + id + " to state " + stateKey);
        }
    }
}
