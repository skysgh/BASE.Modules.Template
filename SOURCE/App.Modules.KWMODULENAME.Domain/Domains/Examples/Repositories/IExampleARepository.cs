using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Shared.Repositories;

namespace App.Modules.KWMODULENAME.Domain.Domains.Examples.Repositories
{
    /// <summary>
    /// Repository contract for <see cref="ExampleA"/> entities.
    /// </summary>
    public interface IExampleARepository : ICrustStateRepository<ExampleA>
    {
    }
}
