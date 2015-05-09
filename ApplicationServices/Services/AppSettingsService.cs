using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;

namespace ApplicationServices.Services
{
    public interface IAppSettingsService
    {
        T GetSettingAs<T>(string settingKey);
    }

    public class AppSettingsService : IAppSettingsService
    {
        public T GetSettingAs<T>(string settingKey)
        {
            var value = WebConfigurationManager.AppSettings[settingKey];

            if (string.IsNullOrEmpty(value))
            {
                throw new NullReferenceException(string.Format("{0} was not found."));
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
