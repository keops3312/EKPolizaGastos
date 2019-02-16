namespace EKPolizaGastos.Forms
{
    partial class OpcionVersionForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpcionVersionForm));
            this.metroTilePanel1 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.metroTileItemVersionUno = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItemVersionDos = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItemExit = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.SuspendLayout();
            // 
            // metroTilePanel1
            // 
            // 
            // 
            // 
            this.metroTilePanel1.BackgroundStyle.Class = "MetroTilePanel";
            this.metroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel1.ContainerControlProcessDialogKey = true;
            this.metroTilePanel1.DragDropSupport = true;
            this.metroTilePanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel1.Location = new System.Drawing.Point(12, 12);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.ReserveLeftSpace = false;
            this.metroTilePanel1.Size = new System.Drawing.Size(626, 208);
            this.metroTilePanel1.TabIndex = 0;
            this.metroTilePanel1.Text = "metroTilePanel1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.metroTileItemVersionUno,
            this.metroTileItemVersionDos,
            this.metroTileItemExit});
            // 
            // 
            // 
            this.itemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.Class = "MetroTileGroupTitle";
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.TitleStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemContainer1.TitleText = "Seleccione version para trabajar";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // metroTileItemVersionUno
            // 
            this.metroTileItemVersionUno.Image = global::EKPolizaGastos.Properties.Resources.version_uno_fw;
            this.metroTileItemVersionUno.Name = "metroTileItemVersionUno";
            this.metroTileItemVersionUno.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItemVersionUno.Text = "Version 1.0";
            this.metroTileItemVersionUno.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure;
            // 
            // 
            // 
            this.metroTileItemVersionUno.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItemVersionUno.TileStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.metroTileItemVersionUno.TitleText = "Genera polizas(con productos) y \r\nDIOT Basico (IVA)";
            this.metroTileItemVersionUno.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileItemVersionUno.Click += new System.EventHandler(this.metroTileItemVersionUno_Click);
            // 
            // metroTileItemVersionDos
            // 
            this.metroTileItemVersionDos.Image = global::EKPolizaGastos.Properties.Resources.version_dos_fw;
            this.metroTileItemVersionDos.Name = "metroTileItemVersionDos";
            this.metroTileItemVersionDos.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItemVersionDos.Text = "Version 2.0";
            this.metroTileItemVersionDos.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue;
            // 
            // 
            // 
            this.metroTileItemVersionDos.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItemVersionDos.TileStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.metroTileItemVersionDos.TitleText = "Genera Polizas(C/Subtotal) de tipo E, I y\r\nNomina, Tambien DIOT Completa";
            this.metroTileItemVersionDos.Click += new System.EventHandler(this.metroTileItemVersionDos_Click);
            // 
            // metroTileItemExit
            // 
            this.metroTileItemExit.Image = global::EKPolizaGastos.Properties.Resources.cerrar_tres_fw;
            this.metroTileItemExit.Name = "metroTileItemExit";
            this.metroTileItemExit.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItemExit.Text = "Salir";
            this.metroTileItemExit.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItemExit.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItemExit.TileStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.metroTileItemExit.Click += new System.EventHandler(this.metroTileItemExit_Click);
            // 
            // OpcionVersionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 234);
            this.ControlBox = false;
            this.Controls.Add(this.metroTilePanel1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(666, 273);
            this.MinimumSize = new System.Drawing.Size(666, 273);
            this.Name = "OpcionVersionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Version para trabajar XML\'s";
            this.Load += new System.EventHandler(this.OpcionVersionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItemVersionUno;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItemVersionDos;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItemExit;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}