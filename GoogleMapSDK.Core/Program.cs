﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

using static GoogleMapSDK.Contract.ComponentContract.AutoCompleteContract;
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
            
            
            
            //Application.Run(form);
        }
    }
}
