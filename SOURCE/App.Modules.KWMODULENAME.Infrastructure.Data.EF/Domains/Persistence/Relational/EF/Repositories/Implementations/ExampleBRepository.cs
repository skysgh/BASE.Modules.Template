using App.Modules.KWMODULENAME.Domain.Domains.Examples.Repositories;
using App.Modules.KWMODULENAME.Infrastructure.Data.EF;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Infrastructure.Domains.Diagnostics;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;

namespace App.Modules.KWMODULENAME.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations
{
    /// <summary>
    /// CRUST repository for <see cref="ExampleB"/> entities.
    /// </summary>
    public class ExampleBRepository : CrustStateRepositoryBase<ExampleB>, IExampleBRepository
    {
        private const string StateActive = "Active";
        private const string StateInactive = "Inactive";

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleBRepository"/> class.
        /// </summary>
        /// <param name="db">The module database context.</param>
        /// <param name="logger">Logger instance for diagnostics.</param>
        public ExampleBRepository(ModuleDbContext db, IAppLogger logger)
            : base(logger, db)
        {
        }

        /// <inheritdoc/>
        public IQueryable<ExampleB> QueryByParent(Guid exampleAId)
        {
            return this.Query().Where(exampleB => exampleB.ExampleAId == exampleAId);
        }

        /// <inheritdoc/>
        public override async Task TransitionStateAsync(Guid id, string stateKey, CancellationToken cancellationToken = default)
        {
            ExampleB entity = await this.GetForUpdateAsync(id, cancellationToken)
                ?? throw new InvalidOperationException("ExampleB with ID " + id + " was not found.");

            switch (stateKey)
            {
                case StateActive:
                    break;
                case StateInactive:
                    break;
                default:
                    throw new InvalidOperationException(
                        "Invalid state '" + stateKey + "' for ExampleB. Valid states: "
                        + StateActive + ", " + StateInactive + ".");
            }

            await this.DbContext.SaveChangesAsync(cancellationToken);
            this.LoggerService.LogInformation("Transitioned ExampleB " + id + " to state " + stateKey);
        }
    }
}
