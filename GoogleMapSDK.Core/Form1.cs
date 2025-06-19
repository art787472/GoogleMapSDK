using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using GMap.NET;
//using GMap.NET.MapProviders;
using GoogleMapSDK.Core.Contract;

namespace GoogleMapSDK.Core
{
    public partial class Form1 : Form
    {
        public Form1(IAutoCompleteTextBoxView autoCompleteTextBox)
        {
            InitializeComponent();

            this.Controls.Add((Control)autoCompleteTextBox);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var TaipeiStation = new PointLatLng(25.0475613, 121.5173399);

            //var instance = GoogleMapProvider.Instance;
            //this.gMap1.MapProvider = instance;
            //GoogleMapProvider.Language = LanguageType.ChineseTraditional;
            //GMaps.Instance.Mode = AccessMode.ServerAndCache;
            //this.gMap1.Position = TaipeiStation;
            //this.gMap1.MinZoom = 10;
            //this.gMap1.MaxZoom = 20;
            //this.gMap1.Zoom = 16;
            //this.gMap1.DragButton = MouseButtons.Left;
            //this.gMap1.MouseWheelZoomEnabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
