using Autofac;
using System.Reflection;
using Achitecture.Domain.Common.InjectionAttribute;

namespace Achitecture.Infrastructure.AutoDependencyInjection
{
    public static class ConfigDependencyInjectionExtension
    {
        public static void RegisterDIConteiner(this ContainerBuilder builder, string projectCommonName)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains(projectCommonName)).ToList();
            foreach (var assembly in assemblies)
            {
                #region auto register with Transient
                builder.RegisterAssemblyTypes(assembly)
                    .Where(obj => obj.GetCustomAttribute<TransientDependencyAttribute>() != null)
                    .AsImplementedInterfaces()
                    .InstancePerDependency();

                builder.RegisterAssemblyTypes(assembly)
                    .Where(obj =>
                        obj.FullName.EndsWith("TransientRepo")
                        || obj.FullName.EndsWith("TransientRepository")
                        || obj.FullName.EndsWith("TransientService")
                        || obj.FullName.EndsWith("TransientBusiness")
                        || obj.FullName.EndsWith("Repo")
                        || obj.FullName.EndsWith("Repository")
                        || obj.FullName.EndsWith("Service")
                        || obj.FullName.EndsWith("Business"))
                    .AsImplementedInterfaces()
                    .InstancePerDependency();
                #endregion

                #region auto register with Scoped
                builder.RegisterAssemblyTypes(assembly)
                    .Where(obj => obj.GetCustomAttribute<ScopedDependencyAttribute>() != null)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(assembly)
                     .Where(obj =>
                         obj.FullName.EndsWith("ScopedRepo")
                         || obj.FullName.EndsWith("ScopedRepository")
                         || obj.FullName.EndsWith("ScopedService")
                         || obj.FullName.EndsWith("ScopedBusiness"))
                     .AsImplementedInterfaces()
                     .InstancePerLifetimeScope();
                #endregion

                #region auto register with Singleton
                builder.RegisterAssemblyTypes(assembly)
                    .Where(obj => obj.GetCustomAttribute<SingletonDependencyAttribute>() != null)
                    .AsImplementedInterfaces()
                    .SingleInstance();

                builder.RegisterAssemblyTypes(assembly)
                    .Where(obj =>
                        obj.FullName.EndsWith("SingletonRepo")
                        || obj.FullName.EndsWith("SingletonRepository")
                        || obj.FullName.EndsWith("SingletonService")
                        || obj.FullName.EndsWith("SingletonBusiness"))
                    .AsImplementedInterfaces()
                    .SingleInstance();
                #endregion
            }
        }
    }
}
