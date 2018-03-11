using CRUD_EntityFramework;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CRUD_WindowsForm
{
    public partial class FrmListaFuncionarios : Form
    {
        public FrmListaFuncionarios()
        {
            InitializeComponent();
        }

        private void FrmListaFuncionarios_Load(object sender, EventArgs e)
        {
            ListarTodos();
        }

        private void ListarTodos()
        {
            using(var db = new PostgreContext())
            {
                dgvFuncionarios.DataSource = db.Funcionarios.ToList();
            }
        }

        private void ListarTodos(string buscar)
        {
            using (var db = new PostgreContext())
            {
                dgvFuncionarios.DataSource = db.Funcionarios
                    .Where(c => c.Nome.ToLower().Contains(buscar.ToLower()) ||
                                c.Email.ToLower().Contains(buscar.ToLower())).ToList();
            }
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if(txtPesquisa.Text == String.Empty)
                ListarTodos();
            else
                ListarTodos(txtPesquisa.Text);
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            var frmCadFunc = new FrmFuncionario();
            frmCadFunc.ShowDialog();
            ListarTodos();
        }

        private void DgvFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = int.Parse(dgvFuncionarios.Rows[e.RowIndex].Cells[0].Value.ToString());
            var frmCadFunc = new FrmFuncionario(id);
            frmCadFunc.ShowDialog();
            ListarTodos();
        }
    }
}
