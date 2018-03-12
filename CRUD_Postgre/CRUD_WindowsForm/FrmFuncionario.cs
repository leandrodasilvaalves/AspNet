using CRUD_EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CRUD_WindowsForm
{
    public partial class FrmFuncionario : Form
    {
        public FrmFuncionario()
        {
            InitializeComponent();
        }

        public FrmFuncionario(int id)
        {            
            InitializeComponent();
            CarregarFuncionario(id);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            using(var db = new PostgreContext())
            {
                var func = new Funcionario()
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text
                };
                if (txtId.Text == String.Empty)
                    db.Funcionarios.Add(func);
                else
                {
                    func.Id = int.Parse(txtId.Text);
                    db.Entry(func).State = EntityState.Modified;
                }

                db.SaveChanges();
                MessageBox.Show("Funcionário salvo com sucesso.");
                Close();
            }
           
        }

        private void CarregarFuncionario(int id)
        {
            using(var db = new PostgreContext())
            {
                var func = db.Funcionarios.FirstOrDefault(c => c.Id == id);
                txtId.Text = func.Id.ToString();
                txtNome.Text = func.Nome;
                txtEmail.Text = func.Email;
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Deseja realmente excluir o funcionário: { txtNome.Text}?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                using(var db = new PostgreContext())
                {
                    int id = int.Parse(txtId.Text);
                    var func = db.Funcionarios.FirstOrDefault(c => c.Id == id);
                    db.Funcionarios.Remove(func);
                    db.SaveChanges();
                    MessageBox.Show("Funcionário excluído com sucesso.");
                    Close();
                }
            }
        }
    }
}
