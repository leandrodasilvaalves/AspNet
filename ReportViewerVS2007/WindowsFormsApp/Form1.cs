using Microsoft.Reporting.WinForms;
using Model.Context;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp.Report;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using(var db = new Contexto())
            {
                var dadosRelatorio = (from p in db.Produtos
                                      select new DadosRelatorioProduto
                                      {
                                          CategoryID = p.CategoryID,
                                          CategoryName = p.Categoria.CategoryName,
                                          Description = p.Categoria.Description,
                                          SupplierID = p.Fornecedor.SupplierID,
                                          CompanyName =  p.Fornecedor.CompanyName,
                                          ContactName = p.Fornecedor.ContactName,
                                          ProductID = p.ProductID,
                                          ProductName = p.ProductName,
                                          UnitPrice = p.UnitPrice
                                      }).ToArray();

                var dataSource = new ReportDataSource("DataSetProduto", dadosRelatorio);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(dataSource);
                this.reportViewer.RefreshReport();
            }
            this.reportViewer.RefreshReport();
        }
    }
}
