using System.Linq;
using Framework.ApplicationService;
using Framework.AssemblyHelper;
using Framework.Core.ApplicationService;
using Framework.Core.AssemblyHelper;
using Framework.Core.DependencyInjection;
using Framework.Core.Domain;
using Framework.Core.Facade;
using Framework.Core.Persistence;
using Framework.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.DependencyInjection
{
    public abstract class RegistrarBase<TRegister> : IRegistrar
    {
        private IServiceCollection _serviceCollection;
        private IAssemblyDiscovery _assemblyDiscovery;
        private readonly string _namespace;

        protected RegistrarBase()
        {
            var nameSpaceSpell = typeof(TRegister).Namespace?.Split('.');
            _namespace = nameSpaceSpell?[0] + "." + nameSpaceSpell?[1];
        }

        public void Register(IServiceCollection servicesCollection, IAssemblyDiscovery assemblyDiscovery)
        {
            _serviceCollection = servicesCollection;
            _assemblyDiscovery = assemblyDiscovery;
            RegisterFramework();
            RegisterTransient<IDomainService>();
            RegisterTransient<IEntityMapping>();
            RegisterTransient<IRepository>();
            RegisterTransient<IHandler>();
            RegisterTransient<IQueryFacade>();
            RegisterTransient<ICommandFacade>();
            RegisterTransient<IACLService>();            
        }

        private void RegisterFramework()
        {
            _serviceCollection.AddScoped<IAssemblyDiscovery, AssemblyDiscovery>(a => new AssemblyDiscovery("HR*.dll"));
            _serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            _serviceCollection.AddScoped<IDiContainer, DiContainer>();
            _serviceCollection.AddScoped<ICommandBus, CommandBus>();
            //_serviceCollection.AddTransient(typeof(IEntityIdGenerator<>), typeof(EntityIdGenerator<>));
        }

        private void RegisterTransient<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach (var type in types)
            {
                var baseInterface = type.GetInterfaces()
                    .First(a => a.Name != typeof(TRegisterBaseType).Name);
                _serviceCollection.AddTransient(baseInterface, type);
            }
        }
        private void RegisterScope<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach (var type in types)
            {
                var baseInterface = type.GetInterfaces()
                    .First(a => a.Name != typeof(TRegisterBaseType).Name);
                _serviceCollection.AddScoped(baseInterface, type);
            }
        }
        private void RegisterSingleton<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach (var type in types)
            {
                var baseInterface = type.GetInterfaces()
                    .First(a => a.Name != typeof(TRegisterBaseType).Name);
                _serviceCollection.AddSingleton(baseInterface, type);
            }
        }
    }
}