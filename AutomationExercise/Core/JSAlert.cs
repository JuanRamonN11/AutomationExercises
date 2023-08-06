using AutomationExercise.DataTests;
using AutomationExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Core
{
    [TestClass]
    public class JSAlert
    {
        private IWebDriver _driver;
        private JSAlert_PMO jsAlert;
        private const int ImplicitWaitTimeoutSeconds = 5;
        private const int PageLoadTimeoutSeconds = 10;
        [TestInitialize]
        public void Init()
        {
            _driver = Methods.GetDriver(false);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeoutSeconds);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PageLoadTimeoutSeconds);

            jsAlert = new JSAlert_PMO(_driver);
        }
        [TestCleanup]
        public void Cleanup()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
        [TestMethod]
        public void jsAlert_Test()
        {
            var url = DataTests.JSAlert_DT.GetJSAlertURL();
            jsAlert.NavigateToPage(url);
            jsAlert.Initialize();

            //Click JS Alert
            jsAlert.JsAlert();
            Assert.AreEqual(JSAlert_DT.AlertResultText(), jsAlert.result.Text);

            //Send JS Prompt keys
            jsAlert.JsPrompt();
            Assert.AreEqual(JSAlert_DT.PromptResultText(), jsAlert.result.Text);
        }
    }
}
