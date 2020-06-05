using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsForCalculates
{
    [TestFixture]
    class AvtoTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

           //  string test = Directory.GetCurrentDirectory();
           //  Console.WriteLine(test);
           //  test = test + "\\TestsForCalculates\\Properties\\Calculator.html";
           //  Console.WriteLine(test);
           // driver.Navigate().GoToUrl(test);
            driver.Navigate().GoToUrl("C:\\Users\\Rafael\\source\\repos\\TestsForCalculates\\TestsForCalculates\\Properties\\Calculator.html");
        }

        [TestCase("1", "1")]
        [TestCase("2", "2")]
        [TestCase("3", "3")]
        [TestCase("4", "4")]
        [TestCase("5", "5")]
        [TestCase("6", "6")]
        [TestCase("7", "7")]
        [TestCase("8", "8")]
        [TestCase("9", "9")]
        [TestCase("0", "0")]
        [TestCase("(", "(")]
        [TestCase(")", ")")]
        [TestCase("-", "-")]
        [TestCase(".", ".")]

        public void TestClickOnSomeButoon(string IdForButton,string expected)
        {
            driver.FindElement(By.Id(IdForButton)).Click();
            IWebElement text = driver.FindElement(By.Id("15"));
            string actual = text.GetAttribute("value");
            Assert.AreEqual(expected, actual);
        }


        [TestCase("1","+","2","1+2")]
        [TestCase("1", "*", "2", "1*2")]
        [TestCase("1", "/", "2", "1/2")]
        [TestCase("1", "2", "back", "1")]
        [TestCase("1", "2", "Clean", "")]

        public void TestClickOnPlusMulDivnBackClean(string IdForButoon1, string IdForButoon2,string IdForButoon3,string expected)
        {
            driver.FindElement(By.Id(IdForButoon1)).Click();
            driver.FindElement(By.Id(IdForButoon2)).Click();
            driver.FindElement(By.Id(IdForButoon3)).Click();
            IWebElement text = driver.FindElement(By.Id("15"));
            string actual = text.GetAttribute("value");
            Assert.AreEqual(expected, actual);
        }

        [TestCase("9", "+", "4", "13")]
        [TestCase("8", "-", "3", "5")]
        [TestCase("3", "*", "4", "12")]
        [TestCase("8", "/", "4", "2")]

        public void TestFunctionPlusMinMultDivQually(string IdForButoon1, string IdForButoon2, string IdForButoon3, string expected)
        {
            driver.FindElement(By.Id(IdForButoon1)).Click();
            driver.FindElement(By.Id(IdForButoon2)).Click();
            driver.FindElement(By.Id(IdForButoon3)).Click();
            driver.FindElement(By.Id("=")).Click();
            IWebElement text = driver.FindElement(By.Id("14"));
            string actual = text.GetAttribute("value");
            Assert.AreEqual(expected, actual);
        }

        [TestCase("9", "1", "+", "1", "2", "103")]
        [TestCase("1", "2", "*", "1", "1", "132")]
        [TestCase("8", "5", "/", "1", "7", "5")]
        [TestCase("5", "5", "-", "3", "0", "25")]

        public void TestFunctionCompoNum(string IdForButoon1, string IdForButoon2, string IdForButoon3, string IdForButoon4, string IdForButoon5 ,string expected)
        {
            driver.FindElement(By.Id(IdForButoon1)).Click();
            driver.FindElement(By.Id(IdForButoon2)).Click();
            driver.FindElement(By.Id(IdForButoon3)).Click();
            driver.FindElement(By.Id(IdForButoon4)).Click();
            driver.FindElement(By.Id(IdForButoon5)).Click();
            driver.FindElement(By.Id("=")).Click();
            IWebElement text = driver.FindElement(By.Id("14"));
            string actual = text.GetAttribute("value");
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-", "5", "+", "4", "-1")]
        [TestCase("7", "+", "-", "3", "4")]
        [TestCase("-", "3", "*", "4", "-12")]
        [TestCase("9", "/", "-", "3", "-3")]

        public void TestNegativeNum(string IdForButoon1, string IdForButoon2, string IdForButoon3, string IdForButoon4, string expected)
        {
            driver.FindElement(By.Id(IdForButoon1)).Click();
            driver.FindElement(By.Id(IdForButoon2)).Click();
            driver.FindElement(By.Id(IdForButoon3)).Click();
            driver.FindElement(By.Id(IdForButoon4)).Click();
            driver.FindElement(By.Id("=")).Click();
            IWebElement text = driver.FindElement(By.Id("14"));
            string actual = text.GetAttribute("value");
            Assert.AreEqual(expected, actual);

        }

        [TestCase("1", "+", "2", "*", "2","5")]
        [TestCase("9", "-", "2", "/", "2", "8")]
        [TestCase("1", "+", "3", "/", "3", "2")]
        [TestCase("8", "-", "4", "*", "2", "0")]

        public void TestPriority(string IdForButoon1, string IdForButoon2, string IdForButoon3, string IdForButoon4, string IdForButoon5, string expected)
        {
            driver.FindElement(By.Id(IdForButoon1)).Click();
            driver.FindElement(By.Id(IdForButoon2)).Click();
            driver.FindElement(By.Id(IdForButoon3)).Click();
            driver.FindElement(By.Id(IdForButoon4)).Click();
            driver.FindElement(By.Id(IdForButoon5)).Click();
            driver.FindElement(By.Id("=")).Click();
            IWebElement text = driver.FindElement(By.Id("14"));
            string actual = text.GetAttribute("value");
            Assert.AreEqual(expected, actual);

        }

        [TestCase("4", "*", "2", "+", "1", "12")]
        [TestCase("9", "/", "7", "-", "4", "3")]
        [TestCase("6", "+", "2", "*", "4", "14")]
        [TestCase("4", "-", "8", "/", "4", "2")]

        public void TestPriorityWithBranch(string IdForButoon1, string IdForButoon2, string IdForButoon3, string IdForButoon4, string IdForButoon5, string expected)
        {
            driver.FindElement(By.Id(IdForButoon1)).Click();
            driver.FindElement(By.Id(IdForButoon2)).Click();
            driver.FindElement(By.Id("(")).Click();
            driver.FindElement(By.Id(IdForButoon3)).Click();
            driver.FindElement(By.Id(IdForButoon4)).Click();
            driver.FindElement(By.Id(IdForButoon5)).Click();
            driver.FindElement(By.Id(")")).Click();
            driver.FindElement(By.Id("=")).Click();
            IWebElement text = driver.FindElement(By.Id("14"));
            string actual = text.GetAttribute("value");
            Assert.AreEqual(expected, actual);

        }

        [Test]

        public void TestAllFunction() //Проверяем прмиер 1+2*(3+4/2-(1+2))*2+1
        {
            driver.FindElement(By.Id("1")).Click();
            driver.FindElement(By.Id("+")).Click();
            driver.FindElement(By.Id("2")).Click();
            driver.FindElement(By.Id("*")).Click();
            driver.FindElement(By.Id("(")).Click();
            driver.FindElement(By.Id("3")).Click();
            driver.FindElement(By.Id("+")).Click();
            driver.FindElement(By.Id("4")).Click();
            driver.FindElement(By.Id("/")).Click();
            driver.FindElement(By.Id("2")).Click();
            driver.FindElement(By.Id("-")).Click();
            driver.FindElement(By.Id("(")).Click();
            driver.FindElement(By.Id("1")).Click();
            driver.FindElement(By.Id("+")).Click();
            driver.FindElement(By.Id("2")).Click();
            driver.FindElement(By.Id(")")).Click();
            driver.FindElement(By.Id(")")).Click();
            driver.FindElement(By.Id("*")).Click();
            driver.FindElement(By.Id("2")).Click();
            driver.FindElement(By.Id("+")).Click();
            driver.FindElement(By.Id("1")).Click();
            driver.FindElement(By.Id("=")).Click();
            string expected = "10";
            IWebElement text = driver.FindElement(By.Id("14"));
            string actual = text.GetAttribute("value");
            Assert.AreEqual(expected, actual);
        }

        [TearDown]
       
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
