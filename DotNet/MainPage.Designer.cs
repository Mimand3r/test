namespace TP_DotNet
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.GradientPanel = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.counter_ungueltig = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.counter_erfolg = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.temploggers = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.EmailButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.ResultFolder = new Bunifu.Framework.UI.BunifuImageButton();
            this.RunButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.StopButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.CloseButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.DissCard = new Bunifu.Framework.UI.BunifuCards();
            this.DissLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.DissSeperator = new Bunifu.Framework.UI.BunifuSeparator();
            this.DissPassword = new Bunifu.Framework.UI.BunifuTextbox();
            this.DissUsername = new Bunifu.Framework.UI.BunifuTextbox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.geltungszeitraum = new Bunifu.Framework.UI.BunifuDropdown();
            this.counter_error = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.GradientPanel.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.DissCard.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.GradientPanel;
            this.bunifuDragControl1.Vertical = true;
            // 
            // GradientPanel
            // 
            this.GradientPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GradientPanel.BackgroundImage")));
            this.GradientPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GradientPanel.Controls.Add(this.bunifuCards1);
            this.GradientPanel.Controls.Add(this.bunifuGradientPanel1);
            this.GradientPanel.Controls.Add(this.bunifuSeparator1);
            this.GradientPanel.Controls.Add(this.EmailButton);
            this.GradientPanel.Controls.Add(this.bunifuImageButton1);
            this.GradientPanel.Controls.Add(this.ResultFolder);
            this.GradientPanel.Controls.Add(this.RunButton);
            this.GradientPanel.Controls.Add(this.StopButton);
            this.GradientPanel.Controls.Add(this.CloseButton);
            this.GradientPanel.Controls.Add(this.DissCard);
            this.GradientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GradientPanel.GradientBottomLeft = System.Drawing.Color.DarkGray;
            this.GradientPanel.GradientBottomRight = System.Drawing.Color.DimGray;
            this.GradientPanel.GradientTopLeft = System.Drawing.Color.White;
            this.GradientPanel.GradientTopRight = System.Drawing.Color.WhiteSmoke;
            this.GradientPanel.Location = new System.Drawing.Point(0, 0);
            this.GradientPanel.Name = "GradientPanel";
            this.GradientPanel.Quality = 10;
            this.GradientPanel.Size = new System.Drawing.Size(434, 425);
            this.GradientPanel.TabIndex = 0;
            this.GradientPanel.Click += new System.EventHandler(this.CloseNewForm);
            this.GradientPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this._CloseNewForm);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.counter_error);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox3);
            this.bunifuGradientPanel1.Controls.Add(this.counter_ungueltig);
            this.bunifuGradientPanel1.Controls.Add(this.counter_erfolg);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox2);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox1);
            this.bunifuGradientPanel1.Controls.Add(this.temploggers);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Maroon;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.DarkRed;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Red;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Brown;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(109, 425);
            this.bunifuGradientPanel1.TabIndex = 12;
            // 
            // counter_ungueltig
            // 
            this.counter_ungueltig.AutoSize = true;
            this.counter_ungueltig.BackColor = System.Drawing.Color.Transparent;
            this.counter_ungueltig.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counter_ungueltig.ForeColor = System.Drawing.Color.White;
            this.counter_ungueltig.Location = new System.Drawing.Point(37, 229);
            this.counter_ungueltig.Name = "counter_ungueltig";
            this.counter_ungueltig.Size = new System.Drawing.Size(16, 18);
            this.counter_ungueltig.TabIndex = 16;
            this.counter_ungueltig.Text = "0";
            // 
            // counter_erfolg
            // 
            this.counter_erfolg.AutoSize = true;
            this.counter_erfolg.BackColor = System.Drawing.Color.Transparent;
            this.counter_erfolg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counter_erfolg.ForeColor = System.Drawing.Color.White;
            this.counter_erfolg.Location = new System.Drawing.Point(36, 129);
            this.counter_erfolg.Name = "counter_erfolg";
            this.counter_erfolg.Size = new System.Drawing.Size(16, 18);
            this.counter_erfolg.TabIndex = 15;
            this.counter_erfolg.Text = "0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(22, 176);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(84, 98);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 98);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // temploggers
            // 
            this.temploggers.AutoSize = true;
            this.temploggers.BackColor = System.Drawing.Color.Transparent;
            this.temploggers.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temploggers.ForeColor = System.Drawing.Color.White;
            this.temploggers.Location = new System.Drawing.Point(3, 25);
            this.temploggers.MaximumSize = new System.Drawing.Size(105, 0);
            this.temploggers.Name = "temploggers";
            this.temploggers.Size = new System.Drawing.Size(105, 14);
            this.temploggers.TabIndex = 12;
            this.temploggers.Text = "Ticketprompter ist aus";
            this.temploggers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(96, 0);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(27, 425);
            this.bunifuSeparator1.TabIndex = 10;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = true;
            // 
            // EmailButton
            // 
            this.EmailButton.BackColor = System.Drawing.Color.Transparent;
            this.EmailButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EmailButton.Image = ((System.Drawing.Image)(resources.GetObject("EmailButton.Image")));
            this.EmailButton.ImageActive = null;
            this.EmailButton.Location = new System.Drawing.Point(381, 130);
            this.EmailButton.Name = "EmailButton";
            this.EmailButton.Size = new System.Drawing.Size(41, 40);
            this.EmailButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EmailButton.TabIndex = 9;
            this.EmailButton.TabStop = false;
            this.EmailButton.Zoom = 13;
            this.EmailButton.Click += new System.EventHandler(this.MainEmailButton_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(371, 11);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(19, 23);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 8;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 14;
            this.bunifuImageButton1.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // ResultFolder
            // 
            this.ResultFolder.BackColor = System.Drawing.Color.Transparent;
            this.ResultFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResultFolder.Image = ((System.Drawing.Image)(resources.GetObject("ResultFolder.Image")));
            this.ResultFolder.ImageActive = null;
            this.ResultFolder.Location = new System.Drawing.Point(384, 66);
            this.ResultFolder.Name = "ResultFolder";
            this.ResultFolder.Size = new System.Drawing.Size(38, 31);
            this.ResultFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ResultFolder.TabIndex = 7;
            this.ResultFolder.TabStop = false;
            this.ResultFolder.Zoom = 25;
            this.ResultFolder.Click += new System.EventHandler(this.ResultFolder_Click);
            this.ResultFolder.MouseEnter += new System.EventHandler(this.Tooltipp_ExcelIcon);
            // 
            // RunButton
            // 
            this.RunButton.Activecolor = System.Drawing.Color.Silver;
            this.RunButton.BackColor = System.Drawing.Color.Gray;
            this.RunButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RunButton.BorderRadius = 5;
            this.RunButton.ButtonText = "Starten";
            this.RunButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RunButton.DisabledColor = System.Drawing.Color.Gray;
            this.RunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunButton.ForeColor = System.Drawing.Color.SandyBrown;
            this.RunButton.Iconcolor = System.Drawing.Color.Transparent;
            this.RunButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("RunButton.Iconimage")));
            this.RunButton.Iconimage_right = null;
            this.RunButton.Iconimage_right_Selected = null;
            this.RunButton.Iconimage_Selected = null;
            this.RunButton.IconMarginLeft = 0;
            this.RunButton.IconMarginRight = 0;
            this.RunButton.IconRightVisible = true;
            this.RunButton.IconRightZoom = 0D;
            this.RunButton.IconVisible = true;
            this.RunButton.IconZoom = 50D;
            this.RunButton.IsTab = false;
            this.RunButton.Location = new System.Drawing.Point(188, 343);
            this.RunButton.Name = "RunButton";
            this.RunButton.Normalcolor = System.Drawing.Color.Gray;
            this.RunButton.OnHovercolor = System.Drawing.SystemColors.ControlDarkDark;
            this.RunButton.OnHoverTextColor = System.Drawing.Color.White;
            this.RunButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RunButton.selected = false;
            this.RunButton.Size = new System.Drawing.Size(114, 52);
            this.RunButton.TabIndex = 6;
            this.RunButton.Text = "Starten";
            this.RunButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RunButton.Textcolor = System.Drawing.Color.White;
            this.RunButton.TextFont = new System.Drawing.Font("MS Outlook", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Activecolor = System.Drawing.Color.Maroon;
            this.StopButton.BackColor = System.Drawing.Color.Gray;
            this.StopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StopButton.BorderRadius = 5;
            this.StopButton.ButtonText = "Stoppen";
            this.StopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopButton.DisabledColor = System.Drawing.Color.Gray;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.Iconcolor = System.Drawing.Color.Transparent;
            this.StopButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("StopButton.Iconimage")));
            this.StopButton.Iconimage_right = null;
            this.StopButton.Iconimage_right_Selected = null;
            this.StopButton.Iconimage_Selected = null;
            this.StopButton.IconMarginLeft = 0;
            this.StopButton.IconMarginRight = 0;
            this.StopButton.IconRightVisible = true;
            this.StopButton.IconRightZoom = 0D;
            this.StopButton.IconVisible = true;
            this.StopButton.IconZoom = 50D;
            this.StopButton.IsTab = false;
            this.StopButton.Location = new System.Drawing.Point(188, 343);
            this.StopButton.Name = "StopButton";
            this.StopButton.Normalcolor = System.Drawing.Color.Gray;
            this.StopButton.OnHovercolor = System.Drawing.SystemColors.ControlDarkDark;
            this.StopButton.OnHoverTextColor = System.Drawing.Color.White;
            this.StopButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StopButton.selected = false;
            this.StopButton.Size = new System.Drawing.Size(114, 52);
            this.StopButton.TabIndex = 13;
            this.StopButton.Text = "Stoppen";
            this.StopButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StopButton.Textcolor = System.Drawing.Color.White;
            this.StopButton.TextFont = new System.Drawing.Font("MS Outlook", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.Visible = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageActive = null;
            this.CloseButton.Location = new System.Drawing.Point(396, 7);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(26, 32);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 5;
            this.CloseButton.TabStop = false;
            this.CloseButton.Zoom = 10;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // DissCard
            // 
            this.DissCard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DissCard.BorderRadius = 5;
            this.DissCard.BottomSahddow = true;
            this.DissCard.color = System.Drawing.Color.Gray;
            this.DissCard.Controls.Add(this.DissLabel);
            this.DissCard.Controls.Add(this.DissSeperator);
            this.DissCard.Controls.Add(this.DissPassword);
            this.DissCard.Controls.Add(this.DissUsername);
            this.DissCard.LeftSahddow = false;
            this.DissCard.Location = new System.Drawing.Point(129, 40);
            this.DissCard.Name = "DissCard";
            this.DissCard.RightSahddow = true;
            this.DissCard.ShadowDepth = 20;
            this.DissCard.Size = new System.Drawing.Size(235, 153);
            this.DissCard.TabIndex = 2;
            // 
            // DissLabel
            // 
            this.DissLabel.AutoSize = true;
            this.DissLabel.Font = new System.Drawing.Font("Open Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DissLabel.Location = new System.Drawing.Point(38, 11);
            this.DissLabel.Name = "DissLabel";
            this.DissLabel.Size = new System.Drawing.Size(174, 27);
            this.DissLabel.TabIndex = 3;
            this.DissLabel.Text = "Diss - LoginDaten";
            // 
            // DissSeperator
            // 
            this.DissSeperator.BackColor = System.Drawing.Color.Transparent;
            this.DissSeperator.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.DissSeperator.LineThickness = 1;
            this.DissSeperator.Location = new System.Drawing.Point(3, 23);
            this.DissSeperator.Name = "DissSeperator";
            this.DissSeperator.Size = new System.Drawing.Size(229, 35);
            this.DissSeperator.TabIndex = 2;
            this.DissSeperator.Transparency = 255;
            this.DissSeperator.Vertical = false;
            // 
            // DissPassword
            // 
            this.DissPassword.BackColor = System.Drawing.Color.Silver;
            this.DissPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DissPassword.BackgroundImage")));
            this.DissPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DissPassword.ForeColor = System.Drawing.Color.Honeydew;
            this.DissPassword.Icon = ((System.Drawing.Image)(resources.GetObject("DissPassword.Icon")));
            this.DissPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DissPassword.Location = new System.Drawing.Point(46, 91);
            this.DissPassword.Name = "DissPassword";
            this.DissPassword.Size = new System.Drawing.Size(148, 30);
            this.DissPassword.TabIndex = 1;
            this.DissPassword.text = "Passwort";
            // 
            // DissUsername
            // 
            this.DissUsername.BackColor = System.Drawing.Color.Silver;
            this.DissUsername.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DissUsername.BackgroundImage")));
            this.DissUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DissUsername.ForeColor = System.Drawing.Color.Honeydew;
            this.DissUsername.Icon = ((System.Drawing.Image)(resources.GetObject("DissUsername.Icon")));
            this.DissUsername.Location = new System.Drawing.Point(46, 55);
            this.DissUsername.Name = "DissUsername";
            this.DissUsername.Size = new System.Drawing.Size(148, 30);
            this.DissUsername.TabIndex = 0;
            this.DissUsername.text = "Name";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 12;
            this.bunifuElipse1.TargetControl = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = null;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Gray;
            this.bunifuCards1.Controls.Add(this.geltungszeitraum);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuCards1.Controls.Add(this.bunifuSeparator2);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(129, 208);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(235, 101);
            this.bunifuCards1.TabIndex = 4;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Open Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(29, 11);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(177, 27);
            this.bunifuCustomLabel1.TabIndex = 3;
            this.bunifuCustomLabel1.Text = "Geltungszeitraum";
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(3, 23);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(229, 35);
            this.bunifuSeparator2.TabIndex = 2;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // geltungszeitraum
            // 
            this.geltungszeitraum.BackColor = System.Drawing.Color.Transparent;
            this.geltungszeitraum.BorderRadius = 3;
            this.geltungszeitraum.ForeColor = System.Drawing.Color.White;
            this.geltungszeitraum.Items = new string[] {
        "24 Monate",
        "18 Monate",
        "12 Monate",
        "6 Monate"};
            this.geltungszeitraum.Location = new System.Drawing.Point(27, 55);
            this.geltungszeitraum.Name = "geltungszeitraum";
            this.geltungszeitraum.NomalColor = System.Drawing.Color.DarkGray;
            this.geltungszeitraum.onHoverColor = System.Drawing.Color.Gray;
            this.geltungszeitraum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.geltungszeitraum.selectedIndex = 0;
            this.geltungszeitraum.Size = new System.Drawing.Size(179, 30);
            this.geltungszeitraum.TabIndex = 4;
            // 
            // counter_error
            // 
            this.counter_error.AutoSize = true;
            this.counter_error.BackColor = System.Drawing.Color.Transparent;
            this.counter_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counter_error.ForeColor = System.Drawing.Color.White;
            this.counter_error.Location = new System.Drawing.Point(37, 333);
            this.counter_error.Name = "counter_error";
            this.counter_error.Size = new System.Drawing.Size(16, 18);
            this.counter_error.TabIndex = 18;
            this.counter_error.Text = "0";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(22, 280);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(84, 98);
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 425);
            this.Controls.Add(this.GradientPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TicketPrompter";
            this.GradientPanel.ResumeLayout(false);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.DissCard.ResumeLayout(false);
            this.DissCard.PerformLayout();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuGradientPanel GradientPanel;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuTextbox DissUsername;
        private Bunifu.Framework.UI.BunifuTextbox DissPassword;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Bunifu.Framework.UI.BunifuCards DissCard;
        private Bunifu.Framework.UI.BunifuCustomLabel DissLabel;
        private Bunifu.Framework.UI.BunifuSeparator DissSeperator;
        private Bunifu.Framework.UI.BunifuImageButton CloseButton;
        private Bunifu.Framework.UI.BunifuFlatButton RunButton;
        private Bunifu.Framework.UI.BunifuImageButton ResultFolder;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton EmailButton;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuCustomLabel temploggers;
        private Bunifu.Framework.UI.BunifuFlatButton StopButton;
        private Bunifu.Framework.UI.BunifuCustomLabel counter_ungueltig;
        private Bunifu.Framework.UI.BunifuCustomLabel counter_erfolg;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private Bunifu.Framework.UI.BunifuDropdown geltungszeitraum;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuCustomLabel counter_error;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

