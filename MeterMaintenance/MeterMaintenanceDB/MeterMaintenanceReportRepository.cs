using Dapper;
using MeterMaintenanceDB.Model;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MeterMaintenanceDB
{


    public class MeterMaintenanceReportRepository
    {
        private readonly IDbConnection _db;

        public MeterMaintenanceReportRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<List<MeterMaintenanceReport>> GetReportAsync(long maintenanceRecordCode)
        {
            string sql = @"
                WITH CompanyHierarchy AS
                (
                -- Root companies
                SELECT 
                Id,
                CompanySectorDeptName,
                ParentId,
                Id AS RootId
                FROM dbo.CompanySectorDept
                WHERE ParentId = 0

                UNION ALL

                -- Children
                SELECT 
                C.Id,
                C.CompanySectorDeptName,
                C.ParentId,
                H.RootId
                FROM dbo.CompanySectorDept C
                INNER JOIN CompanyHierarchy H
                ON C.ParentId = H.Id
                )

                SELECT      
                MR.MaintenanceRecordDate,
                CSD.CompanySectorDeptName AS CompanySectorDept,
                LC.LabCenterName AS LabCenter,
                MR.MeterCount,
                MR.WorkingMetersCount,
                MR.RepairedMetersCount,
                MR.RetiredMetersCount,
                MR.MaintenanceRecordCode,
                MR.ISSync,
                MR.CompanySectorDept_Level,
                U.UserName AS [User],
                MRD.MeterNumber,
                TR.TestResultName AS TestResult,
                CA.CorrectiveActionName AS CorrectiveAction,

                ROOT.CompanySectorDeptName AS CompanyName

                FROM dbo.MaintenanceRecord_Detail MRD

                INNER JOIN dbo.MaintenanceRecord MR
                ON MRD.MaintenanceRecordCode = MR.MaintenanceRecordCode

                INNER JOIN dbo.CompanySectorDept CSD
                ON MR.CompanySectorDept_Id = CSD.Id

                INNER JOIN CompanyHierarchy CH
                ON CH.Id = MR.CompanySectorDept_Id

                INNER JOIN dbo.CompanySectorDept ROOT
                ON ROOT.Id = CH.RootId

                INNER JOIN dbo.LabCenter LC
                ON MR.LabCenter_Id = LC.Id

                INNER JOIN dbo.Users U
                ON MR.UserId = U.Id

                INNER JOIN dbo.TestResult TR
                ON MRD.TestResultCode = TR.TestResultCode

                INNER JOIN dbo.CorrectiveAction CA
                ON MRD.CorrectiveActionCode = CA.CorrectiveActionCode

                WHERE MR.MaintenanceRecordCode = @MaintenanceRecordCode";

            var result = await _db.QueryAsync<MeterMaintenanceReport>(
                sql,
                new { MaintenanceRecordCode = maintenanceRecordCode }
            );

            return result.AsList();
        }
    }
}
