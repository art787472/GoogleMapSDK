using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using IOCDependencyInjection;

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
            var collection = new ServiceCollection();
            collection.RegisterMVP(Assembly.GetEntryAssembly());
            collection.AddSingleton<Form, Form1>();
            collection.AddWinFormUIKitRegistraction();

            var provider = collection.BuildProvider();
            var form = provider.GetService<Form>();
            Application.Run(form);
            
        }
    }
}
