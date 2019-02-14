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
            this.cmbTipoFactura = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbEmpresa = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbMes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbAno = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnCargar = new DevComponents.DotNetBar.ButtonX();
            this.btnComenzar = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // cmbTipoFactura
            // 
            this.cmbTipoFactura.DisplayMember = "Text";
            this.cmbTipoFactura.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipoFactura.FormattingEnabled = true;
            this.cmbTipoFactura.ItemHeight = 14;
            this.cmbTipoFactura.Location = new System.Drawing.Point(91, 41);
            this.cmbTipoFactura.Name = "cmbTipoFactura";
            this.cmbTipoFactura.Size = new System.Drawing.Size(137, 20);
            this.cmbTipoFactura.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTipoFactura.TabIndex = 1;
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DisplayMember = "Text";
            this.cmbEmpresa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.ItemHeight = 14;
            this.cmbEmpresa.Location = new System.Drawing.Point(18, 129);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(282, 20);
            this.cmbEmpresa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbEmpresa.TabIndex = 2;
            this.cmbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            this.cmbEmpresa.SelectedValueChanged += new System.EventHandler(this.cmbEmpresa_SelectedValueChanged);
            // 
            // cmbMes
            // 
            this.cmbMes.DisplayMember = "Text";
            this.cmbMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.ItemHeight = 14;
            this.cmbMes.Location = new System.Drawing.Point(173, 298);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(127, 20);
            this.cmbMes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbMes.TabIndex = 3;
            // 
            // cmbAno
            // 
            this.cmbAno.DisplayMember = "Text";
            this.cmbAno.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAno.FormattingEnabled = true;
            this.cmbAno.ItemHeight = 14;
            this.cmbAno.Location = new System.Drawing.Point(18, 298);
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.Size = new System.Drawing.Size(115, 20);
            this.cmbAno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbAno.TabIndex = 4;
            this.cmbAno.SelectedIndexChanged += new System.EventHandler(this.cmbAno_SelectedIndexChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(76, 12);
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
            this.labelX2.Location = new System.Drawing.Point(91, 89);
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
            this.labelX3.Location = new System.Drawing.Point(190, 260);
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
            this.labelX4.Location = new System.Drawing.Point(34, 260);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(85, 23);
            this.labelX4.TabIndex = 8;
            this.labelX4.Text = "Seleccione Año";
            // 
            // btnCargar
            // 
            this.btnCargar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCargar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCargar.Location = new System.Drawing.Point(119, 185);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(81, 30);
            this.btnCargar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCargar.TabIndex = 9;
            this.btnCargar.Text = "Iniciar";
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnComenzar
            // 
            this.btnComenzar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnComenzar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnComenzar.Location = new System.Drawing.Point(119, 355);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(81, 32);
            this.btnComenzar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnComenzar.TabIndex = 10;
            this.btnComenzar.Text = "buttonX1";
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // VentanaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 429);
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
            this.Name = "VentanaForm";
            this.Text = "VentanaForm";
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
    }
}