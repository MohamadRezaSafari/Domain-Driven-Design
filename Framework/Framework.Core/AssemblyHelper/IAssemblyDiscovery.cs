using System;
using System.Collections.Generic;

namespace Framework.Core.AssemblyHelper
{
    public interface IAssemblyDiscovery
    {
        IEnumerable<T> DiscoverInstances<T>(string searchNamespace);
        IEnumerable<Type> DiscoverTypes<TInterface>(string searchNamespace);

    }
}
