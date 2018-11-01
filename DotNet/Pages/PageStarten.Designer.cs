namespace TP_DotNet
{
    partial class PageStarten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageStarten));
            this.background = new System.Windows.Forms.PictureBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.timer = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.zaehler_erfolgreich = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.zaehler_geltungszeitraum = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.zaehler_verpasst = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.zaehler_ungueltig = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.fehlermeldung = new System.Windows.Forms.PictureBox();
            this.starten_button = new Bunifu.Framework.UI.BunifuImageButton();
            this.stoppen_button = new Bunifu.Framework.UI.BunifuImageButton();
            this.Konsole = new System.Windows.Forms.FlowLayoutPanel();
            this.meldung_aus = new Bunifu.Framework.UI.BunifuCustomLabel();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fehlermeldung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starten_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stoppen_button)).BeginInit();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("background.BackgroundImage")));
            this.background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(938, 548);
            this.background.TabIndex = 0;
            this.background.TabStop = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.background;
            this.bunifuDragControl1.Vertical = true;
            // 
            // timer
            // 
            this.timer.AutoSize = true;
            this.timer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.timer.Font = new System.Drawing.Font("Bauhaus 93", 31F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.timer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(84)))), ((int)(((byte)(53)))));
            this.timer.Location = new System.Drawing.Point(167, 15);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(673, 35);
            this.timer.TabIndex = 1;
            this.timer.Text = "4 Tagen. 18 Stunden. 44 Minuten. 23 Sekunden";
            this.timer.Visible = false;
            // 
            // zaehler_erfolgreich
            // 
            this.zaehler_erfolgreich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(40)))));
            this.zaehler_erfolgreich.Font = new System.Drawing.Font("Franklin Gothic Demi", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.zaehler_erfolgreich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.zaehler_erfolgreich.Location = new System.Drawing.Point(524, 166);
            this.zaehler_erfolgreich.Name = "zaehler_erfolgreich";
            this.zaehler_erfolgreich.Size = new System.Drawing.Size(60, 32);
            this.zaehler_erfolgreich.TabIndex = 2;
            this.zaehler_erfolgreich.Text = "0";
            this.zaehler_erfolgreich.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zaehler_geltungszeitraum
            // 
            this.zaehler_geltungszeitraum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(46)))));
            this.zaehler_geltungszeitraum.Font = new System.Drawing.Font("Franklin Gothic Demi", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.zaehler_geltungszeitraum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.zaehler_geltungszeitraum.Location = new System.Drawing.Point(632, 167);
            this.zaehler_geltungszeitraum.Name = "zaehler_geltungszeitraum";
            this.zaehler_geltungszeitraum.Size = new System.Drawing.Size(60, 32);
            this.zaehler_geltungszeitraum.TabIndex = 3;
            this.zaehler_geltungszeitraum.Text = "0";
            this.zaehler_geltungszeitraum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zaehler_verpasst
            // 
            this.zaehler_verpasst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.zaehler_verpasst.Font = new System.Drawing.Font("Franklin Gothic Demi", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.zaehler_verpasst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.zaehler_verpasst.Location = new System.Drawing.Point(740, 165);
            this.zaehler_verpasst.Name = "zaehler_verpasst";
            this.zaehler_verpasst.Size = new System.Drawing.Size(60, 32);
            this.zaehler_verpasst.TabIndex = 4;
            this.zaehler_verpasst.Text = "0";
            this.zaehler_verpasst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zaehler_ungueltig
            // 
            this.zaehler_ungueltig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(46)))), ((int)(((byte)(41)))));
            this.zaehler_ungueltig.Font = new System.Drawing.Font("Franklin Gothic Demi", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.zaehler_ungueltig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.zaehler_ungueltig.Location = new System.Drawing.Point(838, 167);
            this.zaehler_ungueltig.Name = "zaehler_ungueltig";
            this.zaehler_ungueltig.Size = new System.Drawing.Size(60, 32);
            this.zaehler_ungueltig.TabIndex = 5;
            this.zaehler_ungueltig.Text = "0";
            this.zaehler_ungueltig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fehlermeldung
            // 
            this.fehlermeldung.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fehlermeldung.BackgroundImage")));
            this.fehlermeldung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fehlermeldung.Location = new System.Drawing.Point(497, 281);
            this.fehlermeldung.Name = "fehlermeldung";
            this.fehlermeldung.Size = new System.Drawing.Size(430, 163);
            this.fehlermeldung.TabIndex = 6;
            this.fehlermeldung.TabStop = false;
            this.fehlermeldung.Visible = false;
            // 
            // starten_button
            // 
            this.starten_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(50)))));
            this.starten_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.starten_button.Image = ((System.Drawing.Image)(resources.GetObject("starten_button.Image")));
            this.starten_button.ImageActive = ((System.Drawing.Image)(resources.GetObject("starten_button.ImageActive")));
            this.starten_button.Location = new System.Drawing.Point(712, 471);
            this.starten_button.Name = "starten_button";
            this.starten_button.Size = new System.Drawing.Size(192, 52);
            this.starten_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.starten_button.TabIndex = 9;
            this.starten_button.TabStop = false;
            this.starten_button.Zoom = 5;
            this.starten_button.Click += new System.EventHandler(this.starten_button_Click);
            // 
            // stoppen_button
            // 
            this.stoppen_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(50)))));
            this.stoppen_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stoppen_button.Image = ((System.Drawing.Image)(resources.GetObject("stoppen_button.Image")));
            this.stoppen_button.ImageActive = ((System.Drawing.Image)(resources.GetObject("stoppen_button.ImageActive")));
            this.stoppen_button.Location = new System.Drawing.Point(712, 471);
            this.stoppen_button.Name = "stoppen_button";
            this.stoppen_button.Size = new System.Drawing.Size(192, 52);
            this.stoppen_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.stoppen_button.TabIndex = 10;
            this.stoppen_button.TabStop = false;
            this.stoppen_button.Visible = false;
            this.stoppen_button.Zoom = 5;
            this.stoppen_button.Click += new System.EventHandler(this.stoppen_button_Click);
            // 
            // Konsole
            // 
            this.Konsole.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Konsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.Konsole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Konsole.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Konsole.Font = new System.Drawing.Font("Century Gothic", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Konsole.Location = new System.Drawing.Point(61, 89);
            this.Konsole.Name = "Konsole";
            this.Konsole.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Konsole.Size = new System.Drawing.Size(398, 415);
            this.Konsole.TabIndex = 11;
            this.Konsole.WrapContents = false;
            // 
            // meldung_aus
            // 
            this.meldung_aus.AutoSize = true;
            this.meldung_aus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.meldung_aus.Font = new System.Drawing.Font("Bauhaus 93", 31F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.meldung_aus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(84)))), ((int)(((byte)(53)))));
            this.meldung_aus.Location = new System.Drawing.Point(167, 15);
            this.meldung_aus.Name = "meldung_aus";
            this.meldung_aus.Size = new System.Drawing.Size(317, 35);
            this.meldung_aus.TabIndex = 12;
            this.meldung_aus.Text = "Ticketprompter ist aus";
            // 
            // PageStarten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.meldung_aus);
            this.Controls.Add(this.Konsole);
            this.Controls.Add(this.stoppen_button);
            this.Controls.Add(this.starten_button);
            this.Controls.Add(this.fehlermeldung);
            this.Controls.Add(this.zaehler_ungueltig);
            this.Controls.Add(this.zaehler_verpasst);
            this.Controls.Add(this.zaehler_geltungszeitraum);
            this.Controls.Add(this.zaehler_erfolgreich);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.background);
            this.Name = "PageStarten";
            this.Size = new System.Drawing.Size(938, 548);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fehlermeldung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starten_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stoppen_button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox background;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuCustomLabel timer;
        private Bunifu.Framework.UI.BunifuCustomLabel zaehler_erfolgreich;
        private Bunifu.Framework.UI.BunifuCustomLabel zaehler_geltungszeitraum;
        private Bunifu.Framework.UI.BunifuCustomLabel zaehler_verpasst;
        private Bunifu.Framework.UI.BunifuCustomLabel zaehler_ungueltig;
        private System.Windows.Forms.PictureBox fehlermeldung;
        private Bunifu.Framework.UI.BunifuImageButton starten_button;
        private Bunifu.Framework.UI.BunifuImageButton stoppen_button;
        private System.Windows.Forms.FlowLayoutPanel Konsole;
        private Bunifu.Framework.UI.BunifuCustomLabel meldung_aus;
    }
}
