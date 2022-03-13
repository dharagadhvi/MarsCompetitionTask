using MarsCompetition.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Database;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static System.Collections.Specialized.BitVector32;
#nullable disable

namespace MarsCompetition.Pages
{
     class ShareSkill
    {
        
          public ShareSkill()
            {
                PageFactory.InitElements(Global.GlobalDefinations.driver, this);
            }

            //Click on ShareSkill Button
            [FindsBy(How = How.LinkText, Using = "Share Skill")]
            private IWebElement ShareSkillButton { get; set; }

            //Enter the Title in textbox
            [FindsBy(How = How.Name, Using = "title")]
            private IWebElement Title { get; set; }

            //Enter the Description in textbox
            [FindsBy(How = How.Name, Using = "description")]
            private IWebElement Description { get; set; }

            //Click on Category Dropdown
            [FindsBy(How = How.Name, Using = "categoryId")]
            private IWebElement CategoryDropDown { get; set; }

            //Click on SubCategory Dropdown
            [FindsBy(How = How.Name, Using = "subcategoryId")]
            private IWebElement SubCategoryDropDown { get; set; }

            //Enter Tag names in textbox
            [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
            private IWebElement Tags { get; set; }

            //Select the Service type
            [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
            private IWebElement ServiceTypeOptions { get; set; }

            //Select the Location Type
            [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
            private IWebElement LocationTypeOption { get; set; }

            //Click on Start Date dropdown
            [FindsBy(How = How.Name, Using = "startDate")]
            private IWebElement StartDateDropDown { get; set; }

            //Click on End Date dropdown
            [FindsBy(How = How.Name, Using = "endDate")]
            private IWebElement EndDateDropDown { get; set; }

            //Storing the table of available days
            [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
            private IWebElement Days { get; set; }

            //Storing the starttime
            [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
            private IWebElement StartTime { get; set; }
        
            //Click on StartTime dropdown
            [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
            private IWebElement StartTimeDropDown { get; set; }

            //Click on EndTime dropdown
            [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
            private IWebElement EndTimeDropDown { get; set; }

            //Click on Upload
            [FindsBy(How = How.XPath, Using = "//*[@id='service - listing - Section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
            private IWebElement WorkSample { get; set; }


            //Click on Skill Trade option
            [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
            private IWebElement SkillTradeOption { get; set; }

            //Enter Skill Exchange
            [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
            private IWebElement SkillExchange { get; set; }

            //Enter the amount for Credit
            [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
            private IWebElement CreditAmount { get; set; }

            //Click on Active/Hidden option
            [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
            private IWebElement ActiveOption { get; set; }

            //Click on Save button
            [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
            private IWebElement Save { get; set; }

            //popup error message
             [FindsBy(How = How.XPath, Using = "/ html / body / div[1] / div")]
             private IWebElement popuerror { get; set; }

        // public object workSample { get; private set; }

        public  void EnterShareSkill()
            {

            //click shareskill button
            ShareSkillButton.Click();

            //GlobalDefinations.ExcelLib.PopulateInCollection(base.ExcelPath, "ShareSkill");
            //Enter the Title and Description

            Title.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Title"));
            Description.SendKeys(GlobalDefinations.ExcelLib.ReadData(2,"Description"));
            
            //selct Category
            CategoryDropDown.Click();
            SelectElement categorySelect = new SelectElement(CategoryDropDown);
            categorySelect.SelectByText(GlobalDefinations.ExcelLib.ReadData(2, "Catagory"));

            //selct Suncategory
            SubCategoryDropDown.Click();
            SelectElement subCategorySelect = new SelectElement(SubCategoryDropDown);
            subCategorySelect.SelectByText(GlobalDefinations.ExcelLib.ReadData(2 ,"SubCategory"));

            //Enter Tag
            Tags.Click();
            Tags.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "tags"));
            Tags.SendKeys(Keys.Enter);

            //Select ServiceType
            ServiceTypeOptions.Click();
              
            //Select Loaction Type
            LocationTypeOption.Click();

            //Enter Available days
            StartDateDropDown.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "StartDate"));
            EndDateDropDown.SendKeys(GlobalDefinations.ExcelLib.ReadData (2,"EndDate"));

            //Select Day
            string day = GlobalDefinations.ExcelLib.ReadData(2, "Selectday");
            if (day == "Sun")
            {
                Days.Click();
            }

            //StartTime and End time for sunday
            StartTimeDropDown.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Starttime"));
            EndTimeDropDown.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Endtime"));

            //SkillTradeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);

            //WorkSample Upload
            
            WorkSample.Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            
            //autoIt.Send(Base.Filepath);
            Thread.Sleep(2000);
            AutoItX3 autoit = new AutoItX3();
            autoit.Send("{ENTER}");

            Thread.Sleep(1000);
            //ActiveOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Active"));
            Save.Click();

            //Checking for shareskill updatation successfull

            string error = popuerror.Text;
            if (error == "Please complete the form correctly.")
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine("ShareSkill Saved");
            }
        



    }

            internal void EditShareSkill()
            {

            }
        }
    }



