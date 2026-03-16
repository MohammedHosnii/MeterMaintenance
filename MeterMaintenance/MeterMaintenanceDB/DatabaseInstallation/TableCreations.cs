using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceDB.DatabaseInstallation
{
    public class TableCreations
    {
        private readonly SqlConnection _conn;

        public TableCreations(SqlConnection conn)
        {
            _conn = conn;
            _conn.ChangeDatabase("MeterMaintenance_LocalDB");
        }

        public void CreateTables(string userCode, string userName)
        {
            CreateCompanySectorDept();
            CreateCorrectiveAction();
            CreateLabCenter();
            CreateMaintenanceRecord(userCode);
            CreateMaintenanceRecordDetail();
            CreateSystemTable(userCode);
            CreateTestResult();
            CreateUsersTable(userCode, userName);
        }

        // ========================= Table Functions =========================

        private void CreateCompanySectorDept()
        {
            string sql = @"
            IF OBJECT_ID('dbo.CompanySectorDept', 'U') IS NULL
            CREATE TABLE dbo.CompanySectorDept(
                Id INT IDENTITY(1,1) PRIMARY KEY,
                CompanySectorDeptCode INT NOT NULL,
                CompanySectorDeptName NVARCHAR(150) NOT NULL,
                CompanySectorDept_Level INT NOT NULL,
                ParentId INT NOT NULL
            );";
            ExecuteNonQuery(sql);
        }

        private void CreateCorrectiveAction()
        {
            string sql = @"
            IF OBJECT_ID('dbo.CorrectiveAction', 'U') IS NULL
            CREATE TABLE dbo.CorrectiveAction(
                Id INT IDENTITY(1,1) PRIMARY KEY,
                CorrectiveActionCode INT NOT NULL,
                CorrectiveActionName NVARCHAR(150) NOT NULL
            );";
            ExecuteNonQuery(sql);
        }

        private void CreateLabCenter()
        {
            string sql = @"
            IF OBJECT_ID('dbo.LabCenter', 'U') IS NULL
            CREATE TABLE dbo.LabCenter(
                Id INT IDENTITY(1,1) PRIMARY KEY,
                LabCenterName NVARCHAR(150) NOT NULL
            );";
            ExecuteNonQuery(sql);
        }

        private void CreateMaintenanceRecord(string userCode)
        {
            string sql = $@"
            IF OBJECT_ID('dbo.MaintenanceRecord', 'U') IS NULL
            CREATE TABLE dbo.MaintenanceRecord(
                Id INT IDENTITY(1,1) PRIMARY KEY,
                MaintenanceRecordDate DATETIME NOT NULL,
                CompanySectorDept_Id INT NOT NULL,
                LabCenter_Id INT NOT NULL,
                MeterCount INT NOT NULL,
                WorkingMetersCount INT NOT NULL,
                RepairedMetersCount INT NOT NULL,
                RetiredMetersCount INT NOT NULL,
                MaintenanceRecordCode BIGINT NOT NULL,
                ISSync BIT NOT NULL DEFAULT(0),
                CompanySectorDept_Level INT NOT NULL DEFAULT(1),
                UserId INT NOT NULL DEFAULT({userCode})
            );";
            ExecuteNonQuery(sql);
        }

        private void CreateMaintenanceRecordDetail()
        {
            string sql = @"
            IF OBJECT_ID('dbo.MaintenanceRecord_Detail', 'U') IS NULL
            CREATE TABLE dbo.MaintenanceRecord_Detail(
                Id INT IDENTITY(1,1) PRIMARY KEY,
                MaintenanceRecordCode BIGINT NOT NULL,
                MeterNumber BIGINT NOT NULL,
                TestResultCode INT NOT NULL,
                CorrectiveActionCode BIGINT NOT NULL,
	            [ErrorNumber] [int] NOT NULL,
	            [CreationDateTime] [datetime] NOT NULL,
	            [Notes] [nvarchar](150) NULL,
	            [ModificationDateTime] [datetime] NULL,             
                ISSync BIT NOT NULL DEFAULT(0)
            );

            IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_MaintenanceRecordDetail_Code_Meter')
            CREATE UNIQUE INDEX UX_MaintenanceRecordDetail_Code_Meter
            ON dbo.MaintenanceRecord_Detail(MaintenanceRecordCode, MeterNumber);";
            ExecuteNonQuery(sql);
        }

        private void CreateSystemTable(string userCode)
        {
            string sql = $@"
            IF OBJECT_ID('dbo.System', 'U') IS NULL
            CREATE TABLE dbo.System(
                Id INT IDENTITY(1,1) PRIMARY KEY,
                UserCode INT NOT NULL,
                MaxUnSyncedCount INT NOT NULL
            );

            IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_System_SingleRow')
            CREATE UNIQUE INDEX UX_System_SingleRow ON dbo.System(UserCode);

            IF NOT EXISTS (SELECT 1 FROM dbo.System WHERE UserCode = {userCode})
            INSERT INTO dbo.System (UserCode, MaxUnSyncedCount) VALUES ({userCode}, 3);";
            ExecuteNonQuery(sql);
        }

        private void CreateTestResult()
        {
            string sql = @"
            IF OBJECT_ID('dbo.TestResult', 'U') IS NULL
            CREATE TABLE dbo.TestResult(
                Id INT IDENTITY(1,1) PRIMARY KEY,
                TestResultCode INT NOT NULL,
                TestResultName NVARCHAR(150) NOT NULL
            );";
            ExecuteNonQuery(sql);
        }

        private void CreateUsersTable(string userCode, string userName)
        {
            string sql = $@"
            IF OBJECT_ID('dbo.Users', 'U') IS NULL
            CREATE TABLE dbo.Users(
                Id INT IDENTITY(1,1) PRIMARY KEY,
                UserCode INT NOT NULL,
                UserName NVARCHAR(50) NOT NULL,
                UserPassword NVARCHAR(50) NOT NULL,
                UserDegree INT NOT NULL
            );

            IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE UserCode = {userCode})
            INSERT INTO dbo.Users (UserCode, UserName, UserPassword, UserDegree)
            VALUES ({userCode}, N'{userName}', '123456', 1);";
            ExecuteNonQuery(sql);
        }

        // ========================= Helper =========================
        private void ExecuteNonQuery(string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

}
