using Example.Project.ToolKit.Helpers;
using Microsoft.Extensions.Configuration;

namespace Example.Project.ToolKit.Settings
{
    public class WebConfigSettingService : ISettingService
    {
        IConfiguration _iConfiguration;
        public WebConfigSettingService(IConfiguration configuration)
        {
            _iConfiguration = configuration;
        }
        public T Get<T>(string key)
        {
            var obj = _iConfiguration.GetConnectionString(key);
            return obj.ConvertTo<T>();
        }

        public T GetConnectionString<T>(string key)
        {
            var obj = _iConfiguration.GetConnectionString(key);
            return obj.ConvertTo<T>();
        }
    }
}
