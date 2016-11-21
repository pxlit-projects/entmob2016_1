using Autofac;
using Mobile_App.ViewModel;
using Xamarin.Forms;

namespace Mobile_App

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
