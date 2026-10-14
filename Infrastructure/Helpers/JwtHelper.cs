using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Helpers
{
    public class JwtHelper
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public int ExpirationInDays { get; set; }
        public string? Key { get; set; }
    }
}
