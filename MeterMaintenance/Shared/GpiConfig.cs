using System;

namespace Shared
{
    public class GpiConfig
    {
        public string ConnString { get; set; }
        public string ConnString_Local { get; set; }

        // Server DB
        public string GetServerDbName()
        {
            return GetDatabaseName(ConnString);
        }

        // Local DB
        public string GetLocalDbName()
        {
            return GetDatabaseName(ConnString_Local);
        }

        // Full connection strings
        public string GetServerConnectionString()
        {
            return ConnString;
        }

        public string GetLocalConnectionString()
        {
            return ConnString_Local;
        }

        private string GetDatabaseName(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                return null;

            var parameters = connectionString.Split(';');

            foreach (var param in parameters)
            {
                if (param.Trim().StartsWith("Database=", StringComparison.OrdinalIgnoreCase))
                {
                    return param.Substring("Database=".Length).Trim();
                }
            }

            return null;
        }
    }

}
