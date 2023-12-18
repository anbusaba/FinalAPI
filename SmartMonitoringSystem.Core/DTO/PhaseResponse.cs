using SmartMonitoringSystem.Core.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.DTO
{
    public class PhaseResponse
    {
        public int Phase { get; set; }
    }

    public static class PhaseExtensions
    {
        public static PhaseResponse ToPhaseResponse(this BaySummaryDetails phase)
        {
            return new PhaseResponse() { Phase = phase.Phase};
        }
    }
}
