using CrudEntityFramework;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CrudWindwosForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            var frm = new FrmCliente();
            frm.ShowDialog();
            ListarClientes();
        }

        private void ListarClientes()
        {
            using (var db = new OracleContext())
            {
                dgvClientes.DataSource = db.Clientes.OrderBy(c => c.Id).ToList();
            }
        }

        private void ListarClientes(string search = "")
        {
            using (var db = new OracleContext())
            {
                dgvClientes.DataSource = db.Clientes
                    .Where(c => c.Nome.ToLower().Contains(search.ToLower()))
                    .OrderBy(c => c.Id).ToList();
            }
        }

        private void DgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString());
            var frm = new FrmCliente(id);
            frm.ShowDialog();
            ListarClientes();

        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if(txtPesquisa.Text == string.Empty)
            {
                ListarClientes();
            }
            else
            {
                ListarClientes(txtPesquisa.Text);
            }
        }
    }
}
