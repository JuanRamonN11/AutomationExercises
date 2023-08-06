using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationExercise
{
    public class Methods
    {
        public static IWebDriver? Driver { get; set; }

        //Set useHeadless = true for running without GUI
        public static IWebDriver GetDriver(bool useHeadless = false)
        {
            useHeadless = true;
            var chromeOptions = new ChromeOptions();
            if (useHeadless)
                chromeOptions.AddArguments("headless");

            chromeOptions.AddArguments("--window-size=1980,1080");
            string workingDirectory = Environment.CurrentDirectory;
            string projectRoot = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string downloadPath = Path.Combine(projectRoot, "Files");
            chromeOptions.AddUserProfilePreference("download.default_directory", downloadPath);
            new DriverManager().SetUpDriver(new ChromeConfig());

            return new ChromeDriver(chromeOptions);
        }
    }
}