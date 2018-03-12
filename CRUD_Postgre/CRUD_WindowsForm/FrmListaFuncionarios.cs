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
                var funcionarios = (from f in db.Funcionarios
                                    orderby f.Id
                                    select new
                                    {
                                        Id = f.Id,
                                        Nome = f.Nome,
                                        Email = f.Email,
                                        Cargo = f.Cargo.Descricao
                                    }).ToList();

                dgvFuncionarios.DataSource = funcionarios;
            }
        }

        private void ListarTodos(string buscar)
        {
            using (var db = new PostgreContext())
            {
                buscar = buscar.ToLower();
                var funcionarios = (from f in db.Funcionarios
                                    where ( f.Nome.ToLower().Contains(buscar)||
                                            f.Email.ToLower().Contains(buscar) ||
                                            f.Cargo.Descricao.ToLower().Contains(buscar))
                                    orderby f.Id
                                    select new
                                    {
                                        Id = f.Id,
                                        Nome = f.Nome,
                                        Email = f.Email,
                                        Cargo = f.Cargo.Descricao
                                    }).ToList();

                dgvFuncionarios.DataSource = funcionarios;
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
