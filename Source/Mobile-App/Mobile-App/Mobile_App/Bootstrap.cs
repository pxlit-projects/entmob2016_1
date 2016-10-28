using Autofac;
using JoesBurgerStore.Contracts;
using JoesBurgerStore.Services;
using Mobile_App.ViewModel;
using Xamarin.Forms;

namespace JoesBurgerStore
{
    public class Bootstrap
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        protected virtual void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>()
                .SingleInstance();
            builder.RegisterType<ConnectSensorViewModel>().SingleInstance();
            builder.RegisterType<NavigationService>()
                .As<INavigationService>()
                .SingleInstance();
            builder.RegisterType<HomeViewModel>().SingleInstance();
        }
    }
}
