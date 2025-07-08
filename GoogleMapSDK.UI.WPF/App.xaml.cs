using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GoogleMapSDK.API;
using IOCDependencyInjection;
using Microsoft.Extensions.Configuration;

namespace GoogleMapSDK.UI.WPF
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ServiceCollection collection = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            collection.AddAPIRegistration(configuration);
            collection.AddWPFIKitRegistraction(configuration);
            collection.AddSingleton<Window, MainWindow>();

            ServiceProvider provider = collection.BuildProvider();
            Window window = provider.GetService<Window>();

            window.Show();


        }
    }
}
