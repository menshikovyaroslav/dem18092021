using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PravosudieParser.Data;
using Support;
using Support.Extensions;
using Support.Models;
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
                await Task.Delay(2200);

                // Проверка на появление captcha
                try
                {
                    var isCaptcha = driver.FindElement(By.Id("modalWindow_capchaDialog"));

                    MessageBox.Show("Требуется ввести данные captcha");
                }
                catch (Exception)
                {
                }

                try
                {
                    var number = IsContains(driver, "(//span[contains(@data-pos,'0')])[1]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[1]")).GetAttribute("textContent") : string.Empty;
                    var instance = IsContains(driver, "(//span[contains(@data-pos,'0')])[4]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[4]")).GetAttribute("textContent") : string.Empty;
                    var clause = IsContains(driver, "(//span[contains(@data-pos,'0')])[5]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[5]")).GetAttribute("textContent") : string.Empty;

                    var regionString = IsContains(driver, "(//span[contains(@data-pos,'0')])[6]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[6]")).GetAttribute("textContent") : string.Empty;
                    var result = IsContains(driver, "(//span[contains(@data-pos,'0')])[7]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[7]")).GetAttribute("textContent") : string.Empty;

                    var judge = IsContains(driver, "(//span[contains(@data-pos,'0')])[2]") ? driver.FindElement(By.XPath("(//span[contains(@data-pos,'0')])[2]")).GetAttribute("textContent") : string.Empty;
                    var person = driver.FindElement(By.XPath("(//td[@class='one-table-value'])[1]")).Displayed ? driver.FindElement(By.XPath("(//td[@class='one-table-value'])[1]")).GetAttribute("textContent") : string.Empty;

                    var sud = IsContains(driver, "//a[contains(@href,'name\"}}')]") ? driver.FindElement(By.XPath("//a[contains(@href,'name\"}}')]")).GetAttribute("textContent") : string.Empty;

                    // //a[contains(@href,'name"}}')]

                    driver.FindElement(By.XPath("//label[contains(.,'Движение по делу')]")).Click();
                    await Task.Delay(500);

                    var html = driver.PageSource;

                    Log.Instance.Info(html);

                    var dateInString = string.Empty;

                    var dataInStart = html.IndexOf($"{number}</a>");
                    dataInStart = html.IndexOf("data-comment=\"Дата поступления\"", dataInStart) + 32;
                    dataInStart = html.IndexOf("\">", dataInStart) + 2;
                    var dataInEnd = html.IndexOf("<", dataInStart);
                    dateInString = html.Substring(dataInStart, dataInEnd - dataInStart);

                    driver.FindElement(By.XPath("//label[contains(.,'Дело')]")).Click();
                    await Task.Delay(500);

                    if (oldNumber == number) break;

                    oldNumber = number;
                    var parsingObject = new ParsingResponse()
                    {
                        Number = number,
                        Instance = instance,
                        Clause = clause,
                        Region = regionString,
                        DecisionText = result,
                        Fio = person,
                        Judge = judge,
                        Sud = sud
                    };
                    if (!dateInString.IsEmpty()) parsingObject.DateIn = DateTime.Parse(dateInString);

                    // Запись в БД найденный кейс
                    DataBase.CreateCase(parsingObject);

                    driver.FindElement(By.XPath("(//span[@title='Вперед'])[3]")).Click();
                }
                catch (Exception ex)
                {
                    Log.Instance.Error(7, ex.Message);
                }
            }

            driver.Quit();
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
