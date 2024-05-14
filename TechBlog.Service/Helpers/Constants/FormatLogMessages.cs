namespace TechBlog.Service.Helpers.Constants
{
    public static class FormatLogMessages
    {
        public static string EventDebug(string methodName, string methodEvent)
        {
            return $"{methodName} service {methodEvent}.";
        }

        public static string EventError(string methodEvent, string typeModel)
        {
            return $"An error occurred while {methodEvent} {typeModel}!";
        }
    }
}
