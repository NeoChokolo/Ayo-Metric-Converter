using System;
using System.Collections.Generic;
using System.Text;

namespace MetricConverter.Model
{
    public class AppSettings : IAppSettings
    {
        public string connectionString { get; set; }
        public string identityServerUrl { get; set; }
        public string identityApiName { get; set; }
    }

    public interface IAppSettings
    {
        string connectionString { get; set; }
        string identityServerUrl { get; set; }
        string identityApiName { get; set; }
    }
}
