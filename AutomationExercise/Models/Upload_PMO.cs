using AutomationExercise.DataTests;
using System.IO;
using System.Reflection.Metadata;

namespace AutomationExercise.Models
{
    public class Upload_PMO
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private readonly By uploadBtnLocator = By.XPath("//*[@id='file-upload']");
        private readonly By submitBtnLocator = By.XPath("//*[@id='file-submit']");
        //private readonly By fileUploadedLocator = By.XPath("//*[@id='uploaded-files']/[contains(text(), 'test.txt')]");
        private readonly By resultLocator = By.XPath("//*[contains(text(), 'File Uploaded!')]");
        public IWebElement uploadBtn { get; private set; }
        public IWebElement submitBtn { get; private set; }
        public IWebElement result { get; private set; }


        public Upload_PMO(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public void NavigateToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        private IWebElement FindElement(By locator)
        {
            return wait.Until(drv => drv.FindElement(locator));
        }
        public void Initialize()
        {
            uploadBtn = FindElement(uploadBtnLocator);
            submitBtn = FindElement(submitBtnLocator);
        }
        public void Results()
        {
            result = FindElement(resultLocator);
        }
        public void Upload()
        {
            var filePath = Utility.GetDownloadPath();
            var file = Path.Combine(filePath, Upload_DT.GetFileUploadName());
            uploadBtn.SendKeys(file);
            submitBtn.Click();
        }
    }
}
