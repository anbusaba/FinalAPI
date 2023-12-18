using Dapper;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.Domain.RepositoryContracts;
using SmartMonitoringSystem.Core.DTO;
using SmartMonitoringSystem.Infrastructure.DBContext;
using System.Data;
using System.Reflection.Metadata;

namespace SmartMonitoringSystem.Infrastructure.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly DapperContext _context;
        public DashboardRepository(DapperContext dapperContext)
        {
            _context = dapperContext;
        }

        public async Task<List<Member>> GetAllMembers()
        {
            using(var connection = _context.CreateConnection())
            {
                var results = await connection.QueryAsync<Member>(
                    "sp_GetAllMembers", 
                    commandType: CommandType.StoredProcedure
                 );
                return results?.ToList() ?? new List<Member>();
            }
        }

        public async Task<UserProfile> GetProfileByUserID(int userID)
        {
            using (var connection = _context.CreateConnection())
            {
                // Execute the stored procedure using Dapper
                var result = await connection.QueryFirstOrDefaultAsync<UserProfile>(
                    "sp_GetProfile",
                    new { userID },
                    commandType: CommandType.StoredProcedure
                );

                return result?? new UserProfile();
            }
        }

        public async Task<List<PhaseSummaryDetails>> GetSummaryDetailsByPhaseID(int phaseID)
        {
            using (var connection = _context.CreateConnection())
            {
                // Execute the stored procedure using Dapper
                var result = await connection.QueryAsync<PhaseSummaryDetails>(
                    "sp_GetSummaryDetailsByPhaseID",
                    new { phaseID },
                    commandType: CommandType.StoredProcedure
                );

                //return result?? new PhaseSummaryDetails();
                return result?.ToList() ?? new List<PhaseSummaryDetails>();
            }
        }

        public async Task<List<BaySummaryDetails>> GetAllPhases()
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var results = await connection.QueryAsync<BaySummaryDetails>(
                    "sp_GetAllPhases",
                    commandType: CommandType.StoredProcedure
                 );
                return results?.ToList() ?? new List<BaySummaryDetails>();
            }
        }

        public async Task<BaySummaryDetails> CreateBayByPhaseID(BaySummaryDetails baySummaryDetails, int phaseID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("organisationId", baySummaryDetails.OrganizationID, DbType.Int32);
            parameters.Add("bayName",baySummaryDetails.BayName , DbType.String);
            parameters.Add("phaseId", phaseID, DbType.Int32);
            parameters.Add("floor", baySummaryDetails.Floor, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync("sp_AddBaybyPhaseID", parameters);
                var result = new BaySummaryDetails
                {
                    BayName = baySummaryDetails.BayName,
                    Phase = baySummaryDetails.Phase,
                    Floor = baySummaryDetails.Floor,
                    OrganizationID = baySummaryDetails.OrganizationID
                };

                return result;
            }
        }

        public async Task<List<BaySummaryDetails>> GetBayDetailsByPhaseID(int phaseID)
        {
            using (var connection = _context.CreateConnection())
            {
                // Execute the stored procedure using Dapper
                var result = await connection.QueryAsync<BaySummaryDetails>(
                    "sp_GetBayDetailsByPhaseID",
                    new { phaseId = phaseID },
                    commandType: CommandType.StoredProcedure
                );

                return result?.ToList() ?? new List<BaySummaryDetails>();
            }
        }
        public async Task<List<PhaseSummaryDetails>> GetSummaryDetailsByBayID(int bayID)
        {
            using (var connection = _context.CreateConnection())
            {
                // Execute the stored procedure using Dapper
                var result = await connection.QueryAsync<PhaseSummaryDetails>(
                    "sp_GetSummaryDetailsByBayID",
                    new { bayID = bayID},
                    commandType: CommandType.StoredProcedure
                );

                // return result ?? new PhaseSummaryDetails();
                return result?.ToList() ?? new List<PhaseSummaryDetails>();
                //Console.WriteLine(bar);
                //return OkResult;
            }
        }
        //public async Task<PhaseSummaryDetails> PutBayLiveData(PhaseSummaryDetails baySummaryDetails, int bayID)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("bay_Id", bayID, DbType.Int32);
        //    parameters.Add("temparture_data", baySummaryDetails.Temperature, DbType.Int32);

        //    using (var connection = _context.CreateConnection())
        //    {
        //        var id = await connection.ExecuteAsync("sp_UpdateTemperature", parameters);
        //        var result = new PhaseSummaryDetails
        //        {
        //            BayID = bayID
        //        };

        //        return result;
        //    }
        //}

        public async Task<List<NotificationDetails>> GetNotifications()
        {
            using (var connection = _context.CreateConnection())
            {
                // Execute the stored procedure using Dapper
                var result = await connection.QueryAsync<NotificationDetails>(
                    "sp_GetNotification",
                    commandType: CommandType.StoredProcedure
                );

                return result?.ToList() ?? new List<NotificationDetails>();
            }
        }

        public async Task<List<NotificationDetails>> GetGlobalSearch(string word)
        {
            using var connection = _context.CreateConnection();
            // Execute the stored procedure using Dapper
            var result = await connection.QueryAsync<NotificationDetails>(
                "sp_GetGlobalSearch",
                new { word },
                commandType: CommandType.StoredProcedure
            );

            return result?.ToList() ?? new List<NotificationDetails>();
        }
    }
}
