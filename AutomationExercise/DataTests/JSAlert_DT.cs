namespace AutomationExercise.DataTests
{
    public class JSAlert_DT
    {
        public static string GetJSAlertURL()
        {
            return "https://the-internet.herokuapp.com/javascript_alerts";
        }
        public static string AlertText()
        {
            return "testing";
        }
        public static string AlertResultText()
        {
            return "You successfully clicked an alert";
        }
        public static string PromptResultText()
        {
            return "You entered: testing";
        }
    }
}