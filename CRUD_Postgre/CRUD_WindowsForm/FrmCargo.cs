using CRUD_EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CRUD_WindowsForm
{
    public partial class FrmCargo : Form
    {
        public FrmCargo()
        {
            InitializeComponent();
        }

        public FrmCargo(int id)
        {
            InitializeComponent();
            CarregarCargo(id);
        }

        private void CarregarCargo(int id)
        {
            using(var db = new PostgreContext())
            {
                var cargo = db.Cargos.FirstOrDefault(c => c.Id == id);
                txtId.Text = cargo.Id.ToString();
                txtDescricao.Text = cargo.Descricao;
            }
        }

        private void FrmCargo_Load(object sender, EventArgs e)
        {
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var cargo = new Cargo()
            {
                Descricao = txtDescricao.Text
            };
            using(var db = new PostgreContext())
            {
                if (txtId.Text == String.Empty)
                {
                    db.Cargos.Add(cargo);
                }
                else
                {
                    cargo.Id = int.Parse(txtId.Text);
                    db.Entry(cargo).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            MessageBox.Show("Cargo salvo com sucesso.");
            Close();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Deseja realmente excluir o cargo: {txtDescricao.Text}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                using(var db = new PostgreContext())
                {
                    int id = int.Parse(txtId.Text);
                    var cargo = db.Cargos.FirstOrDefault(c => c.Id == id);
                    db.Cargos.Remove(cargo);
                    db.SaveChanges();
                    MessageBox.Show("Cargo excluído com sucesso.");
                    Close();
                }
            }
        }
    }
}
