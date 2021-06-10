using System;
using Framework.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.DependencyInjection
{
    public class DiContainer : IDiContainer
    {
        private readonly IServiceProvider _serviceProvider;

        public DiContainer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T Resolve<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
