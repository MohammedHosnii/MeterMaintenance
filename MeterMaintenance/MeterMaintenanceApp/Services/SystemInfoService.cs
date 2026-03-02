using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MeterMaintenanceDB;
using MeterMaintenanceDB.Model;

namespace MeterMaintenanceApp.Services
{
    public class SystemInfoService : IDisposable
    {
        private readonly SystemInfo _systemInfo;
        private SqlConnection _connection;
        private CompanySectorDeptRepository _compRepo;
        private LabCenterRepository _labRepo;
        private TestResultRepository _testResultRepo;
        private CorrectiveActionRepository _correctiveActionRepo;
        public SystemInfoService()
        {
            _systemInfo = new SystemInfo();
        }

        public async Task<bool> InitializeAsync()
        {
            // Initialize connection info
            await _systemInfo.GetActiveConnectionAsync();

            if (string.IsNullOrEmpty(_systemInfo.ConnectionStr_Local))
                throw new InvalidOperationException("Local connection string not initialized.");

            // Open connection once
            _connection = new SqlConnection(_systemInfo.ConnectionStr_Local);
            await _connection.OpenAsync();

            _compRepo = new CompanySectorDeptRepository(_connection);
            _labRepo = new LabCenterRepository(_connection);
            _testResultRepo = new TestResultRepository(_connection);
            _correctiveActionRepo=new CorrectiveActionRepository(_connection);
            // Collect system info
            if (_connection.State == System.Data.ConnectionState.Open)
                _systemInfo.CollectSystemInfo();

            return _systemInfo.IsOnline;
        }

        public int GetUnSyncedCount() => _systemInfo.GetUnSyncedRecordCount();

        public SystemSnapshotDto GetSystemSnapshot() => new SystemSnapshotDto
        {
            UserCode = _systemInfo.userCode,
            UserName = _systemInfo.userName,
            MaxUnSyncedCount = _systemInfo.MaxUnSyncedCount,
            IsOnline = _systemInfo.IsOnline
        };

        public async Task<List<CompanyDto>> GetCompaniesAsync()
        {
            var companies = await _compRepo.GetALLCompany();
            return companies.Select(c => new CompanyDto
            {
                Id = c.Id,
                CompanySectorDeptName = c.CompanySectorDeptName
            }).ToList();
        }

        public async Task<List<TestResult>> GetTestResultAsync()
        {
            var testResult = await _testResultRepo.GetAllAsync();
            return testResult.Select(c => new TestResult
            {
                Id = c.Id,
                TestResultName = c.TestResultName,
                TestResultCode = c.TestResultCode
            }).ToList();
        }

        public async Task<List<CorrectiveAction>> GetCorrectiveActionAsync()
        {
            var correctiveAction = await _correctiveActionRepo.GetAllAsync();
            return correctiveAction.Select(c => new CorrectiveAction
            {
                Id = c.Id,
                CorrectiveActionName = c.CorrectiveActionName,
                CorrectiveActionCode = c.CorrectiveActionCode
            }).ToList();
        }

        public async Task<List<CompanyDto>> GetSectorsAsync(int companyId)
        {
            var sectors = await _compRepo.GetALLSectors(companyId);
            return sectors.Select(c => new CompanyDto
            {
                Id = c.Id,
                CompanySectorDeptName = c.CompanySectorDeptName
            }).ToList();
        }

        public async Task<List<CompanyDto>> GetDepartmentsAsync(int sectorId)
        {
            var deps = await _compRepo.GetALLDepartments(sectorId);
            return deps.Select(c => new CompanyDto
            {
                Id = c.Id,
                CompanySectorDeptName = c.CompanySectorDeptName
            }).ToList();
        }

        public async Task<List<LabCenterDto>> GetLabCentersAsync()
        {
            var labs = await _labRepo.GetAllAsync();
            return labs.Select(l => new LabCenterDto
            {
                Id = l.Id,
                LabCenterName = l.LabCenterName
            }).ToList();
        }
        public string GetConnectionString()
        {
            return _systemInfo.ConnectionStr_Local;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }



    // DTOs
    public class SystemSnapshotDto
    {
        public int UserCode { get; set; }
        public string UserName { get; set; }
        public int MaxUnSyncedCount { get; set; }
        public bool IsOnline { get; set; }
    }

    public class CompanyDto
    {
        public int Id { get; set; }
        public string CompanySectorDeptName { get; set; }
    }

    public class LabCenterDto
    {
        public int Id { get; set; }
        public string LabCenterName { get; set; }
    }
}
