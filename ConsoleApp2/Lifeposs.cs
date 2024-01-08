using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace ConsoleApp2
{
    [TestFixture]
    class Lifeposs
    {
        IWebDriver driver = new ChromeDriver();
        private readonly By _signInButton = By.XPath("//a[normalize-space(.)='Заведите аккаунт']");
        private readonly By _numberRegInputButton = By.XPath("//input[@type='tel']");
        private readonly By _errorNumber = By.XPath("//small[normalize-space(text())='Неверный формат']");
        private readonly By _name = By.XPath("//input[@class='classList ng-untouched ng-pristine ng-valid ng-star-inserted']/..//input[@type='text']");
        private readonly By _errorName = By.XPath("//small[normalize-space(text())='Значение не может начинаться и заканчиваться пробелом']");
        private readonly By _password = By.XPath("//input[@class='classList ng-untouched ng-pristine ng-valid ng-star-inserted']/..//input[@type='password']");
        private readonly By _errorName2 = By.XPath("//small[normalize-space(text())='Значение должно быть не менее 5 знаков']");
        private readonly By _errorPassword = By.XPath("//small[normalize-space(text())='Значение должно быть не менее 6 знаков']");
        private readonly By _passwordInputInserted = By.XPath("//div[@class='svg-wrapper password-input ng-star-inserted']");
        private readonly By _deletedName = By.XPath("//input[@class='ng-valid ng-star-inserted ng-dirty ng-touched classList text-danger']/..//div[@class='svg-wrapper ng-star-inserted']");
        private readonly By _buttonCod = By.XPath("//div[contains(concat(' ',@class,' '),'button') and normalize-space(.)='Отправить код']");
        private readonly By _smsButton = By.XPath("//input[@class='classList ng-untouched ng-pristine ng-star-inserted ng-valid']/..//input[@type='text']");
        private readonly By _errorSms = By.XPath("//small[normalize-space(text())='Неверный код']");
        private readonly By _title = By.XPath("//h2[normalize-space(text())='Добрый день! 👋🏻']");



        [SetUp]

        public void initialize()
        {
            driver.Navigate().GoToUrl("https://my.life-pos.ru/auth/login");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

        }

        [Test]


        public void Авто_Регистрация_нового_пользователя_не_успех()
        {
            var titleDay = driver.FindElement(_title);
            Thread.Sleep(2000);
            var signin = driver.FindElement(_signInButton);
            signin.Click();
            Thread.Sleep(2000);
            var number_reg = driver.FindElement(_numberRegInputButton);
            number_reg.SendKeys("+7(916)123456");
            Thread.Sleep(2000);
            var errorMessage = driver.FindElement(_errorNumber);
            number_reg.Clear();
            number_reg.SendKeys("+7(916)1234567");
            var name = driver.FindElement(_name);
            name.SendKeys(" ");
            Thread.Sleep(5000);
            var errorMessageName = driver.FindElement(_errorName);
            name.Clear();
            Thread.Sleep(5000);
            name.SendKeys("test");        
            var errorMessageName2 = driver.FindElement(_errorName2);
            name.Clear();
            name.SendKeys("Сергей ");
            Thread.Sleep(4000);
            name.Clear();
            name.SendKeys("Тест Тестовый");
            var password = driver.FindElement(_password);
            password.SendKeys("12345");
            Thread.Sleep(5000);
            var errorMessagePassword = driver.FindElement(_errorPassword);
            password.Clear();
            password.SendKeys(" ");
            var errorMessagePassword2 = driver.FindElement(_errorName);
            Thread.Sleep(5000);
            password.Clear();
            password.SendKeys("123456");
            var passwordInputInserted = driver.FindElement(_passwordInputInserted);
            passwordInputInserted.Click();
            var button = driver.FindElement(_buttonCod);
            button.Click();
            Thread.Sleep(4000);
            var sms = driver.FindElement(_smsButton);
            sms.SendKeys("1234");
            sms.Clear();
            sms.SendKeys("123456");
            Thread.Sleep(4000);
            var smserror = driver.FindElement(_errorSms);
           

        }

        [TearDown]

        public void closepage()
        {
           
            //driver.Quit();
        }

    }
}
