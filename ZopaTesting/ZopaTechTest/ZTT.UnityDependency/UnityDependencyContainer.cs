using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace ZTT.UnityDependency
{
    public class UnityDependencyContainer : IDisposable
    {
        private static UnityDependencyContainer _instance;
        private static readonly object Sync = new object();
        private IUnityContainer _container = new UnityContainer();

        private UnityDependencyContainer() { }

        public void Clear()
        {
            Dispose();
        }

        public IUnityContainer Container
        {
            get { return _container; }
        }

        public static UnityDependencyContainer GetCurrent()
        {
            if (_instance == null || _instance.Container == null)
            {
                lock (Sync)
                {
                    _instance = new UnityDependencyContainer();
                }
            }

            return _instance;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.ResolveAll<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public void Register<TFrom, TTo>(bool isTransient = false) where TTo : TFrom
        {
            if (isTransient)
            {
                _container.RegisterType<TFrom, TTo>();
            }
            else
            {
                using (var containerControlledLifetimeManager = new ContainerControlledLifetimeManager())
                {
                    _container.RegisterType<TFrom, TTo>(containerControlledLifetimeManager);
                }
            }
        }

        public void RegisterType(Type tFrom, Type tTo)
        {
            _container.RegisterType(tFrom, tTo);
        }

        public void Register<T>(T intance) where T : class
        {
            _container.RegisterInstance<T>(intance);
        }

        public void Dispose()
        {
            _container.Dispose();
            _container = null;
        }
    }
}
