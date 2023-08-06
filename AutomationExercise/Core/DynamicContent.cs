using AutomationExercise.DataTests;
using AutomationExercise.Models;

namespace AutomationExercise.Core
{
    [TestClass]
    public class DynamicContent
    {
        private IWebDriver _driver;
        private DynamicContent_PMO dynamicContent;

        private const int ImplicitWaitTimeoutSeconds = 1;
        private const int PageLoadTimeoutSeconds = 2;
        [TestInitialize]
        public void Init()
        {
            _driver = Methods.GetDriver(false);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeoutSeconds);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PageLoadTimeoutSeconds);

            dynamicContent = new DynamicContent_PMO(_driver);
        }
        [TestCleanup]
        public void Cleanup()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
        [TestMethod]
        public void DynamicContent_Test()
        {
            var url = DataTests.DynamicContent_DT.GetDynamicContentURL();

            dynamicContent.NavigateToPage(url);
            dynamicContent.FindAllImages();
            Assert.AreEqual(dynamicContent.foundElements.Count, DynamicContent_DT.GetAvailableImages());
            
        }
    }
}
