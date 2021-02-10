using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
namespace ibar
{
    public class TestLanguageSwitch
    {
        [SetUp]
        public void Setup()
        {

        }
        IWebDriver driver = new ChromeDriver();

        public void verifyLang(string text)
        {
            IWebElement ts = driver.FindElement(By.XPath("//section[3]/div/div/div/h3"));
            Assert.AreEqual(ts.Text, text);
        }

        [Test]
        public void changeLangAz()
        {
            driver.Navigate().GoToUrl("https://ibar.az/");
            var selectElement = driver.FindElement(By.CssSelector("#js-selectric-lang"));
            //   new WebDriverWait(driver, 15).Until(ExpectedConditions.ElementToBeClickable(selectElement));
            var select = new SelectElement(selectElement);
            select.SelectByText("AZ");
            verifyLang("Kredit kalkulyatoru");
        }
        [Test]
        public void changeLangEn()
        {
            driver.Navigate().GoToUrl("https://ibar.az/");
            SelectElement select=new SelectElement(driver.FindElement(By.Id("js-selectric-lang")));
            select.SelectByValue("uk");
            verifyLang("Loan calculator");
        }
        [Test]
        public void changeLangRu()
        {
            driver.Url="https://ibar.az";
            var selectElement = driver.FindElement(By.CssSelector("#js-selectric-lang"));
            selectElement.Click();
            Thread.Sleep(2000);
            var select = new SelectElement(selectElement);
            select.SelectByIndex(1);
            verifyLang("Кредитный калькулятор");
        }
    }


    public class TestLoanCalculator
    {
        IWebDriver driver = new ChromeDriver();

           [Test]
        public void CalculateLoan()
        {
            driver.Navigate().GoToUrl("https://ibar.az");
            var first=driver.FindElement(By.Id("js-range-slider-output-0"));
            first.Clear();
            first.SendKeys("7500");
            first.Clear();
            // todo: try with slider
            //var slider = driver.FindElement(By.Id("js-rangeslider-js-0"));
            //Actions move = new Actions(driver);
            //move.DragAndDropToOffset(slider, 30, 0).Perform();
            //Assert.AreEqual("15%",driver.FindElement(By.Id("js-range-slider-output-0")));
            //Thread.Sleep(1000);
            var second = driver.FindElement(By.Id("js-range-slider-output-01"));
            second.Clear();
            second.SendKeys("12");
            Thread.Sleep(1000);
            var third= driver.FindElement(By.Id("js-range-slider-output-02"));
            third.Clear();
            third.SendKeys("20");
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Onlayn müraciət et")).Click();
        }
    }
}