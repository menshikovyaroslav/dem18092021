using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Request.Support;
using Support.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestPravosudie
{
    class Program
    {
        static void Main(string[] args)
        {
         //   System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"c:\path\to\driver\chromedriver.exe");
            IWebDriver driver = new ChromeDriver();
            driver.Url = @"https://bsr.sudrf.ru/bigs/portal.html";
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".date-filter-from")).SendKeys(DateTime.Now.AddDays(-30).ToString("d"));
            driver.FindElement(By.CssSelector(".date-filter-to")).SendKeys(DateTime.Now.AddDays(-29).ToString("d"));
            Thread.Sleep(1000);
            //   driver.FindElements(By.CssSelector(".ui-autocomplete-input"))[5].SendKeys("137");

            var els = driver.FindElements(By.CssSelector(".ui-autocomplete-input"));
            var i = 0;
            foreach (var el in els)
            {
                el.SendKeys(i.ToString());
                i++;
            }

            driver.FindElement(By.XPath(@".//input[@id='searchFormButton']")).Click();
            Thread.Sleep(3000);

            var html = driver.PageSource;

            Console.WriteLine(html);


            Console.ReadKey();
        }
    }
}
