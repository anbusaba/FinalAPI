using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.Domain.DBEntities
{
    public class BayLiveData
     {
        public int bayLiveId { get; set; }
        public int bayID { get; set; }
        public DateTime DateTime { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }

    }
}
