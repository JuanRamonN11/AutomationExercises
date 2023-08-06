using AutomationExercise.DataTests;
using OpenQA.Selenium;

namespace AutomationExercise.Models
{
    public class JSAlert_PMO
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private readonly By jsAlertBtnLocator = By.XPath("//*[@onclick='jsAlert()']");
        private readonly By jsPromptBtnLocator = By.XPath("//*[@onclick='jsPrompt()']");
        private readonly By resultLocator = By.XPath("//*[@id='result']");

        public IWebElement jsAlertBtn { get; private set; }
        public IWebElement jsPromptBtn { get; private set; }
        public IWebElement result { get; private set; }


        public JSAlert_PMO(IWebDriver driver)
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
            jsAlertBtn = FindElement(jsAlertBtnLocator);
            jsPromptBtn = FindElement(jsPromptBtnLocator);
            result = FindElement(resultLocator);

        }
        private IAlert GetAlert()
        {
            return driver.SwitchTo().Alert();
        }
        public void AcceptAlert() 
        {
            GetAlert().Accept();
        }
        public void SendKeysAlert(string inputText) 
        {
            IAlert alertWindow = GetAlert();
            alertWindow.SendKeys(inputText);
        }
        public void JsAlert()
        {
            jsAlertBtn.Click();
            AcceptAlert();
        }
        public void JsPrompt()
        {
            jsPromptBtn.Click();
            SendKeysAlert(JSAlert_DT.AlertText());
            AcceptAlert();
        }
    }
}
