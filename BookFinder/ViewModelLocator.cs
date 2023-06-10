using BookFinder.Servers;
using BookFinder.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder
{
    public class ViewModelLocator
    {
        public IServiceProvider serviceProvider { get; private set; }

        public ViewModelLocator()
        {
            serviceProvider = ConfigureServices();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<WindowMainViewModel>();
            services.AddSingleton<MemberCenterViewModel>();


            serviceProvider = services.BuildServiceProvider();
            Ioc.Default.ConfigureServices(serviceProvider);
            
            return serviceProvider;
        }

        public MainWindowViewModel MainWindowDataContext  => Ioc.Default.GetService<MainWindowViewModel>();

        public WindowMainViewModel WindowMainDataContext => Ioc.Default.GetService<WindowMainViewModel>();

        public MemberCenterViewModel MemberCenterDataContext => Ioc.Default.GetService<MemberCenterViewModel>();
    }
}
