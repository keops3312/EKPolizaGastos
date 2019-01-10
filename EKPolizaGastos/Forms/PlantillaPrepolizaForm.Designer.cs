namespace EKPolizaGastos.Forms
{
    partial class PlantillaPrepolizaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.lblCantidad = new DevComponents.DotNetBar.LabelX();
            this.lblAno = new DevComponents.DotNetBar.LabelX();
            this.lblMes = new DevComponents.DotNetBar.LabelX();
            this.lblEmpresa = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.styleManagerAmbient1 = new DevComponents.DotNetBar.StyleManagerAmbient(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.txtTipo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtNumero = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFecha = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtConcepto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.poliza = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.cmbLocalidades = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtDepto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.txtDebe = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtHaber = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poliza)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewX1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(198)))), ((int)(((byte)(217)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(595, 46);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewX1.Size = new System.Drawing.Size(340, 145);
            this.dataGridViewX1.TabIndex = 6;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(662, 206);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(71, 18);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 7;
            this.buttonX1.Text = "Cargar CFDIs";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // lblCantidad
            // 
            // 
            // 
            // 
            this.lblCantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCantidad.Location = new System.Drawing.Point(33, 42);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(431, 23);
            this.lblCantidad.TabIndex = 15;
            this.lblCantidad.Text = "Numero de Polizas por Generar";
            // 
            // lblAno
            // 
            // 
            // 
            // 
            this.lblAno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAno.Location = new System.Drawing.Point(713, 13);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(220, 23);
            this.lblAno.TabIndex = 16;
            this.lblAno.Text = "Año";
            // 
            // lblMes
            // 
            // 
            // 
            // 
            this.lblMes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMes.Location = new System.Drawing.Point(467, 13);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(220, 23);
            this.lblMes.TabIndex = 17;
            this.lblMes.Text = "Mes";
            // 
            // lblEmpresa
            // 
            // 
            // 
            // 
            this.lblEmpresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEmpresa.Location = new System.Drawing.Point(33, 13);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(417, 23);
            this.lblEmpresa.TabIndex = 18;
            this.lblEmpresa.Text = "Empresa";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(34, 71);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(297, 23);
            this.labelX6.TabIndex = 19;
            this.labelX6.Text = "Generacion de Poliza";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(713, 626);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(220, 38);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 21;
            this.buttonX2.Text = "Pre-Poliza";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // txtTipo
            // 
            // 
            // 
            // 
            this.txtTipo.Border.Class = "TextBoxBorder";
            this.txtTipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTipo.Location = new System.Drawing.Point(115, 113);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.PreventEnterBeep = true;
            this.txtTipo.Size = new System.Drawing.Size(100, 20);
            this.txtTipo.TabIndex = 22;
            this.txtTipo.Text = "Eg";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(34, 110);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(45, 23);
            this.labelX1.TabIndex = 23;
            this.labelX1.Text = "Tipo:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(221, 110);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(63, 23);
            this.labelX3.TabIndex = 24;
            this.labelX3.Text = "Numero:";
            // 
            // txtNumero
            // 
            // 
            // 
            // 
            this.txtNumero.Border.Class = "TextBoxBorder";
            this.txtNumero.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumero.Location = new System.Drawing.Point(290, 113);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.PreventEnterBeep = true;
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 25;
            this.txtNumero.Text = "99";
            // 
            // txtFecha
            // 
            // 
            // 
            // 
            this.txtFecha.Border.Class = "TextBoxBorder";
            this.txtFecha.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFecha.Location = new System.Drawing.Point(479, 113);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.PreventEnterBeep = true;
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 26;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(409, 110);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(64, 23);
            this.labelX4.TabIndex = 27;
            this.labelX4.Text = "Fecha:";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(34, 139);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 28;
            this.labelX5.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.AllowDrop = true;
            // 
            // 
            // 
            this.txtConcepto.Border.Class = "TextBoxBorder";
            this.txtConcepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtConcepto.Location = new System.Drawing.Point(115, 139);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.PreventEnterBeep = true;
            this.txtConcepto.Size = new System.Drawing.Size(464, 52);
            this.txtConcepto.TabIndex = 29;
            // 
            // poliza
            // 
            this.poliza.AllowUserToAddRows = false;
            this.poliza.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.poliza.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.poliza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.poliza.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cuenta,
            this.Concepto,
            this.Debe,
            this.Haber});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.poliza.DefaultCellStyle = dataGridViewCellStyle23;
            this.poliza.EnableHeadersVisualStyles = false;
            this.poliza.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(198)))), ((int)(((byte)(217)))));
            this.poliza.Location = new System.Drawing.Point(39, 283);
            this.poliza.Name = "poliza";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.poliza.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.poliza.Size = new System.Drawing.Size(894, 293);
            this.poliza.TabIndex = 30;
            // 
            // Cuenta
            // 
            this.Cuenta.HeaderText = "No.Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Concepto
            // 
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            // 
            // Debe
            // 
            this.Debe.HeaderText = "Debe";
            this.Debe.Name = "Debe";
            // 
            // Haber
            // 
            this.Haber.HeaderText = "Haber";
            this.Haber.Name = "Haber";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(770, 206);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(71, 17);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 31;
            this.buttonX3.Text = "Avanzar";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // cmbLocalidades
            // 
            this.cmbLocalidades.DisplayMember = "Text";
            this.cmbLocalidades.FormattingEnabled = true;
            this.cmbLocalidades.ItemHeight = 13;
            this.cmbLocalidades.Location = new System.Drawing.Point(33, 242);
            this.cmbLocalidades.Name = "cmbLocalidades";
            this.cmbLocalidades.Size = new System.Drawing.Size(261, 21);
            this.cmbLocalidades.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbLocalidades.TabIndex = 32;
            this.cmbLocalidades.SelectedIndexChanged += new System.EventHandler(this.cmbLocalidades_SelectedIndexChanged);
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(34, 213);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(260, 23);
            this.labelX7.TabIndex = 33;
            this.labelX7.Text = "Para cambiar las cuentas Seleccione la localidad:";
            // 
            // txtDepto
            // 
            // 
            // 
            // 
            this.txtDepto.Border.Class = "TextBoxBorder";
            this.txtDepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDepto.Location = new System.Drawing.Point(322, 242);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.PreventEnterBeep = true;
            this.txtDepto.Size = new System.Drawing.Size(199, 20);
            this.txtDepto.TabIndex = 34;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(322, 198);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(199, 38);
            this.labelX8.TabIndex = 35;
            this.labelX8.Text = "<b>Departamento</b>\r\n<br></br> \r\n<u>(Lo puede cambiar para Actualizar)</u>";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(440, 582);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(72, 23);
            this.labelX9.TabIndex = 36;
            this.labelX9.Text = "Totales:";
            // 
            // txtDebe
            // 
            // 
            // 
            // 
            this.txtDebe.Border.Class = "TextBoxBorder";
            this.txtDebe.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebe.Location = new System.Drawing.Point(529, 585);
            this.txtDebe.Name = "txtDebe";
            this.txtDebe.PreventEnterBeep = true;
            this.txtDebe.Size = new System.Drawing.Size(183, 20);
            this.txtDebe.TabIndex = 37;
            // 
            // txtHaber
            // 
            // 
            // 
            // 
            this.txtHaber.Border.Class = "TextBoxBorder";
            this.txtHaber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHaber.Location = new System.Drawing.Point(750, 586);
            this.txtHaber.Name = "txtHaber";
            this.txtHaber.PreventEnterBeep = true;
            this.txtHaber.Size = new System.Drawing.Size(183, 20);
            this.txtHaber.TabIndex = 38;
            // 
            // PlantillaPrepolizaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 729);
            this.Controls.Add(this.txtHaber);
            this.Controls.Add(this.txtDebe);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.cmbLocalidades);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.poliza);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "PlantillaPrepolizaForm";
            this.Text = "PlantillaPrepolizaForm";
            this.Load += new System.EventHandler(this.PlantillaPrepolizaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poliza)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX lblCantidad;
        private DevComponents.DotNetBar.LabelX lblAno;
        private DevComponents.DotNetBar.LabelX lblMes;
        private DevComponents.DotNetBar.LabelX lblEmpresa;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.StyleManagerAmbient styleManagerAmbient1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTipo;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNumero;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFecha;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtConcepto;
        private DevComponents.DotNetBar.Controls.DataGridViewX poliza;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbLocalidades;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDepto;
        private DevComponents.DotNetBar.LabelX labelX8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Haber;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDebe;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHaber;
    }
}