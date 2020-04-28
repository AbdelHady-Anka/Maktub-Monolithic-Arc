using System;
using System.Collections.Generic;
using System.Text;

namespace Maktoob.Domain.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
