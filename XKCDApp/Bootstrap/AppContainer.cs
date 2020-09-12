using System;
using Autofac;
using XKCDApp.Services;
using XKCDApp.ViewModels;

namespace XKCDApp.Bootstrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public AppContainer()
        {
            RegisterTypes();
        }

        private void RegisterTypes()
        {
            var containerBuiler = new ContainerBuilder();

            containerBuiler.RegisterType<HttpComicService>().As<IComicService>().SingleInstance();

            containerBuiler.RegisterType<ComicViewModel>().SingleInstance();

            _container = containerBuiler.Build();
        }

        public T Resolve<T>() => _container.Resolve<T>();

        public object Resolve(Type type) => _container.Resolve(type);
    }
}
