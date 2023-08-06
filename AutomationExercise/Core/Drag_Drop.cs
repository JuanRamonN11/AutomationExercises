using AutomationExercise.Models;

namespace AutomationExercise.Core
{
    [TestClass]
    public class Drag_Drop
    {
        private IWebDriver _driver;
        private DragDrop_PMO dragDrop;

        private const int ImplicitWaitTimeoutSeconds = 5;
        private const int PageLoadTimeoutSeconds = 10;
        [TestInitialize]
        public void Init()
        {
            _driver = Methods.GetDriver(false);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeoutSeconds);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PageLoadTimeoutSeconds);

            dragDrop = new DragDrop_PMO(_driver);
        }
        [TestCleanup]
        public void Cleanup()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
        [TestMethod]
        public void DragAndDrop_Test()
        {
            var url = DataTests.DragDrop_DT.GetDragAndDropURL();

            dragDrop.NavigateToPage(url);
            dragDrop.Initialize();

            //Drag and drop A to B
            dragDrop.MoveAtoB();
            Assert.AreEqual("B", dragDrop.BlockA.Text);
            Assert.AreEqual("A", dragDrop.BlockB.Text);

            //Drag and drop B to A
            dragDrop.MoveBtoA();
            Assert.AreEqual("B", dragDrop.BlockB.Text);
            Assert.AreEqual("A", dragDrop.BlockA.Text);
        }
    }
}
