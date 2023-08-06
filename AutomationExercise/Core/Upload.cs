using AutomationExercise.DataTests;
using AutomationExercise.Models;

namespace AutomationExercise.Core
{
    [TestClass]
    public class Upload
    {
        private IWebDriver _driver;
        private Upload_PMO upload;

        string fileName = Upload_DT.GetFileUploadName();
        string fileContent =Upload_DT.GetFileUploadContent();

        private const int ImplicitWaitTimeoutSeconds = 5;
        private const int PageLoadTimeoutSeconds = 10;

        [TestInitialize]
        public void Init()
        {
            _driver = Methods.GetDriver(false);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeoutSeconds);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PageLoadTimeoutSeconds);
            Utility.CreateFile(fileName, fileContent);

            upload = new Upload_PMO(_driver);

        }
        [TestCleanup]
        public void Cleanup()
        {
            Utility.DeleteFile(fileName);
            _driver?.Quit();
            _driver?.Dispose();
        }
        [TestMethod]
        public void Upload_Test()
        {
            var url = DataTests.Upload_DT.GetFileUploadURL();

            upload.NavigateToPage(url);
            upload.Initialize();
            upload.Upload();

            string downloadPath = Utility.GetDownloadPath();
            Thread.Sleep(2000);
            //Gets result when file is uploaded
            upload.Results();
            Assert.AreEqual(upload.result.Text, Upload_DT.ResultText());
        }
    }
}
