using static System.Net.Mime.MediaTypeNames;

namespace AutomationExercise.DataTests
{
    public class DynamicContent_DT
    {
        public static string GetDynamicContentURL()
        {
            return "https://the-internet.herokuapp.com/dynamic_content";
        }
        public static int GetAvailableImages()
        {
            return 5;
        }
    }
}
