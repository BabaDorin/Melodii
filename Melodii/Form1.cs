﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Melodii.DesignFunctionalities;
using Melodii.Forms;

namespace Melodii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panelMelodiiSubmenu.Visible = false;
            panelParticipantiSubmenu.Visible = false;
            openChildForm(new HomeForm(), panelFormsArea);
        }

        private void btnMelodii_Click(object sender, EventArgs e)
        {
            //La fiecare click, submeniul va aparea sau va disparea.
            Toggle(panelMelodiiSubmenu);
        }

        private void btnParticipanti_Click(object sender, EventArgs e)
        {
            //La fiecare click, submeniul va aparea sau va disparea.
            Toggle(panelParticipantiSubmenu);
        }

        private void btnAdaugaMelodii_Click(object sender, EventArgs e)
        {
            openChildForm(new AdaugaMelodieForm(), panelFormsArea);
        }

        private void btnExcludeMelodii_Click(object sender, EventArgs e)
        {

        }

        private void btnVeziMelodii_Click(object sender, EventArgs e)
        {
        
        }

        private void btnAdaugaParticipanti_Click(object sender, EventArgs e)
        {

        }

        private void btnVeziParticipanti_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openChildForm(new HomeForm(), panelFormsArea);
        }
    }
}