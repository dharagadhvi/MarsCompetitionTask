using MarsCompetition.Config;
using MarsCompetition.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Reflection;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using static MarsCompetition.Global.GlobalDefinations;
#nullable disable

namespace MarsCompetition.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static string ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string Filepath = MarsResource.Filepath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {
            switch (Browser)
            {

                case 1:
                    GlobalDefinations.driver = new FirefoxDriver();
                    break;
                case 2:
                    //new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    ////System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"c:\Users\dhara\Downloads\chromedriver.exe");
                    GlobalDefinations.driver = new ChromeDriver();
                    GlobalDefinations.driver.Manage().Window.Maximize();
                    break;


            }
            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(MarsResource.ReportXMLPath);

            #endregion



            if (MarsResource.IsLogin == "true")
                    {
                        SignIn loginobj = new SignIn();
                        loginobj.LoginSteps();
                    }
                    else
                    {
                       SignUp obj = new SignUp();
                       obj.register();
                    }



        }
        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinations.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            test = new ExtentTest("", "");
            test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (Reports)
            //extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :)

            GlobalDefinations.driver.Close();
            GlobalDefinations.driver.Quit();
        }
        #endregion



    }
}



