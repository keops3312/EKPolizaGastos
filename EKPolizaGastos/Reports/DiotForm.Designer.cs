namespace EKPolizaGastos.Reports
{
    partial class DiotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiotForm));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReportDiot1 = new EKPolizaGastos.Reports.CrystalReportDiot();
            this.dataSetDiot1 = new EKPolizaGastos.Data.DataSetDiot();
            this.CrystalReportDiot2 = new EKPolizaGastos.Reports.CrystalReportDiot();
            this.btnDiot = new DevComponents.DotNetBar.ButtonX();
            this.btnVolver = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDiot1)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 76);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(800, 374);
            this.crystalReportViewer1.TabIndex = 2;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // dataSetDiot1
            // 
            this.dataSetDiot1.DataSetName = "DataSetDiot";
            this.dataSetDiot1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnDiot
            // 
            this.btnDiot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDiot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDiot.Image = global::EKPolizaGastos.Properties.Resources.bathc;
            this.btnDiot.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnDiot.Location = new System.Drawing.Point(630, 12);
            this.btnDiot.Name = "btnDiot";
            this.btnDiot.Size = new System.Drawing.Size(158, 42);
            this.btnDiot.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDiot.TabIndex = 1;
            this.btnDiot.Text = "&Hacer Batch";
            this.btnDiot.Click += new System.EventHandler(this.btnDiot_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVolver.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVolver.Image = global::EKPolizaGastos.Properties.Resources.cerrar;
            this.btnVolver.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnVolver.Location = new System.Drawing.Point(12, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(158, 42);
            this.btnVolver.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "&Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // DiotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnDiot);
            this.Controls.Add(this.crystalReportViewer1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DiotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de DIOT";
            this.Load += new System.EventHandler(this.DiotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDiot1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReportDiot CrystalReportDiot1;
        private Data.DataSetDiot dataSetDiot1;
        private CrystalReportDiot CrystalReportDiot2;
        private DevComponents.DotNetBar.ButtonX btnDiot;
        private DevComponents.DotNetBar.ButtonX btnVolver;
    }
}