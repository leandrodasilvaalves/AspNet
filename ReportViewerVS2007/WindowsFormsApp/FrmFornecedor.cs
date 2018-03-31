using Microsoft.Reporting.WinForms;
using Model.Context;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp.Report;

namespace WindowsFormsApp
{
    public partial class FrmFornecedor : Form
    {
        public FrmFornecedor()
        {
            InitializeComponent();
        }

        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            using (var db = new Contexto())
            {
                var dadosRelatorio = (from p in db.Produtos
                                      select new DadosRelatorioFornecedor
                                      {                                          
                                          SupplierID = p.Fornecedor.SupplierID,
                                          CompanyName = p.Fornecedor.CompanyName,
                                          ContactName = p.Fornecedor.ContactName,
                                          ProductID = p.ProductID,
                                          ProductName = p.ProductName,
                                          UnitPrice = p.UnitPrice
                                      }).ToArray();

                var dataSource = new ReportDataSource("DataSetFornecedor", dadosRelatorio);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
