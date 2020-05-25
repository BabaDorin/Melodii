namespace Melodii.Forms
{
    partial class AdaugaMelodieForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.slidingBar = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btSave = new System.Windows.Forms.Button();
            this.tbDenumire = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbInterpret = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbGen = new System.Windows.Forms.TextBox();
            this.lbEroare = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.tbPuncte = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbInformatii = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adauga o melodie";
            // 
            // slidingBar
            // 
            this.slidingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.slidingBar.Location = new System.Drawing.Point(76, 103);
            this.slidingBar.Name = "slidingBar";
            this.slidingBar.Size = new System.Drawing.Size(224, 2);
            this.slidingBar.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btSave
            // 
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Location = new System.Drawing.Point(76, 495);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(261, 41);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Inscrie melodia in concurs";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbDenumire
            // 
            this.tbDenumire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.tbDenumire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDenumire.Font = new System.Drawing.Font("Leelawadee", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDenumire.ForeColor = System.Drawing.Color.Gray;
            this.tbDenumire.Location = new System.Drawing.Point(76, 149);
            this.tbDenumire.Name = "tbDenumire";
            this.tbDenumire.Size = new System.Drawing.Size(584, 23);
            this.tbDenumire.TabIndex = 3;
            this.tbDenumire.Tag = "Denumirea";
            this.tbDenumire.Text = "Denumirea";
            this.tbDenumire.Enter += new System.EventHandler(this.tb_Enter);
            this.tbDenumire.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(76, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(391, 1);
            this.label3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(76, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(391, 1);
            this.label4.TabIndex = 6;
            // 
            // tbInterpret
            // 
            this.tbInterpret.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.tbInterpret.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInterpret.Font = new System.Drawing.Font("Leelawadee", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInterpret.ForeColor = System.Drawing.Color.Gray;
            this.tbInterpret.Location = new System.Drawing.Point(76, 217);
            this.tbInterpret.Name = "tbInterpret";
            this.tbInterpret.Size = new System.Drawing.Size(584, 23);
            this.tbInterpret.TabIndex = 5;
            this.tbInterpret.Tag = "Interpretul";
            this.tbInterpret.Text = "Interpretul";
            this.tbInterpret.Enter += new System.EventHandler(this.tb_Enter);
            this.tbInterpret.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(76, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(391, 1);
            this.label5.TabIndex = 8;
            // 
            // tbGen
            // 
            this.tbGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.tbGen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbGen.Font = new System.Drawing.Font("Leelawadee", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGen.ForeColor = System.Drawing.Color.Gray;
            this.tbGen.Location = new System.Drawing.Point(76, 287);
            this.tbGen.Name = "tbGen";
            this.tbGen.Size = new System.Drawing.Size(584, 23);
            this.tbGen.TabIndex = 7;
            this.tbGen.Tag = "Genul muzical";
            this.tbGen.Text = "Genul muzical";
            this.tbGen.Enter += new System.EventHandler(this.tb_Enter);
            this.tbGen.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // lbEroare
            // 
            this.lbEroare.AutoSize = true;
            this.lbEroare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbEroare.Location = new System.Drawing.Point(76, 565);
            this.lbEroare.Name = "lbEroare";
            this.lbEroare.Size = new System.Drawing.Size(0, 20);
            this.lbEroare.TabIndex = 9;
            // 
            // timer2
            // 
            this.timer2.Interval = 6;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(471, 9);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(50);
            this.label6.Size = new System.Drawing.Size(288, 75);
            this.label6.TabIndex = 10;
            // 
            // timer3
            // 
            this.timer3.Interval = 2000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(76, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(391, 1);
            this.label7.TabIndex = 12;
            // 
            // tbPuncte
            // 
            this.tbPuncte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.tbPuncte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPuncte.Font = new System.Drawing.Font("Leelawadee", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPuncte.ForeColor = System.Drawing.Color.Gray;
            this.tbPuncte.Location = new System.Drawing.Point(76, 358);
            this.tbPuncte.Name = "tbPuncte";
            this.tbPuncte.Size = new System.Drawing.Size(584, 23);
            this.tbPuncte.TabIndex = 11;
            this.tbPuncte.Tag = "Puncte";
            this.tbPuncte.Text = "Puncte";
            this.tbPuncte.Enter += new System.EventHandler(this.tb_Enter);
            this.tbPuncte.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(77, 456);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(391, 1);
            this.label8.TabIndex = 14;
            // 
            // tbInformatii
            // 
            this.tbInformatii.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.tbInformatii.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInformatii.Font = new System.Drawing.Font("Leelawadee", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInformatii.ForeColor = System.Drawing.Color.Gray;
            this.tbInformatii.Location = new System.Drawing.Point(77, 431);
            this.tbInformatii.Name = "tbInformatii";
            this.tbInformatii.Size = new System.Drawing.Size(584, 23);
            this.tbInformatii.TabIndex = 13;
            this.tbInformatii.Tag = "Informatii (optional)";
            this.tbInformatii.Text = "Informatii (optional)";
            this.tbInformatii.Enter += new System.EventHandler(this.tb_Enter);
            this.tbInformatii.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // AdaugaMelodieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(7)))), ((int)(((byte)(36)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(771, 612);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbInformatii);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPuncte);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbEroare);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbGen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbInterpret);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDenumire);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.slidingBar);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdaugaMelodieForm";
            this.Text = "Adauga";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label slidingBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox tbDenumire;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbInterpret;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbGen;
        private System.Windows.Forms.Label lbEroare;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbInformatii;
        private System.Windows.Forms.TextBox tbPuncte;
    }
}