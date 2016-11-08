using System.Web.Mvc;
using JET.Services.Implementations.Logger;
using JET.Services.Interfaces.Logger;
using JET.UnityDependency;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace JET.Web
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            UnityDependencyContainer.GetCurrent().RegisterType(typeof(ILoggerService<>), typeof(LoggerService<>));
        }
    }
}