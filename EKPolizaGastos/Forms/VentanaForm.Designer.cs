namespace EKPolizaGastos.Forms
{
    partial class VentanaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaForm));
            this.cmbTipoFactura = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbEmpresa = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbMes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbAno = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnImportExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnDiot = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnComenzar = new DevComponents.DotNetBar.ButtonX();
            this.btnCargar = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // cmbTipoFactura
            // 
            this.cmbTipoFactura.DisplayMember = "Text";
            this.cmbTipoFactura.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipoFactura.FormattingEnabled = true;
            this.cmbTipoFactura.ItemHeight = 14;
            this.cmbTipoFactura.Location = new System.Drawing.Point(138, 51);
            this.cmbTipoFactura.Name = "cmbTipoFactura";
            this.cmbTipoFactura.Size = new System.Drawing.Size(137, 20);
            this.cmbTipoFactura.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTipoFactura.TabIndex = 0;
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DisplayMember = "Text";
            this.cmbEmpresa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.ItemHeight = 14;
            this.cmbEmpresa.Location = new System.Drawing.Point(65, 129);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(282, 20);
            this.cmbEmpresa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbEmpresa.TabIndex = 1;
            this.cmbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            this.cmbEmpresa.SelectedValueChanged += new System.EventHandler(this.cmbEmpresa_SelectedValueChanged);
            // 
            // cmbMes
            // 
            this.cmbMes.DisplayMember = "Text";
            this.cmbMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.ItemHeight = 14;
            this.cmbMes.Location = new System.Drawing.Point(143, 274);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(127, 20);
            this.cmbMes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbMes.TabIndex = 4;
            // 
            // cmbAno
            // 
            this.cmbAno.DisplayMember = "Text";
            this.cmbAno.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAno.FormattingEnabled = true;
            this.cmbAno.ItemHeight = 14;
            this.cmbAno.Location = new System.Drawing.Point(149, 197);
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.Size = new System.Drawing.Size(115, 20);
            this.cmbAno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbAno.TabIndex = 3;
            this.cmbAno.SelectedIndexChanged += new System.EventHandler(this.cmbAno_SelectedIndexChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(123, 24);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(167, 23);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "Seleccione Tipo de Factura";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(138, 100);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(136, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "Seleccione Empresa";
            this.labelX2.Click += new System.EventHandler(this.labelX2_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(162, 245);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(89, 23);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "Seleccione Mes";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(164, 168);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(85, 23);
            this.labelX4.TabIndex = 8;
            this.labelX4.Text = "Seleccione Año";
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImportExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImportExcel.Image = global::EKPolizaGastos.Properties.Resources.excel;
            this.btnImportExcel.ImageFixedSize = new System.Drawing.Size(36, 36);
            this.btnImportExcel.Location = new System.Drawing.Point(18, 348);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(115, 44);
            this.btnImportExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImportExcel.TabIndex = 11;
            this.btnImportExcel.Text = "Importar Ejercicio";
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnDiot
            // 
            this.btnDiot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDiot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDiot.Image = global::EKPolizaGastos.Properties.Resources.New_Database;
            this.btnDiot.ImageFixedSize = new System.Drawing.Size(36, 36);
            this.btnDiot.Location = new System.Drawing.Point(272, 348);
            this.btnDiot.Name = "btnDiot";
            this.btnDiot.Size = new System.Drawing.Size(115, 44);
            this.btnDiot.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDiot.TabIndex = 10;
            this.btnDiot.Text = "DIOT";
            this.btnDiot.Click += new System.EventHandler(this.btnDiot_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Image = global::EKPolizaGastos.Properties.Resources.cerrar;
            this.btnClose.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnClose.Location = new System.Drawing.Point(340, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 38);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 9;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnComenzar
            // 
            this.btnComenzar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnComenzar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnComenzar.Image = global::EKPolizaGastos.Properties.Resources.Poliza_de__Servicio;
            this.btnComenzar.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnComenzar.Location = new System.Drawing.Point(147, 348);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(115, 44);
            this.btnComenzar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnComenzar.TabIndex = 5;
            this.btnComenzar.Text = "Polizas";
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCargar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCargar.Image = global::EKPolizaGastos.Properties.Resources._256px_Database_svg;
            this.btnCargar.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnCargar.Location = new System.Drawing.Point(36, 51);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(27, 19);
            this.btnCargar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCargar.TabIndex = 2;
            this.btnCargar.Text = "Cargar Ejercicios";
            this.btnCargar.Visible = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // VentanaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 423);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.btnDiot);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnComenzar);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.cmbAno);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.cmbEmpresa);
            this.Controls.Add(this.cmbTipoFactura);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(399, 423);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(399, 423);
            this.Name = "VentanaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione de Tipo de Polizas";
            this.Load += new System.EventHandler(this.VentanaForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbTipoFactura;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbEmpresa;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbMes;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbAno;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnCargar;
        private DevComponents.DotNetBar.ButtonX btnComenzar;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnDiot;
        private DevComponents.DotNetBar.ButtonX btnImportExcel;
    }
}