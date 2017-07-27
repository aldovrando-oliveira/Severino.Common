using System;
using LightInject;

namespace Severino.Common.IoC
{
    /// <summary>
    /// Classe que realiza a configuração
    /// </summary>
    public static class IoCBootstrap
    {
        private static IServiceContainer _container;

        public static IServiceContainer GetConfiguredContainer() => _container;

        public static void Setup(Action<IServiceContainer> action)
        {
            _container = new ServiceContainer();
            action.Invoke((ServiceContainer)_container);
        }

        public static T Resolve<T>() => GetConfiguredContainer().GetInstance<T>();
    }
}