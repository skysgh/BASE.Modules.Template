using App.Modules.KWMODULENAME.Interfaces.Models.Dtos;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Shared.ObjectMaps;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Maps
{
    /// <summary>
    /// Maps <see cref="ExampleA"/> domain entity to <see cref="ExampleADto"/>.
    /// Convention-based: all properties auto-map by name.
    /// Discovered at startup via <see cref="IObjectMap"/> reflection scan.
    /// </summary>
    public class ExampleAToExampleADtoMap : ObjectMapBase<ExampleA, ExampleADto>
    {
        // Convention-mapped: Id, Title, Description, IsActive, CreatedUtc, ModifiedUtc
        // Override ConfigureMapping() for custom mappings — see ObjectMapBase docs.
    }
}
