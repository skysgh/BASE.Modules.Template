using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Sys.Shared.Domains.Services.Implementations;

namespace App.Modules.KWMODULENAME.Domain.Domains.Examples.Services.Implementations
{
    /// <summary>
    /// Implementation of <see cref="IExampleDomainService"/>.
    /// </summary>
    /// <remarks>
    /// Notice how the service inherits from the
    /// common base class (<see cref="DomainServiceBase"/>),
    /// while also implementing the contract interface.
    /// </remarks>
    public class ExampleDomainService: DomainServiceBase, IExampleDomainService
    {
        // In 95% of cases
        // an application service
        // only needs to invoke a repository
        // to get records,
        // when it needs to do actual logic
        // don't do it in the Application Service
        // hand the entities off to a specialised
        // Domain Service to do that work.
        //
        // But when it does need a Service
        // to encapsulate domain entity 

    }
}
