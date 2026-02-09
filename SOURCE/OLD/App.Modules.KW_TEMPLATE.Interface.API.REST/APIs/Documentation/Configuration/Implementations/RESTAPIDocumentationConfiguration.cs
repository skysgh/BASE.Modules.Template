using App.Base.Application.APIs.Configuration;
using App.Base.Presentation.Web.APIs.Constants;
using App.Base.Presentation.Web.APIs.Documentation.Configuration.Implemenation.Base;
using App.Base.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.KW_TEMPLATE.Presentation.Web.APIs.Documentation.Configuration.Implementations
{
    /// <summary>
    /// REST specific implementation of 
    /// Module's common API documentation information.
    /// </summary>
    public class RESTAPIDocumentationConfiguration : APIDocumentationConfigurationBase
    {
        /// <inheritdoc/>
        public override string Key { get; } = ModuleApiRoutingConstants.Protocols.Rest.GroupIdentifier;

        /// <inheritdoc/>
        public override string Title { get; set; } = $"{ModuleConstants.Key} REST Endpoints";


        /// <inheritdoc/>
        public override string Description { get; set; } = $"REST endpoints of the {ModuleConstants.Key} Logical Module.";


        /// <inheritdoc/>
        public override string VersionText { get; set; } = "v1";

    }

}
