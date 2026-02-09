using App.Base.Shared.Models.Contracts;

namespace App.Modules.KW_TEMPLATE.Application.APIs.Services.Configuration
{
    /// <summary>
    /// Configuration object
    /// used to describe Module.
    /// </summary>
    /// <remarks>
    /// <b>Development Concerns:</b><br/>
    /// Module developers provide default values.
    /// But as only needed for API Documentation, etc.
    /// and not Routing, are not required to be Static, 
    /// hence they are configurable if required.
    /// </remarks>
    public class ModuleDescription : IHasModuleDescription
    {
        /// <summary>
        /// Public default configurable Title of the Module
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public string Title { get; set; } = "TODO:KW_TEMPLATE:Title";

        /// <summary>
        /// Public configurable Description of the Module
        /// </summary>
        public string Description { get; set; } = "TODO:KW_TEMPLATE:Description";

        /// <summary>
        /// Public configurable Url to Module Maintainer web page.
        /// </summary>
        public string OrganisationUrl { get; set; } = "TODO:KW_TEMPLATE:Website Url";

        /// <summary>
        /// public configurable Url to Module maintainer Contact information web page.
        /// </summary>
        public string ContactUrl { get; set; } = "TODO:KW_TEMPLATE:Contact Url";

    }
}
