using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void contatosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmContatoCAD"] == null)
            {
                UI.frmContatoCAD tela = new UI.frmContatoCAD();
                tela.MdiParent = this;
                tela.Show();
            }
            else
            {
                Application.OpenForms["frmContatoCAD"].WindowState =
                    FormWindowState.Normal;
                Application.OpenForms["frmContatoCAD"].Focus();
            }
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmContatoCON tela = new UI.frmContatoCON();
            tela.MdiParent = this;
            tela.Show();
        }
    }
}
