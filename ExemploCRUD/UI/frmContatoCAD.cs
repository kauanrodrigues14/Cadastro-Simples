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
    public partial class frmContatoCAD : Form
    {
        public frmContatoCAD()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Instanciar um objeto da camada BLL
            BLL.Amigo obj = new BLL.Amigo();

            //Preencher o objeto BLL com os dados que o usuario
            // informou na interface
            obj.Nome = txtNome.Text;
            obj.Telefone = txtTel.Text;

            //Instanciar um objeto da camada DAL para chamar a acao(metodo)
            // Cadastrar para enviar ao Banco de Dados
            DAL.AmigoDAL objDAL = new DAL.AmigoDAL();
            objDAL.Cadastrar(obj);

            MessageBox.Show("Contato Cadastrado !");
            txtNome.Text = "";
            txtTel.Text = "";
            txtNome.Focus();
        }
    }
}
