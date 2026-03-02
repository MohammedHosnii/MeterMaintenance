using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceDB.DatabaseInstallation
{
    public class TestConnection
    {
        string ConnectionStr_Server;
        string ConnectionStr_Local_master;

       
        public TestConnection() 
        {
            var config = MeterMaintenanceShared.GPI.GetConfig();

            ConnectionStr_Server = config.ConnString;
            ConnectionStr_Local_master = config.ConnString_Local_master;

        }
        public bool CheckServerConnection()
        {
            try
            {
                
                using (SqlConnection testConn = new SqlConnection(ConnectionStr_Server))
                {
                    testConn.Open();

                    return true; // Connection succeeded
                }
            }
            catch
            {
                return false; // Could not connect
            }
        }

        public bool CheckLocalConnection() 
        {
            try
            {

                using (SqlConnection testConn = new SqlConnection(ConnectionStr_Local_master))
                {
                    testConn.Open();
                    return true; // Connection succeeded
                }
            }
            catch
            {
                return false; // Could not connect
            }
        }


        public SqlConnection GetServerConnection()
        {
            var conn = new SqlConnection(ConnectionStr_Server);
            conn.Open();
            return conn;  
        }

         
        public SqlConnection GetLocalConnection()
        {
           
            //var builder = new SqlConnectionStringBuilder(ConnectionStr_Local_master)
            //{
            //    InitialCatalog = "master"
            //};
            var conn = new SqlConnection(ConnectionStr_Local_master);
            conn.Open();
            return conn; 
        }
    }
}
