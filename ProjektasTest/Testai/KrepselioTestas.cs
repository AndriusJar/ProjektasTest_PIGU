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
using ProjektasTest.POM;

namespace ProjektasTest

        //IDEJIMO I KREPSELI TESTAS
{
    public class OtherCases1
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
        public static void IdejimoIKrepseliTestas()
        {
            KrepselioKlase krepselioKlase = new KrepselioKlase(driver);

            krepselioKlase.dirSportasTurizmas();

            //Thread.Sleep(300);
            krepselioKlase.dirLaisvalaikis();
                                   
            //Thread.Sleep(300);
            krepselioKlase.dirBatutai();
                        
            //Thread.Sleep(300);
            krepselioKlase.clickIKrepseli();
                        
            //Thread.Sleep(500);
            krepselioKlase.uzdaromPatvirtintaItraukima();

            Assert.AreEqual("1", krepselioKlase.gaunamKiekiKrepselyje());
        }


        [TearDown]
        public static void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
