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

        /// <summary>
        /// Обработка нажатия кнопки старта парсинга
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void StartParser_Click(object sender, RoutedEventArgs e)
        {
            if (DateFrom.SelectedDate == null || DateTo.SelectedDate == null)
            {
                MessageBox.Show("Проверьте ввод даты начала и даты конца !");
                return;
            }

            var dateFrom = (DateTime)DateFrom.SelectedDate;
            var dateTo = (DateTime)DateTo.SelectedDate;

            IWebDriver driver = new ChromeDriver();
            driver.Url = @"https://bsr.sudrf.ru/bigs/portal.html";

            // ожидаем загрузки страницы
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    driver.FindElement(By.CssSelector(".date-filter-from"));
                    await Task.Delay(1000);
                    break;
                }
                catch (Exception)
                {
                    await Task.Delay(1000);
                }
            }

            driver.FindElement(By.CssSelector(".date-filter-from")).SendKeys(dateFrom.ToString("d"));
            driver.FindElement(By.CssSelector(".date-filter-to")).SendKeys(dateTo.ToString("d"));

            await Task.Delay(1000);

            driver.FindElement(By.XPath("//input[@placeholder='Введите номер дела']")).SendKeys(ClauseCb.Text);
        }
    }
}
