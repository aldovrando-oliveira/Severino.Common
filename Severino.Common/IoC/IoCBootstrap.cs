using System;
using LightInject;

namespace Severino.Common.IoC
{
    /// <summary>
    /// Classe static para auxiliar o uso de Injeção de dependência
    /// </summary>
    public static class IoCBootstrap
    {
        private static IServiceContainer _container;

        /// <summary>
        /// Retorna a instância do container configurado
        /// </summary>
        /// <returns></returns>
        public static IServiceContainer GetConfiguredContainer() => _container;

        /// <summary>
        /// Configura o container utilizando um callback
        /// </summary>
        /// <param name="action">Callback para registrar os objetos no container</param>
        /// <exception cref="ArgumentNullException">Ocorre quando o argumento 'action' está nulo</exception>
        public static void Setup(Action<IServiceContainer> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            _container = new ServiceContainer();
            action.Invoke((ServiceContainer)_container);
        }

        /// <summary>
        /// Retorna uma instância do tipo informado
        /// </summary>
        /// <returns></returns>
        public static T Resolve<T>() => GetConfiguredContainer().GetInstance<T>();
    }
}