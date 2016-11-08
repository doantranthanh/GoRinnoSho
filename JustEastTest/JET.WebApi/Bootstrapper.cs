using System.Web.Mvc;
using JET.Services.Implementations.Helpers;
using JET.Services.Implementations.Logger;
using JET.Services.Implementations.WebClient;
using JET.Services.Implementations.WebStore;
using JET.Services.Interfaces.Helper;
using JET.Services.Interfaces.Logger;
using JET.Services.Interfaces.WebClient;
using JET.Services.Interfaces.WebStore;
using JET.UnityDependency;
using Microsoft.Practices.Unity;
using Unity.Mvc4;


namespace JET.WebApi
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
            var container = UnityDependencyContainer.GetCurrent().Container;

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            UnityDependencyContainer.GetCurrent().Register<IHttpClientService, HttpClientService>(true);
            UnityDependencyContainer.GetCurrent().Register<ICacheHelper, CacheHelper>();
            UnityDependencyContainer.GetCurrent().Register<IRestaurantHelpers, RestaurantHelper>();
            UnityDependencyContainer.GetCurrent().RegisterType(typeof(ILoggerService<>), typeof(LoggerService<>));
        }
    }
}