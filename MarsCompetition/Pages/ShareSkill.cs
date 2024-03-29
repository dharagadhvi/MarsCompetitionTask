﻿using MarsCompetition.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using AutoItX3Lib;

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

        [FindsBy(How = How.CssSelector,Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(4) > div.twelve.wide.column > div > div > div > span > a")]
        private IWebElement RemoveTags { get; set; }

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

        //monday Checkbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement Mon { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Monday Starttime checkbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input")]
        private IWebElement MonStartTime { get; set; }

        //Monday Endtime button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input")]
        private IWebElement MonEndTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }


        //Click on Upload
        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(9) > div > div.twelve.wide.column > section > div > label > div > span > i")]

        private IWebElement WorkSample { get; set; }


        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        [FindsBy(How =How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(8) > div:nth-child(4) > div > div > div > div > span > a")]
        private IWebElement RemoveSkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(10) > div.twelve.wide.column")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div.ui.vertically.padded.right.aligned.grid > div > input.ui.teal.button")]
        private IWebElement Save { get; set; }

        //popup error message
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement popuerror { get; set; }

        // public object workSample { get; private set; }
        
        public IWebElement RemoveSkillExchageTag { get; set; }


        public void EnterShareSkill()
        {
            Thread.Sleep(4000);

            //click shareskill button
            ShareSkillButton.Click();

            GlobalDefinations.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            //Enter the Title and Description
            Thread.Sleep(2000);

            Title.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Title"));
            Description.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Description"));
            Thread.Sleep(4000);

            //select Category
            CategoryDropDown.Click();
            SelectElement categorySelect = new SelectElement(CategoryDropDown);
            categorySelect.SelectByText(GlobalDefinations.ExcelLib.ReadData(2, "Category"));
            Thread.Sleep(4000);

            //select Suncategory
            SubCategoryDropDown.Click();
            SelectElement subCategorySelect = new SelectElement(SubCategoryDropDown);
            Thread.Sleep(2000);
            subCategorySelect.SelectByText(GlobalDefinations.ExcelLib.ReadData(2, "SubCategory"));
            Thread.Sleep(2000);
            //Enter Tag
            Tags.Click();
            Thread.Sleep(2000);
            Tags.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            //Select ServiceType
            ServiceTypeOptions.Click();
            Thread.Sleep(1000);

            //Select Loaction Type
            LocationTypeOption.Click();
            Thread.Sleep(1000);

            //Enter Available days
            //StartDateDropDown.Click();
            //SelectElement startdateElement = new SelectElement(StartDateDropDown);
            //startdateElement.SelectByText(GlobalDefinations.ExcelLib.ReadData(2, "StartDate"));
            //EndDateDropDown.Click();
            //SelectElement enddateElement = new SelectElement(EndDateDropDown);
            //enddateElement.SelectByText(GlobalDefinations.ExcelLib.ReadData(2, "EndDate"));

            string day = GlobalDefinations.ExcelLib.ReadData(2, "Selectday");
            if (day == "Mon")
            {
                Mon.Click();
            }

            //Start time and End time for Monday
            MonStartTime.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Starttime"));

            MonEndTime.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Endtime"));

            //SkillTradeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            Thread.Sleep(2000);
            SkillExchange.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);


            //WorkSample Upload
            WorkSample.Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(5000);
            autoIt.Send(@"C:\Users\dhara\Desktop\Jira-vs-Confluence (1).jpg");
            Thread.Sleep(4000);
            autoIt.Send("{ENTER}");

            Thread.Sleep(1000);
            //ActiveOption.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Active"));
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
            GlobalDefinations.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditShareSkill");
            //GlobalDefinitions.wait(1);
            Thread.Sleep(3000);

            //Clearing the textbox
            Title.Clear();
            Description.Clear();
            Thread.Sleep(2000);

            //reading the values from excel
            Title.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Title"));
            Description.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Description"));

            //click on category and subcategory
            CategoryDropDown.Click();
            SelectElement categoryselect = new SelectElement(CategoryDropDown);
            categoryselect.SelectByText(GlobalDefinations.ExcelLib.ReadData(2, "Category"));
            SubCategoryDropDown.Click();
            SelectElement subcategoryselect = new SelectElement(SubCategoryDropDown);
            subcategoryselect.SelectByText(GlobalDefinations.ExcelLib.ReadData(2, "SubCategory"));

            //Removing Existing tags
            RemoveTags.Click();
           
            Thread.Sleep(2000);

            //Adding tags
            Tags.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            //Tags.Click();

            //Servicetype and location type
            //LocationTypeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"));

            //reading data for startdate and enddate
            GlobalDefinations.wait(4);
            StartDateDropDown.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Startdate"));
            EndDateDropDown.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Enddate"));

            //Click on the day
            string day = GlobalDefinations.ExcelLib.ReadData(2, "Selectday");
            if (day == "Mon")
            {
                Mon.Click();
            }

            //StartTime and End time for monday
            MonStartTime.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Starttime"));
            MonEndTime.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Endtime"));

            //Click on Remove the Skill-Exchangetag
            RemoveSkillExchange.Click();

            

            //SkillTradeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(GlobalDefinations.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            //WorkSample Upload
            WorkSample.Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            autoIt.Send(Base.Filepath);
            Thread.Sleep(2000);
            autoIt.Send("{ENTER}");

            //ActiveOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Active"));
            Save.Click();
            Thread.Sleep(4000);



        }

    }
}



