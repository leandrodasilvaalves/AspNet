using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace _1Exemplo.Tests
{
    [Binding]
    public class CadastroDeUsuariosSteps
    {
        IWebDriver browser;
        static string urlBase = "http://localhost:52232/";

        [BeforeFeature]
        public static void CleanBaseStart() => LimparBaseDeDados();

        public void Init(string nomeBrowser)
        {
            browser = new OpenBrowser().Open(nomeBrowser);
        }
        
        public void Close()
        {
            Thread.Sleep(2000); //<== Somente para visualizar o teste rodando. Em um teste real este 'sleep' não deverá existir
            browser.Close();
            browser.Dispose();
        }

        [Given(@"usuario se encontra na pagina de registro")]
        public void DadoUsuarioSeEncontraNaPaginaDeRegistro(Table table)
        {
            var row = table.Rows[0];

            Init(row[3]);
            browser.Navigate().GoToUrl(urlBase + "Account/Register");

            var email = browser.FindElement(By.Id("Email"));
            email.SendKeys(row[0]);

            var password = browser.FindElement(By.Id("Password"));
            password.SendKeys(row[1]);

            var confirmPassword = browser.FindElement(By.Id("ConfirmPassword"));
            confirmPassword.SendKeys(row[2]);
        }
        
        [When(@"clicar no botao Register")]
        public void QuandoClicarNoBotaoRegister()
        {
            var btnRegister = browser.FindElement(By.Id("btnRegister"));
            Thread.Sleep(2000);
            btnRegister.Click();
        }
        
        [Then(@"o usuario será autenticado")]
        public void EntaoOUsuarioSeraAutenticado()
        {
            var loggedUser = browser.FindElement(By.Id("userLogged"));
            Regex regex = new Regex(@"Hello\s\w+@\w+\.\w{3}!");
            Assert.AreEqual(true, regex.IsMatch(loggedUser.Text));
            Close();
            LimparBaseDeDados();
        }


        [Given(@"usuario se encontra na pagina de login")]
        public void DadoUsuarioSeEncontraNaPaginaDeLogin(Table table)
        {
            InserirLoginTeste();

            var row = table.Rows[0];
            Init(row[2]);

            browser.Navigate().GoToUrl(urlBase + "Account/Login");            

            var email = browser.FindElement(By.Id("Email"));
            email.SendKeys(row[0].ToString());

            var password = browser.FindElement(By.Id("Password"));
            password.SendKeys(row[1].ToString());
        }

        [When(@"clicar no botao login")]
        public void QuandoClicarNoBotaoLogin()
        {
            var btnLogin = browser.FindElement(By.Id("btnLogin"));
            Thread.Sleep(1000);
            btnLogin.Click();
        }




        #region [ Private Methods ]

        private static void InserirLoginTeste()
        {            
            string sql = "INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e99a4ba7-90cc-44a2-a3d5-3bf579e3bcd8', N'leandro@gmail.com', 0, N'AAE0CDou9qGV6+osEBCyWtHuB5CQVbelDMfa9quGN31R89LXuxXW71qFTpac7e6aLw==', N'ce21fd63-8d84-41ce-8717-06430be9d54e', NULL, 0, 0, NULL, 1, 0, N'leandro@gmail.com')";
            ExecutarAcaoNoBancoDeDados(sql);
        }

        private static void LimparBaseDeDados()
        {
            string sql = "delete from dbo.AspNetUsers;";
            ExecutarAcaoNoBancoDeDados(sql);
        }

        private static void ExecutarAcaoNoBancoDeDados(string sql)
        {
            string strcon = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\leandro.alves\source\repos\UsandoBDD\1Exemplo\App_Data\aspnet-1Exemplo-20180407122646.mdf;Initial Catalog=aspnet-1Exemplo-20180407122646;Integrated Security=True";
            var con = new SqlConnection(strcon);
            con.Open();
            var cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}
