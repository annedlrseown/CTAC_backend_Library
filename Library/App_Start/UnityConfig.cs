using System;
using Library.DataLayer;
using Library.Domain.Interfaces.DataLayer;
using Library.Domain.Interfaces.Services;
using Library.Services;
using Unity;

namespace Library
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<ITranslator, Translator>();
            container.RegisterType<IBookStorage, BookStorage>();
        }
    }
}