namespace Melodii.Forms
{
    partial class AdaugaParticipantForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbScor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNume = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbEroare = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.tbInformatii = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbVarsta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(471, 9);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(50);
            this.label6.Size = new System.Drawing.Size(288, 75);
            this.label6.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(76, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(391, 1);
            this.label4.TabIndex = 17;
            // 
            // tbScor
            // 
            this.tbScor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.tbScor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbScor.Font = new System.Drawing.Font("Leelawadee", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScor.ForeColor = System.Drawing.Color.Gray;
            this.tbScor.Location = new System.Drawing.Point(76, 362);
            this.tbScor.Name = "tbScor";
            this.tbScor.Size = new System.Drawing.Size(584, 23);
            this.tbScor.TabIndex = 16;
            this.tbScor.Tag = "Scorul (optional, Implicit 0)";
            this.tbScor.Text = "Scorul (optional, Implicit 0)";
            this.tbScor.Enter += new System.EventHandler(this.tb_Enter);
            this.tbScor.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(76, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(391, 1);
            this.label3.TabIndex = 15;
            // 
            // tbNume
            // 
            this.tbNume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.tbNume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNume.Font = new System.Drawing.Font("Leelawadee", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNume.ForeColor = System.Drawing.Color.Gray;
            this.tbNume.Location = new System.Drawing.Point(76, 154);
            this.tbNume.Name = "tbNume";
            this.tbNume.Size = new System.Drawing.Size(584, 23);
            this.tbNume.TabIndex = 14;
            this.tbNume.Tag = "Numele";
            this.tbNume.Text = "Numele";
            this.tbNume.Enter += new System.EventHandler(this.tb_Enter);
            this.tbNume.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // btSave
            // 
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Location = new System.Drawing.Point(76, 445);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(261, 41);
            this.btSave.TabIndex = 13;
            this.btSave.Text = "Inregistreaza participantul";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(76, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 2);
            this.label2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Inregistreaza un participant";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbEroare
            // 
            this.lbEroare.AutoSize = true;
            this.lbEroare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbEroare.Location = new System.Drawing.Point(72, 514);
            this.lbEroare.Name = "lbEroare";
            this.lbEroare.Size = new System.Drawing.Size(0, 20);
            this.lbEroare.TabIndex = 21;
            // 
            // timer2
            // 
            this.timer2.Interval = 6;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 2000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(76, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(391, 1);
            this.label7.TabIndex = 23;
            // 
            // tbInformatii
            // 
            this.tbInformatii.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.tbInformatii.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInformatii.Font = new System.Drawing.Font("Leelawadee", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInformatii.ForeColor = System.Drawing.Color.Gray;
            this.tbInformatii.Location = new System.Drawing.Point(76, 292);
            this.tbInformatii.Name = "tbInformatii";
            this.tbInformatii.Size = new System.Drawing.Size(584, 23);
            this.tbInformatii.TabIndex = 22;
            this.tbInformatii.Tag = "Informatii (optional)";
            this.tbInformatii.Text = "Informatii (optional)";
            this.tbInformatii.Enter += new System.EventHandler(this.tb_Enter);
            this.tbInformatii.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(76, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(391, 1);
            this.label5.TabIndex = 25;
            // 
            // tbVarsta
            // 
            this.tbVarsta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.tbVarsta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVarsta.Font = new System.Drawing.Font("Leelawadee", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVarsta.ForeColor = System.Drawing.Color.Gray;
            this.tbVarsta.Location = new System.Drawing.Point(76, 223);
            this.tbVarsta.Name = "tbVarsta";
            this.tbVarsta.Size = new System.Drawing.Size(584, 23);
            this.tbVarsta.TabIndex = 24;
            this.tbVarsta.Tag = "Varsta";
            this.tbVarsta.Text = "Varsta";
            this.tbVarsta.Enter += new System.EventHandler(this.tb_Enter);
            this.tbVarsta.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // AdaugaParticipantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(771, 612);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbVarsta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbInformatii);
            this.Controls.Add(this.lbEroare);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbScor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNume);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdaugaParticipantForm";
            this.Text = "AdaugaParticipantiForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbScor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNume;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbEroare;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbInformatii;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbVarsta;
    }
}