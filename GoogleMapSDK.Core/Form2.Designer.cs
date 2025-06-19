namespace GoogleMapSDK.Core
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.googleMap1 = new GoogleMapSDK.Core.GoogleMapComponent.GMap.Control.GoogleMap();
            this.SuspendLayout();
            // 
            // googleMap1
            // 
            this.googleMap1.Bearing = 0F;
            this.googleMap1.CanDragMap = true;
            this.googleMap1.Dock = System.Windows.Forms.DockStyle.Right;
            this.googleMap1.EmptyTileColor = System.Drawing.Color.Navy;
            this.googleMap1.GrayScaleMode = false;
            this.googleMap1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.googleMap1.LevelsKeepInMemory = 5;
            this.googleMap1.Location = new System.Drawing.Point(293, 0);
            this.googleMap1.MarkersEnabled = true;
            this.googleMap1.MaxZoom = 20;
            this.googleMap1.MinZoom = 2;
            this.googleMap1.MouseWheelZoomEnabled = true;
            this.googleMap1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.googleMap1.Name = "googleMap1";
            this.googleMap1.NegativeMode = false;
            this.googleMap1.PolygonsEnabled = true;
            this.googleMap1.RetryLoadTile = 0;
            this.googleMap1.RoutesEnabled = true;
            this.googleMap1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.googleMap1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.googleMap1.ShowTileGridLines = false;
            this.googleMap1.Size = new System.Drawing.Size(507, 450);
            this.googleMap1.TabIndex = 1;
            this.googleMap1.Zoom = 10D;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.googleMap1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private GoogleMapComponent.GMap.Control.GoogleMap googleMap1;
    }
}