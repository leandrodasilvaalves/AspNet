using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_WindowsForm
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnCadFunc_Click(object sender, EventArgs e)
        {
            var frm = new FrmListaFuncionarios();
            frm.ShowDialog();
        }

        private void BtnCadCargo_Click(object sender, EventArgs e)
        {
            var frm = new FrmListaCargos();
            frm.ShowDialog();
        }
    }
}
