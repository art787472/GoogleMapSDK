using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMapSDK.Core.Components.HistoryAutoComplete;

using GoogleMapSDK.Core.Components.PlaceAutoComplete;
using GoogleMapSDK.Core.Contract;
using IOCDependencyInjection;

namespace GoogleMapSDK.Core
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
            ServiceCollection collection = new ServiceCollection();
            collection.RegisterMVP(Assembly.GetExecutingAssembly());
            collection.AddSingleton<Form, Form2>();
            collection.AddTransient<AutoCompleteTextBoxBase, PlaceAutoComplelteTextBox>();
            collection.AddTransient<AutoCompleteTextBoxBase, HistoryAutoCompleteTextBox>();
            var provider = collection.BuildProvider();
            var form = provider.GetService<Form>();
            Application.Run(form);
        }
    }
}
