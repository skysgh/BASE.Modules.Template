using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Shared.Repositories;

namespace App.Modules.KWMODULENAME.Domain.Domains.Examples.Repositories
{
    /// <summary>
    /// Repository contract for <see cref="ExampleB"/> entities.
    /// </summary>
    public interface IExampleBRepository : ICrustStateRepository<ExampleB>
    {
        /// <summary>
        /// Returns child entities for a specific parent.
        /// </summary>
        IQueryable<ExampleB> QueryByParent(Guid exampleAId);
    }
}
