using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.DTO;
using SmartMonitoringSystem.Core.ServiceContracts;

namespace SmartMonitoringSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService dashboardService;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(IDashboardService dashboardService, ILogger<DashboardController> logger)
        {
            this.dashboardService = dashboardService;
            _logger = logger;
        }
        [HttpGet("GetProfile/{id:int}")]
        public async Task<ActionResult<UserProfileResponse>> GetProfile(int id)
        {
            try
            {
                var userProfileDetails = await dashboardService.GetProfileByUserID(id);
                if (userProfileDetails == null)
                {
                    return Problem(detail: "Invalid UserId", statusCode: 400);
                }
                return userProfileDetails;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in GetProfile, ");
                return new UserProfileResponse();

            }
            
        }
        [HttpGet("GetSummaryDetailsByPhaseID/{phaseID:int}")]
        public async Task<ActionResult<List<PhaseSummaryDetailsResponse>>> GetSummaryDetailsByPhaseID(int phaseID)
        {
            try
            {
                var summaryDetails = await dashboardService.GetSummaryDetailsByPhaseID(phaseID);
                if (summaryDetails == null)
                {
                    return Problem(detail: "Invalid Phase ID", statusCode: 400);
                }
                return summaryDetails;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in GetSummaryDetailsByPhaseID ");
                return new List<PhaseSummaryDetailsResponse>();
            }
           
        }
        [HttpGet("GetAllMembers")]
        public async Task<ActionResult<List<MemberResponse>>> GetAllMembers()
        {
            try
            {
                var allMembers = await dashboardService.GetAllMembers();
                if (allMembers == null)
                {
                    return Problem(detail: "No members found", statusCode: 400);
                }
                return allMembers;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in GetAllMembers");
                return new List<MemberResponse>();
            }
           
        }

        [HttpGet("GetAllPhases")]
        public async Task<ActionResult<List<PhaseResponse>>> GetAllPhases()
        {
            try
            {
                var allPhases = await dashboardService.GetAllPhases();
                if (allPhases == null)
                {
                    return Problem(detail: "No Such Phase found", statusCode: 400);
                }
                return allPhases;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in GetAllPhases");
                return new List<PhaseResponse>();
            }

        }

        [HttpPost("CreateBayByPhaseID/{phaseID:int}")]
        public async Task<ActionResult<BayResponse>> CreateBayByPhaseID(BaySummaryDetails bay,int phaseID)
        {
            try
            {
                var createdBay = await dashboardService.CreateBayByPhaseID(bay,phaseID); 
                if (createdBay == null)
                {
                    return Problem(detail: "No Such Phase found", statusCode: 400);
                }
                return createdBay;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in creating a bay");
                return new BayResponse();
            }
        }


        [HttpGet("GetSummaryDetailsByBayID/{bayID:int}")]
        public async Task<ActionResult<List<PhaseSummaryDetailsResponse>>> GetSummaryDetailsByBayID(int bayID)
        {
            try
            {
                var summaryDetails = await dashboardService.GetSummaryDetailsByBayID(bayID);
                if (summaryDetails == null)
                {
                    return Problem(detail: "Invalid Bay ID", statusCode: 400);
                }
                return summaryDetails;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in GetSummaryDetailsByBayID");
                return new List<PhaseSummaryDetailsResponse>();
            }
        }
        //[HttpPut("putBayLiveData/{bayId}")]
        //public async Task<ActionResult<PhaseSummaryDetailsResponse>> PutBayLiveData(int bayID, PhaseSummaryDetails bay)
        //{
        //    try
        //    {
        //        var updateBay = await dashboardService.PutBayLiveData(bay, bayID);
        //        if (updateBay == null)
        //        {
        //            return Problem(detail: "No Such bay found", statusCode: 400);
        //        }
        //        return updateBay;
        //    }
        //    catch (Exception)
        //    {
        //        _logger.LogError("Exception occurred in updating a bay");
        //        return new PhaseSummaryDetailsResponse();
        //    }
        //}

        [HttpGet("GetBayDetailsByPhaseID/{phaseID:int}")]
        public async Task<ActionResult<List<BayResponse>>> GetBayDetailsByPhaseID(int phaseID)
        {
            try
            {
                var summaryDetails = await dashboardService.GetBayDetailsByPhaseID(phaseID);
                if (summaryDetails == null)
                {
                    return Problem(detail: "Invalid Phase ID", statusCode: 400);
                }
                return summaryDetails;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in GetSummaryDetailsByPhaseID ");
                return new List<BayResponse>();
            }

        }

        /// <summary>
        /// To get the notification for every 15mins duration if temparature is above or equal to 25 degree
        /// </summary>
        /// <returns>Returns the temparature notification</returns>
        [HttpGet("GetNotifications")]
        public async Task<ActionResult<List<NotificationResponse>>> GetNotifications()
        {
            try
            {
                var result = await dashboardService.GetNotifications();
                if (result == null)
                {
                    return Problem(detail: "Temparature is not found", statusCode: 400);
                }
                return result;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in notifications");
                return new List<NotificationResponse>();
            }

        }
        /// <summary>
        /// Search based on the given inputs
        /// </summary>
        /// <returns>Returns the data in the response based on searched result</returns>
        [HttpGet("GetGlobalSearch")]
        public async Task<ActionResult<List<NotificationResponse>>> GetGlobalSearch(string searchRequest)
        {
            try
            {
                var searchResult = await dashboardService.GetGlobalSearch(searchRequest);
                if (searchResult == null)
                {
                    return Problem(detail: "Search result is not found", statusCode: 400);
                }
                return searchResult;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in search");
                return new List<NotificationResponse>();
            }

        }
    }
}
