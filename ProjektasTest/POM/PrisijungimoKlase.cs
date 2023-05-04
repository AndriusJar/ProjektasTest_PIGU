using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektasTest.POM
{
    internal class PrisijungimoKlase
    {
        IWebDriver driver;

        public PrisijungimoKlase(IWebDriver driver) {
            this.driver = driver;
        }

        public void clickMyAccount()
        {
            //paspaudziamas prisijungimo mygtukas
            By myAccount = By.XPath("(//i[@class=\"c-icon--profile\"])[1]");
            driver.FindElement(myAccount).Click();
        }

        public void clickElPastas()
        {   
            clickMyAccount();
            //paspaudziama ant el.pasto lauko
            By elPastas = By.XPath("(//input[@placeholder='El. paštas'])[1]");
            driver.FindElement(elPastas).Click();
        }

        public void enterElPastas(string email) 
        {
            //is datos suformuojamas el.pastas, ivedamas, kuris bus naudojamas kaip ir slaptazodis
            driver.FindElement(By.XPath("(//input[@placeholder='El. paštas'])[1]")).SendKeys(email);
        }

        public void clickPassword()
        {
            //paspaudziama ant slaptazodzio lauko
            By slaptazodis = By.XPath("(//input[@type='password'])[1]");
            driver.FindElement(slaptazodis).Click();
        }

        public void enterPassword(string password)
        {
            //ivedamas slaptazodis
            driver.FindElement(By.XPath("(//input[@type='password'])[1]")).SendKeys(password); ;
        }

        public void clickPrisijungti()
        {
            //paspaudziamas galutinio prisijungimo mygtukas
            By prisijungti = By.XPath("(//input[@type='submit'])[2]");
            driver.FindElement(prisijungti).Click();
        }

    }
}
