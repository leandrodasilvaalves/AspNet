using CRUD_EntityFramework;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CRUD_WindowsForm
{
    public partial class FrmListaCargos : Form
    {
        public FrmListaCargos()
        {
            InitializeComponent();
        }

        private void FrmListaCargos_Load(object sender, EventArgs e)
        {

            ListarTodos();
        }

        private void ListarTodos()
        {
            using(var db = new PostgreContext())
            {
                var cargos = (from c in db.Cargos
                              orderby c.Id
                              select new { Id = c.Id, Descricao = c.Descricao }).ToList();
                dgvCargos.DataSource = cargos;
            }
        }

        private void ListarTodos(string buscar)
        {
            using (var db = new PostgreContext())
            {
                buscar = buscar.ToLower();
                var cargos = (from c in db.Cargos
                              where c.Descricao.ToLower().Contains(buscar)
                              orderby c.Id
                              select new { Id = c.Id, Descricao = c.Descricao }).ToList();
                dgvCargos.DataSource = cargos;
            }
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            ListarTodos(txtPesquisa.Text);
        }

        private void DgvCargos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvCargos.Rows[e.RowIndex].Cells[0].Value.ToString());
            var frm = new FrmCargo(id);
            frm.ShowDialog();
            ListarTodos();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            var frm = new FrmCargo();
            frm.ShowDialog();
            ListarTodos();
        }
    }

}
