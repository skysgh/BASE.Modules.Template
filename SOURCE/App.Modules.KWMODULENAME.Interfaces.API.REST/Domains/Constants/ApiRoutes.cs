using App.Modules.Sys.Substrate.Infrastructure.Constants;

namespace App.Modules.KWMODULENAME.Interfaces.API.REST.Domains.Constants
{
    /// <summary>
    /// KWMODULENAME module API route constants.
    /// NO MAGIC STRINGS — all routes composed from constants.
    /// Organized by: {root}/{api-type}/{module}/{version}/{path}
    /// </summary>
    /// <remarks>
    /// Pattern: api/rest/kwmodulename/v1/{controller-path}
    /// Built on shared <see cref="ApiConstants"/> from Substrate.
    /// </remarks>
    public static class ApiRoutes
    {
        /// <summary>
        /// Module identifier for URL building.
        /// </summary>
        private const string ModuleId = ModuleConstants.Key;

        /// <summary>
        /// REST module base: api/rest/kwmodulename
        /// </summary>
        private const string RestModuleBase = ApiConstants.Root + "/" + ApiConstants.RestType + "/" + ModuleId;

        /// <summary>
        /// REST API routes for KWMODULENAME module.
        /// </summary>
        public static class Rest
        {
            /// <summary>
            /// Version 1 of KWMODULENAME module REST APIs.
            /// </summary>
            public static class V1
            {
                private const string VersionBase = RestModuleBase + "/" + ApiConstants.Versions.V1;

                /// <summary>
                /// Standard controller route template.
                /// Value: "api/rest/kwmodulename/v1/{controller}"
                /// </summary>
                public const string ControllerRoute = VersionBase + "/{controller}";

                /// <summary>
                /// ExampleA endpoints (api/rest/kwmodulename/v1/example-a).
                /// </summary>
                public static class ExampleAs
                {
                    /// <summary>
                    /// ExampleA base path.
                    /// Value: "api/rest/kwmodulename/v1/example-a"
                    /// </summary>
                    public const string Base = VersionBase + "/example-a";
                }

                /// <summary>
                /// ExampleB endpoints (api/rest/kwmodulename/v1/example-b).
                /// </summary>
                public static class ExampleBs
                {
                    /// <summary>
                    /// ExampleB base path.
                    /// Value: "api/rest/kwmodulename/v1/example-b"
                    /// </summary>
                    public const string Base = VersionBase + "/example-b";
                }
            }
        }
    }
}