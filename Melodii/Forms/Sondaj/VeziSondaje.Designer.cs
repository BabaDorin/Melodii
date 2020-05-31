namespace Melodii.Forms.Sondaj
{
    partial class VeziSondaje
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
            this.panelSondaje = new System.Windows.Forms.Panel();
            this.panelSondajeButtons = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.slidingBar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerSlidingBar = new System.Windows.Forms.Timer(this.components);
            this.timerSlideInDetails = new System.Windows.Forms.Timer(this.components);
            this.panelSondaje.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.Font = new System.Drawing.Font("Leelawadee", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbError.Location = new System.Drawing.Point(46, 573);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 19);
            this.lbError.TabIndex = 16;
            // 
            // panelSondaje
            // 
            this.panelSondaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSondaje.AutoScroll = true;
            this.panelSondaje.Controls.Add(this.panelSondajeButtons);
            this.panelSondaje.Controls.Add(this.label3);
            this.panelSondaje.Controls.Add(this.label2);
            this.panelSondaje.Font = new System.Drawing.Font("Leelawadee", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelSondaje.Location = new System.Drawing.Point(50, 143);
            this.panelSondaje.Name = "panelSondaje";
            this.panelSondaje.Size = new System.Drawing.Size(652, 408);
            this.panelSondaje.TabIndex = 14;
            // 
            // panelSondajeButtons
            // 
            this.panelSondajeButtons.AutoScroll = true;
            this.panelSondajeButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelSondajeButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSondajeButtons.Location = new System.Drawing.Point(1, 0);
            this.panelSondajeButtons.Name = "panelSondajeButtons";
            this.panelSondajeButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelSondajeButtons.Size = new System.Drawing.Size(651, 407);
            this.panelSondajeButtons.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(1, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(651, 1);
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
            this.slidingBar.Location = new System.Drawing.Point(70, 96);
            this.slidingBar.Name = "slidingBar";
            this.slidingBar.Size = new System.Drawing.Size(254, 2);
            this.slidingBar.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Sondajele anterioare";
            // 
            // timerSlidingBar
            // 
            this.timerSlidingBar.Interval = 2;
            // 
            // timerSlideInDetails
            // 
            this.timerSlideInDetails.Interval = 2;
            // 
            // VeziSondaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(771, 612);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.panelSondaje);
            this.Controls.Add(this.slidingBar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Leelawadee", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VeziSondaje";
            this.Text = "VeziSondaje";
            this.panelSondaje.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Panel panelSondaje;
        private System.Windows.Forms.Panel panelSondajeButtons;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label slidingBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerSlidingBar;
        private System.Windows.Forms.Timer timerSlideInDetails;
    }
}