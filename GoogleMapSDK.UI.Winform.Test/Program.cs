using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMapSDK.API;
using GoogleMapSDK.Contract.API;
using IOCDependencyInjection;
using Microsoft.Extensions.Configuration;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;
using GoogleMapSDK.Core;

namespace GoogleMapSDK.UI.Winform.Test
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IConfiguration configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

            var collection = new ServiceCollection();
            collection.AddGoogleMapSDKRegistration(configuration);
            collection.AddWinFormUIKitRegistraction(configuration);
            collection.AddAPIRegistration(configuration);
            collection.AddSingleton<Form, Form1>();
            
            var provider = collection.BuildProvider();
           
            var form = provider.GetService<Form>();

            Application.Run(form);
            
        }
    }
}
