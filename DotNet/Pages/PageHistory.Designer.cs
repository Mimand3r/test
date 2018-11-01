namespace TP_DotNet
{
    partial class PageHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageHistory));
            this.Konsole = new System.Windows.Forms.FlowLayoutPanel();
            this.zaehler_erfolgreich = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.zaehler_geltungszeitraum = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.zaehler_verpasst = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.zaehler_ungueltig = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.fehlermeldung = new System.Windows.Forms.PictureBox();
            this.DurchlaufChooser = new Bunifu.Framework.UI.BunifuDropdown();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fehlermeldung)).BeginInit();
            this.SuspendLayout();
            // 
            // Konsole
            // 
            this.Konsole.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Konsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.Konsole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Konsole.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Konsole.Font = new System.Drawing.Font("Century Gothic", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Konsole.Location = new System.Drawing.Point(475, 69);
            this.Konsole.Name = "Konsole";
            this.Konsole.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Konsole.Size = new System.Drawing.Size(398, 415);
            this.Konsole.TabIndex = 12;
            this.Konsole.WrapContents = false;
            // 
            // zaehler_erfolgreich
            // 
            this.zaehler_erfolgreich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(40)))));
            this.zaehler_erfolgreich.Font = new System.Drawing.Font("Franklin Gothic Demi", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.zaehler_erfolgreich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.zaehler_erfolgreich.Location = new System.Drawing.Point(37, 231);
            this.zaehler_erfolgreich.Name = "zaehler_erfolgreich";
            this.zaehler_erfolgreich.Size = new System.Drawing.Size(60, 32);
            this.zaehler_erfolgreich.TabIndex = 3;
            this.zaehler_erfolgreich.Text = "0";
            this.zaehler_erfolgreich.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zaehler_geltungszeitraum
            // 
            this.zaehler_geltungszeitraum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(46)))));
            this.zaehler_geltungszeitraum.Font = new System.Drawing.Font("Franklin Gothic Demi", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.zaehler_geltungszeitraum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.zaehler_geltungszeitraum.Location = new System.Drawing.Point(145, 232);
            this.zaehler_geltungszeitraum.Name = "zaehler_geltungszeitraum";
            this.zaehler_geltungszeitraum.Size = new System.Drawing.Size(60, 32);
            this.zaehler_geltungszeitraum.TabIndex = 13;
            this.zaehler_geltungszeitraum.Text = "0";
            this.zaehler_geltungszeitraum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zaehler_verpasst
            // 
            this.zaehler_verpasst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.zaehler_verpasst.Font = new System.Drawing.Font("Franklin Gothic Demi", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.zaehler_verpasst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.zaehler_verpasst.Location = new System.Drawing.Point(252, 230);
            this.zaehler_verpasst.Name = "zaehler_verpasst";
            this.zaehler_verpasst.Size = new System.Drawing.Size(60, 32);
            this.zaehler_verpasst.TabIndex = 14;
            this.zaehler_verpasst.Text = "0";
            this.zaehler_verpasst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zaehler_ungueltig
            // 
            this.zaehler_ungueltig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(46)))), ((int)(((byte)(41)))));
            this.zaehler_ungueltig.Font = new System.Drawing.Font("Franklin Gothic Demi", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.zaehler_ungueltig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.zaehler_ungueltig.Location = new System.Drawing.Point(352, 231);
            this.zaehler_ungueltig.Name = "zaehler_ungueltig";
            this.zaehler_ungueltig.Size = new System.Drawing.Size(60, 32);
            this.zaehler_ungueltig.TabIndex = 15;
            this.zaehler_ungueltig.Text = "0";
            this.zaehler_ungueltig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fehlermeldung
            // 
            this.fehlermeldung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(50)))));
            this.fehlermeldung.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fehlermeldung.BackgroundImage")));
            this.fehlermeldung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fehlermeldung.Location = new System.Drawing.Point(3, 340);
            this.fehlermeldung.Name = "fehlermeldung";
            this.fehlermeldung.Size = new System.Drawing.Size(430, 163);
            this.fehlermeldung.TabIndex = 16;
            this.fehlermeldung.TabStop = false;
            this.fehlermeldung.Visible = false;
            // 
            // DurchlaufChooser
            // 
            this.DurchlaufChooser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(89)))), ((int)(((byte)(104)))));
            this.DurchlaufChooser.BorderRadius = 20;
            this.DurchlaufChooser.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DurchlaufChooser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(164)))), ((int)(((byte)(181)))));
            this.DurchlaufChooser.Items = new string[] {
        "unbegrenzter Geltungszeitraum",
        "48 Monate",
        "24 Monate",
        "18 Monate",
        "12 Monate",
        " 6  Monate"};
            this.DurchlaufChooser.Location = new System.Drawing.Point(27, 108);
            this.DurchlaufChooser.Margin = new System.Windows.Forms.Padding(4);
            this.DurchlaufChooser.Name = "DurchlaufChooser";
            this.DurchlaufChooser.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(76)))));
            this.DurchlaufChooser.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.DurchlaufChooser.selectedIndex = 0;
            this.DurchlaufChooser.Size = new System.Drawing.Size(385, 63);
            this.DurchlaufChooser.TabIndex = 26;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // PageHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.DurchlaufChooser);
            this.Controls.Add(this.fehlermeldung);
            this.Controls.Add(this.zaehler_ungueltig);
            this.Controls.Add(this.zaehler_verpasst);
            this.Controls.Add(this.zaehler_geltungszeitraum);
            this.Controls.Add(this.zaehler_erfolgreich);
            this.Controls.Add(this.Konsole);
            this.DoubleBuffered = true;
            this.Name = "PageHistory";
            this.Size = new System.Drawing.Size(938, 548);
            ((System.ComponentModel.ISupportInitialize)(this.fehlermeldung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Konsole;
        private Bunifu.Framework.UI.BunifuCustomLabel zaehler_erfolgreich;
        private Bunifu.Framework.UI.BunifuCustomLabel zaehler_geltungszeitraum;
        private Bunifu.Framework.UI.BunifuCustomLabel zaehler_verpasst;
        private Bunifu.Framework.UI.BunifuCustomLabel zaehler_ungueltig;
        private System.Windows.Forms.PictureBox fehlermeldung;
        private Bunifu.Framework.UI.BunifuDropdown DurchlaufChooser;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}
