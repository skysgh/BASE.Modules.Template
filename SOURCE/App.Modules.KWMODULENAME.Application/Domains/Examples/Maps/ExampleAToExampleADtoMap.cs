using App.Modules.KWMODULENAME.Application.Domains.Examples.Dtos;
using App.Modules.KWMODULENAME.Shared.Domains.Examples.Models;
using App.Modules.Sys.Shared.ObjectMaps.Models;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

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
        // or develop custom map:
        /// <inheritdoc/>
        protected override void ConfigureMapping()
        {
            CreateMap()
                //.Ignore(dest => dest.IsActive)
                .MapFrom(dest => dest.CreatedUtc, src => src.CreatedUtc)
                .MapFrom(dest => dest.ModifiedUtc, src => src.ModifiedUtc)
                .MapFrom(dest => dest.IsActive, src => src.IsActive)
                .MapFrom(dest => dest.Id, src => src.Id)
                .MapFrom(dest => dest.Title, src => src.Title)
                .MapFrom(dest => dest.Description, src => src.Description);

            //.MapFrom(dest => dest.Id, src => $"{src.id} {src.LastName}");

        }

    }
}