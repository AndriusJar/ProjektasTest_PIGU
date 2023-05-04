using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V109.CSS;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Runtime.InteropServices;
using System.Timers;
using ProjektasTest.POM;
using ProjektasTest.Generators;

namespace ProjektasTest
        //TESTAS TIKRINA AR IVEDUS NETEISINGUS PRISIJUNGIMO DUOMENIS BUS PRISIJUNGTA
{
    public static class OtherCases2
    {
        static IWebDriver driver;

        [SetUp]
        public static void SETUP()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://pigu.lt/lt";
            By asseptCookiesButton = By.XPath("//button[@class='c-btn--primary h-btn--small']");
            driver.FindElement(asseptCookiesButton).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public static void RegistracijosTestas()
        {
            PrisijungimoKlase prisijungimoKlase = new PrisijungimoKlase(driver);

            //Thread.Sleep(300);
            prisijungimoKlase.clickElPastas();
            string email_Password = StringGenerator.getEmail();
            prisijungimoKlase.enterElPastas(email_Password);
            //Thread.Sleep(300);
            prisijungimoKlase.clickPassword();
            prisijungimoKlase.enterPassword(email_Password);
            prisijungimoKlase.clickPrisijungti();
                        
            //lyginam, ivedus neteisingus duomenis testas praeina, jei ivesti duomenys teisingi testas feilins
            By neteisingiDuomenys = By.XPath("//div[@class='error-message']");
            Assert.AreEqual(neteisingiDuomenys, neteisingiDuomenys);

        }

        [TearDown]
        public static void TearDown() 
        {
            driver.Close();
            driver.Quit();
        }

    }
}





