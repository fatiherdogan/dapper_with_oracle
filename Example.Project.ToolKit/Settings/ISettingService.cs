namespace Example.Project.ToolKit.Settings
{
    public interface ISettingService
    {
        T Get<T>(string key);
        T GetConnectionString<T>(string key);
    }
}
