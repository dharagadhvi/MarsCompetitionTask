using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using MarsCompetition.Global;
using SeleniumExtras.PageObjects;
using System.IO;
#nullable disable

namespace MarsCompetition.Pages

{
     class SignIn
    {
        public SignIn()
        {
       
          PageFactory.InitElements(Global.GlobalDefinations.driver, this);
        }


        #region  Initialize Web Elements 
        //Go to Url
        private IWebElement Url { get; set; }

        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/a")]
        private IWebElement SignIntab { get; set; }


        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[1]/input")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[2]/input")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        public void LoginSteps()
        {
            GlobalDefinations.driver.Navigate().GoToUrl("http://localhost:5000/");
           // Url.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Url"));
            SignIntab.Click();
           
            GlobalDefinations.ExcelLib.PopulateInCollection(Base.ExcelPath,"SignIn");

            Email.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Username"));
            Password.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Password"));
            LoginBtn.Click();
        }
    }
}

