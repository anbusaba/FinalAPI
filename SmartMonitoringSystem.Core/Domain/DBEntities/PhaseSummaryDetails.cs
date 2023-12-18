namespace SmartMonitoringSystem.Core.Domain.DBEntities
{
    public class PhaseSummaryDetails
    {
        public int Phase { get; set; }
        public int BayID { get; set; }

        public string? BayName { get; set; }
        public string? Floor { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public DateTime DateTime { get; set; }

    }
}
