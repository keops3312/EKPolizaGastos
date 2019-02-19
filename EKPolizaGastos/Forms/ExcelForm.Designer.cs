namespace EKPolizaGastos.Forms
{
    partial class ExcelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelForm));
            this.swtBtn = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.lblLeyenda = new DevComponents.DotNetBar.LabelX();
            this.cmbEmpresa = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNameSheet = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnCarga = new DevComponents.DotNetBar.ButtonX();
            this.btnRegistrar = new DevComponents.DotNetBar.ButtonX();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.gridMuestra = new System.Windows.Forms.DataGridView();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.styleManagerAmbient1 = new DevComponents.DotNetBar.StyleManagerAmbient(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridMuestra)).BeginInit();
            this.SuspendLayout();
            // 
            // swtBtn
            // 
            // 
            // 
            // 
            this.swtBtn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.swtBtn.Location = new System.Drawing.Point(44, 84);
            this.swtBtn.Name = "swtBtn";
            this.swtBtn.OffText = "Emitidas";
            this.swtBtn.OnText = "Recibidas";
            this.swtBtn.Size = new System.Drawing.Size(143, 35);
            this.swtBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.swtBtn.TabIndex = 24;
            this.swtBtn.Value = true;
            this.swtBtn.ValueObject = "Y";
            this.swtBtn.ValueChanged += new System.EventHandler(this.swtBtn_ValueChanged);
            // 
            // lblLeyenda
            // 
            // 
            // 
            // 
            this.lblLeyenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLeyenda.Location = new System.Drawing.Point(12, 12);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(810, 23);
            this.lblLeyenda.TabIndex = 23;
            this.lblLeyenda.Text = "Nueva Forma de Carga de XML SAT";
            this.lblLeyenda.Click += new System.EventHandler(this.lblLeyenda_Click);
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DisplayMember = "Text";
            this.cmbEmpresa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.ItemHeight = 14;
            this.cmbEmpresa.Location = new System.Drawing.Point(14, 186);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(203, 20);
            this.cmbEmpresa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbEmpresa.TabIndex = 22;
            // 
            // txtPath
            // 
            // 
            // 
            // 
            this.txtPath.Border.Class = "TextBoxBorder";
            this.txtPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPath.Location = new System.Drawing.Point(14, 285);
            this.txtPath.Name = "txtPath";
            this.txtPath.PreventEnterBeep = true;
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(203, 20);
            this.txtPath.TabIndex = 21;
            // 
            // txtNameSheet
            // 
            // 
            // 
            // 
            this.txtNameSheet.Border.Class = "TextBoxBorder";
            this.txtNameSheet.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNameSheet.Location = new System.Drawing.Point(15, 360);
            this.txtNameSheet.Name = "txtNameSheet";
            this.txtNameSheet.PreventEnterBeep = true;
            this.txtNameSheet.Size = new System.Drawing.Size(200, 20);
            this.txtNameSheet.TabIndex = 20;
            this.txtNameSheet.Text = "XML";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(29, 150);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(173, 21);
            this.labelX2.TabIndex = 19;
            this.labelX2.Text = "Seleccione la Empresa";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 55);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(202, 23);
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "Seleccione Tipos de XML a Registrar:";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnCarga
            // 
            this.btnCarga.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCarga.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCarga.Location = new System.Drawing.Point(39, 242);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(152, 37);
            this.btnCarga.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCarga.TabIndex = 17;
            this.btnCarga.Text = "Cargar Excel";
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegistrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRegistrar.Location = new System.Drawing.Point(41, 400);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(149, 43);
            this.btnRegistrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnRegistrar.TabIndex = 16;
            this.btnRegistrar.Text = "Registrar en Base de Datos";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(12, 481);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(10, 13);
            this.lblCantidad.TabIndex = 15;
            this.lblCantidad.Text = "-";
            // 
            // gridMuestra
            // 
            this.gridMuestra.AllowUserToAddRows = false;
            this.gridMuestra.AllowUserToDeleteRows = false;
            this.gridMuestra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMuestra.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(198)))), ((int)(((byte)(213)))));
            this.gridMuestra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMuestra.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.gridMuestra.Location = new System.Drawing.Point(242, 55);
            this.gridMuestra.Name = "gridMuestra";
            this.gridMuestra.ReadOnly = true;
            this.gridMuestra.Size = new System.Drawing.Size(753, 388);
            this.gridMuestra.TabIndex = 14;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(15, 331);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(200, 23);
            this.labelX3.TabIndex = 25;
            this.labelX3.Text = "Nombre de la Hoja:";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // ExcelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 516);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.swtBtn);
            this.Controls.Add(this.lblLeyenda);
            this.Controls.Add(this.cmbEmpresa);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtNameSheet);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.gridMuestra);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelForm";
            this.Text = "Importar XML de Excel";
            this.Load += new System.EventHandler(this.ExcelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMuestra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.SwitchButton swtBtn;
        private DevComponents.DotNetBar.LabelX lblLeyenda;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbEmpresa;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPath;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNameSheet;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnCarga;
        private DevComponents.DotNetBar.ButtonX btnRegistrar;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.DataGridView gridMuestra;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.StyleManagerAmbient styleManagerAmbient1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}