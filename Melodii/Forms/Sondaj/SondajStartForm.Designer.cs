namespace Melodii.Forms.Sondaj
{
    partial class SondajStartForm
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
            this.lbAdresare = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.cbTop3 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbAdresare
            // 
            this.lbAdresare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbAdresare.AutoSize = true;
            this.lbAdresare.Font = new System.Drawing.Font("Leelawadee", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdresare.Location = new System.Drawing.Point(378, 230);
            this.lbAdresare.Name = "lbAdresare";
            this.lbAdresare.Size = new System.Drawing.Size(0, 32);
            this.lbAdresare.TabIndex = 12;
            this.lbAdresare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sondajul consta in ghicirea pozitiilor in top a melodiilor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Leelawadee", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.Location = new System.Drawing.Point(246, 472);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(266, 43);
            this.btOk.TabIndex = 14;
            this.btOk.Text = "Ok, Incepe sondajul";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // cbTop3
            // 
            this.cbTop3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbTop3.AutoSize = true;
            this.cbTop3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.cbTop3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTop3.Location = new System.Drawing.Point(266, 321);
            this.cbTop3.Name = "cbTop3";
            this.cbTop3.Size = new System.Drawing.Size(246, 26);
            this.cbTop3.TabIndex = 15;
            this.cbTop3.Text = "Include doar TOP 3 melodii";
            this.cbTop3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbTop3.UseVisualStyleBackColor = false;
            // 
            // SondajStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(771, 612);
            this.Controls.Add(this.cbTop3);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAdresare);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SondajStartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAdresare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.CheckBox cbTop3;
    }
}