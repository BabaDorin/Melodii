namespace Melodii.Forms.Sondaj
{
    partial class SondajForm
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
            this.label = new System.Windows.Forms.Label();
            this.lbParticipant = new System.Windows.Forms.Label();
            this.lbMelodiiRamase = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSondaj = new System.Windows.Forms.Panel();
            this.SlidingPanel = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Leelawadee", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(341, 32);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(97, 32);
            this.label.TabIndex = 13;
            this.label.Text = "Sondaj";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbParticipant
            // 
            this.lbParticipant.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbParticipant.AutoSize = true;
            this.lbParticipant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParticipant.Location = new System.Drawing.Point(364, 76);
            this.lbParticipant.Name = "lbParticipant";
            this.lbParticipant.Size = new System.Drawing.Size(46, 18);
            this.lbParticipant.TabIndex = 14;
            this.lbParticipant.Text = "label1";
            // 
            // lbMelodiiRamase
            // 
            this.lbMelodiiRamase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbMelodiiRamase.AutoSize = true;
            this.lbMelodiiRamase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMelodiiRamase.Location = new System.Drawing.Point(364, 105);
            this.lbMelodiiRamase.Name = "lbMelodiiRamase";
            this.lbMelodiiRamase.Size = new System.Drawing.Size(46, 18);
            this.lbMelodiiRamase.TabIndex = 15;
            this.lbMelodiiRamase.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.lbMelodiiRamase);
            this.panel1.Controls.Add(this.lbParticipant);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 162);
            this.panel1.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(513, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 597);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(771, 15);
            this.panel2.TabIndex = 16;
            // 
            // panelSondaj
            // 
            this.panelSondaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSondaj.Location = new System.Drawing.Point(0, 162);
            this.panelSondaj.Name = "panelSondaj";
            this.panelSondaj.Size = new System.Drawing.Size(771, 435);
            this.panelSondaj.TabIndex = 17;
            // 
            // SlidingPanel
            // 
            this.SlidingPanel.Interval = 2;
            this.SlidingPanel.Tick += new System.EventHandler(this.SlidingPanel_Tick);
            // 
            // SondajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(771, 612);
            this.Controls.Add(this.panelSondaj);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SondajForm";
            this.Text = "SondajForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lbParticipant;
        private System.Windows.Forms.Label lbMelodiiRamase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelSondaj;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer SlidingPanel;
    }
}