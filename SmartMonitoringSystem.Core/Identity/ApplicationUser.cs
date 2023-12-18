﻿using Microsoft.AspNetCore.Identity;

namespace SmartMonitoringSystem.Core.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? PersonName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationDatatime { get; set; }


    }
}
