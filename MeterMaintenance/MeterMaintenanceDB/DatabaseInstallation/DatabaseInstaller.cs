using MeterMaintenanceDB.DatabaseInstallation;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MeterMaintenanceDB
{
    public class DatabaseInstaller
    {
        private  SqlConnection _serverConnection;
        private TableCreations _tableCreations;
        private DbSync  _dbSync;
        public DatabaseInstaller(SqlConnection serverConnection)
        {
            _serverConnection = serverConnection;
           
        }

        public void Install(string userCode, string userName)
        {
            using (SqlConnection conn = _serverConnection)
            {
                conn.Open();

                //CreateDatabase(conn);
                _tableCreations = new TableCreations(conn);
               
                _tableCreations.CreateTables(userCode,userName);
                _dbSync = new DbSync(conn);
                _dbSync.createSP_Fun();
            }
        }

        //public void CreateDatabase(SqlConnection conn)
        //{
        //    string sql = @" 
        //        IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'MeterMaintenance_LocalDB')
        //        BEGIN
        //            CREATE DATABASE [MeterMaintenance_LocalDB] COLLATE Arabic_100_CI_AS;
        //        END
        //    ";

        //    ExecuteNonQuery(conn, sql);
        //}
        public void CreateDatabase()
        {
            //using (SqlConnection conn = _serverConnection)
            //{
               
               if(_serverConnection.State!=ConnectionState.Open) _serverConnection.Open();

                string sql = @"
                USE [master];
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'MeterMaintenance_LocalDB')
                BEGIN
                    CREATE DATABASE [MeterMaintenance_LocalDB] COLLATE Arabic_100_CI_AS;
                END";

                using (SqlCommand cmd = new SqlCommand(sql, _serverConnection))
                {
                    cmd.ExecuteNonQuery();
                }
            //}
        }

        public void CreateTables(string userCode, string userName)
        {
            //using (SqlConnection conn = _serverConnection)
            //{
                if (_serverConnection.State != ConnectionState.Open) _serverConnection.Open();
                var tableCreations = new TableCreations(_serverConnection);
                tableCreations.CreateTables(userCode, userName);
            //}
        }

        public void CreateStoredProcedures()
        {
            //using (SqlConnection conn = CreateLocalDbConnection())
            //{
            //conn.Open();
            if (_serverConnection.State != ConnectionState.Open) _serverConnection.Open();
            var dbSync = new DbSync(_serverConnection);
                dbSync.createSP_Fun();
           // }
        }
        public async Task ExecSPSyncAsync()
        {
            //using (SqlConnection conn = CreateLocalDbConnection())
            //{
            if (_serverConnection.State != ConnectionState.Open) await _serverConnection.OpenAsync();

                var syncRepo = new SyncRepository(_serverConnection);
                await syncRepo.ExecuteSyncAllTablesAsync();
          //  }
        }

        private SqlConnection CreateLocalDbConnection()
        {
            var builder = new SqlConnectionStringBuilder( _serverConnection.ConnectionString)
            {
                InitialCatalog = "MeterMaintenance_LocalDB"
            };

            return new SqlConnection(builder.ConnectionString);
        }

        public void ExecuteNonQuery(SqlConnection conn, string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
