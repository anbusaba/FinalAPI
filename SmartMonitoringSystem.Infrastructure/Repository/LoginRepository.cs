using Dapper;
using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.Domain.RepositoryContracts;
using SmartMonitoringSystem.Core.DTO;
using SmartMonitoringSystem.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Infrastructure.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DapperContext _context;
        public LoginRepository(DapperContext dapperContext)
        {
            _context = dapperContext;
        }
        public async Task<int> LoginUser(LoginDto loginDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("email", loginDTO.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("password", loginDTO.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("id", 0, DbType.Int32, ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute("sp_IsValidUser", parameters, commandType: CommandType.StoredProcedure);
                int userID = parameters.Get<int>("id");
                return userID;
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

                return result ?? new UserProfile();
            }
        }
    }
}
