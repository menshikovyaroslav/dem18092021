using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Request.Support;
using Support;
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
            IWebDriver driver = new ChromeDriver();
            driver.Url = @"https://bsr.sudrf.ru/bigs/portal.html";
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector(".date-filter-from")).SendKeys(DateTime.Now.AddDays(-30).ToString("d"));
            driver.FindElement(By.CssSelector(".date-filter-to")).SendKeys(DateTime.Now.AddDays(-29).ToString("d"));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@placeholder='Введите номер дела']")).SendKeys("137");

            Console.ReadKey();
        }
    }
}
