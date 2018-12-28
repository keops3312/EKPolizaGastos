namespace EKPolizaGastos
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtpath = new System.Windows.Forms.TextBox();
            this.lblCount = new DevComponents.DotNetBar.LabelX();
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.lblMessage = new DevComponents.DotNetBar.LabelX();
            this.lblLeyenda = new DevComponents.DotNetBar.LabelX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.listZip = new DevComponents.DotNetBar.ListBoxAdv();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.lblItemSeleted = new DevComponents.DotNetBar.LabelX();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.listXML = new System.Windows.Forms.ListBox();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnPoliza = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLeer = new DevComponents.DotNetBar.ButtonX();
            this.btnCargarRuta = new DevComponents.DotNetBar.ButtonX();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listTables = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.lblEmpresa = new DevComponents.DotNetBar.LabelX();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(12, 122);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(308, 20);
            this.txtpath.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Black;
            this.lblCount.Location = new System.Drawing.Point(12, 163);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(308, 41);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "-";
            this.lblCount.WordWrap = true;
            // 
            // circularProgress1
            // 
            this.circularProgress1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(496, 214);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.circularProgress1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.circularProgress1.Size = new System.Drawing.Size(46, 49);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 5;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.Location = new System.Drawing.Point(445, 75);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(221, 38);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "-";
            this.lblMessage.WordWrap = true;
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblLeyenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLeyenda.ForeColor = System.Drawing.Color.Black;
            this.lblLeyenda.Location = new System.Drawing.Point(12, 93);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(308, 23);
            this.lblLeyenda.TabIndex = 7;
            this.lblLeyenda.Text = "Ruta Cargada:";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerColorTint = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(12, 37);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(139, 23);
            this.labelX1.TabIndex = 10;
            this.labelX1.Text = "1. Selecciona Empresa";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(389, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(277, 23);
            this.labelX2.TabIndex = 11;
            this.labelX2.Text = "2. Leer Carpeta y Registar Arhivos XML";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(785, 37);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(121, 23);
            this.labelX3.TabIndex = 12;
            this.labelX3.Text = "3. Revisar registros";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(12, 66);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(308, 21);
            this.cmbEmpresa.TabIndex = 13;
            this.cmbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            // 
            // listZip
            // 
            this.listZip.AutoScroll = true;
            // 
            // 
            // 
            this.listZip.BackgroundStyle.BorderBottomWidth = 2;
            this.listZip.BackgroundStyle.BorderLeftWidth = 2;
            this.listZip.BackgroundStyle.BorderRightWidth = 2;
            this.listZip.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.listZip.BackgroundStyle.BorderTopWidth = 2;
            this.listZip.BackgroundStyle.Class = "TreeBorderKey";
            this.listZip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listZip.CheckStateMember = null;
            this.listZip.ContainerControlProcessDialogKey = true;
            this.listZip.DragDropSupport = true;
            this.listZip.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.listZip.Location = new System.Drawing.Point(12, 210);
            this.listZip.Name = "listZip";
            this.listZip.Size = new System.Drawing.Size(308, 139);
            this.listZip.TabIndex = 14;
            this.listZip.Text = "listBoxAdv1";
            this.listZip.ItemDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listZip_ItemDoubleClick);
            this.listZip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listZip_KeyPress);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(12, 143);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(308, 23);
            this.labelX4.TabIndex = 15;
            this.labelX4.Text = "Archivos Zip Encontrados(Seleccione uno para descomprimir)";
            // 
            // lblItemSeleted
            // 
            // 
            // 
            // 
            this.lblItemSeleted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblItemSeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemSeleted.ForeColor = System.Drawing.Color.Black;
            this.lblItemSeleted.Location = new System.Drawing.Point(12, 384);
            this.lblItemSeleted.Name = "lblItemSeleted";
            this.lblItemSeleted.Size = new System.Drawing.Size(308, 23);
            this.lblItemSeleted.TabIndex = 16;
            this.lblItemSeleted.Text = "-";
            this.lblItemSeleted.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // listXML
            // 
            this.listXML.FormattingEnabled = true;
            this.listXML.Location = new System.Drawing.Point(389, 123);
            this.listXML.Name = "listXML";
            this.listXML.Size = new System.Drawing.Size(277, 238);
            this.listXML.TabIndex = 17;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(50, 355);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(148, 30);
            this.labelX5.TabIndex = 18;
            this.labelX5.Text = "Archivo Seleccionado";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::EKPolizaGastos.Properties.Resources.xmlLogo;
            this.pictureBox3.Location = new System.Drawing.Point(389, 75);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 41);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::EKPolizaGastos.Properties.Resources.ZIP_File_Logo;
            this.pictureBox2.Location = new System.Drawing.Point(12, 355);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // btnPoliza
            // 
            this.btnPoliza.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPoliza.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPoliza.Image = global::EKPolizaGastos.Properties.Resources.attachment_icon;
            this.btnPoliza.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnPoliza.Location = new System.Drawing.Point(785, 413);
            this.btnPoliza.Name = "btnPoliza";
            this.btnPoliza.Size = new System.Drawing.Size(187, 50);
            this.btnPoliza.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPoliza.TabIndex = 9;
            this.btnPoliza.Text = "Revisar XML\'s Registrados";
            this.btnPoliza.Click += new System.EventHandler(this.btnPoliza_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EKPolizaGastos.Properties.Resources.New_DatabaseP_fw;
            this.pictureBox1.Location = new System.Drawing.Point(989, 477);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnLeer
            // 
            this.btnLeer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLeer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLeer.Image = global::EKPolizaGastos.Properties.Resources.New_Database;
            this.btnLeer.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnLeer.Location = new System.Drawing.Point(441, 413);
            this.btnLeer.Name = "btnLeer";
            this.btnLeer.Size = new System.Drawing.Size(187, 50);
            this.btnLeer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLeer.TabIndex = 4;
            this.btnLeer.Text = "Registrar en Base de Datos";
            this.btnLeer.Click += new System.EventHandler(this.btnLeer_Click);
            this.btnLeer.MouseHover += new System.EventHandler(this.btnLeer_MouseHover);
            // 
            // btnCargarRuta
            // 
            this.btnCargarRuta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCargarRuta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCargarRuta.Image = global::EKPolizaGastos.Properties.Resources.My_Documents_Folder;
            this.btnCargarRuta.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnCargarRuta.Location = new System.Drawing.Point(70, 413);
            this.btnCargarRuta.Name = "btnCargarRuta";
            this.btnCargarRuta.Size = new System.Drawing.Size(162, 50);
            this.btnCargarRuta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCargarRuta.TabIndex = 2;
            this.btnCargarRuta.Text = "Descomprimir Archivo";
            this.btnCargarRuta.Click += new System.EventHandler(this.btnCargarRuta_Click);
            this.btnCargarRuta.MouseHover += new System.EventHandler(this.btnCargarRuta_MouseHover);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "iconList.fw.png");
            // 
            // listTables
            // 
            // 
            // 
            // 
            this.listTables.Border.Class = "ListViewBorder";
            this.listTables.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listTables.DisabledBackColor = System.Drawing.Color.Empty;
            this.listTables.Location = new System.Drawing.Point(990, 413);
            this.listTables.Name = "listTables";
            this.listTables.Size = new System.Drawing.Size(44, 44);
            this.listTables.SmallImageList = this.imageList1;
            this.listTables.TabIndex = 21;
            this.listTables.UseCompatibleStateImageBehavior = false;
            this.listTables.View = System.Windows.Forms.View.Details;
            // 
            // lblEmpresa
            // 
            // 
            // 
            // 
            this.lblEmpresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEmpresa.Location = new System.Drawing.Point(729, 82);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(277, 44);
            this.lblEmpresa.TabIndex = 22;
            this.lblEmpresa.Text = "-";
            this.lblEmpresa.WordWrap = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(729, 123);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(277, 238);
            this.listBox1.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 475);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.listTables);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.circularProgress1);
            this.Controls.Add(this.listXML);
            this.Controls.Add(this.lblItemSeleted);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.listZip);
            this.Controls.Add(this.cmbEmpresa);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnPoliza);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLeyenda);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnLeer);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnCargarRuta);
            this.Controls.Add(this.txtpath);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TitleText = "EK Poliza de Gastos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtpath;
        private DevComponents.DotNetBar.ButtonX btnCargarRuta;
        private DevComponents.DotNetBar.LabelX lblCount;
        private DevComponents.DotNetBar.ButtonX btnLeer;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
        private DevComponents.DotNetBar.LabelX lblMessage;
        private DevComponents.DotNetBar.LabelX lblLeyenda;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonX btnPoliza;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private DevComponents.DotNetBar.ListBoxAdv listZip;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX lblItemSeleted;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ListBox listXML;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Controls.ListViewEx listTables;
        private DevComponents.DotNetBar.LabelX lblEmpresa;
        private System.Windows.Forms.ListBox listBox1;
    }
}

