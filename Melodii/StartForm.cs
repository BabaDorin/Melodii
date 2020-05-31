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
using System.Diagnostics;
using System.Data.SqlClient;
using Melodii.Forms.Sondaj;

namespace Melodii
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            panelMelodiiSubmenu.Visible = false;
            panelParticipantiSubmenu.Visible = false;
            panelSondajSubmenu.Visible = false;
            openChildForm(new HomeForm(), panelFormsArea);
        }

        private void btnMelodii_Click(object sender, EventArgs e)
        {
            //La fiecare click, submeniul va aparea sau va disparea.
            Toggle(btnMelodii, panelMelodiiSubmenu);
        }

        private void btnParticipanti_Click(object sender, EventArgs e)
        {
            //La fiecare click, submeniul va aparea sau va disparea.
            Toggle(btnParticipanti, panelParticipantiSubmenu);
        }

        private void btnAdaugaMelodii_Click(object sender, EventArgs e)
        {
            openChildForm(new AdaugaMelodieForm(), panelFormsArea);
        }

        private void btnVeziMelodii_Click(object sender, EventArgs e)
        {
            openChildForm(new VeziMelodiiForm(), panelFormsArea);
        }

        private void btnAdaugaParticipanti_Click(object sender, EventArgs e)
        {
            openChildForm(new AdaugaParticipantForm(), panelFormsArea);
        }

        private void btnVeziParticipanti_Click(object sender, EventArgs e)
        {
            openChildForm(new VeziParticipantiForm(), panelFormsArea);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openChildForm(new HomeForm(), panelFormsArea);
        }

        private void btnSondaj_Click(object sender, EventArgs e)
        {
            //La fiecare click, submeniul va aparea sau va disparea.
            Toggle(btnSondaj, panelSondajSubmenu);
        }

        private void btnVeziSondaje_Click(object sender, EventArgs e)
        {
            openChildForm(new VeziSondajeForm(), panelFormsArea);
        }
    }
}