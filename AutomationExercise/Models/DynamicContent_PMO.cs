namespace AutomationExercise.Models
{
    public class DynamicContent_PMO
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private readonly List<By> locators;
        public List<IWebElement> foundElements { get; private set; }



        public DynamicContent_PMO(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            locators = new List<By>
            {
                By.XPath("//img[@src='/img/avatars/Original-Facebook-Geek-Profile-Avatar-1.jpg']"),
                By.XPath("//img[@src='/img/avatars/Original-Facebook-Geek-Profile-Avatar-2.jpg']"),
                By.XPath("//img[@src='/img/avatars/Original-Facebook-Geek-Profile-Avatar-3.jpg']"),
                By.XPath("//img[@src='/img/avatars/Original-Facebook-Geek-Profile-Avatar-5.jpg']"),
                By.XPath("//img[@src='/img/avatars/Original-Facebook-Geek-Profile-Avatar-6.jpg']"),
                By.XPath("//img[@src='/img/avatars/Original-Facebook-Geek-Profile-Avatar-7.jpg']"),

            };
        }
        public void FindAllImages()
        {
            List<By> remainingLocators = new List<By>(locators);
            foundElements = new List<IWebElement>();
            int consecutiveFoundCount = 0;
            //Search every locator on the list and catches NoSuchElementException
            //and continues on the other element
            while (foundElements.Count < 5)
            {
                List<By> locatorsToRemove = new List<By>();

                foreach (By locator in remainingLocators)
                {
                    try
                    {
                        IWebElement element = driver.FindElement(locator);
                        foundElements.Add(element);
                        locatorsToRemove.Add(locator);
                        consecutiveFoundCount++;
                        //Break if 3 elements were found to prevent
                        //searching the other locators since there is no more than 3 images
                        if (consecutiveFoundCount == 3)
                        {
                            break;
                        }
                    }
                    catch (NoSuchElementException)
                    {
                    }
                }
                //remove locators that were found
                remainingLocators.RemoveAll(locatorsToRemove.Contains); 

                //Stops if 5 images where found
                if (foundElements.Count < 5)
                {
                    driver.Navigate().Refresh();
                }
            }
        }

        public void NavigateToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
       
    }
}
