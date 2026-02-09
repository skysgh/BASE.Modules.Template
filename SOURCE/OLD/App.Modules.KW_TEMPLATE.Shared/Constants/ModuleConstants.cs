using App.Base.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.KW_TEMPLATE.Shared.Constants
{
    /// <summary>
    /// A static class of Constants used in
    /// this logical Module.
    /// <para>
    /// The class is public to allow the rest of 
    /// the Logical Module to reference it, 
    /// but Base or any other logical module probably
    /// should not (in order to not hard ref the module).
    /// </para>
    /// </summary>
    public static class ModuleConstants
    {
        /// <summary>
        /// The unique key to disambiguate this 
        /// logical module from others.
        /// </summary>
        /// <remarks>
        /// <b>Development Concerns:</b><br/>
        /// Use Pretty Case, so that Key can be used
        /// as a <c>Name</c> - lowercase if/as needed 
        /// at point of use.
        /// </remarks>
        public const string Key = "KW_TEMPLATE";

        /// <summary>
        /// The unique key of the Schema for this Logical Module.
        /// <para>
        /// By default, matches the <see cref="Key"/>
        /// </para>
        /// </summary>
        public const string DbSchemaKey = Key;

        /// <summary>
        /// The unique key of the Namespace used when developing APIs 
        /// (see OData EDM registration).
        /// <para>
        /// By default, matches the <see cref="Key"/>
        /// </para>
        /// </summary>
        public const string APINamespace = Key;

        /// <summary>
        /// The name of the default App ConnectionString.
        /// <para>
        /// By default, reuses the 
        /// App-wide 
        /// Default Connection String.
        /// </para>
        /// </summary>
        public const string DbConnectionStringName =
            AppConstants.DbConnectionStringName;

    }
}
