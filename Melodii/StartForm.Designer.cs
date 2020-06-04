namespace Melodii
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelSondajSubmenu = new System.Windows.Forms.Panel();
            this.btnVeziSondaje = new System.Windows.Forms.Button();
            this.btnSondaj = new System.Windows.Forms.Button();
            this.panelParticipantiSubmenu = new System.Windows.Forms.Panel();
            this.btnVeziParticipanti = new System.Windows.Forms.Button();
            this.btnAdaugaParticipanti = new System.Windows.Forms.Button();
            this.btnParticipanti = new System.Windows.Forms.Button();
            this.panelMelodiiSubmenu = new System.Windows.Forms.Panel();
            this.btnVeziMelodii = new System.Windows.Forms.Button();
            this.btnAdaugaMelodii = new System.Windows.Forms.Button();
            this.btnMelodii = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelFormsArea = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelSondajSubmenu.SuspendLayout();
            this.panelParticipantiSubmenu.SuspendLayout();
            this.panelMelodiiSubmenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelMenu.Controls.Add(this.panelSondajSubmenu);
            this.panelMenu.Controls.Add(this.btnSondaj);
            this.panelMenu.Controls.Add(this.panelParticipantiSubmenu);
            this.panelMenu.Controls.Add(this.btnParticipanti);
            this.panelMenu.Controls.Add(this.panelMelodiiSubmenu);
            this.panelMenu.Controls.Add(this.btnMelodii);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Font = new System.Drawing.Font("Leelawadee", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(191, 651);
            this.panelMenu.TabIndex = 0;
            // 
            // panelSondajSubmenu
            // 
            this.panelSondajSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelSondajSubmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelSondajSubmenu.Controls.Add(this.btnVeziSondaje);
            this.panelSondajSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSondajSubmenu.Location = new System.Drawing.Point(0, 457);
            this.panelSondajSubmenu.Name = "panelSondajSubmenu";
            this.panelSondajSubmenu.Size = new System.Drawing.Size(191, 38);
            this.panelSondajSubmenu.TabIndex = 6;
            // 
            // btnVeziSondaje
            // 
            this.btnVeziSondaje.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVeziSondaje.FlatAppearance.BorderSize = 0;
            this.btnVeziSondaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeziSondaje.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnVeziSondaje.Location = new System.Drawing.Point(0, 0);
            this.btnVeziSondaje.Name = "btnVeziSondaje";
            this.btnVeziSondaje.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnVeziSondaje.Size = new System.Drawing.Size(191, 38);
            this.btnVeziSondaje.TabIndex = 2;
            this.btnVeziSondaje.Text = "Vezi sondajele anterioare";
            this.btnVeziSondaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVeziSondaje.UseVisualStyleBackColor = true;
            this.btnVeziSondaje.Click += new System.EventHandler(this.btnVeziSondaje_Click);
            // 
            // btnSondaj
            // 
            this.btnSondaj.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSondaj.FlatAppearance.BorderSize = 0;
            this.btnSondaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSondaj.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSondaj.Location = new System.Drawing.Point(0, 419);
            this.btnSondaj.Name = "btnSondaj";
            this.btnSondaj.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSondaj.Size = new System.Drawing.Size(191, 38);
            this.btnSondaj.TabIndex = 5;
            this.btnSondaj.Text = "Sondaj";
            this.btnSondaj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSondaj.UseVisualStyleBackColor = true;
            this.btnSondaj.Click += new System.EventHandler(this.btnSondaj_Click);
            // 
            // panelParticipantiSubmenu
            // 
            this.panelParticipantiSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelParticipantiSubmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelParticipantiSubmenu.Controls.Add(this.btnVeziParticipanti);
            this.panelParticipantiSubmenu.Controls.Add(this.btnAdaugaParticipanti);
            this.panelParticipantiSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelParticipantiSubmenu.Location = new System.Drawing.Point(0, 343);
            this.panelParticipantiSubmenu.Name = "panelParticipantiSubmenu";
            this.panelParticipantiSubmenu.Size = new System.Drawing.Size(191, 76);
            this.panelParticipantiSubmenu.TabIndex = 4;
            // 
            // btnVeziParticipanti
            // 
            this.btnVeziParticipanti.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVeziParticipanti.FlatAppearance.BorderSize = 0;
            this.btnVeziParticipanti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeziParticipanti.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnVeziParticipanti.Location = new System.Drawing.Point(0, 38);
            this.btnVeziParticipanti.Name = "btnVeziParticipanti";
            this.btnVeziParticipanti.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnVeziParticipanti.Size = new System.Drawing.Size(191, 38);
            this.btnVeziParticipanti.TabIndex = 1;
            this.btnVeziParticipanti.Text = "Vezi participantii";
            this.btnVeziParticipanti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVeziParticipanti.UseVisualStyleBackColor = true;
            this.btnVeziParticipanti.Click += new System.EventHandler(this.btnVeziParticipanti_Click);
            // 
            // btnAdaugaParticipanti
            // 
            this.btnAdaugaParticipanti.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdaugaParticipanti.FlatAppearance.BorderSize = 0;
            this.btnAdaugaParticipanti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdaugaParticipanti.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdaugaParticipanti.Location = new System.Drawing.Point(0, 0);
            this.btnAdaugaParticipanti.Name = "btnAdaugaParticipanti";
            this.btnAdaugaParticipanti.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAdaugaParticipanti.Size = new System.Drawing.Size(191, 38);
            this.btnAdaugaParticipanti.TabIndex = 0;
            this.btnAdaugaParticipanti.Text = "Adauga";
            this.btnAdaugaParticipanti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdaugaParticipanti.UseVisualStyleBackColor = true;
            this.btnAdaugaParticipanti.Click += new System.EventHandler(this.btnAdaugaParticipanti_Click);
            // 
            // btnParticipanti
            // 
            this.btnParticipanti.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnParticipanti.FlatAppearance.BorderSize = 0;
            this.btnParticipanti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParticipanti.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnParticipanti.Location = new System.Drawing.Point(0, 305);
            this.btnParticipanti.Name = "btnParticipanti";
            this.btnParticipanti.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnParticipanti.Size = new System.Drawing.Size(191, 38);
            this.btnParticipanti.TabIndex = 3;
            this.btnParticipanti.Text = "Participanti";
            this.btnParticipanti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParticipanti.UseVisualStyleBackColor = true;
            this.btnParticipanti.Click += new System.EventHandler(this.btnParticipanti_Click);
            // 
            // panelMelodiiSubmenu
            // 
            this.panelMelodiiSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelMelodiiSubmenu.Controls.Add(this.btnVeziMelodii);
            this.panelMelodiiSubmenu.Controls.Add(this.btnAdaugaMelodii);
            this.panelMelodiiSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMelodiiSubmenu.Location = new System.Drawing.Point(0, 229);
            this.panelMelodiiSubmenu.Name = "panelMelodiiSubmenu";
            this.panelMelodiiSubmenu.Size = new System.Drawing.Size(191, 76);
            this.panelMelodiiSubmenu.TabIndex = 2;
            // 
            // btnVeziMelodii
            // 
            this.btnVeziMelodii.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVeziMelodii.FlatAppearance.BorderSize = 0;
            this.btnVeziMelodii.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeziMelodii.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnVeziMelodii.Location = new System.Drawing.Point(0, 38);
            this.btnVeziMelodii.Name = "btnVeziMelodii";
            this.btnVeziMelodii.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnVeziMelodii.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnVeziMelodii.Size = new System.Drawing.Size(191, 38);
            this.btnVeziMelodii.TabIndex = 2;
            this.btnVeziMelodii.Text = "Vezi melodiile";
            this.btnVeziMelodii.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVeziMelodii.UseVisualStyleBackColor = true;
            this.btnVeziMelodii.Click += new System.EventHandler(this.btnVeziMelodii_Click);
            // 
            // btnAdaugaMelodii
            // 
            this.btnAdaugaMelodii.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdaugaMelodii.FlatAppearance.BorderSize = 0;
            this.btnAdaugaMelodii.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdaugaMelodii.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdaugaMelodii.Location = new System.Drawing.Point(0, 0);
            this.btnAdaugaMelodii.Name = "btnAdaugaMelodii";
            this.btnAdaugaMelodii.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAdaugaMelodii.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdaugaMelodii.Size = new System.Drawing.Size(191, 38);
            this.btnAdaugaMelodii.TabIndex = 0;
            this.btnAdaugaMelodii.Text = "Adauga";
            this.btnAdaugaMelodii.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdaugaMelodii.UseVisualStyleBackColor = true;
            this.btnAdaugaMelodii.Click += new System.EventHandler(this.btnAdaugaMelodii_Click);
            // 
            // btnMelodii
            // 
            this.btnMelodii.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.btnMelodii.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMelodii.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMelodii.FlatAppearance.BorderSize = 0;
            this.btnMelodii.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMelodii.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMelodii.Location = new System.Drawing.Point(0, 191);
            this.btnMelodii.Name = "btnMelodii";
            this.btnMelodii.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMelodii.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMelodii.Size = new System.Drawing.Size(191, 38);
            this.btnMelodii.TabIndex = 1;
            this.btnMelodii.TabStop = false;
            this.btnMelodii.Text = "Melodii";
            this.btnMelodii.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMelodii.UseVisualStyleBackColor = false;
            this.btnMelodii.Click += new System.EventHandler(this.btnMelodii_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(191, 191);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.pictureBox1.Size = new System.Drawing.Size(191, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panelFormsArea
            // 
            this.panelFormsArea.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelFormsArea.BackgroundImage")));
            this.panelFormsArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFormsArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormsArea.Location = new System.Drawing.Point(191, 0);
            this.panelFormsArea.Name = "panelFormsArea";
            this.panelFormsArea.Size = new System.Drawing.Size(787, 651);
            this.panelFormsArea.TabIndex = 1;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(978, 651);
            this.Controls.Add(this.panelFormsArea);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Melodii";
            this.panelMenu.ResumeLayout(false);
            this.panelSondajSubmenu.ResumeLayout(false);
            this.panelParticipantiSubmenu.ResumeLayout(false);
            this.panelMelodiiSubmenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelParticipantiSubmenu;
        private System.Windows.Forms.Button btnVeziParticipanti;
        private System.Windows.Forms.Button btnAdaugaParticipanti;
        private System.Windows.Forms.Button btnParticipanti;
        private System.Windows.Forms.Panel panelMelodiiSubmenu;
        private System.Windows.Forms.Button btnVeziMelodii;
        private System.Windows.Forms.Button btnAdaugaMelodii;
        private System.Windows.Forms.Button btnMelodii;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelFormsArea;
        private System.Windows.Forms.Panel panelSondajSubmenu;
        private System.Windows.Forms.Button btnSondaj;
        private System.Windows.Forms.Button btnVeziSondaje;
    }
}

