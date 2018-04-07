using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Exemplo.Tests
{
    public class OpenBrowser
    {
        private IWebDriver browser;

        public IWebDriver Open(string NomeBrowser)
        {
            switch (NomeBrowser)
            {
                case "Chrome": this.browser = new ChromeDriver(); break;
                case "Firefox": this.browser = new FirefoxDriver(); break;
                case "IE": this.browser = new InternetExplorerDriver(); break;
                default: break;
            }
            return browser;
        }

    }
}
