namespace TodoList_Backend.Exceptions
{
    public class AppSettingNotDefinedException : System.Exception
    {
        public AppSettingNotDefinedException(string settingName) : base($"App setting {settingName} is not defined.")
        {
        }
    }
}
