using CrudEntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CrudWindwosForm
{
    public partial class FrmCliente : Form
    {
        public FrmCliente(int id)
        {
            InitializeComponent();
            CarregarCliente(id);
        }
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente()
            {
                Nome = txtNome.Text
            };
            var db = new OracleContext();
            if (txtId.Text == String.Empty)
            {
                db.Clientes.Add(cliente);
            }
            else
            {
                cliente.Id = int.Parse(txtId.Text);
                db.Entry(cliente).State = EntityState.Modified;
            }
            db.SaveChanges();
            MessageBox.Show("Cliente salvo com sucesso");
            Close();
        }

        private void CarregarCliente(int id)
        {
            using(var db = new OracleContext())
            {
                var cli = db.Clientes.FirstOrDefault(c => c.Id == id);
                txtId.Text = cli.Id.ToString();
                txtNome.Text = cli.Nome;
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var result = (MessageBox
                .Show($"Deseja realmente excluir o cliente: {txtNome.Text}?","Confirmação",MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if(result == DialogResult.Yes)
            {
                using (var db = new OracleContext())
                {
                    var id = int.Parse(txtId.Text);
                    var cli = db.Clientes.FirstOrDefault(c => c.Id == id);
                    db.Clientes.Remove(cli);
                    db.SaveChanges();
                    MessageBox.Show("Cliente excluído com sucesso.");
                    Close();
                }
            }
        }
    }
}
