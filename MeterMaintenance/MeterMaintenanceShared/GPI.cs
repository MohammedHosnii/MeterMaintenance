using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MeterMaintenanceShared
{
    public static class GPI
    {
        private static readonly string JsonFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\GpiConfig.json";

        public static GpiConfig GetConfig()
        {
            var jsonString = File.ReadAllText(JsonFilePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<GpiConfig>(jsonString);
        }

        public static string GetConnectionString()
        {
            return GetConfig().ConnString; // Default Server
        }
    }

}

