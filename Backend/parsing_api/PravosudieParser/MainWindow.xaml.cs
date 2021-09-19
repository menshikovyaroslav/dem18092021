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

            // ввод даты начала и даты конца
            driver.FindElement(By.CssSelector(".date-filter-from")).SendKeys(dateFrom.ToString("d"));
            driver.FindElement(By.CssSelector(".date-filter-to")).SendKeys(dateTo.ToString("d"));

            await Task.Delay(1000);

            // ввод статьи
            driver.FindElement(By.XPath("//input[@placeholder='Введите статью или категорию дела']")).SendKeys(ClauseCb.Text);

            await Task.Delay(500);
            
            // нажать на кнопку Найти
            driver.FindElement(By.XPath("//input[@id='searchFormButton']")).Click();

            await Task.Delay(2000);

            driver.FindElement(By.XPath("//a[contains(.,'Уголовное дело')]")).Click();

            var oldNumber = string.Empty;
            while (true)
            {
                await Task.Delay(3000);

                var number = IsContains(driver, "(//span[contains(@data-pos,'0')])[1]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[1]")).GetAttribute("textContent") : string.Empty;
                var instance = IsContains(driver, "(//span[contains(@data-pos,'0')])[4]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[4]")).GetAttribute("textContent") : string.Empty;
                var clause = IsContains(driver, "(//span[contains(@data-pos,'0')])[5]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[5]")).GetAttribute("textContent") : string.Empty;

                var regionString = IsContains(driver, "(//span[contains(@data-pos,'0')])[6]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[6]")).GetAttribute("textContent") : string.Empty;
                var result = IsContains(driver, "(//span[contains(@data-pos,'0')])[7]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[7]")).GetAttribute("textContent") : string.Empty;

                var judge = IsContains(driver, "(//span[contains(@data-pos,'0')])[2]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[2]")).GetAttribute("textContent") : string.Empty;
                var person = IsContains(driver, "(//td[@class='one-table-value'])[1]") ? driver.FindElement(By.XPath("(//td[@class='one-table-value'])[1]")).GetAttribute("textContent") : string.Empty;


                if (oldNumber == number) break;

                driver.FindElement(By.XPath("(//span[@title='Вперед'])[3]")).Click();
            }
        }

        private bool IsContains(IWebDriver driver, string element)
        {
            try
            {
                var el = driver.FindElement(By.XPath(element)).GetAttribute("textContent");
                if (el == "Не заполнено") return false;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
