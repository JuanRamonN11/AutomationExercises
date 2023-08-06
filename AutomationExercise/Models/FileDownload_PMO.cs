namespace AutomationExercise.Models
{
    public class FileDownload_PMO
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public IWebElement file { get; private set; }


        private readonly By fileLocator = By.XPath("//*[@href='download/some-file.txt']");

        public FileDownload_PMO(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public void NavigateToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void Initialize()
        {
            file = FindElement(fileLocator);
        }
        private IWebElement FindElement(By locator)
        {
            return wait.Until(drv => drv.FindElement(locator));
        }
        public void Download()
        {
            file.Click();
        }
    }
}
