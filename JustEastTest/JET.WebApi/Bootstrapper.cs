﻿using System.Web.Mvc;
using JET.Services.Implementations.WebClient;
using JET.Services.Interfaces.WebClient;
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
        }
    }
}