namespace Melodii.Forms
{
    partial class VeziMelodiiForm
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
            this.slidingBar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMelodii = new System.Windows.Forms.Panel();
            this.panelMelodiiButtons = new System.Windows.Forms.Panel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.timerSlidingBar = new System.Windows.Forms.Timer(this.components);
            this.timerSlideInDetails = new System.Windows.Forms.Timer(this.components);
            this.lbError = new System.Windows.Forms.Label();
            this.btTop3 = new System.Windows.Forms.Button();
            this.panelMelodii.SuspendLayout();
            this.SuspendLayout();
            // 
            // slidingBar
            // 
            this.slidingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.slidingBar.Location = new System.Drawing.Point(70, 96);
            this.slidingBar.Name = "slidingBar";
            this.slidingBar.Size = new System.Drawing.Size(174, 2);
            this.slidingBar.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vezi melodiile";
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
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(1, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 1);
            this.label3.TabIndex = 7;
            // 
            // panelMelodii
            // 
            this.panelMelodii.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMelodii.AutoScroll = true;
            this.panelMelodii.Controls.Add(this.panelMelodiiButtons);
            this.panelMelodii.Controls.Add(this.label3);
            this.panelMelodii.Controls.Add(this.label2);
            this.panelMelodii.Font = new System.Drawing.Font("Leelawadee", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMelodii.Location = new System.Drawing.Point(50, 143);
            this.panelMelodii.Name = "panelMelodii";
            this.panelMelodii.Size = new System.Drawing.Size(329, 408);
            this.panelMelodii.TabIndex = 8;
            // 
            // panelMelodiiButtons
            // 
            this.panelMelodiiButtons.AutoScroll = true;
            this.panelMelodiiButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelMelodiiButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMelodiiButtons.Location = new System.Drawing.Point(1, 0);
            this.panelMelodiiButtons.Name = "panelMelodiiButtons";
            this.panelMelodiiButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelMelodiiButtons.Size = new System.Drawing.Size(328, 407);
            this.panelMelodiiButtons.TabIndex = 8;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.panelInfo.Location = new System.Drawing.Point(421, 96);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(333, 455);
            this.panelInfo.TabIndex = 9;
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
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbError.Location = new System.Drawing.Point(46, 573);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 20);
            this.lbError.TabIndex = 10;
            // 
            // btTop3
            // 
            this.btTop3.AutoSize = true;
            this.btTop3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.btTop3.FlatAppearance.BorderSize = 0;
            this.btTop3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTop3.Font = new System.Drawing.Font("Leelawadee", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTop3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btTop3.Location = new System.Drawing.Point(275, 111);
            this.btTop3.Name = "btTop3";
            this.btTop3.Size = new System.Drawing.Size(104, 26);
            this.btTop3.TabIndex = 11;
            this.btTop3.Text = "Top 3 melodii";
            this.btTop3.UseVisualStyleBackColor = false;
            this.btTop3.Click += new System.EventHandler(this.btTop3_Click);
            // 
            // VeziMelodiiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(771, 612);
            this.Controls.Add(this.btTop3);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelMelodii);
            this.Controls.Add(this.slidingBar);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VeziMelodiiForm";
            this.Text = "Vezi melodiile";
            this.Resize += new System.EventHandler(this.VeziMelodiiForm_Resize);
            this.panelMelodii.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label slidingBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelMelodii;
        private System.Windows.Forms.Panel panelMelodiiButtons;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Timer timerSlidingBar;
        private System.Windows.Forms.Timer timerSlideInDetails;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Button btTop3;
    }
}