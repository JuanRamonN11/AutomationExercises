using AutomationExercise.DataTests;
using AutomationExercise.Models;

namespace AutomationExercise.Core
{
    [TestClass]
    public class FileDownload
    {
        private IWebDriver _driver;
        private FileDownload_PMO fileDownload;
        string fileName = FileDownload_DT.GetFileDownloadName();


        private const int ImplicitWaitTimeoutSeconds = 5;
        private const int PageLoadTimeoutSeconds = 10;
        [TestInitialize]
        public void Init()
        {
            _driver = Methods.GetDriver(false);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeoutSeconds);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PageLoadTimeoutSeconds);

            fileDownload = new FileDownload_PMO(_driver);
        }
        [TestCleanup]
        public void Cleanup()
        {
            Utility.DeleteFile(fileName);
            _driver?.Quit();
            _driver?.Dispose();
        }
        [TestMethod]
        public void FileDownload_Test()
        {
            var url = DataTests.FileDownload_DT.GetFileDownloadURL();

            fileDownload.NavigateToPage(url);
            fileDownload.Initialize();
            fileDownload.Download();

            string downloadPath = Utility.GetDownloadPath();
            Thread.Sleep(2000);

            Assert.IsTrue(File.Exists(Path.Combine(downloadPath, fileName)));
        }
    }
}
