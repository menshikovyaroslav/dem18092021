using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PravosudieParser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartParser_Click(object sender, RoutedEventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = @"https://bsr.sudrf.ru/bigs/portal.html";
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector(".date-filter-from")).SendKeys(DateTime.Now.AddDays(-30).ToString("d"));
            driver.FindElement(By.CssSelector(".date-filter-to")).SendKeys(DateTime.Now.AddDays(-29).ToString("d"));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@placeholder='Введите номер дела']")).SendKeys("137");
        }
    }
}
