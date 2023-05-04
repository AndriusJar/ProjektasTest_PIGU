using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace ProjektasTest
{
    //KAINU LYGINIMO (NUO PIGIAUSIU) TESTAS
    internal class Registracija

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
        }


        public static void CaptureScreenShot(IWebDriver driver, string fileName)
        {
            var screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            if (!Directory.Exists("Screenshots"))
            {
                Directory.CreateDirectory("Screenshots");
            }

            screenshot.SaveAsFile(
                $"Screenshots\\{fileName}.png",
                ScreenshotImageFormat.Png);

        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var name =
                    $"{TestContext.CurrentContext.Test.MethodName}" +
                    $" Error at " +
                    $"{DateTime.Now.ToString().Replace(":", "_").Replace("/","-")}";

                CaptureScreenShot(driver, name);
                File.WriteAllText($"Screenshots\\{name}.txt",
                TestContext.CurrentContext.Result.Message);

            }
            driver.Close();
            driver.Quit();
        }


        [Test]
        public static void CheckSorting()

        {
            TestSortingAsc("https://pigu.lt/lt/kompiuterine-technika/isoriniai-kompiuteriu-aksesuarai/mikrofonai");
            TestSortingAsc("https://pigu.lt/lt/sportas-laisvalaikis-turizmas/kurybingas-laisvalaikis/klijuojami-modeliai");
            TestSortingAsc("https://pigu.lt/lt/autoprekes/akumuliatoriai/akumuliatoriai");
            TestSortingAsc("https://pigu.lt/lt/teleskopai-ir-mikroskopai");
            TestSortingAsc("https://pigu.lt/lt/kompiuterine-technika/dronai");
        }

        public static void TestSortingAsc(string categoryURL)
        {

            //pasiimu visas kainas iš pirmo puslapio kiekvienoje kategorijoje
            driver.Url = categoryURL + "?ob=pa";
            By pricesBy = By.XPath("//span[contains(@class,'price notranslate')]");


            //susikuriu tuščią sąrašą į kurį įdėsiu kaina, vienas elementas
            List<int> prices = new List<int>();


            //konvertacija kainos, tekstas ir nuo pabaigos atimu 2 elementus,
            //t.y. tarpa ir euro simboli, ir įkeliu į prices sąrašą auščiau
            
            foreach (IWebElement el in driver.FindElements(pricesBy))
            {
                string onePrice = el.Text.Substring(0, el.Text.Length - 2);                           
                int onePriceInt = int.Parse(onePrice);
                prices.Add(onePriceInt);
            }

            //turim sąrašą, jei priešais skaičius bus didesnis tada testas sufeilins

            for (int i = 0; i < prices.Count - 1; i++)
            {
                if (prices[i] > prices[i + 1])
                {
                    Assert.Fail("Failed in " + categoryURL + " " + prices[i] + " " + prices[i + 1]);
                }                
            }
        }


    }
}


