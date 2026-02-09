using App.Base.Infrastructure.Services;
using App.Base.Presentation.Web.APIs.OData.Controllers.Base;
using App.Base.Shared.Attributes;
using App.Modules.KW_TEMPLATE.Presentation.Web.APIs.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.KW_TEMPLATE.Presentation.Web.APIs.Rest.OData.Controllers
{
    [Route(Route)]
    [ForDemoOnly]
    //For Swagger:
    [ApiExplorerSettings(GroupName = ModuleApiRoutingConstants.Protocols.OData.GroupIdentifier)]
    [Produces("application/json")]
    public class ExampleController : AppBasicODataControllerBase
    {
        /// <summary>
        /// Name of Controller.
        /// <para>
        /// Unique per Protocol per Module.
        /// </para>
        /// <para>
        /// Combined with the Module Key
        /// used to develop the 
        /// Route to the Controller.
        /// </para>
        /// <para>
        /// Note that when a Controller is OData enabled, 
        /// the Name is used to register the 
        /// route in the OData EDM Model.
        /// </para>
        /// </summary>
        internal const string Name = "Example";

        /// <summary>
        /// The unique Route to the Controller, combining
        /// <list type="bullet">
        /// <item>Module Key</item>
        /// <item>Protocol based Service Root</item>
        /// <item>API Version</item>
        /// <item>Controller Name</item>
        /// </list>
        /// </summary>
        internal const string Route = $"{ModuleApiRoutingConstants.Protocols.OData.RoutePrefix}/{Name}";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="principalService"></param>
        public ExampleController(IPrincipalService principalService) : base(principalService)
        {
        }
    }
}
