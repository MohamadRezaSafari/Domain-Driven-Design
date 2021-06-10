using Framework.Core.AssemblyHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Framework.AssemblyHelper
{
    public class AssemblyDiscovery : IAssemblyDiscovery
    {
        private static List<Assembly> _loadedAssemblies = null;
        private readonly string _assemblySearchPattern;
        public AssemblyDiscovery(string assemblySearchPattern)
        {
            this._assemblySearchPattern = assemblySearchPattern;
            LoadAssemblies(assemblySearchPattern);
        }

        public IEnumerable<T> DiscoverInstances<T>(string searchNamespace)
        {
            var res = _loadedAssemblies
                    .Where(a => a.FullName.StartsWith(searchNamespace))
                    .SelectMany(a => a.GetTypes())
                    .Where(t => t.IsClass && !t.IsAbstract)
                    .Where(t => t.GetInterface(typeof(T).Name) != null)
                    .Select(Activator.CreateInstance)
                    .OfType<T>();
            return res;
        }

        public IEnumerable<Type> DiscoverTypes<TInterface>(string searchNamespace)
        {

            return _loadedAssemblies
                .Where(a => a.FullName.StartsWith(searchNamespace))
            .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
            .Where(t => t.GetInterface(typeof(TInterface).Name) != null)
            .Select(t => t);

        }

        public IEnumerable<Type> GetTypes(Type type)
        {
            var baseClassName = type.Name;

            return GetAllAssemblies().SelectMany(a => a.GetTypes()).Where(a =>
        a.BaseType != null && a.BaseType.Name == baseClassName && a.IsClass && !a.IsAbstract).ToList();
        }

        private IEnumerable<Assembly> GetAllAssemblies()
        {
            var result = _loadedAssemblies
                    .Where(a => a.FullName!.Contains(_assemblySearchPattern)).ToList();
            return result;
        }

        private void LoadAssemblies(string assemblySearchPattern)
        {
            if (_loadedAssemblies == null)
            {
                var directory = AppDomain.CurrentDomain.BaseDirectory;
                _loadedAssemblies = Directory.GetFiles(directory, assemblySearchPattern).Select(Assembly.LoadFrom)
                    .ToList();
            }
        }



        public IList<Assembly> GetAssemblies(Type HasType)
        {
            var BaseClassName = HasType.Name;

            var resault = GetAllAssemblies();
            return GetAllAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.BaseType != null && a.BaseType.Name == BaseClassName)
                .Select(a => a.Assembly)
                .ToList();
        }




        public IList<Type> GetClassByInterface(Type baseInterFace)
        {
            var baseClassName = baseInterFace.Name;

            var result = GetAllAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.GetInterfaces().Any(b => b.Name == baseClassName) && a.IsClass && !a.IsAbstract)
                .ToList();

            return result;
        }


        public IList<object> GetInstanceByInterface(Type baseInterFace)
        {
            var baseClassName = baseInterFace.Name;

            return GetAllAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.GetInterfaces().Any(b => b.Name == baseClassName))
                .Distinct()
                .Select(Activator.CreateInstance)
                .ToList();
        }
    }
}
