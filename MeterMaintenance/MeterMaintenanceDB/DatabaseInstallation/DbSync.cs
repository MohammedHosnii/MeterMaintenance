using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceDB.DatabaseInstallation
{
    public class DbSync
    {
        private readonly SqlConnection _conn;

        public DbSync(SqlConnection conn)
        {
            _conn = conn;
            _conn.ChangeDatabase("MeterMaintenance_LocalDB");
        }

		public void createSP_Fun()
		{
			EnsureLinkedServer();
			CreateSyncAllTablesSP();
			CreateGetCompanySectorDeptFunction();
		}
        // ========================= Linked Server =========================
        public void EnsureLinkedServer()
        {
            string sql = $@"
                IF NOT EXISTS (SELECT * FROM sys.servers WHERE name = 'ServerDB')
                BEGIN
                    EXEC master.dbo.sp_addlinkedserver 
                        @server = N'ServerDB', 
                        @srvproduct = N'', 
                        @provider = N'SQLNCLI', 
                        @datasrc = N'192.168.15.10';

                    EXEC master.dbo.sp_addlinkedsrvlogin 
                        @rmtsrvname = N'ServerDB', 
                        @useself = N'False', 
                        @locallogin = NULL, 
                        @rmtuser = N'sa', 
                        @rmtpassword = N'Giza@123456';
                END
                ";
                ExecuteNonQuery(sql);
        }

        // ========================= Stored Procedure Creation =========================
        public void CreateSyncAllTablesSP()
        {
            string sql = @"
            
			CREATE PROCEDURE [dbo].[Sync_All_Tables]
			AS
			BEGIN
				SET NOCOUNT ON;

				BEGIN TRY

				-----------------------------------------------------
				-- CompanySectorDept
				-----------------------------------------------------
				SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.CompanySectorDept ON;

				MERGE MeterMaintenance_LocalDB.dbo.CompanySectorDept AS T
				USING ServerDB.MeterMaintenanceDB.dbo.CompanySectorDept AS S
				ON T.Id = S.Id
				WHEN MATCHED THEN UPDATE SET
					T.CompanySectorDeptCode = S.CompanySectorDeptCode,
					T.CompanySectorDeptName = S.CompanySectorDeptName,
					T.CompanySectorDept_Level = S.CompanySectorDept_Level,
					T.ParentId = S.ParentId
				WHEN NOT MATCHED BY TARGET THEN
					INSERT (Id, CompanySectorDeptCode, CompanySectorDeptName, CompanySectorDept_Level, ParentId)
					VALUES (S.Id, S.CompanySectorDeptCode, S.CompanySectorDeptName, S.CompanySectorDept_Level, S.ParentId)
				WHEN NOT MATCHED BY SOURCE THEN DELETE;

				SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.CompanySectorDept OFF;


				-----------------------------------------------------
				-- CorrectiveAction
				-----------------------------------------------------
				SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.CorrectiveAction ON;

				MERGE MeterMaintenance_LocalDB.dbo.CorrectiveAction AS T
				USING ServerDB.MeterMaintenanceDB.dbo.CorrectiveAction AS S
				ON T.Id = S.Id
				WHEN MATCHED THEN UPDATE SET
					T.CorrectiveActionCode = S.CorrectiveActionCode,
					T.CorrectiveActionName = S.CorrectiveActionName
				WHEN NOT MATCHED BY TARGET THEN
					INSERT (Id, CorrectiveActionCode, CorrectiveActionName)
					VALUES (S.Id, S.CorrectiveActionCode, S.CorrectiveActionName)
				WHEN NOT MATCHED BY SOURCE THEN DELETE;

				SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.CorrectiveAction OFF;


				-----------------------------------------------------
				-- LabCenter
				-----------------------------------------------------
				SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.LabCenter ON;

				MERGE MeterMaintenance_LocalDB.dbo.LabCenter AS T
				USING ServerDB.MeterMaintenanceDB.dbo.LabCenter AS S
				ON T.Id = S.Id
				WHEN MATCHED THEN UPDATE SET
					T.LabCenterName = S.LabCenterName
				WHEN NOT MATCHED BY TARGET THEN
					INSERT (Id, LabCenterName)
					VALUES (S.Id, S.LabCenterName)
				WHEN NOT MATCHED BY SOURCE THEN DELETE;

				SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.LabCenter OFF;


				-----------------------------------------------------
				-- TestResult
				-----------------------------------------------------
				SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.TestResult ON;

				MERGE MeterMaintenance_LocalDB.dbo.TestResult AS T
				USING ServerDB.MeterMaintenanceDB.dbo.TestResult AS S
				ON T.Id = S.Id
				WHEN MATCHED THEN UPDATE SET
					T.TestResultCode = S.TestResultCode,
					T.TestResultName = S.TestResultName
				WHEN NOT MATCHED BY TARGET THEN
					INSERT (Id, TestResultCode, TestResultName)
					VALUES (S.Id, S.TestResultCode, S.TestResultName)
				WHEN NOT MATCHED BY SOURCE THEN DELETE;

				SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.TestResult OFF;


				-----------------------------------------------------
				-- Users
				-----------------------------------------------------
				SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.Users ON;

				MERGE MeterMaintenance_LocalDB.dbo.Users AS T
				USING ServerDB.MeterMaintenanceDB.dbo.Users AS S
				ON T.Id = S.Id
				WHEN MATCHED THEN UPDATE SET
					T.UserCode = S.UserCode,
					T.UserName = S.UserName,
					T.UserPassword = S.UserPassword,
					T.UserDegree = S.UserDegree
				WHEN NOT MATCHED BY TARGET THEN
					INSERT (Id, UserCode, UserName, UserPassword, UserDegree)
					VALUES (S.Id, S.UserCode, S.UserName, S.UserPassword, S.UserDegree)
				WHEN NOT MATCHED BY SOURCE THEN DELETE;

				SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.Users OFF;


			--------------------XXXXXXXX---------------------------------
			/* =====================================================
			MaintenanceRecord (HEADER)
			===================================================== */

			-----------------------------------------------------
			-- Local → Server : UPDATE existing
			-----------------------------------------------------
						UPDATE S
						SET
							S.MaintenanceRecordDate   = L.MaintenanceRecordDate,
							S.CompanySectorDept_Id    = L.CompanySectorDept_Id,
							S.LabCenter_Id            = L.LabCenter_Id,
							S.MeterCount              = L.MeterCount,
							S.WorkingMetersCount      = L.WorkingMetersCount,
							S.RepairedMetersCount     = L.RepairedMetersCount,
							S.RetiredMetersCount      = L.RetiredMetersCount,
							S.CompanySectorDept_Level = L.CompanySectorDept_Level,
							s.ISSync=L.ISSync
						FROM ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord S
						JOIN MeterMaintenance_LocalDB.dbo.MaintenanceRecord L
							ON S.MaintenanceRecordCode = L.MaintenanceRecordCode
						WHERE L.ISSync = 0;

						-----------------------------------------------------
						-- Local → Server : INSERT new
						-----------------------------------------------------
						INSERT INTO ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord (
							MaintenanceRecordDate,
							CompanySectorDept_Id,
							LabCenter_Id,
							MeterCount,
							WorkingMetersCount,
							RepairedMetersCount,
							RetiredMetersCount,
							MaintenanceRecordCode,
							CompanySectorDept_Level,
							UserId,
							ISSync
						)
						SELECT
							L.MaintenanceRecordDate,
							L.CompanySectorDept_Id,
							L.LabCenter_Id,
							L.MeterCount,
							L.WorkingMetersCount,
							L.RepairedMetersCount,
							L.RetiredMetersCount,
							L.MaintenanceRecordCode,
							L.CompanySectorDept_Level,
							L.UserId,
							L.ISSync
						FROM MeterMaintenance_LocalDB.dbo.MaintenanceRecord L
						WHERE L.ISSync = 0
						AND NOT EXISTS (
							SELECT 1
							FROM ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord S
							WHERE S.MaintenanceRecordCode = L.MaintenanceRecordCode
						);

						-----------------------------------------------------
						-- mark header synced
						-----------------------------------------------------
						UPDATE MeterMaintenance_LocalDB.dbo.MaintenanceRecord
						SET ISSync = 1
						WHERE ISSync = 0;

						-----------------------------------------------------
						-- Server → Local (MERGE allowed)
						-----------------------------------------------------
						MERGE MeterMaintenance_LocalDB.dbo.MaintenanceRecord AS T
						USING ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord AS S
						ON T.MaintenanceRecordCode = S.MaintenanceRecordCode

						WHEN MATCHED THEN
						UPDATE SET
							T.MaintenanceRecordDate   = S.MaintenanceRecordDate,
							T.CompanySectorDept_Id    = S.CompanySectorDept_Id,
							T.LabCenter_Id            = S.LabCenter_Id,
							T.MeterCount              = S.MeterCount,
							T.WorkingMetersCount      = S.WorkingMetersCount,
							T.RepairedMetersCount     = S.RepairedMetersCount,
							T.RetiredMetersCount      = S.RetiredMetersCount,
							T.CompanySectorDept_Level = S.CompanySectorDept_Level,
							T.ISSync = 1

						WHEN NOT MATCHED THEN
						INSERT (
							MaintenanceRecordDate,
							CompanySectorDept_Id,
							LabCenter_Id,
							MeterCount,
							WorkingMetersCount,
							RepairedMetersCount,
							RetiredMetersCount,
							MaintenanceRecordCode,
							CompanySectorDept_Level,
							ISSync,
							UserId
						)
						VALUES (
							S.MaintenanceRecordDate,
							S.CompanySectorDept_Id,
							S.LabCenter_Id,
							S.MeterCount,
							S.WorkingMetersCount,
							S.RepairedMetersCount,
							S.RetiredMetersCount,
							S.MaintenanceRecordCode,
							S.CompanySectorDept_Level,
							1,
							S.UserId
						);

				UPDATE ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord
						SET ISSync = 1
						WHERE ISSync = 0;

			/* =====================================================
			MaintenanceRecord_Detail
			===================================================== */

			-----------------------------------------------------
			-- Local → Server : UPDATE existing
			-----------------------------------------------------
						UPDATE S
						SET
							S.TestResultCode        = L.TestResultCode,
							S.CorrectiveActionCode  = L.CorrectiveActionCode,
							S.ErrorNumber           = L.ErrorNumber,
							S.CreationDateTime      = L.CreationDateTime,
							S.Notes                 = L.Notes,
							S.ModificationDateTime  = L.ModificationDateTime,
							S.ISSync                = L.ISSync
						FROM ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord_Detail S
						JOIN MeterMaintenance_LocalDB.dbo.MaintenanceRecord_Detail L
							ON S.MaintenanceRecordCode = L.MaintenanceRecordCode
						   AND S.MeterNumber = L.MeterNumber
						WHERE L.ISSync = 0;

						-----------------------------------------------------
						-- Local → Server : INSERT new
						-----------------------------------------------------
						INSERT INTO ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord_Detail
						(
							MaintenanceRecordCode,
							MeterNumber,
							TestResultCode,
							CorrectiveActionCode,
							ErrorNumber,
							CreationDateTime,
							Notes,
							ModificationDateTime,
							ISSync
						)
						SELECT
							L.MaintenanceRecordCode,
							L.MeterNumber,
							L.TestResultCode,
							L.CorrectiveActionCode,
							L.ErrorNumber,
							L.CreationDateTime,
							L.Notes,
							L.ModificationDateTime,
							L.ISSync
						FROM MeterMaintenance_LocalDB.dbo.MaintenanceRecord_Detail L
						WHERE L.ISSync = 0
						AND NOT EXISTS
						(
							SELECT 1
							FROM ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord_Detail S
							WHERE S.MaintenanceRecordCode = L.MaintenanceRecordCode
							  AND S.MeterNumber = L.MeterNumber
						);
						-----------------------------------------------------
						-- mark detail synced
						-----------------------------------------------------
						UPDATE MeterMaintenance_LocalDB.dbo.MaintenanceRecord_Detail
						SET ISSync = 1
						WHERE ISSync = 0;

						-----------------------------------------------------
						-- Server → Local
						-----------------------------------------------------
						MERGE MeterMaintenance_LocalDB.dbo.MaintenanceRecord_Detail AS T
						USING ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord_Detail AS S
						ON T.MaintenanceRecordCode = S.MaintenanceRecordCode
						AND T.MeterNumber = S.MeterNumber

						WHEN MATCHED THEN
						UPDATE SET
							T.TestResultCode        = S.TestResultCode,
							T.CorrectiveActionCode  = S.CorrectiveActionCode,
							T.ErrorNumber           = S.ErrorNumber,
							T.CreationDateTime      = S.CreationDateTime,
							T.Notes                 = S.Notes,
							T.ModificationDateTime  = S.ModificationDateTime,
							T.ISSync                = 1

						WHEN NOT MATCHED THEN
						INSERT
						(
							MaintenanceRecordCode,
							MeterNumber,
							TestResultCode,
							CorrectiveActionCode,
							ErrorNumber,
							CreationDateTime,
							Notes,
							ModificationDateTime,
							ISSync
						)
						VALUES
						(
							S.MaintenanceRecordCode,
							S.MeterNumber,
							S.TestResultCode,
							S.CorrectiveActionCode,
							S.ErrorNumber,
							S.CreationDateTime,
							S.Notes,
							S.ModificationDateTime,
							1
						);


						UPDATE ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord_Detail
						SET ISSync = 1
						WHERE ISSync = 0;

			   -------------------------------XXXXXXXx---------
				END TRY
				BEGIN CATCH

					SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.CompanySectorDept OFF;
					SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.CorrectiveAction OFF;
					SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.LabCenter OFF;
					SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.TestResult OFF;
					SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.Users OFF;
					SET IDENTITY_INSERT MeterMaintenance_LocalDB.dbo.MaintenanceRecord OFF;

					THROW;
				END CATCH

			END;

            

            ";
            ExecuteNonQuery(sql);
        }

        // ========================= Function Creation =========================
        public void CreateGetCompanySectorDeptFunction()
        {
            string sql = @"
				

				CREATE FUNCTION dbo.GetCompanySectorDept (@id INT)
				RETURNS NVARCHAR(150)
				AS
				BEGIN
					DECLARE @ResultVar NVARCHAR(150);

					SELECT @ResultVar = CompanySectorDeptName
					FROM dbo.CompanySectorDept
					WHERE Id = @id;

					RETURN @ResultVar;
				END;
				
			";
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
