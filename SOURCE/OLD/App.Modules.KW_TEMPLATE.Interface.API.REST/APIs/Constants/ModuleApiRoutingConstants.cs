using App.Base.Presentation.Web.APIs.Constants;
using App.Modules.KW_TEMPLATE.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.KW_TEMPLATE.Presentation.Web.APIs.Constants
{

        /// <summary>
        /// Class of Constants to describe
        /// APIs, specific to this assembly.
        /// <para>
        /// Module specific 
        /// route constants must be redefined 
        /// per Module - rather than be dynamically
        /// determined variables - as Attributes (eg:
        /// RouteAttribute on Controllers) 
        /// must be Constants.
        /// </para>
        /// </summary>
        public static class ModuleApiRoutingConstants
        {
            /// <summary>
            /// Name of the Module
            /// <para>
            /// Used to develop unique 
            /// Routes for Controllers
            /// of the same name in different 
            /// Modules.
            /// </para>
            /// </summary>
            public const string Name = ModuleConstants.Key;


            /// <summary>
            /// TODO
            /// </summary>
            public static class Protocols
            {

                /// <summary>
                /// Rest based Protocol documentation constants.
                /// </summary>
                public static class Rest
                {

                    /// <summary>
                    /// Name used to differentiate Protocol
                    /// specific APIs from other APIs.
                    /// </summary>
                    /// <remarks>
                    /// <b>Development Perspective:</b><br/>
                    /// Key is used to decorate individual API endpoints
                    /// so that Swagger develops them into distict OpenAPI
                    /// json files.
                    /// </remarks>
                    public const string GroupIdentifier =
                        $"{ModuleConstants.Key}-Rest";

                    /// <summary>
                    /// The Route Prefix for all
                    /// Rest 
                    /// based Controllers 
                    /// in this Module.
                    /// </summary>
                    public const string RoutePrefix =
                        $"{AppApiRoutingConstants.RestApiRoutePrefixPart}/" +
                        $"{Name}/" +
                        $"{AppApiRoutingConstants.VersionRoutePart}";
                }

                /// <summary>
                /// 
                /// </summary>
                public static class OData
                {

                    /// <summary>
                    /// Name used to differentiate Protocol
                    /// specific APIs from other APIs.
                    /// </summary>
                    /// <remarks>
                    /// <b>Development Perspective:</b><br/>
                    /// Key is used to decorate individual API endpoints
                    /// so that Swagger develops them into distict OpenAPI
                    /// json files.
                    /// </remarks>
                    public const string GroupIdentifier =
                        $"{ModuleConstants.Key}-Rest-OData";

                    /// <summary>
                    /// The Odata Prefix for all
                    /// OData
                    /// based Controllers 
                    /// in this Module.
                    /// </summary>
                    public const string RoutePrefix =
                        $"{AppApiRoutingConstants.ODataApiRoutePrefixPart}/" +
                        $"{Name}/" +
                        $"{AppApiRoutingConstants.VersionRoutePart}";
                }
                /// <summary>
                /// Constants for documenting
                /// GraphML endpoints.
                /// </summary>
                public static class GraphML
                {
                    /// <summary>
                    /// Name used to differentiate Protocol
                    /// specific APIs from other APIs.
                    /// </summary>
                    /// <remarks>
                    /// <b>Development Perspective:</b><br/>
                    /// Key is used to decorate individual API endpoints
                    /// so that Swagger develops them into distict OpenAPI
                    /// json files.
                    /// </remarks>
                    public const string GroupIdentifier =
                        $"{ModuleConstants.Key}-GraphML";


                    /// <summary>
                    /// The Prefix for all
                    /// GraphML based Controllers 
                    /// in this Module.
                    /// </summary>
                    public const string RoutePrefix =
                        $"{AppApiRoutingConstants.GraphQLApiRoutePrefixPart}/" +
                        $"{Name}/" +
                        $"{AppApiRoutingConstants.VersionRoutePart}";

                }

                /// <summary>
                /// Still used...
                /// TODO
                /// </summary>
                public static class Soap
                {
                    /// <summary>
                    /// Name used to differentiate Protocol
                    /// specific APIs from other APIs.
                    /// </summary>
                    /// <remarks>
                    /// <b>Development Perspective:</b><br/>
                    /// Key is used to decorate individual API endpoints
                    /// so that Swagger develops them into distict OpenAPI
                    /// json files.
                    /// </remarks>
                    public const string GroupIdentifier =
                        $"{ModuleConstants.Key}-Soap";


                    /// <summary>
                    /// The Prefix for all
                    /// SOAP based endpoints
                    /// in this Module.
                    /// </summary>
                    public const string RoutePrefix =
                    $"{AppApiRoutingConstants.SoapApiRoutePrefixPart}/{Name}/{AppApiRoutingConstants.VersionRoutePart}";

                }//~Protocol
            }//~Protocols
        }//~class
    }
