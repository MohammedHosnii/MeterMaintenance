using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MeterMaintenanceDB.Model;

namespace MeterMaintenanceDB
{
   

    public class MaintenanceRecordViewRepository
    {
        private readonly IDbConnection _db;

        public MaintenanceRecordViewRepository(IDbConnection db)
        {
            _db = db;
        }

        private const string BaseQuery = @"
        SELECT  
        MR.MaintenanceRecordDate,
        CSD.CompanySectorDeptName,
        MR.MeterCount,
        MR.WorkingMetersCount,
        MR.RepairedMetersCount,
        MR.RetiredMetersCount,
        MR.MaintenanceRecordCode,
        MR.ISSync,
        CASE MR.CompanySectorDept_Level
        WHEN 1 THEN N'شركة'
        WHEN 2 THEN N'قطاع'
        WHEN 3 THEN N'هندسة'
        END AS [CompanySectorDept_Level],
        LC.LabCenterName
        FROM dbo.MaintenanceRecord MR
        INNER JOIN dbo.LabCenter LC 
        ON MR.LabCenter_Id = LC.Id
        INNER JOIN dbo.CompanySectorDept CSD 
        ON MR.CompanySectorDept_Id = CSD.Id
        
        ";

        
        public async Task<IEnumerable<MaintenanceRecordView>> GetAllAsync()
        {
            return await _db.QueryAsync<MaintenanceRecordView>(BaseQuery+@"   WHERE  MR.UserId ="+SystemInfo.userId);
        }

     
        public async Task<IEnumerable<MaintenanceRecordView>>
            GetByDepartmentAsync(int deptId)
        {
            var sql = BaseQuery + @"
                WHERE  MR.UserId ="+SystemInfo.userId+@"
                AND (  CSD.Id = @DeptId 
                OR CSD.ParentId = @DeptId)";

            return await _db.QueryAsync<MaintenanceRecordView>(
                sql,
                new { DeptId = deptId }
            );
        }


        public async Task<IEnumerable<MaintenanceRecordView>>
            GetByWhereAsync(string whereStr)
        {
            var sql = BaseQuery + @"
                WHERE  MR.UserId =" + SystemInfo.userId + @"
                  " +whereStr+@"
                 ";

            return await _db.QueryAsync<MaintenanceRecordView>(
                sql
            );
        }
    }

}
