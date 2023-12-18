using SmartMonitoringSystem.Core.Domain.DBEntities;

namespace SmartMonitoringSystem.Core.DTO
{
    public class PhaseSummaryDetailsResponse
    {
        public int Phase { get; set; }
        public int BayID { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public string? BayName { get; set; }
        public string? Floor { get; set; }

        public DateTime DateTime { get; set; }

    }
    public static class PhaseSummaryDetailsExtension
    {
        //Converts from PhaseSummaryDetails object to PhaseSummaryDetailsResponse object
        public static PhaseSummaryDetailsResponse ToPhaseSummaryDetailsResponse(this PhaseSummaryDetails phase)
        {
            return new PhaseSummaryDetailsResponse() { Phase = phase.Phase, BayID = phase.BayID, Temperature = phase.Temperature, Humidity = phase.Humidity,
                 BayName=phase.BayName,Floor=phase.Floor,DateTime=phase.DateTime};
        }
    }
}
