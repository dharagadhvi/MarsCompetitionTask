using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using MarsCompetition.Global;
using SeleniumExtras.PageObjects;
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
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }


        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        public void LoginSteps()
        {
            GlobalDefinations.driver.Navigate().GoToUrl("http://localhost:5000/");
            SignIntab.Click();
            GlobalDefinations.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            Email.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Username"));
            Password.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Password"));
            LoginBtn.Click();
        }
    }
}

