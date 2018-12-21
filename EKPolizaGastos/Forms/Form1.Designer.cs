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
            this.txtpath = new System.Windows.Forms.TextBox();
            this.lblCount = new DevComponents.DotNetBar.LabelX();
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.lblMessage = new DevComponents.DotNetBar.LabelX();
            this.lblLeyenda = new DevComponents.DotNetBar.LabelX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLeer = new DevComponents.DotNetBar.ButtonX();
            this.btnCargarRuta = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(30, 151);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(262, 20);
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
            this.lblCount.ForeColor = System.Drawing.Color.White;
            this.lblCount.Location = new System.Drawing.Point(30, 177);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(262, 63);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "-";
            // 
            // circularProgress1
            // 
            this.circularProgress1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(138, 289);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.Size = new System.Drawing.Size(28, 28);
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
            this.lblMessage.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.Location = new System.Drawing.Point(42, 415);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(250, 23);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "labelX1";
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblLeyenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLeyenda.ForeColor = System.Drawing.Color.White;
            this.lblLeyenda.Location = new System.Drawing.Point(30, 122);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(262, 23);
            this.lblLeyenda.TabIndex = 7;
            this.lblLeyenda.Text = "Ruta Cargada:";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EKPolizaGastos.Properties.Resources.New_DatabaseP_fw;
            this.pictureBox1.Location = new System.Drawing.Point(398, 347);
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
            this.btnLeer.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnLeer.Location = new System.Drawing.Point(113, 323);
            this.btnLeer.Name = "btnLeer";
            this.btnLeer.Size = new System.Drawing.Size(75, 59);
            this.btnLeer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLeer.TabIndex = 4;
            this.btnLeer.Click += new System.EventHandler(this.btnLeer_Click);
            this.btnLeer.MouseHover += new System.EventHandler(this.btnLeer_MouseHover);
            // 
            // btnCargarRuta
            // 
            this.btnCargarRuta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCargarRuta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCargarRuta.Image = global::EKPolizaGastos.Properties.Resources.My_Documents_Folder;
            this.btnCargarRuta.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.btnCargarRuta.Location = new System.Drawing.Point(113, 47);
            this.btnCargarRuta.Name = "btnCargarRuta";
            this.btnCargarRuta.Size = new System.Drawing.Size(75, 59);
            this.btnCargarRuta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCargarRuta.TabIndex = 2;
            this.btnCargarRuta.Click += new System.EventHandler(this.btnCargarRuta_Click);
            this.btnCargarRuta.MouseHover += new System.EventHandler(this.btnCargarRuta_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLeyenda);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.circularProgress1);
            this.Controls.Add(this.btnLeer);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnCargarRuta);
            this.Controls.Add(this.txtpath);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TitleText = "EK Poliza de Gastos";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

