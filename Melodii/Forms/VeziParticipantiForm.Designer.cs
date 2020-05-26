namespace Melodii.Forms
{
    partial class VeziParticipantiForm
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
            this.lbError = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panelParticipanti = new System.Windows.Forms.Panel();
            this.panelParticipantiButtons = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.slidingBar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerSlidingBar = new System.Windows.Forms.Timer(this.components);
            this.timerSlideInDetails = new System.Windows.Forms.Timer(this.components);
            this.btVarsta18 = new System.Windows.Forms.Button();
            this.panelParticipanti.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbError.Location = new System.Drawing.Point(47, 572);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 17);
            this.lbError.TabIndex = 15;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.panelInfo.Location = new System.Drawing.Point(422, 95);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(333, 455);
            this.panelInfo.TabIndex = 14;
            // 
            // panelParticipanti
            // 
            this.panelParticipanti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelParticipanti.AutoScroll = true;
            this.panelParticipanti.Controls.Add(this.panelParticipantiButtons);
            this.panelParticipanti.Controls.Add(this.label3);
            this.panelParticipanti.Controls.Add(this.label2);
            this.panelParticipanti.Location = new System.Drawing.Point(51, 142);
            this.panelParticipanti.Name = "panelParticipanti";
            this.panelParticipanti.Size = new System.Drawing.Size(329, 408);
            this.panelParticipanti.TabIndex = 13;
            // 
            // panelParticipantiButtons
            // 
            this.panelParticipantiButtons.AutoScroll = true;
            this.panelParticipantiButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelParticipantiButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParticipantiButtons.Location = new System.Drawing.Point(1, 0);
            this.panelParticipantiButtons.Name = "panelParticipantiButtons";
            this.panelParticipantiButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelParticipantiButtons.Size = new System.Drawing.Size(328, 407);
            this.panelParticipantiButtons.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(1, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 1);
            this.label3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 408);
            this.label2.TabIndex = 4;
            // 
            // slidingBar
            // 
            this.slidingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.slidingBar.Location = new System.Drawing.Point(71, 95);
            this.slidingBar.Name = "slidingBar";
            this.slidingBar.Size = new System.Drawing.Size(209, 2);
            this.slidingBar.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Vezi Participantii";
            // 
            // timerSlidingBar
            // 
            this.timerSlidingBar.Interval = 2;
            this.timerSlidingBar.Tick += new System.EventHandler(this.timerSlidingBar_Tick);
            // 
            // timerSlideInDetails
            // 
            this.timerSlideInDetails.Interval = 2;
            this.timerSlideInDetails.Tick += new System.EventHandler(this.timerSlideInDetails_Tick);
            // 
            // btVarsta18
            // 
            this.btVarsta18.AutoSize = true;
            this.btVarsta18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.btVarsta18.FlatAppearance.BorderSize = 0;
            this.btVarsta18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVarsta18.Font = new System.Drawing.Font("Leelawadee", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVarsta18.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btVarsta18.Location = new System.Drawing.Point(276, 110);
            this.btVarsta18.Name = "btVarsta18";
            this.btVarsta18.Size = new System.Drawing.Size(104, 26);
            this.btVarsta18.TabIndex = 16;
            this.btVarsta18.Text = "Varsta ≤ 18";
            this.btVarsta18.UseVisualStyleBackColor = false;
            this.btVarsta18.Click += new System.EventHandler(this.btVarsta18_Click);
            // 
            // VeziParticipantiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(771, 612);
            this.Controls.Add(this.btVarsta18);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelParticipanti);
            this.Controls.Add(this.slidingBar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VeziParticipantiForm";
            this.Text = "VeziParticipantiForm";
            this.Resize += new System.EventHandler(this.VeziMelodiiForm_Resize);
            this.panelParticipanti.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelParticipanti;
        private System.Windows.Forms.Panel panelParticipantiButtons;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label slidingBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerSlidingBar;
        private System.Windows.Forms.Timer timerSlideInDetails;
        private System.Windows.Forms.Button btVarsta18;
    }
}