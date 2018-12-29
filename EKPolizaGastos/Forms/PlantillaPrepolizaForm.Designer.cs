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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.dateInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lblCantidad = new DevComponents.DotNetBar.LabelX();
            this.lblAno = new DevComponents.DotNetBar.LabelX();
            this.lblMes = new DevComponents.DotNetBar.LabelX();
            this.lblEmpresa = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(198)))), ((int)(((byte)(217)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(33, 193);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.Size = new System.Drawing.Size(900, 261);
            this.dataGridViewX1.TabIndex = 6;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(792, 475);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(141, 37);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 7;
            this.buttonX1.Text = "Cargar CFDIs";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // dateInput
            // 
            // 
            // 
            // 
            this.dateInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateInput.ButtonDropDown.Visible = true;
            this.dateInput.IsPopupCalendarOpen = false;
            this.dateInput.Location = new System.Drawing.Point(293, 475);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateInput.MonthCalendar.DisplayMonth = new System.DateTime(2018, 12, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateInput.MonthCalendar.TodayButtonVisible = true;
            this.dateInput.Name = "dateInput";
            this.dateInput.Size = new System.Drawing.Size(200, 20);
            this.dateInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateInput.TabIndex = 13;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(34, 475);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(253, 23);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "Seleccione Fecha para Crear Pre-Poliza:";
            // 
            // lblCantidad
            // 
            // 
            // 
            // 
            this.lblCantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCantidad.Location = new System.Drawing.Point(33, 122);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(431, 23);
            this.lblCantidad.TabIndex = 15;
            this.lblCantidad.Text = "Numero de CFDIS por generar Poliza";
            // 
            // lblAno
            // 
            // 
            // 
            // 
            this.lblAno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAno.Location = new System.Drawing.Point(33, 82);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(431, 23);
            this.lblAno.TabIndex = 16;
            this.lblAno.Text = "Año";
            // 
            // lblMes
            // 
            // 
            // 
            // 
            this.lblMes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMes.Location = new System.Drawing.Point(33, 42);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(431, 23);
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
            this.lblEmpresa.Size = new System.Drawing.Size(431, 23);
            this.lblEmpresa.TabIndex = 18;
            this.lblEmpresa.Text = "Empresa";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(33, 164);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(297, 23);
            this.labelX6.TabIndex = 19;
            this.labelX6.Text = "Click ó Enter para Revisar Factura:";
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(198)))), ((int)(((byte)(217)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(33, 518);
            this.dataGridViewX2.Name = "dataGridViewX2";
            this.dataGridViewX2.Size = new System.Drawing.Size(900, 199);
            this.dataGridViewX2.TabIndex = 20;
            // 
            // PlantillaPrepolizaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 729);
            this.Controls.Add(this.dataGridViewX2);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.dateInput);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "PlantillaPrepolizaForm";
            this.Text = "PlantillaPrepolizaForm";
            this.Load += new System.EventHandler(this.PlantillaPrepolizaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateInput;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lblCantidad;
        private DevComponents.DotNetBar.LabelX lblAno;
        private DevComponents.DotNetBar.LabelX lblMes;
        private DevComponents.DotNetBar.LabelX lblEmpresa;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
    }
}