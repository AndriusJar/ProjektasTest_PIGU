using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektasTest
       
        //ATPAZINIMO TESTAI
{
    public class OtherCases
    {
        static IWebDriver driver;

        [SetUp]
        public static void SETUP()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://pigu.lt/lt/";
            By asseptCookiesButton = By.XPath("//button[@class='c-btn--primary h-btn--small']");
            driver.FindElement(asseptCookiesButton).Click();
        }


        [Test]
        public static void Test01()
        {
            //visos prekes - paspaudimas
            By topMenuCat = By.XPath("//i[@class='c-icon--menu']");
            driver.FindElement(topMenuCat).Click();

            //sulyginam su uzrasu  pigu.lt/lt/katalogas
            string actualTitle = driver.Title;
            string expectedTitle = "katalogas";

            if (!actualTitle.Contains(expectedTitle))
            {
                Assert.Fail("Wrong Title");
            }

        }


        [Test]
        public static void CheckTitleIsCorrect()
        {
            string actualTitle = driver.Title;
            string expectedTitle = "Pigu.lt - prekybos centras internete";
            Assert.AreEqual(actualTitle, expectedTitle);
        }


        [TearDown]
        public static void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
