namespace Melodii
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelParticipantiSubmenu.SuspendLayout();
            this.panelMelodiiSubmenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.panelParticipantiSubmenu);
            this.panelMenu.Controls.Add(this.btnParticipanti);
            this.panelMenu.Controls.Add(this.panelMelodiiSubmenu);
            this.panelMenu.Controls.Add(this.btnMelodii);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(191, 651);
            this.panelMenu.TabIndex = 0;
            // 
            // panelParticipantiSubmenu
            // 
            this.panelParticipantiSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelParticipantiSubmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelParticipantiSubmenu.Controls.Add(this.btnVeziParticipanti);
            this.panelParticipantiSubmenu.Controls.Add(this.btnAdaugaParticipanti);
            this.panelParticipantiSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelParticipantiSubmenu.Location = new System.Drawing.Point(0, 346);
            this.panelParticipantiSubmenu.Name = "panelParticipantiSubmenu";
            this.panelParticipantiSubmenu.Size = new System.Drawing.Size(191, 82);
            this.panelParticipantiSubmenu.TabIndex = 4;
            // 
            // btnVeziParticipanti
            // 
            this.btnVeziParticipanti.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVeziParticipanti.FlatAppearance.BorderSize = 0;
            this.btnVeziParticipanti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeziParticipanti.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnVeziParticipanti.Location = new System.Drawing.Point(0, 39);
            this.btnVeziParticipanti.Name = "btnVeziParticipanti";
            this.btnVeziParticipanti.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnVeziParticipanti.Size = new System.Drawing.Size(191, 39);
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
            this.btnAdaugaParticipanti.Size = new System.Drawing.Size(191, 39);
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
            this.btnParticipanti.Location = new System.Drawing.Point(0, 307);
            this.btnParticipanti.Name = "btnParticipanti";
            this.btnParticipanti.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnParticipanti.Size = new System.Drawing.Size(191, 39);
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
            this.panelMelodiiSubmenu.Size = new System.Drawing.Size(191, 78);
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
            this.btnVeziMelodii.Size = new System.Drawing.Size(191, 39);
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
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(0, 428);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(191, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "Sondaj";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 467);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 82);
            this.panel1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Location = new System.Drawing.Point(0, 39);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(191, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "*Vezi sondaje anterioare";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(191, 39);
            this.button3.TabIndex = 0;
            this.button3.Text = "Creaza";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
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
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Melodii";
            this.panelMenu.ResumeLayout(false);
            this.panelParticipantiSubmenu.ResumeLayout(false);
            this.panelMelodiiSubmenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}

