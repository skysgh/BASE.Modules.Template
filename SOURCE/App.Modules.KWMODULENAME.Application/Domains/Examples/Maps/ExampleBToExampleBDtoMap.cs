using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Shared.ObjectMaps;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.KWMODULENAME.Application.Domains.Examples.Maps
{
    /// <summary>
    /// Maps <see cref="ExampleB"/> domain entity to <see cref="ExampleBDto"/>.
    /// Convention-based: all properties auto-map by name.
    /// Discovered at startup via <see cref="IObjectMap"/> reflection scan.
    /// </summary>
    public class ExampleBToExampleBDtoMap : ObjectMapBase<ExampleB, ExampleBDto>
    {
        // Convention-mapped: Id, ExampleAId, Name, SortOrder, CreatedUtc
    }
}
