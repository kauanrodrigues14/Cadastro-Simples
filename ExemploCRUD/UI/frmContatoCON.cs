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
    public partial class frmContatoCON : Form
    {
        public frmContatoCON()
        {
            InitializeComponent();
        }

        BLL.Amigo a = new BLL.Amigo();
        DAL.AmigoDAL aDAL = new DAL.AmigoDAL();

        private void frmContatoCON_Load(object sender, EventArgs e)
        {
            //Preencher a fonte de dados da DataGridView
            dgvResultado.DataSource = aDAL.Consultar();

            //Ocultar os botoes laterais
            dgvResultado.RowHeadersVisible = false;

            //Selecionar a linha inteira
            dgvResultado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Nao permitir selecao multipla
            dgvResultado.MultiSelect = false;

            //Ajustar a largura das colunas em toda area disponivel
            dgvResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Nao permitir reajuste de altura das linhas
            dgvResultado.AllowUserToResizeRows = false;

            //Nao permitir reajuste de largura das colunas
            dgvResultado.AllowUserToResizeColumns = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvResultado.SelectedCells.Count > 0)
            {
                DialogResult resposta;
                string nomeSelecionado;
                nomeSelecionado = dgvResultado.SelectedCells[1].Value.ToString();

                resposta =
                MessageBox.Show("Deseja realmente excluir o contato " + nomeSelecionado + " ?",
                                 "Confirmação",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button2);

                if (resposta == DialogResult.Yes)
                {
                    int idSelecionado;

                    //idSelecionado = int.Parse( dgvResultado.SelectedCells[0].Value.ToString() ) ;
                    idSelecionado = Convert.ToInt32(dgvResultado.SelectedCells[0].Value);

                    a.Id = idSelecionado;
                    aDAL.Excluir(a);

                    frmContatoCON_Load(null, null); //Reexecuta o Metodo LOAD

                    MessageBox.Show("Registro Excluido !");
                }
                else
                {
                    MessageBox.Show("Operacao Cancelada !");
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //preencher o obj BLL com os dados da interface(filtro)
            a.Nome = txtFiltro.Text;
            dgvResultado.DataSource = aDAL.Consultar(a);
        }

        private void dgvResultado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idSelecionado;
            idSelecionado = Convert.ToInt32( dgvResultado.SelectedCells[0].Value );

            frmContatoATU tela = new frmContatoATU(idSelecionado);
            tela.ShowDialog();

            btnFiltrar.PerformClick();
        }
    }
}
