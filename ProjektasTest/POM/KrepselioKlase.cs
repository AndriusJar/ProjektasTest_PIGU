using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjektasTest.POM
{
    internal class KrepselioKlase
    {
        IWebDriver driver;
        public KrepselioKlase(IWebDriver driver) {
            this.driver = driver;
        }

        public void dirSportasTurizmas()
        {
            // paspaudžiam kategorija - sportas, laisvalaikis, turizmas
            By kategorija = By.XPath("(//ul[@class='departaments-list-container']/li)[5]");
            driver.FindElement(kategorija).Click();
        }

        public void dirLaisvalaikis()
        {
            // paspaudžiam pirma direktorija - laisvalaikis
            By kategorija2 = By.XPath("(//ul[contains(@class,'link-menu__has-submenu')]//li)[2]");
            driver.FindElement(kategorija2).Click();
        }

        public void dirBatutai()
        {
            // pasirenkam pirmą produktą sąraše - batutai
            By pirmasProduktas = By.XPath("//div[@id='productListLoader']//div[contains(@class,'product-list-item')]//p//a");
            // jį atsidarome
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(pirmasProduktas));
            driver.FindElement(pirmasProduktas).Click();
            driver.FindElement(pirmasProduktas).Click();
        }

        public void clickIKrepseli()
        {
            // paspaudžiame į krepšelį
            By iKrepseli = By.XPath("//div[@class='c-btn--atc']");
            driver.FindElement(iKrepseli).Click();
        }

        public void uzdaromPatvirtintaItraukima() 
        {
            // uždarome atsidariusį langą, taip patvirtiname prekes patekima i krepseli
            By uzdaromeKrepseli = By.XPath("//div[@class='modal-content']//a[@class='close-modal']");
            driver.FindElement(uzdaromeKrepseli).Click();
        }

        public string gaunamKiekiKrepselyje()
        {
            // paimame prekių kiekį krepšelyje ir palyginam ar kiekis lygus vienetui, jei nelygus testas sufeilina
            By prekiuKiekisKrepselyje = By.XPath("//span[@widget-attachpoint='count']");
            string count = driver.FindElement(prekiuKiekisKrepselyje).Text;

            return count;
        }

    }
}
