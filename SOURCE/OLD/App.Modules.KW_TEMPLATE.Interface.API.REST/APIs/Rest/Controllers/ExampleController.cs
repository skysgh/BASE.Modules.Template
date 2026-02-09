using App.Base.Presentation.Web.APIs.Rest.Controllers.Base;
using App.Base.Shared.Attributes;
using App.Modules.KW_TEMPLATE.Presentation.Web.APIs.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.KW_TEMPLATE.Presentation.Web.APIs.Rest.Controllers
{
    /// <summary>
    /// IMPORTANT:
    /// Take this attribute off 
    /// when ready or for production.
    /// </summary>
    /// <remarks>
    /// Can inherit directly from 
    /// <see cref="ControllerBase"/> or
    /// the app specific 
    /// <see cref="AppWebApiControllerBase"/>
    /// </remarks>
    [ForDemoOnly]
    [Route(Route)]
    ////For Swagger:
    [ApiExplorerSettings(GroupName = ModuleApiRoutingConstants.Protocols.OData.GroupIdentifier)]
    [Produces("application/json")]
    public class ExampleController : AppWebApiControllerBase   
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
        internal const string Route = $"{ModuleApiRoutingConstants.Protocols.Rest.RoutePrefix}/{Name}";

    }
}
