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
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("C:\\Users\\Rafael\\source\\repos\\TestsForCalculates\\TestsForCalculates\\Properties\\Calculator.html");
            driver.FindElement(By.Id("1")).Click();
            IWebElement text = driver.FindElement(By.Id("15"));
            string actual = text.Text;
            string expected = "1";
            Assert.AreEqual(expected, actual);
        }
    }
}
