namespace AutomationExercise.DataTests
{
    public class Upload_DT
    {
        public static string GetFileUploadURL()
        {
            return "https://the-internet.herokuapp.com/upload";
        }
        public static string GetFileUploadName()
        {
            return "test.txt";
        }
        public static string GetFileUploadContent()
        {
            return "testing";
        }
        public static string ResultText()
        {
            return "File Uploaded!";
        }
    }
}