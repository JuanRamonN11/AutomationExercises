namespace AutomationExercise.Models
{
    public class DragDrop_PMO
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly string dnd_javascript;

        public IWebElement BlockA { get; private set; }
        public IWebElement BlockB { get; private set; }

        private readonly By blockALocator = By.XPath("//*[@id='column-a']");
        private readonly By blockBLocator = By.XPath("//*[@id='column-b']");


        public DragDrop_PMO(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            string fileName = "dnd.js";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            dnd_javascript = System.IO.File.ReadAllText(filePath);
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
            BlockA = FindElement(blockALocator);
            BlockB = FindElement(blockBLocator);
        }

        public void MoveAtoB()
        {
            //Doesn't works with HTML5
            //Actions actions = new Actions(driver);
            //actions.DragAndDrop(blockA,blockB).Perform();
            ((IJavaScriptExecutor)driver).ExecuteScript(dnd_javascript + "$('#column-a').simulateDragDrop({ dropTarget: '#column-b'});");
        }
        public void MoveBtoA()
        {
            //Doesn't works with HTML5
            //Actions actions = new Actions(driver);
            //actions.DragAndDrop(blockA,blockB).Perform();
            ((IJavaScriptExecutor)driver).ExecuteScript(dnd_javascript + "$('#column-b').simulateDragDrop({ dropTarget: '#column-a'});");
        }
    }
}