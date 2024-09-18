using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploCRUD.UI
{
    public partial class frmContatoATU : Form
    {
        BLL.Amigo a = new BLL.Amigo();
        DAL.AmigoDAL aDAL = new DAL.AmigoDAL();

        //Metodo Construtor
        public frmContatoATU(int i)
        {
            InitializeComponent();
            a.Id = i;
            a = aDAL.PreencherPeloId(a);
            if(a.Id == 0)
            {
                MessageBox.Show("Registro nao encontrado !");
                btnAtualizar.Enabled = false;
            }
            else
            {
                txtId.Text = a.Id.ToString();
                txtNome.Text = a.Nome;
                txtTel.Text = a.Telefone;
            }
            
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            a.Id        = int.Parse(txtId.Text);
            a.Nome      = txtNome.Text;
            a.Telefone  = txtTel.Text;

            aDAL.Atualizar(a);
            this.Close();
        }
    }
}
