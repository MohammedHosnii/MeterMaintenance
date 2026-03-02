using MeterMaintenanceShared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeterMaintenanceDB
{
    public  class SystemInfo
    {
        public   SqlConnection Connection_Server { get; set; }

        public static  SqlConnection Connection_Local { get; set; }

        public   string ConnectionStr_Server { get; set; }

        public  string ConnectionStr_Local { get; set; }
        public  bool IsOnline { get; set; }
        public  int userCode { get; set; }
        public   string userName { get; set; }

        public static int userId { get; set; }

        public string password { get; set; } = string.Empty;
        public  int MaxUnSyncedCount { get; set; }
        public int LastLogIdConfirmed { get; set; }
        
         
        public   async  Task GetActiveConnectionAsync()
        {
            var config = MeterMaintenanceShared.GPI.GetConfig();

            ConnectionStr_Server = config.ConnString;
            ConnectionStr_Local = config.ConnString_Local;
            IsOnline = false;
    
            if (await CanConnectAsync(ConnectionStr_Server))
            {
                Connection_Server = new SqlConnection(ConnectionStr_Server);
               
                IsOnline = true;
                
            }


            if (await CanConnectAsync(ConnectionStr_Local))
            {
                Connection_Local = new SqlConnection(ConnectionStr_Local);
                
            }

   
            Connection_Local = new SqlConnection(ConnectionStr_Local);
             
        }
        public  async Task<bool> CanConnectAsync(string connectionString)
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(connectionString)
                {
                    ConnectTimeout = 3  
                };
                using (var con = new SqlConnection(builder.ConnectionString))
                {
                    await con.OpenAsync();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public  void CollectSystemInfo()
        {
             SqlDataAdapter da= new SqlDataAdapter(@"SELECT TOP (1)dbo.Users.Id, dbo.System.UserCode, dbo.Users.UserName, dbo.Users.UserPassword, dbo.System.MaxUnSyncedCount
                FROM         dbo.System LEFT OUTER JOIN
                   dbo.Users ON dbo.System.UserCode = dbo.Users.UserCode
                ORDER BY dbo.System.Id DESC"
                , Connection_Local);
            DataTable dt = new DataTable();
            da.Fill(dt);

            userCode =Convert.ToInt32( dt.Rows[0]["UserCode"]);
            userName = dt.Rows[0]["UserName"].ToString();
            password=dt.Rows[0]["UserPassword"].ToString();
            MaxUnSyncedCount = Convert.ToInt32(dt.Rows[0]["MaxUnSyncedCount"]);
            userId = Convert.ToInt32(dt.Rows[0]["Id"]);
        }
       
       
        public  int GetUnSyncedRecordCount()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT  isnull(count(0),0)
            FROM [dbo].[MaintenanceRecord]
            where [ISSync]=0"
                    , Connection_Local);
            if (Connection_Local.State != ConnectionState.Open)
                Connection_Local.Open();
            int count = 0;

            count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }


    }
}
