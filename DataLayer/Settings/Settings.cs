using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLayer.Services
{
    public class AppSettigns
    {
        public string ConnectionString { get; set; }
    }
    public static class Settings
    {
        private static string settingsFilePath = @"C:\Users\carlo\Documents\JsonSettings\AppSetting.json";
        public static void settings(AppSettigns appSettigns)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile(settingsFilePath, optional: false, reloadOnChange: true);

            IConfigurationRoot conf = builder.Build();
            conf.GetSection("AppSettings").Bind(appSettigns);
        }
    }
}
